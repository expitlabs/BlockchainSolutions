namespace SendEncryptedEmail
{
    partial class frmEmailStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmailStatus));
            this.dgvEmailStatus = new System.Windows.Forms.DataGridView();
            this.clmStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmailStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmailStatus
            // 
            this.dgvEmailStatus.AllowUserToAddRows = false;
            this.dgvEmailStatus.AllowUserToDeleteRows = false;
            this.dgvEmailStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmailStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmStep,
            this.clmStatus,
            this.clmOwner});
            this.dgvEmailStatus.Location = new System.Drawing.Point(12, 12);
            this.dgvEmailStatus.Name = "dgvEmailStatus";
            this.dgvEmailStatus.ReadOnly = true;
            this.dgvEmailStatus.Size = new System.Drawing.Size(706, 155);
            this.dgvEmailStatus.TabIndex = 2;
            this.dgvEmailStatus.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvEmailStatus_RowPostPaint);
            // 
            // clmStep
            // 
            this.clmStep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmStep.DataPropertyName = "Step";
            this.clmStep.HeaderText = "Step";
            this.clmStep.Name = "clmStep";
            this.clmStep.ReadOnly = true;
            // 
            // clmStatus
            // 
            this.clmStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmStatus.DataPropertyName = "Owner";
            this.clmStatus.HeaderText = "Owner";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clmOwner
            // 
            this.clmOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmOwner.DataPropertyName = "Status";
            this.clmOwner.HeaderText = "Status";
            this.clmOwner.Name = "clmOwner";
            this.clmOwner.ReadOnly = true;
            this.clmOwner.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(643, 173);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 3;
            this.btnStatus.Text = "Update";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // frmEmailStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 205);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.dgvEmailStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmailStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmailStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEmailStatus;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOwner;
    }
}