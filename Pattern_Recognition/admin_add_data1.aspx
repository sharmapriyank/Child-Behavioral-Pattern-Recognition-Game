<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="admin_add_data1.aspx.cs" Inherits="admin_add_data1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">



          <script language="javascript" type="text/javascript">
              // <![CDATA[

              function TextArea1_onclick() {

              }

              // ]]>
              function onUpdating() {
                  // get the divImage
                  var panelProg = $get('divImage');
                  // set it to visible
                  panelProg.style.display = '';

                  // hide label if visible     
                  var lbl = $get('<%= this.Lblmsgn.ClientID %>');
            lbl.innerHTML = '';
        }

        function onUpdated() {
            // get the divImage
            var panelProg = $get('divImage');
            // set it to invisible
            panelProg.style.display = 'none';
        }
    </script>
    <style type="text/css">
       
        .showupload
        {
            display:block;
        }
         .hideupload
        {
            display:none;
        }
      
    </style>

    <asp:Panel ID="Panel1" runat="server" style="border:1px solid #DFDFDF;width:552px;height:auto" >
       
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
            Font-Names="Book Antiqua" Font-Size="XX-Large" Font-Underline="True" 
            ForeColor="Black" Text="Add Data - Admin Panel" Font-Overline="True"
            Font-Strikeout="False"></asp:Label>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager> 
                <table cellpadding="10px" cellspacing="10px" style="height:50%;width:100%">
                    <tr >
                        <td></td>
                        <td>
                               <asp:DropDownList ID="ddl_items" runat="server" AutoPostBack="True" 
                               onselectedindexchanged="ddl_items_SelectedIndexChanged">
                               <asp:ListItem>Word Scramble</asp:ListItem>
                               <asp:ListItem>Single Sentence Scramble</asp:ListItem>
                               <asp:ListItem>Multiple Sentence Scramble</asp:ListItem>
                               <asp:ListItem>Letter ID</asp:ListItem>
                               <asp:ListItem>Sound ID</asp:ListItem>
                               <asp:ListItem>MCQ Decodable Words</asp:ListItem>
                               <asp:ListItem>MCQ Non-Decodable Words</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             GE
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Correct Answer
                        </td>
                        <td>
                            <asp:TextBox ID="tb_data" runat="server" Columns="10" Height="81px" 
                               ontextchanged="tb_data_TextChanged" Rows="5" TextMode="multiline" 
                             Width="286px" />
                        </td>
                    </tr>
                    <div id="divextra" runat="server"  visible="false">
                         <tr>
                        <td>
                            Extra
                        </td>
                        <td>
                            <input type="checkbox" id="chcextra"  runat="server"/>
                        </td>
                    </tr>
                    </div>
                      <tr>
                        <td >
                            <asp:Label ID="lb_op1" runat="server" Text="Option"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload  ID="fileupload1"  runat="server" />
                        </td>
                    </tr>
                    <div runat="server" id="divoption" visible="false">
                    <tr >
                        <td >
                            <asp:Label ID="lbloption1" runat="server" Text="Option1"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtoption1"  runat="server"></asp:TextBox>
                        </td>
                    </tr>
                      <tr >
                        <td >
                            <asp:Label ID="lbloption2"  runat="server" Text="Option2"></asp:Label>
                        </td>
                        <td>
                           <asp:TextBox ID="txtoption2"  runat="server"></asp:TextBox>
                        </td>
                    </tr>
                      <tr >
                        <td >
                            <asp:Label ID="lbloption3"  runat="server" Text="Option3"></asp:Label>
                        </td>
                        <td>
                              <asp:TextBox ID="txtoption3"  runat="server"></asp:TextBox>
                        </td>
                    </tr>
                      <tr >
                        <td >
                            <asp:Label ID="lbloption4"  runat="server" Text="Option4"></asp:Label>
                        </td>
                        <td>
                             <asp:TextBox ID="txtoption4"  runat="server"></asp:TextBox>
                        </td>
                     </tr>
                      <tr >
                        <td >
                            <asp:Label ID="lbloption5"  runat="server" Text="Option5"></asp:Label>
                        </td>
                        <td>
                             <asp:TextBox ID="txtoption5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                        </div>
                    <tr >
                        <td>
                              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" 
                                Height="35px" Width="86px" />
                        </td>
                        <td>
                            <asp:Label ID="Lblmsgn" runat="server" 
                                  Visible="False" ForeColor="blue"></asp:Label>

                              <div id="divImage" style="display:none">
                                <asp:Image ID="img1" runat="server" ImageUrl="ajax_loader_gray_512.gif" 
                               style="width: 97px; height: 77px" />
                               Processing...
                             </div>

                        </td>
                    </tr>
                </table>
             
                <br />
                <br />
                 <br />
                <br />
           
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="Button1" />
            </Triggers>
        </asp:UpdatePanel>
      
        <asp:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" 
                runat="server" TargetControlID="UpdatePanel1">
            <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating();" />
                    <EnableAction AnimationTarget="Button1" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated();" />
                    <EnableAction AnimationTarget="Button1" Enabled="true" />
                </Parallel>
            </OnUpdated>
        </Animations>
        </asp:UpdatePanelAnimationExtender>
        
    </asp:Panel>
   

</asp:Content>