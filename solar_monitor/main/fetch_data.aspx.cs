using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using solar_monitor.Models;
using System.IO;
using AspDotNet.FTPHelper;
using System.Data.SqlClient;
using System.Diagnostics;

namespace solar_monitor.main
{
    public partial class fetch_data : System.Web.UI.Page
    {
       public enum settingtype
        {
            cslogger, ivcurve
        }
        public class uploadparams
        {
            public TimeSpan time { get; set; }
            public string date { get; set; }
            public double voltage { get; set; }
            public double current { get; set; }          
        }

        private class ftpdetails
        {
            public string filename { get; set; }   
            public int port { get; set; }   
            public string domain { get; set; }
            public string password { get; set; }
            public string username { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string pathf = getfilepath();
                datfilelocationtxt.Value = pathf;
                List<ftpdetails> ftpdet = getftp();
                usernametxt.Value = ftpdet[0].username.ToString();
                hostnametxt.Value = ftpdet[0].domain.ToString();
                passwordtxt.Value = ftpdet[0].password.ToString();
                fileurltxt.Value = ftpdet[0].filename.ToString();
            }
        }

        protected void fetch_cslogger(object sender, EventArgs e)
        {
            try
            {
                string filename = "SolarHouse_Average.dat";
                string filepath = getfilepath();
                int countsucc = 0;
                int counfail = 0;
                if (File.Exists(filepath+filename))
                {
                    string deletedb = "delete from DL_Avg";
                    Utils.NonQeryRequest(deletedb);
                    string[] lines = File.ReadAllLines(filepath + filename);
                    
                    for (int i = 4; i < lines.Length; i++)
                    {

                        //string test = lines[i].Split(',')[0].ToString();
                        //datfilelocationtxt.Value = test;
                        DateTime dtime = Convert.ToDateTime(lines[i].Split(',')[0].ToString().Replace(@"""", ""));
                        int record = Convert.ToInt32(lines[i].Split(',')[1]);
                        double BattV_Min = Convert.ToDouble(lines[i].Split(',')[2]);
                        double Rt_CNRM_Avg = Convert.ToDouble(lines[i].Split(',')[3]);
                        double Rt_WKSH_Avg = Convert.ToDouble(lines[i].Split(',')[4]);
                        double Rt_DkRM_Avg = Convert.ToDouble(lines[i].Split(',')[5]);
                        double Rt_OUDR_Avg = Convert.ToDouble(lines[i].Split(',')[6]);
                        double WDir_Std = Convert.ToDouble(lines[i].Split(',')[7]);
                        double WSpd_Avg = Convert.ToDouble(lines[i].Split(',')[8]);
                        double Sol_Glo_Avg = Convert.ToDouble(lines[i].Split(',')[9]);
                        double Sol_tilt_Avg = Convert.ToDouble(lines[i].Split(',')[10]);
                        double CHP1_Avg = Convert.ToDouble(lines[i].Split(',')[11]);
                        double CMP10_Avg = Convert.ToDouble(lines[i].Split(',')[12]);
                        double CMP10_Shaded_Avg = Convert.ToDouble(lines[i].Split(',')[13]);
                        double SGR4_Avg = Convert.ToDouble(lines[i].Split(',')[14]);
                        double Ambt_lux_Avg = Convert.ToDouble(lines[i].Split(',')[15]);
                        double Temp_C_Avg_1 = Convert.ToDouble(lines[i].Split(',')[16]);
                        double Temp_C_Avg_2 = Convert.ToDouble(lines[i].Split(',')[17]);
                        double Temp_C_Avg_3 = Convert.ToDouble(lines[i].Split(',')[18]);
                        double Temp_C_Avg_4 = Convert.ToDouble(lines[i].Split(',')[19]);
                        double Temp_C_Avg_5 = Convert.ToDouble(lines[i].Split(',')[20]);
                        double Temp_C_Avg_6 = Convert.ToDouble(lines[i].Split(',')[21]);
                        double Temp_C_Avg_7 = Convert.ToDouble(lines[i].Split(',')[22]);
                        double Temp_C_Avg_8 = Convert.ToDouble(lines[i].Split(',')[23]);
                        double Temp_C_Avg_9 = Convert.ToDouble(lines[i].Split(',')[24]);
                        double Temp_C_Avg_10 = Convert.ToDouble(lines[i].Split(',')[25]);
                        double Temp_C_Avg_11 = Convert.ToDouble(lines[i].Split(',')[26]);
                        double Temp_C_Avg_12 = Convert.ToDouble(lines[i].Split(',')[27]);
                        double Temp_C_Avg_13 = Convert.ToDouble(lines[i].Split(',')[28]);
                        double Temp_C_Avg_14 = Convert.ToDouble(lines[i].Split(',')[29]);
                        double Temp_C_Avg_15 = Convert.ToDouble(lines[i].Split(',')[30]);
                        double Temp_C_Avg_16 = Convert.ToDouble(lines[i].Split(',')[31]);
                        double Temp_C_Avg_17 = Convert.ToDouble(lines[i].Split(',')[32]);
                        double Temp_C_Avg_18 = Convert.ToDouble(lines[i].Split(',')[33]);
                        double Temp_C_Avg_19 = Convert.ToDouble(lines[i].Split(',')[34]);
                        double Temp_C_Avg_20 = Convert.ToDouble(lines[i].Split(',')[35]);
                        double Tmp_Wbt_Avg = 0; //Convert.ToDouble(lines[i].Split(',')[36]);
                        double Tmp_Wmd_Avg = 0; //Convert.ToDouble(lines[i].Split(',')[37]);
                        double Tmp_Wtp_Avg = 0; //Convert.ToDouble(lines[i].Split(',')[38]);
                        double Tmp_Ebt_Avg = 0; //Convert.ToDouble(lines[i].Split(',')[39]);
                        double Tmp_Emd_Avg = 0; //\ Convert.ToDouble(lines[i].Split(',')[40]);
                        double Tmp_Etp_Avg = 0;// Convert.ToDouble(lines[i].Split(',')[41]);

                        string insertin = "insert into DL_Avg values('" + dtime + "'," + record + "," + BattV_Min + "," + Rt_CNRM_Avg + "," + Rt_WKSH_Avg + "," + Rt_DkRM_Avg + "," + Rt_OUDR_Avg + "," + WDir_Std + "," + WSpd_Avg + "," + Sol_Glo_Avg + "," + Sol_tilt_Avg + "," + CHP1_Avg + "," + CMP10_Avg + "," + CMP10_Shaded_Avg + "," + SGR4_Avg + "," + Ambt_lux_Avg + "," + Temp_C_Avg_1 + "," + Temp_C_Avg_2 + "," + Temp_C_Avg_3 + "," + Temp_C_Avg_4 + "," + Temp_C_Avg_5 + "," + Temp_C_Avg_6 + "," + Temp_C_Avg_7 + "," + Temp_C_Avg_8 + "," + Temp_C_Avg_9 + "," + Temp_C_Avg_10 + "," + Temp_C_Avg_11 + "," + Temp_C_Avg_12 + "," + Temp_C_Avg_13 + "," + Temp_C_Avg_14 + "," + Temp_C_Avg_15 + "," + Temp_C_Avg_16 + "," + Temp_C_Avg_17 + "," + Temp_C_Avg_18 + "," + Temp_C_Avg_19 + "," + Temp_C_Avg_20 + "," + Tmp_Wbt_Avg + "," + Tmp_Wmd_Avg + "," + Tmp_Wtp_Avg + "," + Tmp_Ebt_Avg + "," + Tmp_Emd_Avg + "," + Tmp_Etp_Avg + ")";
                        string rowss = Utils.NonQeryRequest(insertin);
                        switch (rowss)
                        {
                            case "200":
                                countsucc++;

                                break;
                            case "No changes were made":
                                counfail++;
                                //  alert.Visible = true;
                                //alert.Attributes.Add("class", "alert alert-danger col-xl-6 offset-md-3");
                                //  innertext.InnerHtml = "CS Logger Data fetching failed: please check logs";
                                break;
                            default:
                                break;
                        }
                    }
                }
               
                alert.Visible = true;
                alert.Attributes.Add("class", "alert alert-danger col-xl-6 offset-md-3");
                innertext.InnerHtml =countsucc+ " CS Logger Data successfully fetched and loaded to DB /n ";
                // string name = settingtype.cslogger.ToString();
            }
            catch(Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
        }

        public string getfilepath()
        {
            string urlpath = string.Empty;
            try
            {               
               string getpath = "select top 1 * from Settings where SettingId=2";
                DataTable dt = Utils.GetRequest(getpath);
                urlpath = dt.Rows[0]["FileUrl"].ToString();
            }  
           catch(Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
            return urlpath;
        }
        private List<ftpdetails> getftp()
        {
            var ftp = new List<ftpdetails>();
            string get = "select top 1 * from Settings where SettingId=1";
             DataTable dt = Utils.GetRequest(get);
            ftp = (from DataRow dr in dt.Rows select new ftpdetails()
            {
                username = dr["Username"].ToString(),
                port = 21,
                password = dr["Password"].ToString(),
                domain = dr["FTP_Domain"].ToString(),
                filename = dr["FileUrl"].ToString()
            }).ToList();

            return ftp;
        }
        protected void fetchivcurvetracer(object sender, EventArgs e)
        {
            try
            {
                    string getcred = "select * from Settings where SettingId=1";
                DataTable dt = Utils.GetRequest(getcred);
                string domain = dt.Rows[0]["FTP_Domain"].ToString();
                string username = dt.Rows[0]["Username"].ToString();
                string password = dt.Rows[0]["Password"].ToString();
                string fileurl = dt.Rows[0]["FileUrl"].ToString();
                string del = "delete from Voic_Ic_Rad";
                Utils.NonQeryRequest(del);
                for (int i = 1; i < 7; i++)
                {
                    // File.Delete(@"C:\Files\H000" + i + ".csv");// ENSURE TO ENABLE THIS BIT

                    //DOWNLOAD FILE 
                    //string inputfilepath = @"C:\Temp\FileName.exe";
                    //string ftphost = "xxx.xx.x.xxx";
                    //string ftpfilepath = "/Updater/Dir1/FileName.exe";
                    // string excelPath = @"C:\Files\H000" + i + ".csv";
                   // string excelPath = "C:\\Users\\User\\Desktop\\database for iV Curve tracer\\H000" + i + ".csv";
                    string excelPath = System.Configuration.ConfigurationManager.AppSettings["csvpath"];

                    string ftpfullpath = $"ftp://{domain}{fileurl}H000{i}.csv"; // "ftp://" + ftphost + ftpfilepath;

                    //                using (WebClient request = new WebClient())
                    //                {
                    //                    request.Credentials = new NetworkCredential(username, password);
                    //                    byte[] fileData = request.DownloadData(ftpfullpath);

                    //                    using (FileStream file = File.Create(excelPath))
                    //                    {
                    //                        file.Write(fileData, 0, fileData.Length);
                    //                        file.Close();
                    //                    }
                    //                   // MessageBox.Show("Download Complete");
                    //                }


                    //                FtpWebRequest request =
                    //(FtpWebRequest)WebRequest.Create(ftpfullpath);
                    //                request.Credentials = new NetworkCredential(username, password);
                    //                request.Method = WebRequestMethods.Ftp.DownloadFile;

                    //                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                    //                using (Stream fileStream = File.Create(excelPath))
                    //                {
                    //                    byte[] buffer = new byte[10240];
                    //                    int read;
                    //                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    //                    {
                    //                        fileStream.Write(buffer, 0, read);
                    //                        //Console.WriteLine("Downloaded {0} bytes", fileStream.Position);
                    //                    }
                    //                }

                    //WebClient client = new WebClient();
                    //client.Credentials = new NetworkCredential(username, password);

                    //client.DownloadFile(
                    //  $"ftp://{domain}{fileurl}H000+{i}.csv", $"C:\\Files\\H000{i}.csv");
                    // string excelPath = @"C:\Files\H000" + i + ".csv";
                    int count = 0;
                    if (File.Exists(excelPath))
                    {
                        string deletedb = "delete from Temp_Voltage_1 where stringId="+i+"";
                        Utils.NonQeryRequest(deletedb);
                        var csvTable = new DataTable();
                        using (var csvReader = new CsvReader(new StreamReader(File.OpenRead(excelPath)), true))
                        {
                            csvTable.Load(csvReader);
                            List<uploadparams> searchParameters = new List<uploadparams>();
                            for (int j = 2; j < csvTable.Rows.Count; j++)
                            {
                                if (i == 6)
                                {
                                   //                    j = j - 1;
                                    string time = csvTable.Rows[j][0].ToString().Split('\t')[0];
                                    string date = csvTable.Rows[j][0].ToString().Split('\t')[1];// Convert.ToDateTime(csvTable.Rows[j][0]).ToString("yyyy-MM-dd").Split('\t')[1];
                                    double stringno = Convert.ToInt32(csvTable.Rows[j][0].ToString().Split('\t')[2]);
                                    double voc = Convert.ToDouble(csvTable.Rows[j][0].ToString().Split('\t')[3]);
                                    double isc = Convert.ToDouble(csvTable.Rows[j][0].ToString().Split('\t')[4]);
                                    double rad = Convert.ToDouble(csvTable.Rows[j][0].ToString().Split('\t')[5]);
                                    string yy = date.Split('/')[2];
                                    string mm = date.Split('/')[1];
                                    string dd = date.Split('/')[0].Length == 1 ? 0.ToString() + date.Split('/')[0] : date.Split('/')[0];
                                    string dtime = yy + "-" + mm + "-" + dd;
                                    dtime = dtime + " " + time;
                                    //DateTime dtime2 = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                    //DateTime condate = Convert.ToDateTime(dtime);
                                    string inserth = $"insert into Voic_Ic_Rad values('{time}','{yy + "-" + mm + "-" + dd}','{yy + "-" + mm + "-" + dd + " " + time}',{stringno},{voc},{isc},{rad})";
                                    string feedback = Utils.NonQeryRequest(inserth);
                                    switch (feedback)
                                    {
                                        case "200":
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {

                                    string time = csvTable.Rows[j][0].ToString().Split('\t')[0];
                                    string date = csvTable.Rows[j][0].ToString().Split('\t')[1];// Convert.ToDateTime(csvTable.Rows[j][0]).ToString("yyyy-MM-dd").Split('\t')[1];
                                    double voltage = Convert.ToDouble(csvTable.Rows[j][0].ToString().Split('\t')[2]);
                                    double current = Convert.ToDouble(csvTable.Rows[j][0].ToString().Split('\t')[3]);
                                    string yy = date.Split('/')[2];
                                    string mm = date.Split('/')[1];
                                    string dd = date.Split('/')[0].Length == 1 ? 0.ToString() + date.Split('/')[0] : date.Split('/')[0];
                                    string dtime = yy + "-" + mm + "-" + dd;
                                    dtime = dtime + " " + time;
                                    //DateTime dtime2 = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                                    //DateTime condate = Convert.ToDateTime(dtime);
                                    string inserth = $"insert into Temp_Voltage_1 values({i},'{yy + "-" + mm + "-" + dd}','{time}','{yy + "-" + mm + "-" + dd + " " + time}',{voltage},{current})";
                                    string feedback = Utils.NonQeryRequest(inserth);
                                    switch (feedback)
                                    {
                                        case "200":
                                            count += count;
                                            // System.GC.Collect();
                                            //System.GC.WaitForPendingFinalizers();
                                            //File.Delete(picturePath);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    { }                                           
                           
                }
                alert.Visible = true;
                alert.Attributes.Add("class", "alert alert-success col-xl-6 offset-md-3");
                innertext.InnerHtml = "Complete! (See logs for Details)";
            }
            catch(Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }

        }

        protected void updateftp(object sender, EventArgs e)
        {
            try
            {
                string domain = hostnametxt.Value.ToString();
                string username = usernametxt.Value.ToString();
                string password = passwordtxt.Value.ToString();
                //int port = 21;
                string filepath = fileurltxt.Value.ToString();
                string update = $"update Settings set FileUrl='{filepath}',FTP_Domain='{domain}',Username='{username}', Password='{password}', DateModified='{DateTime.Now}' where SettingId=1";
                string resp = Utils.NonQeryRequest(update);
                switch(resp)
                {
                    case "200":                           
                        alert.Visible = true;
                        alert.Attributes.Add("class", "alert alert-success col-xl-6 offset-md-3");
                        innertext.InnerHtml = "Record updated successfully";
                        break;
                    case "No changes were made":
                        alert.Visible = true;
                        innertext.InnerHtml = "No change was made";
                        break;
                    default:
                        alert.Visible = true;
                        innertext.InnerHtml ="Some error occured";
                        break;
                }

            }
            catch(Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
        }

        protected void updatedatfilelocation(object sender, EventArgs e)
        {
            try
            {
                
                string fileurl = datfilelocationtxt.Value.ToString();
                string update = $"update Settings set FileUrl='{fileurl}',DateModified='{DateTime.Now}' where SettingId=2";
                string resp = Utils.NonQeryRequest(update);
                switch (resp)
                {
                    case "200":
                        alert.Visible = true;
                        alert.Attributes.Add("class", "alert alert-success col-xl-6 offset-md-3");
                        innertext.InnerHtml = "Record updated successfully";
                        break;
                    case "No changes were made":
                        alert.Visible = true;
                        innertext.InnerHtml = "No change was made";
                        break;
                    default:
                        alert.Visible = true;
                        innertext.InnerHtml = "Some error occured";
                        break;
                }
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
        }
        public void testlinq()
        {
            int[] numbers = { 1, 2, 3 };
            var test = from number in numbers where number>2 select numbers[0];
            string.Join(",", test);
        }

        

        public class FtpUtility
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Path { get; set; }
            string domain = "52.229.31.163";
            public List<string> ListFiles()
            {
                var request = (FtpWebRequest)WebRequest.Create(Path);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(UserName, Password, domain);
                List<string> files = new List<string>();
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(responseStream);
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(line) == false)
                            {
                                var fileName = line.Split(new[] { ' ', '\t' }).Last();
                                if (!fileName.StartsWith("."))
                                    files.Add(fileName);
                            }
                        }
                        return files;
                    }
                }
            }
        }

        //public class uploadparams
        //{
        //    public string time { get; set; }
        //    public string date { get; set; }
        //    public string voltage { get; set; }
        //    public double current { get; set; }
          
        //}

        //public void valdateandupload(string filename)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.AddRange(new DataColumn[7] { new DataColumn("date", typeof(string)),
        //                new DataColumn("Farm_name", typeof(string)),
        //                new DataColumn("coordinate", typeof(string)),
        //                new DataColumn("location", typeof(string)),
        //                new DataColumn("maplocation", typeof(string)),
        //                new DataColumn("type", typeof(string)),
        //                new DataColumn("validity", typeof(string)),

        //        });
        //    try
        //    {
               
        //            string excelPath = Server.MapPath("~/main/uploads/") + filename;
        //            FileUpload2.SaveAs(excelPath);

        //            string conString = string.Empty;
        //            string extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
        //            if (extension != ".csv")
        //            {
        //                Response.Write("<script>alert('Only .csv files are allowed ');</script>");
        //            }
        //            else
        //            {
        //                var csvTable = new DataTable();
        //                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(excelPath)), true))
        //                {
        //                    csvTable.Load(csvReader);
        //                    List<uploadparams> searchParameters = new List<uploadparams>();
        //                    for (int i = 0; i < csvTable.Rows.Count; i++)
        //                    {

        //                        searchParameters.Add(new uploadparams { sn = csvTable.Rows[i][0].ToString(), farm_name = csvTable.Rows[i][1].ToString(), crop = csvTable.Rows[i][2].ToString(), size = Convert.ToDouble(csvTable.Rows[i][3]), anchor = csvTable.Rows[i][4].ToString(), mapper = csvTable.Rows[i][5].ToString(), local_govt = csvTable.Rows[i][6].ToString(), coordinates = csvTable.Rows[i][7].ToString(), state = csvTable.Rows[i][8].ToString() });
        //                    }
        //                    // Repeater1.DataSource = csvTable;
        //                    // Repeater1.DataBind();

        //                    foreach (DataRow row in csvTable.Rows) // FOR EACH ROW IN CSV
        //                    {

        //                        string serialnumber = row["S/N"].ToString(); //FOR EACH COORDINATE
        //                        string coordinate = row["coordinates"].ToString(); //FOR EACH COORDINATE
        //                        string farmname = row["farm_name"].ToString();
        //                        string state = row["state"].ToString();
        //                        string crop = row["crop"].ToString();
        //                        double size = Convert.ToDouble(row["size"]);
        //                        string anchor = row["anchor"].ToString();
        //                        string mapper = row["mapper"].ToString();
        //                        string local_govt = row["local_govt"].ToString();
        //                        //  string project = row["project"].ToString();


        //                        string temp = "[" + coordinate + "]";
        //                        double[][] cooc = Newtonsoft.Json.JsonConvert.DeserializeObject<double[][]>(temp);
        //                        //double[][] cooc = System.Text.Json.JsonSerializer.Deserialize<double[][]>(temp);
        //                        double temp1 = cooc[0][0];
        //                        double longtemp = cooc[0][1];
        //                        double name2 = Convert.ToDouble(longtemp);
        //                        double Name = temp1;
        //                        string latitudestr = Name + "," + name2;



        //                        var client = new RestSharp.RestClient("http://api.positionstack.com/v1/");
        //                        var request = new RestSharp.RestRequest("reverse?access_key=33471b138af197c343f5f5713331e72c&query=" + latitudestr + "", RestSharp.Method.GET);
        //                        request.RequestFormat = RestSharp.DataFormat.Json;

        //                        var response = client.Execute(request);
        //                        int statcode = Convert.ToInt32(response.StatusCode);
        //                        if (statcode == 200)
        //                        {
        //                            // Parse the response body.
        //                            //var deserializer = new RestSharp.Serialization.Json.JsonDeserializer();
        //                            var deserializer = new RestSharp.Deserializers.JsonDeserializer();

        //                            var dataObjects = deserializer.Deserialize<root>(response);
        //                            DateTime now = DateTime.Now;
        //                            string timeofvalidation = now.ToString("dd/MM/yyyy hh:mm tt");
        //                            // string status = dataObjects.status;
        //                            if (dataObjects.data[0].region != null)
        //                            {

        //                                string templocation = dataObjects.data[0].region.ToString();
        //                                if (templocation.ToLower().Contains(state.ToLower()) == true)
        //                                {
        //                                    dt.Rows.Add(timeofvalidation, farmname, coordinate, state, templocation, dataObjects.data[0].type, "YES");
        //                                    if (CheckBox1.Checked == true)
        //                                    {
        //                                        Guid mapguid = Guid.NewGuid();
        //                                        string coordinatestatus = "Valid";
        //                                        DateTime created = DateTime.Now;
        //                                        int activated = 0;
        //                                        int deleted = 0;
        //                                        float tempsize = (float)size;
        //                                        SqlCommand createschedule = new SqlCommand("insert into all_farms (farm_guid,crop,size,anchor,mapper,local_govt,farm_name,location,map_location,coordinate1,status,activated,created_at,deleted,is_valid,type) values(@mapguid,@crop,@size,@anchor,@mapper,@local_govt,@farmname,@location,@map_location,@co1,@status,@activated,@createdat,@deleted,@isvalid,@type)", sc);
        //                                        createschedule.Parameters.AddWithValue("@mapguid", mapguid);
        //                                        createschedule.Parameters.AddWithValue("@crop", crop);
        //                                        createschedule.Parameters.AddWithValue("@size", size);
        //                                        createschedule.Parameters.AddWithValue("@anchor", anchor);
        //                                        createschedule.Parameters.AddWithValue("@mapper", mapper);
        //                                        createschedule.Parameters.AddWithValue("@local_govt", local_govt);
        //                                        createschedule.Parameters.AddWithValue("@farmname", farmname);
        //                                        createschedule.Parameters.AddWithValue("@location", state);
        //                                        createschedule.Parameters.AddWithValue("@map_location", templocation);
        //                                        createschedule.Parameters.AddWithValue("@co1", coordinate);
        //                                        createschedule.Parameters.AddWithValue("@status", coordinatestatus);
        //                                        createschedule.Parameters.AddWithValue("@activated", activated);
        //                                        createschedule.Parameters.AddWithValue("@createdat", created);
        //                                        createschedule.Parameters.AddWithValue("@deleted", deleted);
        //                                        createschedule.Parameters.AddWithValue("@isvalid", 1);
        //                                        createschedule.Parameters.AddWithValue("@type", dataObjects.data[0].type);
        //                                        createschedule.ExecuteNonQuery();
        //                                    }
        //                                    else
        //                                    {

        //                                    }


        //                                }
        //                                else
        //                                {
        //                                    dt.Rows.Add(timeofvalidation, farmname, coordinate, state, templocation, dataObjects.data[0].type, "NO");
        //                                    if (CheckBox1.Checked == true)
        //                                    {
        //                                        Guid mapguid = Guid.NewGuid();
        //                                        string coordinatestatus = "Invalid";
        //                                        string reason = "Map location does not match Location provided";
        //                                        DateTime created = DateTime.Now;
        //                                        int activated = 0;
        //                                        int deleted = 0;
        //                                        SqlCommand createschedule = new SqlCommand("insert into all_farms (farm_guid,crop,size,anchor,mapper,local_govt,farm_name,location,map_location,coordinate1,status,activated,created_at,deleted,is_valid,type) values(@mapguid,@crop,@size,@anchor,@mapper,@local_govt,@farmname,@location,@map_location,@co1,@status,@activated,@createdat,@deleted,@isvalid,@type)", sc);
        //                                        createschedule.Parameters.AddWithValue("@mapguid", mapguid);
        //                                        createschedule.Parameters.AddWithValue("@crop", crop);
        //                                        createschedule.Parameters.AddWithValue("@size", size);
        //                                        createschedule.Parameters.AddWithValue("@anchor", anchor);
        //                                        createschedule.Parameters.AddWithValue("@mapper", mapper);
        //                                        createschedule.Parameters.AddWithValue("@local_govt", local_govt);
        //                                        createschedule.Parameters.AddWithValue("@farmname", farmname);
        //                                        createschedule.Parameters.AddWithValue("@location", state);
        //                                        createschedule.Parameters.AddWithValue("@map_location", templocation);
        //                                        createschedule.Parameters.AddWithValue("@co1", coordinate);
        //                                        createschedule.Parameters.AddWithValue("@status", coordinatestatus);
        //                                        createschedule.Parameters.AddWithValue("@reason", reason);
        //                                        createschedule.Parameters.AddWithValue("@activated", activated);
        //                                        createschedule.Parameters.AddWithValue("@createdat", created);
        //                                        createschedule.Parameters.AddWithValue("@deleted", deleted);
        //                                        createschedule.Parameters.AddWithValue("@isvalid", 0);
        //                                        createschedule.Parameters.AddWithValue("@type", dataObjects.data[0].type);
        //                                        createschedule.ExecuteNonQuery();
        //                                    }
        //                                    else
        //                                    {

        //                                    }

        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (dataObjects.data[0].name.ToString() != null && dataObjects.data[0].type.ToString() != null)
        //                                {

        //                                    string templocation = dataObjects.data[0].name.ToString();
        //                                    dt.Rows.Add(timeofvalidation, farmname, coordinate, state, templocation, dataObjects.data[0].type, "NO");
        //                                    if (CheckBox1.Checked == true)
        //                                    {
        //                                        Guid mapguid = Guid.NewGuid();
        //                                        string coordinatestatus = "Invalid";
        //                                        string reason = "Map location does not match Location provided";
        //                                        DateTime created = DateTime.Now;
        //                                        int activated = 0;
        //                                        int deleted = 0;
        //                                        SqlCommand createschedule = new SqlCommand("insert into all_farms (farm_guid,crop,size,anchor,mapper,local_govt,farm_name,location,map_location,coordinate1,status,activated,created_at,deleted,is_valid,type) values(@mapguid,@crop,@size,@anchor,@mapper,@local_govt,@farmname,@location,@map_location,@co1,@status,@activated,@createdat,@deleted,@isvalid,@type)", sc);
        //                                        createschedule.Parameters.AddWithValue("@mapguid", mapguid);
        //                                        createschedule.Parameters.AddWithValue("@farmname", farmname);
        //                                        createschedule.Parameters.AddWithValue("@crop", crop);
        //                                        createschedule.Parameters.AddWithValue("@size", size);
        //                                        createschedule.Parameters.AddWithValue("@anchor", anchor);
        //                                        createschedule.Parameters.AddWithValue("@mapper", mapper);
        //                                        createschedule.Parameters.AddWithValue("@local_govt", local_govt);
        //                                        createschedule.Parameters.AddWithValue("@location", state);
        //                                        createschedule.Parameters.AddWithValue("@map_location", templocation);
        //                                        createschedule.Parameters.AddWithValue("@co1", coordinate);
        //                                        createschedule.Parameters.AddWithValue("@status", coordinatestatus);
        //                                        createschedule.Parameters.AddWithValue("@reason", reason);
        //                                        createschedule.Parameters.AddWithValue("@activated", activated);
        //                                        createschedule.Parameters.AddWithValue("@createdat", created);
        //                                        createschedule.Parameters.AddWithValue("@deleted", deleted);
        //                                        createschedule.Parameters.AddWithValue("@isvalid", 0);
        //                                        createschedule.Parameters.AddWithValue("@type", dataObjects.data[0].type);
        //                                        createschedule.ExecuteNonQuery();
        //                                    }
        //                                    else
        //                                    {

        //                                    }
        //                                }
        //                                else
        //                                {

        //                                    string templocation = "No Map Location Found";
        //                                    if (dataObjects.data[0].type != null)
        //                                    {
        //                                        string type = dataObjects.data[0].type;
        //                                        dt.Rows.Add(timeofvalidation, farmname, coordinate, state, templocation, type, "NO");
        //                                        if (CheckBox1.Checked == true)
        //                                        {
        //                                            Guid mapguid = Guid.NewGuid();
        //                                            string coordinatestatus = "Invalid";
        //                                            string reason = "No Location found for the Coordinates on the Map";
        //                                            DateTime created = DateTime.Now;
        //                                            int activated = 0;
        //                                            int deleted = 0;
        //                                            SqlCommand createschedule = new SqlCommand("insert into all_farms (farm_guid,crop,size,anchor,mapper,local_govt,farm_name,location,map_location,coordinate1,status,activated,created_at,deleted,is_valid,type) values(@mapguid,@crop,@size,@anchor,@mapper,@local_govt,@farmname,@location,@map_location,@co1,@status,@activated,@createdat,@deleted,@isvalid,@type)", sc);
        //                                            createschedule.Parameters.AddWithValue("@mapguid", mapguid);
        //                                            createschedule.Parameters.AddWithValue("@crop", crop);
        //                                            createschedule.Parameters.AddWithValue("@size", size);
        //                                            createschedule.Parameters.AddWithValue("@anchor", anchor);
        //                                            createschedule.Parameters.AddWithValue("@mapper", mapper);
        //                                            createschedule.Parameters.AddWithValue("@local_govt", local_govt);
        //                                            createschedule.Parameters.AddWithValue("@farmname", farmname);
        //                                            createschedule.Parameters.AddWithValue("@location", state);
        //                                            createschedule.Parameters.AddWithValue("@map_location", templocation);
        //                                            createschedule.Parameters.AddWithValue("@co1", coordinate);
        //                                            createschedule.Parameters.AddWithValue("@status", coordinatestatus);
        //                                            createschedule.Parameters.AddWithValue("@reason", reason);
        //                                            createschedule.Parameters.AddWithValue("@activated", activated);
        //                                            createschedule.Parameters.AddWithValue("@createdat", created);
        //                                            createschedule.Parameters.AddWithValue("@deleted", deleted);
        //                                            createschedule.Parameters.AddWithValue("@isvalid", 0);
        //                                            createschedule.Parameters.AddWithValue("@type", type);
        //                                            createschedule.ExecuteNonQuery();
        //                                        }
        //                                        else
        //                                        {

        //                                        }
        //                                    }
        //                                    else
        //                                    {

        //                                        string type = "No Type found";
        //                                        dt.Rows.Add(timeofvalidation, farmname, coordinate, state, templocation, type, "NO");
        //                                        if (CheckBox1.Checked == true)
        //                                        {
        //                                            Guid mapguid = Guid.NewGuid();
        //                                            string coordinatestatus = "Invalid";
        //                                            string reason = "No Location found for the Coordinates on the Map";
        //                                            DateTime created = DateTime.Now;
        //                                            int activated = 0;
        //                                            int deleted = 0;
        //                                            SqlCommand createschedule = new SqlCommand("insert into all_farms (farm_guid,crop,size,anchor,mapper,local_govt,farm_name,location,map_location,coordinate1,status,activated,created_at,deleted,is_valid,type) values(@mapguid,@crop,@size,@anchor,@mapper,@local_govt,@farmname,@location,@map_location,@co1,@status,@activated,@createdat,@deleted,@isvalid,@type)", sc);
        //                                            createschedule.Parameters.AddWithValue("@mapguid", mapguid);
        //                                            createschedule.Parameters.AddWithValue("@crop", crop);
        //                                            createschedule.Parameters.AddWithValue("@size", size);
        //                                            createschedule.Parameters.AddWithValue("@anchor", anchor);
        //                                            createschedule.Parameters.AddWithValue("@mapper", mapper);
        //                                            createschedule.Parameters.AddWithValue("@local_govt", local_govt);
        //                                            createschedule.Parameters.AddWithValue("@farmname", farmname);
        //                                            createschedule.Parameters.AddWithValue("@location", state);
        //                                            createschedule.Parameters.AddWithValue("@map_location", templocation);
        //                                            createschedule.Parameters.AddWithValue("@co1", coordinate);
        //                                            createschedule.Parameters.AddWithValue("@status", coordinatestatus);
        //                                            createschedule.Parameters.AddWithValue("@reason", reason);
        //                                            createschedule.Parameters.AddWithValue("@activated", activated);
        //                                            createschedule.Parameters.AddWithValue("@createdat", created);
        //                                            createschedule.Parameters.AddWithValue("@deleted", deleted);
        //                                            createschedule.Parameters.AddWithValue("@isvalid", 0);
        //                                            createschedule.Parameters.AddWithValue("@type", type);
        //                                            createschedule.ExecuteNonQuery();
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }

        //                        else
        //                        {
        //                            // Parse the response body.
        //                            //var deserializer = new RestSharp.Serialization.Json.JsonDeserializer();
        //                            var deserializer = new RestSharp.Deserializers.JsonDeserializer();
        //                            var dataObjects = deserializer.Deserialize<errorrep>(response);
        //                            DateTime now = DateTime.Now;
        //                            int activated = 0;

        //                            string timeofvalidation = now.ToString("dd/MM/yyyy hh:mm tt");
        //                            // string status = dataObjects.status;
        //                            if (dataObjects.error != null)
        //                            {
        //                                string reason = dataObjects.error.message.ToString();
        //                                string errorcode = dataObjects.error.code.ToString();
        //                                // string valerror = dataObjects.error.context.longitude.ToString();
        //                                dt.Rows.Add(timeofvalidation, farmname, coordinate, state, "NA", "N/A", "Invalid");
        //                                if (CheckBox1.Checked == true)
        //                                {
        //                                    Guid mapguid = Guid.NewGuid();
        //                                    string coordinatestatus = "Invalid";
        //                                    DateTime created = DateTime.Now;
        //                                    int deleted = 0;
        //                                    SqlCommand createschedule = new SqlCommand("insert into all_farms (farm_guid,crop,size,anchor,mapper,local_govt,farm_name,location,map_location,coordinate1,status,activated,created_at,deleted,is_valid,type) values(@mapguid,@crop,@size,@anchor,@mapper,@local_govt,@farmname,@location,@map_location,@co1,@status,@activated,@createdat,@deleted,@isvalid,@type)", sc);
        //                                    createschedule.Parameters.AddWithValue("@mapguid", mapguid);
        //                                    createschedule.Parameters.AddWithValue("@crop", crop);
        //                                    createschedule.Parameters.AddWithValue("@size", size);
        //                                    createschedule.Parameters.AddWithValue("@anchor", anchor);
        //                                    createschedule.Parameters.AddWithValue("@mapper", mapper);
        //                                    createschedule.Parameters.AddWithValue("@local_govt", local_govt);
        //                                    createschedule.Parameters.AddWithValue("@farmname", farmname);
        //                                    createschedule.Parameters.AddWithValue("@location", state);
        //                                    createschedule.Parameters.AddWithValue("@map_location", "N/A");
        //                                    createschedule.Parameters.AddWithValue("@co1", coordinate);

        //                                    createschedule.Parameters.AddWithValue("@status", coordinatestatus);
        //                                    createschedule.Parameters.AddWithValue("@reason", reason);
        //                                    createschedule.Parameters.AddWithValue("@activated", activated);
        //                                    createschedule.Parameters.AddWithValue("@createdat", created);
        //                                    createschedule.Parameters.AddWithValue("@deleted", deleted);
        //                                    createschedule.Parameters.AddWithValue("@isvalid", 0);
        //                                    createschedule.Parameters.AddWithValue("@type", "N/A");
        //                                    createschedule.ExecuteNonQuery();
        //                                }
        //                                else
        //                                {

        //                                }



        //                            }
        //                            else
        //                            {

        //                            }

        //                        }
        //                    }
        //                }
        //                Repeater3.DataSource = dt;
        //                Repeater3.DataBind();
        //                alert.Visible = true;
        //                alert.Attributes.Add("class", "alert alert-success col-xl-6 offset-md-3");
        //                innertext.InnerHtml = "Complete! (See logs for Details)";

        //                sc.Close();
        //            }

                
        //    }
        //    catch (Exception e)
        //    {
        //        Repeater3.DataSource = dt;
        //        Repeater3.DataBind();
        //        alert.Visible = true;
        //        innertext.InnerHtml = "Error:" + e.ToString() + "";
        //    }
        //}
    }
}