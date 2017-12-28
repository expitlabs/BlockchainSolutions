using System;
using System.Windows.Forms;
using SendEncryptedEmail.Libraries;

namespace SendEncryptedEmail
{
    public partial class EncryptionKey : Form
    {
        string encryptionPrivateKey;
        SecurityHelper securityHelper;

        public EncryptionKey()
        {
            InitializeComponent();
        }
        public EncryptionKey(string encPrivateKey)
        {
            InitializeComponent();
            encryptionPrivateKey = encPrivateKey;
        }

        public string RegisteredEmailKey
        {
            get { return tbKey.Text.Trim(); }
            set { tbKey.Text = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            securityHelper = new SecurityHelper();
            tbKey.Text = securityHelper.Decrypt(encryptionPrivateKey, tbKey.Text.Trim());
        }
    }
}
