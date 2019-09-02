namespace presentation.desktopApp.forms {
    partial class frmSettings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.gbxLanguage = new System.Windows.Forms.GroupBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblSettingsDescription = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.tabDNS = new System.Windows.Forms.TabPage();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbxLanguage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxLanguage
            // 
            resources.ApplyResources(this.gbxLanguage, "gbxLanguage");
            this.gbxLanguage.Controls.Add(this.cmbLanguage);
            this.gbxLanguage.Controls.Add(this.lblLanguage);
            this.gbxLanguage.Name = "gbxLanguage";
            this.gbxLanguage.TabStop = false;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Sorted = true;
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // lblSettingsDescription
            // 
            resources.ApplyResources(this.lblSettingsDescription, "lblSettingsDescription");
            this.lblSettingsDescription.Name = "lblSettingsDescription";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabCommon);
            this.tabControl.Controls.Add(this.tabDNS);
            this.tabControl.Controls.Add(this.tabSchedule);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabCommon
            // 
            this.tabCommon.Controls.Add(this.gbxLanguage);
            resources.ApplyResources(this.tabCommon, "tabCommon");
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.UseVisualStyleBackColor = true;
            // 
            // tabDNS
            // 
            resources.ApplyResources(this.tabDNS, "tabDNS");
            this.tabDNS.Name = "tabDNS";
            this.tabDNS.UseVisualStyleBackColor = true;
            // 
            // tabSchedule
            // 
            resources.ApplyResources(this.tabSchedule, "tabSchedule");
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lblSettingsDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSettings_FormClosing);
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.gbxLanguage.ResumeLayout(false);
            this.gbxLanguage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblSettingsDescription;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.TabPage tabDNS;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}