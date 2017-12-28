using System;
using System.Windows.Forms;

namespace SendEncryptedEmail
{
    public partial class frmUploadEmailId : Form
    {
        public string RecipientAddress
        {
            get { return tbRecipientAddress.Text.Trim(); }
        }
        public frmUploadEmailId()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
