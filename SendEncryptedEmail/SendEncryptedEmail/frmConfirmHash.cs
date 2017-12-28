using System;
using System.Windows.Forms;
using SendEncryptedEmail.Libraries;

namespace SendEncryptedEmail
{
    public partial class frmConfirmHash : Form
    {
        string encryptionPublicKey;
        SecurityHelper securityHelper;

        public string EmailEncryptionKey
        {
            get { return tbEncryptionKey.Text.Trim(); }
        }
        public string RecipientAddress
        {
            get { return tbRecipientAddress.Text.Trim(); }
        }
        public frmConfirmHash(string encPublicKey)
        {
            InitializeComponent();

            encryptionPublicKey = encPublicKey;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            securityHelper = new SecurityHelper();

            tbEncryptionKey.Text = securityHelper.Encrypt(encryptionPublicKey, EmailEncryptionKey);
        }
    }
}
