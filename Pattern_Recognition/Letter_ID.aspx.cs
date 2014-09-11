using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class Letter_ID : System.Web.UI.Page
{
    //Takes correct letter and randomly generates other options

    Conn con = new Conn();
    char[] str;
    public List<string> m_Question = new List<string>();
    public string m_FileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadQuestion();
        }
    }

    private string RandomString(char correctAnswer)
    {

        Random num = new Random();
        int randomadd = num.Next(0, 5);
        StringBuilder builder = new StringBuilder();
        char ch;
        int flag = 0;
        if (char.IsUpper(correctAnswer)) //fOR UPPER LETTERS    
        {
            while (flag != 5)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * num.NextDouble() + 65)));
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

        else   //for lower case letters
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
        return builder.ToString();
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
                sql = string.Format("select GE,Correct_Answer,Sound_FileName, UID from Letter_ID where GE>={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE", ge, userInfo.ChildId, questionType);
            }
            else
            {
                sql = string.Format("select GE,Correct_Answer,Sound_FileName, UID from Letter_ID where GE<={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE DESC", ge, userInfo.ChildId, questionType);
            }
            DataTable dt = new DataTable();

            bool IsFound = con.GetData(sql, ref dt);
            if (IsFound)
            {
                sound_id.Value = dt.Rows[0][0].ToString();
                start_time.Value = DateTime.Now.ToString();
                str = dt.Rows[0][1].ToString().ToCharArray();  // myReader["Correct_Answer"].ToString().ToCharArray();
                m_FileName = dt.Rows[0][2].ToString();
                //lblCorrectAnswer.Text = str[0].ToString();
                UID.Value = dt.Rows[0][3].ToString();
            }
        }
        catch (Exception e)
        {
        }
        try
        {
            char[] a = RandomString(str[0]).ToCharArray();
            m_Question = new List<string>();
            foreach (var item in a)
            {
                m_Question.Add(item.ToString());
            }
        }
        catch { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;

            DateTime starttime = Convert.ToDateTime(start_time.Value);
            DateTime endTime = DateTime.Now;
            TimeSpan span = endTime.Subtract(starttime);
            int timeTaken = (span.Seconds*1000) + (span.Minutes * 60)+span.Milliseconds;

            string soundId = sound_id.Value;
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