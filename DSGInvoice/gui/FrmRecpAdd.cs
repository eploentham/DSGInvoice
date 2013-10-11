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
    public partial class FrmRecpAdd : Form
    {
        ConnectDB conn;
        //Config1 config1;
        DsgControl dc;
        Invoice inv;
        Recript recp;
        int colInvRow = 0,colStatus=1, colInvDesc = 3, colInvDate = 2, colInvAmount = 4, colInvReceipt = 5, colInvId = 8, colInvRemark=9;
        int colAmount = 6, colReceipt = 7;
        
        int colRecpRow=0, colRecpInvNumber=1, colRecpDesc=2, colRecpInvDate=3,colRecpAmount=4, colRecpRemark=5,colRecpId=6, colCntRecp=9, colCntInv=10;
        int colRecpItemId = 8;

        int colDepRow = 0, colDepDate = 1, colDepDeposit = 2, colDepDescription = 3, colDepRemark = 4;
        Boolean chkCboInv = false,chkCboCust=false;
        public String flagShow = "";

        public FrmRecpAdd()
        {
            InitializeComponent();
            initConfig();
        }
        //public void setDC(DsgControl dc)
        //{
        //    this.dc = dc;
        //}
        private void initConfig()
        {
            dc = new DsgControl();
            inv = new Invoice();
            recp = new Recript();
            cboCust = dc.invdb.getCboCustUnPayment(cboCust);
            //cboInv = dc.invdb.getCboInvUnPayment1(cboInv);

            dgvDeposit.Visible = false;
            setDgvAddInvoice(colCntInv, dgvAdd.RowCount);
            //conn = new ConnectDB();
            //config1 = new Config1();
        }
        private void setControlReceipt()
        {
            if (chkReceiptAll.Checked)
            {
                dgvAdd.Enabled = false;
                txtAmount.Enabled = false;
                txtReceipt.Enabled = false;
                //dgvAdd.BackgroundColor = Color.Gray;
                for (int i = 0; i < dgvAdd.RowCount; i++)
                {
                    dgvAdd.Rows[i].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EEEEEE");
                    //calAmount(i);
                }
            }
            else
            {
                dgvAdd.Enabled = true;
                txtAmount.Enabled = false;
                txtReceipt.Enabled = false;
                for (int i = 0; i < dgvAdd.RowCount; i++)
                {
                    dgvAdd.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    if (i != dgvAdd.RowCount)
                    {
                        setColReceipt(i);
                    }
                }
            }
        }
        private void setDgvDeposit()
        {
            dgvDeposit.ColumnCount = 5;
            dgvDeposit.Columns[colDepRow].Width = 50;
            dgvDeposit.Columns[colDepDate].Width = 100;
            dgvDeposit.Columns[colDepDeposit].Width = 150;
            dgvDeposit.Columns[colDepDescription].Width = 200;
            dgvDeposit.Columns[colDepRemark].Width = 200;

            dgvDeposit.Columns[colDepRow].HeaderText = "ลำดับ";
            dgvDeposit.Columns[colDepDate].HeaderText = "วันที่รับ";
            dgvDeposit.Columns[colDepDeposit].HeaderText = "จำนวนเงิน";
            dgvDeposit.Columns[colDepDescription].HeaderText = "รายละเอียด";
            dgvDeposit.Columns[colDepRemark].HeaderText = "";

        }
        private void setDgvAddInvoice(int column, int row)
        {
            dgvAdd.ColumnCount = 0;
            dgvAdd.ColumnCount = column;
            //dgvAdd.RowCount = row;
            if (row == 0)
            {
                dgvAdd.RowCount = 1;
            }
            else
            {
                dgvAdd.RowCount = row;
            }
            dgvAdd.Columns[colInvRow].Width = 50;
            dgvAdd.Columns[colStatus].Width = 160;
            dgvAdd.Columns[colInvDate].Width = 100;
            dgvAdd.Columns[colInvDesc].Width = 300;
            dgvAdd.Columns[colInvAmount].Width = 150;
            dgvAdd.Columns[colInvReceipt].Width = 150;
            dgvAdd.Columns[colAmount].Width = 150;
            dgvAdd.Columns[colReceipt].Width = 150;
            //dgvAdd.Columns[7].Width = 80;
            dgvAdd.Columns[colInvRow].HeaderText = "ลำดับ";
            dgvAdd.Columns[colInvDate].HeaderText = "วันที่ ";
            dgvAdd.Columns[colInvDesc].HeaderText = "รายละเอียด";
            dgvAdd.Columns[colInvAmount].HeaderText = "ราคา";
            //dgvAdd.Columns[colInvAmount].HeaderText = "qty";
            dgvAdd.Columns[colInvAmount].HeaderText = " มูลค่า";
            dgvAdd.Columns[colInvReceipt].HeaderText = "รับชำระแล้ว";
            dgvAdd.Columns[colAmount].HeaderText = "คงเหลือ";
            dgvAdd.Columns[colReceipt].HeaderText = "รับชำระ";
            dgvAdd.Columns[colInvId].HeaderText = "invid";
            dgvAdd.Columns[colInvRemark].HeaderText = "หมายเหตุ";
            ////dgvAdd.Columns[1]. = cell;
            dgvAdd.Columns[colInvId].Visible = false;
            dgvAdd.Columns[colStatus].Visible = false;
            dgvAdd.Columns[colInvAmount].ReadOnly = true;
            dgvAdd.Columns[colAmount].ReadOnly = true;
            dgvAdd.Columns[colInvReceipt].ReadOnly = true;
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvAdd.Font = font;
        }
        private void setDgvAddReceipt(int column)
        {
            dgvAdd.ColumnCount = 0;
            dgvAdd.ColumnCount = column;
            if (dgvAdd.RowCount == 0)
            {
                dgvAdd.RowCount = 1;
            }
            dgvAdd.Columns[colRecpRow].Width = 50;
            dgvAdd.Columns[colRecpInvNumber].Width = 160;
            dgvAdd.Columns[colRecpDesc].Width = 300;
            dgvAdd.Columns[colRecpInvDate].Width = 100;
            dgvAdd.Columns[colRecpAmount].Width = 150;
            dgvAdd.Columns[colRecpId].Width = 150;
            dgvAdd.Columns[colAmount].Width = 150;
            dgvAdd.Columns[colReceipt].Width = 150;
            //dgvAdd.Columns[7].Width = 80;
            dgvAdd.Columns[colRecpRow].HeaderText = "ลำดับ";
            dgvAdd.Columns[colRecpInvNumber].HeaderText = "invoice number ";
            dgvAdd.Columns[colRecpDesc].HeaderText = "รายละเอียด";
            dgvAdd.Columns[colRecpInvDate].HeaderText = "วันที่";
            dgvAdd.Columns[colRecpAmount].HeaderText = "รับชำระ";
            dgvAdd.Columns[colRecpId].HeaderText = "recpid";
            dgvAdd.Columns[colRecpRemark].HeaderText = "หมายเหตุ";
            ////dgvAdd.Columns[1]. = cell;
            //dgvAdd.Columns[colInvId].Visible = false;
            dgvAdd.Columns[colRecpId].Visible = false;
            dgvAdd.Columns[colRecpInvNumber].ReadOnly = true;
            dgvAdd.Columns[colRecpDesc].ReadOnly = true;
            dgvAdd.Columns[colRecpAmount].ReadOnly = true;
            dgvAdd.Columns[colRecpAmount].ReadOnly = true;
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvAdd.Font = font;
        }
        private void setDataDeposit(String custId)
        {
            Double amt = 0.0;
            dgvDeposit.Visible = false;
            setDgvDeposit();
            DataTable dt = new DataTable();
            
            dt = dc.depdb.selectByCustId(custId);
            
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            dgvDeposit.RowCount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                dgvDeposit.Visible = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    amt += Double.Parse(dt.Rows[i][dc.depdb.dep.deposit].ToString());
                    dgvDeposit[colDepRow, i].Value = (i+1);
                    dgvDeposit[colDepDate, i].Value = dc.config1.dateDBtoShow1(dt.Rows[i][dc.depdb.dep.depositDate].ToString());
                    dgvDeposit[colDepDeposit, i].Value = dc.config1.NumberNull(dt.Rows[i][dc.depdb.dep.deposit]);
                    dgvDeposit[colDepDescription, i].Value = dt.Rows[i][dc.depdb.dep.description].ToString();
                    dgvDeposit[colDepRemark, i].Value = dt.Rows[i][dc.depdb.dep.invNumber].ToString();
                }
                txtDeposit.Text = dc.config1.NumberNull(amt);
                chkDeposit.Checked = true;
            }
        }
        public void setDataInvoiceFromRecpView(String invId)
        {
            //ComboBoxItem item = new ComboBoxItem();
            //item = (ComboBoxItem)cboCust.SelectedItem;
            //cust = dc.custdb.selectCustomerByPk(item.Value);
            //txtCustRemark.Text = cust.remark;
            //txtCustId.Text = cust.custId;
            //cboInv = dc.invdb.getCboInvUnPayment(cboInv, cust.custId);
            
            setDataInvoice(invId);
            setDataDeposit(txtCustId.Text);
            cboCust.Enabled = false;
            btnCust.Enabled = false;
            cboInv.Enabled = false;
            chkActive.Checked = true;
            btnUnActive.Enabled = false;
        }
        public void setDataInvoice(String invId)
        {
            DataTable dt = new DataTable();
            Deposit dep = new Deposit();
            Double amt = 0.0, recp = 0.0, itemAmt=0.0, itemRecp=0.0, deposit=0.0, depositInv=0.0;
            //DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
            //cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            inv = dc.invdb.selectInvoiceByPk(invId);
            //inv = dc.invdb.selectInvoiceByInvNumber(invId);
            Customer cust = new Customer();
            cust = dc.custdb.selectCustomerByPk(inv.custId);
            dt = dc.invIdb.selectByInvId(inv.invId);
            txtInvId.Text = inv.invId;
            txtCustId.Text = inv.custId;
            chkCboCust = true;
            chkCboInv = true;
            cboCust.Text = inv.custName;
            txtInvId.Text = inv.invId;
            chkCboInv = false;
            chkCboCust = false;
            cboInv.Text = dc.invdb.getInvDesp(inv.invId);
            txtCustRemark.Text = cust.remark;
            txtInvRemark.Text = inv.remark;
            dep.deposit = dc.depdb.selectSumDepositByInvId(invId);
            if (!dep.deposit.Equals("") && (!dep.deposit.Equals(".00")))
            {
                chkDeposit.Checked = true;
            }
            else
            {
                chkDeposit.Checked = false;
            }
            
            if (chkDeposit.Checked)
            {
                amt = Double.Parse(dc.config1.NumberNull(inv.invAmount));
                recp = Double.Parse(dc.config1.NumberNull(inv.recpAmount));
                deposit = Double.Parse(dep.deposit);
                txtAmount.Text = dc.config1.NumberNull(amt - deposit - recp);
            }
            else
            {
                amt = Double.Parse(dc.config1.NumberNull(inv.invAmount));
                recp = Double.Parse(dc.config1.NumberNull(inv.recpAmount));
                if (inv.statusDeposit.Equals("1"))
                {
                    depositInv = Double.Parse(inv.deposit);
                }
                else
                {
                    depositInv = 0.0;
                }
                txtAmount.Text = dc.config1.NumberNull(amt - (recp + depositInv));
            }

            txtInvRemark.Text = inv.remark;
            txtDeposit.Text = dep.deposit;
            txtDepositId.Text = dep.depositId;
            chkReceiptAll.Checked = true;
            chkActive.Checked = true;
            dgvAdd.RowCount = dt.Rows.Count + 1;
            
            
            txtRecpNumber.Text = dc.recpdb.genRecriptNumber();
            txtRecpNumber.Enabled = false;
            int row1 = dt.Rows.Count + 1;
            setDgvAddInvoice(colCntInv, row1);
            //cboCust.Text = inv.custName;
            //dt = invIdb.selectByInvId(inv.invId);

            //dgvAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemAmt = Double.Parse(dt.Rows[i][dc.invIdb.invI.amount].ToString());
                    itemRecp = Double.Parse(dt.Rows[i][dc.invIdb.invI.recpAmount].ToString());
                    dgvAdd[colInvRow, i].Value = dt.Rows[i][dc.invIdb.invI.invItemRow].ToString().Replace(".00","");
                    //dgvAdd[colInvDate, i].Value = dc.config1.dateDBtoShow1(inv.invDate.Substring(0,10));
                    dgvAdd[colInvDate, i].Value = dc.config1.dateDBtoShow1(inv.invDate);
                    dgvAdd[colInvDesc, i].Value = dt.Rows[i][dc.invIdb.invI.description].ToString();
                    dgvAdd[colInvAmount, i].Value = dc.config1.NumberNull(dt.Rows[i][dc.invIdb.invI.amount]);//ยอดเต็ม
                    //dgvAdd[colInvReceipt, i].Value = dc.config1.NumberNull(itemRecp+deposit);//จำนวนเงินที่รับไปแล้ว
                    dgvAdd[colInvReceipt, i].Value = dc.config1.NumberNull(itemRecp+depositInv);//จำนวนเงินที่รับไปแล้ว
                    if (chkDeposit.Checked)
                    {
                        dgvAdd[colAmount, i].Value = dc.config1.NumberNull(itemAmt - (itemRecp + deposit));
                    }
                    else
                    {
                        if (inv.statusDeposit.Equals("1"))
                        {
                            depositInv = Double.Parse(inv.deposit);
                        }
                        else
                        {
                            depositInv = 0.0;
                        }
                        dgvAdd[colAmount, i].Value = dc.config1.NumberNull(itemAmt - (itemRecp + depositInv));
                    }
                    
                    dgvAdd[colReceipt, i].Value = "0.00";
                    //dgvAdd[colInvId, i].Value = dt.Rows[i][dc.invIdb.invI.amount].ToString();
                    dgvAdd[colInvRemark, i].Value = dt.Rows[i][dc.invIdb.invI.remark].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvAdd.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            //setControlReceipt();
            setEnable();
            setControlReceipt();
        }
        public void setDataReceipt(String recpId)
        {
            DataTable dt = new DataTable();
            ComboBoxItem cboI = new ComboBoxItem();
            recp = dc.recpdb.selectRecriptByPk(recpId);
            dt = dc.recpIdb.selectReceiptItemByRecpId(recpId);
            cboI = dc.custdb.selectComboBoxItemByPk(recp.custId);
            txtRecpNumber.Text = recp.recpNumber;
            txtRecpId.Text = recp.recpId;
            txtAmount.Text = recp.recpAmount;
            chkCboCust = true;
            cboCust.Text = cboI.Text;
            txtCustId.Text = cboI.Value;
            chkCboCust = false;
            if (recp.recpDate != "")
            {
                dtpRecepDate.Value = DateTime.Parse(recp.recpDate);
            }
            setDgvAddReceipt(colCntRecp);
            if (recp.recpActive.Equals("3"))
            {
                //chkUnActive.Checked = true;
                chkUnActive.Checked = true;
            }
            else
            {
                //chkUnActive.Checked = false;
                chkActive.Checked = true;
            }
            if (recp.statusRecepitAll.Equals("1"))
            {
                //chkUnActive.Checked = true;
                chkReceiptAll.Checked = true;
            }
            else
            {
                //chkUnActive.Checked = false;
                chkReceiptSome.Checked = true;
            }
            
            if (dt.Rows.Count > 0)
            {
                dgvAdd.RowCount = dt.Rows.Count;
            }
            else
            {
                dgvAdd.RowCount = 1;
            }
            txtAmount.Text = dc.config1.NumberNull(recp.recpAmount);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvAdd[colRecpRow, i].Value = dt.Rows[i][dc.recpIdb.recpI.recpItemRow].ToString().Replace(".00", "");
                    dgvAdd[colRecpInvNumber, i].Value = dt.Rows[i][dc.recpIdb.recpI.invNumber].ToString();
                    dgvAdd[colRecpItemId, i].Value = dt.Rows[i][dc.recpIdb.recpI.recpItemId].ToString();
                    dgvAdd[colRecpDesc, i].Value = dt.Rows[i][dc.recpIdb.recpI.description].ToString();
                    dgvAdd[colRecpInvDate, i].Value = dc.config1.dateDBtoShow1(dt.Rows[i][dc.recpIdb.recpI.invDate].ToString()); 
                    dgvAdd[colRecpAmount, i].Value = dc.config1.NumberNull(dt.Rows[i][dc.recpIdb.recpI.amount]);
                    dgvAdd[colRecpRemark, i].Value = dt.Rows[i][dc.recpIdb.recpI.remark].ToString();
                    dgvAdd[colRecpId, i].Value = dt.Rows[i][dc.recpIdb.recpI.recpId].ToString();
                    if ((i % 2) != 0)
                    {
                        dgvAdd.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    inv = dc.invdb.selectInvoiceByPk(dt.Rows[i][dc.recpIdb.recpI.invId].ToString());
                    chkCboInv = true;
                    cboInv.Text = dc.invdb.getInvDesp(inv.invId);
                    chkCboInv = false;
                    txtInvId.Text = inv.invId;
                    Deposit deposit = new Deposit();
                    //txtDeposit.Text = dc.depdb.selectSumDepositByInvId2(inv.invId);
                    txtDeposit.Text = dc.config1.NumberNull(dt.Rows[i][dc.recpIdb.recpI.deposit]);
                    if (inv.statusDeposit.Equals("1") || inv.statusDeposit.Equals("2"))
                    {
                        chkDeposit.Checked = true;
                    }
                }
            }
            setDisable();
        }
        public void setDataPayment(String invId)
        {
            String txt = "";
            DataTable dt = new DataTable();
            inv = dc.invdb.selectInvoiceByPk(invId);
            dt = dc.invIdb.selectByInvId(invId);
            txtCustId.Text = inv.custId;
            cboCust.Text = inv.custName;
            txtInvRemark.Text = inv.remark;
            txt = inv.custName + "-" +inv.invNumber + "[จำนวนเงิน " + dc.config1.NumberNull(inv.invAmount)+"]";
            cboInv.Text = txt;
            txtInvId.Text = inv.invId;
            chkReceiptAll.Checked = true;
            txtAmount.Text = inv.invAmount;
            if (dt.Rows.Count > 0)
            {
                dgvAdd.RowCount = dt.Rows.Count;
            }
            else
            {
                dgvAdd.RowCount = 1;
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvAdd[colRecpRow, i].Value = dt.Rows[i][dc.invIdb.invI.invItemRow].ToString().Replace(".00", "");
                    dgvAdd[colRecpInvNumber, i].Value = inv.invNumber;
                    dgvAdd[colRecpDesc, i].Value = dt.Rows[i][dc.invIdb.invI.description].ToString();
                    dgvAdd[colRecpInvDate, i].Value = dc.config1.dateDBtoShow1(inv.invDate);
                    dgvAdd[colRecpAmount, i].Value = dc.config1.NumberNull(dt.Rows[i][dc.invIdb.invI.amount]);
                    dgvAdd[colRecpRemark, i].Value = dt.Rows[i][dc.invIdb.invI.remark].ToString();
                }
            }
            setDisable();
        }
        private void setDisable()
        {
            txtRecpNumber.Enabled = false;
            dtpRecepDate.Enabled = false;
            cboCust.Enabled = false;
            txtCustRemark.Enabled = false;
            cboInv.Enabled = false;
            txtInvRemark.Enabled = false;
            txtDeposit.Enabled = false;
            dgvDeposit.Enabled = false;
            dgvAdd.Enabled = false;
            chkDeposit.Enabled = false;
            chkReceiptAll.Enabled = false;
            txtAmount.Enabled = false;
            chkReceiptSome.Enabled = false;
            txtReceipt.Enabled = false;
            btnSave.Enabled = false;
            btnCust.Enabled = false;
            btnUnActive.Enabled = false;
        }
        private void setEnable()
        {
            txtRecpNumber.Enabled = true;
            dtpRecepDate.Enabled = true;
            cboCust.Enabled = true;
            txtCustRemark.Enabled = true;
            cboInv.Enabled = true;
            txtInvRemark.Enabled = true;
            txtDeposit.Enabled = true;
            dgvDeposit.Enabled = true;
            dgvAdd.Enabled = true;
            chkDeposit.Enabled = true;
            chkReceiptAll.Enabled = true;
            txtAmount.Enabled = true;
            chkReceiptSome.Enabled = true;
            txtReceipt.Enabled = true;
            btnSave.Enabled = true;
            btnCust.Enabled = true;
        }

        private void FrmRecpAdd_Load(object sender, EventArgs e)
        {
            setResize();
        }

        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkCboCust)
            {
                return;
            }
            clearControl();
            Customer cust = new Customer();
            //cust = custdb.selectCustomerByName(cboCust.Text);
            ComboBoxItem item = new ComboBoxItem();
            item = (ComboBoxItem)cboCust.SelectedItem;
            cust = dc.custdb.selectCustomerByPk(item.Value);
            txtCustRemark.Text = cust.remark;
            txtCustId.Text = cust.custId;
            cboInv = dc.invdb.getCboInvUnPayment(cboInv, cust.custId);
            setDataDeposit(cust.custId);
        }

        private void cboInv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkCboInv)
            {
                return;
            }
            //Invoice inv = new Invoice();
            ComboBoxItem item = new ComboBoxItem();
            item = (ComboBoxItem)cboInv.SelectedItem;
            //inv = dc.invdb.selectInvoiceByPk(item.Value);
            //txtInvId.Text = inv.invId;
            //txtAmount.Text = inv.invAmount;
            setDataInvoice(item.Value);
        }

        private void chkReceiptAll_CheckedChanged(object sender, EventArgs e)
        {
            setControlReceipt();
        }

        private void chkReceiptSome_CheckedChanged(object sender, EventArgs e)
        {
            setControlReceipt();
        }

        private void dgvAdd_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvAdd.CurrentCell.ColumnIndex == colReceipt) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void clearControl()
        {
            dgvAdd.RowCount = 1;
            txtAmount.Text = "0.00";
            chkReceiptAll.Checked = true;
            txtInvRemark.Text = "";
            txtInvId.Text = "";
            cboInv.Text = "";
            cboInv.Items.Clear();
        }
        private void setResize()
        {
            dgvAdd.Width = this.Width - 50;
            groupBox1.Width = this.Width - 50;
            groupBox2.Width = this.Width - 50;
            //dgvAdd.Height = this.Height - 150;
        }
        private void calAmount(int row)
        {
            String invAmount = "0.0";
            String invReceipt = "0.0";
            String receipt = "0.0";
            Double temp = 0.0;
            if (dgvAdd[colInvAmount, row].Value != null)
            {
                invAmount = dgvAdd[colInvAmount, row].Value.ToString();
            }
            if (dgvAdd[colInvReceipt, row].Value != null)
            {
                invReceipt = dgvAdd[colInvReceipt, row].Value.ToString();
            }
            if (dgvAdd[colReceipt, row].Value != null)
            {
                receipt = dgvAdd[colReceipt, row].Value.ToString();
            }
            receipt = dc.config1.NumberNull(receipt);
            invReceipt = dc.config1.NumberNull(invReceipt);
            invAmount = dc.config1.NumberNull(invAmount);
            temp = Double.Parse(invAmount) - (Double.Parse(invReceipt) + Double.Parse(receipt) + Double.Parse(txtDeposit.Text));
            dgvAdd[colAmount, row].Value = dc.config1.NumberNull(temp);
        }
        private void setColReceipt(int row)
        {
            if (row > 0)
            {
                dgvAdd[colReceipt, row].Value = "0.00";
            }            
        }

        private void FrmRecpAdd_Resize(object sender, EventArgs e)
        {
            setResize();
        }

        private void dgvAdd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colReceipt)
            {
                calAmount(e.RowIndex);
                String temp = "";
                Double receipt1 = 0.0;
                for (int i = 0; i < dgvAdd.RowCount; i++)
                {
                    if (dgvAdd[colReceipt, i].Value != null)
                    {
                        temp = dgvAdd[colReceipt, i].Value.ToString();
                        temp = dc.config1.NumberNull(temp);
                        receipt1 += Double.Parse(temp);
                    }
                }
                dgvAdd[colReceipt, e.RowIndex].Value = dc.config1.NumberNull(dgvAdd[colReceipt, e.RowIndex].Value);
                txtReceipt.Text = dc.config1.NumberNull(receipt1);
            }
        }
        private void setReceipt()
        {
            Double amt = 0.0, recp1 = 0.0, deposit = 0.0;
            deposit = Double.Parse(txtDeposit.Text);
            amt = Double.Parse(txtAmount.Text);
            if (txtReceipt.Text.Equals(""))
            {
                recp1 = 0.0;
            }
            else
            {
                recp1 = Double.Parse(txtReceipt.Text);
            }
            

            recp.recpId = txtRecpId.Text;
            recp.recpNumber = txtRecpNumber.Text;
            recp.remark = txtInvRemark.Text;
            recp.recpDate = dtpRecepDate.Value.ToString("yyyy-MM-dd");
            
            recp.custId = txtCustId.Text;
            recp.custName = cboCust.Text;
            //recep. = dtpDueDate.Value.ToString();
            recp.recpActive = "1";
            if (chkReceiptAll.Checked)
            {
                recp.recpAmount = String.Concat(amt+deposit);
                recp.statusRecepitAll = "1";
            }
            else
            {
                recp.recpAmount = String.Concat(recp1+deposit);
                recp.statusRecepitAll = "2";
            }
            
            recp.month = dtpRecepDate.Value.ToString("MM");
            recp.year = String.Concat(dtpRecepDate.Value.Year + 543);
            inv = dc.invdb.selectInvoiceByPk(txtInvId.Text);
            recp.invNumber = inv.invNumber;
            //recep.invDate = dtpInvDate.Value.ToString();
            //recep.invId = txtInvId.Text;
            //recep.remark = txtRemark.Text;
            //recep.termPayment = txtTermPayment.Text;
            
        }
        private Boolean saveRecpItem(String recpId)
        {
            Boolean chk = false;
            String recepiId = "";
            RecriptItem item;
            //Invoice inv = new Invoice();
            ComboBoxItem item1 = new ComboBoxItem();
            item1 = (ComboBoxItem)cboInv.SelectedItem;
            Invoice inv = new Invoice();
            Double deposit = 0, receipt = 0;
            inv = dc.invdb.selectInvoiceByPk(txtInvId.Text);
            for (int i = 0; i < dgvAdd.Rows.Count; i++)// ไม่ต้องทำ row สุดท้าย
            {
                item = new RecriptItem();
                if (dgvAdd[colInvDesc, i].Value == null)
                {
                    continue;
                }
                if (!chkReceiptAll.Checked)
                {
                    if (dgvAdd[colReceipt, i].Value == null)
                    {
                        continue;
                    }
                    if (dgvAdd[colReceipt, i].Value.Equals(""))
                    {
                        continue;
                    }
                }
                
                item.description = dgvAdd[colInvDesc, i].Value.ToString();
                item.recpId = recpId;
                item.recpItemActive = "1";
                item.recpItemId = dc.config1.ObjectNull(dgvAdd[colRecpItemId, i].Value);
                item.recpItemRow = String.Concat(i + 1);
                item.invDate = dc.config1.datetoDB(dgvAdd[colInvDate, i].Value);
                
                item.invNumber = inv.invNumber;
                item.invId = inv.invId;
                
                if (chkReceiptAll.Checked)
                {
                    //receipt = Double.Parse(dgvAdd[colInvAmount, i].Value.ToString());
                    receipt = Double.Parse(dgvAdd[colReceipt, i].Value.ToString());
                    receipt = Double.Parse(dc.config1.NumberNull(txtAmount.Text));
                    deposit = Double.Parse(txtDeposit.Text);
                    item.recpAmount = txtAmount.Text;
                    //item.amount = String.Concat(receipt+deposit);
                }
                else
                {
                    receipt = Double.Parse(dgvAdd[colReceipt, i].Value.ToString());
                    deposit = Double.Parse(txtDeposit.Text);
                    //item.amount = dgvAdd[colReceipt, i].Value.ToString();
                    item.recpAmount = txtReceipt.Text;
                }
                
                item.amount = String.Concat(receipt);
                item.deposit = txtDeposit.Text;
                item.invAmount = dgvAdd[colInvAmount, i].Value.ToString();
                item.amount1 = dgvAdd[colInvReceipt, i].Value.ToString();
                //item.recpAmount = dgvAdd[colReceipt, i].Value.ToString();
                if (dgvAdd[colInvRemark, i].Value != null)
                {
                    item.remark = dgvAdd[colInvRemark, i].Value.ToString();
                }
                else
                {
                    item.remark = "";
                }

                //item.remark = dgvAdd[colRemark, i].Value.ToString();
                recepiId = dc.recpIdb.insertRecriptItem(item);
                dgvAdd[colRecpItemId, i].Value = recepiId;
            }
            chk = true;//ถ้าทำงานได้ถึงบันทัดนี้ แสดงว่าไม่มี error
            return chk;
        }
        private Boolean updateInv(String recpDate)
        {
            Boolean chk = false;
            String receipt = "";
            for (int i = 0; i < dgvAdd.Rows.Count; i++)// ไม่ต้องทำ row สุดท้าย
            {
                if (dgvAdd[colInvDesc, i].Value == null)
                {
                    continue;
                }
                if (dgvAdd[colReceipt, i].Value == null)
                {
                    //MessageBox.Show("ไม่พบรายการ", "ไม่สามารถบันทึกข้อมูลได้");
                    return false;
                }
                if (dgvAdd[colAmount, i].Value == null)
                {
                    //continue;// row สุดท้าย
                    return false;
                }
                if (chkReceiptAll.Checked)
                {
                    //receipt = dgvAdd[colInvAmount, i].Value.ToString();
                    receipt = txtAmount.Text;
                }
                else
                {
                    receipt = dgvAdd[colReceipt, i].Value.ToString();
                }
                
                dc.invIdb.updateRecpAmount(txtInvId.Text, txtRecpNumber.Text, receipt);
            }
            Invoice inv = new Invoice();
            inv = dc.invdb.selectInvoiceByPk(txtInvId.Text);
            if (chkReceiptAll.Checked)
            {
                dc.invdb.updateRecript(inv.invNumber, txtRecpNumber.Text, txtAmount.Text, recpDate);
            }
            else
            {
                dc.invdb.updateRecript(inv.invNumber, txtRecpNumber.Text, txtReceipt.Text, recpDate);
            }
            chk = true;
            return chk;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String recpId = "", chk = "";
            setReceipt();
            for (int i = 0; i < dgvAdd.Rows.Count-1; i++)// ไม่ต้องทำ row สุดท้าย
            {
                if (dgvAdd[colReceipt, i].Value == null)
                {
                    //MessageBox.Show("ไม่พบรายการ", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
                if (dgvAdd[colAmount, i].Value == null)
                {
                    //continue;// row สุดท้าย
                    return;
                }
            }

            recpId = dc.recpdb.insertRecript(recp);
            txtRecpId.Text = recpId;
            if (!recpId.Equals(""))
            {
                if (saveRecpItem(recpId))
                {
                    //update Invoice
                    if (updateInv(recp.recpDate))
                    {
                        if (chkDeposit.Checked)
                        {
                            Recript recp1 = new Recript();
                            recp1 = dc.recpdb.selectRecriptByPk(recpId);
                            chk = dc.depdb.updateStatusDepositClear(txtInvId.Text,recp1.recpNumber);
                            if(chk.Equals("1") || chk.Equals("2") || chk.Equals("3"))
                            {
                                chk = "\n"+"และได้หักยอดเงินมัดจำ จำนวน " +txtDeposit.Text;
                            }
                        }
                        MessageBox.Show("รับชำระเรียบร้อย\n" + "เลขที่ :" + txtRecpNumber.Text + chk, "บันทึกข้อมูล");
                        this.Dispose();
                    }
                }
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

        private void txtInvRemark_Enter(object sender, EventArgs e)
        {
            txtInvRemark.BackColor = Color.LightYellow;
        }

        private void txtInvRemark_Leave(object sender, EventArgs e)
        {
            txtInvRemark.BackColor = Color.White;
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            cboCust = dc.custdb.getCboCustomer(cboCust);
            //cboCust.Refresh();
        }

        private void txtDeposit_Enter(object sender, EventArgs e)
        {
            txtDeposit.BackColor = Color.LightYellow;
        }

        private void txtDeposit_Leave(object sender, EventArgs e)
        {
            txtDeposit.BackColor = Color.White;
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ต้องการยกเลิกรายการ \n" + "เลขที่ :" + txtRecpNumber.Text, "ยกเลิกรายการ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dc.unActiveReceipt(txtRecpId.Text);
                MessageBox.Show("ได้ทำการยกเลิก \nใบเสร็จเชขที่ :"+txtRecpNumber.Text+"\nใบเสร็จเรียบร้อย", "ยกเลิกใบเสร็จ");
            }
        }

        private void chkUnActive_Click(object sender, EventArgs e)
        {
            btnUnActive.Enabled = true;
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            btnUnActive.Enabled = false;

        }
    }
}
