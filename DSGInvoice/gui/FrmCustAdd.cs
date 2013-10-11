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
    public partial class FrmCustAdd : Form
    {
        ConnectDB conn;
        Config1 config1;
        CustomerDB custdb;
        Customer cust;
        CustomerTypeDB custTdb;
        DistrictDB distdb;
        Boolean chkKey = false;
        public FrmCustAdd()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            conn = new ConnectDB();
            config1 = new Config1();

            distdb = new DistrictDB(conn);
            custdb = new CustomerDB(conn);
            custTdb = new CustomerTypeDB(conn);
            cust = new Customer();
            custTdb.getCboCustomerType(cboTypeCust);
        }
        private void setResize()
        {
            
        }
        public void setData(String custId)
        {
            DataTable dt = new DataTable();
            cust = custdb.selectCustomerByPk(custId);
            txtCustName.Text = cust.custName;
            txtCustNumber.Text = cust.custNumber;
            txtAddress1.Text = cust.custAddress1;
            txtAddress2.Text = cust.custAddress2;
            txtDescription.Text = cust.description;
            txtEmail.Text = cust.email;
            txtPostcode.Text = cust.postCode;
            txtRemark.Text = cust.remark;
            txtTelephone.Text = cust.telephone;
            txtCustId.Text = cust.custId;
            cboTypeCust.Text = custTdb.selectCustomerTypeNameById(cust.custTypeNumber);
        }
        private void getData()
        {
            cust.custId = txtCustId.Text;
            cust.custName = txtCustName.Text;
            cust.custNumber = txtCustNumber.Text;
            cust.custAddress1 = txtAddress1.Text;
            cust.custAddress2 = txtAddress2.Text;
            cust.description = txtDescription.Text;
            cust.email = txtEmail.Text;
            cust.postCode = txtPostcode.Text;
            cust.remark = txtRemark.Text;
            cust.custActive = "1";
        }
        private void saveCustomer()
        {
            getData();
            custdb.insertCustomer(cust);
        }

        private void FrmCustAdd_Load(object sender, EventArgs e)
        {
            //var aaa = new Dictionary
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveCustomer();
        }

        private void cboDistrict_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtCustName.Text = cboDistrict.Text;

        }

        private void cboDistrict_KeyUp(object sender, KeyEventArgs e)
        {
            //txtCustName.Text = cboDistrict.Text;
            if (e.KeyCode == Keys.Enter)
            {
                if (!chkKey)
                {
                    if (cboDistrict.Text == "")
                    {
                        return;
                    }
                    chkKey = true;
                    distdb.getCboDistrict(cboDistrict, cboDistrict.Text);

                    chkKey = false;
                    
                }
                txtPostcode.Focus();
            }
            
        }

        private void cboDistrict_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboDistrict_TabStopChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCustName_Enter(object sender, EventArgs e)
        {
            txtCustName.BackColor = Color.LightYellow;
        }

        private void txtCustName_Leave(object sender, EventArgs e)
        {
            txtCustName.BackColor = Color.White;
        }

        private void txtCustNameE_Enter(object sender, EventArgs e)
        {
            txtCustNameE.BackColor = Color.LightYellow;
        }

        private void txtCustNameE_Leave(object sender, EventArgs e)
        {
            txtCustNameE.BackColor = Color.White;
        }

        private void txtCustName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustNameE.Focus();
            }
            
        }

        private void txtCustNameE_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress1.Focus();
            }
        }

        private void txtAddress1_Enter(object sender, EventArgs e)
        {
            txtAddress1.BackColor = Color.LightYellow;
        }

        private void txtAddress1_Leave(object sender, EventArgs e)
        {
            txtAddress1.BackColor = Color.White;
        }

        private void txtAddress2_Enter(object sender, EventArgs e)
        {
            txtAddress2.BackColor = Color.LightYellow;
        }

        private void txtAddress2_Leave(object sender, EventArgs e)
        {
            txtAddress2.BackColor = Color.White;
        }

        private void txtAddress2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboDistrict.Focus();
            }
        }

        private void txtAddress1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress2.Focus();
            }
        }

        private void cboDistrict_Enter(object sender, EventArgs e)
        {
            cboDistrict.BackColor = Color.LightYellow;
        }

        private void cboDistrict_Leave(object sender, EventArgs e)
        {
            cboDistrict.BackColor = Color.White;
        }

        private void txtPostcode_Enter(object sender, EventArgs e)
        {
            txtPostcode.BackColor = Color.LightYellow;
        }

        private void txtPostcode_Leave(object sender, EventArgs e)
        {
            txtPostcode.BackColor = Color.White;
        }

        private void txtPostcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelephone.Focus();
            }
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtDescription.BackColor = Color.LightYellow;
        }

        private void txtDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            txtDescription.BackColor = Color.White;
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.LightYellow;
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.White;
        }

        private void txtRemark_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.LightYellow;
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
        }

        private void btnCheckName_Click(object sender, EventArgs e)
        {
            DataTable dt = custdb.selectCust(txtCustName.Text);
            if (dt.Rows.Count > 0)
            {
                Form frm = new Form();
                Panel panel = new Panel();
                DataGridView dgvView = new DataGridView();
                dgvView.Top = frm.Top + 10;
                dgvView.Left = frm.Left + 5;
                
                dgvView.RowCount = dt.Rows.Count;
                dgvView.ColumnCount = 2;
                dgvView.Columns[0].Width = 40;
                dgvView.Columns[1].Width = 400;
                
                dgvView.Columns[0].HeaderText = "ลำดับ";
                dgvView.Columns[1].HeaderText = "ลูกค้า";
                
                //int top = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[0, i].Value = (i + 1);
                    dgvView[1, i].Value = dt.Rows[i][custdb.cust.custName].ToString();   
                }
                
                //TextBox txt = new TextBox();
                
                frm.WindowState = FormWindowState.Normal;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Width = 600;
                frm.Height = 500;
                dgvView.Width = frm.Width;
                dgvView.Height = frm.Height;
                panel.Width = frm.Width;
                panel.Height = frm.Height;
                frm.Controls.Add(dgvView);
                frm.ShowDialog(this);
            }
        }
    }
}
