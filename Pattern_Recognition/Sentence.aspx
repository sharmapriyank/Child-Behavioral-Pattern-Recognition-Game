<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeFile="Sentence.aspx.cs" Inherits="Sentence" %>


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

    <p>
        <br />
    </p>

    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Rearrange Words to make a complete 
        Sentence&nbsp;</p>

<%--    <div style="overflow:auto">
         <ul ID="sortable" runat="server" style="width:100%" >
                </ul>
    </div>--%>

    <asp:Panel ID="Panel1" runat="server" style="margin-left: 0px;" Height="150px" >
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>


                <br />
       
        <div>
               <audio autoplay="autoplay" controls="controls">  
                      <source src="/audio/sound_id/<%=m_FileName%>" />    
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
    <asp:HiddenField ID="start_time" runat="server" />
    <asp:HiddenField ID="selected_answer" runat="server" />
    <asp:HiddenField ID="UID" runat="server" />
    <asp:HiddenField ID="QuestionType" runat="server" />
        
    <br />
    <asp:Button ID="Button1" runat="server" Height="38px" OnClientClick="SetValue()" onclick="Button1_Click" 
            Text="Next" Width="183px" />
                        
 
    <div>
    
    </div>


<script type="text/javascript">

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
            text = text.replace(/(\r\n|\n|\r)/gm, "");
            //text = text.trim();
            newOrder = newOrder + text+" ";
        });
        newOrder = newOrder.trim();
        //for (index in ids) {
        //    newOrder += $("#" + ids[index] + " span").text();
        //}
        document.getElementById("<%=selected_answer.ClientID %>").value = newOrder;
    }
</script>
</asp:Content>

