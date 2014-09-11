<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="practice.aspx.cs" Inherits="practice" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Panel ID="Panel1" runat="server" Style="text-align: left; padding: 10px" Width="709px">

        <h3>Practice Test</h3>

        <br />
        <br />
        <br />
        <div id="divcontrol" runat="server">
        <audio autoplay="autoplay" controls="controls">  
                      <source src="/audio/sound_id/<%=m_FileName%>" />    
                      </audio>

        <%foreach (var item in radiovalue)
          {%>
        <br />
        <br />
        <input type="radio" value="<%=item %>" name="rdAnswer" /><%=item %>
        <%} %>
        <br />
        <br />
        <br />

        <input type="button" value="Next" onclick="SetValue();" />
        <br />
        <br />
        <br />

           <%--  Correct Answer Is :
                    <asp:Label ID="lblCorrectAnswer" runat="server"></asp:Label>--%>

       </div> 
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" ForeColor="Blue" Font-Size="X-Large" runat="server"></asp:Label>
    </asp:Panel>
    <asp:HiddenField ID="start_time" runat="server" />
    <asp:HiddenField ID="selected_answer" runat="server" />
    <asp:HiddenField ID="UID" runat="server" />
    <asp:HiddenField ID="Corret_Answer" runat="server" />

    <asp:Button ID="btnsave" runat="server" OnClick="Button1_Click" ClientIDMode="Static" Style="display: none" />
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
