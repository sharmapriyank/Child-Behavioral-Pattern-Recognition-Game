<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="admin_list.aspx.cs" Inherits="admin_list" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

      
                               <asp:DropDownList ID="ddl_items" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_items_SelectedIndexChanged" >
                               <asp:ListItem>Word Scramble</asp:ListItem>
                               <asp:ListItem>Single Sentence Scramble</asp:ListItem>
                               <asp:ListItem>Multiple Sentence Scramble</asp:ListItem>
                               <asp:ListItem>Letter ID</asp:ListItem>
                               <asp:ListItem>Sound ID</asp:ListItem>
                               <asp:ListItem>MCQ Decodable Words</asp:ListItem>
                               <asp:ListItem>MCQ Non-Decodable Words</asp:ListItem>
                        </asp:DropDownList>

        <br />
        <br />     
    <asp:GridView runat="server" ID="grid" Width="100%" AllowPaging="false" PageSize="30"></asp:GridView>

        <br />
        <br /> 
</asp:Content>
