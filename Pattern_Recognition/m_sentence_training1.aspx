<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="m_sentence_training1.aspx.cs" Inherits="m_sentence_training1" %>

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
            Text="Sentence Scrambler Training Question: 1"></asp:Label>
        <br />
        <br />
          <audio id="ctrlaudio" autoplay="autoplay" controls="controls">  
                <source  src="/audio/sound_id/S2P_T1.wav"  /> 
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
            <input type="button" value="Next" onclick="SetValue();" />
        </p>
    <p>
        &nbsp;</p>
    <p>

    <asp:HiddenField ID="correct_answer" runat="server" />

</body>

<script type="text/javascript">
    var count = 0;
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
        newOrder = newOrder.replace(/(\r\n|\n|\r)/gm, "");
        var answer = document.getElementById("<%=correct_answer.ClientID %>").value;
        if (newOrder == answer) {
            location.replace("/m_sentence_training2.aspx?Iscorrect=1&Iscorrectcount=" + count);
        }
        else {
            if (count == 0) {
                document.getElementById('ctrlaudio').src = '/audio/sound_id/S2P_T3.wav';
                count++;
            }
            else {
                location.replace("/m_sentence_training2.aspx?Iscorrect=0&Iscorrectcount=" + count);
            }
        }

    }
</script>
       </asp:Content>


