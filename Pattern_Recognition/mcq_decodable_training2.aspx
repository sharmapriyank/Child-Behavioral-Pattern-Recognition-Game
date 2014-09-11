<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="mcq_decodable_training2.aspx.cs" Inherits="mcq_decodable_training2" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

<body>
    <div>
    
    </div>
    <asp:Panel ID="Panel1" runat="server" style="text-align: center;padding:10px" Width="709px">
        <br />
         MCQ Decodable Training Question : 2
        <br />
        <br />
        <audio id="ctrlaudio" style="width:75%" autoplay="autoplay" controls="controls">  
                <source src="/audio/sound_id/<%=m_filename %>"  /> 
                </audio>   
        <br />
        <br />
 <div align="center" style="border:1px solid black;width:75%;height:100%;margin-left:85px">
           <%foreach (var item in radiovalue)
          {%>
                <br />
            
                <input type="radio" value="<%=item %>" name="rdAnswer"/><%=item %>
                <br />
                <br />
          <%} %>
        <br />
    
            <input type="button" value="Next" onclick="SetValue();" />
        <br />
        <br />
    </div> 
          <br />
        <%-- Correct Answer Is : <asp:Label ID="lblCorrectAnswer" runat="server"></asp:Label>--%>
    </asp:Panel>
        <asp:HiddenField ID="correct_answer" runat="server" />

</body>

<script type="text/javascript">

    var count = 0;
    function SetValue() {
        var test = document.getElementsByName("rdAnswer");
        var sizes = test.length;
        var selectedValue = "";
        for (i = 0; i < sizes; i++) {
            if (test[i].checked == true) {
                selectedValue = test[i].value;
                break;
            }
        }
        if (selectedValue == "") {
            alert("Please answer this Question");
            return false;
        }
        else {
            var answer = document.getElementById("<%=correct_answer.ClientID %>").value;
            if (selectedValue == answer) {
                document.getElementById('ctrlaudio').src = '/audio/sound_id/WR_T4.wav';
                setTimeout(function () {
                    location.replace("/test_mcq_audio.aspx");
                }, 5000
            );
            }
            else {
                if ("<%=Iscorrect%>" == "1" && "<%=Iscorrectcount%>" == "0" && count == 0) {
                    document.getElementById('ctrlaudio').src = '/audio/sound_id/WR_T5.wav';
                    count++;
                }
                else {
                    document.getElementById('ctrlaudio').src = '/audio/sound_id/WR_T6.wav';
                    setTimeout(function () {
                        location.replace("/test_mcq_audio.aspx");
                    }, 2000
                   );
                }
            }
        }
    }
</script>
</asp:Content>


