using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
//using System.Drawing.Graphics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Threading;

public partial class word_scramble_training2 : System.Web.UI.Page
{
    public string m_filename = "";
    public string Iscorrect = "";
    public string Iscorrectcount = "";
    public string anslength = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Iscorrect = Request.QueryString["Iscorrect"].ToString();
            Iscorrectcount = Request.QueryString["Iscorrectcount"].ToString();
            if (Iscorrect == "0")
            {
                m_filename = "L2W_T5.wav";
            }
            else
            {
                m_filename = "L2W_T2.wav";
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

            char[] letterArray = new char[3];

            letterArray[0] = 's';
            letterArray[1] = 'n';
            letterArray[2] = 'u';
            

            string answer = "sun";
            LoadEmptyBox(answer);
            correct_answer.Value = answer;
            answerlength.Value = answer.Length.ToString();
            anslength = answer.Length * 50 + "px";
            int n = letterArray.Length;
            Label[] Label = new Label[n];

            for (int i = 0; i < letterArray.Length; i++)
            {
                Label[i] = new Label();
                Label[i].Text = "" + letterArray[i];
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "ui-state-default");
                li.Attributes.Add("id", "LI" + i);

                drop.Controls.Add(li);
                li.Controls.Add(Label[i]);
            }

        }
        catch (Exception e)
        {
        }

    }
    protected void LoadEmptyBox(string answer)
    {
        for (int i = 0; i < answer.Length; i++)
        {
            
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("class", "ui-state-default emptyspace");
            li.Attributes.Add("id", "Empty" + i);
            sortable.Controls.Add(li);
        }
    }



}