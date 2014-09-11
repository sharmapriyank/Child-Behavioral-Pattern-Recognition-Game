using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsUserInfo
/// </summary>
public class clsUserInfo
{
	public clsUserInfo()
	{
	}
    public int SessionId { get; set; }
    public int ChildId { get; set; }
    public int LogId { get; set; }
    public int Grade { get; set; }
    public string UserName { get; set; }
}