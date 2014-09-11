using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class mcq_decodable_training1 : System.Web.UI.Page
{
    //Takes correct letter and randomly generates other options

    Conn con = new Conn();
    public string[] radiovalue = new string[7];

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadQuestion();
        }
    }

    private void LoadQuestion()
    {
        try
        {
            clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;
            if (userInfo == null)
                Response.Redirect("/login.aspx");

            radiovalue[0] = "Mon";
            radiovalue[1] = "Mod";
            radiovalue[2] = "Mam";
            radiovalue[3] = "Nun";
            radiovalue[4] = "Men";
            radiovalue[5] = "Maa";
            radiovalue[6] = "Mom";

           // lblCorrectAnswer.Text = "B";
            correct_answer.Value = "Mom";
        }
        catch { }
    }

  
}