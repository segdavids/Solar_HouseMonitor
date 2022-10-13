using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using solar_monitor.Models;


namespace solar_monitor.main
{
    public partial class dlavg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  getstats();
            GetDegreeClass();
        }

        public void GetDegreeClass()
        {
            if (!IsPostBack)
            {
                string query = "select ParameterName,Unit from Parameters";
                Utils.BindListBox(countryoforiginlistbx, query, "ParameterName", "Unit"/*, "Select State"*/);
            }
        }

        public void getstats()
        {
            try
            {
                string fromdate = "";
                string enddate = enddatetxt.Value;
                string get = $"select * from DL_Avg order by Timestamp desc ";
                DataTable dt = Utils.GetRequest(get);
                Repeater25.DataSource = dt;
                Repeater25.DataBind();
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.Message.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count = countryoforiginlistbx.GetSelectedIndices().Count();
                if (count > 4)
                {
                    alert.Visible = true;
                    innertext.InnerHtml = "You cannot plot for more than 4 parameters at once";
                    return;
                }
                string condition5 = string.Empty;
                foreach (ListItem item in countryoforiginlistbx.Items)
                {
                    condition5 += item.Selected ? string.Format("{0},", item.Text + "(" + item.Value + ")") : string.Empty;
                    count = count + 1;
                }

                //string fromdate = startdatetxt.Value;
                // string enddate = enddatetxt.Value;

                string fromtime = starttimetxt.Value == string.Empty ? "00:00" : starttimetxt.Value;
                string fromdate = Convert.ToDateTime(startdatetxt.Value + " " + fromtime).ToString("yyyy-MM-dd HH:mm");
                //   string enddate = enddatetxt.Value;
                string endtime = endtimetxt.Value == string.Empty ? "00:00" : endtimetxt.Value;
                string enddate = Convert.ToDateTime(enddatetxt.Value + " " + endtime).ToString("yyyy-MM-dd HH:mm");
                string stringtxt = string.Empty;

                //string get = $"select * from DL_Avg order by Timestamp desc ";
                string get = $"select * from DL_Avg where Timestamp between '{fromdate}' and '{enddate}' order by Timestamp asc ";
                DataTable dt = Utils.GetRequest(get);
                Repeater25.DataSource = dt;
                Repeater25.DataBind();
                if(dt.Rows.Count>0)
                {
                    GetStringCurrent(dt, fromdate, enddate, condition5);
                }
                else
                {
                    Literal1.Text = "No data for seleted date and time:  CS Logger ";
                }
                
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.Message.ToString();
            }
        }

        private void GetStringCurrent(DataTable dt, string from, string to,string graphtitle)
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
 title: 'CS Logger Average for "+graphtitle+" from " + from + " to " + to + " ");
                strScript.Append(@"',
             curveType: 'function',
            legend: { position: 'right' },
 hAxis: {
         title: 'T(t)");
                strScript.Append(@"'

        },
           
           vAxis:
            {
            title: '" + graphtitle + ""); 
                strScript.Append(@"',
        },
                 
              width: '90%',
        height: '85%',
                     
       
                    lineWidth: 2,
                  backgroundColor: {fill: 'transparent'},
curveType: 'function',
          pointSize: 1,
                 
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['Date',");
                foreach (ListItem item in countryoforiginlistbx.Items)
                {
                    string selecteditem = item.Selected ? string.Format("'{0}',", item.Text) : String.Empty;
                    if (!string.IsNullOrEmpty(selecteditem))
                    {
                        strScript.Append("" +  selecteditem);
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
                        string selecteditem = item.Selected ? string.Format("{0}", item.Text) : String.Empty;
                        if (!string.IsNullOrEmpty(selecteditem))
                        {
                            strScript.Append("" + row["" + selecteditem + ""]+ "," );
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