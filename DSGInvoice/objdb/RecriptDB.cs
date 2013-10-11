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
    class RecriptDB
    {
        private ConnectDB conn;
        public Recript recp;
        public RecriptItemDB recpIdb;
        public RecriptDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            recp = new Recript();
            recpIdb = new RecriptItemDB(conn);
            recp.custId = "cust_id";
            recp.recpActive = "recp_active";
            recp.recpAmount = "recp_amount";
            recp.recpAmountThb = "recp_amount_thb";
            recp.recpDate = "recp_date";
            recp.recpId = "recp_id";
            recp.recpNumber = "recp_number";
            recp.remark = "remark";
            recp.year = "year1";
            recp.month = "month1";
            recp.custName = "cust_name";
            recp.statusRecepitAll = "status_receipt_all";
            recp.invNumber = "inv_number";

            recp.pkField = "recp_id";
            recp.sited = "";
            recp.table = "t_recript";
        }
        private Recript setData(Recript item, DataTable dt)
        {
            item.custId = dt.Rows[0][recp.custId].ToString();
            item.recpActive = dt.Rows[0][recp.recpActive].ToString();
            item.recpAmount = dt.Rows[0][recp.recpAmount].ToString();
            item.recpAmountThb = dt.Rows[0][recp.recpAmountThb].ToString();
            item.recpDate = dt.Rows[0][recp.recpDate].ToString();
            item.recpId = dt.Rows[0][recp.recpId].ToString();
            item.recpNumber = dt.Rows[0][recp.recpNumber].ToString();
            item.remark = dt.Rows[0][recp.remark].ToString();
            item.year = dt.Rows[0][recp.year].ToString();
            item.month = dt.Rows[0][recp.month].ToString();
            item.custName = dt.Rows[0][recp.custName].ToString();
            item.statusRecepitAll = dt.Rows[0][recp.statusRecepitAll].ToString();
            item.invNumber = dt.Rows[0][recp.invNumber].ToString();
            return item;
        }
        public Recript selectRecriptByPk(String recpId)
        {
            Recript item = new Recript();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + recp.table + " Where " + recp.pkField + "='" + recpId + "'";
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
            sql = "Select * From " + recp.table +
                " Where " + recp.year + "='" + year + "' and " + recp.month + "='" + monthName + "' and " + recp.recpActive + " = '1' " +
                "Order By " + recp.recpNumber;
            dt = conn.selectData(sql);
            return dt;
        }
        private String insert(Recript p)
        {
            String chk = "", sql = "";
            if (p.recpId == "")
            {
                p.recpId = p.getGenID();
            }
            try
            {
                p.remark = p.remark.Replace("'", "''");
                p.recpAmount = p.recpAmount.Replace(",", "");
                sql = "Insert Into "+recp.table+"("+recp.pkField+","+recp.custId+","+
                    recp.recpActive+","+recp.recpAmount+","+
                    recp.recpAmountThb+","+recp.recpDate+","+
                    recp.recpNumber+","+recp.remark+","+
                    recp.month+","+recp.year+","+
                    recp.custName+","+recp.statusRecepitAll+","+
                    recp.invNumber+") "+
                    "Values('" + p.recpId + "','" + p.custId + "','" +
                    p.recpActive + "'," + p.recpAmount + ",'" +
                    p.recpAmountThb + "','" + p.recpDate + "','" +
                    p.recpNumber + "','" + p.remark+"','"+
                    p.month+"','"+p.year+"','"+
                    p.custName+"','"+p.statusRecepitAll+"','"+
                    p.invNumber+ "') ";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Receipt");
            }
            finally
            {
            }
            return p.recpId;
        }
        public String update(Recript p)
        {
            String sql = "", chk = "";
            try
            {
                //p.dateModi = DateTime.Now.Year.ToString() + DateTime.Now.ToString("-MM-dd HH:MM");
                p.remark = p.remark.Replace("'", "''");

                sql = "Update " + recp.table + " Set " + recp.custId + "='" + p.custId + "'," +
                recp.recpAmount + "='" + p.recpAmount + "'," +
                recp.recpAmountThb + "='" + p.recpAmountThb + "'," +
                recp.recpDate + "='" + p.recpDate + "'," +
                recp.recpNumber + "='" + p.recpNumber + "'," +
                recp.remark + "='" + p.remark + "', " +
                recp.month + "='" + p.month + "', " +
                recp.year + "='" + p.year + "', " +
                recp.custName + "='" + p.custName + "' " + 

                "Where " + recp.recpId + "='" + p.recpId + "'";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "Update Receipt");
            }
            return chk;
        }
        public String insertRecript(Recript p)
        {
            Recript item = new Recript();
            String chk = "";
            item = selectRecriptByPk(p.recpId);
            if (item.recpId == "")
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
            sql = "Delete From " + recp.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String genRecriptNumber()
        {
            String sql = "", row = "", invNumber = "", year = "";
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + recp.table;
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                row = "000000" + dt.Rows[0]["cnt"].ToString();
            }
            year = System.DateTime.Now.Year.ToString().Substring(2);
            invNumber = "DSG" + year + row.Substring(row.Length - 4);
            return invNumber;
        }
        public String updateUnActive(String recpId)
        {
            String amount = "", chk = "", sql = "";
            //amount = invIdb.selectAmountByInvId(invId);
            //amount = config1.NumberNull(amount);
            //amount = amount.Replace(",", "");
            sql = "Update " + recp.table + " Set " + recp.recpActive + "='3' Where " + recp.pkField + "='" + recpId + "'";
            chk = conn.ExecuteNonQuery(sql);
            recpIdb.updateUnActive(recpId);


            return chk;
        }
    }
}
