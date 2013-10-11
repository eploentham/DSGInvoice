using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGInvoice.object1
{
    class Recript : Persistent
    {
        public String recpId = "";
        public String recpNumber = "";
        public String recpDate = "";
        public String custId = "";
        public String recpActive = "";
        public String remark = "";
        public String recpAmount = "";
        public String recpAmountThb = "";
        public String year = "";
        public String month = "";
        public String custName = "";
        public String statusRecepitAll = "";
        public String invNumber = "";
        public override string ToString()
        {
            return recpNumber;
        }
    }
}
