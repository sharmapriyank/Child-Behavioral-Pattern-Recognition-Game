using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class practice : System.Web.UI.Page
{
    Conn con = new Conn();
    public string m_FileName = "";
    public string[] radiovalue = new string[4];

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


            string sql = string.Format("SELECT [UID], [GE], [Sentence], [Correct_Answer], [option1],[option2],[option3],[option4],[Sound_FileName] FROM [dbo].[practice] WHERE UID NOT IN (SELECT practiceId from practiceresult where child_id={0})", userInfo.ChildId);
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                UID.Value = dt1.Rows[0][0].ToString();
                Corret_Answer.Value = dt1.Rows[0][3].ToString();
                // lblquestion.Text = dt1.Rows[0][2].ToString();
                radiovalue[0] = dt1.Rows[0][4].ToString();
                radiovalue[1] = dt1.Rows[0][5].ToString();
                radiovalue[2] = dt1.Rows[0][6].ToString();
                radiovalue[3] = dt1.Rows[0][7].ToString();
                m_FileName = dt1.Rows[0][8].ToString();
            }
            else
            {
                divcontrol.Visible = false;
                Label1.Text = "Good Work! You have completed the Test.";
            }
        }
        catch (Exception e)
        {
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int isansewrcorrect = 0;
        clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;
        string selectedanswer = selected_answer.Value;
        int childid = userInfo.ChildId;
        if (Corret_Answer.Value == selectedanswer)
        {
            isansewrcorrect = 1;
        }
        con.getCon();
        String s = "insert into practiceresult(Child_ID,Selected_Answer,IsAnswerCorrect,practiceId) values (@Child_ID,@Selected_Answer,@IsAnswerCorrect,@practiceId)";
        con.cmd = new SqlCommand(s, con.con);
        con.cmd.Parameters.Add("@Child_ID", SqlDbType.VarChar).Value = childid;
        con.cmd.Parameters.Add("@Selected_Answer", SqlDbType.VarChar).Value = selectedanswer;
        con.cmd.Parameters.Add("@IsAnswerCorrect", SqlDbType.VarChar).Value = isansewrcorrect;
        con.cmd.Parameters.Add("@practiceId", SqlDbType.VarChar).Value = UID.Value;
        con.cmd.ExecuteNonQuery();
        System.Threading.Thread.Sleep(1000);

        con.cmd.Dispose();
        con.disCon();
        Response.Redirect("~/practice.aspx");
    }

}