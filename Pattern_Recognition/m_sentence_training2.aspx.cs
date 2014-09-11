using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class m_sentence_training2 : System.Web.UI.Page
{
    Conn con = new Conn();
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
                m_filename = "S2P_T5.wav";
            }
            else
            {
                m_filename = "S2P_T2.wav";
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

            string[] sentence_separator = new string[3];
            sentence_separator[0] = "I like Rat.";
            sentence_separator[1] = "I will eat Rat.";
            sentence_separator[2] = "I am Cat.";

            correct_answer.Value = "I am Cat.I like Rat.I will eat Rat.";
            int n = sentence_separator.Length;
            Label[] Label = new Label[n];
            for (int i = 0; i < sentence_separator.Length; i++)
            {
                Label[i] = new Label();
                Label[i].Text = sentence_separator[i];
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "ui-state-default");
                li.Attributes.Add("id", "LI" + i);
                sortable.Controls.Add(li);
                li.Controls.Add(Label[i]);
            }
        }
        catch { }

    }

}