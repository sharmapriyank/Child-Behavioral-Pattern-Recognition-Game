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

public partial class m_sentences : System.Web.UI.Page
{
    Conn con = new Conn();
    public string m_FileName = "";

    protected void LoadSentence(string sentense)
    {
        String[] sentence_separator = splitText(sentense);
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
            // Here you can modify the value of the label which is at labels[i]
        }

    }


    protected string[] splitText(string sentense)
    {
        char[] delimiters = new[] { '~' };  
        string[] sentence_separator = sentense.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        return sentence_separator;
        //ms_bt1.Text= sentence_separator[0];
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
                sql = string.Format("select UID, GE, Sentences, Correct_Answer,Sound_FileName FROM m_sentences where GE>={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE", ge, userInfo.ChildId, questionType);
            }
            else
            {
                sql = string.Format("select UID, GE, Sentences, Correct_Answer,Sound_FileName FROM m_sentences  where GE<={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE DESC", ge, userInfo.ChildId, questionType);
            }
            DataTable dt = new DataTable();

            string sentense = "";

            bool IsFound = con.GetData(sql, ref dt);
            if (IsFound)
            {
                UID.Value = dt.Rows[0][0].ToString();
                sentense = dt.Rows[0][2].ToString();
                start_time.Value = DateTime.Now.ToString();
                m_FileName = dt.Rows[0][4].ToString();
            }

            LoadSentence(sentense);

        }
        catch (Exception e)
        {
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