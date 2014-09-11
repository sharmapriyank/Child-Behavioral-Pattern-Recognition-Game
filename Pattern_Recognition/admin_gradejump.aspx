<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="admin_gradejump.aspx.cs" Inherits="admin_gradejump" %>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

          <script language="javascript" type="text/javascript">
              // <![CDATA[

             
    </script>
    

    <asp:Panel ID="Panel1" runat="server" style="border:1px solid #DFDFDF;"  Height="500px" 
        Width="552px" >
        <br />
        <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" 
            Font-Names="Book Antiqua" Font-Size="XX-Large" Font-Underline="True" 
            ForeColor="Black" Text="Add Data - Admin Panel" Font-Overline="True" 
            Font-Strikeout="False"></asp:Label>
        <br />
        <br /> 
        <br />
        <br />
          <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
              
                  <table cellpadding="7px" cellspacing="7px" style="height:50%;width:100%">
                      <tr>
                          <td>
                             <asp:Label ID="lblGrade" runat="server" Text="Grade"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="txtgrade" runat="server" ></asp:TextBox>
                          </td>
                      </tr>
                       <tr>
                          <td>
                             <asp:Label ID="lblquestiontype" runat="server" Text="Question Type"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="txtquestiontype" runat="server" ></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <asp:Label ID="lblposjumb" runat="server" Text="Positive Jump"   ></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="txtposjumb" runat="server" ></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <asp:Label ID="lblnegjump" runat="server" Text="Negative Jump" Visible="true"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="txtnegjump" runat="server" ></asp:TextBox>
                          </td>
                      </tr>
                     
                      <tr>
                          <td>
                               <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" 
                                Height="35px" Width="86px" />
                          </td>
                          <td>
                              <asp:Label ID="Lblmsgn" runat="server" ForeColor="Blue"  Visible="False"></asp:Label>
                          </td>
                      </tr>
                  </table>

            </ContentTemplate>
          
        </asp:UpdatePanel>
     
    </asp:Panel>
    
</asp:Content>

