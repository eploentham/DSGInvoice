using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGInvoice.object1
{
    class Invoice : Persistent
    {
        public String invId = "";
        public String invNumber = "";
        public String invDate = "";
        public String invAmount = "0";
        public String invAmountThb = "";
        public String dueDate = "";
        public String termPayment = "";
        public String receiptNumber = "";
        public String custId = "";
        public String custName = "";
        public String custAddress1 = "";
        public String custAddress2 = "";
        public String remark = "";
        public String invActive = "";
        public String year = "";
        public String month = "";
        public String statusRecp = "";
        public String recpAmount = "0";
        public String remarkReceipt = "";
        public String recpDate = "";
        public String statusDeposit = "";
        public String deposit = "";
        public String log = "";
        public override string ToString()
        {
            return invNumber + " " + invAmount + " " + recpAmount;
        }
    }
}
