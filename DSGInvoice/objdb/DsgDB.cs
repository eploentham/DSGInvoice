using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSGInvoice.objdb
{
    class DsgDB
    {
        public CustomerDB custdb;
        public DsgDB(ConnectDB c)
        {
            custdb = new CustomerDB(c);
        }
    }
}
