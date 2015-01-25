<%@ Page Title="AboutUser" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="AboutUser.aspx.cs" Inherits="BiedaClient.AboutUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    <asp:Panel ID="Panel1" runat="server" BackColor="#FFBC79" BorderColor="#FFBC79" BorderWidth="20px" Width="1100px" Height="700px">
        <br/><br/><br/>
        <asp:Label ID="LabelName" runat="server" Text="" Font-Size ="30"></asp:Label>
        <br/><br/>
        <asp:Label ID="LabelPersonal" runat="server" Text="" Font-Size ="20"></asp:Label><br/>
        <asp:Label ID="LabelNumber" runat="server" Text="" Font-Size ="20"></asp:Label><br/>
        <asp:Label ID="LabelEmail" runat="server" Text="" Font-Size ="20"></asp:Label><br/>
    </asp:Panel>
</asp:Content>
