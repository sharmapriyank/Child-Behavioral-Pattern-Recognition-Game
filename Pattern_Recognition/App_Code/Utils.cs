using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
    private static Conn conn = new Conn();
	public Utils()
	{
	}

    public static void UpdateViewLog(int childId, int questionType, int questionId)
    {
        string sql = string.Format("INSERT INTO [Student_ViewLog] (Child_ID, QuestionType, QuestionId, CreatedOn) VALUES({0}, {1}, {2}, GETDATE())", childId, questionType, questionId);
        conn.ExecuteQuery(sql);
    }
}