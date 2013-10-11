using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSGInvoice.object1
{
    class Customer : Persistent
    {
        public String custId = "";
        public String custName = "";
        public String custNamet = "";
        public String description = "";
        public String custAddress1 = "";
        public String custAddress2 = "";
        public String remark = "";
        public String telephone = "";
        public String fax = "";
        public String custActive = "";
        public String custNumber = "";
        public String custHouse = "";
        public String custRoad = "";
        public String custMoo = "";
        public String custTambon = "";
        public String custAmphur = "";
        public String custChangwat = "";
        public String postCode = "";
        public String email = "";
        public String messageContact = "";
        public String messageMarketing = "";
        public String sort1 = "";
        public String custTypeNumber = "";
        public String termPayment = "";
        public override string ToString()
        {
            return custName;
        }
    }
}
