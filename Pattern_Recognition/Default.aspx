<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <table>
            <tr>
                <td>
                   <asp:Button ID="btnNewTest" runat="server"  Text="Start New Test" OnClick="btnNewTest_Click" /> <br />
                </td>
            </tr>
             <tr>
                <td>
                  <asp:Button ID="btnPrevTest" runat="server"   Text="Continue Previous Test" OnClick="btnPrevTest_Click" /> <br />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="btnPracTest" runat="server"   Text="Practice Test" OnClick="btnPracticeTest_Click" /> <br />
                </td>
            </tr>
        </table>
    </div>
   

</asp:Content>
