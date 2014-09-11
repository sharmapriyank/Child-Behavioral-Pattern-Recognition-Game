using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class letter_id_training2 : System.Web.UI.Page
{
    //Takes correct letter and randomly generates other options

    Conn con = new Conn();
    public string[] radiovalue = new string[5];
    public string m_filename = "";
    public string Iscorrect = "";
    public string Iscorrectcount = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Iscorrect = Request.QueryString["Iscorrect"].ToString();
            Iscorrectcount = Request.QueryString["Iscorrectcount"].ToString();
            if (Iscorrect == "0")
            {
                m_filename = "LID_T5.wav";
            }
            else
            {
                m_filename = "LID_T2.wav";
            }
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

            radiovalue[0] = "P";
            radiovalue[1] = "Q";
            radiovalue[2] = "R";
            radiovalue[3] = "S";
            radiovalue[4] = "T";

            //lblCorrectAnswer.Text = "S";
            correct_answer.Value = "S";
        }
        catch { }
    }


}