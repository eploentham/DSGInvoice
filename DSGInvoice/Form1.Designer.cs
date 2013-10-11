namespace DSGInvoice
{
    partial class Form1
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
            this.btnImport = new System.Windows.Forms.Button();
            this.pgB = new System.Windows.Forms.ProgressBar();
            this.labelExcelFilename = new System.Windows.Forms.Label();
            this.labelSheetCount = new System.Windows.Forms.Label();
            this.oFD = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkDeleteData = new System.Windows.Forms.RadioButton();
            this.chkAppendData = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(136, 71);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(136, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "start Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pgB
            // 
            this.pgB.Location = new System.Drawing.Point(12, 281);
            this.pgB.Name = "pgB";
            this.pgB.Size = new System.Drawing.Size(388, 23);
            this.pgB.TabIndex = 1;
            // 
            // labelExcelFilename
            // 
            this.labelExcelFilename.AutoSize = true;
            this.labelExcelFilename.Location = new System.Drawing.Point(27, 108);
            this.labelExcelFilename.Name = "labelExcelFilename";
            this.labelExcelFilename.Size = new System.Drawing.Size(35, 13);
            this.labelExcelFilename.TabIndex = 2;
            this.labelExcelFilename.Text = "label1";
            // 
            // labelSheetCount
            // 
            this.labelSheetCount.AutoSize = true;
            this.labelSheetCount.Location = new System.Drawing.Point(30, 145);
            this.labelSheetCount.Name = "labelSheetCount";
            this.labelSheetCount.Size = new System.Drawing.Size(35, 13);
            this.labelSheetCount.TabIndex = 3;
            this.labelSheetCount.Text = "label2";
            // 
            // oFD
            // 
            this.oFD.FileName = "openFileDialog1";
            // 
            // btnOpenExcel
            // 
            this.btnOpenExcel.Location = new System.Drawing.Point(136, 30);
            this.btnOpenExcel.Name = "btnOpenExcel";
            this.btnOpenExcel.Size = new System.Drawing.Size(136, 23);
            this.btnOpenExcel.TabIndex = 4;
            this.btnOpenExcel.Text = "open Excel File";
            this.btnOpenExcel.UseVisualStyleBackColor = true;
            this.btnOpenExcel.Click += new System.EventHandler(this.btnOpenExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(30, 220);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(35, 13);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "invoice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(444, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Customer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkDeleteData
            // 
            this.chkDeleteData.AutoSize = true;
            this.chkDeleteData.Location = new System.Drawing.Point(325, 30);
            this.chkDeleteData.Name = "chkDeleteData";
            this.chkDeleteData.Size = new System.Drawing.Size(91, 17);
            this.chkDeleteData.TabIndex = 9;
            this.chkDeleteData.TabStop = true;
            this.chkDeleteData.Text = "delete all data";
            this.chkDeleteData.UseVisualStyleBackColor = true;
            // 
            // chkAppendData
            // 
            this.chkAppendData.AutoSize = true;
            this.chkAppendData.Location = new System.Drawing.Point(444, 30);
            this.chkAppendData.Name = "chkAppendData";
            this.chkAppendData.Size = new System.Drawing.Size(85, 17);
            this.chkAppendData.TabIndex = 10;
            this.chkAppendData.TabStop = true;
            this.chkAppendData.Text = "append data";
            this.chkAppendData.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 342);
            this.Controls.Add(this.chkAppendData);
            this.Controls.Add(this.chkDeleteData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenExcel);
            this.Controls.Add(this.labelSheetCount);
            this.Controls.Add(this.labelExcelFilename);
            this.Controls.Add(this.pgB);
            this.Controls.Add(this.btnImport);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ProgressBar pgB;
        private System.Windows.Forms.Label labelExcelFilename;
        private System.Windows.Forms.Label labelSheetCount;
        private System.Windows.Forms.OpenFileDialog oFD;
        private System.Windows.Forms.Button btnOpenExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton chkDeleteData;
        private System.Windows.Forms.RadioButton chkAppendData;
    }
}

