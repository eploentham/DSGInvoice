using DSGInvoice.objdb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DSGInvoice.object1
{
    class DsgControl
    {
        public Config1 config1;
        public ConnectDB conn;
        public Recript recp;
        public RecriptItem recpI;
        public Invoice inv;
        public InvoiceItem invI;
        public Customer cust;
        public Deposit dep;

        public CustomerDB custdb;
        public InvoiceDB invdb;
        public InvoiceItemDB invIdb;
        public RecriptDB recpdb;
        public RecriptItemDB recpIdb;
        public DepositDB depdb;

        public DsgControl()
        {
            config1 = new Config1();
            conn = new ConnectDB();
            custdb = new CustomerDB(conn);
            recpdb = new RecriptDB(conn);
            invdb = new InvoiceDB(conn);
            invIdb = new InvoiceItemDB(conn);
            invI = new InvoiceItem();
            recpIdb = new RecriptItemDB(conn);

            dep = new Deposit();
            depdb = new DepositDB(conn);
            
        }
        public void unActiveReceipt(String recpId)
        {
            /**
             * 1. unActive receipt
             * 2. unActive Deposit
             * 3. ยกเลิกรับชำระ ของ table t_invoice
             **/
            DataTable dt = new DataTable();
            recp = recpdb.selectRecriptByPk(recpId);
            dt = recpIdb.selectReceiptItemByRecpId(recpId);
            recpdb.updateUnActive(recpId);
            
            if(dt.Rows.Count>0)
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    //recpIdb.updateUnActive(recpId);
                    RecriptItem recpI = new RecriptItem();
                    DataTable dtrecpI = recpIdb.selectReceiptItemByRecpId(recpId);
                    String recpAmount = "0", deposit="0";
                    recpAmount = dtrecpI.Rows[0][recpIdb.recpI.recpAmount].ToString();
                    inv = invdb.selectInvoiceByPk(dt.Rows[i][invdb.inv.invId].ToString());
                    //if (inv.statusDeposit.Equals("1"))
                    //{
                    //    deposit = depdb.selectSumDepositByInvId(inv.invId);
                    //    deposit = deposit.Replace(",", "");
                    //    recpAmount = String.Concat(Double.Parse(recpAmount) + Double.Parse(deposit));
                    //}
                    depdb.updateStatusDeposit(inv.invId, recp.recpNumber);
                    invdb.updateUnRecript(inv.invId, recp.recpNumber, recpAmount);
                }
            }
        }
    }
}
