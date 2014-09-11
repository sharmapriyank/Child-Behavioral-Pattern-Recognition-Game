<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="final_words2sent.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8">
  <title>jQuery UI Droppable - Default functionality</title>
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css">
  <style>
      #MainContent_sortable { list-style-type: none; margin: 0; padding: 0; width: 100%;
          text-align: center;
      }
  #MainContent_sortable li { margin: 3px 3px 3px 3px 3px 3px 0; padding: 2px; float: left; width: 130px; height: 40px; font-size: 1.5em; text-align: left; }
  .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
    background: url("") repeat-x scroll 50% 50% #E6E6E6;
    border: 1px solid #D3D3D3;
    color: #555555;
    font-weight: normal;
}
  </style>


<body>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
          
             <audio autoplay="autoplay" controls="controls">  
                      <source src="/audio/sound_id/<%=m_FileName%>" />    
                      </audio>
              <br />
            <br /> 
<br />
<br />
<ul ID="sortable" runat="server">
</ul>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Next" OnClientClick="SetValue()"  onclick="Button1_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="start_time" runat="server" />
    <asp:HiddenField ID="selected_answer" runat="server" />
    <asp:HiddenField ID="UID" runat="server" />
    <asp:HiddenField ID="QuestionType" runat="server" />


</body>

<script type="text/javascript">
      $(function () {
          $("#MainContent_sortable").sortable();
          $("#MainContent_sortable").disableSelection();
      });

      function abc() {
          var ids = $("#MainContent_sortable").sortable('toArray');
          var newOrder = "";
          for (index in ids) { newOrder += $("#" + ids[index] + " span").text(); }
          document.getElementById("<%=selected_answer.ClientID %>").value = newOrder;
      }
</script>


</asp:Content>
