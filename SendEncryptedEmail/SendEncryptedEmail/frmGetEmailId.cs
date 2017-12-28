using System;
using System.Windows.Forms;

namespace SendEncryptedEmail
{
    public partial class frmGetEmailId : Form
    {
        public string EmailId
        {
            get { return tbEmailId.Text.Trim(); }
            set { tbEmailId.Text = value; }
        }

        public frmGetEmailId()
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
