using System;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Windows.Forms;
using SendEncryptedEmail.Libraries;
using SendEncryptedEmail.Models;
using System.Collections.Generic;

namespace SendEncryptedEmail
{
    public partial class ReadEncryptedEmail
    {
        string emailId;
        string encryptionPublicKey;
        string encryptionPrivateKey;

        BlockchainHelper blockchainHelper;
        SecurityHelper securityHelper = new SecurityHelper();
        EthereumContract ethContract;
        EthereumUser emailRecipient;
        FileOperationsHelper fileHelper;

        private static readonly Object locker = new Object();

        public string SharedKey { get; set; }

        private void ReadEncryptedEmail_Load(object sender, RibbonUIEventArgs e)
        {
            blockchainHelper = new BlockchainHelper();
            securityHelper = new SecurityHelper();
            fileHelper = new FileOperationsHelper();

            ethContract = new EthereumContract();
            ethContract.ContractAddress = Constants.ContractAddress;
            ethContract.ContractABI = Constants.ContractABI;

            // Get recipient's saved Ethereum account details (If exists)
            GetRecipientInfo();
        }

        /// <summary>
        /// Get recipient's saved Ethereum account details (If exists)
        /// </summary>
        private void GetRecipientInfo()
        {
            // Email recipient
            emailRecipient = new EthereumUser();

            EthereumUser userInfo = fileHelper.ReadBinaryFile(fileHelper.FilePathGenerator(Constants.RecipientFile));
            if (userInfo != null)
            {
                emailRecipient.PublicAddress = userInfo.PublicAddress;
                emailRecipient.PrivateKey = userInfo.PrivateKey;
            }
        }

        private void btnConfirmReceival_Click(object sender, RibbonControlEventArgs e)
        {
            // Confirm email receival
            ConfirmReceival(e);
        }

        /// <summary>
        /// Confirm email receival
        /// </summary>
        /// <param name="e"></param>
        private void ConfirmReceival(RibbonControlEventArgs e)
        {
            var m = e.Control.Context as Inspector;
            var mailitem = m.CurrentItem as MailItem;

            try
            {
                if (mailitem.Attachments.Count > 0)
                {
                    string filePath;
                    for (int i = 1; i <= mailitem.Attachments.Count; i++)
                    {
                        filePath = fileHelper.FilePathGenerator(mailitem.Attachments[i].FileName);

                        mailitem.Attachments[i].SaveAsFile(filePath);
                        if (mailitem.Attachments[i].FileName.Contains(Constants.EncryptedFileExtension))
                        {
                            string emId = mailitem.Body.Substring(mailitem.Body.LastIndexOf("Your Email ID is")).Replace("Your Email ID is ", "").Trim();

                            //Hash attached encrypted email
                            string encryptedEmailHash = securityHelper.HashFile(filePath);

                            frmConfirmReceival frm = new frmConfirmReceival();
                            frm.EmailHash = encryptedEmailHash;
                            frm.EmailId = emId;
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                string confirmResult = blockchainHelper.ConfirmReceivalAndUploadEmailHash(ethContract, emailRecipient, frm.EmailId, frm.EmailHash, frm.EncryptionPublicKey).Result;

                                emailId = frm.EmailId;
                                encryptionPublicKey = frm.EncryptionPublicKey;
                                encryptionPrivateKey = frm.EncryptionPrivateKey;

                                btnStatus.Enabled = true;

                                MessageBox.Show("Email receival was confirmed successfully!", "EXPIT Registered Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            MessageBox.Show("This email doesn't contain a registered email.", "EXPIT Registered Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                    MessageBox.Show("This email doesn't contain a registered email.", "EXPIT Registered Email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Exception ex)
            {
                // System.Windows.Forms.MessageBox.Show(ex.Message+"\r\n"+ex.InnerException);
            }
        }

        private void btnGetEncryptionKey_Click(object sender, RibbonControlEventArgs e)
        {
            // Get encrypted shared key from Ethereum
            GetEncryptionKeyFromEthereum();
        }

        /// <summary>
        /// Get encrypted shared key from Ethereum
        /// </summary>
        private void GetEncryptionKeyFromEthereum()
        {
            string getEmailKeyResult = blockchainHelper.GetEmailKeyWithTransaction(ethContract, emailRecipient, emailId).Result;
            SharedKey = blockchainHelper.GetEmailKeyWithoutTransaction(ethContract, emailId).Result;
            DialogResult dr = MessageBox.Show("Shared key was retrieved successfully! \r\n Shared Key: \r\n================ \r\n" + SharedKey + "(Click Ok to copy)", "EXPIT Registered Email", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                Clipboard.SetText(SharedKey);
                btnStatus.Enabled = true;
            }
        }

        private void btnDycrept_Click(object sender, RibbonControlEventArgs e)
        {
            // Decrypt the received registered email by the shared key provided by the sender.
            DecryptRegisteredEmail(e);
        }

        /// <summary>
        /// Decrypt the received registered email by the shared key provided by the sender.
        /// </summary>
        /// <param name="e"></param>
        private void DecryptRegisteredEmail(RibbonControlEventArgs e)
        {
            var m = e.Control.Context as Inspector;
            var mailitem = m.CurrentItem as MailItem;

            try
            {
                if (mailitem.Attachments.Count > 0)
                {
                    string filePath;
                    for (int i = 1; i <= mailitem.Attachments.Count; i++)
                    {
                        filePath = fileHelper.FilePathGenerator(mailitem.Attachments[i].FileName);

                        mailitem.Attachments[i].SaveAsFile(filePath);
                        if (mailitem.Attachments[i].FileName.Contains(Constants.EncryptedFileExtension))
                        {
                            //Hash attached encrypted email
                            string encryptedEmailHash = securityHelper.HashFile(filePath);

                            EncryptionKey eK = new EncryptionKey(encryptionPrivateKey);
                            eK.RegisteredEmailKey = SharedKey;

                            eK.ShowDialog();

                            if (eK.DialogResult == DialogResult.OK)
                            {
                                if (File.Exists(filePath))
                                {
                                    SaveFileDialog sfdSaveDecryptedEmail = new SaveFileDialog();
                                    sfdSaveDecryptedEmail.Title = "Save Decrypted Email";
                                    sfdSaveDecryptedEmail.FileName = mailitem.Subject + ".msg";
                                    sfdSaveDecryptedEmail.InitialDirectory = @"c:\";
                                    sfdSaveDecryptedEmail.CheckPathExists = true;
                                    sfdSaveDecryptedEmail.DefaultExt = "msg";
                                    sfdSaveDecryptedEmail.Filter = "msg files (*.msg)|*.msg|All files (*.*)|*.*";
                                    sfdSaveDecryptedEmail.FilterIndex = 1;
                                    sfdSaveDecryptedEmail.RestoreDirectory = true;
                                    if (sfdSaveDecryptedEmail.ShowDialog() == DialogResult.OK)
                                    {
                                        securityHelper.FileDecrypt(filePath, sfdSaveDecryptedEmail.FileName, eK.RegisteredEmailKey);

                                        // Delete encrypted email
                                        File.Delete(filePath);

                                        MessageBox.Show("Email was decrypted successfully!", "EXPIT Registered Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        string argument = "/select, \"" + sfdSaveDecryptedEmail.FileName + "\"";
                                        System.Diagnostics.Process.Start("explorer.exe", argument);
                                        btnStatus.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                // System.Windows.Forms.MessageBox.Show(ex.Message+"\r\n"+ex.InnerException);
            }
        }

        private void btnStatus_Click(object sender, RibbonControlEventArgs e)
        {
            // Show registered email status
            frmEmailStatus eStatus = new frmEmailStatus(ethContract, emailId);
            eStatus.ShowDialog();
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            // Load/Save Ethereum account details
            frmEthereumAccountDetails accDetails = new frmEthereumAccountDetails(Constants.RecipientFile);
            accDetails.ShowDialog();
        }

        private void btnOpenEtherScan_Click(object sender, RibbonControlEventArgs e)
        {
            // Navigate to a URL.
            System.Diagnostics.Process.Start(Constants.EtherScanURL);
        }
    }
}
