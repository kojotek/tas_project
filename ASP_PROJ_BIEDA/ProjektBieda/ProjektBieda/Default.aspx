<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjektBieda._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center;">
        <br /><br /><br /><br />
        <asp:Image ID="Image1" runat="server" ImageUrl="http://zapodaj.net/images/0f770bb31e781.png" ImageAlign="AbsMiddle" Width="722px" />
        <br /><br /><br /><br />
        <asp:TextBox ID="TextBox1" runat="server" Width="500px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Znajdź interesujące cię produkty" />
    </div>


</asp:Content>
