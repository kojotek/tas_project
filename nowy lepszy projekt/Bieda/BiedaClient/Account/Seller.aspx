<%@ Page Title="Seller" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="BiedaClient.Account.WebForm1" Async="true"%>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <br />
    <asp:Panel ID="NoAccess" runat="server" Width="1119px" Height="200px" BackColor="#FFBC79" HorizontalAlign="Center"> 
        <br/>
        <br />
        <h1>Przejdz do strony <asp:HyperLink runat="server" ID="ManageHyperLink" ViewStateMode="Disabled" NavigateUrl="~/Account/Manage.aspx">zarządzania</asp:HyperLink>&nbsp;by zostać sprzedawcą!</h1>  
    </asp:Panel>

    <asp:Table ID="Access" runat="server" Width="1036px" Height="1039px" CellPadding="30" CellSpacing="0" Visible="false">
        <asp:TableRow runat="server" >
            <asp:TableCell runat="server" BackColor="#FFBC79">
                <asp:Panel ID="Panel1" runat="server" Height="500px" Width="500px"> 
                    
                </asp:Panel>
            </asp:TableCell>
        
            <asp:TableCell runat="server" BackColor="#FF9D3C">
                <asp:Panel ID="Panel2" runat="server" Height="500px" Width="500px">
                 
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server">
            <asp:TableCell runat="server" BackColor="#FF9D3C">
                <asp:Panel ID="Panel3" runat="server" Height="500px" Width="500px">

                </asp:Panel>
            </asp:TableCell>

            <asp:TableCell runat="server" BackColor="#FFBC79">
                <asp:Panel ID="Panel4" runat="server" Height="500px" Width="500px">
        
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
