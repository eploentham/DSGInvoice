namespace DSGInvoice.gui
{
    partial class FrmRecpAdd
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
            this.btnCust = new System.Windows.Forms.Button();
            this.txtCustRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.cboCust = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpRecepDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecpNumber = new System.Windows.Forms.TextBox();
            this.dgvAdd = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDeposit = new System.Windows.Forms.CheckBox();
            this.txtDepositId = new System.Windows.Forms.TextBox();
            this.dgvDeposit = new System.Windows.Forms.DataGridView();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecpId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvRemark = new System.Windows.Forms.TextBox();
            this.txtInvId = new System.Windows.Forms.TextBox();
            this.cboInv = new System.Windows.Forms.ComboBox();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkReceiptSome = new System.Windows.Forms.RadioButton();
            this.chkReceiptAll = new System.Windows.Forms.RadioButton();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUnActive = new System.Windows.Forms.Button();
            this.chkUnActive = new System.Windows.Forms.RadioButton();
            this.chkActive = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdd)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCust);
            this.groupBox1.Controls.Add(this.txtCustRemark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCustId);
            this.groupBox1.Controls.Add(this.cboCust);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpRecepDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRecpNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1138, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ใบเสร็จรับเงิน";
            // 
            // btnCust
            // 
            this.btnCust.Location = new System.Drawing.Point(983, 23);
            this.btnCust.Name = "btnCust";
            this.btnCust.Size = new System.Drawing.Size(75, 30);
            this.btnCust.TabIndex = 22;
            this.btnCust.Text = "ดึงลูกค้าทัหมด";
            this.btnCust.UseVisualStyleBackColor = true;
            this.btnCust.Click += new System.EventHandler(this.btnCust_Click);
            // 
            // txtCustRemark
            // 
            this.txtCustRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCustRemark.Location = new System.Drawing.Point(399, 67);
            this.txtCustRemark.Name = "txtCustRemark";
            this.txtCustRemark.Size = new System.Drawing.Size(568, 26);
            this.txtCustRemark.TabIndex = 21;
            this.txtCustRemark.Enter += new System.EventHandler(this.txtCustRemark_Enter);
            this.txtCustRemark.Leave += new System.EventHandler(this.txtCustRemark_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(315, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "หมายเหตุ :";
            // 
            // txtCustId
            // 
            this.txtCustId.Location = new System.Drawing.Point(1015, 67);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(100, 26);
            this.txtCustId.TabIndex = 19;
            // 
            // cboCust
            // 
            this.cboCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCust.FormattingEnabled = true;
            this.cboCust.Location = new System.Drawing.Point(399, 23);
            this.cboCust.Name = "cboCust";
            this.cboCust.Size = new System.Drawing.Size(568, 32);
            this.cboCust.TabIndex = 18;
            this.cboCust.SelectedIndexChanged += new System.EventHandler(this.cboCust_SelectedIndexChanged);
            this.cboCust.Enter += new System.EventHandler(this.cboCust_Enter);
            this.cboCust.Leave += new System.EventHandler(this.cboCust_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(315, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "ลูกค้า :";
            // 
            // dtpRecepDate
            // 
            this.dtpRecepDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpRecepDate.Location = new System.Drawing.Point(135, 62);
            this.dtpRecepDate.Name = "dtpRecepDate";
            this.dtpRecepDate.Size = new System.Drawing.Size(174, 26);
            this.dtpRecepDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "วันที่ออกใบเสร็จ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "เลขที่ใบเสร็จ :";
            // 
            // txtRecpNumber
            // 
            this.txtRecpNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRecpNumber.Location = new System.Drawing.Point(135, 25);
            this.txtRecpNumber.Name = "txtRecpNumber";
            this.txtRecpNumber.Size = new System.Drawing.Size(174, 29);
            this.txtRecpNumber.TabIndex = 0;
            // 
            // dgvAdd
            // 
            this.dgvAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdd.Location = new System.Drawing.Point(12, 323);
            this.dgvAdd.Name = "dgvAdd";
            this.dgvAdd.Size = new System.Drawing.Size(1138, 194);
            this.dgvAdd.TabIndex = 1;
            this.dgvAdd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdd_CellEndEdit);
            this.dgvAdd.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAdd_EditingControlShowing);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDeposit);
            this.groupBox2.Controls.Add(this.txtDepositId);
            this.groupBox2.Controls.Add(this.dgvDeposit);
            this.groupBox2.Controls.Add(this.txtDeposit);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtRecpId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtInvRemark);
            this.groupBox2.Controls.Add(this.txtInvId);
            this.groupBox2.Controls.Add(this.cboInv);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1152, 188);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ใบแจ้งหนี้";
            // 
            // chkDeposit
            // 
            this.chkDeposit.AutoSize = true;
            this.chkDeposit.Location = new System.Drawing.Point(135, 160);
            this.chkDeposit.Name = "chkDeposit";
            this.chkDeposit.Size = new System.Drawing.Size(111, 24);
            this.chkDeposit.TabIndex = 32;
            this.chkDeposit.Text = "ทอนเงินมัดจำ";
            this.chkDeposit.UseVisualStyleBackColor = true;
            // 
            // txtDepositId
            // 
            this.txtDepositId.Location = new System.Drawing.Point(1005, 54);
            this.txtDepositId.Name = "txtDepositId";
            this.txtDepositId.Size = new System.Drawing.Size(100, 26);
            this.txtDepositId.TabIndex = 31;
            // 
            // dgvDeposit
            // 
            this.dgvDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeposit.Location = new System.Drawing.Point(371, 99);
            this.dgvDeposit.Name = "dgvDeposit";
            this.dgvDeposit.Size = new System.Drawing.Size(761, 83);
            this.dgvDeposit.TabIndex = 30;
            // 
            // txtDeposit
            // 
            this.txtDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDeposit.Location = new System.Drawing.Point(134, 123);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(231, 31);
            this.txtDeposit.TabIndex = 29;
            this.txtDeposit.Enter += new System.EventHandler(this.txtDeposit_Enter);
            this.txtDeposit.Leave += new System.EventHandler(this.txtDeposit_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(13, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "เงินมัดจำ :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1041, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 24);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "unlock";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(13, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Invoice :";
            // 
            // txtRecpId
            // 
            this.txtRecpId.Location = new System.Drawing.Point(899, 54);
            this.txtRecpId.Name = "txtRecpId";
            this.txtRecpId.Size = new System.Drawing.Size(100, 26);
            this.txtRecpId.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(14, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "หมายเหตุ :";
            // 
            // txtInvRemark
            // 
            this.txtInvRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtInvRemark.Location = new System.Drawing.Point(135, 64);
            this.txtInvRemark.Name = "txtInvRemark";
            this.txtInvRemark.Size = new System.Drawing.Size(736, 29);
            this.txtInvRemark.TabIndex = 21;
            this.txtInvRemark.Enter += new System.EventHandler(this.txtInvRemark_Enter);
            this.txtInvRemark.Leave += new System.EventHandler(this.txtInvRemark_Leave);
            // 
            // txtInvId
            // 
            this.txtInvId.Location = new System.Drawing.Point(899, 22);
            this.txtInvId.Name = "txtInvId";
            this.txtInvId.Size = new System.Drawing.Size(100, 26);
            this.txtInvId.TabIndex = 20;
            // 
            // cboInv
            // 
            this.cboInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboInv.FormattingEnabled = true;
            this.cboInv.Location = new System.Drawing.Point(134, 25);
            this.cboInv.Name = "cboInv";
            this.cboInv.Size = new System.Drawing.Size(737, 33);
            this.cboInv.TabIndex = 0;
            this.cboInv.SelectedIndexChanged += new System.EventHandler(this.cboInv_SelectedIndexChanged);
            this.cboInv.Enter += new System.EventHandler(this.cboInv_Enter);
            this.cboInv.Leave += new System.EventHandler(this.cboInv_Leave);
            // 
            // txtReceipt
            // 
            this.txtReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtReceipt.Location = new System.Drawing.Point(779, 533);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.Size = new System.Drawing.Size(228, 35);
            this.txtReceipt.TabIndex = 24;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1041, 522);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 46);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkReceiptSome
            // 
            this.chkReceiptSome.AutoSize = true;
            this.chkReceiptSome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkReceiptSome.Location = new System.Drawing.Point(683, 538);
            this.chkReceiptSome.Name = "chkReceiptSome";
            this.chkReceiptSome.Size = new System.Drawing.Size(90, 24);
            this.chkReceiptSome.TabIndex = 12;
            this.chkReceiptSome.TabStop = true;
            this.chkReceiptSome.Text = "รับบางส่วน";
            this.chkReceiptSome.UseVisualStyleBackColor = true;
            this.chkReceiptSome.CheckedChanged += new System.EventHandler(this.chkReceiptSome_CheckedChanged);
            // 
            // chkReceiptAll
            // 
            this.chkReceiptAll.AutoSize = true;
            this.chkReceiptAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkReceiptAll.Location = new System.Drawing.Point(331, 538);
            this.chkReceiptAll.Name = "chkReceiptAll";
            this.chkReceiptAll.Size = new System.Drawing.Size(115, 24);
            this.chkReceiptAll.TabIndex = 11;
            this.chkReceiptAll.TabStop = true;
            this.chkReceiptAll.Text = "รับแต็มจำนวน ";
            this.chkReceiptAll.UseVisualStyleBackColor = true;
            this.chkReceiptAll.CheckedChanged += new System.EventHandler(this.chkReceiptAll_CheckedChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAmount.Location = new System.Drawing.Point(448, 533);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(228, 35);
            this.txtAmount.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUnActive);
            this.panel1.Controls.Add(this.chkUnActive);
            this.panel1.Controls.Add(this.chkActive);
            this.panel1.Location = new System.Drawing.Point(12, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 45);
            this.panel1.TabIndex = 25;
            // 
            // btnUnActive
            // 
            this.btnUnActive.Location = new System.Drawing.Point(203, 14);
            this.btnUnActive.Name = "btnUnActive";
            this.btnUnActive.Size = new System.Drawing.Size(103, 23);
            this.btnUnActive.TabIndex = 20;
            this.btnUnActive.Text = "ยกเลิกการใช้งาน";
            this.btnUnActive.UseVisualStyleBackColor = true;
            this.btnUnActive.Click += new System.EventHandler(this.btnUnActive_Click);
            // 
            // chkUnActive
            // 
            this.chkUnActive.AutoSize = true;
            this.chkUnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkUnActive.Location = new System.Drawing.Point(93, 14);
            this.chkUnActive.Name = "chkUnActive";
            this.chkUnActive.Size = new System.Drawing.Size(106, 24);
            this.chkUnActive.TabIndex = 1;
            this.chkUnActive.TabStop = true;
            this.chkUnActive.Text = "ยกเลิกใช้งาน";
            this.chkUnActive.UseVisualStyleBackColor = true;
            this.chkUnActive.Click += new System.EventHandler(this.chkUnActive_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkActive.Location = new System.Drawing.Point(6, 14);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(66, 24);
            this.chkActive.TabIndex = 0;
            this.chkActive.TabStop = true;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.Click += new System.EventHandler(this.chkActive_Click);
            // 
            // FrmRecpAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 576);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtReceipt);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.chkReceiptAll);
            this.Controls.Add(this.chkReceiptSome);
            this.Name = "FrmRecpAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRecpAdd";
            this.Load += new System.EventHandler(this.FrmRecpAdd_Load);
            this.Resize += new System.EventHandler(this.FrmRecpAdd_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpRecepDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecpNumber;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.ComboBox cboCust;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cboInv;
        private System.Windows.Forms.RadioButton chkReceiptSome;
        private System.Windows.Forms.RadioButton chkReceiptAll;
        private System.Windows.Forms.TextBox txtInvId;
        private System.Windows.Forms.TextBox txtInvRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.TextBox txtRecpId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCust;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDeposit;
        private System.Windows.Forms.TextBox txtDepositId;
        private System.Windows.Forms.CheckBox chkDeposit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton chkUnActive;
        private System.Windows.Forms.RadioButton chkActive;
        private System.Windows.Forms.Button btnUnActive;
    }
}