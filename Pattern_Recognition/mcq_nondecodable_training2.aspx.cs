using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class mcq_nondecodable_training2 : System.Web.UI.Page
{
    //Takes correct letter and randomly generates other options

    Conn con = new Conn();
    public string[] radiovalue = new string[7];
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
                m_filename = "WR_T5.wav";
            }
            else
            {
                m_filename = "WR_T2.wav";
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
            radiovalue[0] = "Pird";
            radiovalue[1] = "Durb";
            radiovalue[2] = "Bird";
            radiovalue[3] = "Lerd";
            radiovalue[4] = "Brid";
            radiovalue[5] = "Bidd";
            radiovalue[6] = "Fly";

            //lblCorrectAnswer.Text = "T";
            correct_answer.Value = "Bird";
        }
        catch { }
    }


}