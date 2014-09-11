<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="m_sentences.aspx.cs" Inherits="m_sentences" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.9.1.js"></script>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css">
  <style>
  body{font-size:12px;}
  #MainContent_sortable { list-style-type: none; margin: 0; padding: 0; width: 60%; }
  #MainContent_sortable li { padding-left: 1.5em; font-size: 1.4em; height: 18px; 
          margin-right: 3px;
          margin-top: 0;
          margin-bottom: 3px;
          padding-right: 0.4em;
          padding-top: 0.4em;
          padding-bottom: 0.4em;
      }
  #MainContent_sortable li span { position: absolute; margin-left: -1.3em; }
  </style>
  <script>
      $(function () {
          $("#MainContent_sortable").sortable();
          $("#MainContent_sortable").disableSelection();
      });
  </script>


<body>

    <div>
        <br />
      <input id="hidValueSS" type="hidden" runat="server" />
        <asp:Label ID="ms_lb1" Font-Size="13px" runat="server" 
            Text="Sentence Scrambler: Arrange following Sentence"></asp:Label>
        <br />
        <br />
         <audio autoplay="autoplay" controls="controls">  
                      <source src="/audio/sound_id/<%=m_FileName%>" />    
                      </audio>  

        <br />
        <br />
        &nbsp;<asp:Label ID="ms_lb2" runat="server" Font-Bold="True" Font-Names="Arial" 
            Font-Size="Large"></asp:Label>
        <br />
        <br />
        <br />
    </div>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <ul ID="sortable" runat="server">
                <li>
                    <br />
                </li>
                </ul>
            <p>
                &nbsp;</p>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <asp:Button ID="bt_ms" runat="server" Height="36px"  OnClick="Button1_Click"  OnClientClick="SetValue()"
            Text="Next" Width="116px" />
        </p>
    <p>
        &nbsp;</p>
    <p>

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

    function SetValue() {
        var ids = $("#MainContent_sortable").sortable('toArray');
        var newOrder = "";

        $("#MainContent_sortable li").each(function (index) {
            var text1 = "";
            text1 = $(this).text();
            text1 = text1.replace(/(\r\n|\n|\r)/gm, "");
            text1 = text1.trim();
            if (text1.length > 0) {
                newOrder = newOrder + text1;
            }
        });

        //for (index in ids) {
        //    newOrder += $("#" + ids[index] + " span").text();
        //}
        newOrder = newOrder.replace(/(\r\n|\n|\r)/gm, "");
        document.getElementById("<%=selected_answer.ClientID %>").value = newOrder;
    }
</script>
       </asp:Content>

