using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

public partial class admin_gradejump : System.Web.UI.Page
{
    public Conn conn = new Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        conn.getCon();
        if (!IsPostBack)
        {
          //string  sql = "select PositiveJump, NegativeJump from GradeJump where UID=1";
          //DataTable dt = new DataTable();
          //bool IsFound = conn.GetData(sql, ref dt);
          //if (IsFound)
          //{
          //    txtposjumb.Text =dt.Rows[0][0].ToString();
          //    txtnegjump.Text = dt.Rows[0][1].ToString();
          //}
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       try
       {
           int grade =Convert.ToInt32( txtgrade.Text);
           int questiontype = Convert.ToInt32(txtquestiontype.Text);
           int positivejump = Convert.ToInt32(txtposjumb.Text);
           int negativejump = Convert.ToInt32(txtnegjump.Text);

           string sql = string.Format("select Grade,QuestionType, PositiveJump, NegativeJump from GradeJump where Grade={0} and QuestionType={1}", grade, questiontype);
           DataTable dt = new DataTable();
           bool IsFound = conn.GetData(sql, ref dt);
           string sql1 = "";
           if (IsFound)
           {
               sql1 = string.Format("Update GradeJump set positivejump={2},negativejump={3} where Grade={0} and QuestionType={1}", grade, questiontype, positivejump, negativejump);
               conn.ExecuteQuery(sql1);
           }
           else
           {
               string s = "insert into GradeJump(Grade,QuestionType,PositiveJump,NegativeJump) values (@Grade,@QuestionType,@PositiveJump,@NegativeJump)";

               conn.cmd = new SqlCommand(s, conn.con);
               conn.cmd.Parameters.Add("@Grade", SqlDbType.VarChar).Value = grade;
               conn.cmd.Parameters.Add("@QuestionType", SqlDbType.VarChar).Value = questiontype;
               conn.cmd.Parameters.Add("@PositiveJump", SqlDbType.VarChar).Value = positivejump;
               conn.cmd.Parameters.Add("@NegativeJump", SqlDbType.VarChar).Value = negativejump;
               conn.cmd.ExecuteNonQuery();
           }
            Lblmsgn.Text = "";
            Lblmsgn.Visible = true;
            Lblmsgn.Text += "Record Updated Successfully";
        }
        catch { }
        finally
        {
            conn.disCon();
        }

    }


}