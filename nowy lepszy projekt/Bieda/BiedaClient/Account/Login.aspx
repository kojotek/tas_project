<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BiedaClient.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <br />
    <br />
    <br />

    <asp:Table ID="Table1" runat="server" Width="1036px" Height="1039px" CellPadding="30" CellSpacing="0">
    <asp:TableRow runat="server" >
        <asp:TableCell runat="server" BackColor="#FFBC79">
            <asp:Panel ID="Panel1" runat="server" Height="500px" Width="500px">

                <asp:Label ID="Panel1Title" runat="server" Text="Zaloguj sie użytkowniku:" Width="500px" Font-Size="XX-Large"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Login: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="UserName" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Haslo: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="Password" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large"  BackColor="#FFBC79" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="zaloguj" runat="server" BorderStyle="Solid" Height="60px" Text="ZALOGUJ" CssClass="btn btn-default"
                Font-Size="X-Large" Width="200px" BackColor="#FFBC79" OnClick="LogIn" />
                <br />
                <asp:Label ID="ErrorMsg" runat="server" Text="" Font-Size="Large" Visible="false"></asp:Label>
                <br />
                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label runat="server" AssociatedControlID="RememberMe">Zapamiętaj mnie</asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Zarejestruj się</asp:HyperLink> jeśli nie masz u nas konta.
                </p>
                    
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
