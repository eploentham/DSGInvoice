using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSGInvoice.object1
{
    class Deposit : Persistent
    {
        public String depositId="";
        public String invId = "";
        public String description = "";
        public String depositActive = "";
        public String depositDate = "";
        public String remark = "";
        public String deposit = "";
        public String statusDeposit = "";
        public String custId = "";
        public String custName = "";
        public String invNumber = "";
        public String recpNumber = "";
        public override string ToString()
        {
            return description+" {"+deposit+"}";
        }
    }
}
