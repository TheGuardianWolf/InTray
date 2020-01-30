using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using InTray.Lib;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq;

namespace InTray
{
    public class ContextManager: ApplicationContext, IDisposable
    {
        private Logger logger;
        private string configFolder;
        private TrayIcon icon;

        private List<ContextConfiguration> configs;
        private List<Context> contexts;

        private ContextManagerOptionsForm optionsForm;

        public ContextManager(Logger logger, string configFolder)
        {
            contexts = new List<Context>();
            configs = new List<ContextConfiguration>();
            this.configFolder = configFolder;
            this.logger = logger;

            icon = new TrayIcon
            (
                logger,
                "InTray",
                Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
                Icon_Exit,
                null,
                null,
                Icon_Options
             );

            icon.SetVisible(true);
            icon.SetMenuEnabled(false);

            Initialise();
        }

        public void Initialise()
        {
            if (!Directory.Exists(configFolder))
            {
                throw new ArgumentException($"Config folder does not exist at {configFolder}.");
            }

            var configFiles = Directory.GetFiles(configFolder, "*.yaml");
            foreach (var file in configFiles)
            {
                var config = ContextConfiguration.ImportFromFile(file);

                if (ConfigurationValidator(config))
                {
                    configs.Add(config);
                }
                else
                {
                    logger.Warning($"{config.ApplicationName} context already exists.");
                }
            }

            Reload();
        }

        public void Reload() 
        {
            icon.SetMenuEnabled(false);
            foreach (var context in contexts)
            {
                context.Dispose();
            }
            contexts.Clear();

            foreach (var config in configs)
            {
                try
                {
                    var context = new Context(logger, config);
                    context.ContextExit += Context_ContextExit;
                    contexts.Add(context);
                }
                catch (NullReferenceException)
                {
                    // Ignore
                    logger.Warning($"Could not create context for {config.ApplicationName}.");
                }
            }

            icon.SetMenuEnabled(true);
        }

        public bool ConfigurationValidator(ContextConfiguration config)
        {
            return !configs.Any((x) => x.ApplicationName == config.ApplicationName);
        }

        private void ConfigurationList_ListChanged(object sender, ListChangedEventArgs e)
        {
            ContextConfiguration config;
            string fileName;

            switch (e.ListChangedType)
            {
                case ListChangedType.ItemChanged:
                    config = optionsForm.ConfigurationList[e.NewIndex];
                    configs[e.NewIndex] = config;
                    fileName = Path.Combine(configFolder, $"{config.ApplicationName}.yaml");
                    ContextConfiguration.ExportToFile(fileName, config);
                    break;
                case ListChangedType.ItemAdded:
                    config = optionsForm.ConfigurationList[e.NewIndex];
                    configs.Insert(e.NewIndex, config);
                    fileName = Path.Combine(configFolder, $"{config.ApplicationName}.yaml");
                    ContextConfiguration.ExportToFile(fileName, config);
                    break;
                case ListChangedType.ItemDeleted:
                    config = configs[e.NewIndex];
                    fileName = Path.Combine(configFolder, $"{config.ApplicationName}.yaml");
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                        configs.RemoveAt(e.NewIndex);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Context_ContextExit(object sender, EventArgs e)
        {
            var context = sender as Context;
            if (context != null)
            {
                contexts.Remove(context);
            }
        }

        private void Icon_Options(object sender, EventArgs e)
        {
            if (optionsForm == null || !optionsForm.Visible)
            {
                optionsForm = new ContextManagerOptionsForm(new List<ContextConfiguration>(configs), ConfigurationValidator);
                optionsForm.Show();
                optionsForm.Invoke(new Action(() =>
                {
                    optionsForm.ConfigurationList.ListChanged += ConfigurationList_ListChanged;
                    optionsForm.FormClosing += OptionsForm_FormClosing;
                }));
            }
            else if (optionsForm.Visible)
            {
                optionsForm.TopMost = true;
            }
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            optionsForm.Invoke(new Action(() =>
            {
                optionsForm.ConfigurationList.ListChanged -= ConfigurationList_ListChanged;
                optionsForm.FormClosing -= OptionsForm_FormClosing;
            }));
            optionsForm = null;
        }

        private void Icon_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            // Clean up any components being used.
            if (disposing)
            {
            }

            foreach (var context in contexts)
            {
                context.Dispose();
            }
            contexts.Clear();

            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            icon.SetVisible(false);

            base.Dispose(disposing);
        }
    }
}
