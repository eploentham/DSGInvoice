using DSGInvoice.objdb;
using DSGInvoice.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGInvoice.gui
{
    public partial class FrmInvView : Form
    {
        DsgControl dc;
        ConnectDB conn;
        Config1 config1;
        Invoice inv;
        InvoiceDB invdb;
        FrmInvAdd frmInvAdd;
        FrmReport frmReport;
        int colRow=0,colInvNumber = 1, colInvDate=2, colCustName=3, colInvAmount=4, colTermPay=5, colDueDate=6, colInvId=7, colRecpNumber=8, colCnt=9;
        private void initConfig()
        {
            dc = new DsgControl();
            conn = new ConnectDB();
            config1 = new Config1();
            inv = new Invoice();
            invdb = new InvoiceDB(conn);
            config1.setCboMonth(cboMonth);
            config1.setCboYearT(cboYear);
        }
        public FrmInvView()
        {
            InitializeComponent();
            initConfig();
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 50;
            dgvView.Height = this.Height - 150;
        }
        public void setData(String year, String monthName)
        {
            DataTable dt = new DataTable();
            if (chkUnActive.Checked)
            {
                dt = invdb.selectUnActiveByYearMonth(year, monthName);
            }
            else
            {
                dt = invdb.selectByYearMonth(year, monthName);
            }

            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colInvNumber].Width = 150;
            dgvView.Columns[colInvDate].Width = 120;
            dgvView.Columns[colCustName].Width = 300;
            dgvView.Columns[colInvAmount].Width = 120;
            dgvView.Columns[colTermPay].Width = 100;
            dgvView.Columns[colDueDate].Width = 120;
            dgvView.Columns[colInvId].Width = 80;
            dgvView.Columns[colRecpNumber].Width = 80;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colInvNumber].HeaderText = "ใบแจ้งหนี้";
            dgvView.Columns[colInvDate].HeaderText = "วันที่";
            dgvView.Columns[colCustName].HeaderText = "ลูกค้า";
            dgvView.Columns[colInvAmount].HeaderText = "จำนวนเงิน";
            dgvView.Columns[colTermPay].HeaderText = "due date";
            dgvView.Columns[colDueDate].HeaderText = "วันที่ชำระเงิน";
            dgvView.Columns[colInvId].HeaderText = "invid";
            dgvView.Columns[colRecpNumber].HeaderText = "ใบเสร็จรับเงิน";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colInvId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colInvNumber, i].Value = dt.Rows[i][invdb.inv.invNumber].ToString();
                    dgvView[colInvDate, i].Value = dc.config1.dateDBtoShow1(dt.Rows[i][invdb.inv.invDate].ToString());
                    dgvView[colCustName, i].Value = dt.Rows[i][invdb.inv.custName].ToString();
                    dgvView[colInvAmount, i].Value = dc.config1.NumberNull(dt.Rows[i][invdb.inv.invAmount]);
                    dgvView[colTermPay, i].Value = dt.Rows[i][invdb.inv.termPayment].ToString();
                    dgvView[colDueDate, i].Value = dc.config1.dateDBtoShow1(dt.Rows[i][invdb.inv.dueDate].ToString());
                    dgvView[colInvId, i].Value = dt.Rows[i][invdb.inv.invId].ToString();
                    dgvView[colRecpNumber, i].Value = dt.Rows[i][invdb.inv.receiptNumber].ToString();
                    
                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void showInvAdd(String invNumber)
        {

        }
        private void FrmMain_ResizeEnd(object sender, EventArgs e)
        {
            //setResize();
        }

        private void FrmInvView_Load(object sender, EventArgs e)
        {
            setData(cboYear.Text, config1.getMonthId(cboMonth.Text));
            setResize();
        }

        private void FrmInvView_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            setData(cboYear.Text, config1.getMonthId(cboMonth.Text));
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dgvView[colInvId, e.RowIndex].Value == null)
            {
                return;
            }
            //if (frmInvAdd == null)
            //{
                frmInvAdd = new FrmInvAdd();
            //}

                frmInvAdd.setData(dgvView[colInvId, e.RowIndex].Value.ToString());
                this.Hide();
                frmInvAdd.ShowDialog(this);
                setData(cboYear.Text, config1.getMonthId(cboMonth.Text));
                this.Show();
            
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem i = (ComboBoxItem)cboMonth.SelectedItem;
            setData(cboYear.Text, i.Value);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReport = new FrmReport();
             
            frmReport.reportName = "invView";
            String datestart = "", dateend = "";
            //DateTime endOfMonth = new DateTime(cboYear.Text, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            //datestart = cboYear.Text + "-" + config1.getMonthId(cboMonth.Text)+"-01";
            //dateend = config1.getEndDateofMonth(int.Parse(cboYear.Text)-543, int.Parse(config1.getMonthId(cboMonth.Text)));
            
            //rmgdb.setRMonthlyGroupId(datestart, dateend);
            frmReport.setRptInvView(cboYear.Text, config1.getMonthId(cboMonth.Text));
            frmReport.Show(this);
        }

        private void btnAddInv_Click(object sender, EventArgs e)
        {
            //if (frmInvAdd == null)
            //{
                frmInvAdd = new FrmInvAdd();
                frmInvAdd.setData("");
                frmInvAdd.ShowDialog(this);
                setData(cboYear.Text, config1.getMonthId(cboMonth.Text));
            //}
            //else
            //{
            //    frmInvAdd.setData("");
            //    frmInvAdd.Show();

            //}
            
        }

        private void chkUnActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkUnActive_Click(object sender, EventArgs e)
        {
            setData(cboYear.Text, config1.getMonthId(cboMonth.Text));
        }
    }
}
