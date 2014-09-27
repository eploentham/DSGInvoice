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
    public partial class FrmDepositAdd : Form
    {
        DsgControl dc;
        Deposit dep;
        public FrmDepositAdd()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            dc = new DsgControl();
            dep = new Deposit();
            //cboCust = dc.custdb.getCboCustomer(cboCust);
            cboCust = dc.invdb.getCboCustUnPayment(cboCust);
            setControl(dep);
            //cboInv= dc.invdb.
        }
        private void setDeposit()
        {
            dep = new Deposit();
            dep.depositActive = "1";
            dep.depositDate = dtpDepositDate.Value.ToString("yyyy-MM-dd");
            dep.depositId = txtDepositId.Text;
            dep.description = txtDescription.Text;
            if (!txtInvId.Text.Equals(""))
            {
                dep.invId = txtInvId.Text;
                Invoice inv = new Invoice();
                inv = dc.invdb.selectInvoiceByPk(txtInvId.Text);
                dep.invNumber = inv.invNumber;
            }
            dep.remark = txtCustRemark.Text;
            dep.deposit = txtDeposit.Text;
            dep.custId = txtCustId.Text;
            dep.custName = cboCust.Text;
        }
        public void setData(String depositId)
        {
            dep = dc.depdb.selectDepositByPk(depositId);
            setControl(dep);
        }
        private void setControl(Deposit p)
        {
            txtDepositId.Text = p.depositId;
            txtDescription.Text = p.description;
            txtInvId.Text = p.invId;
            txtCustRemark.Text = p.remark;
            cboInv.Text = dc.invdb.getInvDesp(p.invId);
            if (p.depositDate.Equals(""))
            {
                dtpDepositDate.Value = DateTime.Now;
            }
            else
            {
                dtpDepositDate.Value = DateTime.Parse(p.depositDate);
            }
            
            txtDeposit.Text = dc.config1.NumberNull(p.deposit);
            txtCustId.Text = p.custId;
            cboCust.Text = p.custName;
            if (p.depositActive.Equals("3"))
            {
                chkActive.Checked = false;
            }
            else
            {
                chkActive.Checked = true;
            }
            if (p.statusDeposit.Equals("2"))
            {
                setControlDisAbled();
                chkActive.Enabled = false;
                chkUnActive.Enabled = false;
                btnUnActive.Enabled = false;
            }
            else
            {
                setControlEnAbled();
                chkActive.Enabled = true;
                chkUnActive.Enabled = true;
                btnUnActive.Enabled = true;
            }
        }
        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            ComboBoxItem item = new ComboBoxItem();
            item = (ComboBoxItem)cboCust.SelectedItem;
            cust = dc.custdb.selectCustomerByPk(item.Value);
            txtCustRemark.Text = cust.remark;
            txtCustId.Text = cust.custId;
            cboInv = dc.invdb.getCboInvUnPayment(cboInv, cust.custId);
        }

        private void cboInv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = new ComboBoxItem();
            item = (ComboBoxItem)cboInv.SelectedItem;
            txtInvId.Text = item.Value;
        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("", "aaaa");
        }

        private void txtDeposit_Leave(object sender, EventArgs e)
        {
            //String aaa = dc.config1.NumberNull(txtDeposit.Text);
            txtDeposit.Text = dc.config1.NumberNull(txtDeposit.Text);
            txtDeposit.BackColor = Color.White;
        }
        private Boolean saveDeposit()
        {
            String depId = "";
            setDeposit();
            depId = dc.depdb.insertDeposit(dep);
            txtDepositId.Text = depId;
            if (depId.Length > 5)
            {
                if (!txtInvId.Text.Equals(""))
                {
                    dc.invdb.updateDeposit(txtInvId.Text, dep.deposit);
                }
                MessageBox.Show("บันทึก ใบรับเงินมัดจำเรียบร้อย \n" + "ของ " + cboCust.Text, "บันทึกข้อมูล");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void setControlDisAbled()
        {
            txtCustRemark.Enabled = false;
            cboCust.Enabled = false;
            cboInv.Enabled = false;
            dtpDepositDate.Enabled = false;
            txtDeposit.Enabled = false;
            txtDescription.Enabled = false;
            //txtRemark.Enabled = false;
            btnPrint.Enabled = false;
            btnSave.Enabled = false;
            btnUnActive.Enabled = true;
        }
        private void setControlEnAbled()
        {
            txtCustRemark.Enabled = true;
            cboCust.Enabled = true;
            cboInv.Enabled = true;
            dtpDepositDate.Enabled = true;
            txtDeposit.Enabled = true;
            txtDescription.Enabled = true;
            btnPrint.Enabled = true;
            btnSave.Enabled = true;
            btnUnActive.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Equals(""))
            {
                MessageBox.Show("กรุณาป้อนรายละเอียด การรับเงินมัดจำ", "error");
                return;
            }
            if (txtCustId.Text.Equals(""))
            {
                MessageBox.Show("ไม่พบข้อมูลลูกค้า", "error");
                return;
            }
            if (txtDeposit.Text.Equals(""))
            {
                MessageBox.Show("กรุณาป้อนจำนวนเงินมัดจำ", "error");
                return;
            }
            if (txtCustId.Text.Equals(""))
            {
                MessageBox.Show("กรุณาเลือกลูกค้า", "error");
                return;
            }
            if (txtInvId.Text.Equals(""))
            {
                MessageBox.Show("กรุณาเลือกใบแจ้งหนี้", "error");
                return;
            }
            if (saveDeposit())
            {
                //this.Dispose();
            }
            
        }

        private void cboCust_Enter(object sender, EventArgs e)
        {
            cboCust.BackColor = Color.LightYellow;
        }

        private void cboCust_Leave(object sender, EventArgs e)
        {
            cboCust.BackColor = Color.White;
        }

        private void txtCustRemark_Enter(object sender, EventArgs e)
        {
            txtCustRemark.BackColor = Color.LightYellow;
        }

        private void txtCustRemark_Leave(object sender, EventArgs e)
        {
            txtCustRemark.BackColor = Color.White;
        }

        private void cboInv_Enter(object sender, EventArgs e)
        {
            cboInv.BackColor = Color.LightYellow;
        }

        private void cboInv_Leave(object sender, EventArgs e)
        {
            cboInv.BackColor = Color.White;
        }

        private void txtDeposit_Enter(object sender, EventArgs e)
        {
            txtDeposit.BackColor = Color.LightYellow;
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtDescription.BackColor = Color.LightYellow;
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            txtDescription.BackColor = Color.White;
        }

        private void FrmDepositAdd_Load(object sender, EventArgs e)
        {

        }

        private void chkUnActive_CheckedChanged(object sender, EventArgs e)
        {
            setControlDisAbled();
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            setControlEnAbled();
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ต้องการยกเลิกรายการ \n" , "ยกเลิกรายการ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dc.depdb.updateUnActive(txtDepositId.Text);
                if (!txtInvId.Text.Equals(""))
                {
                    dc.invdb.updateUnDeposit(txtInvId.Text, txtDeposit.Text);
                }
            }
        }

        private void txtDeposit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void txtDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnSave_Enter(object sender, EventArgs e)
        {
            btnSave_Click(null,null);
        }
    }
}
