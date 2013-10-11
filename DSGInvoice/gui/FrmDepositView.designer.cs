namespace DSGInvoice.gui
{
    partial class FrmDepositView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddDeposit = new System.Windows.Forms.Button();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.chkUnActive = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUnActive);
            this.groupBox1.Controls.Add(this.btnAddDeposit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.Location = new System.Drawing.Point(607, 18);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(124, 40);
            this.btnAddDeposit.TabIndex = 7;
            this.btnAddDeposit.Text = "ออก ใบรับเงินมัดจำ";
            this.btnAddDeposit.UseVisualStyleBackColor = true;
            this.btnAddDeposit.Click += new System.EventHandler(this.btnAddDeposit_Click);
            // 
            // dgvView
            // 
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(12, 92);
            this.dgvView.Name = "dgvView";
            this.dgvView.Size = new System.Drawing.Size(737, 367);
            this.dgvView.TabIndex = 2;
            this.dgvView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellDoubleClick);
            // 
            // chkUnActive
            // 
            this.chkUnActive.AutoSize = true;
            this.chkUnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkUnActive.Location = new System.Drawing.Point(861, 26);
            this.chkUnActive.Name = "chkUnActive";
            this.chkUnActive.Size = new System.Drawing.Size(112, 24);
            this.chkUnActive.TabIndex = 8;
            this.chkUnActive.Text = "ดูข้อมูลยกเลิก";
            this.chkUnActive.UseVisualStyleBackColor = true;
            this.chkUnActive.Click += new System.EventHandler(this.chkUnActive_Click);
            // 
            // FrmDepositView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 471);
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDepositView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDepositView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDepositView_Load);
            this.Resize += new System.EventHandler(this.FrmDepositView_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Button btnAddDeposit;
        private System.Windows.Forms.CheckBox chkUnActive;
    }
}