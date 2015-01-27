<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BiedaClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Image ID="Image1" runat="server" ImageUrl="~/logo.jpg"/>

    <asp:Panel ID="Panel1" runat="server" Height="20px"></asp:Panel>
    
    <%-- FORMULARZ WYSZUKIWANIA --%>


    <asp:Table ID="Table0" runat="server" Width="1190px" Height="139px" CellPadding="10" CellSpacing="10" BackColor="#FFBC79">

    <asp:TableRow runat="server" >

        <asp:TableCell runat="server">
            <asp:Button ID="Button0" runat="server" Text="Wyszukaj aukcje:" Font-Size="X-Large" Font-Names="Calibri" CssClass="btn btn-default"
                BackColor="#FF9933" BorderWidth="4" OnClick="Search_Click"></asp:Button>
        </asp:TableCell>

    </asp:TableRow>
    <asp:TableRow runat="server" >

        <asp:TableCell runat="server">
            <asp:Label ID="Label01" runat="server" Text="" Font-Size="Larger" Font-Names="Calibri" Width="300" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Label ID="Label02" runat="server" Text="kategoria" Font-Size="Larger" Font-Names="Calibri" Width="100" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Label ID="Label03" runat="server" Text="sortuj" Font-Size="Larger" Font-Names="Calibri" Font-Bold="True" Width="80"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:Label ID="Label04" runat="server" Text="kierunek" Font-Size="Larger" Font-Names="Calibri" Font-Bold="True" Width="80"></asp:Label>
        </asp:TableCell>

    </asp:TableRow>
    <asp:TableRow runat="server" >

        <asp:TableCell runat="server">
            <asp:TextBox ID="TextBox_haslo" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="Wpisz hasło wyszukiwania" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:DropDownList ID="DropDownList_kategoria" runat="server" Height="40" Width="200" Font-Size="Larger" AutoPostBack="false">
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:DropDownList ID="DropDownList_sortuj" runat="server" Height="40" Width="150" Font-Size="Larger" AutoPostBack="false">
                <asp:ListItem Text="Cena"></asp:ListItem>
                <asp:ListItem Text="Data zakończenia"></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:DropDownList ID="DropDownList_kierunek" runat="server" Height="40" Width="150" Font-Size="Larger" AutoPostBack="false">
                <asp:ListItem Text="Rosnąco"></asp:ListItem>
                <asp:ListItem Text="Malejąco"></asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>

    </asp:TableRow>
    <asp:TableRow Height="20">
        </asp:TableRow>

    </asp:Table>
    <br />

    <asp:Table ID="Table1" runat="server" BackColor="#FF9933" Font-Bold="true" Font-Size="11" ForeColor="Black" GridLines="None" 
        HorizontalAlign="Left" BorderStyle="Solid" BorderColor="#FFBC79" BorderWidth="50" CellPadding="4" CellSpacing="1">

        <%-- PIERWSZY WIERSZ (NAZWY PÓL) --%>

        <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

            <asp:TableCell runat="server" BackColor="#FFCC66">
                <asp:Label ID="Label5" runat="server" Text="Sprzedający: " Font-Size="Large" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server" BackColor="#FFFF66">
                <asp:Label ID="Label6" runat="server" Text="Data zakończenia: " Font-Size="Large" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server" BackColor="#FFFF99">
                <asp:Label ID="Label7" runat="server" Text="Nazwa: " Font-Size="Large" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server" BackColor="#FFFFCC">
                <asp:Label ID="Label8" runat="server" Text="Cena startowa: " Font-Size="Large" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server" BackColor="White">
                <asp:Label ID="Label9" runat="server" Text="Cena wysyłki: " Font-Size="Large" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server" BackColor="#CCFFFF">
                <asp:Label ID="Label10" runat="server" Text="Ocena sprzedawcy: " Font-Size="Large" Font-Bold="True"></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server" BackColor="#66FFFF">
                <asp:Label ID="Label11" runat="server" Text="Najwyższa oferta: " Font-Size="Large" Font-Bold="True"></asp:Label>
            </asp:TableCell>

        </asp:TableRow>

    </asp:Table>   
    

</asp:Content>

