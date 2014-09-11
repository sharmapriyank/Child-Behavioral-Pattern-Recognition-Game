using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

public partial class Sound_ID : System.Web.UI.Page
{
    char[] correctItems = { 'D', 'R' };
    char[] a = new char[5];
    char flagx;
    //for training item no
    int testVar = 0;
    Conn con = new Conn();
    char[] str;
     string selectedText;
    // private static Random random = new Random((int)DateTime.Now.Ticks);
    private string RandomString(char correctAnswer)
    {
        Random num = new Random();
        int randomadd = num.Next(0, 5);
        StringBuilder builder = new StringBuilder();
        char ch;
        int flag = 0;
        if (char.IsUpper(correctAnswer))
        {
            while (flag != 5)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * num.NextDouble() + 65)));
                if (flag == randomadd)
                {
                    builder.Append(correctAnswer);
                  //  flagx = ch;
                   
                    flag++;
                }

                else if (ch != correctAnswer)
                {
                    builder.Append(ch);
                    flag++;
                }
            }
        }

        else
        {
            while (flag != 5)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * num.NextDouble() + 97)));
                if (flag == randomadd)
                {
                    builder.Append(correctAnswer);
                    flag++;
                }

                else if (ch != correctAnswer)
                {
                    builder.Append(ch);
                    flag++;
                }
            }


        }
        /*  Random num = new Random();
          builder.Append(correctAnswer);
          string temp = builder.ToString();
      again:
          // Create new string from the reordered char array
          string rand = new string(temp.ToCharArray().
           OrderBy(sx => (num.Next(2) % 2) == 0).ToArray());
          if (rand == temp)
              goto again;

          */

        return builder.ToString();
        
       


    }


   

    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {

            if (Session["clickcount"] == null)
            {
                Session["clickcount"] = 0;
                ViewState["countx"] = 0;

            }
            testVar = (int)Session["clickcount"];

            if (testVar == 1)
            {
                hidValue.Value = "1";

            }
            else if (testVar == 2)
            {
                hidValue.Value = "2";
              
            }

            ViewState["countx"] = ViewState["countx"];
            a = RandomString(correctItems[0]).ToCharArray();
            RadioButton0.Text = "" + a[0];
            RadioButton1.Text = "" + a[1];
            RadioButton2.Text = "" + a[2];
            RadioButton3.Text = "" + a[3];
            RadioButton4.Text = "" + a[4];
            
            //   Response.Write(@"<script language='javascript'>alert('" + a[flagx] + "')</script>");

            //  Response.Write(@"<script language='javascript'>alert('" + flagx + "')</script>");

        }

        if (ViewState["viewstate"] != null)
        {
            flagx= (char)ViewState["viewstate"];
        }
        else
        {
            try
            {
                ViewState["viewstate"] = correctItems[(int)ViewState["countx"]];
            }
            catch { }
        }
   


    }


    protected void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (((RadioButton)sender).Checked)
            selectedText = ((RadioButton)sender).Text;
        Response.Write(@"<script language='javascript'>alert('Update is successful."+selectedText+"')</script>");
    }




    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void Button1_Click1(object sender, EventArgs e)
    {
       // Response.Write(@"<script language='javascript'>alert('Update is successful.')</script>");
        string sx = "" + flagx;

        /*  if (RadioButton0.Checked == true)
          {

              if (RadioButton0.Text == sx)
              {
                  // Response.Write(@"<script language='javascript'>alert('goo')</script>");
                  Response.Redirect("home.aspx");
              }
              else Response.Redirect("Login.aspx");
          }

          */
        if ((RadioButton0.Checked == true && RadioButton0.Text == sx) || (RadioButton2.Text == sx && RadioButton2.Checked == true) || (RadioButton3.Text == sx && RadioButton3.Checked == true) || (RadioButton4.Text == sx && RadioButton4.Checked == true) || (RadioButton1.Text == sx && RadioButton1.Checked == true))
        {

            ViewState["countx"] = (int)ViewState["countx"] + 1;
        }

        else Response.Redirect("admin_add_data1.aspx");
        ViewState["viewstate"] = null;
        //Thread.Sleep(1000);
        Session["clickcount"] = (int)Session["clickcount"] + 1;
        // Cache["clickscount"] = (int)Cache["clickscount"] + 1;
       
       

        
    }


    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {

    }
}