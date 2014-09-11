<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="final_ls.aspx.cs" Inherits="final_ls" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
<script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
<script type="text/javascript" src="http://www.pureexample.com/js/lib/jquery.ui.touch-punch.min.js"></script>
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
    <style type="text/css">
  #MainContent_sortable li{
    float: left;
    font-size: 2em;
    height: 35px;
    padding: 1px;
    text-align: center;
    width:40px;
}
.ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
    background: url() repeat-x scroll 50% 50% #E6E6E6;
    border: 1px solid #D3D3D3;
    color: #555555;
    font-weight: normal;
}
        
 #MainContent_drop li {
    float: left;
    font-size: 2em;
    height: 35px;
    padding: 1px;
    text-align: center;
    width:40px;
}

     #MainContent_drop {
    list-style-type: none;
    margin: 0;
    padding: 0;
    text-align: center;
    width: 842px;
}

#MainContent_sortable {
    list-style-type: none;
    margin: 0;
    padding: 0;
    text-align: left;
    width: 842px;
}
  #divdrop {  float: left; }
  #divdrop ol { margin: 0; }

   #div1 {  float: left; }
  #div1 ol { margin: 0; }

.ui-draggable-dragging  
{
        list-style-type: none;
        float: left;
        font-size: 2em;
        height: 35px;
        padding: 1px;
        text-align: center;
        width:40px;
         
}
       
    </style>

 

    <asp:Panel ID="Panel1" runat="server" Height="414px" Width="572px" style="text-align: center;margin-left:20%">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>


                <br />
       
                     <div>
                       <audio autoplay="autoplay" style="width:100%" controls="controls">  
                       <source src="/audio/sound_id/<%=m_FileName%>" />    
                       </audio>  
                    </div>
                 <br />
                 <br />
                
            </ContentTemplate>
        </asp:UpdatePanel>
 <div align="center" style="border:1px solid black;width:100%;height:100%;">    
              <br />
               <br />
            <ul ID="drop" runat="server" style="height:40px;width:100%" >
            </ul>
          
        <br />
        <br />
        <br />
        <br />
          <div id="divdrop">
              <ol id="sortable" runat="server" style="height:40px; width:100%;">
              <%--<span id="tempText">Drop here</span>--%>
              </ol>
          </div>
        <br /><a href="#" onclick="javascript:window.location.href = window.location.href;">Reload</a>
        <br />
        <br />
        <br /> 
        <br />
        <br />
         <br />
         <br />  
         <br />
      
      <asp:Button ID="Button1" runat="server" Height="38px" OnClientClick="SetValue()" onclick="Button1_Click" 
            Text="Next" Width="183px" />
        <br />
        <br />
         <br />
         <br />
         <br />
         <br />
         <br />
  </div>
   </asp:Panel>
    <asp:HiddenField ID="start_time" runat="server" />
    <asp:HiddenField ID="selected_answer" runat="server" />
    <asp:HiddenField ID="UID" runat="server" />
    <asp:HiddenField ID="QuestionType" runat="server" />
    <asp:HiddenField ID="answerlength" Value="0" runat="server" />
        
   
                        
    


<script type="text/javascript">

    var i = 0;
    $(function () {

       // MovebottomToTop();
        MoveToptoBottom();
        
    });

    function MovebottomToTop() {
        //$("#MainContent_sortable li").draggable({
        //    appendTo: "body",
        //    helper: "clone"
        //});
        var length = $('#MainContent_answerlength').val();
        $("#MainContent_drop").droppable({
            activeClass: "ui-state-default",
            hoverClass: "ui-state-hover",
            accept: ":not(.ui-sortable-helper)",
            drop: function (event, ui) {
                var lilength = $("#MainContent_sortable li").length;
              //  if (parseInt(length) > parseInt(lilength)) {
                    $(ui.draggable).remove();
                    $("<li  class='ui-state-default ui-draggable'> <span> " + ui.draggable.text() + "</span ></li>").appendTo(this);
                    i = i - 1;
                    $("#divdrop ol").append("<li id=Empty" + i + " class='ui-state-default ui-draggable'> <span> </span ></li>");
                    MoveToptoBottom();
               // }
            }
        })
    }

    function MoveToptoBottom() {
        $("#MainContent_drop li").draggable({
            appendTo: "body",
            helper: "clone"
        });

        var length = $('#MainContent_answerlength').val();
        //  $("#divdrop ol").droppable({
        $("#MainContent_sortable li").droppable({
            //activeClass: "ui-state-default",
            //hoverClass: "ui-state-hover",
            accept: ":not(.ui-sortable-helper)",
            drop: function (event, ui) {
                $(ui.draggable).remove();
                var id = this.id;
                $("#" + id).html("<span> " + ui.draggable.text() + "</span >");
                //$("#divdrop ol #Empty" + i).remove();
                //var lilength=$("#MainContent_sortable li").length;
                //if( parseInt(length) > parseInt(lilength) )
                //{
                //    $(ui.draggable).remove();
             
                //    $("<li class='ui-state-default ui-draggable'> <span> " + ui.draggable.text() + "</span ></li>").appendTo(this);
                //    i = i + 1;
                //    MovebottomToTop();
                //}

            }
        }).sortable({
            items: "li:not(.placeholder)",
            sort: function () {
                $(this).removeClass("ui-state-default");
            }

        });
    }


    function SetValue() {
        var newOrder = "";
        $("#MainContent_sortable li").each(function (index) {
            var text = "";
            text = $(this).text();
            text = text.replace("\n", "");
            text = text.trim();
            newOrder = newOrder + text;
        });

        //for (index in ids) {
        //    newOrder += $("#" + ids[index] + " span").text();
        //}
        document.getElementById("<%=selected_answer.ClientID %>").value = newOrder;
    }
</script>
</asp:Content>
