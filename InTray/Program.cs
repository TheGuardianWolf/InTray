using InTray.Lib;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InTray
{
    static class Program
    {
        static ContextManager contextManager;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var args = Environment.GetCommandLineArgs().ToList();
            args.RemoveAt(0);

            var appDataFolder = SetupAppData();

            var debug = false;
            foreach (var arg in args)
            {
                if (arg == "--debug")
                {
                    debug = true;
                }
            }
            debug = false;

            var logConfig = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(appDataFolder, "log.txt"));

            if (debug)
            {
                logConfig = logConfig.MinimumLevel.Debug();
            }
            else
            {
                logConfig = logConfig.MinimumLevel.Information();
            }

            var logger = logConfig.CreateLogger();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            contextManager = new ContextManager(logger, appDataFolder);

            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run(contextManager);
        }

        private static string SetupAppData()
        {
            // The folder for the roaming current user 
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Combine the base folder with your specific folder....
            string specificFolder = Path.Combine(folder, Assembly.GetExecutingAssembly().GetName().Name);

            // CreateDirectory will check if folder exists and, if not, create it.
            // If folder exists then CreateDirectory will do nothing.
            return Directory.CreateDirectory(specificFolder).FullName;
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            contextManager.Dispose();
            contextManager = null;
        }
    }
}
