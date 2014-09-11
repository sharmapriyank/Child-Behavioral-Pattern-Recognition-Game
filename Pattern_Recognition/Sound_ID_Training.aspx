<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Sound_ID_Training.aspx.cs" Inherits="Sound_ID" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <meta charset="utf-8">
  <title>Training Items</title>
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css">
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

    <script>
        $(document).ready(function () {
            function change1(sourceUrl) {
                var audio = $("#player");
                $("#mp3_src").attr("src", sourceUrl);
                /****************/
                audio[0].pause();
                audio[0].load(); //suspends and restores all audio element
                audio[0].play();
                /****************/
            }

            $('.track').click(function () {
                load_track = $(this).attr('data-location');
                var message = document.getElementById('<%=hidValue.ClientID%>').value;
                alert(message);
                change1(load_track); // function to change the track of the loaded audio player without page refresh preferred...
            });

        });
    </script>

<body>
   
    <p>
        &nbsp;</p>
    <p>
           </p>
    
    <p>
           </p>
    <p>
                   <asp:Panel ID="Panel1" runat="server" Height="414px" style="text-align: center" 
                       Width="572px">
                       <br />
                       <br />
                       <br />
                       <asp:RadioButton ID="RadioButton0" runat="server" 
                           GroupName="Group1" />
                       <br />
                       <br />
                       <asp:RadioButton ID="RadioButton1" runat="server" 
                           GroupName="Group1" />
                       <br />
                       <br />
                       <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Group1" />
                       <br />
                       <br />
                       <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Group1" 
                           oncheckedchanged="RadioButton3_CheckedChanged" />
                       <br />
                       <br />
                       <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Group1" />
                       <br />
                       <br />
                       <asp:Button ID="Button1" runat="server" AutoPostBack="False" 
                           onclick="Button1_Click1" Text="Submit" />
                       <br />
                       <br />
                   </asp:Panel>
           </p>
    
    
           

           <div id="audio_list">
            <a href="#" class="track" data-location="audio/clip.mp3">sample</a>
        </div>

        <audio id="player" controls="controls"autoplay="autoplay">         
          <source id="mp3_src" src="audio/Sound_ID/SID_T1_d.wav" />
          Your browser does not support the audio element.
        </audio>
           
            <br />
            <br />
<br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br />
<br />

       
    <div>
    
        
    
    </div>
    <p>
        &nbsp;</p>
    <input id="hidValue" type="hidden" runat="server" value="1x" />
    
    <audio autoplay="autoplay" controls="controls">  
        
        <source src="audio/Sound_ID/"+"SID_T1_d.wav" />
        
        <br />
        <br />


</body>
</asp:Content>
