namespace SendEncryptedEmail
{
    partial class ReadEncryptedEmail : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ReadEncryptedEmail()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnConfirmReceival = this.Factory.CreateRibbonButton();
            this.btnGetEncryptionKey = this.Factory.CreateRibbonButton();
            this.btnDycrept = this.Factory.CreateRibbonButton();
            this.btnStatus = this.Factory.CreateRibbonButton();
            this.btnSettings = this.Factory.CreateRibbonButton();
            this.btnOpenEtherScan = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabReadMessage";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "EXPIT Registered Email";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnConfirmReceival);
            this.group1.Items.Add(this.btnGetEncryptionKey);
            this.group1.Items.Add(this.btnDycrept);
            this.group1.Items.Add(this.btnStatus);
            this.group1.Items.Add(this.btnSettings);
            this.group1.Items.Add(this.btnOpenEtherScan);
            this.group1.Label = "Recipient";
            this.group1.Name = "group1";
            // 
            // btnConfirmReceival
            // 
            this.btnConfirmReceival.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnConfirmReceival.Label = "3- Confirm";
            this.btnConfirmReceival.Name = "btnConfirmReceival";
            this.btnConfirmReceival.ShowImage = true;
            this.btnConfirmReceival.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfirmReceival_Click);
            // 
            // btnGetEncryptionKey
            // 
            this.btnGetEncryptionKey.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnGetEncryptionKey.Label = "6- Get Key*";
            this.btnGetEncryptionKey.Name = "btnGetEncryptionKey";
            this.btnGetEncryptionKey.ShowImage = true;
            this.btnGetEncryptionKey.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGetEncryptionKey_Click);
            // 
            // btnDycrept
            // 
            this.btnDycrept.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnDycrept.Label = "7- Decrypt*";
            this.btnDycrept.Name = "btnDycrept";
            this.btnDycrept.ShowImage = true;
            this.btnDycrept.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDycrept_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Enabled = false;
            this.btnStatus.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnStatus.Label = "Status";
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.ShowImage = true;
            this.btnStatus.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStatus_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnSettings.Label = "Settings";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ShowImage = true;
            this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettings_Click);
            // 
            // btnOpenEtherScan
            // 
            this.btnOpenEtherScan.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnOpenEtherScan.Label = "Contract Info";
            this.btnOpenEtherScan.Name = "btnOpenEtherScan";
            this.btnOpenEtherScan.ShowImage = true;
            this.btnOpenEtherScan.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOpenEtherScan_Click);
            // 
            // ReadEncryptedEmail
            // 
            this.Name = "ReadEncryptedEmail";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ReadEncryptedEmail_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDycrept;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfirmReceival;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnGetEncryptionKey;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOpenEtherScan;
    }

    partial class ThisRibbonCollection
    {
        internal ReadEncryptedEmail ReadEncryptedEmail
        {
            get { return this.GetRibbon<ReadEncryptedEmail>(); }
        }
    }
}
