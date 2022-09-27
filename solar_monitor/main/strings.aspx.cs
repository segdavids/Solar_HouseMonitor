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
                GetDegreeClass();
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
                string get = $"select Stringid,Date,convert(varchar(5), Time,21) as time, Voltage,SCurrent as SCurrent from Temp_Voltage_1 where stringid={stringtxt} and Date between '{fromdate}' and '{enddate}' order by Time asc ";
                DataTable dt = Utils.GetRequest(get);
                if (dt.Rows.Count > 0)
                {
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
        }



        public void GetDegreeClass()
        {
            if (!IsPostBack)
            {
                string query = "select ParameterName from Parameters";
                Utils.BindListBox(countryoforiginlistbx, query, "ParameterName", "ParameterName"/*, "Select State"*/);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count = countryoforiginlistbx.GetSelectedIndices().Count();
                if (count ==0)
                {
                    alert.Visible = true;
                    innertext.InnerHtml = "You must select at least one parameter for CS Logger Chart";
                    return;
                }
                if (count > 4)
                {
                    alert.Visible = true;
                    innertext.InnerHtml = "You cannot plot for more than 4 parameters at once";
                    return;
                }
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
                string get = $"select Stringid,Date,convert(varchar(5), Time,21) as time, Voltage,SCurrent as SCurrent from Temp_Voltage_1 where stringid={stringtxt} and Date between '{fromdate}' and '{enddate}' order by Time asc ";
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
                    case "Volt. VS Curr.":
                        GetStringCurrent2(dt,fromdate,enddate,"Voltage(V) vs Current(I)","Voltage","SCurrent","Current", stringtxt);
                        break;
                    case "Curr. VS Volt.":
                        GetStringCurrent2(dt, fromdate, enddate, "Current(I) vs Voltage(V)", "SCurrent", "Voltage", "Current", stringtxt);
                        break;
                    default:
                        GetStringBoth(dt, stringtxt);
                        break;
                }

                //CS LOGGER GRAPH 
                
                string condition5 = string.Empty;
                foreach (ListItem item in countryoforiginlistbx.Items)
                {
                    condition5 += item.Selected ? string.Format("{0},", item.Value) : string.Empty;
                    count = count + 1;




                }

                //string fromdate = startdatetxt.Value;
                //string enddate = enddatetxt.Value;
                //string get = $"select * from DL_Avg order by Timestamp desc ";
                string detcslogger = $"select * from DL_Avg where Timestamp between '{fromdate} 00:00' and '{enddate} 23:59' order by Timestamp asc ";
                DataTable csloggerdat = Utils.GetRequest(detcslogger);
                Repeater1.DataSource = csloggerdat;
                Repeater1.DataBind();
                GetStringCurrent(csloggerdat, fromdate, enddate, condition5);
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
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
                  backgroundColor: {fill: '#transparent'},
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
                  backgroundColor: {fill: 'transparent'},
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
                  backgroundColor: {fill: '#transparent'},
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


        private void GetStringCurrent2(DataTable dt, string from, string to, string graphtitle, string firstvs , string seconfvs, string seconfvstitle, string stringtxt)
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
 title: 'STRING "+ stringtxt + " " + graphtitle + " from " + from + " to " + to + " ");
                strScript.Append(@"',
             curveType: 'function',
             legend: { position: 'bottom' },
                 
           
          
                  
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
                  ['"+ firstvs + "','"+seconfvstitle+"'");
               
                    
                strScript.Append(@"],");

                // 'Voc','Isc','Radiation'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("[" + row[""+firstvs+""] + "," + row[""+seconfvs+""] + "],");
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

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
              
        //    }
        //    catch (Exception ex)
        //    {
        //        alert.Visible = true;
        //        innertext.InnerHtml = ex.Message.ToString();
        //    }
        //}

        private void GetStringCurrent(DataTable dt, string from, string to, string graphtitle)
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
 title: 'Datalogger Average Graph for " + graphtitle + " from " + from + " to " + to + " ");
                strScript.Append(@"',
             curveType: 'function',
             legend: { position: 'bottom' },
                 
           
          
                  
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
                  ['Date',");
                foreach (ListItem item in countryoforiginlistbx.Items)
                {
                    string selecteditem = item.Selected ? string.Format("'{0}',", item.Value) : String.Empty;
                    if (!string.IsNullOrEmpty(selecteditem))
                    {
                        strScript.Append("" + selecteditem);
                    }

                }
                strScript = strScript.Remove(strScript.Length - 1, 1);
                strScript.Append(@"],");

                // 'Voc','Isc','Radiation'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("['" + Convert.ToDateTime(row["Timestamp"]).ToString("d-MMM HH:mm") + "',");
                    foreach (ListItem item in countryoforiginlistbx.Items)
                    {
                        string selecteditem = item.Selected ? string.Format("{0}", item.Value) : String.Empty;
                        if (!string.IsNullOrEmpty(selecteditem))
                        {
                            strScript.Append("" + row["" + selecteditem + ""] + ",");
                            //     strScript.Append("" + string.Format("{0},", row["" + item.Value + ""]));
                        }
                    }
                    strScript = strScript.Remove(strScript.Length - 1, 1);
                    strScript.ToString().Trim();
                    strScript.Append(@"],");
                    //  strScript.Append("['" + Convert.ToDateTime(row["Date"]).ToString("d-MMM") + " " + row["Time"] + "'," + row["Voc"] + "," + row["Isc"] + "," + row["Radiation"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");


                strScript.Append("var chart = new google.visualization.LineChart(document.getElementById('cslogger_graph'));" +
                    "chart.draw(data, options);}");
                strScript.Append(" </script>");

                Literal2.Text = strScript.ToString();
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