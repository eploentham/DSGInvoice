namespace DSGInvoice.gui
{
    partial class FrmMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ใบแจ้งหนี้");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ใบรับเงินมัดจำ");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ใบเสร็จรับเงิน");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("รายงานลูกหนี้ ประจำวัน");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("รายงานสรุปลูกหนี้ แยกตามลูกหนี้");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("รายงานยอดค้างชำระ");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Account", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("รายชื่อลูกค้า");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Convert Data");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("กำหนดค่าเริ่มต้นโปรแกรม");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("ตั้งค่า", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            this.tv1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tv1
            // 
            this.tv1.BackColor = System.Drawing.SystemColors.Window;
            this.tv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tv1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tv1.ItemHeight = 40;
            this.tv1.Location = new System.Drawing.Point(12, 12);
            this.tv1.Name = "tv1";
            treeNode1.Name = "nInvoice";
            treeNode1.Text = "ใบแจ้งหนี้";
            treeNode2.Name = "nDeposit";
            treeNode2.Text = "ใบรับเงินมัดจำ";
            treeNode3.Name = "nReceipt";
            treeNode3.Text = "ใบเสร็จรับเงิน";
            treeNode4.Name = "nDailyInvoice";
            treeNode4.Text = "รายงานลูกหนี้ ประจำวัน";
            treeNode5.Name = "Node1";
            treeNode5.Text = "รายงานสรุปลูกหนี้ แยกตามลูกหนี้";
            treeNode6.Name = "nUnPayment";
            treeNode6.Text = "รายงานยอดค้างชำระ";
            treeNode7.Name = "nAccount";
            treeNode7.Text = "Account";
            treeNode8.Name = "nCustomer";
            treeNode8.Text = "รายชื่อลูกค้า";
            treeNode9.Name = "nConvert";
            treeNode9.Text = "Convert Data";
            treeNode10.Name = "nInitConfig";
            treeNode10.Text = "กำหนดค่าเริ่มต้นโปรแกรม";
            treeNode11.Name = "nInitial";
            treeNode11.Text = "ตั้งค่า";
            this.tv1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode11});
            this.tv1.Size = new System.Drawing.Size(539, 432);
            this.tv1.TabIndex = 6;
            this.tv1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv1_NodeMouseDoubleClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 456);
            this.Controls.Add(this.tv1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv1;
    }
}