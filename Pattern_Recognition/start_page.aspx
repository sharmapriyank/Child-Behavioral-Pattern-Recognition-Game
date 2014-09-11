<%@ Page Language="C#" AutoEventWireup="true" CodeFile="start_page.aspx.cs" Inherits="start_page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Algerian;
            font-size: xx-large;
            color: #3399FF;
            text-decoration: underline;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            font-family: Andalus;
            font-size: xx-large;
            color: #FF0000;
        }
        .style4
        {
            color: #993300;
        }
        .style5
        {
            font-size: x-large;
        }
        .style6
        {
            color: #993300;
            font-size: x-large;
        }
    </style>
</head>
<body background="images/backgroud.jpg">
    <form id="form1" runat="server">
    <div class="style2">
    
        <br />
        <span class="style1"><strong>Reading Assessment: Games<br />
        </strong></span>
        <br />
        <br />
        <br />
        <br />
        <br />
        <span class="style3"><strong>Play Games</strong></span><br />
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="style5" 
            NavigateUrl="Default.aspx"> Word Scramble</asp:HyperLink>
        <br class="style6" />
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="style5" 
            NavigateUrl="~/Sentence.aspx">Sentence Scramble</asp:HyperLink>
        <br class="style6" />
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="style5" 
            NavigateUrl="~/m_sentences.aspx">Paragraph Scramble</asp:HyperLink>
        <span class="style4">&nbsp;</span><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
