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
    public partial class voic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rtype = DropDownList2.SelectedItem.Text;
                string fromdate = Convert.ToDateTime(startdatetxt.Value).ToString("yyyy-MM-dd");
                string tempstarttime = starttimetxt.Value==""? "12:00 AM": starttimetxt.Value;
                string starttime = (Convert.ToDateTime(tempstarttime)).ToString("HH:MM");
                string enddate = Convert.ToDateTime(enddatetxt.Value).ToString("yyyy-MM-dd");// enddatetxt.Value;
                string tempendtime = endtimetxt.Value == "" ? "12:00 AM" : endtimetxt.Value;
                string endtime = (Convert.ToDateTime(tempendtime)).ToString("HH:MM");
                string stringtxt = string.Empty;
               // fromdate = fromdate + " " + starttime;
               // enddate = enddate + " " + endtime;
                string st = DropDownList1.SelectedItem.Text;
                switch (st)
                {
                    case "String 1":
                        stringtxt = "1";
                        break;
                    case "String 2":
                        stringtxt = "2";
                        break;
                    case "String 3":
                        stringtxt = "3";
                        break;
                    case "String 4":
                        stringtxt = "4";
                        break;
                    case "String 5":
                        stringtxt = "5";
                        break;
                    default:
                        break;
                }
                string get = $"select Date,DateTime,Voc,Isc,Radiation,convert(varchar(5), Time,21) as time from Voic_Ic_Rad where String_No={stringtxt} and DateTime between '{fromdate}' and '{enddate}' and Time between '{tempstarttime}' and '{tempendtime}' order by Time asc ";
                
                stringspan.InnerHtml = stringtxt;
              // stringspan.InnerHtml = get;
                string converteddatefrom = Convert.ToDateTime(fromdate).ToString("dd, MMM yyyy") + " " + tempstarttime ;
                string converteddateto = Convert.ToDateTime(enddate).ToString("dd, MMM yyyy") + " " + tempendtime;
                startdatespan.InnerHtml = Convert.ToDateTime(fromdate).ToString("dd MMM, yyyy") +" "+ tempstarttime +" TO "+ Convert.ToDateTime(enddate).ToString("dd MMM, yyyy") +" "+ tempendtime ;
                DataTable dt = Utils.GetRequest(get);
                Repeater25.DataSource = dt;
                Repeater25.DataBind();
                switch (rtype)
                {
                    case "All":
                        GetStringCurrent(dt, stringtxt, converteddatefrom, converteddateto,"I(A) V(v)","T(t)");
                        break;
                    case "Voc":
                        GetStringVolatage(dt, stringtxt,"Voc","VOC","blue", converteddatefrom, converteddateto);
                        break;
                    case "Isc":
                        GetStringVolatage(dt, stringtxt, "Isc", "ISC", "red", converteddatefrom, converteddateto);
                        break;
                    case "Radiation":
                        GetStringVolatage(dt, stringtxt, "Radiation", "Radiation", "orange", converteddatefrom, converteddateto);
                        break;
                    default:
                        GetStringBoth(dt, stringtxt);
                        break;
                }
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.Message.ToString();
            }
        }


        private void GetStringCurrent(DataTable dt, string str, string from, string to, string yaxis, string haxis)
        {
            StringBuilder strScript = new StringBuilder();

            try
            {
                //  dsChartData = GetSoilData(datefrom, dateto);


                strScript.Append(@"<script type='text/javascript'>  
                     google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

  
              function drawChart()  {  
var options = {
 title: 'Voc & Isc Graph for STRING" + str + " from "+from+ " to "+ to + " ");
                strScript.Append(@"',
             curveType: 'function',
             legend: { position: 'right' },
 hAxis: {
         title: '" + haxis + "");
                strScript.Append(@"'

        },
           
           vAxis:
            {
            title: '" + yaxis + ""); 
                strScript.Append(@"',
        },
                 
              width: '90%',
        height: '85%',
                     
       
                    lineWidth: 1,
          
                  
                  backgroundColor: {fill: 'transparent'},
curveType: 'function',
          pointSize: 1,
                 
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['Date', 'Voc','Isc'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM HH:mm") + "'," + row["Voc"] + "," + row["Isc"] + "],");
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

        private void GetStringVolatage(DataTable dt, string str,string unit, string fullname, string color, string from, string to)
        {
            //string test = "select Stringid,Date,convert(varchar(5), Time,21) as time, voltage from Temp_Voltage_1 where stringid=3 and Date  =  convert(varchar(16), '2022-02-25',21)";
            //DataTable dt = Utils.GetRequest(test);
            StringBuilder strScript = new StringBuilder();

            try
            {
                //  dsChartData = GetSoilData(datefrom, dateto);


                strScript.Append(@"<script type='text/javascript'>  
                     google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

  
              function drawChart()  {  
var options = {

            title: '" + fullname + " Graph for STRING" + str + "  from " + from + " TO " + to + " ");
                strScript.Append(@"',
            curveType: 'function',
                    colors: [ '" + color +"");
                strScript.Append(@"', ],
                  chartArea: { width: '90%', height: '90%' },
                  legend: {position: 'right', textStyle: { color: '#b1b1b1' } },
                    lineWidth: 3,
                  backgroundColor: {fill: 'transparent'},
curveType: 'function',
          pointSize: 2,
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['Date', '" + fullname + "'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM HH:mm") + "'," + row[""+ unit+""] + "],");
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

        private void GetStringBoth(DataTable dt, string str)
        {
            //string test = "select Stringid,Date,convert(varchar(5), Time,21) as time, voltage from Temp_Voltage_1 where stringid=3 and Date  =  convert(varchar(16), '2022-02-25',21)";
            //DataTable dt = Utils.GetRequest(test);
            StringBuilder strScript = new StringBuilder();

            try
            {
                //  dsChartData = GetSoilData(datefrom, dateto);


                strScript.Append(@"<script type='text/javascript'>  
                     google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

  
              function drawChart()  {  
var options = {
title: 'Current (A) vs Voltage (V) Graph for H" + str + "");
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
                    strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM HH:mm") + "'," + row["voltage"] + "," + row["SCurrent"] + "],");
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
    }
}