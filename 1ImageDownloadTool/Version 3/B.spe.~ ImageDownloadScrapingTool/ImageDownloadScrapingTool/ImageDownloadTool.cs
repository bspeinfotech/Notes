using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownloadScrapingTool
{
    public partial class ImageDownloadTool : Form
    {
        #region general variable declaration
        string upFilePath = string.Empty;
        string fileTextSource = string.Empty;
        string[] arr_TotalRecords;
        int intCount = 0;
        string LogFilePath = string.Empty;
        string OutputFilePath = string.Empty;
        string ImageDownloadedLocation = string.Empty;
        string imageFolderName = string.Empty;
        string locationPath = string.Empty;
        string userName = string.Empty;
        string password = string.Empty;
        string SelectedWebsite = string.Empty;
        #endregion

        #region Create .csv file of Image url and path mapping
        public void CreateFiles()
        {
            try
            {
                // Create log & output Files with specific Folder
                string dirName;

                dirName = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Trec\\" + imageFolderName.Trim() + "\\" + imageFolderName.Trim() + "Images\\");
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                locationPath = dirName;

                dirName = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Trec\\" + imageFolderName.Trim() + "\\" + imageFolderName.Trim() + " Image Url-Path Mapping\\Log");
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                LogFilePath = (dirName + ("\\" + imageFolderName.Trim() + "_ImgUrlPathMapping_Log_"
                            + (DateTime.Now.Month.ToString() + ("_"
                            + (DateTime.Now.Day.ToString() + ("_"
                            + (DateTime.Now.Year.ToString() + ("_"
                            + (DateTime.Now.Hour.ToString() + ("_"
                            + (DateTime.Now.Minute.ToString() + ".txt")))))))))));

                dirName = (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Trec\\" + imageFolderName.Trim() + "\\" + imageFolderName.Trim() + " Image Url-Path Mapping\\Output");
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                OutputFilePath = (dirName + ("\\" + imageFolderName.Trim() + "_ImgUrlPathMapping_Output_"
                            + (DateTime.Now.Month.ToString() + ("_"
                            + (DateTime.Now.Day.ToString() + ("_"
                            + (DateTime.Now.Year.ToString() + ("_"
                            + (DateTime.Now.Hour.ToString() + ("_"
                            + (DateTime.Now.Minute.ToString() + ".csv")))))))))));

                txtFilePath.Text = (("Image Downloaded Location : " + (locationPath + "\r\n")) + ("Output file stored at : " + (OutputFilePath + "\r\n")) + ("Log file stored at : " + (LogFilePath + "\r\n")));
            }
            catch (Exception ex)
            {
                WriteLog("Error on file create : " + ex.Message);
            }
        }
        #endregion

        #region Constructor
        public ImageDownloadTool()
        {
            InitializeComponent();
            Bind_Websites_ComboBox();
            LoadCredentialAndFolderName();
        }
        #endregion

        #region Bind Websites ComboBox
        private void Bind_Websites_ComboBox()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("UnderArmour", "UnderArmour");
            items.Add("UnderArmourUniforms", "UnderArmourUniforms");
            items.Add("Fila", "Fila");
            items.Add("BadgerSport", "BadgerSport");
            items.Add("Wilson", "Wilson");
            items.Add("Nike", "Nike");
            items.Add("Augustra", "Augustra");
            items.Add("Agron", "Agron");
            items.Add("DUC", "DUC");
            items.Add("Mizuno", "Mizuno");
            items.Add("TeamChampionUsa", "TeamChampionUsa");
            items.Add("Linksoul", "Linksoul");
            items.Add("Speedo", "Speedo");
            items.Add("Petermillar_Repspark", "Petermillar_Repspark");
            items.Add("JhonnieO_Repspark", "JhonnieO_Repspark");
            items.Add("PCNA", "PCNA");
            items.Add("FootJoy", "FootJoy");
            items.Add("SSActivewear (Original image)", "SSActivewearImages");
            items.Add("SSActivewear (Swatch image)", "SSActivewearSwatchImages");
            items.Add("Lacoste", "Lacoste");

            ddlWebsites.DataSource = new BindingSource(items, null);
            ddlWebsites.DisplayMember = "value";
            ddlWebsites.ValueMember = "key";

            SelectedWebsite = ((KeyValuePair<string, string>)ddlWebsites.Items[0]).Value;
        }
        #endregion

        #region Load Credential and Folder Name
        private void LoadCredentialAndFolderName()
        {
            #region Folder Name and Credential for Selected Website
            if (SelectedWebsite == "Nike")
            {
                txtFolderName.Text = "Nike";
                txtUserName.Text = "customerservice@teamconnection.com";
                txtPassword.Text = "#Volleyba11";
            }
            else
                if (SelectedWebsite == "Lacoste")
                {
                    txtFolderName.Text = "Lacoste";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
                else if (SelectedWebsite == "TeamChampionUsa")
                {
                    txtFolderName.Text = "TeamChampionUsa";
                    //imageFolderName = "TeamAthletics";
                    //imageFolderName = "TeamAthletics_Swatch";
                    txtUserName.Text = "teamcon";
                    txtPassword.Text = "champ14";
                }
                else if (SelectedWebsite == "Linksoul")
                {
                    txtFolderName.Text = "Linksoul";
                    txtUserName.Text = "mshanley@parsonskellogg.com";
                    txtPassword.Text = "nike20552";
                }
                else if (SelectedWebsite == "Speedo")
                {
                    txtFolderName.Text = "Speedo";
                    txtUserName.Text = "dbolick@teamconnection.com";
                    txtPassword.Text = "tc1234";
                }
                else if (SelectedWebsite == "Petermillar_Repspark")
                {
                    txtFolderName.Text = "PeterMillar_RepSpark";
                    txtUserName.Text = "kgiron";
                    txtPassword.Text = "nike20552";
                }
                else if (SelectedWebsite == "JhonnieO_Repspark")
                {
                    txtFolderName.Text = "JhonnieO_RepSpark";
                    txtUserName.Text = "kgiron";
                    txtPassword.Text = "nike20552";
                }
                else if (SelectedWebsite == "PCNA")
                {
                    txtFolderName.Text = "PCNA";
                    txtUserName.Text = "galbert@parsonskellogg.com";
                    txtPassword.Text = "Gail@8998";
                }
                else if (SelectedWebsite == "FootJoy")
                {
                    txtFolderName.Text = "FootJoy";
                }
                else if (SelectedWebsite == "SSActivewearImages")
                {
                    txtFolderName.Text = "SSActivewearImages";
                }
                else if (SelectedWebsite == "SSActivewearSwatchImages")
                {
                    txtFolderName.Text = "SSActivewearSwatchImages";
                }
                else
                {
                    txtFolderName.Text = "Downloaded_Images";
                }
            #endregion
        }
        #endregion

        #region ddlWebsites_SelectedIndexChanged
        private void ddlWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((KeyValuePair<string, string>)ddlWebsites.SelectedItem).Value.ToString() != "")
            {
                SelectedWebsite = ((KeyValuePair<string, string>)ddlWebsites.SelectedItem).Value;
                txtFolderName.Text = SelectedWebsite;
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }
        #endregion

        #region Select file button
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = "c:\\";
            OpenFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                upFilePath = OpenFileDialog.FileName;
            }

            lblImageName.Text = upFilePath.Substring(upFilePath.LastIndexOf("\\") + 1);
            Application.DoEvents();
        }
        #endregion

        #region Project/Folder name changed event
        private void txtFolderName_TextChanged(object sender, EventArgs e)
        {
            if (txtFolderName.Text != "")
            {
                txtFolderName.Text = txtFolderName.Text;
                txtFolderName.ForeColor = Color.Black;
            }
        }
        #endregion

        #region Start button
        private void btnStart_Click(object sender, EventArgs e)
        {

            if (upFilePath == "")
            {
                lblSelectFile.Visible = true;
            }
            else
            {
                lblSelectFile.Visible = false;
                txtLog.Text = (System.DateTime.Now.ToString() + (" :: " + ("\n\t\n\t \t\t" + "Please wait" + ("\r\n" + txtLog.Text))));

                #region Folder Name and Credential from TextBox
                imageFolderName = txtFolderName.Text.Trim();
                userName = txtUserName.Text.Trim();
                password = txtPassword.Text.Trim();
                #endregion

                #region Download image
                if (imageFolderName != "" && imageFolderName != "Please enter Project/folder name..")
                {
                    // create .csv output file and log file
                    CreateFiles();
                    ImageDownloadedLocation = locationPath;

                    #region get records from .csv file
                    lblStartTime.Text = DateTime.Now.ToString();
                    try
                    {
                        StreamReader sr = new StreamReader(upFilePath, System.Text.Encoding.Default);
                        fileTextSource = sr.ReadToEnd();
                        arr_TotalRecords = fileTextSource.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on open file : " + ex.Message, true);
                    }
                    #endregion

                    Application.DoEvents();

                    try
                    {
                        int imageIndex = 0;
                        string lastImageUrl = "N/A";
                        string lastImageName = string.Empty;
                        for (int i = 0; i < arr_TotalRecords.Length - 1; i++)
                        {
                            lblCurrentRecord.Text = (i + 1).ToString();
                            string imageUrl = string.Empty;
                            string imageName = string.Empty;
                            imageUrl = string.Empty;
                            imageUrl = RemoveIllegalCharFromLink(arr_TotalRecords[i].Trim());

                            if (imageUrl != "")
                            {
                                if (imageUrl != lastImageUrl)
                                {
                                    lastImageUrl = imageUrl;
                                    //imageUrl = RemoveIlligleChar(imageUrl);
                                    #region Make Image Name
                                    try
                                    {

                                        if (SelectedWebsite == "UnderArmourUniforms")
                                        {
                                            imageName = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1);
                                        }
                                        else if (SelectedWebsite == "Fila")
                                        {
                                            imageName = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1).Replace(".jpg", ".png");
                                            if (imageName.Contains("B2B_Site_Large-"))
                                                imageName = imageName.Replace("B2B_Site_Large-", "");
                                        }
                                        else if (SelectedWebsite == "Wilson" || SelectedWebsite == "SSActivewearImages" || SelectedWebsite == "SSActivewearSwatchImages" || SelectedWebsite == "Boxercraft")
                                        {
                                            imageName = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1).Replace(".jpg", ".png");
                                        }
                                        else if (SelectedWebsite == "Nike")
                                        {
                                            imageName = imageUrl.Split('?')[0];
                                            if (imageName.Contains(".JPG") || imageName.Contains(".jpg") || imageName.Contains(".png"))
                                                imageName = imageName.Substring(imageName.LastIndexOf("/") + 1).Replace(".JPG", ".png");
                                            else
                                                imageName = imageName.Substring(imageName.LastIndexOf("/") + 1) + ".png";
                                        }
                                        else if (SelectedWebsite == "BadgerSport")
                                        {
                                            imageName = imageUrl.Split('?')[0].Substring(imageUrl.Split('?')[0].LastIndexOf("/") + 1);
                                        }
                                        else if (SelectedWebsite == "Augustra")
                                        {
                                            imageUrl = "http:" + imageUrl;
                                            imageName = imageUrl.Split('?')[0];
                                            imageName = imageName.Substring(imageName.LastIndexOf("/") + 1) + ".png";
                                        }
                                        else if (SelectedWebsite == "Agron" || SelectedWebsite == "UnderArmour" || SelectedWebsite == "TeamChampionUsa" || SelectedWebsite == "FootJoy")
                                        {
                                            imageName = imageUrl.Substring(imageUrl.LastIndexOf("/") + 1).Split('?')[0].ToString() + ".png";
                                        }
                                        else if (SelectedWebsite == "Lacoste" || SelectedWebsite == "Linksoul" || SelectedWebsite == "Petermillar_Repspark")
                                        {
                                            imageName = imageUrl.Substring(imageUrl.LastIndexOf("/") + 1).Split('?')[0].ToString().Replace(".jpg", ".png");
                                        }
                                        else if (SelectedWebsite == "JhonnieO_Repspark")
                                        {
                                            // Note : note merge it with PeterMillar and Linksoul
                                            imageName = imageUrl.Substring(0, imageUrl.LastIndexOf("?"));
                                            imageName = imageName.Substring(imageName.LastIndexOf("/") + 1).Replace(".jpg", ".png");
                                        }

                                        else if (SelectedWebsite == "Speedo")
                                        {
                                            if (imageUrl.Contains("/?"))
                                                imageName = imageUrl.Substring(0, imageUrl.IndexOf("/?"));
                                            else
                                                imageName = imageUrl.Substring(0, imageUrl.IndexOf("?"));

                                            imageName = imageName.Substring(imageName.LastIndexOf("/") + 1) + ".png";
                                        }
                                        else if (SelectedWebsite == "PCNA")
                                        {
                                            imageName = imageUrl.Substring(0, imageUrl.IndexOf("/en"));
                                            imageName = imageName.Substring(imageName.LastIndexOf("/") + 1) + ".png";
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        WriteLog("Error on get image name : " + ex.Message);
                                    }
                                    #endregion

                                    #region image not exist then download it
                                    if (!File.Exists(locationPath + imageName))
                                    {
                                        try
                                        {
                                            using (var webClient = new WebClient())
                                            {
                                                //webClient.Credentials = new NetworkCredential(userName, password);
                                                webClient.Credentials = new NetworkCredential("customerservice@teamconnection.com", "#Volleyba11");
                                                webClient.DownloadFile(imageUrl, locationPath + imageName);
                                                webClient.Dispose();
                                            }
                                            intCount = (intCount + 1);
                                            txtTotalImagesDownloaded.Text = intCount.ToString();
                                            WriteLog(intCount.ToString() + " : images downloaded successfully..", true);
                                            write_to_csv(imageUrl, "~\\" + imageFolderName + " Images\\" + imageName + "");
                                        }
                                        catch (Exception ex)
                                        {
                                            WriteLog("Error on download image : " + ex.Message);
                                            WriteLog("Image Url : " + imageUrl + " : " + ex.Message);
                                            write_to_csv("", "");
                                        }
                                    }
                                    else
                                    {
                                        if (imageName == "")
                                            write_to_csv(imageUrl, "");
                                        else
                                            write_to_csv(imageUrl, "~\\" + imageFolderName + "Images\\" + imageName + "");
                                    }

                                    lastImageName = imageName;
                                    Application.DoEvents();

                                    #endregion
                                }
                                else
                                {
                                    write_to_csv(imageUrl, "~\\" + imageFolderName + " Images\\" + lastImageName + "");
                                }
                            }
                            else
                            {
                                write_to_csv("", "");
                                WriteLog(" No Image url available..");
                            }
                            Application.DoEvents();

                        }
                        if (txtTotalImagesDownloaded.Text != "0")
                            WriteLog(("\r\n\r\n") + ("\t\t" + "Total " + txtTotalImagesDownloaded.Text.ToString() + " images are downloaded..") + ("\r\n\r\n") + ("\t\t" + "All records are readed successfuly...") + ("\r\n\r\n"));
                        else
                            WriteLog(("\r\n\r\n") + ("\t\t" + "No images are downloaded") + ("\r\n\r\n") + ("\t\t" + "All records are readed successfuly...") + ("\r\n\r\n"));
                    }
                    catch (Exception ex)
                    {
                        WriteLog("Error on get image url or image name : " + ex.Message, true);
                    }
                }
                #endregion
            }
        }

        private string RemoveIlligleChar(string imageUrl)
        {
            return imageUrl.Replace("&amp", "").Replace(";", "&").Replace(",", "%").Replace("$", "");
        }
        #endregion

        #region RemoveI llegal Char From Link
        public string RemoveIllegalCharFromLink(string url)
        {
            url = Regex.Replace(url, "\"", "");
            url = Regex.Replace(url, "\\/", "/");
            url = Regex.Replace(url, "\\&quot;", "");
            url = Regex.Replace(url, "\r\n", "");
            url = Regex.Replace(url, "\t", "");
            url = url.Replace(";", "&");
            //url = url.Replace(",", "%");
            //url = url.Replace("$", "%");
            return url;
        }
        #endregion

        #region Write data on .csv file
        private void write_to_csv(string imageUrl, string imagePathOnCsvFile)
        {
            try
            {
                System.IO.StreamWriter sw;
                if (!File.Exists(OutputFilePath))
                {
                    sw = new System.IO.StreamWriter(OutputFilePath, true);
                    sw.WriteLine(("Image Url" + ("," + ("Image path on .csv file"))));
                    sw.Close();
                }

                sw = new System.IO.StreamWriter(OutputFilePath, true);
                sw.WriteLine(("\""
                                + (imageUrl + ("\"" + ("," + ("\""
                                + (imagePathOnCsvFile + "\"")))))));

                sw.Close();
                txtTotalImagesDownloaded.Text = intCount.ToString();
            }
            catch (Exception ex)
            {
                WriteLog(("error on Write_to_csv" + (ex.Message + (" " + ex.StackTrace))), false);
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
                txtLog.Text = (System.DateTime.Now.ToString() + (" :: " + (msg + ("\r\n" + txtLog.Text))));
            }

            StreamWriter sw;
            try
            {
                sw = new StreamWriter(LogFilePath, true);
                sw.WriteLine((System.DateTime.Now.ToString() + (" : " + msg)));
                sw.Close();
            }
            catch (Exception ex)
            {
                WriteLog(("Error while writing in output file : " + (ex.Message + (" " + ex.StackTrace))), false);
                txtLog.Text = ("Error while writing in output file : " + LogFilePath);
            }

        }
        #endregion
    }
}


#region Other commented codes

#region attach http/htpps
//if (!imageUrl.Contains("http") && !imageUrl.Contains("https"))
//    imageUrl = "https:" + imageUrl;
#endregion

#region for all website
//if (imageUrl.Contains('?'))
//{
//    int startIndex = imageUrl.LastIndexOf("/") + 1;
//    int endIndex = imageUrl.IndexOf("?");
//    imageName = imageUrl.Substring(startIndex, endIndex - startIndex);
//}
//else
//{
//    imageName = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1).ToUpper();
//}
#endregion

#region attach extensions
//if (!imageName.Contains(".png") && !imageName.Contains(".jpeg") && !imageName.Contains(".jpg"))
//{
//    imageName = imageName + ".png";
//}
#endregion

#region Download Images
//public void DownloadImage(string imageUrl, string imageName)
//{
//    #region local variable declaration for image

//    string imagePath = "";
//    string imagePathOnCsvFile = "";
//    #endregion local variable declaration for image

//    #region ImagePath on .csv file

//    if (imageName != "")
//        imagePathOnCsvFile = "~\\" + imageFolderName + "Images\\" + imageName;

//    #endregion

//    ImageDownloadedLocation = locationPath;
//    Application.DoEvents();

//    WebClient webClient = new WebClient();

//    #region Credentials
//    if (userName != null && password != null)
//    {
//        webClient.Credentials = new NetworkCredential(userName, password);
//    }
//    #endregion

//    #region Download image
//    try
//    {
//        if (imageUrl != "N/A")
//        {

//            webClient.DownloadFile(imageUrl, imageFullPath);
//            intCount = (intCount + 1);
//            txtTotalImagesDownloaded.Text = intCount.ToString();
//            WriteLog(intCount.ToString() + " : images downloaded successfully..", true);
//            Application.DoEvents();

//        }
//        else
//        {
//            WriteLog("Image url not available");
//            Application.DoEvents();
//            imageUrl = "N/A";
//            imagePath = imageName = "N/A";
//            imagePathOnCsvFile = "N/A";
//        }
//        write_to_csv(imageUrl, imagePathOnCsvFile);
//    }
//    catch (Exception ex)
//    {
//        WriteLog("Error on download image of Url : \"" + imageUrl + "\" : " + ex.Message, true);
//        write_to_csv("N/A", "N/A");
//    }
//    #endregion Download 1st image

//    webClient.Dispose();
//    txtTotalImagesDownloaded.Text = intCount.ToString();
//}
#endregion

#endregion