using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class test_mcq_audio : System.Web.UI.Page
{
    Conn con = new Conn();
    public string m_FileName = "";
    public string[] radiovalue = new string[7];
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
                sql = string.Format("select UID, GE, option1, option2, option3, option4, option5, option6, option7, Correct_Answer, audioFileName FROM mcq_decodable_words_audio where GE>={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE", ge, userInfo.ChildId, questionType);
            }
            else
            {
                sql = string.Format("select UID, GE, option1, option2, option3, option4, option5, option6, option7, Correct_Answer, audioFileName FROM mcq_decodable_words_audio where GE<={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE DESC", ge, userInfo.ChildId, questionType);
            }
            DataTable dt = new DataTable();

            bool IsFound = con.GetData(sql, ref dt);
            if (IsFound)
            {
                start_time.Value = DateTime.Now.ToString();
                UID.Value = dt.Rows[0][0].ToString();

                radiovalue[0] = dt.Rows[0][2].ToString();
                radiovalue[1] = dt.Rows[0][3].ToString();
                radiovalue[2] = dt.Rows[0][4].ToString();
                radiovalue[3] = dt.Rows[0][5].ToString();
                radiovalue[4] = dt.Rows[0][6].ToString();
                radiovalue[5] = dt.Rows[0][7].ToString();
                radiovalue[6] = dt.Rows[0][8].ToString();
                m_FileName = dt.Rows[0][10].ToString();
               // lblCorrectAnswer.Text = dt.Rows[0][9].ToString();
            }
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

            string pageName = string.Format("~/UpdateQuestion.aspx?QuestionType={0}&QuestionId={1}&selectedAnswer={2}&timeTaken={3}", questionType, uid, selectedanswer, timeTaken);
            Response.Redirect(pageName);
        }
        catch { }
    }

   
}