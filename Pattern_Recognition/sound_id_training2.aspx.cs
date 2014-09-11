using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class sound_id_training2 : System.Web.UI.Page
{
    //Takes correct letter and randomly generates other options

    Conn con = new Conn();
    public string[] radiovalue = new string[5];

    public string m_filename = "";
    public string Iscorrect="";
    public string Iscorrectcount = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Iscorrect = Request.QueryString["Iscorrect"].ToString();
            Iscorrectcount = Request.QueryString["Iscorrectcount"].ToString();
            if (Iscorrect == "0")
            {
                m_filename = "SID_T5.wav";
            }
            else
            {
                m_filename = "SID_T2.wav";
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

            radiovalue[0] = "M";
            radiovalue[1] = "N";
            radiovalue[2] = "R";
            radiovalue[3] = "O";
            radiovalue[4] = "P";


            //lblCorrectAnswer.Text = "R";
            correct_answer.Value = "R";
        }
        catch { }
    }


}