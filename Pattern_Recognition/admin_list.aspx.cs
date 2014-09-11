using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class admin_list : System.Web.UI.Page
{
    Conn con=new Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = string.Format("Select UId,Ge,Sentences,Correct_Answer,Sound_FileName from [dbo].[word_scramble]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
    }

    protected void ddl_items_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_items.SelectedValue == "Word Scramble")
        {
            string sql = string.Format("Select UID,GE,Sentences,Correct_Answer,Sound_FileName from [dbo].[word_scramble]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
        if (ddl_items.SelectedValue == "Single Sentence Scramble")
        {
            string sql = string.Format("Select UID,GE,Sentences,Correct_Answer,Sound_FileName from [dbo].[Sentence]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
        if (ddl_items.SelectedValue == "Multiple Sentence Scramble")
        {
            string sql = string.Format("Select UID,GE,Sentences,Correct_Answer,Sound_FileName from [dbo].[m_sentences]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
        if (ddl_items.SelectedValue == "Letter ID")
        {
            string sql = string.Format("Select UID,GE,Letter_ID,Correct_Answer,Sound_FileName from [dbo].[Letter_ID]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
        if (ddl_items.SelectedValue == "Sound ID")
        {
            string sql = string.Format("Select UID,GE,Sound_ID,Correct_Answer,Sound_FileName from [dbo].[Sound_ID]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
        if (ddl_items.SelectedValue == "MCQ Decodable Words")
        {
            string sql = string.Format("SELECT  [UID],[GE],[option1],[option2],[option3],[option4],[option5] ,[option6],[option7] ,[Correct_Answer] ,[audioFileName] FROM [dbo].[mcq_decodable_words_audio]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
        if (ddl_items.SelectedValue == "MCQ Non-Decodable Words")
        {
            string sql = string.Format("SELECT  [UID],[GE],[option1],[option2],[option3],[option4],[option5] ,[option6],[option7] ,[Correct_Answer] ,[audioFileName] FROM [dbo].[mcq_nondecodable_words_audio]");
            DataTable dt1 = new DataTable();
            bool isFound = con.GetData(sql, ref dt1);
            if (isFound)
            {
                grid.DataSource = dt1;
                grid.DataBind();
            }
        }
    }
}