namespace SendEncryptedEmail
{
    partial class RegisterEmail : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RegisterEmail()
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
            this.btnEncrypt = this.Factory.CreateRibbonButton();
            this.btnUploadEmailId = this.Factory.CreateRibbonButton();
            this.btnGetEmailHash = this.Factory.CreateRibbonButton();
            this.btnConfirmEmailHash = this.Factory.CreateRibbonButton();
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
            this.tab1.ControlId.OfficeId = "TabNewMailMessage";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "EXPIT Registered Email";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnEncrypt);
            this.group1.Items.Add(this.btnUploadEmailId);
            this.group1.Items.Add(this.btnGetEmailHash);
            this.group1.Items.Add(this.btnConfirmEmailHash);
            this.group1.Items.Add(this.btnStatus);
            this.group1.Items.Add(this.btnSettings);
            this.group1.Items.Add(this.btnOpenEtherScan);
            this.group1.Label = "Sender";
            this.group1.Name = "group1";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnEncrypt.Label = "1- Encrypt Email";
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.ShowImage = true;
            this.btnEncrypt.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnEncrypt_Click);
            // 
            // btnUploadEmailId
            // 
            this.btnUploadEmailId.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnUploadEmailId.Label = "2- Recipient Address";
            this.btnUploadEmailId.Name = "btnUploadEmailId";
            this.btnUploadEmailId.ShowImage = true;
            this.btnUploadEmailId.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUploadEmailId_Click);
            // 
            // btnGetEmailHash
            // 
            this.btnGetEmailHash.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnGetEmailHash.Label = "4- Get Hash && Key*";
            this.btnGetEmailHash.Name = "btnGetEmailHash";
            this.btnGetEmailHash.ShowImage = true;
            this.btnGetEmailHash.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGetEmailHash_Click);
            // 
            // btnConfirmEmailHash
            // 
            this.btnConfirmEmailHash.Image = global::SendEncryptedEmail.Properties.Resources.expit;
            this.btnConfirmEmailHash.Label = "5- Confirm Hash*";
            this.btnConfirmEmailHash.Name = "btnConfirmEmailHash";
            this.btnConfirmEmailHash.ShowImage = true;
            this.btnConfirmEmailHash.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfirmEmailHash_Click);
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
            // RegisterEmail
            // 
            this.Name = "RegisterEmail";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose, Microsoft.Outlook.Mail.Read, Microsoft.Outlook.Re" +
    "sponse.Compose";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RegisterEmail_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEncrypt;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUploadEmailId;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnGetEmailHash;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfirmEmailHash;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOpenEtherScan;
    }

    partial class ThisRibbonCollection
    {
        internal RegisterEmail RegisterEmail
        {
            get { return this.GetRibbon<RegisterEmail>(); }
        }
    }
}
