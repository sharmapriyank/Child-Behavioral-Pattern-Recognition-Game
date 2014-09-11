using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class UpdateQuestion : System.Web.UI.Page
{
    private Conn conn = new Conn();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("/login.aspx");
        }

        try
        {
            int quetionType = Convert.ToInt32(Request.QueryString["QuestionType"]);
            int questionId = Convert.ToInt32(Request.QueryString["QuestionId"]);
            string selectedAnswer = Request.QueryString["SelectedAnswer"].ToString();
            int timeTaken = Convert.ToInt32(Request.QueryString["timeTaken"].ToString());


            clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;
            string tableName = "";
            string pageName = "";
            if (userInfo != null)
            {
                switch (quetionType)
                {
                    case 1:
                        tableName = "Letter_ID";
                        break;
                    case 2:
                        tableName = "Sound_ID";
                        break;
                    case 3:
                        tableName = "mcq_decodable_words_audio";
                        break;
                    case 4:
                        tableName = "mcq_nondecodable_words_audio";
                        break;
                    case 5:
                        tableName = "word_scramble";
                        break;
                    case 6:
                        tableName = "sentence";
                        break;
                    case 7:
                        tableName = "m_sentences";

                        break;

                    //case 1:
                    //    tableName = "Sound_ID";
                    //    break;
                    //case 2:
                    //    tableName = "Letter_ID";
                    //    break;
                    //case 3:
                    //    tableName = "m_sentences";
                    //    break;
                    //case 4:
                    //    tableName = "sentence";
                    //    break;
                    //case 5:
                    //    tableName = "word_scramble";
                    //    break;
                    //case 6:
                    //    tableName = "mcq_decodable_words_audio";
                    //    break;
                    //case 7:
                    //    tableName = "mcq_nondecodable_words_audio";
                    //    break;
                    default:
                        break;
                }


                string sql = string.Format("SELECT UID, GE, Correct_Answer FROM {0} WHERE UID={1}", tableName, questionId);
                DataTable dt = new DataTable();
                int ge = 0;
                int IsCorrect = 0;
                bool IsFound = conn.GetData(sql, ref dt);
                if (IsFound)
                {
                    int positivejump = 0;
                    int negativejump = 0;
                    DataTable dt1 = new DataTable();
                    string sql1 = string.Format("SELECT Positivejump, NegativeJump FROM GradeJump WHERE Grade={0} and QuestionType={1}",userInfo.Grade,quetionType);
                    bool IsFound1 = conn.GetData(sql1, ref dt1);
                    if (IsFound1)
                    {
                        positivejump=Convert.ToInt32(dt1.Rows[0][0].ToString());
                        negativejump = Convert.ToInt32(dt1.Rows[0][1].ToString());
                    }
                    ge = Convert.ToInt32(dt.Rows[0][1].ToString());
                    string correctanswer = dt.Rows[0][2].ToString();

                    if (quetionType == 6 || quetionType == 7)
                    {
                        string x = string.Join(" ", Regex.Split(correctanswer, @"(?:\r\n|\n|\r)"));
                        string correctanswer1 = x.Replace(" ", "");
                        string selectedAnswer1 = selectedAnswer.Replace(" ", "");
                        if (correctanswer1 == selectedAnswer1)
                        {
                            IsCorrect = 1;
                            ge = ge + positivejump;
                        }
                        else
                        {
                            IsCorrect = 0;
                            ge = ge - negativejump;
                        }
                    }
                    else
                    {

                        if (correctanswer == selectedAnswer)
                        {
                            IsCorrect = 1;
                            ge = ge + positivejump;
                        }
                        else
                        {
                            IsCorrect = 0;
                            ge = ge - negativejump;
                        }
                    }
                }


                sql = "select currentQuestionType, currentQuestionNo, currentGE from Student_log where UID=" + userInfo.LogId;
                dt = new DataTable();

                int currentQuestionType = 0;
                int currentQuestionNo = 0;
                IsFound = conn.GetData(sql, ref dt);
                if (IsFound)
                {
                    currentQuestionNo = Convert.ToInt32(dt.Rows[0][1].ToString());
                    currentQuestionType = Convert.ToInt32(dt.Rows[0][0].ToString());
                }

                sql = string.Format("UPDATE Student_log SET  {0}_question_{1}_uid={2}, {0}_question_{1}_selected_answer='{3}', {0}_question_{1}_answer_correct={4}, {0}_question_{1}_total_time={5} WHERE UID={6}", tableName, currentQuestionNo, questionId, selectedAnswer, IsCorrect, timeTaken, userInfo.LogId);
                conn.ExecuteQuery(sql);

                currentQuestionNo++;
                if (currentQuestionNo > 7)
                {
                    currentQuestionNo = 1;
                    currentQuestionType++;
                    ge = GetGEFromType(currentQuestionType);
                }

            

                sql = string.Format("UPDATE Student_log SET currentQuestionType={0}, currentQuestionNo={1}, currentGE={2},last_answer_correct={4} WHERE UID={3}", currentQuestionType, currentQuestionNo, ge, userInfo.LogId, IsCorrect);
                conn.ExecuteQuery(sql);

           //----Check next question-------
                int lastAnswerCorrect = 0;
                int questionType = 0;

                string sql2 = string.Format("SELECT [UID], [currentQuestionType], [currentQuestionNo], [currentGE], [last_answer_correct] FROM [dbo].[Student_log] WHERE UID={0}", userInfo.LogId);
                DataTable dt2 = new DataTable();
                bool isFound = conn.GetData(sql2, ref dt2);
                if (isFound)
                {
                    lastAnswerCorrect = Convert.ToInt32(dt2.Rows[0][4].ToString().Trim());
                    ge = Convert.ToInt32(dt2.Rows[0][3].ToString().Trim());
                    questionType = Convert.ToInt32(dt2.Rows[0][1].ToString().Trim());
                }

                if (lastAnswerCorrect == 1)
                {
                    sql = string.Format("select GE, UID from {3} where GE>={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE", ge, userInfo.ChildId, questionType,tableName);
                }
                else
                {
                    sql = string.Format("select GE, UID from {3} where GE<={0} and uid NOT IN (Select QuestionId From Student_ViewLog Where Child_Id={1} AND QuestionType={2}) ORDER BY GE DESC", ge, userInfo.ChildId, questionType,tableName);
                }
                DataTable dt3 = new DataTable();

                bool IsFound2 = conn.GetData(sql, ref dt3);
                if (!IsFound2)
                {
                    currentQuestionNo = 1;
                    currentQuestionType++;
                    ge = GetGEFromType(currentQuestionType);
                    sql = string.Format("UPDATE Student_log SET currentQuestionType={0}, currentQuestionNo={1}, currentGE={2},last_answer_correct={4} WHERE UID={3}", currentQuestionType, currentQuestionNo, ge, userInfo.LogId, IsCorrect);
                    conn.ExecuteQuery(sql);
                    pageName = GetPageName(currentQuestionType);
                }
                else
                {
                    if (currentQuestionNo != 1)
                    {
                        switch (currentQuestionType)
                        {
                            case 1:
                                pageName = "letter_id.aspx";
                                break;
                            case 2:
                                pageName = "sound_id.aspx";
                                break;
                            case 3:
                                pageName = "test_mcq_audio.aspx";
                                break;
                            case 4:
                                pageName = "test_mcq_non-decodable.aspx";
                                break;
                            case 5:
                                pageName = "final_ls.aspx";
                                break;
                            case 6:
                                pageName = "Sentence.aspx";
                                break;
                            case 7:
                                pageName = "m_sentences.aspx";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        pageName = GetPageName(currentQuestionType);
                       
                    }
                }
                if (pageName == "")
                {
                    lblend.Text = "Good Work!   You have completed the Letters2Meaning game. ";
                }
                else
                {
                    Response.Redirect(pageName);
                }
            }

        }
        catch (Exception)
        {
        }
    }

    private string GetPageName(int questiontypeid)
    {
        string pageName = "";
        switch (questiontypeid)
        {
            case 1:
                pageName = "letter_id_training1.aspx";
                break;
            case 2:
                pageName = "sound_id_training1.aspx";
                break;
            case 3:
                pageName = "mcq_decodable_training1.aspx";
                break;
            case 4:
                pageName = "mcq_nondecodable_training1.aspx";
                break;
            case 5:
                pageName = "word_scramble_training1.aspx";
                break;
            case 6:
                pageName = "sentence_training1.aspx";
                break;
            case 7:
                pageName = "m_sentence_training1.aspx";
                break;
            default:
                break;
        }
        return pageName;
    }

    private int GetGEFromType(int quetionType)
    {
        int ge = 0;
        clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;
        string fieldName = "";
        if (userInfo != null)
        {
            switch (quetionType)
            {
                case 1:
                    fieldName = "Letter_GE";
                    break;
                case 2:
                    fieldName = "Sound_GE";
                    break;
                case 3:
                    fieldName = "mcq_decodable_words_audio_GE";
                    break;
                case 4:
                    fieldName = "mcq_nondecodable_words_audio_GE";
                    break;
                case 5:
                    fieldName = "word_scramble_GE";
                    break;
                case 6:
                    fieldName = "sentence_GE";
                    break;
                case 7:
                    fieldName = "m_sentences_GE";
                    break;

                default:
                    break;
            }

            string sql = string.Format("SELECT {0} FROM Difficulty_level_Grade WHERE Grade={1}", fieldName, userInfo.Grade);
            DataTable dt = new DataTable();

            bool IsFound = conn.GetData(sql, ref dt);
            if (IsFound)
            {
                ge = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
        }
        return ge;
    }
}