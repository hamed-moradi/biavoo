namespace presentation.desktopApp {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnTray = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.grbConnection = new System.Windows.Forms.GroupBox();
            this.lblNetworkConnection = new System.Windows.Forms.Label();
            this.cmbNetworkConnection = new System.Windows.Forms.ComboBox();
            this.grbDNS = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmbAlternateDNS = new System.Windows.Forms.ComboBox();
            this.cmbPreferredDNS = new System.Windows.Forms.ComboBox();
            this.lblAlternateDNS = new System.Windows.Forms.Label();
            this.lblPreferredDNS = new System.Windows.Forms.Label();
            this.grbConnection.SuspendLayout();
            this.grbDNS.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTray
            // 
            resources.ApplyResources(this.btnTray, "btnTray");
            this.btnTray.FlatAppearance.BorderSize = 0;
            this.btnTray.Name = "btnTray";
            this.btnTray.UseVisualStyleBackColor = true;
            this.btnTray.Click += new System.EventHandler(this.BtnTray_Click);
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // grbConnection
            // 
            resources.ApplyResources(this.grbConnection, "grbConnection");
            this.grbConnection.Controls.Add(this.lblNetworkConnection);
            this.grbConnection.Controls.Add(this.cmbNetworkConnection);
            this.grbConnection.Name = "grbConnection";
            this.grbConnection.TabStop = false;
            // 
            // lblNetworkConnection
            // 
            resources.ApplyResources(this.lblNetworkConnection, "lblNetworkConnection");
            this.lblNetworkConnection.Name = "lblNetworkConnection";
            // 
            // cmbNetworkConnection
            // 
            resources.ApplyResources(this.cmbNetworkConnection, "cmbNetworkConnection");
            this.cmbNetworkConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetworkConnection.FormattingEnabled = true;
            this.cmbNetworkConnection.Name = "cmbNetworkConnection";
            // 
            // grbDNS
            // 
            resources.ApplyResources(this.grbDNS, "grbDNS");
            this.grbDNS.Controls.Add(this.btnApply);
            this.grbDNS.Controls.Add(this.cmbAlternateDNS);
            this.grbDNS.Controls.Add(this.cmbPreferredDNS);
            this.grbDNS.Controls.Add(this.lblAlternateDNS);
            this.grbDNS.Controls.Add(this.lblPreferredDNS);
            this.grbDNS.Name = "grbDNS";
            this.grbDNS.TabStop = false;
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // cmbAlternateDNS
            // 
            resources.ApplyResources(this.cmbAlternateDNS, "cmbAlternateDNS");
            this.cmbAlternateDNS.FormattingEnabled = true;
            this.cmbAlternateDNS.Name = "cmbAlternateDNS";
            // 
            // cmbPreferredDNS
            // 
            resources.ApplyResources(this.cmbPreferredDNS, "cmbPreferredDNS");
            this.cmbPreferredDNS.FormattingEnabled = true;
            this.cmbPreferredDNS.Name = "cmbPreferredDNS";
            this.cmbPreferredDNS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CmbPreferredDNS_KeyUp);
            // 
            // lblAlternateDNS
            // 
            resources.ApplyResources(this.lblAlternateDNS, "lblAlternateDNS");
            this.lblAlternateDNS.Name = "lblAlternateDNS";
            // 
            // lblPreferredDNS
            // 
            resources.ApplyResources(this.lblPreferredDNS, "lblPreferredDNS");
            this.lblPreferredDNS.Name = "lblPreferredDNS";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.grbDNS);
            this.Controls.Add(this.grbConnection);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnTray);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.grbConnection.ResumeLayout(false);
            this.grbConnection.PerformLayout();
            this.grbDNS.ResumeLayout(false);
            this.grbDNS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTray;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.GroupBox grbConnection;
        private System.Windows.Forms.Label lblNetworkConnection;
        private System.Windows.Forms.ComboBox cmbNetworkConnection;
        private System.Windows.Forms.GroupBox grbDNS;
        private System.Windows.Forms.ComboBox cmbAlternateDNS;
        private System.Windows.Forms.ComboBox cmbPreferredDNS;
        private System.Windows.Forms.Label lblAlternateDNS;
        private System.Windows.Forms.Label lblPreferredDNS;
        private System.Windows.Forms.Button btnApply;
    }
}

