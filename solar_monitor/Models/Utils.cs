using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace solar_monitor.Models
{
    public class Utils
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SolarStr"].ConnectionString);
        public static DataTable GetRequest(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }

        public static void BindDropDownList(DropDownList ddl, string query, string text, string value /*string defaultText*/)
        {
            string conString = ConfigurationManager.ConnectionStrings["SolarStr"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    ddl.DataSource = cmd.ExecuteReader();
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();
                    con.Close();
                }
            }
            //    ddl.Items.Insert(0, new ListItem(defaultText, "0"));
        } 
        public static void BindListBox(ListBox ddl, string query, string text, string value /*string defaultText*/)
        {
            string conString = ConfigurationManager.ConnectionStrings["SolarStr"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    ddl.DataSource = cmd.ExecuteReader();
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();
                    con.Close();
                }
            }
            //    ddl.Items.Insert(0, new ListItem(defaultText, "0"));
        }

        public static string NonQeryRequest(string Query)
        {
            string Statcode = string.Empty;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SolarStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Statcode = "200";
            else
                Statcode = "No changes were made";
            conn.Close();

            return Statcode;
        }

    }
}