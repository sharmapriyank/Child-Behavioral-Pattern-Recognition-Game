using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//using System.Data.OleDb;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Conn
{
    /*public OleDbConnection con;
    public OleDbCommand cmd;
    public OleDbDataReader dr;

    public void getCon()
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\student.mdb;");
        if (con.State == ConnectionState.Closed)
            con.Open();
    }

    public void discon()
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\student.mdb;");
        if (con.State == ConnectionState.Open)
            con.Close();
    }*/

    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataReader dr;
    private int m_CommandExecutionTimeout = 600;
  // private string m_ConnectionString = @"Data Source=(local)\sqlexpress;Initial Catalog=alpha;Integrated Security=True";
    private string m_ConnectionString = @"Data Source=A2I-DEV;Initial Catalog=alpha;Integrated Security=True";
    public void getCon()
    {
        con = new SqlConnection(m_ConnectionString);
        //con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        if (con.State == ConnectionState.Closed)
            con.Open();
    }

    public void disCon()
    {
        con = new SqlConnection(m_ConnectionString);
        //con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
        if (con.State == ConnectionState.Open)
            con.Close();
    }


    public bool GetData(string SQL, ref DataTable objDataTable)
    {
        SqlConnection objConnection = new SqlConnection(m_ConnectionString);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        bool ReturnValue;

        if (SQL.Length == 0)
        {
            return false;
        }

        SqlCommand objCommand = new SqlCommand(SQL, objConnection);
        objCommand.CommandTimeout = m_CommandExecutionTimeout;
        try
        {
            objConnection.Open();
            objDataAdapter.SelectCommand = objCommand;
            objDataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                objDataTable = dt;
                ReturnValue = true;
            }
            else
            {
                ReturnValue = false;
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message.ToString());
            ReturnValue = false;
        }
        finally
        {
            objConnection.Close();
        }

        return ReturnValue;

    }

    public string ExecuteQuery(string SQL)
    {
        SqlConnection objConnection = new SqlConnection(m_ConnectionString);
        SqlCommand objCommand = new SqlCommand(SQL, objConnection);
        objCommand.CommandTimeout = m_CommandExecutionTimeout;
        string Error = "";

        try
        {
            objConnection.Open();
            objCommand.ExecuteNonQuery();
            objCommand.Dispose();
        }
        catch (SqlException e)
        {
            SqlErrorCollection sqlErrors = e.Errors;
            for (int i = 0; i < sqlErrors.Count; i++)
            {
                Error += sqlErrors[i].Message.ToString();
            }
        }
        finally
        {
            objConnection.Close();
        }
        return Error;
    }

    public int GetIDFromInsert(string SQL)
    {
        int id = 0;
        SqlConnection objConnection = new SqlConnection(m_ConnectionString);
        SqlCommand objCommand = objConnection.CreateCommand();
        objCommand.CommandText = SQL + " SET @PKey = SCOPE_IDENTITY()";

        SqlParameter PKey = new SqlParameter("@PKey", SqlDbType.Int);
        PKey.Direction = ParameterDirection.Output;
        objCommand.Parameters.Add(PKey);

        objCommand.Connection.Open();
        objCommand.ExecuteNonQuery();
        id = (int)PKey.Value;
        return id;
    }
}