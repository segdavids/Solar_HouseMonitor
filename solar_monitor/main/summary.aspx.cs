using solar_monitor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solar_monitor.main
{
    public partial class summary : System.Web.UI.Page
    {
       

      
        protected void Page_Load(object sender, EventArgs e)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            getstring1();
            getstring2();
            getstring3();
            getstring4();
            getstring5();
            getstring6();
            Getforcast();
            GetStringBoth();
            averagevoltageanalysis();
            averagecurrentanalysis();
        }

        public void getstring1()
        {
            string query = "select top 1 Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid=1 order by Time desc";
            DataTable dt = Utils.GetRequest(query);
            Repeater25.DataSource = dt;
            Repeater25.DataBind();
        }
        public void getstring2()
        {
            string query = "select top 1 Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid=2 order by Time desc";
            DataTable dt = Utils.GetRequest(query);
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }
        public void getstring3()
        {
            string query = "select top 1 Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid=3 order by Time desc";
            DataTable dt = Utils.GetRequest(query);
            Repeater4.DataSource = dt;
            Repeater4.DataBind();
        }
        public void getstring4()
        {
            string query = "select top 1 Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid=4 order by Time desc";
            DataTable dt = Utils.GetRequest(query);
            Repeater6.DataSource = dt;
            Repeater6.DataBind();
        }
        public void getstring5()
        {
            string query = "select top 1 Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid=5 order by Time desc";
            DataTable dt = Utils.GetRequest(query);
            Repeater7.DataSource = dt;
            Repeater7.DataBind();
        }

        public void getstring6()
        {
            try
            {
                //string fromdate = DateTime.Now.ToString("MM/dd/yyyy");
                // string enddate = DateTime.Now.ToString("MM/dd/yyyy");
                string fromdate = "02/25/2022";
                string enddate = "02/25/2022";
                string get = $"select String_No,Date,Voc,Isc,Radiation,convert(varchar(5), Time,21) as time from Voic_Ic_Rad where Date between '{fromdate}' and '{enddate}' order by Time asc ";
                DataTable dt = Utils.GetRequest(get);
                repeater34.DataSource = dt;
                repeater1.DataSource = dt;
                repeater34.DataBind();
                repeater1.DataBind();
            }
            catch(Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.Message.ToString();
            }
        }


        private void GetStringBoth()
        {
            Random rd = new Random();
            int srting = rd.Next(1, 6);
           // string date = DateTime.Now.ToString("MM/dd/yyyy");
            string date = "02/25/2022";
            string get = $"select Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid={srting} and Date = '{date}' order by Time asc ";
            DataTable dt = Utils.GetRequest(get);
            StringBuilder strScript = new StringBuilder();

            try
            {
                strScript.Append(@"<script type='text/javascript'>  
                     google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

  
              function drawChart()  {  
var options = {
title: 'Current (A) & Voltage (V) Graph for String" + srting + "");
                strScript.Append(@"',
             curveType: 'function',
                  
                  chartArea: { width: '90%', height: '90%' },
                  legend: {position: 'right', textStyle: { color: '#b1b1b1' } },
                    lineWidth: 2,
                  backgroundColor: {fill: 'transparent'},
curveType: 'function',
          pointSize: 2,
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['Date', 'Voltage','Current'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM") + "," + row["Time"] + "'," + row["voltage"] + "," + row["SCurrent"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");


                strScript.Append("var chart = new google.visualization.LineChart(document.getElementById('chartt_div'));" +
                    "chart.draw(data, options);}");
                strScript.Append(" </script>");

                Literal1.Text = strScript.ToString();
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
            finally
            {
                dt.Dispose();
                strScript.Clear();
            }
        }

        private void GetCropDistChardata()
        {
            Random rd = new Random();
            int srting = rd.Next(1, 6);
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string get = $"select Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid={srting} and Date = {date} order by Time asc ";
            //string test = "select Stringid,Date,convert(varchar(5), Time,21) as time, voltage from Temp_Voltage_1 where stringid= and Date  =  convert(varchar(16), '2022-02-25',21)";
            DataTable dt = Utils.GetRequest(get);
            StringBuilder strScript = new StringBuilder();

            try
            {
                //  dsChartData = GetSoilData(datefrom, dateto);


                strScript.Append(@"<script type='text/javascript'>  
                     google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

  
              function drawChart()  {  
var options = {
 title: 'Soil Moisture in the Last 30 days',
             curveType: 'function',
             legend: { position: 'bottom' },

                  
                  chartArea: { width: '90%', height: '90%' },
                  legend: {position: 'top', textStyle: { color: '#b1b1b1' } },

                  backgroundColor: {
                      fill: 'transparent'
                  },
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['Date', 'Surface Moisture','Ground Moisture'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("['" + Convert.ToDateTime(row["date"]).ToString("dd-MMM") + "'," + row["surface_moisture"] + "," + row["root_moisture"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");


                strScript.Append("var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));" +
                    "chart.draw(data, options);}");
                strScript.Append(" </script>");

                Literal1.Text = strScript.ToString();
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
            finally
            {
                dt.Dispose();
                strScript.Clear();
            }
        }

        public void Getforcast()
        {
            try
            {
                DataTable weathertodaydt = new DataTable();
                weathertodaydt.Columns.AddRange(new DataColumn[9]
                {
                        new DataColumn("date", typeof(string)),
                        new DataColumn("todaytemp", typeof(string)),
                        new DataColumn("feelslike", typeof(string)),
                        new DataColumn("wind", typeof(double)),
                        new DataColumn("humidity", typeof(double)),
                        new DataColumn("cloud", typeof(double)),
                        new DataColumn("precipitatiom", typeof(double)),
                        new DataColumn("icon", typeof(string)),
                        new DataColumn("weatherDesc",typeof(string))
                });

                var client = new RestSharp.RestClient("https://api.openweathermap.org");
                var request = new RestSharp.RestRequest("/data/2.5/onecall?lat=" + -31.487157183388565 + "&lon=" + 26.920641642801872 + "&exclude=minutely,hourly&appid=6a8a5d190e30bc6950e102a0c8d18b88", RestSharp.Method.GET);
                request.RequestFormat = RestSharp.DataFormat.Json;
                var response = client.Execute(request);
                int statcode = Convert.ToInt32(response.StatusCode);
                if (statcode == 200)
                {
                    weather.response weatherclass = new weather.response();
                    // Parse the response body.
                    weatherclass = Newtonsoft.Json.JsonConvert.DeserializeObject<weather.response>(response.Content);
                    //GET WEATHER FOR TODAY
                    double todaytemp = weatherclass.current.temp - 273;
                    double feelslike = weatherclass.current.feels_like - 273;
                    double pressuretoday = weatherclass.current.pressure;
                    double humiditytiday = weatherclass.current.humidity;
                    double cloudstoday = weatherclass.current.clouds;
                    double wind_speedtody = weatherclass.current.wind_speed;
                    string descriptiontoday = weatherclass.current.weather[0].description;
                    string icontoday = "http://openweathermap.org/img/wn/" + weatherclass.current.weather[0].icon + "@2x.png";
                    weathertodaydt.Rows.Add(DateTime.Now.ToString("MMM dd, yyyy"), (string.Format("{0:N0}", todaytemp.ToString())), (string.Format("{0:N1}", feelslike.ToString())), wind_speedtody, humiditytiday, cloudstoday, pressuretoday, icontoday, descriptiontoday);
                    Repeater5.DataSource = weathertodaydt;

                    Repeater5.DataBind();

                }

            }

            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
        }


        private void averagevoltageanalysis()
        {

            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                //string query = "select mapper, sum(size) as summer from all_farms group by mapper";
                string query = "select 'String '+ CONVERT(varchar,stringid) as stringid, sum(voltage)/count(*) voltsum,sum(SCurrent)/count(*) from Temp_Voltage_1 where date='02/25/2022' group by stringId";
                dsChartData = Utils.GetRequest(query);


                strScript.Append(@"<script type='text/javascript'>  
                       google.charts.load('current', { packages: ['corechart'] });
          google.charts.setOnLoadCallback(drawChart);
  
              function drawChart()  {  
var options = {
                  chartArea: { width: '80%', height: '80%' },
                  legend: { textStyle: { color: '#b1b1b1' } },

                  backgroundColor: {
                      fill: 'transparent'
                  },
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  },
                  slices: {
                      2: { offset: 0.0 },
                      3: { offset: 0.0 },
                      1: { offset: 0.0 },
                      4: { offset: 0.0 },
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['String', 'Voltage Today'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["stringid"] + "'," + row["voltsum"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");


                strScript.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_3d2'));" +
                    "chart.draw(data, options);}");
                strScript.Append(" </script>");

                Literal3.Text = strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }

        private void averagecurrentanalysis()
        {

            string query = "select 'String '+ CONVERT(varchar,stringid) as stringid, sum(voltage)/count(*) voltsum,sum(SCurrent)/count(*) as scurrnet from Temp_Voltage_1 where date='02/25/2022' group by stringId";
            DataTable dsChartData = new DataTable();
            StringBuilder strScript = new StringBuilder();

            try
            {
                dsChartData = Utils.GetRequest(query);


                strScript.Append(@"<script type='text/javascript'>  
                       google.charts.load('current', { packages: ['corechart'] });
          google.charts.setOnLoadCallback(drawChart);
  
              function drawChart()  {  
var options = {
           pieHole: 0.6,
           chartArea: { width: '80%', height: '80%' },
           legend: {textStyle: {color: '#b1b1b1'}},

                backgroundColor: {
                    fill: 'transparent'
                },
                animation: {
  duration: 1000,
  easing: 'in',
},
                slices: {
             
                1: { offset: 0.0 },
                0: { offset: 0.0 },
                5: { offset: 0.0 },
                6: { offset: 0.0 },
            }
        };

                    var data = google.visualization.arrayToDataTable([
                  ['String', 'Total Current Today'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["stringid"] + "'," + row["scurrnet"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");


                strScript.Append("var chart = new google.visualization.PieChart(document.getElementById('pie_chart'));" +
                    "chart.draw(data, options);}");
                strScript.Append(" </script>");

                Literal2.Text = strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                dsChartData.Dispose();
                strScript.Clear();
            }
        }
    }
}