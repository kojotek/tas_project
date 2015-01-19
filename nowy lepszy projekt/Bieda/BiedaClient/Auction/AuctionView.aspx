<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionView.aspx.cs" Inherits="BiedaClient.Auction.AuctionView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <br />
    <br />
    
    <asp:Table runat="server">
        <asp:TableRow>            
            <asp:TableCell runat="server">

            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="BidClick"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
