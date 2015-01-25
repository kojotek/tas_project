<%@ Page Title="Create auction" Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site.Master"
    CodeBehind="Create.aspx.cs" Inherits="BiedaClient.Auction.AuctionCreatorPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <br />
    <br />

    <asp:Panel ID="panelBackground" runat="server" BackColor="#FFBC79" BorderColor="#FFBC79" BorderWidth="20px" Width="1100px" Height="2000px">
    <asp:Table runat="server">

        <asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="itemNameLabel" Text="Nazwa przedmiotu" Font-Bold="true" runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="itemNameTextBox" Text="" Width="400px" runat="server" AutoPostBack="false"/>
                <asp:RequiredFieldValidator id="itemNameFieldValidator" runat="server" 
                    ControlToValidate="itemNameTextBox" ErrorMessage="Can't be empty" /><br />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">            
            <asp:TableCell runat="server">
                <asp:Label ID="categoryListLabel" Text="Kategorie" Font-Bold="true"  runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:DropDownList ID="categoryListDropdown" runat="server" Width="400px" AutoPostBack="false" />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="descriptionLabel" Text="Opis przedmiotu" Font-Bold="true"  runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="descriptionTextBox" Text="" TextMode="MultiLine" Width="400px" runat="server"  AutoPostBack="false"/><br />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="priceLabel" Text="Cena jednostkowa " Font-Bold="true" runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="priceEditBox" Text="" Width="400px" runat="server" AutoPostBack="false"/>
                <asp:RegularExpressionValidator ID="priceRegExValidator" runat="server" Font-Bold="true" ForeColor="DarkRed" 
                    ControlToValidate="priceEditBox" ValidationExpression="^(\d)+(,(\d)+)?$" ErrorMessage="Zly format waluty"/>
                <asp:RequiredFieldValidator id="priceFieldValidator" runat="server" 
                    ControlToValidate="priceEditBox" ErrorMessage="Can't be empty"/><br />
        </asp:TableCell></asp:TableRow>

        <asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="deliveryLabel" Text="Koszt wysyłki " Font-Bold="true"  runat="server"/>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="deliveryTextBox" Text="" Width="400px" runat="server"  AutoPostBack="false"/>
                <asp:RegularExpressionValidator ID="deliveryRegExValidator" runat="server" Font-Bold="true" ForeColor="DarkRed" 
                    ControlToValidate="deliveryTextBox" ValidationExpression="^(\d)+(,(\d)+)?$" ErrorMessage="Zly format waluty"/>
                <asp:RequiredFieldValidator ID="deliveryFieldValidator" runat="server" 
                    ControlToValidate="deliveryTextBox" ErrorMessage="Can't be empty" /><br />
            </asp:TableCell></asp:TableRow>

        <asp:TableRow Height="50px" runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="expireTimeLabel" Text="Czas trwania aukcji (liczba dni)" Font-Bold="true" runat="server"/>
            </asp:TableCell><asp:TableCell runat="server">
                <asp:TextBox ID="expireTimeEditBox" Text="" Width="400px" TextMode="Number" runat="server"  AutoPostBack="false"/>
                <asp:RegularExpressionValidator ID="expireTimeRegExValidator" runat="server" Font-Bold="true" ForeColor="DarkRed" 
                    ControlToValidate="expireTimeEditBox" ValidationExpression="^(\d+)$" ErrorMessage="Podaj liczbe calkowita"/>
                <asp:RequiredFieldValidator id="expireTimeFieldValidator" runat="server" 
                    ControlToValidate="expireTimeEditBox">Wpisz liczbę</asp:RequiredFieldValidator><br />
            </asp:TableCell>
        </asp:TableRow></asp:Table><asp:Button ID="btnCreateAuction" OnClick="CreateAuctionClick" runat="server" Text="Utwórz aukcje" CssClass="btn btn-default" />
    </asp:Panel>


</asp:Content>