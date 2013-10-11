using DSGInvoice.objdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSGInvoice.gui
{
    public partial class FrmDailyInvoice : Form
    {
        ConnectDB conn;
        public String reportName = "";
        private void initConfig()
        {
            conn = new ConnectDB();
            
        }
        public FrmDailyInvoice()
        {
            InitializeComponent();
            initConfig();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FrmReport frm = new FrmReport();
            //if (reportName == "dailyinvoice")
            //{
                frm.reportName = "dailyinvoice";
                //RmonthlyGroupIdDB rmgdb = new RmonthlyGroupIdDB();
                String sql = "", datestart = "", dateend = "";
                datestart = (dtpStart.Value.Year+543) + "-" + dtpStart.Value.ToString("MM-dd");
                dateend = (dtpEnd.Value.Year+543) + "-" + dtpEnd.Value.ToString("MM-dd");
                //rmgdb.setRMonthlyGroupId(datestart, dateend);
                frm.setRptDailyInvoice(datestart, dateend);
            //}
            frm.Show(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
