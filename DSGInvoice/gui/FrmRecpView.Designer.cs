namespace DSGInvoice.gui
{
    partial class FrmRecpView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkReceipt = new System.Windows.Forms.RadioButton();
            this.chkPaymented = new System.Windows.Forms.RadioButton();
            this.chkUnPayment = new System.Windows.Forms.RadioButton();
            this.btnAddRecp = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chkReceipt);
            this.panel1.Controls.Add(this.chkPaymented);
            this.panel1.Controls.Add(this.chkUnPayment);
            this.panel1.Controls.Add(this.btnAddRecp);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 78);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboYear);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboMonth);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(3, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 55);
            this.panel2.TabIndex = 15;
            // 
            // cboYear
            // 
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(47, 14);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(84, 28);
            this.cboYear.TabIndex = 5;
            this.cboYear.Click += new System.EventHandler(this.cboYear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ปี :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(146, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "เดือน :";
            // 
            // cboMonth
            // 
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(201, 14);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 28);
            this.cboMonth.TabIndex = 8;
            this.cboMonth.Click += new System.EventHandler(this.cboMonth_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(328, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(53, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkReceipt
            // 
            this.chkReceipt.AutoSize = true;
            this.chkReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkReceipt.Location = new System.Drawing.Point(633, 28);
            this.chkReceipt.Name = "chkReceipt";
            this.chkReceipt.Size = new System.Drawing.Size(72, 24);
            this.chkReceipt.TabIndex = 14;
            this.chkReceipt.TabStop = true;
            this.chkReceipt.Text = "ใบเสร็จ";
            this.chkReceipt.UseVisualStyleBackColor = true;
            this.chkReceipt.Click += new System.EventHandler(this.chkReceipt_Click);
            // 
            // chkPaymented
            // 
            this.chkPaymented.AutoSize = true;
            this.chkPaymented.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkPaymented.Location = new System.Drawing.Point(526, 28);
            this.chkPaymented.Name = "chkPaymented";
            this.chkPaymented.Size = new System.Drawing.Size(97, 24);
            this.chkPaymented.TabIndex = 13;
            this.chkPaymented.TabStop = true;
            this.chkPaymented.Text = "รับชำระแล้ว";
            this.chkPaymented.UseVisualStyleBackColor = true;
            this.chkPaymented.CheckedChanged += new System.EventHandler(this.chkPaymented_CheckedChanged);
            this.chkPaymented.Click += new System.EventHandler(this.chkPaymented_Click);
            // 
            // chkUnPayment
            // 
            this.chkUnPayment.AutoSize = true;
            this.chkUnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkUnPayment.Location = new System.Drawing.Point(440, 28);
            this.chkUnPayment.Name = "chkUnPayment";
            this.chkUnPayment.Size = new System.Drawing.Size(80, 24);
            this.chkUnPayment.TabIndex = 12;
            this.chkUnPayment.TabStop = true;
            this.chkUnPayment.Text = "ค้างชำระ";
            this.chkUnPayment.UseVisualStyleBackColor = true;
            this.chkUnPayment.CheckedChanged += new System.EventHandler(this.chkUnPayment_CheckedChanged);
            this.chkUnPayment.Click += new System.EventHandler(this.chkUnPayment_Click);
            // 
            // btnAddRecp
            // 
            this.btnAddRecp.Location = new System.Drawing.Point(954, 18);
            this.btnAddRecp.Name = "btnAddRecp";
            this.btnAddRecp.Size = new System.Drawing.Size(122, 40);
            this.btnAddRecp.TabIndex = 11;
            this.btnAddRecp.Text = "ออก ใบเสร็จรับเงิน";
            this.btnAddRecp.UseVisualStyleBackColor = true;
            this.btnAddRecp.Click += new System.EventHandler(this.btnAddRecp_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(860, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 40);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvView
            // 
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(13, 97);
            this.dgvView.Name = "dgvView";
            this.dgvView.Size = new System.Drawing.Size(806, 369);
            this.dgvView.TabIndex = 1;
            this.dgvView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvView_CellDoubleClick);
            // 
            // FrmRecpView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 478);
            this.Controls.Add(this.dgvView);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRecpView";
            this.Text = "FrmRecpView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRecpView_Load);
            this.Resize += new System.EventHandler(this.FrmRecpView_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Button btnAddRecp;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.RadioButton chkPaymented;
        private System.Windows.Forms.RadioButton chkUnPayment;
        private System.Windows.Forms.RadioButton chkReceipt;
        private System.Windows.Forms.Panel panel2;
    }
}