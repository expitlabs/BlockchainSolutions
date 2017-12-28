using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SendEncryptedEmail.Libraries;
using SendEncryptedEmail.Models;

namespace SendEncryptedEmail
{
    public partial class frmEthereumAccountDetails : Form
    {
        FileOperationsHelper fileHelper;
        EthereumUser user;

        public string UserFile { get; set; }

        public frmEthereumAccountDetails(string userFile)
        {
            InitializeComponent();

            UserFile = userFile;
            fileHelper = new FileOperationsHelper();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAccount();
        }

        private void SaveAccount()
        {
            user = new EthereumUser();
            user.PublicAddress = tbPublicAddress.Text.Trim();
            user.PrivateKey = tbPrivateKey.Text.Trim();

            if (fileHelper.WriteBinaryFile(fileHelper.FilePathGenerator(UserFile), user))
                lblStatus.Text = "Saved Successfully!";
            else
                lblStatus.Text = "Unable to save. Please try again.";
        }

        private void frmEthereumAccountDetails_Load(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void LoadAccount()
        {
            user = new EthereumUser();
            user = fileHelper.ReadBinaryFile(fileHelper.FilePathGenerator(UserFile));
            if (user != null)
            {
                tbPublicAddress.Text = user.PublicAddress;
                tbPrivateKey.Text = user.PrivateKey;
            }
        }
    }
}
