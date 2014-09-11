using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    Conn con = new Conn();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.getCon();
        String s = "select * from child where UserName=@user AND Password=@pass";
        con.cmd = new SqlCommand(s, con.con);
        con.cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = UserName.Text;
        con.cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = Password.Text;
        con.dr = con.cmd.ExecuteReader();
        if (con.dr.HasRows)
        {
            con.dr.Read();
            string sql =string.Format("INSERT INTO Student_Session (Child_ID, StartTime, EndTime) VALUES ({0}, GetDate(), NULL)", con.dr["UID"].ToString());
            int uid = con.GetIDFromInsert(sql);
            clsUserInfo userInfo = new clsUserInfo();
            userInfo.SessionId = uid;
            userInfo.ChildId = Convert.ToInt32(con.dr["UID"].ToString());
            userInfo.Grade = Convert.ToInt32(con.dr["Grade"].ToString());

            userInfo.UserName = UserName.Text;

            Session["UserInfo"] = userInfo;
            Session["username"] = UserName.Text;
            UserName.Text = "";
            Response.Redirect("default.aspx");
        }
        else
        {
            UserName.Text = "";
            lblMsg.Text = "Invalid Username or Password";
        }
        con.disCon();

    }


}