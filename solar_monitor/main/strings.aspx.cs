using solar_monitor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solar_monitor.main
{
    public partial class strings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string rtype = DropDownList2.SelectedItem.Text;
                string fromdate = DateTime.Now.ToString("MM/dd/yyyy");
                string enddate = DateTime.Now.ToString("MM/dd/yyyy");
                string stringtxt = string.Empty;
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
                string get = $"select Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid={stringtxt} and Date between '{fromdate}' and '{enddate}' order by Time asc ";
                DataTable dt = Utils.GetRequest(get);
                Repeater25.DataSource = dt;
                Repeater25.DataBind();
                switch (rtype)
                {
                    case "Both":
                        GetStringBoth(dt, stringtxt);
                        break;
                    case "Voltage":
                        GetStringVolatage(dt, stringtxt);
                        break;
                    case "Current":
                        GetStringCurrent(dt, stringtxt);
                        break;
                    default:
                        GetStringBoth(dt, stringtxt);
                        break;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rtype = DropDownList2.SelectedItem.Text;             
                string fromdate = startdatetxt.Value;
                string enddate = enddatetxt.Value;
                string stringtxt=string.Empty;
                string st = DropDownList1.SelectedItem.Text;
                switch(st)
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
                string get = $"select Stringid,Date,convert(varchar(5), Time,21) as time, voltage,SCurrent from Temp_Voltage_1 where stringid={stringtxt} and Date between '{fromdate}' and '{enddate}' order by Time asc ";
                DataTable dt = Utils.GetRequest(get);
                Repeater25.DataSource = dt;
                Repeater25.DataBind();
                switch (rtype)
                {
                    case "Both":
                        GetStringBoth(dt,stringtxt);
                        break;
                    case "Voltage":
                        GetStringVolatage(dt, stringtxt);
                        break;
                    case "Current":
                        GetStringCurrent(dt, stringtxt);
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


        private void GetStringCurrent(DataTable dt, string str)
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
 title: 'Current (A) Graph for H" + str + "");
                strScript.Append(@"',
             curveType: 'function',
             legend: { position: 'bottom' },
                  colors: [ 'red', ],
           
          
                  
                 chartArea: { width: '90%', height: '90%' },
                  legend: {position: 'right', textStyle: { color: '#b1b1b1' } },
                    lineWidth: 2,
                  backgroundColor: {fill: '#f1f3f0'},
curveType: 'function',
          pointSize: 2,
                  backgroundColor: {
                      fill: '#transparent'
                  },
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['Date', 'Current'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM") + " " + row["Time"] + "'," + row["SCurrent"] + "],");
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

        private void GetStringVolatage(DataTable dt, string str)
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
 title: 'Voltage Graph for H"+str+"");
                strScript.Append(@"',
            curveType: 'function',
                  
                  chartArea: { width: '90%', height: '90%' },
                  legend: {position: 'right', textStyle: { color: '#b1b1b1' } },
                    lineWidth: 2,
                  backgroundColor: {fill: '#f1f3f0'},
curveType: 'function',
          pointSize: 2,
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['Date', 'Voltage'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM") +" "+ row["Time"]+"'," + row["Voltage"] + "],");
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
                  backgroundColor: {fill: '#f1f3f0'},
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
                    strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM") + ","+ row["Time"]+"'," + row["voltage"] + "," + row["SCurrent"] + "],");
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