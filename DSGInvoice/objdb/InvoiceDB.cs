using DSGInvoice.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGInvoice.objdb
{
    class InvoiceDB
    {
        private ConnectDB conn;
        public Invoice inv;
        public Config1 config1;
        public InvoiceItemDB invIdb;
        public DsgDB dsgdb;
        Customer cust;
        public InvoiceDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            config1 = new Config1();
            dsgdb = new DsgDB(conn);
            inv = new Invoice();
            cust = new Customer();
            invIdb = new InvoiceItemDB(conn);
            inv.custAddress1 = "cust_address1";
            inv.custAddress2 = "cust_address2";
            inv.custId = "cust_id";
            inv.custName = "cust_name";
            inv.dueDate = "due_date";
            inv.invActive = "inv_active";
            inv.invAmount = "inv_amount";
            inv.invAmountThb = "inv_amount_thb";
            inv.invDate = "inv_date";
            inv.invId = "inv_id";
            inv.invNumber = "inv_number";
            inv.receiptNumber = "recp_number";
            inv.remark = "remark";
            inv.termPayment = "term_payment";
            inv.year = "year1";
            inv.month = "month1";
            inv.statusRecp = "status_recp";
            inv.recpAmount = "recp_amount";
            inv.remarkReceipt = "remark_receipt";
            inv.recpDate = "recp_date";
            inv.statusDeposit = "status_deposit";
            inv.deposit = "deposit";
            inv.log = "log";
            inv.pkField = "inv_id";
            inv.sited = "";
            inv.table = "t_invoice";
        }
        public Invoice selectInvoiceByPk(String invId)
        {
            Invoice item = new Invoice();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table + " Where " + inv.pkField + "='" + invId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private Invoice setData(Invoice item, DataTable dt)
        {
            item.invId = dt.Rows[0][inv.invId].ToString();
            item.invNumber = dt.Rows[0][inv.invNumber].ToString();
            item.custAddress1 = dt.Rows[0][inv.custAddress1].ToString();
            item.custAddress2 = dt.Rows[0][inv.custAddress2].ToString();
            item.custId = dt.Rows[0][inv.custId].ToString();
            item.custName = dt.Rows[0][inv.custName].ToString();
            item.dueDate = dt.Rows[0][inv.dueDate].ToString();
            item.invActive = dt.Rows[0][inv.invActive].ToString();
            item.invAmount = config1.NumberNull(dt.Rows[0][inv.invAmount]);
            item.invAmountThb = dt.Rows[0][inv.invAmountThb].ToString();
            item.invDate = dt.Rows[0][inv.invDate].ToString();

            item.receiptNumber = dt.Rows[0][inv.receiptNumber].ToString();
            item.remark = dt.Rows[0][inv.remark].ToString();
            item.termPayment = dt.Rows[0][inv.termPayment].ToString();
            item.year = dt.Rows[0][inv.year].ToString();
            item.month = dt.Rows[0][inv.month].ToString();

            item.recpAmount = config1.NumberNull(dt.Rows[0][inv.recpAmount]);
            item.statusRecp = dt.Rows[0][inv.statusRecp].ToString();
            item.recpDate = dt.Rows[0][inv.recpDate].ToString();
            item.statusDeposit = dt.Rows[0][inv.statusDeposit].ToString();
            item.deposit = dt.Rows[0][inv.deposit].ToString();
            return item;
        }
        public Invoice selectInvoiceByInvNumber(String invNumber)
        {
            Invoice item = new Invoice();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table + " Where " + inv.invNumber + "='" + invNumber + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            
            return item;
        }
        public DataTable selectByYearMonth(String year, String monthName)
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table +
                " Where " + inv.year + "='" + year + "' and " + inv.month + "='" + monthName + "' and " + inv.invActive + " <> '3' " +
                "Order By " + inv.invNumber;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectUnActiveByYearMonth(String year, String monthName)
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table +
                " Where " + inv.year + "='" + year + "' and " + inv.month + "='" + monthName + "' and " + inv.invActive + " = '3' " +
                "Order By " + inv.invNumber;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectUnPayment()
        {
            String curDate = "";
            curDate = config1.getCurrDate();
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table +
                " Where " + inv.dueDate + " < '" + curDate + "' and " 
                + inv.invActive + " = '1' and " + inv.statusRecp + " <> '2' " +
                "Order By " + inv.invNumber;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectPaymentedByYearMonth(String year, String monthName)
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table +
                " Where " + inv.recpDate + " like '%" + year + "-" + monthName + "%' and "
                + inv.invActive + " = '1' and " + inv.statusRecp + " = '2' " +
                "Order By " + inv.invNumber;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectByUnPayment()
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table +
                " Where " + inv.statusRecp + "<>'2' and " + inv.invActive + " = '1' " +
                "Order By " + inv.invNumber;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectCustomerByUnPayment()
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select Distinct " + inv.custId + "," + inv.custName + " From " + inv.table +
                " Where " + inv.statusRecp + "<>'2' and " + inv.invActive + " = '1' " +
                "Order By " + inv.custName;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectByUnPayment(String custId)
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + inv.table +
                " Where " + inv.statusRecp + "<>'2' and " + inv.invActive + " = '1' and " + inv.custId + "='"+ custId + "'" +
                "Order By " + inv.invNumber;
            dt = conn.selectData(sql);
            return dt;
        }
        private String insert(Invoice p)
        {
            String chk = "", sql = "";
            if (p.invId == "")
            {
                p.invId = p.getGenID();
            }
            try
            {
                p.custAddress1 = p.custAddress1.Replace("'", "''");
                p.custAddress2 = p.custAddress2.Replace("'", "''");
                p.custName = p.custName.Replace("'", "''");
                p.invAmountThb = p.invAmountThb.Replace("'", "''");
                p.statusDeposit = "0";
                if (p.recpAmount == "")
                {
                    p.recpAmount = "0";
                }
                if (p.deposit == "")
                {
                    p.deposit = "0";
                }
                
                p.remark = p.remark.Replace("'", "''");
                p.invAmount = p.invAmount.Replace(",", "");
                sql = "Insert Into " + inv.table + "(" + inv.pkField + "," + inv.custAddress1 + "," +
                    inv.custAddress2 + "," + inv.custName + "," +
                    inv.dueDate + "," + inv.invActive + "," +
                    inv.invAmount + "," + inv.invAmountThb + "," +
                    inv.invDate + "," + inv.invNumber + "," +
                    inv.receiptNumber + "," + inv.remark + "," +
                    inv.termPayment+","+inv.year+","+
                    inv.month + ","+inv.recpAmount+","+
                    inv.statusRecp+","+inv.custId+","+
                    inv.remarkReceipt+","+inv.recpDate+","+
                    inv.statusDeposit+","+inv.deposit+")" +
                    "Values('" + p.invId + "','" + p.custAddress1 + "','" +
                    p.custAddress2 + "','" + p.custName + "','" +
                    p.dueDate + "','" + p.invActive + "'," +
                    p.invAmount + ",'" + p.invAmountThb + "','" +
                    p.invDate + "','" + p.invNumber + "','" +
                    p.receiptNumber + "','" + p.remark + "','" +
                    p.termPayment+"','"+p.year+"','"+
                    p.month+"',"+p.recpAmount+",'"+
                    p.statusRecp+"','"+p.custId+"','"+
                    p.remarkReceipt+"','"+p.recpDate+"','"+
                    p.statusDeposit+"',"+p.deposit+ ")";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Invoice");
            }
            finally
            {
            }
            return p.invId;
        }
        public String update(Invoice p)
        {
            String sql = "", chk = "";
            try
            {
                //p.dateModi = DateTime.Now.Year.ToString() + DateTime.Now.ToString("-MM-dd HH:MM");
                p.custAddress1 = p.custAddress1.Replace("'", "''");
                p.custAddress2 = p.custAddress2.Replace("'", "''");
                p.custName = p.custName.Replace("'", "''");
                p.invAmountThb = p.invAmountThb.Replace("'", "''");

                sql = "Update " + inv.table + " Set " + inv.invNumber + "='" + p.invNumber + "'," +
                inv.custAddress1 + "='" + p.custAddress1 + "'," +
                inv.custAddress2 + "='" + p.custAddress2 + "'," +
                inv.custId + "='" + p.custId + "'," +
                inv.custName + "='" + p.custName + "'," +
                inv.dueDate + "='" + p.dueDate + "'," +
                //inv.invActive + "='" + p.invActive + "'," +
                inv.invAmount + "='" + p.invAmount + "'," +
                inv.invAmountThb + "='" + p.invAmountThb + "'," +
                inv.invDate + "='" + p.invDate + "'," +
                //inv.receiptNumber + "='" + p.receiptNumber + "'," +
                inv.remark + "='" + p.remark + "'," +
                inv.termPayment + "='" + p.termPayment + "', " +
                inv.year + "='" + p.year + "', " +
                inv.month + "='" + p.month + "' " +

                "Where " + inv.invId + "='" + p.invId + "'";
                chk = conn.ExecuteNonQuery(sql);
                chk = p.invId;
            }
            catch (Exception ex)
            {

            }
            return chk;
        }
        public String insertInvoice(Invoice p)
        {
            Invoice item = new Invoice();
            String chk = "";
            item = selectInvoiceByPk(p.invId);
            if (item.invId == "")
            {
                p.statusDeposit = "0";
                p.statusRecp = "1";
                chk = insert(p);
            }
            else
            {
                chk = update(p);
            }
            return chk;
        }
        public String deleteAll()
        {
            String sql = "", chk = "";
            sql = "Delete From " + inv.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateRecript(String invNo, String recpNumber, String amount, String recpDate)
        {
            /**
             * 1. Update status จำนวนเงิน ที่รับชำระ โดนการทอนออกจากยอดเก่า และเลขที่ใบเสร็จ
             * 2. Check ยอดคงเหลือ คือ ดึงดูว่า inv_amount <= recp_amount หรือไม่ 
             * */
            Invoice inv1 = new Invoice();
            
            String sql = "", chk = "", remarkReceipt="";
            amount = amount.Replace(",", "");
            remarkReceipt = " [เลขที่ใบเสร็จ="+recpNumber+";จำนวนเงิน="+amount+";"+"วันที่Update="+System.DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss")+"];";
            sql = "Update " + inv.table+" Set "+inv.receiptNumber+" = "+inv.receiptNumber+" + '["+recpNumber+"];', "+
                inv.recpAmount+"="+inv.recpAmount+"+"+amount +", "+
                inv.remarkReceipt + "=" + inv.remarkReceipt + "+'" + remarkReceipt + "', " +
                inv.recpDate + "='" + recpDate + "' " +
                "Where "+inv.invNumber+"='"+invNo+"'";
            chk = conn.ExecuteNonQuery(sql);//1.

            inv1 = selectInvoiceByInvNumber(invNo);//2.
            Double deposit = 0.0, recpAmpount=0.0, invAmount=0.0;
            deposit = Double.Parse(config1.NumberNull(inv1.deposit));
            recpAmpount = Double.Parse(config1.NumberNull(inv1.recpAmount));
            invAmount = Double.Parse(config1.NumberNull(inv1.invAmount));
            if ((recpAmpount + deposit) >= invAmount)// Check ว่าจำนวนเงินที่รับมา มากกว่า inv_amount
            {
                sql = "Update "+inv.table+" Set "+ inv.statusRecp+"='2' "+
                    "Where "+inv.invNumber+"='"+invNo+"'";
                chk = conn.ExecuteNonQuery(sql);//2.
                chk = invIdb.updateStatusReceipt(inv1.invId, recpNumber);
            }
            
            return chk;
        }
        public String updateUnRecript(String invId, String recpNumber, String amount)
        {
            /**
             * 1. Update status จำนวนเงิน ที่รับชำระ โดนการทอนออกจากยอดเก่า และเลขที่ใบเสร็จ
             * 2. Check ยอดคงเหลือ คือ ดึงดูว่า inv_amount <= recp_amount หรือไม่ 
             * */
            Invoice inv1 = new Invoice();

            String sql = "", chk = "", remarkReceipt = "";
            amount = amount.Replace(",", "");
            inv1 = selectInvoiceByPk(invId);//2.
            remarkReceipt = " [ยกเลิกรับชำระ->เลขที่ใบเสร็จ=" + recpNumber + ";จำนวนเงิน=" + amount + ";" + "วันที่Update=" + System.DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss") + "];";
            sql = "Update " + inv.table + " Set " + inv.receiptNumber + " = " + inv.receiptNumber + " + '[ยกเลิกรับชำระ->" + recpNumber + "];', " +
                inv.recpAmount + "=" + inv.recpAmount + "-" + amount + ", " +
                inv.remarkReceipt + "=" + inv.remarkReceipt + "+'" + remarkReceipt + "', " +
                //inv.recpDate + "='" + recpDate + "' " +
                inv.recpDate + "='' " +
                "Where " + inv.invId + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);//1.

            inv1 = selectInvoiceByPk(invId);//2.

            if (Double.Parse(config1.NumberNull(inv1.recpAmount)) <= Double.Parse(config1.NumberNull(inv1.invAmount)))// Check ว่าจำนวนเงินที่รับมา มากกว่า inv_amount
            {
                sql = "Update " + inv.table + " Set " + inv.statusRecp + "='1' " +
                    "Where " + inv.invId + "='" + invId + "'";
                chk = conn.ExecuteNonQuery(sql);//2.
                chk = invIdb.updateStatusUnReceipt(inv1.invId, recpNumber, amount);
            }

            return chk;
        }
        public String updateInvoiceAmount(String invId)
        {
            String amount = "", chk = "", sql="";
            amount = invIdb.selectAmountByInvId(invId);
            amount = config1.NumberNull(amount);
            amount = amount.Replace(",","");
            sql = "Update "+inv.table+" Set "+inv.invAmount+"="+amount+" Where "+inv.pkField+"='"+invId+"'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateDeposit(String invId, String deposit)
        {
            String amount = "", chk = "", sql = "";
            if(deposit.Equals(""))
            {
                deposit = "0";
            }
            sql = "Update " + inv.table + " Set " + inv.deposit + "=" + inv.deposit + "+" + deposit + ","+
                inv.statusDeposit+"='1' "+
                " Where " + inv.pkField + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateUnDeposit(String invId, String deposit)
        {
            String amount = "", chk = "", sql = "";
            if (deposit.Equals(""))
            {
                deposit = "0";
            }
            deposit = deposit.Replace(",", "");
            sql = "Update " + inv.table + " Set " + inv.deposit + "=" + inv.deposit + "-" + deposit + "," +
                inv.statusDeposit + "='3', " +inv.log+"="+inv.log+"+'ยกเลิก deposit;'"+
                " Where " + inv.pkField + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateUnActive(String invId)
        {
            String amount = "", chk = "", sql = "";
            //amount = invIdb.selectAmountByInvId(invId);
            //amount = config1.NumberNull(amount);
            //amount = amount.Replace(",", "");
            sql = "Update " + inv.table + " Set " + inv.invActive + "='3' Where " + inv.pkField + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String genInvNumber()
        {
            String sql = "", row = "", invNumber = "", year="";
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From "+inv.table;
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                row = "000000"+dt.Rows[0]["cnt"].ToString();
            }
            year = System.DateTime.Now.Year.ToString().Substring(2);
            invNumber = "DSG" + year + "-" + row.Substring(row.Length-4);
            return invNumber;
        }
        public ComboBox getCboCustUnPayment(ComboBox c)
        {
            String txt = "";
            ComboBoxItem item;
            DataTable dt = new DataTable();
            dt = selectCustomerByUnPayment();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt = dt.Rows[i][inv.custName].ToString();
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][inv.custId].ToString();
                item.Text = txt;
                c.Items.Add(item);
            }
            return c;
        }
        public ComboBox getCboInvUnPayment(ComboBox c)
        {
            String txt = "";
            ComboBoxItem item;
            DataTable dt = new DataTable();
            dt = selectByUnPayment();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt = dt.Rows[i][inv.custName].ToString() + "-" + dt.Rows[i][inv.invNumber].ToString() + "-" + config1.NumberNull(dt.Rows[i][inv.invAmount]);
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][inv.invNumber].ToString();
                item.Text = txt;
                c.Items.Add(item);
            }
            return c;
        }
        public ComboBox getCboInvUnPayment1(ComboBox c)
        {
            String txt = "";
            ComboBoxItem item;
            DataTable dt = new DataTable();
            dt = selectByUnPayment();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt = dt.Rows[i][inv.custName].ToString() + "-" + dt.Rows[i][inv.invNumber].ToString() + "-" + config1.NumberNull(dt.Rows[i][inv.invAmount]);
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][inv.invId].ToString();
                item.Text = txt;
                c.Items.Add(item);
            }
            return c;
        }
        public ComboBox getCboInvUnPayment1(ComboBox c, String custId)
        {
            String txt = "";
            ComboBoxItem item;
            DataTable dt = new DataTable();
            c.Items.Clear();
            dt = selectByUnPayment(custId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt = dt.Rows[i][inv.custName].ToString() + "-" + dt.Rows[i][inv.invNumber].ToString() + "[จำนวนเงิน " + config1.NumberNull(dt.Rows[i][inv.invAmount]) + "]";
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][inv.invNumber].ToString();
                item.Text = txt;
                c.Items.Add(item);
            }
            return c;
        }
        public ComboBox getCboInvUnPayment(ComboBox c, String custId)
        {
            String txt = "";
            ComboBoxItem item;
            DataTable dt = new DataTable();
            c.Items.Clear();
            dt = selectByUnPayment(custId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txt = dt.Rows[i][inv.custName].ToString() + "-" + dt.Rows[i][inv.invNumber].ToString() + "[จำนวนเงิน " + config1.NumberNull(dt.Rows[i][inv.invAmount])+"]";
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][inv.invId].ToString();
                item.Text = txt;
                c.Items.Add(item);
            }
            return c;
        }
        public String getInvDesp(String invId)
        {
            DataTable dt = new DataTable();
            String txt = "";
            Invoice inv = selectInvoiceByPk(invId);
            
            txt = inv.custName + "-" +inv.invNumber + "[จำนวนเงิน " + config1.NumberNull(inv.invAmount) + "]";
            
            return txt;
        }
    }
}
