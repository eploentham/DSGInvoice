using DSGInvoice.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGInvoice.objdb
{
    class InvoiceItemDB
    {
        ConnectDB conn;
        public InvoiceItem invI;
        public InvoiceItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            invI = new InvoiceItem();
            invI.amount = "amount";
            invI.description = "description";
            invI.invId = "inv_id";
            invI.invItemActive = "inv_item_active";
            invI.invItemId = "inv_item_id";
            invI.invItemRow = "inv_item_row";
            invI.price = "price";
            invI.qty = "qty";
            invI.remark = "remark";
            invI.qtyUnit = "qty_unit";
            invI.statusRecp = "status_recp";
            invI.recpAmount = "recp_amount";
            invI.recpNumber = "recp_number";
            invI.statusPayment = "status_payment";

            invI.pkField = "inv_item_id";
            invI.sited = "";
            invI.table = "t_invoice_item";
        }
        private InvoiceItem setData(InvoiceItem item, DataTable dt)
        {
            item.amount = dt.Rows[0][invI.amount].ToString();
            item.description = dt.Rows[0][invI.description].ToString();
            item.invId = dt.Rows[0][invI.invId].ToString();
            item.invItemActive = dt.Rows[0][invI.invItemActive].ToString();
            item.invItemId = dt.Rows[0][invI.invItemId].ToString();
            item.invItemRow = dt.Rows[0][invI.invItemRow].ToString();
            item.price = dt.Rows[0][invI.price].ToString();
            item.qty = dt.Rows[0][invI.qty].ToString();
            item.remark = dt.Rows[0][invI.remark].ToString();
            item.qtyUnit = dt.Rows[0][invI.qtyUnit].ToString();
            item.recpAmount = dt.Rows[0][invI.recpAmount].ToString();
            item.statusRecp = dt.Rows[0][invI.statusRecp].ToString();
            item.statusPayment = dt.Rows[0][invI.statusPayment].ToString();
            return item;
        }
        public InvoiceItem selectInvoiceItemByPk(String invItemId)
        {
            InvoiceItem item = new InvoiceItem();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + invI.table + " Where " + invI.pkField + "='" + invItemId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public String selectAmountByInvId(String invId)
        {
            //Customer item = new Customer();
            String sql = "", row = "";
            DataTable dt = new DataTable();
            sql = "Select sum("+invI.amount+") as "+invI.amount+
                " From " + invI.table + 
                " Where " + invI.invId + "='" + invId + "' and " + invI.invItemActive + "='1' ";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0][invI.amount].ToString();
            }
            return row;
        }
        public DataTable selectByInvId(String invId)
        {
            //Customer item = new Customer();
            String sql = "", row = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + invI.table + " "+
                "Where "+invI.invId+"='"+invId+ "' and "+invI.invItemActive + "='1' Order By " + invI.invItemRow;
            dt = conn.selectData(sql);

            return dt;
        }
        private String insert(InvoiceItem p)
        {
            String chk = "", sql = "";
            if (p.invItemId == "")
            {
                p.invItemId = p.getGenID();
            }
            try
            {
                if (p.recpAmount == "")
                {
                    p.recpAmount = "0";
                }
                p.remark = p.remark.Replace("'", "''");
                p.description = p.description.Replace("'", "''");
                p.amount = p.amount.Replace(",", "");
                p.qty = p.qty.Replace(",", "");
                p.price = p.price.Replace(",", "");
                sql = "Insert Into " + invI.table + "(" + invI.pkField + "," + invI.amount + "," +
                    invI.description + "," + invI.invId + "," +
                    invI.invItemActive + "," + invI.invItemRow + "," +
                    invI.price + "," + invI.qty + ", " +
                    invI.remark + "," + invI.qtyUnit + ","+
                    invI.recpAmount+","+invI.statusRecp+","+
                    invI.statusPayment+","+invI.recpNumber+") " +
                    "Values('" + p.invItemId + "'," + p.amount + ",'" +
                    p.description + "','" + p.invId + "','" +
                    p.invItemActive + "','" + p.invItemRow + "'," +
                    p.price + "," + p.qty + ",'"+
                    p.remark + "','" + p.qtyUnit+"',"+
                    p.recpAmount+",'0','"+
                    "0','') ";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
            return p.invItemId;
        }
        public String update(InvoiceItem p)
        {
            String sql = "", chk = "";
            try
            {
                //p.dateModi = DateTime.Now.Year.ToString() + DateTime.Now.ToString("-MM-dd HH:MM");
                p.remark = p.remark.Replace("''", "'");
                p.description = p.description.Replace("''", "'");

                sql = "Update " + invI.table + " Set " + invI.amount + "='" + p.amount + "'," +
                invI.description + "='" + p.description + "'," +
                invI.invId + "='" + p.invId + "'," +
                invI.invItemRow + "='" + p.invItemRow + "'," +
                invI.price + "='" + p.price + "'," +
                invI.qty + "='" + p.qty + "', " +
                invI.remark + "='" + p.remark + "', " +
                invI.qtyUnit + "='" + p.qtyUnit + "' " +

                "Where " + invI.pkField + "='" + p.invItemId + "'";
                chk = conn.ExecuteNonQuery(sql);
                chk = p.invItemId;
            }
            catch (Exception ex)
            {

            }
            return chk;
        }
        public String insertInvoiceItem(InvoiceItem p)
        {
            InvoiceItem item = new InvoiceItem();
            String chk = "";
            item = selectInvoiceItemByPk(p.invItemId);
            if (item.invItemId == "")
            {
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
            sql = "Delete From " + invI.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateStatusReceipt(String invId, String recpNumber)
        {
            String sql = "", chk = "";
            //InvoiceItem item = new InvoiceItem();
            //item = selectByInvId(invId);

            //amount = amount.Replace(",", "");
            sql = "Update " + invI.table + " Set " + invI.statusRecp + "='2', "
                //+invI.recpAmount+" ="+invI.recpAmount+"+"+amount+", "
                + invI.recpNumber + "=" + invI.recpNumber + "+'[" + recpNumber + "];' " +
                "Where " + invI.invId + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateRecpAmount(String invId, String recpNumber, String amount)
        {
            String sql = "", chk="";
            //InvoiceItem item = new InvoiceItem();
            //item = selectByInvId(invId);

            amount = amount.Replace(",", "");
            sql = "Update "+invI.table+" Set  "
                + invI.recpAmount + " =" + invI.recpAmount + "+" + amount + " "+
                //+invI.recpNumber+"="+invI.recpNumber+"+'["+recpNumber+"];' "+
                "Where " + invI.invId + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateStatusUnReceipt(String invId, String recpNumber, String amount)
        {
            String sql = "", chk = "";
            //InvoiceItem item = new InvoiceItem();
            //item = selectByInvId(invId);

            amount = amount.Replace(",", "");
            sql = "Update " + invI.table + " Set " + invI.statusRecp + "='1', "
                + invI.recpAmount + " =" + invI.recpAmount + "-" + amount + ", "
                + invI.recpNumber + "=" + invI.recpNumber + "+'[ยกเลิกรับชำระ->" + recpNumber + "];' " +
                "Where " + invI.invId + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateStatusPaymentSplit(String invId)
        {
            String sql = "", chk = "";
            //InvoiceItem item = new InvoiceItem();
            //item = selectByInvId(invId);
            sql = "Update " + invI.table + " Set " + invI.statusPayment + "='2'  "+
                "Where " + invI.invId + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
