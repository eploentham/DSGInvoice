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
    class CustomerTypeDB
    {
        private ConnectDB conn;
        public CustomerType custT;
        public CustomerTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            custT = new CustomerType();
            custT.custTypeActive = "cust_type_active";
            custT.custTypeId = "cust_type_id";
            custT.custTypeName = "cust_type_name";
            custT.custTypeNamet = "cust_type_namet";
            custT.sort1 = "sort1";
            custT.pkField = "";
            custT.sited = "";
            custT.table = "b_customer_type";
        }
        public DataTable selectCustomerType()
        {
            //Customer item = new Customer();
            String sql = "", row = "";
            DataTable dt = new DataTable();
            sql = "Select " + custT.custTypeName + " From " + custT.table + " Where " + custT.custTypeActive + "='1' Order By " + custT.custTypeName;
            dt = conn.selectData(sql);

            return dt;
        }
        public String selectCustomerTypeNameById(String custTId)
        {
            String sql = "", row = "";
            DataTable dt = new DataTable();
            sql = "Select " + custT.custTypeName + " From " + custT.table + " Where " + custT.custTypeId + "='" + custTId + "' ";
            dt = conn.selectData(sql);
            if(dt.Rows.Count>0)
            {
                row = dt.Rows[0][custT.custTypeName].ToString();
            }
            return row;
        }
        public ComboBox getCboCustomerType(ComboBox c)
        {
            //ComboBox c = new ComboBox();
            DataTable dt = selectCustomerType();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                c.Items.Add(dt.Rows[i][custT.custTypeName].ToString());
            }
            return c;
        }
    }
}
