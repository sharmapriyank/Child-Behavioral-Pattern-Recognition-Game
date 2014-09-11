<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="sentence_training1.aspx.cs" Inherits="sentence_training1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <style type="text/css">
         body{font-size:12px;}
        #MainContent_sortable li {
    float: left;
    font-size: 2em;
    height: 35px;
    padding: 1px;
    text-align: center;
    width:100px;
}
.ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
    background: url("images/ui-bg_glass_75_e6e6e6_1x400.png") repeat-x scroll 50% 50% #E6E6E6;
    border: 1px solid #D3D3D3;
    color: #555555;
    font-weight: normal;
}


#MainContent_sortable {
    list-style-type: none;
    margin: 0;
    padding: 0;
    text-align: center;
    width: 842px;
}

    </style>


    <asp:Panel ID="Panel1" runat="server" style="margin-left: 0px;" Height="150px" >
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                    Sentence Training Question : 1
                <br />
                 <br />
       
        <div>
                <audio id="ctrlaudio" autoplay="autoplay" controls="controls">  
                <source  src="/audio/sound_id/W2S_T1.wav"  /> 
                </audio> 
         </div>
        <br />
        <br />
        <br />
        <br />
             <ul ID="sortable" runat="server" style="width:100%" >
                </ul>
        <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
        <br />
        
        <br />
           </asp:Panel>
    <asp:HiddenField ID="correct_answer" runat="server" />
     <br />
        <br />
        <br />
        <br />
    <br />
    <input type="button" value="Next" onclick="SetValue();" />
    <div>
    
    </div>


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
            var text = "";
            text = $(this).text();
            //text = text.replace("\n", "");
            //text = text.trim();
            newOrder = newOrder + text+" ";
        });
        newOrder = newOrder.trim();
      
        var answer = document.getElementById("<%=correct_answer.ClientID %>").value;
       
        if (newOrder == answer) {
            location.replace("/sentence_training2.aspx?Iscorrect=1&Iscorrectcount=" + count);
        }
        else {
            if (count == 0) {
                document.getElementById('ctrlaudio').src = '/audio/sound_id/W2S_T3.wav';
                count++;
            }
            else {
                location.replace("/sentence_training2.aspx?Iscorrect=0&Iscorrectcount=" + count);
            }
        }
    }
</script>
</asp:Content>


