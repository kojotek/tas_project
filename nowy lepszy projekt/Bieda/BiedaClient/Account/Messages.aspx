﻿<%@ Page Title="Messages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="BiedaClient.Account.Messages" Async="true"%>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server" Height="500px" Width="1000px" BackColor="#FFBC79" ScrollBars="Vertical" BorderWidth="50px" BorderColor="#FFBC79"> 
        <asp:Table ID="Table2" runat="server" BackColor="#FF9933" Font-Bold="true" Font-Size="11" ForeColor="Black" GridLines="None" HorizontalAlign="Left" BorderStyle="Solid" BorderColor="#FFBC79" BorderWidth="50" CellPadding="4" CellSpacing="1"></asp:Table>
                    
    </asp:Panel>

</asp:Content>
