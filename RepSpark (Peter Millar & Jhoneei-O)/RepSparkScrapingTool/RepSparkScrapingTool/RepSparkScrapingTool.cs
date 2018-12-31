using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using GenerelFunctions;
using System.Collections;
using mshtml;
using System.IO;

namespace RepSparkScrapingTool
{
    public partial class RepSparkScrapingTool : Form
    {
        #region Credentials
        string PeterMillarUserName = "kgiron";
        string PeterMillarPassword = "nike20552";
        string PeterMillarLoginUrl = "https://petermillar.repspark.net/Login.aspx";
        string PeterMillarSourceUrl = "https://petermillar.repspark.net/System/Reports/Availability/0";
        string PeterMillarProjectName = "PeterMillar_Repspark";

        string JohnnieOUserName = "mshanley@parsonskellogg.com";
        string JohnnieOPassword = "nike20552";
        string JohnnieOLoginUrl = "https://johnnie-o.repspark.net/login.aspx";
        string JohnnieOSourceUrl = "https://johnnie-o.repspark.net/System/Reports/Availability/0";
        string JohnnieOProjectName = "JohnnieO_Repspark";
        //string PeterMillarUserNameId = "txtUserName";
        //string PeterMillarPasswordId = "txtPassword";
        //string PeterMillarLoginId = "btnLogin";
        #endregion

        #region Veriable Declaration
        // global variable declaration
        GenerelFunction gf = new GenerelFunction();
        HtmlAgilityPack.HtmlDocument htmlDoc;
        Boolean processFlag = false;
        string logFilePath = string.Empty;
        string csvFilePath = string.Empty;
        string loginUrl = string.Empty;
        string sourceUrl = string.Empty;
        string ProjectName = string.Empty;
        int intCount = 0;
        ArrayList arr_ProductLinks = new ArrayList();
        string PageSource = string.Empty;
        int seconds = 20;
        #endregion

        #region Create .csv file
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

                string txtOutput = "Output File will be saved to " + csvFilePath + "\r\n";
                txtlocation.Text = txtOutput + ("Log File will be saved to " + (csvFilePath + "\r\n"));
            }
            catch (Exception ex)
            {
                WriteLog(("Error on file creation" + (ex.Message + (" " + ex.StackTrace))), false);
            }
        }
        #endregion

        #region Timer
        private void timer_Tick(object sender, EventArgs e)
        {
            seconds--;
            WriteLog("After " + seconds + " will start to scraping data.. ");

            if (seconds == 0)
            {
                timer.Stop();
                WriteLog("Started to scraping data...");
                GetProductDetail();
            }
        }
        #endregion

        #region Constuctor
        public RepSparkScrapingTool()
        {
            InitializeComponent();
            CreateFiles();
            loginUrl = PeterMillarLoginUrl;
            sourceUrl = PeterMillarSourceUrl;
            ProjectName = PeterMillarProjectName;
            Application.DoEvents();
        }
        #endregion

        #region PaterMillar change event
        private void rbtnPaterMillar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPaterMillar.Checked == true)
            {
                txtUsername.Text = PeterMillarUserName;
                txtPassword.Text = PeterMillarPassword;
                loginUrl = PeterMillarLoginUrl;
                sourceUrl = PeterMillarSourceUrl;
                ProjectName = PeterMillarProjectName;
                lblProducts.Enabled = false;
                label16.Enabled = false;
                label9.Enabled = false;
                txtPrdStart.Enabled = false;
                Application.DoEvents();
            }
        }
        #endregion

        #region JohnnieO change event
        private void rbtnJohnnieO_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnJohnnieO.Checked == true)
            {
                txtUsername.Text = JohnnieOUserName;
                txtPassword.Text = JohnnieOPassword;
                loginUrl = JohnnieOLoginUrl;
                sourceUrl = JohnnieOSourceUrl;
                ProjectName = JohnnieOProjectName;
                lblProducts.Enabled = true;
                label16.Enabled = true;
                label9.Enabled = true;
                txtPrdStart.Enabled = true;
                Application.DoEvents();
            }
        }
        #endregion

        #region LoginButton
        private void btnStart_Click(object sender, EventArgs e)
        {
            CreateFiles();
            lblStartedDateTime.Text = DateTime.Now.ToString();
            Login();
            Application.DoEvents();
        }
        #endregion

        #region Login function
        private void Login()
        {
            #region set value userName and Passworn and Click submit button
            PageSource = string.Empty;
            PageSource = GetPageSourceByBrowser(loginUrl, br);
            setValue(txtUsername.Text.ToString().Replace("\"", "").Trim(), (IHTMLDocument3)br.Document, "id", "txtUserName", "input");
            setValue(txtPassword.Text.ToString().Replace("\"", "").Trim(), (IHTMLDocument3)br.Document, "id", "txtPassword", "input");
            ClickButton((IHTMLDocument3)br.Document, "id", "btnLogin", "input");

            while (!PageSource.Contains("Logout"))
            {
                PageSource = ((IHTMLDocument2)br.Document).body.outerHTML;
            }

            if (PageSource.Contains("Logout"))
            {
                WriteLog("\r\n\r\n\r\n" + "\t\t\t\t Click to Start button.." + "\r\n\r\n");
                if (rbtnPaterMillar.Checked == true)
                {
                    GetProductDetailFromListPage();
                }
                else if (rbtnJohnnieO.Checked == true)
                {
                    GetProductLinks();
                }
            }
            #endregion
        }
        #endregion

        #region Set Value
        public void setValue(string Enteredvalue, IHTMLDocument3 ihDoc, string eleName, string value, string tagName)
        {
            try
            {
                // Function for click on specific button
                ArrayList optionArr = new ArrayList();
                IHTMLElementCollection ihec;

                ihec = ihDoc.getElementsByTagName(tagName);
                foreach (IHTMLElement El in ihec)
                {
                    if (!(El.getAttribute(eleName) == null))
                    {
                        if ((El.getAttribute(eleName).ToString().ToLower() == value.ToLower()))
                        {
                            El.setAttribute("value", Enteredvalue);
                            loadBrowser();
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                WriteLog(("Problem at setValue :" + ex.Message), false);
            }
        }
        #endregion

        #region ClickButton
        private void ClickButton(IHTMLDocument3 ihDoc, string eleName, string eleVal, string tagName)
        {
            //Function for click on specific button
            try
            {
                ArrayList optionArr = new ArrayList();
                IHTMLElementCollection ihec;
                ihec = ihDoc.getElementsByTagName(tagName);
                foreach (IHTMLElement El in ihec)
                {
                    string a = El.outerHTML;
                    if ((a == null))
                    {
                        a = "";
                    }

                    string b = "";
                    try
                    {
                        b = El.getAttribute(eleName).ToString();
                    }
                    catch (Exception ex)
                    {
                        WriteLog(("Error on ClickButton function" + (ex.Message + (" " + ex.StackTrace))), false);
                    }

                    if ((b == null))
                    {
                        b = "";
                    }

                    if ((b.ToLower() == eleVal.ToLower()))
                    {
                        El.click();
                        WriteLog(("Clicked successfully.....:" + b.ToLower().ToString()));
                        loadBrowser();
                        loadDoc((IHTMLDocument2)br.Document);
                        for (int i = 0; (i <= 1000); i++)
                        {
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(6);
                        }

                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                WriteLog(("Error on ClickButton function" + (ex.Message + (" " + ex.StackTrace))), false);
            }

        }
        #endregion

        #region Get Product Detail From ListPage
        private void GetProductDetailFromListPage()
        {
            PageSource = GetPageSourceByBrowser(sourceUrl, br);
            htmlDoc = new HtmlAgilityPack.HtmlDocument();

            #region get products of  first page
            htmlDoc.LoadHtml(PageSource);

            foreach (HtmlNode prdNode in htmlDoc.DocumentNode.SelectNodes("//table[@id='gv']//tr[@class='availabilityListRow']"))
            {
                #region Local variable declaration
                string strProductCategory = string.Empty;
                string strProductId = string.Empty;
                string strImageUrl = string.Empty;
                string strProductName = string.Empty;
                string strProductNumber = string.Empty;
                string strColor = string.Empty;
                string strDim = string.Empty;
                string strAvailDate = string.Empty;
                string strSeason = string.Empty;
                string strWholeSalePrice = string.Empty;
                string strDiscountPrice = string.Empty;
                string strSizes = string.Empty;
                #endregion

                #region Get Product category
                try
                {
                    strProductCategory = prdNode.SelectSingleNode(".//span[@id='ProductCategoryName']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get product category name : " + ex.Message);
                }
                #endregion

                #region Get ProductId
                try
                {
                    strProductId = prdNode.SelectSingleNode(".//span[@id='ltrProductId']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get productId : " + ex.Message);
                }
                #endregion

                #region Get Product Name
                try
                {
                    strProductName = prdNode.SelectSingleNode(".//span[@id='ltrProductName']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get product name : " + ex.Message);
                }
                #endregion

                #region Get Product number
                try
                {
                    strProductNumber = prdNode.SelectSingleNode(".//span[@class='prdnmbr']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get product number : " + ex.Message);
                }
                #endregion

                #region Get Color
                try
                {
                    strColor = prdNode.SelectSingleNode(".//span[@id='colorName']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get color name : " + ex.Message);
                }
                #endregion

                #region Get whole sale price
                try
                {
                    strWholeSalePrice = prdNode.SelectSingleNode(".//span[@id='wholesalePrice']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get whole sale price : " + ex.Message);
                }
                #endregion

                #region Get Discounted Price
                try
                {
                    strDiscountPrice = prdNode.SelectSingleNode(".//span[@id='wholesaleDiscountedPriceLabel']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get Discounted Price : " + ex.Message, false);
                }
                #endregion

                #region Get sizes
                try
                {
                    foreach (HtmlNode sizeNode in prdNode.SelectNodes(".//table[@id='SizeDataList']//span[@class='szn']"))
                    {
                        strSizes = strSizes.ToString() + "," + sizeNode.InnerText.Trim();
                    }
                    strSizes = strSizes.Substring(1);
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get sizes : " + ex.Message);
                }
                #endregion

                #region Get available date
                try
                {
                    strAvailDate = prdNode.SelectSingleNode(".//span[@id='SellStartDate']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get available date: " + ex.Message);
                }
                #endregion

                #region Get seasion name
                try
                {
                    strSeason = prdNode.SelectSingleNode(".//span[@id='SeasonName']").InnerText.Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get season name : " + ex.Message);
                }
                #endregion

                #region Get ImageUrl
                try
                {
                    strImageUrl = prdNode.SelectSingleNode(".//img").GetAttributeValue("src", string.Empty).ToString().Replace("resize(80,80)", "resize(1000,1000)").Replace("width=80", "width=1000").Replace("height=80", "height=1000");
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get image url : " + ex.Message);
                }
                #endregion

                #region Call to write date on .csv file
                Write_Data_On_CsvFile(strProductCategory, strProductId, strProductName, strProductNumber, strColor, strWholeSalePrice, strDiscountPrice, strSizes, strAvailDate, strSeason, strImageUrl);
                #endregion
            }
            #endregion

            while (PageSource.Contains("value=»"))
            {
                #region click to next page
                try
                {
                    if (PageSource.Contains("value=»"))
                    {
                        ClickNextPage((IHTMLDocument3)br.Document, "value=»", "INPUT");
                        PageSource = ((IHTMLDocument2)br.Document).body.outerHTML;
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on click to next page" + ex.Message);
                }
                #endregion

                htmlDoc.LoadHtml(PageSource);

                foreach (HtmlNode prdNode in htmlDoc.DocumentNode.SelectNodes("//table[@id='gv']//tr[@class='availabilityListRow']"))
                {
                    #region Local variable declaration
                    string strProductCategory = string.Empty;
                    string strProductId = string.Empty;
                    string strImageUrl = string.Empty;
                    string strProductName = string.Empty;
                    string strProductNumber = string.Empty;
                    string strColor = string.Empty;
                    string strDim = string.Empty;
                    string strAvailDate = string.Empty;
                    string strSeason = string.Empty;
                    string strWholeSalePrice = string.Empty;
                    string strDiscountPrice = string.Empty;
                    string strSizes = string.Empty;
                    #endregion

                    #region Get Product category
                    try
                    {
                        strProductCategory = prdNode.SelectSingleNode(".//span[@id='ProductCategoryName']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get product category name : " + ex.Message);
                    }
                    #endregion

                    #region Get ProductId
                    try
                    {
                        strProductId = prdNode.SelectSingleNode(".//span[@id='ltrProductId']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get productId : " + ex.Message);
                    }
                    #endregion

                    #region Get Product Name
                    try
                    {
                        strProductName = prdNode.SelectSingleNode(".//span[@id='ltrProductName']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get product name : " + ex.Message);
                    }
                    #endregion

                    #region Get Product number
                    try
                    {
                        strProductNumber = prdNode.SelectSingleNode(".//span[@class='prdnmbr']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get product number : " + ex.Message);
                    }
                    #endregion

                    #region Get Color
                    try
                    {
                        strColor = prdNode.SelectSingleNode(".//span[@id='colorName']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get color name : " + ex.Message);
                    }
                    #endregion

                    #region Get whole sale price
                    try
                    {
                        strWholeSalePrice = prdNode.SelectSingleNode(".//span[@id='wholesalePrice']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get whole sale price : " + ex.Message);
                    }
                    #endregion

                    #region Get Discounted Price
                    try
                    {
                        strDiscountPrice = prdNode.SelectSingleNode(".//span[@id='wholesaleDiscountedPriceLabel']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get Discounted Price : " + ex.Message, false);
                    }
                    #endregion

                    #region Get sizes
                    try
                    {
                        foreach (HtmlNode sizeNode in prdNode.SelectNodes(".//table[@id='SizeDataList']//span[@class='szn']"))
                        {
                            strSizes = strSizes.ToString() + "," + sizeNode.InnerText.Trim();
                        }
                        strSizes = strSizes.Substring(1);
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get sizes : " + ex.Message);
                    }
                    #endregion

                    #region Get available date
                    try
                    {
                        strAvailDate = prdNode.SelectSingleNode(".//span[@id='SellStartDate']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get available date: " + ex.Message);
                    }
                    #endregion

                    #region Get seasion name
                    try
                    {
                        strSeason = prdNode.SelectSingleNode(".//span[@id='SeasonName']").InnerText.Trim();
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get season name : " + ex.Message);
                    }
                    #endregion

                    #region Get ImageUrl
                    try
                    {
                        strImageUrl = prdNode.SelectSingleNode(".//img").GetAttributeValue("src", string.Empty).ToString().Replace("resize(80,80)", "resize(1000,1000)").Replace("width=80", "width=1000").Replace("height=80", "height=1000");
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get image url : " + ex.Message);
                    }
                    #endregion

                    #region Call to write date on .csv file
                    Write_Data_On_CsvFile(strProductCategory, strProductId, strProductName, strProductNumber, strColor, strWholeSalePrice, strDiscountPrice, strSizes, strAvailDate, strSeason, strImageUrl);
                    #endregion
                }
            }
            lblEndtime.Text = System.DateTime.Now.ToString();
            WriteLog("\r\n\r\n\r\n" + "\t\t\t\t All data are scraped.." + "\r\n\r\n");
            Application.DoEvents();
        }
        #endregion

        #region Get Product Links
        private void GetProductLinks()
        {
            htmlDoc = new HtmlAgilityPack.HtmlDocument();
            PageSource = ((IHTMLDocument2)br.Document).body.outerHTML;
            htmlDoc.LoadHtml(PageSource);
            foreach (HtmlNode prdNode in htmlDoc.DocumentNode.SelectNodes("//div[@class='thumbnailImg no-height']//div[1]"))
            {
                if (prdNode.GetAttributeValue("data-href", string.Empty).Trim().Contains("GetView?productId"))
                    arr_ProductLinks.Add("https://johnnie-o.repspark.net" + prdNode.GetAttributeValue("data-href", string.Empty).Trim());
            }

            int TotalPages = Int32.Parse(htmlDoc.DocumentNode.SelectSingleNode("//span[@class='page-count']").InnerText.Replace("of", "").Trim());
            for (int l = 1; l < TotalPages; l++)
            {
                ClickNextPage((IHTMLDocument3)br.Document, "class=\"fa fa-chevron-right\"", "I");
                PageSource = ((IHTMLDocument2)br.Document).body.outerHTML;
                htmlDoc.LoadHtml(PageSource);
                foreach (HtmlNode prdNode in htmlDoc.DocumentNode.SelectNodes("//div[@class='thumbnailImg no-height']//div[1]"))
                {
                    if (prdNode.GetAttributeValue("data-href", string.Empty).Trim().Contains("GetView?productId"))
                        arr_ProductLinks.Add("https://johnnie-o.repspark.net" + prdNode.GetAttributeValue("data-href", string.Empty).Trim());
                }
                lblProducts.Text = arr_ProductLinks.Count.ToString();
            }

            StartTimer();
        }
        #endregion

        #region Start timer function
        private void StartTimer()
        {
            lblProducts.Text = arr_ProductLinks.Count.ToString();
            txtPrdStart.Text = "1";
            WriteLog("\r\n\r\n" + "Enter index number of product to start from there.." + "\r\n" + "Other wise it will start automaticaly from index number 1 of product after " + seconds + " seconds " + "\r\n\r\n");
            WriteLog("After " + seconds + " will start to scraping data.. ");
            Application.DoEvents();
            timer.Enabled = true;
            timer.Start();
        }
        #endregion

        #region Get Product details
        private void GetProductDetail()
        {
            #region Local variable declaration
            string strCategory = string.Empty;
            string strInventoryStatus = string.Empty;
            string strProductId = string.Empty;
            string strProductName = string.Empty;
            string strSKU = string.Empty;
            string strWholeSalePrice = string.Empty;
            string strRetailPrice = string.Empty;
            string strColor = string.Empty;
            string strSize = string.Empty;
            string strIMMED = string.Empty;
            string strDateInventory = string.Empty;
            string strImage1 = string.Empty;
            string strImage2 = string.Empty;
            string strImage3 = string.Empty;
            string strProductLink = string.Empty;
            ArrayList arr_images = null;
            ArrayList arr_Sizes = null;
            ArrayList arr_IMMED = null;
            ArrayList arr_DateInventory = null;

            #endregion

            string prdPageSource = string.Empty;
            lblProducts.Text = arr_ProductLinks.Count.ToString();
            Application.DoEvents();

            for (int i = Int32.Parse(txtPrdStart.Text)-1; i < arr_ProductLinks.Count; i++)
            {
                lblCurrentProduct.Text = (i + 1).ToString();
                Application.DoEvents();

                string ProductLink = arr_ProductLinks[i].ToString();
                prdPageSource = GetPageSourceByBrowser(ProductLink, br);

                #region get Product Id
                try
                {
                    strProductId = gf.GetSubString(ProductLink, "productId=", "&").Trim();
                    // ProductLink.Substring(ProductLink.IndexOf("productId=") + 10, 8);
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get ProductId : " + ex.Message);
                }
                #endregion

                #region get Product name
                try
                {
                    strProductName = gf.GetSubString(prdPageSource, "data-productname=\"", "\"").Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get product name : " + ex.Message);
                }
                #endregion

                #region get Product SKU
                try
                {
                    strSKU = gf.GetSubString(prdPageSource, "Product #", "</b>").Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get SKU : " + ex.Message);
                }
                #endregion

                #region get wholesale price
                try
                {
                    strWholeSalePrice = gf.GetSubString(prdPageSource, "Wholesale</span> <b>", "</b>").Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get wholesale price : " + ex.Message);
                }
                #endregion

                #region get retail price
                try
                {
                    strRetailPrice = gf.GetSubString(prdPageSource, "Retail</span> <b>", "</b>").Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get retail price : " + ex.Message);
                }
                #endregion

                #region get color
                try
                {
                    strColor = gf.GetSubString(prdPageSource, "Color:", "</b>").Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get color : " + ex.Message);
                }
                #endregion

                string strCategoryInventoryStatus = gf.GetSubString(prdPageSource, "</table>", "Color:").Trim();

                #region Category
                try
                {
                    strCategory = gf.GetSubString(strCategoryInventoryStatus, "<BR>", "</DIV>").Replace("<DIV>", "").Trim();
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get category : " + ex.Message);
                }
                #endregion

                #region Category
                try
                {
                    strInventoryStatus = strCategoryInventoryStatus.Substring(strCategoryInventoryStatus.IndexOf("<BR>"));
                    strInventoryStatus = strInventoryStatus.Substring(strInventoryStatus.IndexOf("</DIV>"));
                    strInventoryStatus = gf.GetSubString(strInventoryStatus, "<DIV>", "</DIV>");
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get category : " + ex.Message);
                }
                #endregion

                #region get images
                try
                {
                    strImage1 = string.Empty;
                    strImage2 = string.Empty;
                    strImage3 = string.Empty;

                    arr_images = gf.GetArray(prdPageSource, "productimage img-thumbnail", ">", "");

                    if (arr_images.Count > 0)
                    {
                        for (int j = 0; j < arr_images.Count; j++)
                        {
                            if (arr_images[j].ToString().Contains("width=40"))
                            {
                                switch (j)
                                {
                                    case 0: strImage1 = gf.GetSubString(arr_images[j].ToString(), "src=\"", "\"").Replace("resize(40,40)", "resize(1000,1000)").Replace("width=40", "width=1000").Replace("height=40", "height=1000").Trim();
                                        break;
                                    case 1: strImage2 = gf.GetSubString(arr_images[j].ToString(), "src=\"", "\"").Replace("resize(40,40)", "resize(1000,1000)").Replace("width=40", "width=1000").Replace("height=40", "height=1000").Trim();
                                        break;
                                    case 2: strImage3 = gf.GetSubString(arr_images[j].ToString(), "src=\"", "\"").Replace("resize(40,40)", "resize(1000,1000)").Replace("width=40", "width=1000").Replace("height=40", "height=1000").Trim();
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get images : " + ex.Message);
                }
                #endregion

                string srcSize = gf.GetSubString(prdPageSource, "sizes-table", "</table>").Trim();
                htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(srcSize);

                #region get size
                try
                {
                    arr_Sizes = new ArrayList();
                    foreach (HtmlNode sizeNode in htmlDoc.DocumentNode.SelectNodes("//th"))
                    {
                        if (!sizeNode.InnerText.Contains("SIZE") && sizeNode.InnerText.Trim() != "" && !sizeNode.InnerText.Contains("IMMED") && !sizeNode.InnerText.Contains("/"))
                        {
                            arr_Sizes.Add(sizeNode.InnerText.Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get sizes : " + ex.Message);
                }
                #endregion

                #region get IMMED
                try
                {
                    arr_IMMED = new ArrayList();
                    foreach (HtmlNode sizeNode in htmlDoc.DocumentNode.SelectNodes("//tr[2]//td"))
                    {
                        arr_IMMED.Add(sizeNode.InnerText.Trim());
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get IMMED : " + ex.Message);
                }
                #endregion

                #region get Date inventory
                try
                {
                    arr_DateInventory = new ArrayList();
                    foreach (HtmlNode dateInventoryNode in htmlDoc.DocumentNode.SelectNodes("//tr[3]//td"))
                    {
                        arr_DateInventory.Add(dateInventoryNode.InnerText.Trim() +" ("+ htmlDoc.DocumentNode.SelectSingleNode("//tr[3]//th[1]").InnerText.Trim()+")");
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("Error on get date inventory : " + ex.Message, false);
                }
                #endregion

                #region call to write data on .csv file
                if (arr_Sizes.Count > 0)
                {
                    for (int k = 0; k < arr_Sizes.Count; k++)
                    {
                        strSize = string.Empty;
                        strIMMED = string.Empty;
                        strDateInventory = string.Empty;

                        if (arr_Sizes.Count > k)
                            strSize = arr_Sizes[k].ToString();

                        if (arr_IMMED.Count > k)
                            strIMMED = arr_IMMED[k].ToString();

                        if (arr_DateInventory.Count > k)
                            strDateInventory = arr_DateInventory[k].ToString();

                        Write_Data_On_CsvFile_Johnnie(strCategory, strProductId, strProductName, strSKU, strWholeSalePrice, strRetailPrice, strColor, strSize, strIMMED, strDateInventory,strInventoryStatus, strImage1, strImage2, strImage3, ProductLink);
                    }
                }
                else
                {
                    Write_Data_On_CsvFile_Johnnie(strCategory, strProductId, strProductName, strSKU, strWholeSalePrice, strRetailPrice, strColor, "", "", "", strInventoryStatus, strImage1, strImage2, strImage3, ProductLink);
                }
                #endregion
            }

            lblEndtime.Text = System.DateTime.Now.ToString();
            WriteLog("\r\n\r\n\r\n" + "\t\t\t\t All data are scraped.." + "\r\n\r\n");
            Application.DoEvents();
        }
        #endregion

        #region Click to next page
        private void ClickNextPage(IHTMLDocument3 ihDoc, string matchString, string tagName)
        {
            try
            {
                ArrayList optionArr = new ArrayList();
                IHTMLElementCollection ihec;
                ihec = ihDoc.getElementsByTagName(tagName);
                foreach (IHTMLElement El in ihec)
                {
                    string a = El.outerHTML;
                    if ((a == null))
                    {
                        a = "";
                    }

                    if ((a.ToLower().Contains(matchString.ToLower())))
                    {
                        El.click();
                        WriteLog(("Clicked successfully.....:" + a.ToLower().ToString()));
                        loadBrowser();
                        loadDoc((IHTMLDocument2)br.Document);
                        for (int i = 0; (i <= 1000); i++)
                        {
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(6);
                        }

                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                WriteLog(("Error on ClickButton function" + (ex.Message + (" " + ex.StackTrace))), false);
            }
        }
        #endregion

        #region Write_Data_On_CsvFile
        private void Write_Data_On_CsvFile(string strProductCategory, string strProductId, string strProductName, string strProductNumber, string strColor, string strWholeSalePrice, string strDiscountPrice, string strSizes, string strAvailDate, string strSeason, string strImageUrl)
        {
            try
            {
                intCount = (intCount + 1);

                System.IO.StreamWriter sw;
                if (!File.Exists(csvFilePath))
                {
                    sw = new System.IO.StreamWriter(csvFilePath, true);
                    sw.WriteLine(("#" + ("," + ("Category" + ("," + ("ProductId" + ("," + ("Product Name" + ("," + ("Product Number" + ("," + ("Color" + ("," + ("Whole Sale Price" + ("," + ("Discount Price" + ("," + ("Sizes" + ("," + ("Avail Date" + ("," + ("Season" + ("," + ("Image"))))))))))))))))))))))));
                    sw.Close();
                }

                sw = new System.IO.StreamWriter(csvFilePath, true);

                sw.WriteLine(("\""
                               + (intCount + ("\"" + ("," + ("\""
                               + (strProductCategory + ("\"" + ("," + ("\""
                               + (strProductId + ("\"" + ("," + ("\""
                               + (strProductName + ("\"" + ("," + ("\""
                               + (strProductNumber + ("\"" + ("," + ("\""
                               + (strColor + ("\"" + ("," + ("\""
                               + (strWholeSalePrice + ("\"" + ("," + ("\""
                               + (strDiscountPrice + ("\"" + ("," + ("\""
                               + (strSizes + ("\"" + ("," + ("\""
                               + (strAvailDate + ("\"" + ("," + ("\""
                               + (strSeason + ("\"" + ("," + ("\""
                               + (strImageUrl + "\"")))))))))))))))))))))))))))))))))))))))))))))));

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

        #region Write_Data_On_CsvFile_Johnnie
        private void Write_Data_On_CsvFile_Johnnie(string strCategory, string strProductId, string strProductName, string strSKU, string strWholeSalePrice, string strRetailPrice, string strColor, string strSize, string strIMMED, string strDateInventory,string strInventoryStatus, string strImage1, string strImage2, string strImage3, string strProductLink)
        {
            try
            {
                intCount = (intCount + 1);

                System.IO.StreamWriter sw;
                if (!File.Exists(csvFilePath))
                {
                    sw = new System.IO.StreamWriter(csvFilePath, true);
                    sw.WriteLine(("#" + ("," + ("Category" + ("," + ("ProductId" + ("," + ("Product Name" + ("," + ("SKU" + ("," + ("Whole Sale Price" + ("," + ("Retail Price" + ("," + ("Color" + ("," + ("Size" + ("," + ("IMMED" + ("," + ("Inventory (Date)" + ("," + ("Inventory Status" + ("," + ("Image1" + ("," + ("Image2" + ("," + ("Image3" + ("," + ("ProductLink"))))))))))))))))))))))))))))))));
                    sw.Close();
                }

                sw = new System.IO.StreamWriter(csvFilePath, true);

                sw.WriteLine(("\""
                               + (intCount + ("\"" + ("," + ("\""
                               + (strCategory + ("\"" + ("," + ("\""
                               + (strProductId + ("\"" + ("," + ("\""
                               + (strProductName + ("\"" + ("," + ("\""
                               + (strSKU + ("\"" + ("," + ("\""
                               + (strWholeSalePrice + ("\"" + ("," + ("\""
                               + (strRetailPrice + ("\"" + ("," + ("\""
                               + (strColor + ("\"" + ("," + ("\""
                               + (strSize + ("\"" + ("," + ("\""
                               + (strIMMED + ("\"" + ("," + ("\""
                               + (strDateInventory + ("\"" + ("," + ("\""
                               + (strInventoryStatus + ("\"" + ("," + ("\""
                               + (strImage1 + ("\"" + ("," + ("\""
                               + (strImage2 + ("\"" + ("," + ("\""
                               + (strImage3 + ("\"" + ("," + ("\""
                               + (strProductLink + "\"")))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))));

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

        #region Get Page Source By Browser
        private string GetPageSourceByBrowser(string url, AxSHDocVw.AxWebBrowser br)
        {
            string sourcecode = "";

            try
            {
                url = url.Replace("&amp;", "&");
                WriteLog(("Please wait while requesting URL : " + url));
                br.Navigate(url);
                IHTMLDocument2 objdoc;
                while ((br.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
                {
                    Application.DoEvents();
                }

                objdoc = (IHTMLDocument2)br.Document;

                while ((objdoc.readyState != "complete"))
                {
                    Application.DoEvents();
                }
                sourcecode = ((HTMLDocument)br.Document).body.outerHTML;
            }
            catch (Exception ex)
            {
                WriteLog(("Error : " + ex.ToString()), false);
            }
            return sourcecode;
        }
        #endregion

        #region load Browser
        private void loadBrowser()
        {
            while (!(this.br.ReadyState == SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
            {
                System.Threading.Thread.Sleep(2);
                Application.DoEvents();
            }
        }
        #endregion

        #region Load document
        public void loadDoc(IHTMLDocument2 ihDoc)
        {
            while ((ihDoc.readyState != "complete"))
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
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
                // setStatus(g_strProc_counter)
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
