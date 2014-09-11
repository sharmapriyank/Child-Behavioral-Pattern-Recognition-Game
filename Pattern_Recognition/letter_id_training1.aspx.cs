using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class letter_id_training1 : System.Web.UI.Page
{
    //Takes correct letter and randomly generates other options

    Conn con = new Conn();
    public string[] radiovalue = new string[5];

    

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

            radiovalue[0] = "A";
            radiovalue[1] = "B";
            radiovalue[2] = "C";
            radiovalue[3] = "D";
            radiovalue[4] = "E";

           // lblCorrectAnswer.Text = "B";
            correct_answer.Value = "C";
        }
        catch { }
    }

  
}