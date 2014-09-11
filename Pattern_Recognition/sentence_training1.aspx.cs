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

public partial class sentence_training1 : System.Web.UI.Page
{
    //static string end_punctuation, input;
    Conn con = new Conn();
   
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

            string[] letterArray = new string[3];
             letterArray[0]="am";
             letterArray[1]="happy";
             letterArray[2]="I";
             correct_answer.Value = "I am happy";


             int  n = letterArray.Length;
            Label[] Label = new Label[n];

            for (int i = 0; i < letterArray.Length; i++)
            {

                if (letterArray[i] != "")
                {
                    Label[i] = new Label();
                    Label[i].Text = "" + letterArray[i];
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "ui-state-default");
                    li.Attributes.Add("id", "LI" + i);

                    sortable.Controls.Add(li);
                    li.Controls.Add(Label[i]);
                }
                // Here you can modify the value of the label which is at labels[i]
            }
          
        }
        catch (Exception e)
        {
        }

    }
}
