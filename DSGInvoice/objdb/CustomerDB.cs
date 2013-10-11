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
    class CustomerDB
    {
        private ConnectDB conn;
        public Customer cust;
        public ComboBoxItem cboI;
        public CustomerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cboI = new ComboBoxItem();
            cust = new Customer();
            cust.custActive = "cust_active";
            cust.custAddress1 = "cust_address1";
            cust.custAddress2 = "cust_address2";
            cust.custAmphur = "cust_amphur";
            cust.custChangwat = "cust_changwat";
            cust.custHouse = "cust_house";
            cust.custId = "cust_id";
            cust.custMoo = "cust_moo";
            cust.custName = "cust_name";
            cust.custNamet = "cust_namet";
            cust.custNumber = "cust_number";
            cust.custRoad = "cust_road";
            cust.custTambon = "cust_tambon";
            cust.description = "description";
            cust.email = "email";
            cust.fax = "fax";
            cust.messageContact = "message_contact";
            cust.messageMarketing = "message_marketing";
            cust.postCode = "post_code";
            cust.remark = "remark";
            cust.sort1 = "sort1";
            cust.telephone = "telephone";
            cust.custTypeNumber = "cust_type_number";
            cust.termPayment = "term_payment";

            cust.table = "b_customer";
            cust.sited = "";
            cust.pkField = "cust_id";
        }
        public Customer selectCustomerByPk(String custId)
        {
            Customer item = new Customer();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cust.table + 
                " Where " + cust.pkField + "='" + custId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public ComboBoxItem selectComboBoxItemByPk(String custId)
        {
            Customer item = new Customer();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cust.table +
                " Where " + cust.pkField + "='" + custId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                cboI = new ComboBoxItem();
                cboI.Value = dt.Rows[0][cust.custId].ToString();
                cboI.Text = dt.Rows[0][cust.custName].ToString();
            }
            return cboI;
        }
        public Customer selectCustomerByName(String custName)
        {
            Customer item = new Customer();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cust.table + " Where " + cust.custName + " like '%" + custName + "%'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        private Customer setData(Customer item, DataTable dt)
        {
            item.custActive = dt.Rows[0][cust.custActive].ToString();
            item.custAddress1 = dt.Rows[0][cust.custAddress1].ToString();
            item.custAddress2 = dt.Rows[0][cust.custAddress2].ToString();
            item.custAmphur = dt.Rows[0][cust.custAmphur].ToString();
            item.custChangwat = dt.Rows[0][cust.custChangwat].ToString();
            item.custHouse = dt.Rows[0][cust.custHouse].ToString();
            item.custId = dt.Rows[0][cust.custId].ToString();
            item.custMoo = dt.Rows[0][cust.custMoo].ToString();
            item.custName = dt.Rows[0][cust.custName].ToString();
            item.custNamet = dt.Rows[0][cust.custNamet].ToString();
            item.custNumber = dt.Rows[0][cust.custNumber].ToString();
            item.custRoad = dt.Rows[0][cust.custRoad].ToString();
            item.custTambon = dt.Rows[0][cust.custTambon].ToString();
            item.description = dt.Rows[0][cust.description].ToString();
            item.email = dt.Rows[0][cust.email].ToString();
            item.fax = dt.Rows[0][cust.fax].ToString();
            item.messageContact = dt.Rows[0][cust.messageContact].ToString();
            item.messageMarketing = dt.Rows[0][cust.messageMarketing].ToString();
            item.postCode = dt.Rows[0][cust.postCode].ToString();
            item.remark = dt.Rows[0][cust.remark].ToString();
            item.sort1 = dt.Rows[0][cust.sort1].ToString();
            item.telephone = dt.Rows[0][cust.telephone].ToString();
            item.custTypeNumber = dt.Rows[0][cust.custTypeNumber].ToString();
            item.termPayment = dt.Rows[0][cust.termPayment].ToString();
            return item;
        }
        public String selectCustNumberMax()
        {
            //Customer item = new Customer();
            String sql = "", row="";
            DataTable dt = new DataTable();
            sql = "Select count(1) as cnt From " + cust.table + " ";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0]["cnt"].ToString();
            }
            return row;
        }
        public DataTable selectCust()
        {
            //Customer item = new Customer();
            String sql = "", row = "";
            DataTable dt = new DataTable();
            sql = "Select "+cust.custId+", "+cust.custName+
                " From " + cust.table + 
                " Where "+cust.custActive+"='1' Order By "+cust.custName;
            dt = conn.selectData(sql);
            
            return dt;
        }
        public DataTable selectCust(String custName)
        {
            //Customer item = new Customer();
            String sql = "", row = "";
            DataTable dt = new DataTable();
            sql = "Select " + cust.custName + " From " + cust.table + " Where " + cust.custName + " like '" + custName + "%' Order By " + cust.custName;
            dt = conn.selectData(sql);

            return dt;
        }
        //public Customer selectCust(String custName)
        //{
        //    Customer item = new Customer();
        //    String sql = "", row = "";
        //    DataTable dt = new DataTable();
        //    sql = "Select " + cust.custName + " From " + cust.table + " Where " + cust.custName + " like '" + custName + "%' Order By " + cust.custName;
        //    dt = conn.selectData(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        item = setData(item, dt);
        //    }
        //    return item;
        //}
        public DataTable selectCustAll(String custName)
        {
            //Customer item = new Customer();
            String sql = "", row = "";
            DataTable dt = new DataTable();
            if (custName == "")
            {
                sql = "Select * From " + cust.table + " Where " + cust.custActive + "='1' Order By " + cust.custName;
            }
            else
            {
                sql = "Select * From " + cust.table + " Where " + cust.custName + " like '" + custName + "%' Order By " + cust.custName;
            }
            
            dt = conn.selectData(sql);

            return dt;
        }
        public DataTable selectCustAll()
        {
            //Customer item = new Customer();
            String sql = "", row = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + cust.table + " Where " + cust.custActive + "='1' Order By " + cust.custName;
            dt = conn.selectData(sql);

            return dt;
        }
        public ComboBox getCboCustomer(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectCust();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][cust.custId].ToString();
                item.Text = dt.Rows[i][cust.custName].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            return c;
        }
        public ComboBox getCboCustomer()
        {
            ComboBox c = new ComboBox();
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectCust();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ComboBoxItem();
                item.Value = dt.Rows[i][cust.custId].ToString();
                item.Text = dt.Rows[i][cust.custName].ToString();
                c.Items.Add(item);
                //c.Items.Add(new );
            }
            return c;
        }
        
        private String insert(Customer p)
        {
            String chk = "", sql="";
            if (p.custId=="")
            {
                p.custId = p.getGenID();
                p.custNumber = "000000000000"+selectCustNumberMax();
                p.custNumber = p.custNumber.Substring(p.custNumber.Length - 5);
            }
            try
            {
                p.custHouse = p.custHouse.Replace("''", "'");
                p.custMoo = p.custMoo.Replace("''", "'");
                p.custName = p.custName.Replace("''", "'");
                p.custNamet = p.custNamet.Replace("''", "'");
                p.custRoad = p.custRoad.Replace("''", "'");
                p.description = p.description.Replace("''", "'");
                p.messageContact = p.messageContact.Replace("''", "'");
                p.messageMarketing = p.messageMarketing.Replace("''", "'");
                p.remark = p.remark.Replace("''", "'");
                p.custAddress1 = p.custAddress1.Replace("''", "'");
                p.custAddress2 = p.custAddress2.Replace("''", "'");
                sql = "Insert Into "+cust.table+"("+cust.pkField+","+cust.custActive+","+
                    cust.custAddress1+","+cust.custAddress2+","+
                    cust.custAmphur+","+cust.custChangwat+","+
                    cust.custHouse+","+cust.custMoo+","+
                    cust.custName+","+cust.custNamet+","+
                    cust.custNumber+","+cust.custRoad+","+
                    cust.custTambon+","+cust.description+","+
                    cust.email+","+cust.fax+","+
                    cust.messageContact+","+cust.messageMarketing+","+
                    cust.postCode+","+cust.remark+","+
                    cust.sort1+","+cust.telephone+","+
                    cust.custTypeNumber+","+cust.termPayment+")"+
                    "Values('" + p.custId + "','" + p.custActive + "','" +
                    p.custAddress1 + "','" + p.custAddress2 + "','" +
                    p.custAmphur + "','" + p.custChangwat + "','" +
                    p.custHouse + "','" + p.custMoo + "','" +
                    p.custName + "','" + p.custNamet + "','" +
                    p.custNumber + "','" + p.custRoad + "','" +
                    p.custTambon + "','" + p.description + "','" +
                    p.email + "','" + p.fax + "','" +
                    p.messageContact + "','" + p.messageMarketing + "','" +
                    p.postCode + "','" + p.remark + "','" +
                    p.sort1 + "','" + p.telephone+"','"+
                    p.custTypeNumber+"','"+p.termPayment+ "')";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Insert");
            }
            finally
            {
            }
            return p.custId;
        }
        public String update(Customer p)
        {
            String sql = "", chk = "";
            try
            {
                //p.dateModi = DateTime.Now.Year.ToString() + DateTime.Now.ToString("-MM-dd HH:MM");
                p.custHouse = p.custHouse.Replace("''", "'");
                p.custMoo = p.custMoo.Replace("''", "'");
                p.custName = p.custName.Replace("''", "'");
                p.custNamet = p.custNamet.Replace("''", "'");
                p.custRoad = p.custRoad.Replace("''", "'");
                p.description = p.description.Replace("''", "'");
                p.messageContact = p.messageContact.Replace("''", "'");
                p.messageMarketing = p.messageMarketing.Replace("''", "'");
                p.remark = p.remark.Replace("''", "'");
                sql = "Update " + cust.table + " Set " + cust.custAddress1 + "='" + p.custAddress1 + "'," +
                cust.custAddress2 + "='" + p.custAddress2 + "'," +
                cust.custAmphur + "='" + p.custAmphur + "'," +
                cust.custChangwat + "='" + p.custChangwat + "'," +
                cust.custHouse + "='" + p.custHouse + "'," +
                cust.custMoo + "='" + p.custMoo + "'," +
                cust.custName + "='" + p.custName + "'," +
                cust.custNamet + "='" + p.custNamet + "'," +
                cust.custNumber + "='" + p.custNumber + "'," +
                cust.custRoad + "='" + p.custRoad + "'," +
                cust.custTambon + "='" + p.custTambon + "'," +
                cust.description + "='" + p.description + "'," +
                cust.email + "='" + p.email + "'," +
                cust.fax + "='" + p.fax + "', " +
                cust.messageContact + "='" + p.messageContact + "', " +
                cust.messageMarketing + "='" + p.messageMarketing + "', " +
                cust.postCode + "='" + p.postCode + "', " +
                cust.remark + "='" + p.remark + "', " +
                cust.sort1 + "='" + p.sort1 + "', " +
                cust.telephone + "='" + p.telephone + "', " +
                cust.custTypeNumber + "='" + p.custTypeNumber + "', " +
                cust.termPayment + "='" + p.termPayment + "' " +
                "Where " + cust.custId + "='" + p.custId + "'";
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {

            }
            return chk;
        }
        public String insertCustomer(Customer p)
        {
            Customer item = new Customer();
            String chk = "";
            item = selectCustomerByPk(p.custId);
            if (item.custId == "")
            {
                chk = insert(p);
            }
            else
            {
                chk = update(p);
            }
            return chk;
        }
        public String insertCustomer1(Customer p)
        {
            Customer item = new Customer();
            String chk = "";
            item = selectCustomerByName(p.custName);
            if (item.custId == "")
            {

                chk = insert(p);
            }
            else
            {
                chk = update(p);
                chk = item.custId;//แก้เพราะ เป็นการ convert
            }
            return chk;
        }
        public String deleteAll()
        {
            String sql = "", chk="";
            sql = "Delete From "+cust.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}
