namespace DSGInvoice.gui
{
    partial class FrmDepositAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUnActive = new System.Windows.Forms.Button();
            this.chkUnActive = new System.Windows.Forms.RadioButton();
            this.chkActive = new System.Windows.Forms.RadioButton();
            this.txtDepositId = new System.Windows.Forms.TextBox();
            this.dtpDepositDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustRemark = new System.Windows.Forms.TextBox();
            this.txtInvId = new System.Windows.Forms.TextBox();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboInv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCust = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ลูกค้า :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUnActive);
            this.groupBox1.Controls.Add(this.chkUnActive);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.txtDepositId);
            this.groupBox1.Controls.Add(this.dtpDepositDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCustRemark);
            this.groupBox1.Controls.Add(this.txtInvId);
            this.groupBox1.Controls.Add(this.txtCustId);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDeposit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboInv);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboCust);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 340);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnUnActive
            // 
            this.btnUnActive.Location = new System.Drawing.Point(581, 295);
            this.btnUnActive.Name = "btnUnActive";
            this.btnUnActive.Size = new System.Drawing.Size(106, 23);
            this.btnUnActive.TabIndex = 19;
            this.btnUnActive.Text = "ยกเลิกการใช้งาน";
            this.btnUnActive.UseVisualStyleBackColor = true;
            this.btnUnActive.Click += new System.EventHandler(this.btnUnActive_Click);
            // 
            // chkUnActive
            // 
            this.chkUnActive.AutoSize = true;
            this.chkUnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkUnActive.Location = new System.Drawing.Point(441, 295);
            this.chkUnActive.Name = "chkUnActive";
            this.chkUnActive.Size = new System.Drawing.Size(106, 24);
            this.chkUnActive.TabIndex = 18;
            this.chkUnActive.TabStop = true;
            this.chkUnActive.Text = "ยกเลิกใช้งาน";
            this.chkUnActive.UseVisualStyleBackColor = true;
            this.chkUnActive.CheckedChanged += new System.EventHandler(this.chkUnActive_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkActive.Location = new System.Drawing.Point(211, 295);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(66, 24);
            this.chkActive.TabIndex = 17;
            this.chkActive.TabStop = true;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // txtDepositId
            // 
            this.txtDepositId.Location = new System.Drawing.Point(654, 163);
            this.txtDepositId.Name = "txtDepositId";
            this.txtDepositId.Size = new System.Drawing.Size(100, 20);
            this.txtDepositId.TabIndex = 16;
            this.txtDepositId.Visible = false;
            // 
            // dtpDepositDate
            // 
            this.dtpDepositDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpDepositDate.Location = new System.Drawing.Point(184, 156);
            this.dtpDepositDate.Name = "dtpDepositDate";
            this.dtpDepositDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDepositDate.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(17, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "วันที่รับเงินมัดจำ :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(18, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "หมายเหตุ :";
            // 
            // txtCustRemark
            // 
            this.txtCustRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCustRemark.Location = new System.Drawing.Point(184, 71);
            this.txtCustRemark.Name = "txtCustRemark";
            this.txtCustRemark.Size = new System.Drawing.Size(674, 26);
            this.txtCustRemark.TabIndex = 12;
            this.txtCustRemark.Enter += new System.EventHandler(this.txtCustRemark_Enter);
            this.txtCustRemark.Leave += new System.EventHandler(this.txtCustRemark_Leave);
            // 
            // txtInvId
            // 
            this.txtInvId.Location = new System.Drawing.Point(532, 189);
            this.txtInvId.Name = "txtInvId";
            this.txtInvId.Size = new System.Drawing.Size(100, 20);
            this.txtInvId.TabIndex = 11;
            this.txtInvId.Visible = false;
            // 
            // txtCustId
            // 
            this.txtCustId.Location = new System.Drawing.Point(532, 162);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(100, 20);
            this.txtCustId.TabIndex = 10;
            this.txtCustId.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(6, 280);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(121, 47);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "พิมพ์ใบรับเงินมัดจำ";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(737, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 47);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDescription.Location = new System.Drawing.Point(184, 228);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(674, 26);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            this.txtDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyUp);
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(18, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "รายละเอียด :";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDeposit.Location = new System.Drawing.Point(184, 191);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(234, 31);
            this.txtDeposit.TabIndex = 5;
            this.txtDeposit.TextChanged += new System.EventHandler(this.txtDeposit_TextChanged);
            this.txtDeposit.Enter += new System.EventHandler(this.txtDeposit_Enter);
            this.txtDeposit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeposit_KeyPress);
            this.txtDeposit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDeposit_KeyUp);
            this.txtDeposit.Leave += new System.EventHandler(this.txtDeposit_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(17, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "เงินมัดจำ :";
            // 
            // cboInv
            // 
            this.cboInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboInv.FormattingEnabled = true;
            this.cboInv.Location = new System.Drawing.Point(184, 114);
            this.cboInv.Name = "cboInv";
            this.cboInv.Size = new System.Drawing.Size(674, 32);
            this.cboInv.TabIndex = 3;
            this.cboInv.SelectedIndexChanged += new System.EventHandler(this.cboInv_SelectedIndexChanged);
            this.cboInv.Enter += new System.EventHandler(this.cboInv_Enter);
            this.cboInv.Leave += new System.EventHandler(this.cboInv_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(18, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "เลขที่ใบแจ้งหนี้ :";
            // 
            // cboCust
            // 
            this.cboCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCust.FormattingEnabled = true;
            this.cboCust.Location = new System.Drawing.Point(184, 33);
            this.cboCust.Name = "cboCust";
            this.cboCust.Size = new System.Drawing.Size(674, 32);
            this.cboCust.TabIndex = 1;
            this.cboCust.SelectedIndexChanged += new System.EventHandler(this.cboCust_SelectedIndexChanged);
            this.cboCust.Enter += new System.EventHandler(this.cboCust_Enter);
            this.cboCust.Leave += new System.EventHandler(this.cboCust_Leave);
            // 
            // FrmDepositAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 364);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDepositAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDeposit";
            this.Load += new System.EventHandler(this.FrmDepositAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboInv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCust;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtInvId;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustRemark;
        private System.Windows.Forms.DateTimePicker dtpDepositDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDepositId;
        private System.Windows.Forms.RadioButton chkUnActive;
        private System.Windows.Forms.RadioButton chkActive;
        private System.Windows.Forms.Button btnUnActive;
    }
}