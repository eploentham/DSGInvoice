using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGInvoice.object1
{
    class InvoiceItem : Persistent
    {
        public String invItemId = "";
        public String invId = "";
        public String invItemRow = "";
        public String description = "";
        public String qty = "0";
        public String price = "0";
        public String amount = "0";
        public String remark = "";
        public String invItemActive = "";
        public String qtyUnit = "";
        public String statusRecp = "";
        public String recpAmount = "0";
        public String recpNumber = "";
        public String statusPayment = "";
        public override string ToString()
        {
            return description;
        }
    }
}
