<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="admin_practice.aspx.cs" Inherits="practice" %>

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


    <asp:Panel ID="Panel1" runat="server" style="border:1px solid #DFDFDF;"  Height="553px" 
        Width="552px" >
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
              
                  <table cellpadding="7px" cellspacing="7px" style="height:50%;width:100%">
                      <tr>
                          <td>
                                  <asp:Label ID="lb_op_correctanswer" runat="server" Text="Correct Answer"   ></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="tb_op_correctanswer" runat="server" Height="37px" 
                               Width="111px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <asp:Label ID="lb_op1" runat="server" Text="Option 1" Visible="true"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="tb_op1" runat="server" Height="29px"  Width="109px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <asp:Label ID="lb_op2" runat="server" Text="Option 2" Visible="true"></asp:Label>
                          </td>
                          <td>
                               <asp:TextBox ID="tb_op2" runat="server" Height="29px" Width="109px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <asp:Label ID="lb_op3" runat="server" Text="Option 3" Visible="true"></asp:Label>
                          </td>
                          <td>
                              <asp:TextBox ID="tb_op3" runat="server" Height="29px"  Width="109px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td>
                                <asp:Label ID="lb_op4" runat="server" Text="Option 4" Visible="true"></asp:Label>
                          </td>
                          <td>
                               <asp:TextBox ID="tb_op4" runat="server" Height="29px" Visible="true"  Width="109px"></asp:TextBox>
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
                              Sentence
                          </td>
                          <td>
                                <asp:TextBox ID="tb_data" runat="server" Columns="10" Height="81px" Rows="5" TextMode="multiline"   Width="286px" />
                          </td>
                      </tr>
                       <tr>
                        <td width="125px">
                            <asp:Label ID="Label2" runat="server" Text="Option"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload  ID="fileupload1"  runat="server" />
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
