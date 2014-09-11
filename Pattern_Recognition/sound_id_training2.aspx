<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="sound_id_training2.aspx.cs" Inherits="sound_id_training2" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

<body>
  
    <asp:Panel ID="Panel2" runat="server" Height="414px" Width="572px" 
        style="text-align: center">
         <br />
         Sound_ID_Training Question: 2
               <br />
                <br />
                <br />
                <audio id="ctrlaudio" style="width:75%" autoplay="autoplay" controls="controls">  
                <source src="/audio/sound_id/<%=m_filename %>"  /> 
                </audio>  
        <br />
        <br/>
           <div align="center" style="border:1px solid black;width:75%;height:100%;margin-left:70px">
              
                         <%foreach (var item in radiovalue)
                             {%>
                                   <br />
                                   <br />
                                   <br />
                                   <input type="radio" value="<%=item %>" name="rdAnswer"/>
                                  <span style="width:100%"  ><%=item %> </span>
                             <%} %>
                          <br />
                          <br />
                          <input type="button" value="Next" onclick="SetValue();" />
                          <br />
                          <br />
               </div>
                           <br />
                           <br />
     <%--   Correct Answer Is : <asp:Label ID="lblCorrectAnswer" runat="server"></asp:Label>--%>
      
    </asp:Panel>
    <asp:Button ID="btnsave" runat="server"  ClientIDMode="Static" style="display:none" />

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
                document.getElementById('ctrlaudio').src = '/audio/sound_id/SID_T4.wav';
                setTimeout(function () {
                    location.replace("/sound_id.aspx");
                }, 5000
            );
            }
            else {
                if ("<%=Iscorrect%>" == "1" && "<%=Iscorrectcount%>" == "0" && count==0) {
                    document.getElementById('ctrlaudio').src = '/audio/sound_id/SID_T5.wav';
                    count++;
                }
                else {
                    document.getElementById('ctrlaudio').src = '/audio/sound_id/SID_T6.wav';
                    setTimeout(function () {
                        location.replace("/sound_id.aspx");
                    }, 2000
                   );
                }
            }
        }
    }
</script>

</asp:Content>
