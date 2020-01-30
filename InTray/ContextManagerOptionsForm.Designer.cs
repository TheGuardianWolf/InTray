namespace InTray
{
    partial class ContextManagerOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListBoxConfigurations = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.TextBoxMainWindowTextRegexp = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxMainWindowClass = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.TextBoxIconPath = new System.Windows.Forms.TextBox();
            this.ButtonBrowseIconPath = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.TextBoxExecutablePath = new System.Windows.Forms.TextBox();
            this.ButtonBrowseExecutable = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxApplicationName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonDeleteConfiguration = new System.Windows.Forms.Button();
            this.ButtonSaveConfiguration = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonImportConfigration = new System.Windows.Forms.Button();
            this.ButtonExportConfiguration = new System.Windows.Forms.Button();
            this.ButtonNewConfiguration = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListBoxConfigurations);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 345);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registered app configurations";
            // 
            // ListBoxConfigurations
            // 
            this.ListBoxConfigurations.FormattingEnabled = true;
            this.ListBoxConfigurations.ItemHeight = 16;
            this.ListBoxConfigurations.Location = new System.Drawing.Point(6, 21);
            this.ListBoxConfigurations.Name = "ListBoxConfigurations";
            this.ListBoxConfigurations.Size = new System.Drawing.Size(212, 276);
            this.ListBoxConfigurations.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(235, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(237, 276);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.label10);
            this.flowLayoutPanel7.Controls.Add(this.TextBoxMainWindowTextRegexp);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 223);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(239, 50);
            this.flowLayoutPanel7.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Main window text regexp";
            // 
            // TextBoxMainWindowTextRegexp
            // 
            this.TextBoxMainWindowTextRegexp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxMainWindowTextRegexp.Location = new System.Drawing.Point(7, 20);
            this.TextBoxMainWindowTextRegexp.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.TextBoxMainWindowTextRegexp.Name = "TextBoxMainWindowTextRegexp";
            this.TextBoxMainWindowTextRegexp.Size = new System.Drawing.Size(224, 22);
            this.TextBoxMainWindowTextRegexp.TabIndex = 10;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label9);
            this.flowLayoutPanel6.Controls.Add(this.TextBoxMainWindowClass);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 168);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(239, 49);
            this.flowLayoutPanel6.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Main window class";
            // 
            // TextBoxMainWindowClass
            // 
            this.TextBoxMainWindowClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxMainWindowClass.Location = new System.Drawing.Point(7, 20);
            this.TextBoxMainWindowClass.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.TextBoxMainWindowClass.Name = "TextBoxMainWindowClass";
            this.TextBoxMainWindowClass.Size = new System.Drawing.Size(224, 22);
            this.TextBoxMainWindowClass.TabIndex = 10;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label8);
            this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel9);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 113);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(239, 49);
            this.flowLayoutPanel5.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Icon path";
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.TextBoxIconPath);
            this.flowLayoutPanel9.Controls.Add(this.ButtonBrowseIconPath);
            this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(3, 20);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(231, 29);
            this.flowLayoutPanel9.TabIndex = 14;
            // 
            // TextBoxIconPath
            // 
            this.TextBoxIconPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxIconPath.Location = new System.Drawing.Point(5, 3);
            this.TextBoxIconPath.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.TextBoxIconPath.Name = "TextBoxIconPath";
            this.TextBoxIconPath.Size = new System.Drawing.Size(140, 22);
            this.TextBoxIconPath.TabIndex = 11;
            // 
            // ButtonBrowseIconPath
            // 
            this.ButtonBrowseIconPath.Location = new System.Drawing.Point(151, 3);
            this.ButtonBrowseIconPath.Name = "ButtonBrowseIconPath";
            this.ButtonBrowseIconPath.Size = new System.Drawing.Size(77, 26);
            this.ButtonBrowseIconPath.TabIndex = 12;
            this.ButtonBrowseIconPath.Text = "Browse";
            this.ButtonBrowseIconPath.UseVisualStyleBackColor = true;
            this.ButtonBrowseIconPath.Click += new System.EventHandler(this.ButtonBrowseIconPath_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label7);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 58);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(239, 49);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Executable path";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.TextBoxExecutablePath);
            this.flowLayoutPanel8.Controls.Add(this.ButtonBrowseExecutable);
            this.flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 20);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(231, 29);
            this.flowLayoutPanel8.TabIndex = 13;
            // 
            // TextBoxExecutablePath
            // 
            this.TextBoxExecutablePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxExecutablePath.Location = new System.Drawing.Point(5, 3);
            this.TextBoxExecutablePath.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.TextBoxExecutablePath.Name = "TextBoxExecutablePath";
            this.TextBoxExecutablePath.Size = new System.Drawing.Size(140, 22);
            this.TextBoxExecutablePath.TabIndex = 11;
            // 
            // ButtonBrowseExecutable
            // 
            this.ButtonBrowseExecutable.Location = new System.Drawing.Point(151, 3);
            this.ButtonBrowseExecutable.Name = "ButtonBrowseExecutable";
            this.ButtonBrowseExecutable.Size = new System.Drawing.Size(77, 26);
            this.ButtonBrowseExecutable.TabIndex = 12;
            this.ButtonBrowseExecutable.Text = "Browse";
            this.ButtonBrowseExecutable.UseVisualStyleBackColor = true;
            this.ButtonBrowseExecutable.Click += new System.EventHandler(this.ButtonBrowseExecutable_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.TextBoxApplicationName);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(239, 49);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Application name";
            // 
            // TextBoxApplicationName
            // 
            this.TextBoxApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxApplicationName.Location = new System.Drawing.Point(7, 20);
            this.TextBoxApplicationName.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.TextBoxApplicationName.Name = "TextBoxApplicationName";
            this.TextBoxApplicationName.Size = new System.Drawing.Size(224, 22);
            this.TextBoxApplicationName.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.ButtonNewConfiguration);
            this.flowLayoutPanel2.Controls.Add(this.ButtonSaveConfiguration);
            this.flowLayoutPanel2.Controls.Add(this.ButtonDeleteConfiguration);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(214, 302);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(258, 36);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // ButtonDeleteConfiguration
            // 
            this.ButtonDeleteConfiguration.Location = new System.Drawing.Point(175, 3);
            this.ButtonDeleteConfiguration.Name = "ButtonDeleteConfiguration";
            this.ButtonDeleteConfiguration.Size = new System.Drawing.Size(80, 30);
            this.ButtonDeleteConfiguration.TabIndex = 1;
            this.ButtonDeleteConfiguration.Text = "Delete";
            this.ButtonDeleteConfiguration.UseVisualStyleBackColor = true;
            this.ButtonDeleteConfiguration.Click += new System.EventHandler(this.ButtonDeleteConfiguration_Click);
            // 
            // ButtonSaveConfiguration
            // 
            this.ButtonSaveConfiguration.Location = new System.Drawing.Point(89, 3);
            this.ButtonSaveConfiguration.Name = "ButtonSaveConfiguration";
            this.ButtonSaveConfiguration.Size = new System.Drawing.Size(80, 30);
            this.ButtonSaveConfiguration.TabIndex = 2;
            this.ButtonSaveConfiguration.Text = "Save";
            this.ButtonSaveConfiguration.UseVisualStyleBackColor = true;
            this.ButtonSaveConfiguration.Click += new System.EventHandler(this.ButtonSaveConfiguration_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.ButtonImportConfigration);
            this.flowLayoutPanel1.Controls.Add(this.ButtonExportConfiguration);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 302);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(172, 36);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // ButtonImportConfigration
            // 
            this.ButtonImportConfigration.Location = new System.Drawing.Point(3, 3);
            this.ButtonImportConfigration.Name = "ButtonImportConfigration";
            this.ButtonImportConfigration.Size = new System.Drawing.Size(80, 30);
            this.ButtonImportConfigration.TabIndex = 1;
            this.ButtonImportConfigration.Text = "Import";
            this.ButtonImportConfigration.UseVisualStyleBackColor = true;
            this.ButtonImportConfigration.Click += new System.EventHandler(this.ButtonImportConfigration_Click);
            // 
            // ButtonExportConfiguration
            // 
            this.ButtonExportConfiguration.Location = new System.Drawing.Point(89, 3);
            this.ButtonExportConfiguration.Name = "ButtonExportConfiguration";
            this.ButtonExportConfiguration.Size = new System.Drawing.Size(80, 30);
            this.ButtonExportConfiguration.TabIndex = 2;
            this.ButtonExportConfiguration.Text = "Export";
            this.ButtonExportConfiguration.UseVisualStyleBackColor = true;
            this.ButtonExportConfiguration.Click += new System.EventHandler(this.ButtonExportConfiguration_Click);
            // 
            // ButtonNewConfiguration
            // 
            this.ButtonNewConfiguration.Location = new System.Drawing.Point(3, 3);
            this.ButtonNewConfiguration.Name = "ButtonNewConfiguration";
            this.ButtonNewConfiguration.Size = new System.Drawing.Size(80, 30);
            this.ButtonNewConfiguration.TabIndex = 3;
            this.ButtonNewConfiguration.Text = "New";
            this.ButtonNewConfiguration.UseVisualStyleBackColor = true;
            this.ButtonNewConfiguration.Click += new System.EventHandler(this.ButtonNewConfiguration_Click);
            // 
            // ContextManagerOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 368);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContextManagerOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "InTray Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button ButtonDeleteConfiguration;
        private System.Windows.Forms.Button ButtonSaveConfiguration;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ButtonImportConfigration;
        private System.Windows.Forms.Button ButtonExportConfiguration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TextBoxMainWindowTextRegexp;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextBoxMainWindowClass;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxApplicationName;
        private System.Windows.Forms.ListBox ListBoxConfigurations;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.TextBox TextBoxExecutablePath;
        private System.Windows.Forms.Button ButtonBrowseExecutable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.TextBox TextBoxIconPath;
        private System.Windows.Forms.Button ButtonBrowseIconPath;
        private System.Windows.Forms.Button ButtonNewConfiguration;
    }
}

