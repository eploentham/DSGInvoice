using DSGInvoice.objdb;
using DSGInvoice.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSGInvoice.gui
{
    public partial class FrmDepositView : Form
    {
        DsgControl dc;
        ConnectDB conn;
        int colRow = 0, colDepositDate = 1, colDescription = 2, colCustName = 3, colInvNumber = 4, colDepositId=5, colDeposit=6, colRecpNumber=7, colCnt=8;
        public FrmDepositView()
        {
            InitializeComponent();
            initConfig();
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 50;
            dgvView.Height = this.Height - 150;
        }
        private void initConfig()
        {
            dc = new DsgControl();
            conn = new ConnectDB();

        }
        public void setData()
        {
            DataTable dt = new DataTable();
            if (chkUnActive.Checked)
            {
                dt = dc.depdb.selectUnActiveAll();
            }
            else
            {
                dt = dc.depdb.selectAll();
            }
            
            dgvView.ColumnCount = colCnt;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colDepositDate].Width = 150;
            dgvView.Columns[colDescription].Width = 300;
            dgvView.Columns[colCustName].Width = 300;
            dgvView.Columns[colInvNumber].Width = 150;
            dgvView.Columns[colDepositId].Width = 150;
            dgvView.Columns[colDeposit].Width = 150;
            dgvView.Columns[colRecpNumber].Width = 120;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colDepositDate].HeaderText = "วันที่";
            dgvView.Columns[colDescription].HeaderText = "รายละเอียด";
            dgvView.Columns[colCustName].HeaderText = "ลูกค้า";
            dgvView.Columns[colInvNumber].HeaderText = "ใบแจ้งหนี้";
            dgvView.Columns[colDepositId].HeaderText = "depositid";
            dgvView.Columns[colDeposit].HeaderText = "ยอดเงินมัดจำ";
            dgvView.Columns[colRecpNumber].HeaderText = "ใบเสร็จรับเงิน";

            dgvView.Columns[colDepositId].Visible = false;
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            if (dt.Rows.Count > 0)
            {
                dgvView.RowCount = dt.Rows.Count;
            }
            else
            {
                dgvView.RowCount = 1;
            }
            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colDepositDate, i].Value = dc.config1.dateDBtoShow1(dt.Rows[i][dc.depdb.dep.depositDate].ToString());
                    dgvView[colDescription, i].Value = dt.Rows[i][dc.depdb.dep.description].ToString();
                    dgvView[colCustName, i].Value = dt.Rows[i][dc.depdb.dep.custName].ToString();
                    dgvView[colInvNumber, i].Value = dt.Rows[i][dc.depdb.dep.invNumber].ToString();
                    dgvView[colDepositId, i].Value = dt.Rows[i][dc.depdb.dep.depositId].ToString();
                    dgvView[colDeposit, i].Value = dc.config1.NumberNull(dt.Rows[i][dc.depdb.dep.deposit]);
                    if (dt.Rows[i][dc.depdb.dep.statusDeposit].ToString().Equals("2"))
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                    }
                    else
                    {
                        if ((i % 2) != 0)
                        {
                            dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
                    
                }
            }
        }

        private void FrmDepositView_Load(object sender, EventArgs e)
        {
            setData();
            setResize();
        }

        private void FrmDepositView_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            FrmDepositAdd frm = new FrmDepositAdd();
            frm.ShowDialog(this);
            setData();
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dgvView[colDepositId, e.RowIndex].Value == null)
            {
                return;
            }
            FrmDepositAdd frmDepositAdd = new FrmDepositAdd();
            frmDepositAdd.setData(dgvView[colDepositId, e.RowIndex].Value.ToString());
            frmDepositAdd.ShowDialog(this);
            setData();
        }

        private void chkUnActive_Click(object sender, EventArgs e)
        {
            setData();
        }
    }
}
