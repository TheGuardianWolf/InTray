using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InTray.Lib
{
    public class TrayIcon
    {
        private Logger logger;

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        private string applicationName;

        public TrayIcon
        (
            Logger logger, 
            string applicationName, 
            Icon applicationIcon, 
            EventHandler exitHandler,
            EventHandler clickHandler=null,
            EventHandler toggleShowHandler=null, 
            EventHandler optionsHandler=null
        )
        {
            this.logger = logger;
            this.applicationName = applicationName;

            logger.Information($"Initialising icon for {applicationName}.");
            
            var toolStripMenuItems = new List<ToolStripMenuItem>();

            if (toggleShowHandler != null)
            {
                ToolStripMenuItem showMenuItem = new ToolStripMenuItem($"Show / Hide {applicationName}", null, toggleShowHandler);
                showMenuItem.Font = new Font(showMenuItem.Font, showMenuItem.Font.Style | FontStyle.Bold);
                toolStripMenuItems.Add(showMenuItem);
            }
            if (optionsHandler != null)
            {
                ToolStripMenuItem optionsMenuItem = new ToolStripMenuItem("Options", null, optionsHandler);
                toolStripMenuItems.Add(optionsMenuItem);
            }
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", null, exitHandler);
            toolStripMenuItems.Add(exitMenuItem);

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(toolStripMenuItems.ToArray());

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = applicationIcon;
            notifyIcon.ContextMenuStrip = contextMenu;

            if (clickHandler != null)
            {
                notifyIcon.Click += clickHandler;
            }
        }

        ~TrayIcon()
        {
        }

        public void SetVisible(bool visible)
        {
            notifyIcon.Visible = visible;
        }

        public void SetIconText(string text)
        {
            logger.Information($"{applicationName} icon text set to {text}.");
            string statusText = applicationName + (text.Length > 0 ? $" - {text}" : "");
            notifyIcon.Text = statusText;
        }

        public void SetMenuEnabled(bool enabled)
        {
            var action = new Action(() =>
            {
                if (contextMenu.Items.Count > 0)
                {
                    for (var i = 0; i < contextMenu.Items.Count - 1; i++)
                    {
                        contextMenu.Items[i].Enabled = enabled;
                    }
                }
            });

            if (contextMenu.InvokeRequired)
            {
                contextMenu.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
