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
               // string st = DropDownList1.SelectedItem.Text;



                //switch (st)
                //{
                //    case "String 1":
                //        stringtxt = "1";
                //        break;
                //    case "String 2":
                //        stringtxt = "2";
                //        break;
                //    case "String 3":
                //        stringtxt = "3";
                //        break;
                //    case "String 4":
                //        stringtxt = "4";
                //        break;
                //    case "String 5":
                //        stringtxt = "5";
                //        break;
                //    default:
                //        break;
                //}
                string get = $"select Stringid,Date,convert(varchar(5), Time,21) as time, Voltage,SCurrent as SCurrent from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
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
                string query = "select ParameterName,Unit from Parameters";
                Utils.BindListBox(countryoforiginlistbx, query, "ParameterName", "Unit"/*, "Select State"*/);
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
                string fromtime = starttimetxt.Value == string.Empty? "00:00":starttimetxt.Value;
                string fromdate = Convert.ToDateTime(startdatetxt.Value+ " "+fromtime).ToString("yyyy-MM-dd HH:mm");
             //   string enddate = enddatetxt.Value;
                string endtime = endtimetxt.Value == string.Empty ? "00:00" : endtimetxt.Value;
                string enddate = Convert.ToDateTime(enddatetxt.Value + " " + endtime).ToString("yyyy-MM-dd HH:mm");
                string stringtxt=string.Empty;
               
                string get = String.Empty;
                DataTable dt = new DataTable();
                get = $"select Stringid,Date,convert(varchar(5), DateTime,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                dt = Utils.GetRequest(get);
                Repeater25.DataSource = dt;
                Repeater25.DataBind();
                DataTable dt2 = new DataTable();
                switch (rtype)
                {
                    case "All":
                        get = $"select Stringid,Date,convert(varchar(5), Time,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                        dt2 = Utils.GetRequest(get);
                        List<string> list = new List<string> { "Voltage", "SCurrent", "Power" };
                        string forlit1=string.Empty;
                        string forlit2 = string.Empty;
                        string forlit3 = string.Empty;
                        string forlit4 = string.Empty;
                        string forlit5 = string.Empty   ;
                        for (int i =1;i<6;i++)
                        {
                            string _sqlWhere = "Stringid = "+i+"";
                            string _sqlOrder = "Time asc";
                            DataRow[] rows = dt2.Select(_sqlWhere, _sqlOrder);
                            if(rows.Length>0)
                            {
                                DataTable _newDataTable = rows.CopyToDataTable();
                                switch (i)
                                {
                                    case 1:
                                       forlit1 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A) P(w)", "curve_chart", Literal1);
                                        break;
                                    case 2:
                                        forlit2 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A) P(w)", "string2_curve", Literal2);
                                        break;
                                    case 3:
                                        forlit3 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A) P(w)", "string3_curve", Literal3);
                                        break;
                                    case 4:
                                        forlit4 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A) P(w)", "string4_curve", Literal4);
                                        break;
                                    case 5:
                                        forlit5 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A) P(w)", "string5_curve", Literal5);
                                        break;

                                }
                            }
                           
                            
                        }
                        if (forlit1.Trim().Length > 0)
                            str1.Visible = true;
                            nodata1.Visible = false;
                            Literal1.Text = forlit1.Trim().Length >0? forlit1:"No Data for String 1";
                        if (forlit2.Trim().Length > 0)
                            str2.Visible = true;
                            nodata2.Visible = false;
                            Literal2.Text = forlit2.Trim().Length > 0 ? forlit2 : "No Data for String 2";
                        if (forlit3.Trim().Length > 0)
                            str3.Visible = true;    
                            nodata3.Visible = false;
                            Literal3.Text = forlit3.Trim().Length > 0 ? forlit3 : "No Data for String 3";
                        if (forlit4.Trim().Length > 0)
                            str4.Visible = true;
                            nodata4.Visible = false;
                            Literal4.Text = forlit4.Trim().Length > 0 ? forlit4 : "No Data for String 4";
                        if (forlit5.Trim().Length > 0)
                            str5.Visible = true;
                            nodata5.Visible = false;
                            Literal5.Text = forlit5.Trim().Length > 0 ? forlit5 : "No Data for String 5";
                        break;

                        //VOLTAGE VS CURRENT
                    case "V - I":
                        get = $"select Stringid,Date,convert(varchar(5), Time,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                        dt2 = Utils.GetRequest(get);
                        list = new List<string> { "Voltage", "SCurrent" };
                         forlit1 = string.Empty;
                         forlit2 = string.Empty;
                         forlit3 = string.Empty;
                         forlit4 = string.Empty;
                         forlit5 = string.Empty;
                        for (int i = 1; i < 6; i++)
                        {
                            string _sqlWhere = "Stringid = " + i + "";
                            string _sqlOrder = "DateTime asc";
                            DataRow[] rows = dt2.Select(_sqlWhere, _sqlOrder);
                            if (rows.Length > 0)
                            {
                                DataTable _newDataTable = rows.CopyToDataTable();
                                switch (i)
                                {
                                    case 1:
                                        forlit1 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "I(A)", "V(v)", "curve_chart", Literal1);
                                        break;
                                    case 2:
                                        forlit2 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "I(A)", "V(v)", "string2_curve", Literal2);
                                        break;
                                    case 3:
                                        forlit3 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "I(A)", "V(v)", "string3_curve", Literal3);
                                        break;
                                    case 4:
                                        forlit4 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "I(A)", "V(v)", "string4_curve", Literal4);
                                        break;
                                    case 5:
                                        forlit5 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "I(A)", "V(v)", "string5_curve", Literal5);
                                        break;
                                }
                            }
                        }
                        if (forlit1.Length > 0)
                            str1.Visible = true;
                        nodata1.Visible = false;
                        Literal1.Text = forlit1.Length > 0 ? forlit1 : "No Data for String 1";
                        if (forlit2.Length > 0)
                            str2.Visible = true;
                        nodata2.Visible = false;
                        Literal2.Text = forlit2.Length > 0 ? forlit2 : "No Data for String 2";
                        if (forlit3.Length > 0)
                            str3.Visible = true;
                        nodata3.Visible = false;
                        Literal3.Text = forlit3.Length > 0 ? forlit3 : "No Data for String 3";
                        if (forlit4.Length > 0)
                            str4.Visible = true;
                        nodata4.Visible = false;
                        Literal4.Text = forlit4.Length > 0 ? forlit4 : "No Data for String 4";
                        if (forlit5.Length > 0)
                            str5.Visible = true;
                        nodata5.Visible = false;
                        Literal5.Text = forlit5.Length > 0 ? forlit5 : "No Data for String 5";
                        break;

                        ///CURRENT VS TIME
                    case "C - T":
                        get = $"select Stringid,DateTime,convert(varchar(5), Time,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                        dt2 = Utils.GetRequest(get);
                        list = new List<string> { "DateTime", "SCurrent" };
                        forlit1 = string.Empty;
                        forlit2 = string.Empty;
                        forlit3 = string.Empty;
                        forlit4 = string.Empty;
                        forlit5 = string.Empty;
                        for (int i = 1; i < 6; i++)
                        {
                            string _sqlWhere = "Stringid = " + i + "";
                            string _sqlOrder = "DateTime asc";
                            DataRow[] rows = dt2.Select(_sqlWhere, _sqlOrder);
                            if (rows.Length > 0)
                            {
                                DataTable _newDataTable = rows.CopyToDataTable();
                                switch (i)
                                {
                                    case 1:
                                        forlit1 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "I(A)", "curve_chart", Literal1);
                                        break;
                                    case 2:
                                        forlit2 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "I(A)", "string2_curve", Literal2);
                                        break;
                                    case 3:
                                        forlit3 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "I(A)", "string3_curve", Literal3);
                                        break;
                                    case 4:
                                        forlit4 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "I(A)", "string4_curve", Literal4);
                                        break;
                                    case 5:
                                        forlit5 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "I(A)", "string5_curve", Literal5);
                                        break;
                                }
                            }
                        }
                        if (forlit1.Length > 0)
                            str1.Visible = true;
                            nodata1.Visible = false;
                            Literal1.Text = forlit1.Length > 0 ? forlit1 : "No Data for String 1";
                        if (forlit2.Length > 0)
                            str2.Visible = true;
                            nodata2.Visible = false;
                            Literal2.Text = forlit2.Length > 0 ? forlit2 : "No Data for String 2";
                        if (forlit3.Length > 0)
                            str3.Visible = true;
                            nodata3.Visible = false;
                            Literal3.Text = forlit3.Length > 0 ? forlit3 : "No Data for String 3";
                        if (forlit4.Length > 0)
                            str4.Visible = true;
                            nodata4.Visible = false;
                            Literal4.Text = forlit4.Length > 0 ? forlit4 : "No Data for String 4";
                        if (forlit5.Length > 0)
                            str5.Visible = true;
                            nodata5.Visible = false;
                            Literal5.Text = forlit5.Length > 0 ? forlit5 : "No Data for String 5";
                            break;

                        //VOLTAGE VS TIME
                    case "V - T":
                        get = $"select Stringid,DateTime,convert(varchar(5), Time,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                        dt2 = Utils.GetRequest(get);
                        list = new List<string> { "DateTime", "Voltage" };
                        forlit1 = string.Empty;
                        forlit2 = string.Empty;
                        forlit3 = string.Empty;
                        forlit4 = string.Empty;
                        forlit5 = string.Empty;
                        for (int i = 1; i < 6; i++)
                        {
                            string _sqlWhere = "Stringid = " + i + "";
                            string _sqlOrder = "DateTime asc";
                            DataRow[] rows = dt2.Select(_sqlWhere, _sqlOrder);
                            if (rows.Length > 0)
                            {
                                DataTable _newDataTable = rows.CopyToDataTable();
                                switch (i)
                                {
                                    case 1:
                                        forlit1 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "V(v)", "curve_chart", Literal1);
                                        break;
                                    case 2:
                                        forlit2 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "V(v)", "string2_curve", Literal2);
                                        break;
                                    case 3:
                                        forlit3 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "V(v)", "string3_curve", Literal3);
                                        break;
                                    case 4:
                                        forlit4 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "V(v)", "string4_curve", Literal4);
                                        break;
                                    case 5:
                                        forlit5 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "V(v)", "string5_curve", Literal5);
                                        break;
                                }
                            }
                        }
                        if (forlit1.Length > 0)
                            str1.Visible = true;
                        nodata1.Visible = false;
                        Literal1.Text = forlit1.Length > 0 ? forlit1 : "No Data for String 1";
                        if (forlit2.Length > 0)
                            str2.Visible = true;
                        nodata2.Visible = false;
                        Literal2.Text = forlit2.Length > 0 ? forlit2 : "No Data for String 2";
                        if (forlit3.Length > 0)
                            str3.Visible = true;
                        nodata3.Visible = false;
                        Literal3.Text = forlit3.Length > 0 ? forlit3 : "No Data for String 3";
                        if (forlit4.Length > 0)
                            str4.Visible = true;
                        nodata4.Visible = false;
                        Literal4.Text = forlit4.Length > 0 ? forlit4 : "No Data for String 4";
                        if (forlit5.Length > 0)
                            str5.Visible = true;
                        nodata5.Visible = false;
                        Literal5.Text = forlit5.Length > 0 ? forlit5 : "No Data for String 5";
                        break;


                    //POWER VS TIME
                    case "P - T":
                        get = $"select Stringid,DateTime,convert(varchar(5), Time,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                        dt2 = Utils.GetRequest(get);
                        list = new List<string> { "DateTime", "Power" };
                        forlit1 = string.Empty;
                        forlit2 = string.Empty;
                        forlit3 = string.Empty;
                        forlit4 = string.Empty;
                        forlit5 = string.Empty;
                        for (int i = 1; i < 6; i++)
                        {
                            string _sqlWhere = "Stringid = " + i + "";
                            string _sqlOrder = "DateTime asc";
                            DataRow[] rows = dt2.Select(_sqlWhere, _sqlOrder);
                            if (rows.Length > 0)
                            {
                                DataTable _newDataTable = rows.CopyToDataTable();
                                switch (i)
                                {
                                    case 1:
                                        forlit1 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "P(w)", "curve_chart", Literal1);
                                        break;
                                    case 2:
                                        forlit2 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "P(w)", "string2_curve", Literal2);
                                        break;
                                    case 3:
                                        forlit3 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "P(w)", "string3_curve", Literal3);
                                        break;
                                    case 4:
                                        forlit4 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "P(w)", "string4_curve", Literal4);
                                        break;
                                    case 5:
                                        forlit5 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "T(t)", "P(w)", "string5_curve", Literal5);
                                        break;
                                }
                            }
                        }
                        if (forlit1.Length > 0)
                            str1.Visible = true;
                        nodata1.Visible = false;
                        Literal1.Text = forlit1.Length > 0 ? forlit1 : "No Data for String 1";
                        if (forlit2.Length > 0)
                            str2.Visible = true;
                        nodata2.Visible = false;
                        Literal2.Text = forlit2.Length > 0 ? forlit2 : "No Data for String 2";
                        if (forlit3.Length > 0)
                            str3.Visible = true;
                        nodata3.Visible = false;
                        Literal3.Text = forlit3.Length > 0 ? forlit3 : "No Data for String 3";
                        if (forlit4.Length > 0)
                            str4.Visible = true;
                        nodata4.Visible = false;
                        Literal4.Text = forlit4.Length > 0 ? forlit4 : "No Data for String 4";
                        if (forlit5.Length > 0)
                            str5.Visible = true;
                        nodata5.Visible = false;
                        Literal5.Text = forlit5.Length > 0 ? forlit5 : "No Data for String 5";
                        break;





                    //CURRENT VS VOLTAGE
                    case "I - V":
                        get = $"select Stringid,DateTime,convert(varchar(5), DateTime,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                        dt2 = Utils.GetRequest(get);
                        list = new List<string> { "SCurrent", "Voltage" };
                        forlit1 = string.Empty;
                        forlit2 = string.Empty;
                        forlit3 = string.Empty;
                        forlit4 = string.Empty;
                        forlit5 = string.Empty;
                        for (int i = 1; i < 6; i++)
                        {
                            string _sqlWhere = "Stringid = " + i + "";
                            string _sqlOrder = "DateTime asc";
                            DataRow[] rows = dt2.Select(_sqlWhere, _sqlOrder);
                            if (rows.Length > 0)
                            {
                                DataTable _newDataTable = rows.CopyToDataTable();
                                switch (i)
                                {
                                    case 1:
                                        forlit1 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A)", "curve_chart", Literal1);
                                        break;
                                    case 2:
                                        forlit2 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A)", "string2_curve", Literal2);
                                        break;
                                    case 3:
                                        forlit3 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A)", "string3_curve", Literal3);
                                        break;
                                    case 4:
                                        forlit4 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A)", "string4_curve", Literal4);
                                        break;
                                    case 5:
                                        forlit5 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "I(A)", "string5_curve", Literal5);
                                        break;
                                }
                            }
                        }
                        if (forlit1.Length > 0)
                            str1.Visible = true;
                        nodata1.Visible = false;
                        Literal1.Text = forlit1.Length > 0 ? forlit1 : "No Data for String 1";
                        if (forlit2.Length > 0)
                            str2.Visible = true;
                        nodata2.Visible = false;
                        Literal2.Text = forlit2.Length > 0 ? forlit2 : "No Data for String 2";
                        if (forlit3.Length > 0)
                            str3.Visible = true;
                        nodata3.Visible = false;
                        Literal3.Text = forlit3.Length > 0 ? forlit3 : "No Data for String 3";
                        if (forlit4.Length > 0)
                            str4.Visible = true;
                        nodata4.Visible = false;
                        Literal4.Text = forlit4.Length > 0 ? forlit4 : "No Data for String 4";
                        if (forlit5.Length > 0)
                            str5.Visible = true;
                        nodata5.Visible = false;
                        Literal5.Text = forlit5.Length > 0 ? forlit5 : "No Data for String 5";
                        break;



                     //POWER VS VOLTAGE
                    case "P - V":
                        get = $"select Stringid,DateTime,convert(varchar(5), DateTime,21) as time,DateTime, Voltage,SCurrent as SCurrent, (Voltage*SCurrent) as Power from Temp_Voltage_1 where DateTime between '{fromdate}' and '{enddate}' order by Time asc ";
                        dt2 = Utils.GetRequest(get);
                        list = new List<string> { "Power", "Voltage" };
                        forlit1 = string.Empty;
                        forlit2 = string.Empty;
                        forlit3 = string.Empty;
                        forlit4 = string.Empty;
                        forlit5 = string.Empty;
                        for (int i = 1; i < 6; i++)
                        {
                            string _sqlWhere = "Stringid = " + i + "";
                            string _sqlOrder = "DateTime asc";
                            DataRow[] rows = dt2.Select(_sqlWhere, _sqlOrder);
                            if (rows.Length > 0)
                            {
                                DataTable _newDataTable = rows.CopyToDataTable();
                                switch (i)
                                {
                                    case 1:
                                        forlit1 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "P(w)", "curve_chart", Literal1);
                                        break;
                                    case 2:
                                        forlit2 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "P(w)", "string2_curve", Literal2);
                                        break;
                                    case 3:
                                        forlit3 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "P(w)", "string3_curve", Literal3);
                                        break;
                                    case 4:
                                        forlit4 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "P(w)", "string4_curve", Literal4);
                                        break;
                                    case 5:
                                        forlit5 = IVCurveGraph(_newDataTable, fromdate, enddate, "Old House String" + i, list, "V(v)", "P(w)", "string5_curve", Literal5);
                                        break;
                                }
                            }
                        }
                        if (forlit1.Length > 0)
                            str1.Visible = true;
                        nodata1.Visible = false;
                        Literal1.Text = forlit1.Length > 0 ? forlit1 : "No Data for String 1";  
                        if (forlit2.Length > 0)
                            str2.Visible = true;
                        nodata2.Visible = false;
                        Literal2.Text = forlit2.Length > 0 ? forlit2 : "No Data for String 2";
                        if (forlit3.Length > 0)
                            str3.Visible = true;
                        nodata3.Visible = false;
                        Literal3.Text = forlit3.Length > 0 ? forlit3 : "No Data for String 3";
                        if (forlit4.Length > 0)
                            str4.Visible = true;
                        nodata4.Visible = false;
                        Literal4.Text = forlit4.Length > 0 ? forlit4 : "No Data for String 4";
                        if (forlit5.Length > 0)
                            str5.Visible = true;
                        nodata5.Visible = false;
                        Literal5.Text = forlit5.Length > 0 ? forlit5 : "No Data for String 5";
                        break;






                    default:
                        GetStringBoth(dt, stringtxt);
                        break;
                }

                //CS LOGGER GRAPH 
                
                string condition5 = string.Empty;
                foreach (ListItem item in countryoforiginlistbx.Items)
                {
                    condition5 += item.Selected ? string.Format("{0},", item.Text+"("+item.Value+")") : string.Empty;
                    count = count + 1;
                }

                //string fromdate = startdatetxt.Value;
                //string enddate = enddatetxt.Value;
                //string get = $"select * from DL_Avg order by Timestamp desc ";
                string literaltext = string.Empty;
                string detcslogger = $"select * from DL_Avg where Timestamp between '{fromdate}' and '{enddate}' order by Timestamp asc ";
                DataTable csloggerdat = Utils.GetRequest(detcslogger);
                Repeater1.DataSource = csloggerdat;
                Repeater1.DataBind();
                if(csloggerdat.Rows.Count>0)
                {
                    literaltext = CSloggergraph(csloggerdat, fromdate, enddate, condition5);
                }           
                if (literaltext.Length > 0)
                    str6.Visible = true;
                //nodata1.Visible = false;
                    Literal6.Text = literaltext.Trim().Length > 0 ? literaltext : "No Data for CS Logger";
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                innertext.InnerHtml = ex.ToString();
            }
        }

        public DataTable getandBind(string query, DataTable dt)
        {
            dt = Utils.GetRequest(query);
            Repeater25.DataSource = dt;
            Repeater25.DataBind();
            return dt;
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
             legend: { position: 'top' },
                  colors: [ 'red', ],
           
             hAxis: {
          title: 'Date'
        },
           
           vAxis: {
          title: 'Population (millions)',
        },
                   width: '90%',
        height: '90%',
                  
                 chartArea: { width: '90%', height: '90%' },
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
             legend: { position: 'top' },
                  hAxis: {
          title: 'Date'
        },
           
           vAxis: {
          title: 'Population (millions)',
        },
                   width: '90%',
        height: '90%',
                 
                    lineWidth: 3,
                  backgroundColor: {fill: 'transparent'},
curveType: 'function',
          pointSize: 3,
                 
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  ['" + firstvs + "','"+seconfvstitle+"'");
               
                    
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

     

        private string CSloggergraph(DataTable dt, string from, string to, string graphtitle)
        {
            string returnvalue = string.Empty;
            StringBuilder strScript = new StringBuilder();

            try
            {
                //  dsChartData = GetSoilData(datefrom, dateto);


                strScript.Append(@"<script type='text/javascript'>  
                     google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

  
              function drawChart()  {  
var options = {
 title: '" + graphtitle + " from " + from + " to " + to + " ");
                strScript.Append(@"',
             curveType: 'none',
             legend: { position: 'right' },
                 
           hAxis: {
         title:'T(t)");

                strScript.Append(@"'

        },
 vAxis: {
          title: '" + graphtitle + "");
                strScript.Append(@"',
        },
                   width: '90%',
        height: '85%',
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
                    string selecteditem = item.Selected ? string.Format("'{0}',", item.Text) : String.Empty;
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
                        string selecteditem = item.Selected ? string.Format("{0}", item.Text) : String.Empty;
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

                returnvalue = strScript.ToString();
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
            return returnvalue;
        }

        private string IVCurveGraph(DataTable dt, string from, string to, string graphtitle, List<string> graphlist, string haxis, string yaxis, 
            string elementid, Literal literal)
        {
            string returnvalue = string.Empty;
            StringBuilder strScript = new StringBuilder();

            try
            {
                //  dsChartData = GetSoilData(datefrom, dateto);


                strScript.Append(@"<script type='text/javascript'>  
                     google.charts.load('current', {'packages':['corechart', 'line']});
      google.charts.setOnLoadCallback(drawChart);

  
              function drawChart()  {  
var options = {
 title: '" + graphtitle + " from " + from + " to " + to + " ");
                strScript.Append(@"',
             curveType: 'none',
             legend: { position: 'right' },
              
             hAxis: {
         title: '" + haxis + "");
                strScript.Append(@"'

        },
           
           vAxis: {
          title: '" + yaxis + ""); 
                strScript.Append(@"',
        },
                   width: '90%',
        height: '85%',
                     
       
                    lineWidth: 1,
                  backgroundColor: {fill: 'transparent'},
          pointSize: 1,
                 
                  animation: {
                      duration: 1000,
                      easing: 'in',
                  }
              };

                    var data = google.visualization.arrayToDataTable([
                  [");

                
                foreach (var item in graphlist)
                {
                    string selecteditem =  string.Format("'{0}',", item);
                    if (selecteditem == "'SCurrent',")
                    {
                        selecteditem = "'Current',";// "Current";
                        strScript.Append("" + selecteditem);
                    }
                    else
                    {
                        strScript.Append("" + selecteditem);
                    }
                    
                }
                strScript = strScript.Remove(strScript.Length - 1, 1);
                strScript.Append(@"],");

                // 'Voc','Isc','Radiation'],");

                foreach (DataRow row in dt.Rows)
                {
                    strScript.Append("[");
                   
                    foreach (var item in graphlist)
                    {
                        string selecteditem = string.Format("{0}", item);
                        if (!string.IsNullOrEmpty(selecteditem))
                        {

                            if(selecteditem == "DateTime")
                            {
                                //selecteditem = Convert.ToDateTime(selecteditem.ToString()).ToString("dd-MM-yyyy HH:mm");
                                strScript.Append("'" + Convert.ToDateTime(row["" + selecteditem + ""].ToString()).ToString("dd-MM HH:mm") + "',");
                            }
                            else
                            {
                                strScript.Append("" + row["" + selecteditem + ""] + ",");
                            }
                            
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


                strScript.Append("var chart = new google.visualization.LineChart(document.getElementById('"+ elementid + "'));" +
                    "chart.draw(data, options);}");
                strScript.Append(" </script>");
                returnvalue = strScript.ToString() ;
               // literal.Text = strScript.ToString();
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
            return returnvalue;
        }
    }
}