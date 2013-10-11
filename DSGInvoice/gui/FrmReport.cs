using DSGInvoice.objdb;
using DSGInvoice.object1;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGInvoice.gui
{
    public partial class FrmReport : Form
    {
        private ConnectDB conn;
        private ReportDB reportdb;
        public String reportName="", pathReport="";
        public FrmReport()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {            
            conn = new ConnectDB();            
            reportdb = new ReportDB(conn);
            //pathReport = System.Environment.CurrentDirectory + "\\report\\";
            pathReport = "d:\\source\\dsg\\dsgInvoice\\dsgInvoice\\report\\";
        }
        private void setResize()
        {
            rV1.Size = new Size(this.Width - 40, this.Height - 70);
        }
        public DataTable getDailyInvoice(String dateStart, String dateEnd)
        {
            conn = new ConnectDB();
            reportdb.conn = conn;
            return reportdb.dailyInvoice(dateStart, dateEnd);
        }
        public void setRptDailyInvoice(String dateStart, String dateEnd)
        {
            try
            {
                ReportDataSource rds = new ReportDataSource("DailyInvoice", getDailyInvoice(dateStart, dateEnd));
                //MessageBox.Show("bbbb");
                rV1.LocalReport.DataSources.Add(rds);
                rV1.LocalReport.ReportPath = pathReport + "DailyInvoice.rdlc";
                //rV1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\report\\DailyInvoice.rdlc";
                ReportParameter reportParaHeader1 = new ReportParameter();
                reportParaHeader1.Name = "header1";
                reportParaHeader1.Values.Add("บริษัท ดี เอส จี โลจิสติกส์ จำกัด");
                rV1.LocalReport.SetParameters(reportParaHeader1);
                ReportParameter reportParaHeader2 = new ReportParameter();
                reportParaHeader2.Name = "header2";
                reportParaHeader2.Values.Add("รายงานใบแจ้งหนี้");
                rV1.LocalReport.SetParameters(reportParaHeader2);
                ReportParameter reportParaHeader3 = new ReportParameter();
                reportParaHeader3.Name = "header3";
                reportParaHeader3.Values.Add("ประจำวันที่ " + dateStart + " ถึงวันที่  " + dateEnd);
                rV1.LocalReport.SetParameters(reportParaHeader3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        public void setRptInvView(String dateStart, String dateEnd)
        {
            try
            {
                ReportDataSource rds = new ReportDataSource("invView", reportdb.invdb.selectByYearMonth(dateStart, dateEnd));
                //MessageBox.Show("bbbb");
                rV1.LocalReport.DataSources.Add(rds);
                rV1.LocalReport.ReportPath = pathReport + "invView.rdlc";
                //rV1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\report\\DailyInvoice.rdlc";
                ReportParameter reportParaHeader1 = new ReportParameter();
                reportParaHeader1.Name = "header1";
                reportParaHeader1.Values.Add("บริษัท ดี เอส จี โลจิสติกส์ จำกัด");
                rV1.LocalReport.SetParameters(reportParaHeader1);
                ReportParameter reportParaHeader2 = new ReportParameter();
                reportParaHeader2.Name = "header2";
                reportParaHeader2.Values.Add("รายงานใบแจ้งหนี้ ประจำเดือน");
                rV1.LocalReport.SetParameters(reportParaHeader2);
                ReportParameter reportParaHeader3 = new ReportParameter();
                reportParaHeader3.Name = "header3";
                reportParaHeader3.Values.Add("ประจำวันที่ " + dateStart + " ถึงวันที่  " + dateEnd);
                rV1.LocalReport.SetParameters(reportParaHeader3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        public void setRptDailyInvPaymentDate(String dateStart, String dateEnd)
        {
            try
            {
                ReportDataSource rds = new ReportDataSource("dailyinvpaymentdate", reportdb.invdb.selectByYearMonth(dateStart, dateEnd));
                //MessageBox.Show("bbbb");
                rV1.LocalReport.DataSources.Add(rds);
                rV1.LocalReport.ReportPath = pathReport + "invView.rdlc";
                //rV1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\report\\DailyInvoice.rdlc";
                ReportParameter reportParaHeader1 = new ReportParameter();
                reportParaHeader1.Name = "header1";
                reportParaHeader1.Values.Add("บริษัท ดี เอส จี โลจิสติกส์ จำกัด");
                rV1.LocalReport.SetParameters(reportParaHeader1);
                ReportParameter reportParaHeader2 = new ReportParameter();
                reportParaHeader2.Name = "header2";
                reportParaHeader2.Values.Add("รายงานใบแจ้งหนี้ ประจำเดือน");
                rV1.LocalReport.SetParameters(reportParaHeader2);
                ReportParameter reportParaHeader3 = new ReportParameter();
                reportParaHeader3.Name = "header3";
                reportParaHeader3.Values.Add("ประจำวันที่ " + dateStart + " ถึงวันที่  " + dateEnd);
                rV1.LocalReport.SetParameters(reportParaHeader3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        public void setRptUnPayment()
        {
            try
            {
                ReportDataSource rds = new ReportDataSource("UnPayment", reportdb.invdb.selectByUnPayment());
                //MessageBox.Show("bbbb");
                rV1.LocalReport.DataSources.Add(rds);
                rV1.LocalReport.ReportPath = pathReport + "UnPayment.rdlc";
                //rV1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\report\\DailyInvoice.rdlc";
                ReportParameter reportParaHeader1 = new ReportParameter();
                reportParaHeader1.Name = "header1";
                reportParaHeader1.Values.Add("บริษัท ดี เอส จี โลจิสติกส์ จำกัด");
                rV1.LocalReport.SetParameters(reportParaHeader1);
                ReportParameter reportParaHeader2 = new ReportParameter();
                reportParaHeader2.Name = "header2";
                reportParaHeader2.Values.Add("รายงานยอดค้างชำระ");
                rV1.LocalReport.SetParameters(reportParaHeader2);
                ReportParameter reportParaHeader3 = new ReportParameter();
                reportParaHeader3.Name = "header3";
                reportParaHeader3.Values.Add(" " );
                rV1.LocalReport.SetParameters(reportParaHeader3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        public void setRptInvoice(String invId)
        {
            try
            {
                Invoice inv = new Invoice();
                inv = reportdb.invdb.selectInvoiceByPk(invId);
                ReportDataSource rds = new ReportDataSource("invoice_item", reportdb.invIdb.selectByInvId(invId));
                //MessageBox.Show("bbbb");
                rV1.LocalReport.DataSources.Add(rds);
                rV1.LocalReport.ReportPath = pathReport + "invoice.rdlc";
                //rV1.LocalReport.ReportPath = System.Environment.CurrentDirectory + "\\report\\DailyInvoice.rdlc";
                ReportParameter reportParaHeader1 = new ReportParameter();
                reportParaHeader1.Name = "company_name_t";
                reportParaHeader1.Values.Add("บริษัท ดี เอส จี โลจิสติกส์ จำกัด");
                rV1.LocalReport.SetParameters(reportParaHeader1);
                ReportParameter reportParaHeader2 = new ReportParameter();
                reportParaHeader2.Name = "company_name_e";
                reportParaHeader2.Values.Add("DSG LOGISTICS CO.,LTD.");
                rV1.LocalReport.SetParameters(reportParaHeader2);
                ReportParameter reportParaHeader3 = new ReportParameter();
                reportParaHeader3.Name = "company_address1";
                reportParaHeader3.Values.Add("เลขที่ 21  ซอยบางนา-ตราด 56 ถนนบางนา-ตราด แขวงบางนา เขตบางนา กรุงเทพฯ 10260 ");
                rV1.LocalReport.SetParameters(reportParaHeader3);
                ReportParameter reportParaHeader4 = new ReportParameter();
                reportParaHeader4.Name = "company_address2";
                reportParaHeader4.Values.Add("21 SOI BANGNA-TRAD 56, BANGNA-TRAD Rd., BANGNA BANGKOK  THAILAND  10260 ");
                rV1.LocalReport.SetParameters(reportParaHeader4);
                ReportParameter reportParaHeader5 = new ReportParameter();
                reportParaHeader5.Name = "company_telephone";
                reportParaHeader5.Values.Add("Tel  : (66) 2751 4108-9        Fax  :  (66)  2751 4107    ");
                rV1.LocalReport.SetParameters(reportParaHeader5);
                ReportParameter reportParaHeader6 = new ReportParameter();
                reportParaHeader6.Name = "cust_name";
                reportParaHeader6.Values.Add("ลูกค้า : "+inv.custName);
                rV1.LocalReport.SetParameters(reportParaHeader6);
                ReportParameter reportParaHeader7 = new ReportParameter();
                reportParaHeader7.Name = "cust_address1";
                reportParaHeader7.Values.Add("ที่อยู่ "+inv.custAddress1);
                rV1.LocalReport.SetParameters(reportParaHeader7);
                ReportParameter reportParaHeader8 = new ReportParameter();
                reportParaHeader8.Name = "cust_address2";
                reportParaHeader8.Values.Add("  "+inv.custAddress2);
                rV1.LocalReport.SetParameters(reportParaHeader8);

                ReportParameter reportParaHeader9 = new ReportParameter();
                reportParaHeader9.Name = "telephone";
                reportParaHeader9.Values.Add("โทรศัพท์ ");
                rV1.LocalReport.SetParameters(reportParaHeader9);

                ReportParameter reportParaHeader10 = new ReportParameter();
                reportParaHeader10.Name = "inv_number";
                reportParaHeader10.Values.Add(inv.invNumber);
                rV1.LocalReport.SetParameters(reportParaHeader10);

                ReportParameter reportParaHeader11 = new ReportParameter();
                reportParaHeader11.Name = "inv_date";
                reportParaHeader11.Values.Add(inv.invDate);
                rV1.LocalReport.SetParameters(reportParaHeader11);

                ReportParameter reportParaHeader12 = new ReportParameter();
                reportParaHeader12.Name = "term_payment";
                reportParaHeader12.Values.Add(inv.termPayment);
                rV1.LocalReport.SetParameters(reportParaHeader12);

                ReportParameter reportParaHeader13 = new ReportParameter();
                reportParaHeader13.Name = "due_date";
                reportParaHeader13.Values.Add(inv.dueDate);
                rV1.LocalReport.SetParameters(reportParaHeader13);

                ReportParameter reportParaHeader14 = new ReportParameter();
                reportParaHeader14.Name = "original";
                reportParaHeader14.Values.Add("ต้นฉบับ");
                rV1.LocalReport.SetParameters(reportParaHeader14);

                ReportParameter reportParaHeader15 = new ReportParameter();
                reportParaHeader15.Name = "tax_id";
                reportParaHeader15.Values.Add("1234567890");
                rV1.LocalReport.SetParameters(reportParaHeader15);

                ReportParameter reportParaHeader16 = new ReportParameter();
                reportParaHeader16.Name = "total";
                reportParaHeader16.Values.Add(inv.invAmount);
                rV1.LocalReport.SetParameters(reportParaHeader16);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

            this.rV1.RefreshReport();
            
            setResize();
        }

        private void FrmReport_Resize(object sender, EventArgs e)
        {
            setResize();
        }
    }
}
