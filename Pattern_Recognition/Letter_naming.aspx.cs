using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Letter_naming : System.Web.UI.Page
{

    

   // private static Random random = new Random((int)DateTime.Now.Ticks);
    private string RandomString(char correctAnswer)
    {
        Random num = new Random();
        int randomadd = num.Next(0,5);
        StringBuilder builder = new StringBuilder();
        char ch;
        int flag = 0;
        if (char.IsUpper(correctAnswer))
        {
            while (flag != 5)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * num.NextDouble() + 65)));
                if (flag == randomadd)
                {
                    builder.Append(correctAnswer);
                    flag++;
                }
                
                else if(ch != correctAnswer)
                {
                    builder.Append(ch);
                    flag++;
                }
            }
        }

        else
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
      /*  Random num = new Random();
        builder.Append(correctAnswer);
        string temp = builder.ToString();
    again:
        // Create new string from the reordered char array
        string rand = new string(temp.ToCharArray().
         OrderBy(sx => (num.Next(2) % 2) == 0).ToArray());
        if (rand == temp)
            goto again;

        */

        return builder.ToString();

    
    }

 
 
    protected void Page_Load(object sender, EventArgs e)
    {
        RadioButton1.Checked = false;
        RadioButton2.Checked = false; 
        RadioButton3.Checked = false;
        RadioButton4.Checked = false; 
        RadioButton5.Checked = false;
        char correctAnswer = 'x';
        char[] a = RandomString('v').ToCharArray();

        RadioButton1.Text = "" + a[0];
        RadioButton2.Text = "" + a[1];
        RadioButton3.Text = "" + a[2];
        RadioButton4.Text = "" + a[3];
        RadioButton5.Text = "" + a[4];
        

        

       
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}