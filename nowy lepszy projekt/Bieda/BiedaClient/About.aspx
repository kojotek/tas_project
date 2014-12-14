<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BiedaClient.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <br /><br />
    <br />
    <div align="right"><asp:Label ID="LabelTime" runat="server" Text="Label" align="right" Font-Size="10"></asp:Label></div>
    <asp:Label ID="LabelLogin" runat="server" Text="Label" Font-Bold="false" Font-Size="10"></asp:Label>
    <br />
    <asp:Label ID="LabelName" runat="server" Text="Label" Font-Bold="True" Font-Underline="True" Font-Size="25pt" Width="2000px"></asp:Label><br />
    <br />
    <br />
    <asp:Label ID="Labeltemp1" runat="server" Text="Obecna cena:" Font-Bold="True" Font-Size="12pt"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="LabelPrice" runat="server" Text="Label" Font-Bold="True" Font-Size="12pt"></asp:Label>
    <br />
    <asp:Label ID="LabelTemp2" runat="server" Text="Cena wysyłki:" Font-Bold="True" Font-Size="12pt"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="LabelSendPrice" runat="server" Text="Label" Font-Bold="True" Font-Size="12pt"></asp:Label><br />

    <br />
    <br />
    <asp:Label ID="LabelTemp4" runat="server" Text="Opis produktu:" Font-Bold="True" Font-Size="12pt"></asp:Label><br />

<asp:Label ID="TextBoxDescription" runat="server" ReadOnly="True" MaxLength="80" Height="100px" Width="500px"></asp:Label><br />
</asp:Content>
