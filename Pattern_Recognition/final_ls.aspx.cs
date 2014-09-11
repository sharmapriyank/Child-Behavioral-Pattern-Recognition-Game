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

public partial class final_ls : System.Web.UI.Page
{
    Conn con = new Conn();
    public Int32 labeln = 6;
    int testVar;
    static int x = 0;
    static String[] scrambleStrings = new String[10];
    int n = 0;
    int m = 0;
    int count = 0; 
    int connFlag= 0, lblFlag=0;
    Char[] letterArray = new Char[20];
    Char[] letterArray1 = new Char[20];
    public string m_FileName = "";
    public string anslength = "0";

    protected void LoadWord(string word)
    {
        letterArray = word.ToCharArray();
        n = letterArray.Length;
        Label[] Label = new Label[n];

        for (int i = 0; i < letterArray.Length; i++)
        {
            Label[i] = new Label();
            Label[i].Text = ""+letterArray[i];
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("class", "ui-state-default");
            li.Attributes.Add("id", "LI" + i);

            drop.Controls.Add(li);
            li.Controls.Add(Label[i]);
            // Here you can modify the value of the label which is at labels[i]
        }

    }


    private void LoadQuestion()
    {
        try
        {
            clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;
            if (userInfo == null)
                Response.Redirect("/login.aspx");

            int ge = 0;
            int lastAnswerCorrect = 0;
            int questionType = 0;

            string sql = string.Format("SELECT [UID], [currentQuestionType], [currentQuestionNo], [currentGE], [last_answer_correct] FROM [dbo].[Student_log] WHERE UID={0}", userInfo.LogId);
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                lastAnswerCorrect = Convert.ToInt32(dt1.Rows[0][4].ToString().Trim());
                ge = Convert.ToInt32(dt1.Rows[0][3].ToString().Trim());
                questionType = Convert.ToInt32(dt1.Rows[0][1].ToString().Trim());
            }

            QuestionType.Value = questionType.ToString();

            if (lastAnswerCorrect == 1)
            {
                sql = string.Format("select UID, GE, Sentences, Correct_Answer,Sound_FileName FROM word_scramble where GE>={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE", ge, userInfo.ChildId, questionType);
            }
            else
            {
                sql = string.Format("select UID, GE, Sentences, Correct_Answer,Sound_FileName FROM word_scramble where GE<={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE DESC", ge, userInfo.ChildId, questionType);
            }
            DataTable dt = new DataTable();
            string word = "";
            bool IsFound = con.GetData(sql, ref dt);
            if (IsFound)
            {
                word = dt.Rows[0][2].ToString();
                start_time.Value = DateTime.Now.ToString();
                UID.Value = dt.Rows[0][0].ToString();
                m_FileName = dt.Rows[0][4].ToString();
                string answer=dt.Rows[0][3].ToString();
                answerlength.Value = answer.Length.ToString();
                anslength = answer.Length * 50 + "px";
                LoadEmptyBox(answer);
            }
            LoadWord(word);
        }
        catch (Exception e)
        {
        }

    }

    protected void LoadEmptyBox(string answer)
    {
        letterArray = answer.ToCharArray();
        n = letterArray.Length;
        Label[] Label = new Label[n];

        for (int i = 0; i < letterArray.Length; i++)
        {
            Label[i] = new Label();
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("class", "ui-state-default emptyspace");
            li.Attributes.Add("id", "Empty" + i);

            sortable.Controls.Add(li);
            li.Controls.Add(Label[i]);
            // Here you can modify the value of the label which is at labels[i]
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadQuestion();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;

            DateTime starttime = Convert.ToDateTime(start_time.Value);
            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(starttime);
            int timeTaken = (span.Seconds * 1000) + (span.Minutes * 60) + span.Milliseconds;

            string selectedanswer = selected_answer.Value;
            int uid = Convert.ToInt32(UID.Value);
            int questionType = Convert.ToInt32(QuestionType.Value);
            Utils.UpdateViewLog(userInfo.ChildId, questionType, uid);

            string pageName = string.Format("/UpdateQuestion.aspx?QuestionType={0}&QuestionId={1}&selectedAnswer={2}&timeTaken={3}", questionType, uid, selectedanswer, timeTaken);
            Response.Redirect(pageName);
        }
        catch { }
    }

}