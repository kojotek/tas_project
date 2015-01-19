<%@ Page Title="Create auction" Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site.Master"
    CodeBehind="AuctionCreator.aspx.cs" Inherits="BiedaClient.Auction.AuctionCreatorPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% bool isLoggedIn = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;
       if (!isLoggedIn)
           Response.Redirect("~/Account/Manage");%>

    <br />
    <br />
    <br />
    
    <asp:Panel ID="Panel1" runat="server" BackColor="#FFBC79" BorderColor="#FFBC79" BorderWidth="20px" Width="1100px" Height="2000px">
    <asp:Table runat="server">

        <asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="lb_Name" Text="Nazwa przedmiotu" Font-Bold="true" runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="tb_Name" Text="" Width="400px" runat="server" AutoPostBack="false"/><br />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">            
            <asp:TableCell runat="server">
                <asp:Label ID="lb_CategoryList" Text="Kategorie" Font-Bold="true"  runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:DropDownList ID="cmb_CategoryList" runat="server" Width="400px" AutoPostBack="false" />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="lb_Description" Text="Opis przedmiotu" Font-Bold="true"  runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="tb_Description" Text="" TextMode="MultiLine" Width="400px" runat="server"  AutoPostBack="false"/><br />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="lb_Price" Text="Cena jednostkowa " Font-Bold="true" runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="tb_Price" Text="" Width="400px" runat="server"  AutoPostBack="false"/><br />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="lb_Delivery" Text="Koszt wysyłki " Font-Bold="true"  runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="tb_Delivery" Text="" Width="400px" runat="server"  AutoPostBack="false"/><br />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="lb_ExpireTime" Text="Czas trwania aukcji (liczba dni)" Font-Bold="true" runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="tb_ExpireTime" Text="" TextMode="Number" Width="400px" runat="server" AutoPostBack="false"/><br />
            </asp:TableCell></asp:TableRow></asp:Table><asp:Button ID="btnCreateAuction" OnClick="CreateAuctionClick" runat="server" Text="Utwórz aukcje" CssClass="btn btn-default" />
    </asp:Panel>


</asp:Content>