using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SendEncryptedEmail.Libraries;
using SendEncryptedEmail.Models;

namespace SendEncryptedEmail
{
    public partial class frmConfirmReceival : Form
    {
        FileOperationsHelper fileHelper;
        SecurityHelper securityHelper;
        public string Address
        {
            get { return tbAddress.Text.Trim(); }
            set { tbAddress.Text = value; }
        }
        public string PrivateKey
        {
            get { return tbPrivateKey.Text.Trim(); }
            set { tbPrivateKey.Text = value; }
        }
        public string EmailHash
        {
            get { return tbEmailHash.Text.Trim(); }
            set { tbEmailHash.Text = value; }
        }

        public string EmailId
        {
            get { return tbEmailId.Text.Trim(); }
            set { tbEmailId.Text = value; }
        }

        public string EncryptionPublicKey
        {
            get { return tbEncryptionPublicKey.Text.Trim(); }
        }

        public string EncryptionPrivateKey { get; set; }

        public frmConfirmReceival()
        {
            InitializeComponent();         
            GetRecipientInfo();       
        }

        private void GetRecipientInfo()
        {
            fileHelper = new FileOperationsHelper();
            EthereumUser userInfo = fileHelper.ReadBinaryFile(fileHelper.FilePathGenerator(Constants.RecipientFile));
            if (userInfo != null)
            {
                tbAddress.Text = userInfo.PublicAddress;
                tbPrivateKey.Text = userInfo.PrivateKey;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void frmConfirmReceival_Load(object sender, EventArgs e)
        {
            GenerateRSAKeys();
        }

        private void GenerateRSAKeys()
        {
            securityHelper = new SecurityHelper();
            var keyPairs = securityHelper.GenerateRSAKeyPairs(1024);

            tbEncryptionPublicKey.Text = keyPairs.Key;
            EncryptionPrivateKey = keyPairs.Value;

            tbEncryptionPublicKey.Visible = true;
        }
    }
}
