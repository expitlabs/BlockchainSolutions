using System;
using System.Collections.Generic;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using SendEncryptedEmail.Libraries;
using SendEncryptedEmail.Models;

namespace SendEncryptedEmail
{
    public partial class RegisterEmail
    {
        EthereumUser emailSender;
        EthereumContract ethContract;
        SecurityHelper securityHelper;
        FileOperationsHelper fileHelper;
        BlockchainHelper blockchainHelper;

        public string EmailId { get; set; }
        public string PublicEncryptionKey { get; set; }

        private void RegisterEmail_Load(object sender, RibbonUIEventArgs e)
        {
            blockchainHelper = new BlockchainHelper();

            // Ethereum contract details
            ethContract = new EthereumContract();
            ethContract.ContractAddress = Constants.ContractAddress;
            ethContract.ContractABI = Constants.ContractABI;

            // Get sender's saved Ethereum account details (If exists)
            GetSenderInfo();
        }

        private void GetSenderInfo()
        {
            // Email sender
            emailSender = new EthereumUser();

            fileHelper = new FileOperationsHelper();
            EthereumUser userInfo = fileHelper.ReadBinaryFile(fileHelper.FilePathGenerator(Constants.SenderFile));
            if (userInfo != null)
            {
                emailSender.PublicAddress = userInfo.PublicAddress;
                emailSender.PrivateKey = userInfo.PrivateKey;
            }
        }

        private void btnEncrypt_Click(object sender, RibbonControlEventArgs e)
        {
            var m = e.Control.Context as Inspector;
            var mailitem = m.CurrentItem as MailItem;

            // The email Id to be used as an email reference
            EmailId = DateTime.UtcNow.ToString("yyyyMMddHHmmssms") + emailSender.PublicAddress;

            // Encrypt original email and its attachments (if any)
            CreateRegisteredEmail(mailitem);
        }

        private void CreateRegisteredEmail(MailItem mailitem)
        {
            Application outlookApp = new Application();
            MailItem encryptedMail = outlookApp.CreateItem(OlItemType.olMailItem) as MailItem;

            encryptedMail.To = mailitem.To;
            encryptedMail.CC = mailitem.CC;
            encryptedMail.BCC = mailitem.BCC;
            encryptedMail.Subject = mailitem.Subject;
            encryptedMail.BodyFormat = mailitem.BodyFormat;
            encryptedMail.Body = mailitem.Body;
            encryptedMail.HTMLBody = mailitem.HTMLBody;
            encryptedMail.Importance = mailitem.Importance;

            try
            {
                if (mailitem.Attachments.Count > 0)
                {
                    for (int x = 1; x <= mailitem.Attachments.Count; x++)
                    {
                        mailitem.Attachments[x].SaveAsFile(fileHelper.FilePathGenerator(mailitem.Attachments[x].FileName));
                        encryptedMail.Attachments.Add(fileHelper.FilePathGenerator(mailitem.Attachments[x].FileName), OlAttachmentType.olByValue, 1, mailitem.Attachments[x].FileName);
                        File.Delete(fileHelper.FilePathGenerator(mailitem.Attachments[x].FileName));
                    }
                }
            }
            catch (System.Exception ex)
            {
                // System.Windows.Forms.MessageBox.Show(ex.Message+"\r\n"+ex.InnerException);
            }

            //Remove attachments from email
            int originalAttachmentsCount = mailitem.Attachments.Count;
            for (int x = 1; x <= originalAttachmentsCount; x++)
                mailitem.Attachments.Remove(1);

            // Encrypt email with attachments if any
            string filePath = fileHelper.FilePathGenerator(encryptedMail.Subject) + ".msg";
            encryptedMail.SaveAs(filePath);
            string encryptedFilePath = EncryptSavedEmail(filePath);

            // Add encrypted email as an attachment
            mailitem.Attachments.Add(encryptedFilePath, OlAttachmentType.olByValue, 1, encryptedFilePath);

            //Hash encrypted email
            securityHelper = new SecurityHelper();
            mailitem.Body = "Email is encrypted and ready to be sent! \n\r" + "Encrypted email hash is " + securityHelper.HashFile(encryptedFilePath) + "\n\r" + "Your Email ID is " + EmailId;

            //Delete encrypted email
            File.Delete(filePath);
        }

        private string EncryptSavedEmail(string filePath)
        {
            securityHelper = new SecurityHelper();

            EncryptionKey eK = new EncryptionKey();
            var btn = eK.Controls.Find("btnDecrypt", false);
            btn[0].Visible = false;

            eK.ShowDialog();
            if (eK.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                securityHelper.FileEncrypt(filePath, eK.RegisteredEmailKey);
            }

            return filePath + Constants.EncryptedFileExtension;
        }

        private void btnUploadEmailId_Click(object sender, RibbonControlEventArgs e)
        {
            UploadEmailIdToEthereum();
        }

        private void UploadEmailIdToEthereum()
        {
            string txResult;
            frmUploadEmailId frm = new frmUploadEmailId();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txResult = blockchainHelper.UploadEmailId(ethContract, emailSender, frm.RecipientAddress, EmailId).Result;
                System.Windows.Forms.MessageBox.Show("Email Id was added successfully!", "EXPIT Registered Email", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                btnStatus.Enabled = true;
            }
        }

        private void btnGetEmailHash_Click(object sender, RibbonControlEventArgs e)
        {
            GetEmailHash(e);
        }

        private void GetEmailHash(RibbonControlEventArgs e)
        {
            var m = e.Control.Context as Inspector;
            var mailitem = m.CurrentItem as MailItem;

            frmGetEmailId frm = new frmGetEmailId();
            frm.EmailId = mailitem.Body.Substring(mailitem.Body.LastIndexOf("Your Email ID is")).Replace("Your Email ID is ", "").Trim();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                EmailId = frm.EmailId;

                string getEmailHashResult = blockchainHelper.GetEmailHashWithTransaction(ethContract, emailSender, EmailId).Result;
                getEmailHashResult = blockchainHelper.GetEmailHashWithoutTransaction(ethContract, EmailId).Result;

                string getEncryptionPublicKeyResult = blockchainHelper.GetEmailEncryptionPublicKeyWithTransaction(ethContract, emailSender, EmailId).Result;
                PublicEncryptionKey = blockchainHelper.GetEmailEncryptionPublicKeyWithoutTransaction(ethContract, EmailId).Result;

                string result = "Email Hash: \n\r ----------- \n\r " + getEmailHashResult + "\r\n" + "Encryption Public Key: \n\r ------------------------- \n\r " + PublicEncryptionKey;
                System.Windows.Forms.DialogResult dR = System.Windows.Forms.MessageBox.Show(result + "\n\r" + " (Click Ok to Copy email hash and encryption public key)", "EXPIT Registered Email", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Information);

                if (dR == System.Windows.Forms.DialogResult.OK)
                {
                    System.Windows.Forms.Clipboard.SetText(result);
                    btnStatus.Enabled = true;
                }
            }
        }

        private void btnConfirmEmailHash_Click(object sender, RibbonControlEventArgs e)
        {
            ConfirmEmailHash();
        }

        private void ConfirmEmailHash()
        {
            frmConfirmHash frm = new frmConfirmHash(PublicEncryptionKey);
            frm.ShowDialog();

            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                string confirmHashResult = blockchainHelper.ConfirmEmailHash(ethContract, emailSender, frm.RecipientAddress, EmailId, frm.EmailEncryptionKey).Result;
                System.Windows.Forms.MessageBox.Show("Email hash was confirmed successfully!", "EXPIT Registered Email", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                btnStatus.Enabled = true;
            }
        }

        private void btnStatus_Click(object sender, RibbonControlEventArgs e)
        {
            // Show registered email status
            frmEmailStatus frmEmailStatus = new frmEmailStatus(ethContract, EmailId);
            frmEmailStatus.ShowDialog();
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            // Load/Save Ethereum account details
            frmEthereumAccountDetails accDetails = new frmEthereumAccountDetails(Constants.SenderFile);
            accDetails.ShowDialog();
        }

        private void btnOpenEtherScan_Click(object sender, RibbonControlEventArgs e)
        {
            // Navigate to a URL.
            System.Diagnostics.Process.Start(Constants.EtherScanURL);
        }
    }
}
