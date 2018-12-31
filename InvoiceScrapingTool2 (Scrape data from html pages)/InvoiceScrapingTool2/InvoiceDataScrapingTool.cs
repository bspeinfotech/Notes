using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenerelFunctions;
using System.Collections;
using System.Text.RegularExpressions;

namespace InvoiceScrapingTool2
{
    public partial class InvoiceDataScrapingTool : Form
    {
        #region Global Declaration
        FolderBrowserDialog fbd;
        GenerelFunction gf = new GenerelFunction();
        string[] files = null;
        string logFilePath = string.Empty;
        string csvFilePath = string.Empty;
        string ProjectName = "Invoice";
        int intCount = 0;
        #endregion

        #region Create files
        public void CreateFiles()
        {
            try
            {
                // Create log & output Files with specific Folder
                string dirName;
                dirName = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Trec\\" + ProjectName + "\\Log");
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                logFilePath = (dirName + ("\\" + ProjectName + "_Log_"
                            + (DateTime.Now.Month.ToString() + ("_"
                            + (DateTime.Now.Day.ToString() + ("_"
                            + (DateTime.Now.Year.ToString() + ("_"
                            + (DateTime.Now.Hour.ToString() + ("_"
                            + (DateTime.Now.Minute.ToString() + ".txt")))))))))));

                dirName = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Trec\\" + ProjectName + "\\Output");
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                csvFilePath = (dirName + "\\" + ProjectName + "_Output_")
                            + (DateTime.Now.Month.ToString() + ("_"
                            + (DateTime.Now.Day.ToString() + ("_"
                            + (DateTime.Now.Year.ToString() + ("_"
                            + (DateTime.Now.Hour.ToString() + ("_"
                            + (DateTime.Now.Minute.ToString() + ".csv")))))))));

                txtlocation.Text = "Output File Path : " + csvFilePath + "\r\n" + "Log File Path : " + logFilePath;
            }
            catch (Exception ex)
            {
                WriteLog(("Error on file creation" + (ex.Message + (" " + ex.StackTrace))), false);
            }
        }
        #endregion

        #region Constructor
        public InvoiceDataScrapingTool()
        {
            InitializeComponent();
            CreateFiles();
        }
        #endregion

        #region Select file button
        private void btnSelect_Click(object sender, EventArgs e)
        {
            fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (fbd.SelectedPath == null)
            {
                fbd.SelectedPath = txtFolderPath.ToString();
            }

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtFolderPath.Text = fbd.SelectedPath;
                files = Directory.GetFiles(fbd.SelectedPath);
                lblTotalfiles.Text = Directory.EnumerateFiles(fbd.SelectedPath, "*." + txtFileType.Text.Replace(".", "").Trim() + "").Count().ToString();
            }
        }
        #endregion

        #region Start button
        private void btnStart_Click(object sender, EventArgs e)
        {
            lblStartedDateTime.Text = DateTime.Now.ToString();
            foreach (string file in Directory.EnumerateFiles(txtFolderPath.Text, "*." + txtFileType.Text.Replace(".", "").Trim() + ""))
            {
                #region Properties
                string sourceFileName = string.Empty;
                string PageSource = string.Empty;
                string strDocumentNo_Date = string.Empty;
                string strReferenceNo = string.Empty;
                string strDelivaryNoteNo_Date = string.Empty;
                string strOrderNoDate = string.Empty;
                string strCustomerNo = string.Empty;
                string strOrderType = string.Empty;
                string strUPC = string.Empty;
                string strColor = string.Empty;
                string strQty = string.Empty;
                string strUnitPrice = string.Empty;
                #endregion

                PageSource = File.ReadAllText(file);
                sourceFileName = file.Substring(file.LastIndexOf("\\") + 1);

                #region Get Document number/date
                try
                {
                    if (PageSource.Contains("Document No"))
                    {
                        strDocumentNo_Date = gf.GetSubString(PageSource, "Document No./Date:", "</");
                        strDocumentNo_Date = strDocumentNo_Date.Substring(strDocumentNo_Date.IndexOf(">") + 1).Trim();
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get Document No./Date : " + ex.Message);
                }
                #endregion

                #region Get Reference number
                try
                {
                    if (PageSource.Contains("Reference Number"))
                    {
                        strReferenceNo = gf.GetSubString(PageSource, "Reference Number", "</");
                        strReferenceNo = strReferenceNo.Substring(strReferenceNo.IndexOf(">") + 1).Trim();
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get Reference No. : " + ex.Message);
                }
                #endregion

                #region Get Delivary Note number/date
                try
                {
                    if (PageSource.Contains("Delivery Note No./Date"))
                    {
                        strDelivaryNoteNo_Date = gf.GetSubString(PageSource, "Delivery Note No./Date", "</");
                        strDelivaryNoteNo_Date = strDelivaryNoteNo_Date.Substring(strDelivaryNoteNo_Date.IndexOf(">") + 1).Trim();
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get Delivary Note No./Date: " + ex.Message);
                }
                #endregion

                #region Get Order number/date
                try
                {
                    if (PageSource.Contains("Order Number/Date"))
                    {
                        strOrderNoDate = gf.GetSubString(PageSource, "Order Number/Date", "</");
                        strOrderNoDate = strOrderNoDate.Substring(strOrderNoDate.IndexOf(">") + 1).Trim();
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get Order No./Date: " + ex.Message);
                }
                #endregion

                #region Get Customer number
                try
                {
                    if (PageSource.Contains("Customer Number"))
                    {
                        strCustomerNo = gf.GetSubString(PageSource, "Customer Number", "</");
                        strCustomerNo = strCustomerNo.Substring(strCustomerNo.IndexOf(">") + 1).Trim();
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get Customer Number : " + ex.Message);
                }
                #endregion

                #region Get Order Type
                try
                {
                    if (PageSource.Contains("Order Type"))
                    {
                        strOrderType = gf.GetSubString(PageSource, "Order Type", "</");
                        strOrderType = strOrderType.Substring(strOrderType.IndexOf(">") + 1).Trim();
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get Order Type: " + ex.Message);
                }
                #endregion

                #region Get UPC, Color and Unit Price
                if (PageSource.Contains("UPC") || PageSource.Contains("COLOR"))
                {
                    ArrayList arr_Tables = new ArrayList();
                    ArrayList arr_Rows = new ArrayList();
                    ArrayList arr_Columns = new ArrayList();
                    bool isNextSize = false;

                    #region Get tables
                    try
                    {
                        if (PageSource.Contains("</table>"))
                        {
                            arr_Tables = gf.GetArray(PageSource, "Extended Price", "</table>", "");
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get tables: " + ex.Message);
                    }
                    #endregion

                    if (arr_Tables.Count > 0)
                    {
                        for (int i = 0; i < arr_Tables.Count; i++)
                        {
                            try
                            {
                                arr_Rows = gf.GetArray(arr_Tables[i].ToString(), "<tr", "</tr>", "");
                                if (arr_Rows.Count > 0)
                                {
                                    for (int j = 0; j < arr_Rows.Count; j++)
                                    {
                                        try
                                        {
                                            arr_Columns = gf.GetArray(arr_Rows[j].ToString(), "<td", "</td>", "");
                                            if (arr_Columns.Count >= 3)
                                            {
                                                //changes here
                                                string tempUPC = string.Empty;
                                                if (arr_Columns.Count == 4 && arr_Columns[2].ToString().Contains("$"))
                                                {
                                                    try
                                                    {
                                                        string temp = string.Empty;
                                                        temp = gf.GetSubString(arr_Columns[0].ToString(), "<b>COLOR SIZE", "RX:");
                                                        temp = gf.GetSubString(temp, "\">", "</");
                                                        if (temp.Contains(" ") && Regex.Matches(temp, @"[a-zA-Z ]").Count > 0)
                                                        {
                                                            strColor = temp.Substring(temp.IndexOf(" ") + 1);
                                                            strUPC = temp.Substring(0, temp.IndexOf(" "));
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        WriteLog("Error on get UPC: " + ex.Message);
                                                    }

                                                }
                                                else
                                                {
                                                    strUPC = arr_Columns[0].ToString().Substring(arr_Columns[0].ToString().LastIndexOf("\">") + 2, arr_Columns[0].ToString().LastIndexOf("<") - arr_Columns[0].ToString().LastIndexOf("\">") - 2).Replace("<br/>", "").Replace("UPC", "").Trim().Replace("&amp;", "").Trim();
                                                    if (strUPC.Contains("RX: upstairs/stock") || strUPC.Contains("Postage") || strUPC.Contains("Postage & Insurance:") || strUPC.Contains("Insurance:"))
                                                    {
                                                        isNextSize = true;
                                                        strUPC = "";
                                                    }
                                                    else
                                                    {
                                                        isNextSize = false;
                                                    }

                                                    #region get color
                                                    try
                                                    {
                                                        if (strUPC.Contains(" ") && Regex.Matches(strUPC, @"[a-zA-Z ]").Count > 0)
                                                        {
                                                            strColor = strUPC.Substring(strUPC.IndexOf(" ") + 1);
                                                            strUPC = strUPC.Substring(0, strUPC.IndexOf(" "));
                                                        }
                                                        else
                                                        {
                                                            strColor = arr_Columns[1].ToString().Substring(arr_Columns[1].ToString().LastIndexOf("\">") + 2, arr_Columns[1].ToString().LastIndexOf("<") - arr_Columns[1].ToString().LastIndexOf("\">") - 2).Replace("<br/>", "").Trim();

                                                            if (strColor == "")
                                                            {
                                                                strColor = arr_Columns[2].ToString().Substring(arr_Columns[2].ToString().LastIndexOf("\">") + 2, arr_Columns[2].ToString().LastIndexOf("<") - arr_Columns[2].ToString().LastIndexOf("\">") - 2).Replace("<br/>", "").Trim();
                                                            }

                                                            if (strColor.Contains("RX: upstairs/stock") || strColor == "UPC")
                                                            {
                                                                isNextSize = true;
                                                                strColor = "";
                                                            }
                                                            else
                                                            {
                                                                isNextSize = false;
                                                            }
                                                        }

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        WriteLog("Error on get Color: " + ex.Message);
                                                    }
                                                    #endregion
                                                }


                                                if (isNextSize != true)
                                                {
                                                    try
                                                    {
                                                        int initiate = 3;

                                                        if (arr_Columns.Count == 4 && arr_Columns[2].ToString().Contains("$"))
                                                            initiate = 2;

                                                        for (int k = initiate; k < arr_Columns.Count; k++)
                                                        {
                                                            strQty = arr_Columns[k - 1].ToString().Substring(arr_Columns[k - 1].ToString().LastIndexOf("\">") + 2, arr_Columns[k - 1].ToString().LastIndexOf("<") - arr_Columns[k - 1].ToString().LastIndexOf("\">") - 2).Replace("<br/>", "").Trim();
                                                            strUnitPrice = arr_Columns[k].ToString().Substring(arr_Columns[k].ToString().LastIndexOf("\">") + 2, arr_Columns[k].ToString().LastIndexOf("<") - arr_Columns[k].ToString().LastIndexOf("\">") - 2).Replace("<br/>", "");
                                                            if (strUnitPrice.Contains("$"))
                                                            {
                                                                break;
                                                                isNextSize = false;
                                                            }
                                                            else
                                                            {
                                                                isNextSize = true;
                                                            }
                                                        }

                                                        if (strUnitPrice == "" || arr_Columns[0].ToString().Contains("Subtotal") || (strUnitPrice == "" && arr_Columns[4].ToString().Substring(arr_Columns[4].ToString().LastIndexOf("\">") + 2, arr_Columns[4].ToString().LastIndexOf("<") - arr_Columns[4].ToString().LastIndexOf("\">") - 2).Replace("<br/>", "") == ""))
                                                            isNextSize = true;
                                                        else
                                                            isNextSize = false;
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        WriteLog("Error on get Unit Price: " + ex.Message, false);
                                                        isNextSize = true;
                                                    }
                                                }

                                                if (isNextSize == false)
                                                {
                                                    WriteDataOnCsvFile(strDocumentNo_Date, strReferenceNo, strDelivaryNoteNo_Date, strOrderNoDate, strCustomerNo, strOrderType, strUPC, strColor, strQty, strUnitPrice, sourceFileName);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            WriteLog("Error on get columns: " + ex.Message);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                WriteLog("Error on get rows: " + ex.Message);
                            }
                        }
                    }
                }

                #endregion
            }
            lblEndtime.Text = DateTime.Now.ToString();
        }
        #endregion

        #region Write Data On .csv file
        private void WriteDataOnCsvFile(string strDocumentNo_Date, string strReferenceNo, string strDelivaryNoteNo_Date, string strOrderNoDate, string strCustomerNo, string strOrderType, string strUPC, string strColor, string strQty, string strUnitPrice, string sourceFileName)
        {
            try
            {
                intCount = (intCount + 1);

                System.IO.StreamWriter sw;

                if (!File.Exists(csvFilePath))
                {
                    sw = new System.IO.StreamWriter(csvFilePath, true);
                    sw.WriteLine(("#" + ("," + ("Document No./Date" + ("," + ("Reference No." + ("," + ("Delivary Note No./Date" + ("," + ("Order Note No./Date" + ("," + ("Customer No." + ("," + ("Order Type" + ("," + ("UPC" + ("," + ("Color" + ("," + ("Quantity" + ("," + ("Unit Price" + ("," + ("Source File"))))))))))))))))))))))));
                    sw.Close();
                }

                sw = new System.IO.StreamWriter(csvFilePath, true);
                sw.WriteLine(("\""
                               + (intCount + ("\"" + ("," + ("\""
                               + (strDocumentNo_Date + ("\"" + ("," + ("\""
                               + (strReferenceNo + ("\"" + ("," + ("\""
                               + (strDelivaryNoteNo_Date + ("\"" + ("," + ("\""
                               + (strOrderNoDate + ("\"" + ("," + ("\""
                               + (strCustomerNo + ("\"" + ("," + ("\""
                               + (strOrderType + ("\"" + ("," + ("\""
                               + (strUPC + ("\"" + ("," + ("\""
                               + (strColor + ("\"" + ("," + ("\""
                               + (strQty + ("\"" + ("," + ("\""
                               + (strUnitPrice + ("\"" + ("," + ("\""
                               + (sourceFileName + "\"")))))))))))))))))))))))))))))))))))))))))))))));

                WriteLog((intCount.ToString() + " record inserted successfully...."));
                sw.Close();
                lbltotalcount.Text = intCount.ToString();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                WriteLog("Error on write data in .csv file : " + ex.Message, false);
            }
        }
        #endregion

        #region Write Log
        private void WriteLog(string msg, Boolean showLog = true)
        {
            // Write to log file and display it on screen
            // if showlog=false then message will be append to log file but not display on screen
            if ((showLog == true))
            {
                txtLogview.Text = (System.DateTime.Now.ToString() + (" :: " + (msg + ("\r\n" + txtLogview.Text))));
            }

            StreamWriter sw;
            try
            {
                sw = new StreamWriter(logFilePath, true);
                sw.WriteLine((System.DateTime.Now.ToString() + (" : " + msg)));
                sw.Close();
            }
            catch (Exception ex)
            {
                WriteLog(("Error while writing in output file : " + (ex.Message + (" " + ex.StackTrace))), false);
                txtLogview.Text = ("Error while writing in output file : " + logFilePath);
            }

        }
        #endregion
    }
}
