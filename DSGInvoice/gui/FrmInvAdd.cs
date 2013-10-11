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
    public partial class FrmInvAdd : Form
    {
        ConnectDB conn;
        Config1 config1;
        DsgControl dc;
        Invoice inv;
        InvoiceDB invdb;
        CustomerDB custdb;
        InvoiceItemDB invIdb;
        //FrmReport frmReport;
        int colRow = 0, colDesc = 1, colQty = 2, colQtyUnit = 3, colPrice = 4, colAmount = 5, colRemark = 6, colInvItemId=7;
        int colInvNumber = 8;
        Boolean chkCboCust = false;
        public FrmInvAdd()
        {
            InitializeComponent();
            initConfig();
            //foreach (Control x in this.Controls)
            //{
            //    if (x is TextBox)
            //    {
            //        x.Text = "aaaa";
            //    }
            //}
        }
        private void initConfig()
        {
            conn = new ConnectDB();
            config1 = new Config1();
            dc = new DsgControl();
            inv = new Invoice();
            invdb = new InvoiceDB(conn);
            invIdb = new InvoiceItemDB(conn);
            custdb = new CustomerDB(conn);
            custdb.getCboCustomer(cboCust);
            setBackColor();
            chkActive.Checked = true;
        }
        private void setBackColor()
        {
            //foreach ( TextBox tb in this.Controls.OfType<TextBox>()) 
            //{
            //    tb.Text = "111111111";
            //}
            foreach (Control X in this.Controls)
            {
                if (X is TextBox)
                {
                    (X as TextBox).Text = "111";
                }
            }

        }
        private void setResize()
        {
            dgvAdd.Width = this.Width - 50;
            dgvAdd.Height = this.Height - 150;
        }
        public void setData(String invId)
        {
            chkCboCust = true;
            DataTable dt = new DataTable();
            //DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
            //cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            inv = invdb.selectInvoiceByPk(invId);
            txtInvNumber.Text = inv.invNumber;
            txtInvId.Text = inv.invId;
            if (inv.invNumber == "")
            {
                txtInvNumber.Text = invdb.genInvNumber();
            }
            
            txtAddress1.Text = inv.custAddress1;
            txtAddress2.Text = inv.custAddress2;
            txtRemark.Text = inv.remark;
            txtTotal.Text = inv.invAmount;
            txtTermPayment.Text = inv.termPayment;
            if (inv.invActive.Equals("3"))
            {
                chkActive.Checked = false;
            }
            else
            {
                chkActive.Checked = true;
                //chkUnActive.Checked = true;
            }
            
            txtTotal.Enabled = false;
            if (inv.invDate != "")
            {
                dtpInvDate.Value = DateTime.Parse(inv.invDate);
            }
            if (inv.dueDate != "")
            {
                dtpDueDate.Value = DateTime.Parse(inv.dueDate);
            }
            
            cboCust.Text = inv.custName;
            dt = invIdb.selectByInvId(inv.invId);

            dgvAdd.ColumnCount =8;

            dgvAdd.RowCount = dt.Rows.Count + 1;
            dgvAdd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdd.Columns[colRow].Width = 50;
            dgvAdd.Columns[colDesc].Width = 400;
            dgvAdd.Columns[colQty].Width = 80;
            dgvAdd.Columns[colQtyUnit].Width = 80;
            dgvAdd.Columns[colPrice].Width = 120;
            dgvAdd.Columns[colAmount].Width = 120;
            dgvAdd.Columns[colRemark].Width = 100;
            //dgvAdd.Columns[7].Width = 80;
            dgvAdd.Columns[colRow].HeaderText = "ลำดับ";
            dgvAdd.Columns[colDesc].HeaderText = "รายละเอียด";
            dgvAdd.Columns[colQty].HeaderText = "จำนวน";
            dgvAdd.Columns[colQtyUnit].HeaderText = "หน่วย";
            dgvAdd.Columns[colPrice].HeaderText = "ราคาต่อหน่วย";
            dgvAdd.Columns[colAmount].HeaderText = "จำนวนเงิน";
            dgvAdd.Columns[colRemark].HeaderText = "หมายเหตุ";
            dgvAdd.Columns[colInvItemId].HeaderText = "invId";
            //dgvAdd.Columns[1]. = cell;
            dgvAdd.Columns[colRow].ReadOnly = true;
            dgvAdd.Columns[colAmount].ReadOnly = true;
            dgvAdd.Columns[colInvItemId].Visible = false;
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvAdd.Font = font;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvAdd[colRow, i].Value = dt.Rows[i][invIdb.invI.invItemRow].ToString().Replace(".00","");
                    dgvAdd[colDesc, i].Value = dt.Rows[i][invIdb.invI.description].ToString();
                    dgvAdd[colQty, i].Value = dt.Rows[i][invIdb.invI.qty].ToString();
                    dgvAdd[colQtyUnit, i].Value = dt.Rows[i][invIdb.invI.qtyUnit].ToString();
                    dgvAdd[colPrice, i].Value = dc.config1.NumberNull(dt.Rows[i][invIdb.invI.price]);
                    dgvAdd[colAmount, i].Value = dc.config1.NumberNull(dt.Rows[i][invIdb.invI.amount].ToString());
                    dgvAdd[colRemark, i].Value = dt.Rows[i][invIdb.invI.remark].ToString();
                    dgvAdd[colInvItemId, i].Value = dt.Rows[i][invIdb.invI.invItemId].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvAdd.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            chkCboCust = false;
        }
        private void setInvoice()
        {
            inv.invNumber = txtInvNumber.Text;
            inv.custAddress1 = txtAddress1.Text;
            inv.custAddress2 = txtAddress2.Text;
            inv.custId = txtCustId.Text;
            inv.custName = cboCust.Text;
            inv.dueDate = dtpDueDate.Value.ToString("yyyy-MM-dd");
            inv.invActive = "1";
            inv.invAmount = txtTotal.Text;
            inv.invDate = dtpInvDate.Value.ToString("yyyy-MM-dd");
            inv.invId = txtInvId.Text;
            inv.remark = txtRemark.Text;
            inv.termPayment = txtTermPayment.Text;
            inv.month = dtpInvDate.Value.ToString("MM");
            inv.year = String.Concat(dtpInvDate.Value.Year + 543);
        }
        private Boolean saveInvItem(String invId)
        {
            String invIId = "";
            Boolean chk = false;
            InvoiceItem item;
            for (int i = 0; i < dgvAdd.Rows.Count; i++)
            {
                item = new InvoiceItem();
                if (dgvAdd[colQty, i].Value == null)
                {
                    continue;
                }
                if (dgvAdd[colPrice, i].Value == null)
                {
                    continue;
                }
                item.amount = dgvAdd[colAmount, i].Value.ToString();
                item.description = dgvAdd[colDesc, i].Value.ToString();
                item.invId = invId;
                item.invItemActive = "1";
                item.invItemId = dc.config1.ObjectNull(dgvAdd[colInvItemId, i].Value);
                item.invItemRow = String.Concat(i + 1);
                item.price = dgvAdd[colPrice, i].Value.ToString();
                item.qty = dgvAdd[colQty, i].Value.ToString();
                if (dgvAdd[colQtyUnit, i].Value != null)
                {
                    item.qtyUnit = dgvAdd[colQtyUnit, i].Value.ToString();
                }
                else
                {
                    item.qtyUnit = "";
                }
                if (dgvAdd[colRemark, i].Value != null)
                {
                    item.remark = dgvAdd[colRemark, i].Value.ToString();
                }
                else
                {
                    item.remark = "";
                }
                
                //item.remark = dgvAdd[colRemark, i].Value.ToString();
                invIId = invIdb.insertInvoiceItem(item);
                dgvAdd[colInvItemId, i].Value = invIId;
            }
            chk = true;
            return chk;
        }
        private Boolean chkCell(int col, int row)
        {
            if (dgvAdd[col, row].Value == null)
            {
                dgvAdd.Rows[row].Cells[col].Style.BackColor = Color.Red;
                return false;
            }
            else
            {
                dgvAdd.Rows[row].Cells[col].Style.BackColor = Color.White;
                return true;
            }
        }
        private void calTotal()
        {
            Double amount = 0;
            for (int i = 0; i < dgvAdd.Rows.Count; i++)
            {
                if(chkCell(colAmount,i))
                {
                    amount += Double.Parse(dgvAdd[colAmount, i].Value.ToString());
                }
            }
            txtTotal.Text = dc.config1.NumberNull(amount);
        }
        private void setDueDate(String termPayment)
        {
            DateTime d = new DateTime();
            if (termPayment != "")
            {
                d = dtpInvDate.Value;
                d = d.AddDays(Double.Parse(termPayment));
                dtpDueDate.Value = d;
            }
        }
        private void setControlDisAbled()
        {
            dtpInvDate.Enabled = false;
            dtpDueDate.Enabled = false;
            txtTermPayment.Enabled = false;
            cboCust.Enabled = false;
            txtAddress1.Enabled = false;
            txtAddress2.Enabled = false;
            txtRemark.Enabled = false;
            btnPrint.Enabled = false;
            btnSave.Enabled = false;
            btnUnActive.Enabled = true;
        }
        private void setControlEnAbled()
        {
            dtpInvDate.Enabled = true;
            dtpDueDate.Enabled = true;
            txtTermPayment.Enabled = true;
            cboCust.Enabled = true;
            txtAddress1.Enabled = true;
            txtAddress2.Enabled = true;
            txtRemark.Enabled = true;
            btnPrint.Enabled = true;
            btnSave.Enabled = true;
            btnUnActive.Enabled = false;
        }
        
        private void cboCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkCboCust)
            {
                return;
            }
            Customer cust = new Customer();
            //cust = custdb.selectCustomerByName(cboCust.Text);
            ComboBoxItem item = new ComboBoxItem();
            item = (ComboBoxItem)cboCust.SelectedItem;
            cust = custdb.selectCustomerByPk(item.Value);
            txtCustId.Text = cust.custId;
            txtAddress1.Text=cust.custAddress1;
            txtAddress2.Text = cust.custAddress2;
            txtRemark.Text = cust.remark;
            txtTermPayment.Text = cust.termPayment;
            setDueDate(cust.termPayment);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String invId = "", chk="";
            setInvoice();
            for (int i = 0; i < dgvAdd.Rows.Count; i++)
            {
                if (dgvAdd[colDesc, i].Value == null)
                {
                    if (dgvAdd[colAmount, i].Value == null)
                    {
                        continue;// row สุดท้าย
                        //return;
                    }
                    MessageBox.Show("ไม่พบรายการ", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
                if (dgvAdd[colQty, i].Value == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลจำนวน", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
                if (dgvAdd[colPrice, i].Value == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลราคา", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
            }
            
            invId = invdb.insertInvoice(inv);
            txtInvId.Text = invId;
            if (saveInvItem(invId))
            {
                MessageBox.Show("บันทึกข้อมูลใบแจ้งหนี้เรียบร้อย", "บันทึกข้อมูล");
                //setData(invId);
                //this.Dispose();
            }
        }

        private void dgvAdd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("aaaa", "aaaa");
            if (e.ColumnIndex == colPrice)
            {
                if (!chkCell(colQty, e.RowIndex))
                {
                    //MessageBox.Show("ไม่พบข้อมูลจำนวน", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
                if (!chkCell(colPrice, e.RowIndex))
                {
                    //MessageBox.Show("ไม่พบข้อมูลราคา", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
                //String amount = "";
                dgvAdd[colAmount, e.RowIndex].Value = dc.config1.NumberNull(Double.Parse(dgvAdd[colPrice, e.RowIndex].Value.ToString()) * Double.Parse(dgvAdd[colQty, e.RowIndex].Value.ToString()));
                dgvAdd[colAmount, e.RowIndex].Selected = true;
                //dgvAdd.Rows[e.RowIndex].Cells[colPrice].Style.BackColor = Color.Yellow;
                dgvAdd[colPrice, e.RowIndex].Value = dc.config1.NumberNull(dgvAdd[colPrice, e.RowIndex].Value);
            }
            if (e.ColumnIndex == colQty)
            {
                if (!chkCell(colQty, e.RowIndex))
                {
                    //MessageBox.Show("ไม่พบข้อมูลจำนวน", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
                if (!chkCell(colPrice, e.RowIndex))
                {
                    //MessageBox.Show("ไม่พบข้อมูลราคา", "ไม่สามารถบันทึกข้อมูลได้");
                    return;
                }
                dgvAdd[colAmount, e.RowIndex].Value = dc.config1.NumberNull(Double.Parse(dgvAdd[colPrice, e.RowIndex].Value.ToString()) * Double.Parse(dgvAdd[colQty, e.RowIndex].Value.ToString()));
                dgvAdd[colPrice, e.RowIndex].Selected = true;
                //dgvAdd.Rows[e.RowIndex].Cells[colPrice].Style.BackColor = Color.Yellow;
            }
            calTotal();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (frmReport == null)
            //{
            FrmReport frmReport = new FrmReport();
            //}
            frmReport.reportName = "invoice";
            String datestart = "", dateend = "";
            //DateTime endOfMonth = new DateTime(cboYear.Text, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            //datestart = cboYear.Text + "-" + config1.getMonthId(cboMonth.Text)+"-01";
            //dateend = config1.getEndDateofMonth(int.Parse(cboYear.Text)-543, int.Parse(config1.getMonthId(cboMonth.Text)));

            //rmgdb.setRMonthlyGroupId(datestart, dateend);
            frmReport.setRptInvoice(txtInvId.Text);
            frmReport.Show(this);
        }

        private void dgvAdd_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvAdd.CurrentCell.ColumnIndex == colPrice) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            else if (dgvAdd.CurrentCell.ColumnIndex == colQty) //Desired Column
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

        private void txtTermPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cboCust_Enter(object sender, EventArgs e)
        {
            cboCust.BackColor = Color.LightYellow;
        }

        private void cboCust_Leave(object sender, EventArgs e)
        {
            cboCust.BackColor = Color.White;
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

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.LightYellow;
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            txtRemark.BackColor = Color.White;
        }

        private void txtTermPayment_KeyUp(object sender, KeyEventArgs e)
        {
            if (!txtTermPayment.Text.Equals(""))
            {
                setDueDate(txtTermPayment.Text);
            }
            
        }

        private void FrmInvAdd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void FrmInvAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ต้องการยกเลิกรายการ \n" + "เลขที่ :"+txtInvNumber.Text, "ยกเลิกรายการ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                invdb.updateUnActive(txtInvId.Text);
                this.Dispose();
            }
            
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            setControlEnAbled();
        }

        private void chkUnActive_CheckedChanged(object sender, EventArgs e)
        {
            setControlDisAbled();
        }

        private void txtTermPayment_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
