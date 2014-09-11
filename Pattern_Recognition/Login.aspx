<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Login.aspx.cs" Inherits="Login" %>




<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server">
        <div style="text-align:center;vertical-align:middle;top:30%">
            <table align="center" style="width:20%;height:160px;border:1px solid #DFDFDF;margin-top:10%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                      <asp:Button ID="Submit" runat="server" onclick="Button1_Click" 
                         Text="Login"  />
                    </td>
                    <td>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
          
        </div>
    </asp:Panel>
  

</asp:Content>
