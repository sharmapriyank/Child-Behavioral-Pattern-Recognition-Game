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


public partial class admin_add_data1 : System.Web.UI.Page
{
    Conn con = new Conn();

    protected void Page_Load(object sender, EventArgs e)
    {
            con.getCon();
            Lblmsgn.Text = "";
            if (ddl_items.SelectedValue == "MCQ Decodable Words" ||ddl_items.SelectedValue == "MCQ Non-Decodable Words" )
            {
                divoption.Visible = true;
            }
            else
            {
                divoption.Visible = false;
            }
            if (ddl_items.SelectedValue == "Word Scramble" )
            {
                divextra.Visible = true;
            }
            else
            {
                divextra.Visible = false;
            }
           
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
            String s, sqldata;
            Random num = new Random();
            
            if (ddl_items.SelectedValue == "Multiple Sentence Scramble")
            {
                s = "insert into m_sentences(GE,Sentences,Correct_Answer,Sound_FileName) values (@GE,@Sentence,@Correct_Answer,@Sound_FileName)";
               // s = "insert into m_sentences(Sentences,original_sentence,Priority) values (@Sentence,@original_sentence,@priority)";

              //  char[] delimiters = new[] { '?', ';', '.','!' };  // List of your delimiters
                char[] delimiters = new[] { '\n' };  // List of your delimiters
                string[] splittedArray = tb_data.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
               // string[] splittedArray = Regex.Split(tb_data.Text, @"(?<=[.?;!])"); 
                //string[] splittedArray = Regex.Split(tb_data.Text, @"(?<=[\n    ])"); 
                List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
                // Add all strings from array
                // Add new random int each time
                foreach (string sx2 in splittedArray)
                {
                    list.Add(new KeyValuePair<int, string>(num.Next(), sx2));
                }
                // Sort the list by the random number
                var sorted = from item in list
                             orderby item.Key
                             select item;
                // Allocate new string array
                string[] result = new string[splittedArray.Length];
                // Copy values to array
                int index = 0;
                foreach (KeyValuePair<int, string> pair in sorted)
                {
                    result[index] = pair.Value;
                    // = pair.Value;
                    index++;
                }
                // Return copied array
                //string sep = Environment.NewLine;
                string sep = "~";
               
                sqldata = string.Join(sep, result);

                con.cmd = new SqlCommand(s, con.con);
                con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
                con.cmd.Parameters.Add("@Sentence", SqlDbType.VarChar).Value = sqldata;
                con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_data.Text;
                con.cmd.Parameters.Add("@Sound_FileName", SqlDbType.VarChar).Value = filename;
                con.cmd.ExecuteNonQuery();
                Lblmsgn.Text = "";
                System.Threading.Thread.Sleep(1000);
                Lblmsgn.Visible = true;
                Lblmsgn.Text += "Record Added Successfully";
                
            }

            else if (ddl_items.SelectedValue == "Sound ID")
            {
                s = "insert into Sound_ID(GE,Correct_Answer,Sound_FileName) values (@GE,@Correct_Answer,@Sound_FileName)";

                con.cmd = new SqlCommand(s, con.con);
                con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
                con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_data.Text;
                con.cmd.Parameters.Add("@Sound_FileName", SqlDbType.VarChar).Value = filename;
                con.cmd.ExecuteNonQuery();
                Lblmsgn.Text = "";
                System.Threading.Thread.Sleep(1000);
                Lblmsgn.Visible = true;
                Lblmsgn.Text += "Record Added Successfully";
            }
            else if (ddl_items.SelectedValue == "Letter ID")
            {
                s = "insert into Letter_ID(GE,Correct_Answer,Sound_FileName) values (@GE,@Correct_Answer,@Sound_FileName)";

                con.cmd = new SqlCommand(s, con.con);
                con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
                con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_data.Text;
                con.cmd.Parameters.Add("@Sound_FileName", SqlDbType.VarChar).Value = filename;
                con.cmd.ExecuteNonQuery();
                Lblmsgn.Text = "";
                System.Threading.Thread.Sleep(1000);
                Lblmsgn.Visible = true;
                Lblmsgn.Text += "Record Added Successfully";
            }

            else if (ddl_items.SelectedValue == "Single Sentence Scramble")
            {
                //single sentence
                s = "insert into Sentence(GE,Sentences,Correct_Answer,Sound_FileName) values (@GE,@Sentence,@Correct_Answer,@Sound_FileName)";
                // s = "insert into Sentence(Sentences,original_sentence,Priority) values (@Sentence,@original_sentence,@priority)";
                string end_punctuation, input;
                input = tb_data.Text;
                char[] charsToTrim = { '?', '.', '!' };
                //char space_trim = ' ';
                end_punctuation = input.Substring(input.Length - 1);
                input = input.TrimEnd(charsToTrim);
                input = input.TrimEnd(' ');
                char[] delimiters = new[] { '.', ';', ' ' };  // List of your delimiters
                string[] splittedArray = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
                // Add all strings from array
                // Add new random int each time
                foreach (string sx1 in splittedArray)
                {

                    list.Add(new KeyValuePair<int, string>(num.Next(), sx1));
                }
                // Sort the list by the random number
                var sorted = from item in list
                             orderby item.Key
                             select item;
                // Allocate new string array
                string[] result = new string[splittedArray.Length];
                // Copy values to array
                int index = 0;
                foreach (KeyValuePair<int, string> pair in sorted)
                {
                    result[index] = pair.Value;
                    index++;
                }
                // Return copied array
                string sep = " ";
                //  lbs1.Text = "<span style='color: red;'>Enter the correct sentence with correct punctuation: </span>" + string.Join(sep, result);
                sqldata = string.Join(sep, result) + ' ' + end_punctuation;

                con.cmd = new SqlCommand(s, con.con);
                con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
                con.cmd.Parameters.Add("@Sentence", SqlDbType.VarChar).Value = sqldata;
                con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_data.Text;
                con.cmd.Parameters.Add("@Sound_FileName", SqlDbType.VarChar).Value = filename;
                con.cmd.ExecuteNonQuery();
                Lblmsgn.Text = "";
                System.Threading.Thread.Sleep(1000);
                Lblmsgn.Visible = true;
                Lblmsgn.Text += "Record Added Successfully";
            }




            else if (ddl_items.SelectedValue == "Word Scramble")
            {
                s = "insert into word_scramble(GE,Sentences,Correct_Answer,Sound_FileName,Extra) values (@GE,@Sentence,@Correct_Answer,@Sound_FileName,@Extra)";
            // s = "insert into word_scramble(UID,Sentences,original_sentence,Priority) values (@UID,@Sentence,@original_sentence,@priority)";
            again:
                // Create new string from the reordered char array
                string rand = new string(tb_data.Text.ToCharArray().
                 OrderBy(sx => (num.Next(2) % 2) == 0).ToArray());
                if (rand == tb_data.Text)
                    goto again;
                else
                    sqldata = rand;

                con.cmd = new SqlCommand(s, con.con);
                con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
                if (chcextra.Checked)
                {
                    con.cmd.Parameters.Add("@Extra", SqlDbType.VarChar).Value = 1;
                }
                else
                {
                    con.cmd.Parameters.Add("@Extra", SqlDbType.VarChar).Value = 0;
                }

                con.cmd.Parameters.Add("@Sentence", SqlDbType.VarChar).Value = sqldata;
                con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_data.Text;
                con.cmd.Parameters.Add("@Sound_FileName", SqlDbType.VarChar).Value = filename;
                con.cmd.ExecuteNonQuery();
                Lblmsgn.Text = "";
                System.Threading.Thread.Sleep(1000);
                Lblmsgn.Visible = true;
                Lblmsgn.Text += "Record Added Successfully";
            }
            else if (ddl_items.SelectedValue == "MCQ Decodable Words")
            {
                s = "insert into mcq_decodable_words_audio(GE,option1,option2,option3,option4,option5,Correct_Answer,audioFileName) values (@GE,@option1,@option2,@option3,@option4,@option5,@Correct_Answer,@audioFileName)";
               
                con.cmd = new SqlCommand(s, con.con);
                con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
                con.cmd.Parameters.Add("@option1", SqlDbType.VarChar).Value = txtoption1.Text;
                con.cmd.Parameters.Add("@option2", SqlDbType.VarChar).Value = txtoption2.Text;
                con.cmd.Parameters.Add("@option3", SqlDbType.VarChar).Value = txtoption3.Text;
                con.cmd.Parameters.Add("@option4", SqlDbType.VarChar).Value = txtoption4.Text;
                con.cmd.Parameters.Add("@option5", SqlDbType.VarChar).Value = txtoption5.Text;
                con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_data.Text;
                con.cmd.Parameters.Add("@audioFileName", SqlDbType.VarChar).Value = filename;
                con.cmd.ExecuteNonQuery();
                Lblmsgn.Text = "";
                System.Threading.Thread.Sleep(1000);
                Lblmsgn.Visible = true;
                Lblmsgn.Text += "Record Added Successfully";
            }
            else if (ddl_items.SelectedValue == "MCQ Non-Decodable Words")
            {
                s = "insert into mcq_nondecodable_words_audio(GE,option1,option2,option3,option4,option5,Correct_Answer,audioFileName) values (@GE,@option1,@option2,@option3,@option4,@option5,@Correct_Answer,@audioFileName)";

                con.cmd = new SqlCommand(s, con.con);
                con.cmd.Parameters.Add("@GE", SqlDbType.VarChar).Value = TextBox1.Text;
                con.cmd.Parameters.Add("@option1", SqlDbType.VarChar).Value = txtoption1.Text;
                con.cmd.Parameters.Add("@option2", SqlDbType.VarChar).Value = txtoption2.Text;
                con.cmd.Parameters.Add("@option3", SqlDbType.VarChar).Value = txtoption3.Text;
                con.cmd.Parameters.Add("@option4", SqlDbType.VarChar).Value = txtoption4.Text;
                con.cmd.Parameters.Add("@option5", SqlDbType.VarChar).Value = txtoption5.Text;
                con.cmd.Parameters.Add("@Correct_Answer", SqlDbType.VarChar).Value = tb_data.Text;
                con.cmd.Parameters.Add("@audioFileName", SqlDbType.VarChar).Value = filename;
                con.cmd.ExecuteNonQuery();
                Lblmsgn.Text = "";
                System.Threading.Thread.Sleep(1000);
                Lblmsgn.Visible = true;
                Lblmsgn.Text += "Record Added Successfully";
            }
            else
            {
                s = null;
                sqldata = "";
            }
        }

        finally
        {
            con.cmd.Dispose();
            con.disCon();
        }
    }
    protected void tb_data_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_items_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtoption1.Text = "";
        txtoption2.Text = "";
        txtoption3.Text = "";
        txtoption4.Text = "";
        txtoption5.Text = "";
        TextBox1.Text = "";
        tb_data.Text = "";
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}