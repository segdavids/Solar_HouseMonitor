using solar_monitor.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace solar_monitor.main
{
    public partial class _default : System.Web.UI.Page
    {
        string ReturnUrl;
        SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["SolarStr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID"] = null;
            Session["LastName"] = null;
            ReturnUrl = Convert.ToString(Request.QueryString["url"]);
            if (ReturnUrl == null)
            {
                if (Session["URLRedirect"] == null)
                {
                    ReturnUrl = "/main/summary";
                }
                else
                {
                    ReturnUrl = Session["URLRedirect"].ToString();
                    Session["URLRedirect"] = null;

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            alert.Visible = false;
            string getuser = "select * from users where username='" + emailtxt.Value.ToString().Trim() + "' and password='" + userpasswordtxt.Value.ToString().Trim() + "'";
            DataTable dt = Utils.GetRequest(getuser);
            if (dt.Rows.Count == 0)
            {
                alert.Visible = true;
                innertext.InnerText = "The email or password you entered is invalid";
            }
            else if (dt.Rows.Count == 1)
            {
                dt.Dispose();
                string getuserdetails = "select first_name,last_name,(case when last_login is null then CAST('00:00:00' AS datetime) else last_login end) as lastlogin,username,email,(case when user_role is null then '0' else user_role end)  as userrole,(case when phone is null then 'No Number Found' else phone end)  as phone, id from users where email='" + emailtxt.Value.ToString() + "'";
                dt = Utils.GetRequest(getuserdetails);
                string status = "success";
                string act = "Login_Dashboard_Session_01ABB_";
                string name = dt.Rows[0]["first_name"].ToString();
                string lname = dt.Rows[0]["last_name"].ToString();
                string lastlog = dt.Rows[0]["lastlogin"].ToString();
                string username1 = dt.Rows[0]["username"].ToString();
                string emails = dt.Rows[0]["email"].ToString();
                string role = dt.Rows[0]["userrole"].ToString();
                string phone = dt.Rows[0]["phone"].ToString();
                string id = dt.Rows[0]["id"].ToString();
                string FundName = name.ToString();
                string LName = lname.ToString();
                string phonenumber = phone.ToString();
                string lastlogs = lastlog.ToString();
                //UPDATE LASTLOGIN
                //string updateuserlogin = "Update users set last_login='" + DateTime.Now + "' WHERE email='" + emailtxt.Value.ToString() + "'";
                //Tools.NonQeryRequest(updateuserlogin);
                ///USER ACTIVITY
                /////
                //sc.Open();
                //SqlCommand insertactivity = new SqlCommand("insert into login_activites (username,first_name,last_name,email,date_of_login,activity,status) values('" + emailtxt + "','" + name + "','" + lname + "','" + emails + "','" + date + "','" + act + emailtxt + "','" + status + "')", sc);
                //insertactivity.Parameters.AddWithValue("username", username1);
                //insertactivity.Parameters.AddWithValue("first_name", name);
                //insertactivity.Parameters.AddWithValue("last_name", lname);
                //insertactivity.Parameters.AddWithValue("email", emails);
                //insertactivity.Parameters.AddWithValue("date_of_login", date);
                //insertactivity.Parameters.AddWithValue("activity", act);
                //insertactivity.Parameters.AddWithValue("status", status);
                //insertactivity.ExecuteNonQuery();
                if (role == "" || role == "0")
                {

                    alert.Visible = true;


                    alert.Style.Add("background-color", "#FF0000");
                    alert.InnerText = "Dear " + name + ", " + lname + ". No role/rights have been assigned to you. Kindly contact your Admin to assign a role to you.";

                }
                if (role == "Admin")
                {
                    Session["ID"] = id;
                    Session["FirstName"] = FundName;
                    Session["LastName"] = lname;
                    Session["Email"] = emailtxt.Value.ToString();
                    Session["lastlogin"] = lastlogs;
                    //string activity = "Successful Login";
                    //DateTime now = DateTime.Now;
                    //SqlCommand cmd3 = new SqlCommand("insert into user_activity (user_id,activity,ActivityType,date_time) values(@user,@activity,@ActivityType,@datetime)", sc);
                    //cmd3.Parameters.AddWithValue("@user", emailtxt.Value.ToString());
                    //cmd3.Parameters.AddWithValue("@activity", activity);
                    //cmd3.Parameters.AddWithValue("@ActivityType", "Login");
                    //cmd3.Parameters.AddWithValue("@datetime", now);
                    //cmd3.ExecuteNonQuery();
                    //sc.Close();
                    ClientScript.RegisterStartupScript(GetType(), "JavaScript", " setTimeout(function ref() { location.href = '" + ReturnUrl + "'; }, 500);", true);
                    Response.AddHeader("REFRESH", "0;URL=" + ReturnUrl + "");
                    //Response.Redirect("~/home/");
                }
                else
                {
                    alert.Visible = true;

                    //string activity = "Failed Login";
                    //DateTime now = DateTime.Now;
                    //SqlCommand cmd3 = new SqlCommand("insert into user_activity (user_id,activity,ActivityType,date_time) values(@user,@activity,@ActivityType,@datetime)", sc);
                    //cmd3.Parameters.AddWithValue("@user", emailtxt.Value.ToString());
                    //cmd3.Parameters.AddWithValue("@activity", activity);
                    //cmd3.Parameters.AddWithValue("@ActivityType", "Failed Login");
                    //cmd3.Parameters.AddWithValue("@datetime", now);
                    //cmd3.ExecuteNonQuery();
                    //sc.Close();
                    alert.Style.Add("background-color", "#FF0000");
                    alert.InnerText = "Dear " + name + ", " + lname + ". The role/rights assigned to you is INVALID. Kindly contact your Administrator.";

                }
              //  sc.Close();
            }
        }
    }
}