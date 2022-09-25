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

namespace solar_monitor.main
{
    public partial class fetch_data : System.Web.UI.Page
    {
       public enum settingtype
        {
            cslogger, ivcurve
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string pathf = getfilepath();
                datfilelocationtxt.Value = pathf;   
            }
        }

        protected void fetch_cslogger(object sender, EventArgs e)
        {
            try
            {
                string filename = "SolarHouse_Average.dat";
                string filepath = getfilepath();
                string[] lines = File.ReadAllLines(filepath+filename);
                for (int i = 4; i < lines.Length; i++)
                {
                    DateTime dtime = Convert.ToDateTime(lines[i].Split(',')[0].ToString());
                    Int32 id = Convert.ToInt32(lines[i].Split(' ')[0]);
                    DateTime dateTime = Convert.ToDateTime(lines[i].Split(' ')[1].ToString() + " " + lines[i].Split(' ')[2].ToString());
                    int id1 = Convert.ToInt32(lines[i].Split(' ')[3]);
                    int id2 = Convert.ToInt32(lines[i].Split(' ')[4]);
                    int id3 = Convert.ToInt32(lines[i].Split(' ')[5]);
                    int id4 = Convert.ToInt32(lines[i].Split(' ')[6]);
                   // Insert(id, dateTime, id1, id2, id3, id4);
                }
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = "nyscjobs_new";
                string password = "247newjobs@??!!";
                var utility = new FtpUtility();
                utility.UserName = "nyscjobs_new";
                utility.Password = "247newjobs@??!!";
                utility.Path = "52.229.31.163";

                WebClient request = new WebClient();
                string url = "ftp://ftp.microsoft.com/developr/fortran/" + "README.TXT";
                request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");


                if (utility.ListFiles().Count() > 0)
                {
                    //The folder contains files
                    for (int i = 1; i <= 6; i++)
                    {
                        var fileNameToCkeck = "H000" + i.ToString();
                        if(utility.ListFiles().Contains(fileNameToCkeck))
                        {
                            //The file exists
                        }
                    }
                }
                
                

               
            }
            catch
            {

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

        public class uploadparams
        {
            public string time { get; set; }
            public string date { get; set; }
            public string voltage { get; set; }
            public double current { get; set; }
          
        }

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