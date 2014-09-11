using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    private Conn conn = new Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnPrevTest.Visible = true;
            if (Session["username"] == null)
            {
                Response.Redirect("/login.aspx");
            }

            clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;
            if (userInfo != null)
            {
                string sql = string.Format("SELECT UID, [SessionState] FROM [Student_log] WHERE [Child_ID]={0} ORDER BY UID DESC", userInfo.ChildId);
                DataTable dt = new DataTable();

                bool IsFound = conn.GetData(sql, ref dt);
                if (IsFound)
                {
                    int state = Convert.ToInt32(dt.Rows[0][1].ToString());
                    if (state == 0)
                    {
                        btnPrevTest.Visible = true;
                        userInfo.LogId = Convert.ToInt32(dt.Rows[0][0].ToString());
                    }
                }
                else
                {
                    btnPrevTest.Visible = false;
                }
            }
        }
    }

    protected void btnPrevTest_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/sound_id.aspx");
    }
    protected void btnPracticeTest_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/practice.aspx");
    }

    protected void btnNewTest_Click(object sender, EventArgs e)
    {
        clsUserInfo userInfo = Session["UserInfo"] as clsUserInfo;
        if (userInfo != null)
        {
            string sql1 = "select top 1 session_id from student_log  order by Session_ID desc ";
            DataTable dt1 = new DataTable();
            string sql = "SELECT Sound_GE FROM  [Difficulty_level_Grade] Where Grade='" + userInfo.Grade + "'";
            DataTable dt = new DataTable();
            bool IsFound1 = conn.GetData(sql1, ref dt1);
            if (IsFound1)
            {
                try
                {
                    int sessionId = Convert.ToInt32(dt1.Rows[0][0].ToString());
                    if (userInfo.SessionId > sessionId)
                    {
                        sql1 = " delete from student_viewlog";
                      conn.ExecuteQuery(sql1);
                    }
                }
                catch { }


            }

            int ge = 0;
            bool IsFound = conn.GetData(sql, ref dt);
            if (IsFound)
            {
                ge =  Convert.ToInt32(dt.Rows[0][0].ToString());
                sql = string.Format("INSERT INTO Student_log (Session_ID, Child_ID, TestStartTime, SessionState, currentQuestionType, currentQuestionNo, currentGE, last_answer_correct) VALUES({0},{1},GETDATE(),0, {2}, {3}, {4}, 1)", userInfo.SessionId, userInfo.ChildId, 1, 1, ge);
                int logId = conn.GetIDFromInsert(sql);
                userInfo.LogId = logId;
                Response.Redirect("~/letter_id_training1.aspx");
            }
        }
    }
}