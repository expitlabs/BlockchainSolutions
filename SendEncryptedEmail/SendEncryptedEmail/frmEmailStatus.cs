using System;
using System.Drawing;
using System.Windows.Forms;
using SendEncryptedEmail.Libraries;
using SendEncryptedEmail.Models;

namespace SendEncryptedEmail
{
    public partial class frmEmailStatus : Form
    {
        string emailId;
        BlockchainHelper blockchainHelper;
        EthereumContract ethContract;

        public frmEmailStatus()
        {
            InitializeComponent();
        }

        public frmEmailStatus(EthereumContract eContract, string eId)
        {
            InitializeComponent();

            blockchainHelper = new BlockchainHelper();

            ethContract = new EthereumContract();
            ethContract.ContractABI = eContract.ContractABI;
            ethContract.ContractAddress = eContract.ContractAddress;

            emailId = eId;
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            var result = blockchainHelper.UpdateEmailStatus(ethContract, emailId).Result;   
            UpdateEmailStatus((int)result);
        }

        private void UpdateEmailStatus(int status)
        {
            dgvEmailStatus.Rows.Clear();
            switch(status)
            {
                case 0:
                    dgvEmailStatus.Rows.Add("Email was encrypted successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email Id was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email was received and email hash and symmetric key were uploaded successfully.", "Recipient", "Pending");
                    dgvEmailStatus.Rows.Add("Email hash and symmetric key were retrieved successfully.", "Sender", "Pending");
                    dgvEmailStatus.Rows.Add("Email has was confirmed and shared key was uploaded successfully.", "Sender", "Pending");
                    dgvEmailStatus.Rows.Add("Email shared key was retrieved successfully.", "Recipient", "Pending");
                    //dgvEmailStatus.Rows.Add("Email was decrypted successfully.", "Recipient", "Pending");

                    dgvEmailStatus.ClearSelection();
                    dgvEmailStatus.Rows[1].Selected = true;
                    break;
                case 1:
                    dgvEmailStatus.Rows.Add("Email was encrypted successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email Id was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email was received and email hash and symmetric key were uploaded successfully.", "Recipient", "Done");
                    dgvEmailStatus.Rows.Add("Email hash and symmetric key were retrieved successfully.", "Sender", "Pending");
                    dgvEmailStatus.Rows.Add("Email has was confirmed and shared key was uploaded successfully.", "Sender", "Pending");
                    dgvEmailStatus.Rows.Add("Email shared key was retrieved successfully.", "Recipient", "Pending");
                    //dgvEmailStatus.Rows.Add("Email was decrypted successfully.", "Recipient", "Pending");

                    dgvEmailStatus.ClearSelection();
                    dgvEmailStatus.Rows[2].Selected = true;
                    break;
                case 2:
                    dgvEmailStatus.Rows.Add("Email was encrypted successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email Id was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email was received and email hash and symmetric key were uploaded successfully.", "Recipient", "Done");
                    dgvEmailStatus.Rows.Add("Email hash and symmetric key were retrieved successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email has was confirmed and shared key was uploaded successfully.", "Sender", "Pending");
                    dgvEmailStatus.Rows.Add("Email shared key was retrieved successfully.", "Recipient", "Pending");
                    //dgvEmailStatus.Rows.Add("Email was decrypted successfully.", "Recipient", "Pending");

                    dgvEmailStatus.ClearSelection();
                    dgvEmailStatus.Rows[3].Selected = true;
                    break;
                case 3:
                    dgvEmailStatus.Rows.Add("Email was encrypted successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email Id was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email was received and email hash and symmetric key were uploaded successfully.", "Recipient", "Done");
                    dgvEmailStatus.Rows.Add("Email hash and symmetric key were retrieved successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email has was confirmed and shared key was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email shared key was retrieved successfully.", "Recipient", "Pending");
                    //dgvEmailStatus.Rows.Add("Email was decrypted successfully.", "Recipient", "Pending");

                    dgvEmailStatus.ClearSelection();
                    dgvEmailStatus.Rows[4].Selected = true;
                    break;
                case 4:
                    dgvEmailStatus.Rows.Add("Email was encrypted successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email Id was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email was received and email hash and symmetric key were uploaded successfully.", "Recipient", "Done");
                    dgvEmailStatus.Rows.Add("Email hash and symmetric key were retrieved successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email has was confirmed and shared key was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email shared key was retrieved successfully.", "Recipient", "Done");
                    //dgvEmailStatus.Rows.Add("Email was decrypted successfully.", "Recipient", "Done");

                    dgvEmailStatus.ClearSelection();
                    dgvEmailStatus.Rows[6].Selected = true;
                    break;
                default:
                    dgvEmailStatus.Rows.Add("Email was encrypted successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email Id was uploaded successfully.", "Sender", "Done");
                    dgvEmailStatus.Rows.Add("Email was received and email hash and symmetric key were uploaded successfully.", "Recipient", "Pending");
                    dgvEmailStatus.Rows.Add("Email hash and symmetric key were retrieved successfully.", "Sender", "Pending");
                    dgvEmailStatus.Rows.Add("Email has was confirmed and shared key was uploaded successfully.", "Sender", "Pending");
                    dgvEmailStatus.Rows.Add("Email shared key was retrieved successfully.", "Recipient", "Pending");
                    //dgvEmailStatus.Rows.Add("Email was decrypted successfully.", "Recipient", "Pending");
                    break;
            }
            
            
        }

        private void dgvEmailStatus_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
