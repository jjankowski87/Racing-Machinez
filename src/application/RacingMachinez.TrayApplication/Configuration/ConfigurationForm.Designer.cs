namespace RacingMachinez.TrayApplication.Configuration
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.lbComPort = new System.Windows.Forms.Label();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.txtPluginsDirectory = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPluginsDirectory = new System.Windows.Forms.Label();
            this.cbActiveClusterPlugin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAllGamePlugins = new System.Windows.Forms.ListBox();
            this.lbActiveGamePlugins = new System.Windows.Forms.ListBox();
            this.lblAllGamePlugins = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddActivePlugin = new System.Windows.Forms.Button();
            this.btnRemoveActivePlugin = new System.Windows.Forms.Button();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbComPort
            // 
            this.cbComPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(114, 151);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(198, 21);
            this.cbComPort.TabIndex = 0;
            // 
            // lbComPort
            // 
            this.lbComPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbComPort.AutoSize = true;
            this.lbComPort.Location = new System.Drawing.Point(55, 154);
            this.lbComPort.Name = "lbComPort";
            this.lbComPort.Size = new System.Drawing.Size(53, 13);
            this.lbComPort.TabIndex = 1;
            this.lbComPort.Text = "Port COM";
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDirectory.Location = new System.Drawing.Point(287, 12);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(25, 22);
            this.btnSelectDirectory.TabIndex = 3;
            this.btnSelectDirectory.Text = "...";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.ButtonSelectDirectoryClicked);
            // 
            // txtPluginsDirectory
            // 
            this.txtPluginsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPluginsDirectory.Location = new System.Drawing.Point(108, 13);
            this.txtPluginsDirectory.Name = "txtPluginsDirectory";
            this.txtPluginsDirectory.ReadOnly = true;
            this.txtPluginsDirectory.Size = new System.Drawing.Size(176, 20);
            this.txtPluginsDirectory.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(156, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.ButtonSaveClicked);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(237, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.ButtonCloseClicked);
            // 
            // lblPluginsDirectory
            // 
            this.lblPluginsDirectory.AutoSize = true;
            this.lblPluginsDirectory.Location = new System.Drawing.Point(16, 16);
            this.lblPluginsDirectory.Name = "lblPluginsDirectory";
            this.lblPluginsDirectory.Size = new System.Drawing.Size(86, 13);
            this.lblPluginsDirectory.TabIndex = 2;
            this.lblPluginsDirectory.Text = "Plugins Directory";
            // 
            // cbActiveClusterPlugin
            // 
            this.cbActiveClusterPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActiveClusterPlugin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActiveClusterPlugin.FormattingEnabled = true;
            this.cbActiveClusterPlugin.Location = new System.Drawing.Point(114, 178);
            this.cbActiveClusterPlugin.Name = "cbActiveClusterPlugin";
            this.cbActiveClusterPlugin.Size = new System.Drawing.Size(198, 21);
            this.cbActiveClusterPlugin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Active Plugin";
            // 
            // lbAllGamePlugins
            // 
            this.lbAllGamePlugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbAllGamePlugins.FormattingEnabled = true;
            this.lbAllGamePlugins.Location = new System.Drawing.Point(19, 62);
            this.lbAllGamePlugins.Name = "lbAllGamePlugins";
            this.lbAllGamePlugins.Size = new System.Drawing.Size(124, 69);
            this.lbAllGamePlugins.TabIndex = 0;
            // 
            // lbActiveGamePlugins
            // 
            this.lbActiveGamePlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbActiveGamePlugins.FormattingEnabled = true;
            this.lbActiveGamePlugins.Location = new System.Drawing.Point(188, 62);
            this.lbActiveGamePlugins.Name = "lbActiveGamePlugins";
            this.lbActiveGamePlugins.Size = new System.Drawing.Size(124, 69);
            this.lbActiveGamePlugins.TabIndex = 1;
            // 
            // lblAllGamePlugins
            // 
            this.lblAllGamePlugins.AutoSize = true;
            this.lblAllGamePlugins.Location = new System.Drawing.Point(16, 46);
            this.lblAllGamePlugins.Name = "lblAllGamePlugins";
            this.lblAllGamePlugins.Size = new System.Drawing.Size(72, 13);
            this.lblAllGamePlugins.TabIndex = 2;
            this.lblAllGamePlugins.Text = "Game Plugins";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Active Plugins";
            // 
            // btnAddActivePlugin
            // 
            this.btnAddActivePlugin.Location = new System.Drawing.Point(149, 61);
            this.btnAddActivePlugin.Name = "btnAddActivePlugin";
            this.btnAddActivePlugin.Size = new System.Drawing.Size(33, 32);
            this.btnAddActivePlugin.TabIndex = 5;
            this.btnAddActivePlugin.Text = ">";
            this.btnAddActivePlugin.UseVisualStyleBackColor = true;
            // 
            // btnRemoveActivePlugin
            // 
            this.btnRemoveActivePlugin.Location = new System.Drawing.Point(149, 100);
            this.btnRemoveActivePlugin.Name = "btnRemoveActivePlugin";
            this.btnRemoveActivePlugin.Size = new System.Drawing.Size(33, 32);
            this.btnRemoveActivePlugin.TabIndex = 6;
            this.btnRemoveActivePlugin.Text = "<";
            this.btnRemoveActivePlugin.UseVisualStyleBackColor = true;
            // 
            // lblLine1
            // 
            this.lblLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine1.Location = new System.Drawing.Point(19, 40);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(293, 2);
            this.lblLine1.TabIndex = 7;
            // 
            // lblLine2
            // 
            this.lblLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine2.Location = new System.Drawing.Point(19, 140);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(293, 2);
            this.lblLine2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(19, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 2);
            this.label3.TabIndex = 9;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 250);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.btnRemoveActivePlugin);
            this.Controls.Add(this.btnAddActivePlugin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAllGamePlugins);
            this.Controls.Add(this.cbActiveClusterPlugin);
            this.Controls.Add(this.cbComPort);
            this.Controls.Add(this.lblPluginsDirectory);
            this.Controls.Add(this.lbComPort);
            this.Controls.Add(this.lbActiveGamePlugins);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.lbAllGamePlugins);
            this.Controls.Add(this.txtPluginsDirectory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(338, 289);
            this.Name = "ConfigurationForm";
            this.Text = "Racing Machinez Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.Label lbComPort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.TextBox txtPluginsDirectory;
        private System.Windows.Forms.Label lblPluginsDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbActiveClusterPlugin;
        private System.Windows.Forms.ListBox lbAllGamePlugins;
        private System.Windows.Forms.ListBox lbActiveGamePlugins;
        private System.Windows.Forms.Label lblAllGamePlugins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddActivePlugin;
        private System.Windows.Forms.Button btnRemoveActivePlugin;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label label3;
    }
}