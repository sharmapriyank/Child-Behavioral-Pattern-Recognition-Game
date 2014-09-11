﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="test_mcq_non-decodable.aspx.cs" Inherits="test_mcq_non_decodable" %>


<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

<body>
    <div>
    
    </div>
    <asp:Panel ID="Panel1" runat="server" style="text-align: center;padding:10px" Width="709px">
        <br />
        <br />
        <br />
        <audio autoplay="autoplay" style="width:75%" controls="controls">  
            <source src="/audio/sound_id/<%=m_FileName%>" />    
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
        <br />
            <input type="button" value="Next" onclick="SetValue();" />
        <br />
        <br />
    </div>
        <br />
       <%--  Correct Answer Is : <asp:Label ID="lblCorrectAnswer" runat="server"></asp:Label>--%>
    </asp:Panel>
        <asp:HiddenField ID="start_time" runat="server" />
        <asp:HiddenField ID="selected_answer" runat="server" />
        <asp:HiddenField ID="UID" runat="server" />
        <asp:HiddenField ID="QuestionType" runat="server" />
      <asp:Button ID="btnsave" runat="server" OnClick="Button1_Click" ClientIDMode="Static" style="display:none" />

</body>

<script type="text/javascript">
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
            document.getElementById("<%=selected_answer.ClientID %>").value = selectedValue;
            var btn = document.getElementById('btnsave');
            btn.click();
        }
    }
</script>
</asp:Content>
