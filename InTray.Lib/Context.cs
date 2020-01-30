using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using InTray.Win32;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;

namespace InTray.Lib
{
    public partial class Context: IDisposable
    {
        public string ApplicationName { get; private set; }
        public string ProcessName { get; private set; }
        public string Executable { get; private set; }
        public string MainWindowClassName { get; private set; }
        public Regex MainWindowTextRegex { get; private set; }

        public event EventHandler<EventArgs> ContextExit;

        private Logger logger;
        private bool initialised;

        private Process process;
        private IntPtr mainWindowHandle;
        private bool windowShown = true;
        private WindowVisualState lastWindowVisualState = WindowVisualState.Minimized;
        private AutomationElement automationElement;

        private TrayIcon icon;

        public Context(Logger logger, ContextConfiguration config)
            : this
            (
                  logger, 
                  config.ApplicationName, 
                  config.IconPath != null ? Icon.ExtractAssociatedIcon(config.IconPath) : null, 
                  config.ExecutablePaths, 
                  config.MainWindowClass, 
                  config.MainWindowTextRegexp
            )
        {
        }

        public Context(Logger logger, string applicationName, Icon applicationIcon, string[] executablePaths, string mainWindowClassName, string mainWindowTextRegexp)
        {
            this.logger = logger;

            logger.Information($"Starting InTray context for {applicationName}");

            FileInfo executableFileInfo = null;
            foreach (var executablePath in executablePaths)
            {
                var expandedPath = Environment.ExpandEnvironmentVariables(executablePath);
                FileInfo fileInfo = new FileInfo(expandedPath);
                if (fileInfo.Exists && fileInfo.Extension == ".exe")
                {
                    logger.Debug($"Executable located at {executablePath}");
                    executableFileInfo = fileInfo;
                    break;
                }
            }

            if (executableFileInfo == null)
            {
                logger.Error($"Executable does not exist for {applicationName}.");
                throw new ArgumentException("Executable does not exist.");
            }

            ApplicationName = applicationName;
            ProcessName = executableFileInfo.Name.Substring(0, executableFileInfo.Name.Length - executableFileInfo.Extension.Length);
            Executable = executableFileInfo.FullName;
            MainWindowClassName = mainWindowClassName;
            MainWindowTextRegex = new Regex(mainWindowTextRegexp);

            icon = new TrayIcon
            (
                logger,
                applicationName,
                applicationIcon == null ? Icon.ExtractAssociatedIcon(executableFileInfo.FullName) : applicationIcon,
                Icon_Exit,
                Icon_Click,
                Icon_ToggleShow
            );
            icon.SetVisible(true);
            icon.SetMenuEnabled(false);
            Task.Run(Initialise);        
        }

        private async void Initialise()
        {
            if (!initialised)
            {
                initialised = true;

                logger.Debug($"Starting initilisation task for context {ApplicationName}.");
                var process = Process.GetProcessesByName(ProcessName).FirstOrDefault();
                if (process == null)
                {
                    logger.Debug($"Process with name {ProcessName} not detected");
                    process = StartProcess();
                }
                else
                {
                    logger.Debug($"Process with name {ProcessName} and PID {process.Id} detected.");
                }

                if (process == null)
                {
                    throw new ArgumentException($"Could not find process with name \"{ProcessName}\".");
                }

                this.process = process;

                int retries = 0;
                while (!HookProcess() && retries < 20)
                {
                    await Task.Delay(500);
                    retries += 1;
                }

                if (mainWindowHandle != IntPtr.Zero)
                {
                    logger.Debug($"Hook on {ProcessName} took {retries} retries.");

                    logger.Information($"Initialised {ApplicationName} context.");
                }
                else
                {
                    logger.Error($"Could not hook on to {ApplicationName} after {retries} retries.");
                    ContextExit?.Invoke(this, new EventArgs());
                    Dispose();
                }
            }
            else
            {
                logger.Information("Already initialised.");
            }
        }

        private User32.ShowWindowType CalculateRestoreState()
        {
            // If minimised, indicates that the last visual state was never set (set to min in init)
            if (lastWindowVisualState == WindowVisualState.Minimized)
            {
                if (mainWindowHandle != null)
                {
                    // Check if application was previously maximised
                    if ((User32.GetWindowPlacement(mainWindowHandle).flags & User32.WPF_RESTORETOMAXIMIZED) > 0)
                    {
                        return User32.ShowWindowType.SW_MAXIMIZE;
                    }
                }
            }
            else
            {
                if (lastWindowVisualState == WindowVisualState.Maximized)
                {
                    return User32.ShowWindowType.SW_MAXIMIZE;
                }
            }

            return User32.ShowWindowType.SW_NORMAL;
        }

        private void ToggleShow()
        {
            if (windowShown)
            {
                logger.Debug($"Toggle hide {ApplicationName}.");
                HideMainWindow();
            }
            else
            {
                logger.Debug($"Toggle show {ApplicationName}.");
                ShowMainWindow();
            }
        }

        private void ShowMainWindow()
        {
            if (mainWindowHandle != IntPtr.Zero)
            {
                logger.Debug($"Showing {ApplicationName} with last state as {lastWindowVisualState}.");
                User32.ShowWindow(mainWindowHandle, CalculateRestoreState());
                User32.SetForegroundWindow(mainWindowHandle);
                windowShown = true;
            }
        }

        private void HideMainWindow()
        {
            if (mainWindowHandle != IntPtr.Zero)
            {
                logger.Debug($"Hiding {ApplicationName} with last state as {lastWindowVisualState}.");
                User32.ShowWindow(mainWindowHandle, User32.ShowWindowType.SW_HIDE);
                windowShown = false;
            }
        }

        private IntPtr FindMainProcessWindow()
        {
            IntPtr mainWindow = IntPtr.Zero;
            var processId = process.Id;

            User32.EnumWindows((IntPtr hWnd, IntPtr lParam) =>
            {
                int windowProcessId = 0;
                User32.GetWindowThreadProcessId(hWnd, out windowProcessId);

                // If process ids don't match or it is a child window, return true for a new window.
                if (windowProcessId != processId || User32.GetWindow(hWnd, User32.GetWindowType.GW_OWNER) != IntPtr.Zero)
                {
                    return true;
                }

                var classNameBuilder = new StringBuilder();
                var classNameLength = User32.GetClassName(hWnd, classNameBuilder, int.MaxValue);
                var className = classNameBuilder.ToString();

                if (className != MainWindowClassName)
                {
                    return true;
                }

                var windowTextBuilder = new StringBuilder();
                var windowTextLength = User32.GetWindowText(hWnd, windowTextBuilder, int.MaxValue);
                var windowText = windowTextBuilder.ToString();

                if (!MainWindowTextRegex.IsMatch(windowText))
                {
                    return true;
                }
                Debug.WriteLine($"[{className}] {windowText}");
                mainWindow = hWnd;

                // Ends enumeration
                return false;
            }, IntPtr.Zero);

            return mainWindow;
        }

        public Process StartProcess()
        {
            var process = new Process
            {
                StartInfo =
                    {
                        FileName = Executable,
                        CreateNoWindow = false,
                        WindowStyle = ProcessWindowStyle.Minimized,
                        UseShellExecute = true
                    }
            };
            process.Start();
            return process;
        }

        private bool HookProcess()
        {
            logger.Information($"Hooking on to {ApplicationName}...");
            if (mainWindowHandle != IntPtr.Zero)
            {
                logger.Information($"Already hooked {ApplicationName}!");
                // Already hooked
                return true;
            }

            mainWindowHandle = FindMainProcessWindow();

            if (mainWindowHandle == IntPtr.Zero)
            {
                logger.Error($"Cannot find {ApplicationName}'s main window.");
                // Main window is lost
                return false;
            }
            else
            {
                logger.Debug($"Hooked on to window handle {mainWindowHandle}");
            }

            try
            {
                process.EnableRaisingEvents = true;
                process.Exited += Process_Exited;
                automationElement = AutomationElement.FromHandle(mainWindowHandle);
                Automation.AddAutomationPropertyChangedEventHandler(
                    automationElement,
                    TreeScope.Element,
                    Process_VisualStateChanged,
                    new AutomationProperty[] { WindowPattern.WindowVisualStateProperty });

                logger.Debug($"Attached event handlers for {ApplicationName} window.");

                // If not already hidden and is currently minimised, hide immediately
                var isIconic = User32.IsIconic(mainWindowHandle);
                if (windowShown && isIconic)
                {
                    logger.Information($"{ApplicationName} is already minimised, hiding now.");
                    HideMainWindow();
                }
                else
                {
                    lastWindowVisualState = (WindowVisualState)automationElement.GetCurrentPropertyValue(WindowPattern.WindowVisualStateProperty);
                }
                logger.Debug($"Set {ApplicationName} visual state as {lastWindowVisualState}.");

                icon.SetMenuEnabled(true);

                return true;
            }
            catch (Win32Exception) 
            {
                mainWindowHandle = IntPtr.Zero;
                logger.Error($"No privillages to hook to {ApplicationName}.");
                return false;
            }
        }

        private void UnhookProcess()
        {
            logger.Information($"Unhooking {ApplicationName}...");

            if (mainWindowHandle != IntPtr.Zero)
            {
                if (!windowShown)
                {
                    logger.Debug($"Previously hidden {ApplicationName}, showing.");
                    // If previously hidden, show to avoid bug
                    User32.ShowWindow(mainWindowHandle, User32.ShowWindowType.SW_NORMAL);
                }

                mainWindowHandle = IntPtr.Zero;
            }

            if (automationElement != null)
            {
                Automation.RemoveAllEventHandlers();
                automationElement = null;
            }

            icon.SetMenuEnabled(false);
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            var mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null)
            {
                var button = mouseEvent.Button;
                logger.Debug($"{ApplicationName} NotifyIcon clicked {button}.");
                if (button == MouseButtons.Left)
                {
                    ToggleShow();
                }
            }
        }
        private void Icon_ToggleShow(object sender, EventArgs e)
        {
            ToggleShow();
        }

        private void Icon_Exit(object sender, EventArgs e)
        {
            Exit();
        }

        private void Process_VisualStateChanged(object sender, AutomationPropertyChangedEventArgs e)
        {
            WindowVisualState visualState = WindowVisualState.Normal;
            try
            {
                visualState = (WindowVisualState)e.NewValue;
            }
            catch (InvalidCastException)
            {
                // ignore
            }

            logger.Debug($"Detected {ApplicationName} visual state change to {visualState}.");

            if (visualState == WindowVisualState.Minimized)
            {
                HideMainWindow();
            }
            else
            {
                windowShown = true;
                lastWindowVisualState = visualState;
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            logger.Information($"{ApplicationName} has exited.");
            Exit();
        }
        private void Exit()
        {
            logger.Information($"Shutting down InTray context for {ApplicationName}.");
            ContextExit?.Invoke(this, new EventArgs());
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            // Clean up any components being used.
            if (disposing)
            {
            }
            UnhookProcess();

            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            icon.SetVisible(false);
            icon.SetMenuEnabled(false);
            icon.SetIconText("Deactivated");

            process?.Dispose();
            process = null;
            initialised = false;
        }

        public void Dispose() => Dispose(true);
    }
}
