using InTray.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace InTray
{
    public partial class ContextManagerOptionsForm : Form
    {
        public BindingList<ContextConfiguration> ConfigurationList { get; }
        private int activeIndex = -1;
        private Func<ContextConfiguration, bool> configurationValidator;

        public ContextManagerOptionsForm(IList<ContextConfiguration> existingConfigs, Func<ContextConfiguration, bool> configurationValidator)
        {
            this.configurationValidator = configurationValidator;

            InitializeComponent();

            DisableForm();
            ConfigurationList = new BindingList<ContextConfiguration>(existingConfigs);
            ListBoxConfigurations.DataSource = ConfigurationList;
            ListBoxConfigurations.DisplayMember = "ApplicationName";
            ListBoxConfigurations.SelectedIndex = -1;
            ListBoxConfigurations.SelectedIndexChanged += ListBoxConfigurations_SelectedIndexChanged;
        }

        private void DisableForm()
        {
            ButtonBrowseExecutable.Enabled = false;
            ButtonBrowseIconPath.Enabled = false;
            ButtonExportConfiguration.Enabled = false;
            ButtonSaveConfiguration.Enabled = false;
            ButtonDeleteConfiguration.Enabled = false;
            TextBoxApplicationName.Enabled = false;
            TextBoxApplicationName.ResetText();
            TextBoxExecutablePath.Enabled = false;
            TextBoxExecutablePath.ResetText();
            TextBoxIconPath.Enabled = false;
            TextBoxIconPath.ResetText();
            TextBoxMainWindowClass.Enabled = false;
            TextBoxMainWindowClass.ResetText();
            TextBoxMainWindowTextRegexp.Enabled = false;
            TextBoxMainWindowClass.ResetText();
        }

        private void EnableForm()
        {
            ButtonBrowseExecutable.Enabled = true;
            ButtonBrowseIconPath.Enabled = true;
            ButtonExportConfiguration.Enabled = true;
            ButtonSaveConfiguration.Enabled = true;
            ButtonDeleteConfiguration.Enabled = true;
            TextBoxApplicationName.Enabled = true;
            TextBoxExecutablePath.Enabled = true;
            TextBoxIconPath.Enabled = true;
            TextBoxMainWindowClass.Enabled = true;
            TextBoxMainWindowTextRegexp.Enabled = true;
        }

        private void LoadConfiguration(ContextConfiguration config)
        {
            TextBoxApplicationName.Text = config.ApplicationName ?? "";
            TextBoxExecutablePath.Text = config.ExecutablePaths == null ? "" : string.Join(";", config.ExecutablePaths);
            TextBoxIconPath.Text = config.IconPath ?? "";
            TextBoxMainWindowClass.Text = config.MainWindowClass ?? "";
            TextBoxMainWindowTextRegexp.Text = config.MainWindowTextRegexp ?? "";
        }

        private void SaveConfiguration(ContextConfiguration config)
        {
            config.ApplicationName = TextBoxApplicationName.Text;
            config.ExecutablePaths = TextBoxExecutablePath.Text.Split(';');
            config.IconPath = TextBoxIconPath.Text;
            config.MainWindowClass = TextBoxMainWindowClass.Text;
            config.MainWindowTextRegexp = TextBoxMainWindowTextRegexp.Text;
        }

        private void ListBoxConfigurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ListBoxConfigurations.SelectedIndex;
            if (index >= 0 && index < ConfigurationList.Count)
            {
                activeIndex = index;
                LoadConfiguration(ConfigurationList[activeIndex]);
                EnableForm();
            }
            else
            {
                DisableForm();
            }
        }

        private void ButtonBrowseExecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog 
            {
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Select executable files",
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                TextBoxExecutablePath.Text = string.Join(";", fileDialog.FileNames);
            }
        }

        private void ButtonBrowseIconPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Icon files (*.ico)|*.ico",
                Title = "Select icon file",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                TextBoxIconPath.Text = fileDialog.FileName;
            }
        }

        private void ButtonImportConfigration_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "YAML files (*.yaml)|*.yaml",
                Title = "Select configuration files",
                Multiselect = true,
                InitialDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var config = ContextConfiguration.ImportFromFile(fileDialog.FileName);
                if (configurationValidator(config))
                {
                    ConfigurationList.Add(config);
                    ListBoxConfigurations.SetSelected(ConfigurationList.Count - 1, true);
                }
                else
                {
                    MessageBox.Show("Configuration already exists!", "InTray Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonExportConfiguration_Click(object sender, EventArgs e)
        {
            if (activeIndex >= 0 && activeIndex < ConfigurationList.Count)
            {
                var config = ConfigurationList[activeIndex];

                SaveFileDialog fileDialog = new SaveFileDialog
                {
                    Filter = "YAML files (*.yaml)|*.yaml",
                    Title = "Save configuration file",
                    FileName = $"{config.ApplicationName}.yaml",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                };
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ContextConfiguration.ExportToFile(fileDialog.FileName, config);
                }
            }
        }

        private void ButtonNewConfiguration_Click(object sender, EventArgs e)
        {
            var newConfig = new ContextConfiguration { ApplicationName = "App" };
            if (configurationValidator(newConfig))
            {
                ConfigurationList.Add(newConfig);
                ListBoxConfigurations.SelectedIndex = ConfigurationList.Count - 1;
            }
            else
            {
                MessageBox.Show("Configuration already exists!", "InTray Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDeleteConfiguration_Click(object sender, EventArgs e)
        {
            if (activeIndex >= 0 && activeIndex < ConfigurationList.Count)
            {
                var prevIndex = activeIndex;
                if (activeIndex - 1 > 0)
                {
                    ListBoxConfigurations.SelectedIndex = activeIndex - 1;
                }
                else if (activeIndex + 1 < ConfigurationList.Count)
                {
                    ListBoxConfigurations.SelectedIndex = activeIndex + 1;
                }
                else
                {
                    ListBoxConfigurations.SelectedIndex = -1;
                }
                ConfigurationList.RemoveAt(prevIndex);
            }
        }

        private void ButtonSaveConfiguration_Click(object sender, EventArgs e)
        {
            if (activeIndex >= 0 && activeIndex < ConfigurationList.Count)
            {
                var updatedConfig = new ContextConfiguration();
                SaveConfiguration(updatedConfig);
                if (ConfigurationList[activeIndex].ApplicationName == updatedConfig.ApplicationName || configurationValidator(updatedConfig))
                {
                    ConfigurationList[activeIndex] = updatedConfig;
                    ConfigurationList.ResetItem(activeIndex);
                }
                else
                {
                    MessageBox.Show("Configuration already exists!", "InTray Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
