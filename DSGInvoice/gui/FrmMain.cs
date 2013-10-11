using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSGInvoice.gui
{
    public partial class FrmMain : Form
    {
        FrmCustView frmCustView;
        FrmRecpView frmRecpView;
        FrmInvView frmInvView;
        Form1 frmConvert;
        FrmDailyInvoice frmDailyInvoice;
        FrmReport frmReport;
        FrmDepositView frmDeposit;
        public FrmMain()
        {
            InitializeComponent();
        }
        private void showFrame(Form f)
        {
            this.Hide();
            f.ShowDialog(this);
            this.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Last Update " + System.IO.File.GetLastWriteTime(System.Environment.CurrentDirectory + "\\" + Process.GetCurrentProcess().ProcessName+".exe");
        }

        private void tv1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String nodeSelect = "";
            nodeSelect = tv1.SelectedNode.Name.ToString();
            if (nodeSelect == "nConvert")
            {
                if (frmConvert == null)
                {
                    frmConvert = new Form1();
                }
                showFrame(frmConvert);
            }
            else if (nodeSelect == "nInvoice")
            {
                if (frmInvView == null)
                {
                    frmInvView = new FrmInvView();
                }
                showFrame(frmInvView);
            }
            else if (nodeSelect == "nReceipt")
            {
                if (frmRecpView == null)
                {
                    frmRecpView = new FrmRecpView();
                }
                showFrame(frmRecpView);
            }
            else if (nodeSelect == "nCustomer")
            {
                if (frmCustView == null)
                {
                    frmCustView = new FrmCustView();
                }
                showFrame(frmCustView);
            }
            else if (nodeSelect == "nDailyInvoice")
            {
                if (frmDailyInvoice == null)
                {
                    frmDailyInvoice = new FrmDailyInvoice();
                }
                showFrame(frmDailyInvoice);
            }
            else if (nodeSelect == "nUnPayment")
            {
                if (frmReport == null)
                {
                    frmReport = new FrmReport();
                }

                frmReport.reportName = "unPayment";
                frmReport.setRptUnPayment();
                frmReport.Show(this);
            }
            else if (nodeSelect == "nDeposit")
            {
                if (frmDeposit == null)
                {
                    frmDeposit = new FrmDepositView();
                }
                showFrame(frmDeposit);
                
            }
        }
    }
}
