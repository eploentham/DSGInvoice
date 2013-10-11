using DSGInvoice.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSGInvoice.objdb
{
    class DepositDB
    {
        public Deposit dep;
        ConnectDB conn;
        Config1 config1;
        public DepositDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        public void initConfig()
        {
            config1 = new Config1();
            dep = new Deposit();
            dep.depositActive="deposit_active";
            dep.depositDate = "deposit_date";
            dep.depositId = "deposit_id";
            dep.description = "description";
            dep.invId = "inv_id";
            dep.remark = "remark";
            dep.deposit = "deposit";
            dep.statusDeposit = "status_deposit";
            dep.custId = "cust_id";
            dep.custName = "cust_name";
            dep.invNumber = "inv_number";
            dep.recpNumber = "recp_number";

            dep.table = "t_deposit";
            dep.pkField = "deposit_id";
            
        }
        public Deposit selectDepositByPk(String depId)
        {
            Deposit item = new Deposit();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + dep.table + " Where " + dep.pkField + "='" + depId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private Deposit setData(Deposit item, DataTable dt)
        {
            item.depositActive = dt.Rows[0][dep.depositActive].ToString();
            item.depositDate = dt.Rows[0][dep.depositDate].ToString();
            item.depositId = dt.Rows[0][dep.depositId].ToString();
            item.description = dt.Rows[0][dep.description].ToString();
            item.invId = dt.Rows[0][dep.invId].ToString();
            item.deposit = dt.Rows[0][dep.deposit].ToString();
            item.statusDeposit = dt.Rows[0][dep.statusDeposit].ToString();
            item.custId = dt.Rows[0][dep.custId].ToString();
            item.custName = dt.Rows[0][dep.custName].ToString();
            item.invNumber = dt.Rows[0][dep.invNumber].ToString();
            item.recpNumber = dt.Rows[0][dep.recpNumber].ToString();

            return item;
        }
        private String insert(Deposit p)
        {
            String chk = "", sql="";
            if (p.depositId == "")
            {
                p.depositId = p.getGenID();
            }
            try
            {
                p.description= p.description.Replace("'","''");
                p.remark = p.remark.Replace("'", "''");
                p.custName = p.custName.Replace("'", "''");
                p.deposit = p.deposit.Replace(",", "");
                if (p.statusDeposit.Equals(""))
                {
                    p.statusDeposit = "1";
                }
                sql = "Insert Into " + dep.table + "(" + dep.pkField + "," + dep.depositActive + "," +
                    dep.depositDate + "," + dep.description + "," +
                    dep.invId + "," + dep.remark+","+
                    dep.deposit+","+dep.statusDeposit+","+
                    dep.custId+","+dep.invNumber+","+
                    dep.custName + ")" +
                    "Values ('" + p.depositId + "','" + p.depositActive + "','" +
                    p.depositDate + "','" + p.description + "','" +
                    p.invId + "','" + p.remark+"',"+
                    p.deposit+",'"+p.statusDeposit+"','"+
                    p.custId + "','" + p.invNumber + "','" + 
                    p.custName + "')";
                chk = conn.ExecuteNonQuery(sql);
                chk = p.depositId;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert Deposit");
            }
            finally
            {
            }
            return chk;
        }
        public String update(Deposit p)
        {
            String chk = "", sql = "";
            try
            {
                p.description = p.description.Replace("'", "''");
                p.remark = p.remark.Replace("'", "''");
                p.custName = p.custName.Replace("'", "''");
                p.deposit = p.deposit.Replace(",", "");
                sql = "Update "+dep.table+" Set "+ dep.depositDate+"='"+p.depositDate+"',"+
                    dep.description+"='"+p.description+"', "+
                    dep.invId+"='"+p.invId+"',"+
                    dep.remark+"='"+p.remark+"', "+
                    dep.deposit + "=" + p.deposit + ", " +
                    dep.custId + "='" + p.custId + "', " +
                    dep.custName + "='" + p.custName + "', " +
                    dep.invNumber + "='" + p.invNumber + "' " +
                    "Where "+dep.pkField+"='"+p.depositId+"'";
                chk = conn.ExecuteNonQuery(sql);
                chk = p.depositId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Deposit");
            }
            finally
            {
            }
            return chk;
        }
        public String insertDeposit(Deposit p)
        {
            String chk = "";
            Deposit item = new Deposit();
            item = selectDepositByPk(p.depositId);
            if (item.depositId == "")
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
            sql = "Delete From " + dep.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateUnActive(String depositId)
        {
            String sql = "", chk = "";
            sql = "Update " + dep.table+" Set "+dep.depositActive+"='3' Where "+dep.pkField+"='"+depositId+"'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String updateStatusDeposit(String invId, String recpNumber)
        {
            String sql = "", chk = "";
            sql = "Update " + dep.table + " Set " + dep.statusDeposit + "='1' Where " + dep.invId + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        /**
         * ใช้เพื่อ update status ว่าจำนวนเงินได้ถูก ใช้ไปตอนหน้าจอรับชำระ
         **/
        public String updateStatusDepositClear(String invId, String recpNumber)
        {
            String sql = "", chk = "";
            sql = "Update " + dep.table + " Set " + dep.statusDeposit + "='2' Where " + dep.invId + "='" + invId + "'";
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
        public String selectSumDepositByInvId(String invId)
        {
            //Deposit item = new Deposit();
            String sql = "", cnt="0";
            DataTable dt = new DataTable();
            sql = "Select sum("+dep.deposit+") as cnt From " + dep.table 
                + " Where " + dep.invId + "='" + invId + "' and "+dep.depositActive+"='1' and "+dep.statusDeposit+" <>'2'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = dt.Rows[0]["cnt"].ToString();
            }
            cnt = config1.NumberNull(cnt);
            return cnt;
        }
        public String selectSumDepositByInvId2(String invId)
        {
            //Deposit item = new Deposit();
            String sql = "", cnt = "0";
            DataTable dt = new DataTable();
            sql = "Select sum(" + dep.deposit + ") as cnt From " + dep.table
                + " Where " + dep.invId + "='" + invId + "' and " + dep.depositActive + "='1' and " + dep.statusDeposit + " ='2'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cnt = dt.Rows[0]["cnt"].ToString();
            }
            cnt = config1.NumberNull(cnt);
            return cnt;
        }
        public DataTable selectByInvId(String invId)
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + dep.table +
                " Where " + dep.statusDeposit + "<>'2' and " + dep.depositActive + " = '1' and " + dep.invId + "='" + invId + "' " +
                "Order By " + dep.depositDate;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectByCustId(String custId)
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + dep.table +
                " Where " + dep.statusDeposit + "<>'2' and " + dep.depositActive + " = '1' and " + dep.custId + "='" + custId + "'" +
                "Order By " + dep.depositDate;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectAll()
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + dep.table +
                " Where " + dep.depositActive + " <> '3' " +
                "Order By " + dep.depositDate;
            dt = conn.selectData(sql);
            return dt;
        }
        public DataTable selectUnActiveAll()
        {
            String sql = "", chk = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + dep.table +
                " Where " + dep.depositActive + " = '3' " +
                "Order By " + dep.depositDate;
            dt = conn.selectData(sql);
            return dt;
        }
    }
}
