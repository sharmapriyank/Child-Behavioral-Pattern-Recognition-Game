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

public partial class practice : System.Web.UI.Page
{
    Conn con = new Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.getCon();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string FilePath = "~\\audio\\Sound_ID\\";
            string filename = "";
            //To check whether file is selected or not to uplaod
            if (fileupload1.HasFile)
            {
                try
                {
                    string FileExt = System.IO.Path.GetExtension(fileupload1.PostedFile.FileName);
                    filename = Path.GetFileName(fileupload1.FileName);
                    string path = Server.MapPath(FilePath) + filename;
                    fileupload1.SaveAs(path);
                }
                catch (Exception ex)
                {
                }
            }


            String s;
            s = "insert into practice(GE,Correct_Answer,Sentence,option1,option2,option3,option4,Sound_FileName) values (@GE,@Correct_Answer,@Sentence,@option1,@option2,@option3,@option4,@Sound_FileName)";
            con.cmd = new SqlCommand(s, con.con);
            con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
            con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_op_correctanswer.Text;
            con.cmd.Parameters.Add("@Sentence", SqlDbType.VarChar).Value = tb_data.Text;
            con.cmd.Parameters.Add("@option1", SqlDbType.VarChar).Value = tb_op1.Text;
            con.cmd.Parameters.Add("@option2", SqlDbType.VarChar).Value = tb_op2.Text;
            con.cmd.Parameters.Add("@option3", SqlDbType.VarChar).Value = tb_op3.Text;
            con.cmd.Parameters.Add("@option4", SqlDbType.VarChar).Value = tb_op4.Text;
            con.cmd.Parameters.Add("@Sound_FileName", SqlDbType.VarChar).Value = filename;
            con.cmd.ExecuteNonQuery();
            Lblmsgn.Text = "";
            System.Threading.Thread.Sleep(1000);
            Lblmsgn.Visible = true;
            Lblmsgn.Text += "Record Added Successfully";
        }
        catch { }
        finally
        {
            con.cmd.Dispose();
            con.disCon();
        }
   
    }

}