<%@ Page Title="Buyer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buyer.aspx.cs" Inherits="ProjektBieda.buyer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br /><br /><br />
        <asp:Label ID="LabelUserName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
    </p>
</asp:Content>
