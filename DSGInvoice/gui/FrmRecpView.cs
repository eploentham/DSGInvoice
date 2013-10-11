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
    public partial class FrmRecpView : Form
    {
        ConnectDB conn;
        Config1 config1;
        Recript recp;
        RecriptDB recpdb;
        FrmRecpAdd frmRecpAdd;
        DsgControl dc;
        int colInvUnPayRow = 0, colInvUnpayRecpNumber = 1, colInvUnPayRecpDate = 4, colInvUnPayCustName = 3;
        int colInvUnPayAmount = 7, colInvUnPayRecpId=5, colInvUnPayInvId=6;
        int colInvUnPayInvNumber = 2, colInvUnPayRecpAmount=8, colInvUnPayDeposit=9, colInvUnPayNetTotal=10, colInvUnPayCnt=11;
        int colPayRow = 0, colPayRecpNumber = 1, colPayRecpdate = 2, colPayCustName = 3, colPayAmount = 4, colPayRecpid = 5, colPayInvId = 6, colPayInvNumber = 7;

        int colRecpRow = 0, colRecpNumber = 1, colRecpDate = 2, colRecpCustName = 3, colRecpAmount = 4, colRecpId = 5, colRecpInvNumber=6, colRecpCnt = 7;

        public FrmRecpView()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            dc = new DsgControl();
            conn = new ConnectDB();
            config1 = new Config1();
            recpdb = new RecriptDB(conn);
            //frmRecpAdd = new FrmRecpAdd();
            config1.setCboMonth(cboMonth);
            config1.setCboYearT(cboYear);
            chkUnPayment.Checked = true;
            setDgvView();
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 50;
            dgvView.Height = this.Height - 150;
        }
        public void setDataReceipt(String year, String monthName)
        {
            DataTable dt = new DataTable();
            //Double amount = 0;
            dt = recpdb.selectByYearMonth(year, monthName);
            dgvView.ColumnCount = colRecpCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRecpRow].Width = 50;
            dgvView.Columns[colRecpNumber].Width = 150;
            dgvView.Columns[colRecpDate].Width = 120;
            dgvView.Columns[colRecpCustName].Width = 400;
            dgvView.Columns[colRecpAmount].Width = 120;
            dgvView.Columns[colRecpId].Width = 100;
            dgvView.Columns[colRecpInvNumber].Width = 150;

            dgvView.Columns[colRecpRow].HeaderText = "ลำดับ";
            dgvView.Columns[colRecpNumber].HeaderText = "ใบเสร็จรับเงิน";
            dgvView.Columns[colRecpDate].HeaderText = "วันที่";
            dgvView.Columns[colRecpCustName].HeaderText = "ลูกค้า";
            dgvView.Columns[colRecpAmount].HeaderText = "จำนวนเงิน";
            dgvView.Columns[colRecpId].HeaderText = "recpid";
            dgvView.Columns[colRecpInvNumber].HeaderText = "ใบแจ้งหนี้";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colRecpInvNumber].Visible = true;
            dgvView.Columns[colInvUnPayRecpId].Visible = false;
            //dgvView.Columns[7].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //amount = Double.Parse(dt.Rows[i][recpdb.recp.recpAmount].ToString());
                    dgvView[colRecpRow, i].Value = (i + 1);
                    dgvView[colRecpNumber, i].Value = dt.Rows[i][recpdb.recp.recpNumber].ToString();
                    dgvView[colRecpDate, i].Value = config1.dateDBtoShow1(dt.Rows[i][recpdb.recp.recpDate].ToString());
                    dgvView[colRecpCustName, i].Value = dt.Rows[i][recpdb.recp.custName].ToString();
                    dgvView[colRecpAmount, i].Value = String.Format(config1.formatNumber, dt.Rows[i][recpdb.recp.recpAmount]);
                    dgvView[colRecpId, i].Value = dt.Rows[i][recpdb.recp.recpId].ToString();
                    dgvView[colRecpInvNumber, i].Value = dt.Rows[i][recpdb.recp.invNumber].ToString();
                    //dgvView[7, i].Value = dt.Rows[i][invdb.inv.invId].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }
        public void setDataUnPayment()
        {
            String recpNumber = "", deposit="",sql="";
            DataTable dt = new DataTable();
            //Double amount = 0;
            dt = dc.invdb.selectUnPayment();
            dgvView.ColumnCount = colInvUnPayCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colInvUnPayRow].Width = 50;
            dgvView.Columns[colInvUnpayRecpNumber].Width = 150;
            dgvView.Columns[colInvUnPayRecpDate].Width = 120;
            dgvView.Columns[colInvUnPayCustName].Width = 300;
            dgvView.Columns[colInvUnPayAmount].Width = 120;
            dgvView.Columns[colInvUnPayRecpId].Width = 100;
            dgvView.Columns[colInvUnPayInvNumber].Width = 150;
            dgvView.Columns[colInvUnPayRecpAmount].Width = 150;
            dgvView.Columns[colInvUnPayNetTotal].Width = 150;
            dgvView.Columns[colInvUnPayDeposit].Width = 95;

            dgvView.Columns[colInvUnPayRow].HeaderText = "ลำดับ";
            dgvView.Columns[colInvUnpayRecpNumber].HeaderText = "ใบเสร็จรับเงิน";
            dgvView.Columns[colInvUnPayRecpDate].HeaderText = "วันที่";
            dgvView.Columns[colInvUnPayCustName].HeaderText = "ลูกค้า";
            dgvView.Columns[colInvUnPayAmount].HeaderText = "จำนวนเงิน";
            dgvView.Columns[colInvUnPayRecpId].HeaderText = "recpid";
            dgvView.Columns[colInvUnPayInvId].HeaderText = "invid";
            dgvView.Columns[colInvUnPayInvNumber].HeaderText = "invoice number";
            dgvView.Columns[colInvUnPayRecpAmount].HeaderText = "รับชำระ";
            dgvView.Columns[colInvUnPayDeposit].HeaderText = "เงินมัดจำ";
            dgvView.Columns[colInvUnPayNetTotal].HeaderText = "คงเหลือ";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            //dgvView.Columns[7].Visible = false;
            dgvView.Columns[colInvUnPayInvId].Visible = false;
            dgvView.Columns[colInvUnPayRecpId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    recpNumber = dt.Rows[i][dc.invdb.inv.receiptNumber].ToString();
                    recpNumber = recpNumber.Replace("[", "");
                    recpNumber = recpNumber.Replace("]", "");
                    recpNumber = recpNumber.Replace(";", "");
                    dgvView[colInvUnPayRow, i].Value = (i + 1);
                    dgvView[colInvUnpayRecpNumber, i].Value = recpNumber;
                    dgvView[colInvUnPayRecpDate, i].Value = config1.dateDBtoShow1(dt.Rows[i][dc.invdb.inv.invDate].ToString());
                    dgvView[colInvUnPayCustName, i].Value = dt.Rows[i][dc.invdb.inv.custName].ToString();
                    dgvView[colInvUnPayAmount, i].Value = dc.config1.NumberNull(dt.Rows[i][dc.invdb.inv.invAmount]);
                    dgvView[colInvUnPayRecpId, i].Value = "";
                    dgvView[colInvUnPayInvId, i].Value = dt.Rows[i][dc.invdb.inv.invId].ToString();
                    dgvView[colInvUnPayInvNumber, i].Value = dt.Rows[i][dc.invdb.inv.invNumber].ToString();
                    dgvView[colInvUnPayRecpAmount, i].Value = dc.config1.NumberNull(dt.Rows[i][dc.invdb.inv.recpAmount]);
                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(254,186,75);
                    }
                    else
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(248, 84, 180);
                    }
                    if (dt.Rows[i][dc.invdb.inv.invId].ToString().Equals("579986984"))
                    {
                        sql = "";
                    }
                    deposit = dc.config1.NumberNull(dt.Rows[i][dc.invdb.inv.deposit].ToString());
                    dgvView[colInvUnPayDeposit, i].Value = dc.config1.NumberNull(deposit);
                    dgvView[colInvUnPayNetTotal, i].Value = dc.config1.NumberNull(Double.Parse(dt.Rows[i][dc.invdb.inv.invAmount].ToString()) - (Double.Parse(dt.Rows[i][dc.invdb.inv.recpAmount].ToString()) + Double.Parse(deposit)));
                }
            }
        }
        public void setDataPaymented(String year, String monthName)
        {
            String recpNumber = "";
            DataTable dt = new DataTable();
            //Double amount = 0;
            dt = dc.invdb.selectPaymentedByYearMonth(year, monthName);
            dgvView.ColumnCount = 8;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colPayRow].Width = 50;
            dgvView.Columns[colPayRecpNumber].Width = 150;
            dgvView.Columns[colPayRecpdate].Width = 120;
            dgvView.Columns[colPayCustName].Width = 300;
            dgvView.Columns[colPayAmount].Width = 120;
            dgvView.Columns[colPayRecpid].Width = 100;
            dgvView.Columns[colInvUnPayInvNumber].Width = 150;

            dgvView.Columns[colPayRow].HeaderText = "ลำดับ";
            dgvView.Columns[colPayRecpNumber].HeaderText = "ใบเสร็จรับเงิน";
            dgvView.Columns[colPayRecpdate].HeaderText = "วันที่";
            dgvView.Columns[colPayCustName].HeaderText = "ลูกค้า";
            dgvView.Columns[colPayAmount].HeaderText = "จำนวนเงิน";
            dgvView.Columns[colPayRecpid].HeaderText = "recpid";
            dgvView.Columns[colPayInvId].HeaderText = "invid";
            dgvView.Columns[colPayInvNumber].HeaderText = "invoice number";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            //dgvView.Columns[7].Visible = false;
            dgvView.Columns[colInvUnPayInvId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    recpNumber = dt.Rows[i][dc.invdb.inv.receiptNumber].ToString();
                    recpNumber = recpNumber.Replace("[", "");
                    recpNumber = recpNumber.Replace("]", "");
                    recpNumber = recpNumber.Replace(";", "");
                    dgvView[colPayRow, i].Value = (i + 1);
                    dgvView[colPayRecpNumber, i].Value = recpNumber;
                    dgvView[colPayRecpdate, i].Value = config1.dateDBtoShow1(dt.Rows[i][dc.invdb.inv.invDate].ToString());
                    dgvView[colPayCustName, i].Value = dt.Rows[i][dc.invdb.inv.custName].ToString();
                    dgvView[colPayAmount, i].Value = String.Format(config1.formatNumber, dt.Rows[i][dc.invdb.inv.invAmount]);
                    dgvView[colPayRecpid, i].Value = "";
                    dgvView[colPayInvId, i].Value = dt.Rows[i][dc.invdb.inv.invId].ToString();
                    dgvView[colPayInvNumber, i].Value = dt.Rows[i][dc.invdb.inv.invNumber].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(11, 178, 134);
                    }
                    else
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(2, 162, 23);
                    }
                }
            }
        }
        private void setDgvView()
        {
            if (chkUnPayment.Checked)
            {
                panel2.Visible = false;
                setDataUnPayment();
            }
            else if (chkPaymented.Checked)
            {
                panel2.Visible = true;
                setDataPaymented(cboYear.Text, config1.getMonthId(cboMonth.Text));
            }
            else if (chkReceipt.Checked)
            {
                panel2.Visible = true;
                setDataReceipt(cboYear.Text, config1.getMonthId(cboMonth.Text));
            }
        }
        private void FrmRecpView_Load(object sender, EventArgs e)
        {
            //chkPaymented.Checked = true;
            //setDataReceipt(cboYear.Text, config1.getMonthId(cboMonth.Text));
            setResize();
        }

        private void FrmRecpView_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //setDataReceipt(cboYear.Text, config1.getMonthId(cboMonth.Text));
            setDgvView();
        }

        private void btnAddRecp_Click(object sender, EventArgs e)
        {
            frmRecpAdd = new FrmRecpAdd();
            //frmRecpAdd.setData("");
            frmRecpAdd.ShowDialog(this);
            setDgvView();
        }


        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            //if (frmRecpAdd == null)
            //{
            frmRecpAdd = new FrmRecpAdd();
            //}
            
            if (chkPaymented.Checked)
            {
                if (dgvView[colPayInvId, e.RowIndex].Value == null)
                {
                    return;
                }
                frmRecpAdd.flagShow = "paymented";
                frmRecpAdd.setDataPayment(dgvView[colPayInvId, e.RowIndex].Value.ToString());
            }
            else
            {
                if (chkUnPayment.Checked)
                {
                    if (dgvView[colInvUnPayInvId, e.RowIndex].Value == null)
                    {
                        return;
                    }
                    frmRecpAdd.flagShow = "unpayment";
                    frmRecpAdd.setDataInvoiceFromRecpView(dgvView[colInvUnPayInvId, e.RowIndex].Value.ToString());
                }
                else
                {
                    if (dgvView[colInvUnPayRecpId, e.RowIndex].Value == null)
                    {
                        return;
                    }
                    frmRecpAdd.flagShow = "receipt";
                    frmRecpAdd.setDataReceipt(dgvView[colInvUnPayRecpId, e.RowIndex].Value.ToString());
                }
            }
            //this.Hide();
            frmRecpAdd.ShowDialog(this);
            //setDataReceipt(cboYear.Text, config1.getMonthId(cboMonth.Text));
            setDgvView();
            this.Show();
        }

        private void chkUnPayment_Click(object sender, EventArgs e)
        {
            setDgvView();
        }

        private void chkPaymented_Click(object sender, EventArgs e)
        {
            setDgvView();
        }

        private void chkReceipt_Click(object sender, EventArgs e)
        {
            setDgvView();
        }

        private void chkPaymented_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboMonth_Click(object sender, EventArgs e)
        {
            setDgvView();
        }

        private void cboYear_Click(object sender, EventArgs e)
        {
            setDgvView();
        }

        private void chkUnPayment_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
