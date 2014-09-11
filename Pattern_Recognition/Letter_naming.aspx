<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Letter_naming.aspx.cs" Inherits="Letter_naming" %>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
 
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
        #form1
        {
            text-align: right;
        }
        .style2
        {
            text-align: left;
            height: 64px;
        }
    </style>

   

       <table style="width:300px;padding:10px">
            <tr>
            <td class="style1">
                 <asp:Label ID="Label2" runat="server" Text="Choose the Correct Letter as Per Audio "></asp:Label></td>
            </tr>
            <tr>
            <td class="style1">
                <asp:RadioButton ID="RadioButton1" 
                    runat="server" GroupName="Group2" /></td>
            </tr>
            <tr>
             <td class="style1"> 
                 <asp:RadioButton ID="RadioButton2" 
                     runat="server" GroupName="Group2" /></td>
             </tr>
             <tr> 
            <td class="style1">
                <asp:RadioButton ID="RadioButton3" 
                    runat="server" GroupName="Group2" /></td>
             </tr>
               <tr> 
            <td class="style1">
                <asp:RadioButton ID="RadioButton4" 
                    runat="server" GroupName="Group2" /></td>
             </tr>
               <tr> 
            <td class="style1">
                <asp:RadioButton ID="RadioButton5" 
                    runat="server" GroupName="Group2" /></td>
             </tr>
               <tr> 
            <td class="style1">&nbsp;</td>
             </tr>
               <tr> 
            <td class="style2">
                    <asp:Button ID="Button1" runat="server" 
                        onclick="Button1_Click" Text="Next" />
                    </td>
             </tr>
                
                <br />
           <br />
    </table>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
 
    <div>
    
    </div>
    <p>
        &nbsp;</p>
&nbsp;<br />
          
</asp:Content>
