using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


public partial class Report : System.Web.UI.Page
{
    Conn con = new Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUserDropdown();
        }
    }

    public void LoadUserDropdown()
    {
          string sql = "Select UID, UserName FROM [dbo].[Child]";
          DataTable dt1 = new DataTable();
          bool isFound = con.GetData(sql, ref dt1);
          if (isFound)
          {
              for (int i = 0; i < dt1.Rows.Count; i++)
              {
                  ddl_items.Items.Add(new ListItem(dt1.Rows[i]["UserName"].ToString()));
              }
          }
          LoadSessionDropDown();
    }

    public void LoadSessionDropDown()
    {
        string username = ddl_items.SelectedValue;
        string sql =string.Format( "Select UID FROM [dbo].[Child] Where UserName='{0}'",username.ToString());
        DataTable dt1 = new DataTable();
        bool isFound = con.GetData(sql, ref dt1);
        if (isFound)
        {
            string sql1 = string.Format( "Select Session_ID FROM [dbo].[Student_log] Where child_ID='{0}'" , dt1.Rows[0][0]);
             DataTable dt2 = new DataTable();
              bool IsFound = con.GetData(sql1, ref dt2);
              if (IsFound)
              {
                  DropDownList1.Items.Clear();
                  for (int i = 0; i < dt2.Rows.Count; i++)
                  {
                      DropDownList1.Items.Add(new ListItem(dt2.Rows[i]["Session_ID"].ToString()));
                  }
              }
              else
              {
                  DropDownList1.Items.Clear();
                  lbltotalcorrect.Text = 0.ToString();
                  lbltimetaken.Text = 0.ToString() + "   Sec";
              }

        }
        LoadReport();
    }
    protected void ddl_items_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSessionDropDown();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadReport();
    }
    public void LoadReport()
    {
        string selectedId =( DropDownList1.SelectedValue);
        string sql = string.Format("Select sound_id_question_1_uid, sound_id_question_1_answer_correct, sound_id_question_1_total_time,sound_id_question_2_uid, sound_id_question_2_answer_correct, sound_id_question_2_total_time,sound_id_question_3_uid, sound_id_question_3_answer_correct, sound_id_question_3_total_time,sound_id_question_4_uid ,sound_id_question_4_answer_correct, sound_id_question_4_total_time,sound_id_question_5_uid, sound_id_question_5_answer_correct, sound_id_question_5_total_time,sound_id_question_6_uid, sound_id_question_6_answer_correct, sound_id_question_6_total_time,sound_id_question_7_uid, sound_id_question_7_answer_correct, sound_id_question_7_total_time, letter_id_question_1_uid, letter_id_question_1_answer_correct, letter_id_question_1_total_time,letter_id_question_2_uid, letter_id_question_2_answer_correct, letter_id_question_2_total_time,letter_id_question_3_uid, letter_id_question_3_answer_correct, letter_id_question_3_total_time,letter_id_question_4_uid, letter_id_question_4_answer_correct, letter_id_question_4_total_time,letter_id_question_5_uid, letter_id_question_5_answer_correct, letter_id_question_5_total_time,letter_id_question_6_uid, letter_id_question_6_answer_correct, letter_id_question_6_total_time,letter_id_question_7_uid, letter_id_question_7_answer_correct, letter_id_question_7_total_time, m_sentences_question_1_uid,  m_sentences_question_1_answer_correct, m_sentences_question_1_total_time, m_sentences_question_2_uid, m_sentences_question_2_answer_correct, m_sentences_question_2_total_time, m_sentences_question_3_uid,  m_sentences_question_3_answer_correct, m_sentences_question_3_total_time , m_sentences_question_4_uid,  m_sentences_question_4_answer_correct, m_sentences_question_4_total_time, m_sentences_question_5_uid, m_sentences_question_5_answer_correct, m_sentences_question_5_total_time, m_sentences_question_6_uid, m_sentences_question_6_answer_correct, m_sentences_question_6_total_time, m_sentences_question_7_uid, m_sentences_question_7_answer_correct, m_sentences_question_7_total_time, sentence_question_1_uid, sentence_question_1_answer_correct, sentence_question_1_total_time, sentence_question_2_uid, sentence_question_2_answer_correct, sentence_question_2_total_time, sentence_question_3_uid, sentence_question_3_answer_correct, sentence_question_3_total_time, sentence_question_4_uid,  sentence_question_4_answer_correct, sentence_question_4_total_time, sentence_question_5_uid,  sentence_question_5_answer_correct, sentence_question_5_total_time, sentence_question_6_uid,  sentence_question_6_answer_correct, sentence_question_6_total_time , sentence_question_7_uid,  sentence_question_7_answer_correct, sentence_question_7_total_time, word_scramble_question_1_uid, word_scramble_question_1_answer_correct, word_scramble_question_1_total_time, word_scramble_question_2_uid, word_scramble_question_2_answer_correct, word_scramble_question_2_total_time, word_scramble_question_3_uid,  word_scramble_question_3_answer_correct, word_scramble_question_3_total_time, word_scramble_question_4_uid,  word_scramble_question_4_answer_correct, word_scramble_question_4_total_time, word_scramble_question_5_uid,  word_scramble_question_5_answer_correct, word_scramble_question_5_total_time, word_scramble_question_6_uid, word_scramble_question_6_answer_correct, word_scramble_question_6_total_time, word_scramble_question_7_uid, word_scramble_question_7_answer_correct, word_scramble_question_7_total_time, mcq_decodable_words_audio_question_1_uid, mcq_decodable_words_audio_question_1_answer_correct, mcq_decodable_words_audio_question_1_total_time, mcq_decodable_words_audio_question_2_uid, mcq_decodable_words_audio_question_2_answer_correct, mcq_decodable_words_audio_question_2_total_time, mcq_decodable_words_audio_question_3_uid, mcq_decodable_words_audio_question_3_answer_correct, mcq_decodable_words_audio_question_3_total_time, mcq_decodable_words_audio_question_4_uid, mcq_decodable_words_audio_question_4_answer_correct, mcq_decodable_words_audio_question_4_total_time, mcq_decodable_words_audio_question_5_uid, mcq_decodable_words_audio_question_5_answer_correct, mcq_decodable_words_audio_question_5_total_time, mcq_decodable_words_audio_question_6_uid, mcq_decodable_words_audio_question_6_answer_correct, mcq_decodable_words_audio_question_6_total_time, mcq_decodable_words_audio_question_7_uid, mcq_decodable_words_audio_question_7_answer_correct, mcq_decodable_words_audio_question_7_total_time, mcq_nondecodable_words_audio_question_1_uid ,mcq_nondecodable_words_audio_question_1_answer_correct, mcq_nondecodable_words_audio_question_1_total_time, mcq_nondecodable_words_audio_question_2_uid, mcq_nondecodable_words_audio_question_2_answer_correct, mcq_nondecodable_words_audio_question_2_total_time, mcq_nondecodable_words_audio_question_3_uid, mcq_nondecodable_words_audio_question_3_answer_correct, mcq_nondecodable_words_audio_question_3_total_time, mcq_nondecodable_words_audio_question_4_uid, mcq_nondecodable_words_audio_question_4_answer_correct, mcq_nondecodable_words_audio_question_4_total_time, mcq_nondecodable_words_audio_question_5_uid, mcq_nondecodable_words_audio_question_5_answer_correct, mcq_nondecodable_words_audio_question_5_total_time, mcq_nondecodable_words_audio_question_6_uid, mcq_nondecodable_words_audio_question_6_answer_correct, mcq_nondecodable_words_audio_question_6_total_time, mcq_nondecodable_words_audio_question_7_uid, mcq_nondecodable_words_audio_question_7_answer_correct, mcq_nondecodable_words_audio_question_7_total_time from [dbo].[Student_log] WHERE Session_ID='{0}'", selectedId);
        DataTable dt1 = new DataTable();
        bool isFound = con.GetData(sql, ref dt1);
        if (isFound)
        {

            int totaltime = 0;
            int totalcorrect = 0;
            int Sectioncount = 1;
            int count = dt1.Columns.Count;
            int rowcount = 0;
            int quescount = 1;
            TableRow tr = new TableRow();
            tr.Attributes.Add("style", "border:1px soild black");
            for (int i = 0; i < count; i++)
            {
                if (rowcount == 0)
                {
                    tr = new TableRow();
                    tr.Attributes.Add("style", "border:1px soild black");
                    TableCell tc1 = new TableCell();

                    if (Sectioncount == 1)
                    {
                        string name1 = "sound_id_question : ";
                        tc1.Text =name1+ quescount.ToString();
                    }
                    else if (Sectioncount == 2)
                    {
                        string name2 = "letter_id_question : ";
                        tc1.Text = name2 + quescount.ToString();
                    }
                    else if (Sectioncount == 3)
                    {
                        string name3 = "m_sentences_question : ";

                        tc1.Text = name3 + quescount.ToString();
                    }
                    else if (Sectioncount == 4)
                    {
                        string name4 = "sentence_question : ";
                        tc1.Text = name4 + quescount.ToString();
                    }
                    else if (Sectioncount == 5)
                    {
                        string name5 = "word_scramble_question : ";
                        tc1.Text = name5 + quescount.ToString();
                    }
                    else if (Sectioncount == 6)
                    {
                        string name6 = "mcq_decodable_words_question : ";
                        tc1.Text = name6 + quescount.ToString();
                    }
                    else if (Sectioncount == 7)
                    {
                        string name6 = "mcq_nondecodable_words_question : ";
                        tc1.Text = name6 + quescount.ToString();
                    }
                    tr.Controls.Add(tc1);

                    TableCell tc3 = new TableCell();
                    tc3.Text = dt1.Rows[0][i].ToString();
                    tr.Controls.Add(tc3);
                    rowcount++;
                }
                else if (rowcount == 1)
                {
                    TableCell tc2 = new TableCell();

                    if (dt1.Rows[0][i].ToString() == "1")
                    {
                        tc2.Text = "Yes";
                        totalcorrect++;
                    }
                    else
                    {
                        tc2.Text = "No";
                    }
                   
                    tr.Controls.Add(tc2);
                    rowcount++;
                }
                else
                {
                    TableCell tc3 = new TableCell();
                    tc3.Text = dt1.Rows[0][i].ToString();
                    if (tc3.Text != "")
                    { 
                        float time=Convert.ToSingle( dt1.Rows[0][i]);
                        float sec=time/1000;
                        string Second = String.Format("{0:0.00}", sec);
                        tc3.Text = Second.ToString();
                       // tc3.Style.Add("text-align", "right");
                        totaltime = totaltime + Convert.ToInt32(dt1.Rows[0][i]);
                    }

                    tr.Controls.Add(tc3);
                    rowcount = 0;
                    quescount++;
                    tblbody.Controls.Add(tr);
                    if (quescount == 8)
                    {
                        quescount = 1;
                        Sectioncount++;
                    }
                }
            }

            lbltotalcorrect.Text = totalcorrect.ToString();
            float totalsec= Convert.ToSingle(totaltime);
            float Msec = totalsec / 1000;
            string TotalSecond= String.Format("{0:0.00}", Msec);
            lbltimetaken.Text = TotalSecond.ToString() + "   Sec";
        }
    }
}