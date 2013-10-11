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
    public partial class FrmCustView : Form
    {
        ConnectDB conn;
        Config1 config1;
        CustomerDB custdb;
        Customer cust;
        public FrmCustView()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            conn = new ConnectDB();
            config1 = new Config1();
            cust = new Customer();
            custdb = new CustomerDB(conn);
            //custdb.getCboCustomer(cboCust);
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 50;
            dgvView.Height = this.Height - 150;
        }
        public void setData(String search)
        {
            DataTable dt = new DataTable();
            dt = custdb.selectCustAll(search);
            dgvView.Visible = false;
            
            dgvView.ColumnCount = 8;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[0].Width = 40;
            dgvView.Columns[1].Width = 400;
            dgvView.Columns[2].Width = 300;
            dgvView.Columns[3].Width = 300;
            dgvView.Columns[4].Width = 200;
            dgvView.Columns[5].Width = 100;
            dgvView.Columns[6].Width = 100;
            dgvView.Columns[7].Width = 80;
            dgvView.Columns[0].HeaderText = "ลำดับ";
            dgvView.Columns[1].HeaderText = "ลูกค้า";
            dgvView.Columns[2].HeaderText = "ที่อยู่1";
            dgvView.Columns[3].HeaderText = "ที่อยู่2";
            dgvView.Columns[4].HeaderText = "โทรศัพท์";
            dgvView.Columns[5].HeaderText = "รายละเอียด";
            dgvView.Columns[6].HeaderText = "หมายเหตุ";
            dgvView.Columns[7].HeaderText = "custId";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            //dgvView.columns

            dgvView.Columns[7].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[0, i].Value = (i + 1);
                    dgvView[1, i].Value = dt.Rows[i][custdb.cust.custName].ToString();
                    dgvView[2, i].Value = dt.Rows[i][custdb.cust.custAddress1].ToString();
                    dgvView[3, i].Value = dt.Rows[i][custdb.cust.custAddress2].ToString();
                    dgvView[4, i].Value = dt.Rows[i][custdb.cust.telephone].ToString();
                    dgvView[5, i].Value = dt.Rows[i][custdb.cust.description].ToString();
                    dgvView[6, i].Value = dt.Rows[i][custdb.cust.remark].ToString();
                    dgvView[7, i].Value = dt.Rows[i][custdb.cust.custId].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            dgvView.Visible = true;
        }

        private void FrmCustView_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.RowIndex > 0)
            {
                FrmCustAdd frm = new FrmCustAdd();
                frm.setData(dgvView[7, e.RowIndex].Value.ToString());
                frm.Show(this);
            }
            
        }

        private void btnCustAdd_Click(object sender, EventArgs e)
        {
            FrmCustAdd frm = new FrmCustAdd();
            //frm.setData(dgvView[7, e.RowIndex].Value.ToString());
            frm.Show(this);
        }

        private void FrmCustView_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            setData(txtSearch.Text);
        }
    }
}
