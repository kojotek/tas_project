<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="AuctionDraftPage.aspx.cs" Inherits="BiedaClient.Auction.AuctionDraftPage" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
    <br>
    <br>
    <br>
    
    <asp:Label ID="lb_Description" runat="server" Text="Opis przedmiotu"/>
    
    <asp:TextBox ID="UserName" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FFBC79"/>

</asp:Content>
