using DSGInvoice.gui;
using DSGInvoice.objdb;
using DSGInvoice.object1;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSGInvoice
{
    public partial class Form1 : Form
    {
        Microsoft.Office.Interop.Excel.Application mApp;
        Workbook workbook;
        Config1 config1 = new Config1();
        public Form1()
        {
            InitializeComponent();
            mApp = new Microsoft.Office.Interop.Excel.Application();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            importExcel();
        }
        private Boolean openExcel(String filename)
        {
            labelStatus.Text = "Opening";
            workbook = mApp.Workbooks.Open(filename,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            if (workbook == null)
            {
                return false;
            }
            else
            {
                labelStatus.Text = "opened";
                labelSheetCount.Text = "Sheet count " + workbook.Sheets.Count;
                return true;
            }
            this.Refresh();
        }
        private void importExcel()
        {
            ConnectDB conn = new ConnectDB();
            CustomerDB custdb = new CustomerDB(conn);
            InvoiceDB invdb = new InvoiceDB(conn);
            InvoiceItemDB invIdb = new InvoiceItemDB(conn);
            RecriptDB recpdb = new RecriptDB(conn);
            RecriptItemDB recpItemdb = new RecriptItemDB(conn);
            String fileName = "", custName = "", invNo = "", custAddress1 = "", custTel = "", custAddress2 = "", err="", month="";
            String invDate = "", dueDate = "", invAmount = "", invAmountThb = "", termPay = "", invId = "", desc4 = "", recpId="";
            String recriptNo = "", recriptDate = "", recriptAmount = "", recriptAmountThb = "", custId="", desc1="", desc2="", desc3="";
            DateTime dt = new DateTime();
            int row = 0, year=0;
            int colInv = 8, colName = 3, colRecript = 7;
            if (!openExcel(labelExcelFilename.Text))
            {
                return;
            }
            //foreach (workbook.Worksheets sh in workbook)
            //{

            //}
            if (chkDeleteData.Checked)
            {
                custdb.deleteAll();
                invdb.deleteAll();
                invIdb.deleteAll();
                recpdb.deleteAll();
                recpItemdb.deleteAll();
            }
            
            Sheets sheets = workbook.Sheets;
            pgB.Minimum = 0;
            pgB.Maximum = workbook.Sheets.Count;
            for (int i = 1; i < workbook.Sheets.Count; i++)
            {
                pgB.Value = i;
                Customer cust = new Customer();
                Invoice inv = new Invoice();
                InvoiceItem invI = new InvoiceItem();
                Recript recp = new Recript();
                RecriptItem recpItem = new RecriptItem();
                
                Worksheet sheet = workbook.Worksheets[i];
                labelStatus.Text = "Sheet " + sheet.Name;
                this.Refresh();
                //cust.custNumber = "0000000000"+i;
                //cust.custNumber = cust.custNumber.Substring(cust.custNumber.Length-5);
                if (sheet.Name.Substring(0, 1) == "1")
                {
                    colInv = 8;
                    Range cellInvNo = sheet.Cells[8, colInv];
                    invNo = cellInvNo.Value;
                    if (sheet.Name.Length < 2)
                    {
                        continue;
                    }
                    if (invNo == "Invoice No.:")
                    {
                        continue;
                    }
                    if (invNo.IndexOf("Invoice") > 0)
                    {
                        invNo = sheet.Cells[8, colInv + 1];//
                        if (invNo.IndexOf("DSG") > 0)
                        {
                            colInv = 9;
                        }
                    }
                    invNo = invNo.Replace("Invoice No.:", "");
                    Range celCustName = sheet.Cells[8, colName];
                    Range celCustAddress1 = sheet.Cells[10, colName];
                    Range celCustAddress2 = sheet.Cells[12, colName];
                    Range celCustTel = sheet.Cells[14, colName];
                    custName = config1.ObjectNull(celCustName.Value);//
                    custAddress1 = config1.ObjectNull(celCustAddress1.Value);//
                    custAddress2 = config1.ObjectNull(celCustAddress2.Value);//
                    custTel = config1.ObjectNull(celCustTel.Value);//
                    if (cust.custName.IndexOf("บริษัท") >= 0)
                    {
                        cust.custTypeNumber = "001";
                    }
                    else if (cust.custName.IndexOf("หจก") >= 0)
                    {
                        cust.custTypeNumber = "002";
                    }
                    else if (cust.custName.IndexOf("คุณ") >= 0)
                    {
                        cust.custTypeNumber = "003";
                    }
                    else
                    {
                        cust.custTypeNumber = "001";
                    }
                    if (custAddress2.Length > 5)
                    {
                        cust.postCode = custAddress2.Substring(custAddress2.Length - 5);
                    }
                    Range celInvDate = sheet.Cells[10, colInv];
                    Range celDueDate = sheet.Cells[14, colInv];
                    Range celTermPay = sheet.Cells[12, colInv];
                    Range celInvAmount = sheet.Cells[41, 7];
                    Range celInvAmountThb = sheet.Cells[41, colName];
                    dt = celInvDate.Value;
                    invDate = config1.datetoDB(dt);
                    month = dt.ToString("MM");
                    year = (dt.Year + 543);
                    //invDate = dt.Year.ToString() + dt.ToString("-MM-dd HH:MM");
                    dt = celDueDate.Value;
                    //dueDate = dt.Year.ToString() + dt.ToString("-MM-dd HH:MM");
                    dueDate = config1.datetoDB(dt);
                    termPay = celTermPay.Value;//
                    invAmount = String.Concat(config1.ObjectNull(celInvAmount.Value));//
                    invAmountThb = config1.ObjectNull(celInvAmountThb.Value);//
                    if (invAmount == "")
                    {
                        celInvAmount = sheet.Cells[42, 7];
                        celInvAmountThb = sheet.Cells[42, colName];
                        invAmount = String.Concat(config1.ObjectNull(celInvAmount.Value));//
                        invAmountThb = config1.ObjectNull(celInvAmountThb.Value);//
                    }
                    if (invAmount == "")
                    {
                        invAmount = "0";
                    }
                    cust.custActive = "1";
                    cust.custAddress1 = custAddress1.Trim();
                    cust.custAddress2 = custAddress2.Trim();
                    cust.custName = custName.Trim();
                    cust.custNamet = custName.Trim();
                    cust.telephone = custTel.Trim();
                    cust.termPayment = "30";
                    custId = custdb.insertCustomer1(cust);
                    if (invNo == "DSG13-0010")
                    {
                        err = "";
                    }
                    inv.custAddress1 = cust.custAddress1;
                    inv.custAddress2 = cust.custAddress2;
                    inv.custId = custId;
                    inv.custName = cust.custName;
                    inv.dueDate = dueDate;
                    inv.invActive = "1";
                    inv.invAmount = invAmount;
                    inv.invAmountThb = invAmountThb;
                    inv.invDate = invDate;
                    inv.invNumber = invNo;
                    inv.termPayment = termPay;

                    inv.year = year.ToString();
                    inv.month = month;
                    invId = "";
                    invId = invdb.insertInvoice(inv);

                    Range celInvIRow1 = sheet.Cells[21, 2];
                    Range celInvIDescription11 = sheet.Cells[21, 3];
                    Range celInvIDescription12 = sheet.Cells[22, 3];
                    Range celInvIDescription13 = sheet.Cells[23, 3];
                    Range celInvIDescription14 = sheet.Cells[24, 3];
                    Range celInvIQty1 = sheet.Cells[21, 4];
                    Range celInvIQtyUnit1 = sheet.Cells[21, 5];
                    Range celInvIPrice1 = sheet.Cells[21, 6];
                    Range celInvIAmount1 = sheet.Cells[21, 7];
                    Range celInvIRemark1 = sheet.Cells[21, 8];

                    invI.amount = config1.ObjectNull(celInvIAmount1.Value);
                    desc1 = config1.ObjectNull(celInvIDescription11.Value);
                    desc2 = config1.ObjectNull(celInvIDescription12.Value);
                    desc3 = config1.ObjectNull(celInvIDescription13.Value);
                    desc4 = config1.ObjectNull(celInvIDescription14.Value);
                    invI.description = desc1.Trim() + " " + desc2.Trim() + " " + desc3.Trim() + " " + desc4.Trim();
                    invI.invId = invId;
                    invI.invItemActive = "1";
                    invI.invItemRow = config1.ObjectNull(celInvIRow1.Value);
                    invI.price = config1.ObjectNull(celInvIPrice1.Value);
                    invI.qty = config1.ObjectNull(celInvIQty1.Value);
                    invI.qtyUnit = config1.ObjectNull(celInvIQtyUnit1.Value);
                    invI.remark = config1.ObjectNull(celInvIRemark1.Value);
                    invIdb.insertInvoiceItem(invI);

                    Range celInvIRow2 = sheet.Cells[25, 2];
                    Range celInvIDescription21 = sheet.Cells[25, 3];
                    Range celInvIDescription22 = sheet.Cells[26, 3];
                    Range celInvIDescription23 = sheet.Cells[27, 3];
                    Range celInvIDescription24 = sheet.Cells[28, 3];
                    Range celInvIQty2 = sheet.Cells[25, 4];
                    Range celInvIQtyUnit2 = sheet.Cells[25, 5];
                    Range celInvIPrice2 = sheet.Cells[25, 6];
                    Range celInvIAmount2 = sheet.Cells[25, 7];
                    Range celInvIRemark2 = sheet.Cells[25, 8];

                    if (config1.ObjectNull(celInvIRow2.Value) == "")
                    {
                        celInvIRow2 = sheet.Cells[26, 2];
                        celInvIDescription21 = sheet.Cells[26, 3];
                        celInvIDescription22 = sheet.Cells[27, 3];
                        celInvIDescription23 = sheet.Cells[28, 3];
                        celInvIDescription24 = sheet.Cells[29, 3];
                        celInvIQty2 = sheet.Cells[26, 4];
                        celInvIQtyUnit2 = sheet.Cells[26, 5];
                        celInvIPrice2 = sheet.Cells[26, 6];
                        celInvIAmount2 = sheet.Cells[26, 7];
                        celInvIRemark2 = sheet.Cells[26, 8];
                    }
                    if (config1.ObjectNull(celInvIRemark2) != "")
                    {
                        invI.invItemId = "";
                        desc1 = config1.ObjectNull(celInvIDescription21.Value);
                        desc2 = config1.ObjectNull(celInvIDescription22.Value);
                        desc3 = config1.ObjectNull(celInvIDescription23.Value);
                        desc4 = config1.ObjectNull(celInvIDescription24.Value);
                        invI.description = desc1.Trim() + " " + desc2.Trim() + " " + desc3.Trim() + " " + desc4.Trim();
                        invI.invId = invId;
                        invI.invItemActive = "1";
                        invI.invItemRow = config1.ObjectNull(celInvIRow2.Value);
                        invI.price = config1.ObjectNull(celInvIPrice2.Value);
                        invI.qty = config1.ObjectNull(celInvIQty2.Value);
                        invI.qtyUnit = config1.ObjectNull(celInvIQtyUnit2.Value);
                        invI.remark = config1.ObjectNull(celInvIRemark2.Value);
                        invI.amount = config1.ObjectNull(celInvIAmount2.Value);
                        invIdb.insertInvoiceItem(invI);
                    }
                    invdb.updateInvoiceAmount(invId);

                }
                else if (sheet.Name.Substring(0, 2) == "56")
                {
                    Range celRecriptNo = sheet.Cells[5, colRecript];
                    Range celRecriptDate = sheet.Cells[7, colRecript];
                    Range celInvNo = sheet.Cells[14, 3];
                    Range celRecriptAmount = sheet.Cells[30, 6];
                    Range celRecriptAmountThb = sheet.Cells[30, 2];

                    recriptNo = celRecriptNo.Value;//
                    if (recriptNo == "DSG13005")
                    {
                        err = "";
                    }
                    dt = celRecriptDate.Value;
                    
                    //recriptDate = dt.Year.ToString() + dt.ToString("-MM-dd HH:MM");
                    recriptDate = config1.datetoDB(dt);
                    month = dt.ToString("MM");
                    year = (dt.Year + 543);
                    invNo = celInvNo.Value;//
                    recriptAmount = String.Concat(celRecriptAmount.Value);//
                    recriptAmountThb = celRecriptAmountThb.Value;//

                    inv = invdb.selectInvoiceByInvNumber(invNo);

                    recp.custId = inv.custId;
                    recp.recpActive = "1";
                    recp.recpAmount = recriptAmount;
                    recp.recpAmountThb = recriptAmountThb.Trim();
                    recp.recpDate = recriptDate;
                    recp.recpNumber = recriptNo.Trim();
                    recp.remark = "";
                    recp.year = year.ToString();
                    recp.month = month;
                    recp.custName = inv.custName;
                    recpId=recpdb.insertRecript(recp);

                    Range celRecpItemRow1 = sheet.Cells[14, 2];
                    Range celInvNumber1 = sheet.Cells[14, 3];
                    Range celInvDate1 = sheet.Cells[14, 4];
                    Range celRecpItemDesc1 = sheet.Cells[14, 5];
                    Range celRecpItemAmount1 = sheet.Cells[14, 6];

                    dt = celInvDate1.Value;
                    //invDate = dt.Year.ToString() + dt.ToString("-MM-dd HH:MM");
                    invDate = config1.datetoDB(dt);
                    invAmount = config1.ObjectNull(celRecpItemAmount1.Value);
                    if (invAmount == "")
                    {
                        invAmount = "0";
                    }
                    invNo = celInvNumber1.Value;//
                    recpItem.recpItemId = "";
                    recpItem.recpItemRow = config1.ObjectNull(celRecpItemRow1.Value);
                    recpItem.amount = invAmount;
                    recpItem.description = config1.ObjectNull(celRecpItemDesc1.Value);
                    recpItem.invDate = invDate;
                    recpItem.recpId = recpId;
                    recpItem.recpItemActive = "1";
                    recpItem.remark = "";
                    recpItem.invNumber = invNo;

                    recpItemdb.insertRecriptItem(recpItem);
                    invdb.updateRecript(invNo, recriptNo, recpItem.amount, recriptDate);

                    Range celRecpItemRow2 = sheet.Cells[15, 2];
                    Range celInvNumber2 = sheet.Cells[15, 3];
                    Range celInvDate2 = sheet.Cells[14, 4];
                    Range celRecpItemDesc2 = sheet.Cells[15, 5];
                    Range celRecpItemAmount2 = sheet.Cells[15, 6];

                    if (config1.ObjectNull(celRecpItemRow2.Value) != "")
                    {
                        invNo = celInvNumber2.Value;//
                        dt = celInvDate2.Value;
                        invDate = dt.Year.ToString() + dt.ToString("-MM-dd HH:MM");
                        invAmount = config1.ObjectNull(celRecpItemAmount2.Value);
                        if (invAmount == "")
                        {
                            invAmount = "0";
                        }
                        recpItem.recpItemId = "";
                        recpItem.recpItemRow = config1.ObjectNull(celRecpItemRow2.Value);
                        recpItem.amount = invAmount;
                        recpItem.description = config1.ObjectNull(celRecpItemDesc2.Value);
                        recpItem.invDate = invDate;
                        recpItem.recpId = recpId;
                        recpItem.recpItemActive = "1";
                        recpItem.remark = "";
                        recpItem.invNumber = invNo;

                        recpItemdb.insertRecriptItem(recpItem);
                        invdb.updateRecript(invNo, recriptNo, recpItem.amount, recriptDate);
                    }
                    
                }
                
            }
            workbook.Close();
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            oFD.ShowDialog();
            labelExcelFilename.Text = oFD.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInvView frm = new FrmInvView();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCustView frm = new FrmCustView();
            frm.setData("");
            frm.Show();
        }
    }
}
