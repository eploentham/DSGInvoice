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
    class RecriptItemDB
    {
        ConnectDB conn;
        public RecriptItem recpI;
        public RecriptItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        public void initConfig()
        {
            recpI = new RecriptItem();
            recpI.amount = "amount";
            recpI.description = "description";
            recpI.invDate = "inv_date";
            recpI.invNumber = "inv_number";
            recpI.recpId = "recp_id";
            recpI.recpItemActive = "recp_item_active";
            recpI.recpItemId = "recp_item_id";
            recpI.recpItemRow = "recp_item_row";
            recpI.remark = "remark";
            recpI.invId = "inv_id";
            recpI.amount1 = "amount1";
            recpI.deposit = "deposit";
            recpI.recpAmount = "recp_amount";
            recpI.invAmount = "inv_amount";

            recpI.sited = "";
            recpI.table = "t_recript_item";
            recpI.pkField = "recp_item_id";
        }
        public RecriptItem selectRecriptItemByPk(String recpItemId)
        {
            RecriptItem item = new RecriptItem();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + recpI.table + " Where " + recpI.pkField + "='" + recpItemId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item.amount = dt.Rows[0][recpI.amount].ToString();
                item.description = dt.Rows[0][recpI.description].ToString();
                item.invDate = dt.Rows[0][recpI.invDate].ToString();
                item.invNumber = dt.Rows[0][recpI.invNumber].ToString();
                item.recpId = dt.Rows[0][recpI.recpId].ToString();
                item.recpItemActive = dt.Rows[0][recpI.recpItemActive].ToString();
                item.recpItemId = dt.Rows[0][recpI.recpItemId].ToString();
                item.recpItemRow = dt.Rows[0][recpI.recpItemRow].ToString();
                item.remark = dt.Rows[0][recpI.remark].ToString();
                item.invId = dt.Rows[0][recpI.invId].ToString();

                item.amount1 = dt.Rows[0][recpI.amount1].ToString();
                item.deposit = dt.Rows[0][recpI.deposit].ToString();
                item.recpAmount = dt.Rows[0][recpI.recpAmount].ToString();
                item.invAmount = dt.Rows[0][recpI.invAmount].ToString();
            }
            return item;
        }
        public DataTable selectReceiptItemByRecpId(String recepId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + recpI.table + " Where " + recpI.recpId + "='" + recepId + "'";
            dt = conn.selectData(sql);
            return dt;
        }
        private String insert(RecriptItem p)
        {
            String chk = "", sql = "";
            if (p.recpItemId == "")
            {
                p.recpItemId = p.getGenID();
            }
            try
            {
                p.remark = p.remark.Replace("'", "''");
                p.amount = p.amount.Replace(",", "");
                p.amount1 = p.amount1.Replace(",", "");
                p.deposit = p.deposit.Replace(",", "");
                p.invAmount = p.invAmount.Replace(",", "");
                p.recpAmount = p.recpAmount.Replace(",", "");
                p.description = p.description.Replace("''", "'");
                if(p.amount1.Equals(""))
                {
                    p.amount1 = "0";
                }
                if (p.deposit.Equals(""))
                {
                    p.deposit = "0";
                }
                if (p.invAmount.Equals(""))
                {
                    p.invAmount = "0";
                }
                if (p.recpAmount.Equals(""))
                {
                    p.recpAmount = "0";
                }
                if (p.amount.Equals(""))
                {
                    p.amount = "0";
                }
                sql = "Insert Into " + recpI.table + "(" + recpI.pkField + "," + recpI.amount + "," +
                    recpI.description + "," + recpI.invDate + "," +
                    recpI.invNumber + "," + recpI.recpId + "," +
                    recpI.recpItemActive + "," + recpI.recpItemRow + ", " +
                    recpI.remark+","+recpI.invId+","+
                    recpI.amount1+","+recpI.deposit+","+
                    recpI.invAmount+","+recpI.recpAmount + ") " +
                    "Values('" + p.recpItemId + "'," + p.amount + ",'" +
                    p.description + "','" + p.invDate + "','" +
                    p.invNumber + "','" + p.recpId + "','" +
                    p.recpItemActive + "','" + p.recpItemRow + "','" +
                    p.remark+"','"+p.invId+"',"+
                    p.amount1+","+p.deposit+","+
                    p.invAmount+","+p.recpAmount + ") ";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                chk = "";
                MessageBox.Show("Error " + ex.ToString(), "insert receipt item");
            }
            finally
            {
            }
            return p.recpItemId;
        }
        public String update(RecriptItem p)
        {
            String sql = "", chk = "";
            try
            {
                //p.dateModi = DateTime.Now.Year.ToString() + DateTime.Now.ToString("-MM-dd HH:MM");
                p.remark = p.remark.Replace("''", "'");
                p.description = p.description.Replace("''", "'");

                sql = "Update " + recpI.table + " Set " + recpI.amount + "='" + p.amount + "'," +
                recpI.description + "='" + p.description + "'," +
                recpI.invDate + "='" + p.invDate + "'," +
                recpI.invNumber + "='" + p.invNumber + "'," +
                recpI.recpId + "='" + p.recpId + "'," +
                recpI.recpItemActive + "='" + p.recpItemActive + "', " +
                recpI.recpItemRow + "='" + p.recpItemRow + "', " +
                recpI.invId + "='" + p.invId + "', " +
                recpI.remark + "='" + p.remark + "' " +

                "Where " + recpI.pkField + "='" + p.recpItemId + "'";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "Update receipt item");
            }
            return chk;
        }
        public String insertRecriptItem(RecriptItem p)
        {
            RecriptItem item = new RecriptItem();
            String chk = "";
            item = selectRecriptItemByPk(p.recpItemId);
            if (item.recpItemId == "")
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
            sql = "Delete From " + recpI.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateUnActive(String recpId)
        {
            String amount = "", chk = "", sql = "";
            //amount = invIdb.selectAmountByInvId(invId);
            //amount = config1.NumberNull(amount);
            //amount = amount.Replace(",", "");
            sql = "Update " + recpI.table + " Set " + recpI.recpItemActive + "='3' Where " + recpI.recpId + "='" + recpId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
