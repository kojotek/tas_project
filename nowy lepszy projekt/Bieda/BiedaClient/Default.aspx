<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BiedaClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1>BIEDA.pl</h1>
        <p class="lead">BIEDA.pl to fantastyczny serwis aukcyjny dla ludzi bez pieniędzy.</p>
    </div>

    
    <%-- FORMULARZ WYSZUKIWANIA --%>


    <asp:Table ID="Table0" runat="server" Width="1190px" Height="139px" CellPadding="10" CellSpacing="10" BackColor="#FFCC66">

    <asp:TableRow runat="server" >

        <asp:TableCell runat="server">
            <asp:Button ID="Button0" runat="server" Text="Wyszukaj aukcje:" Font-Size="X-Large" Font-Names="Calibri" CssClass="btn btn-default"
                BackColor="#FF9933" BorderWidth="4"></asp:Button>
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
            <asp:DropDownList ID="DropDownList_kategoria" runat="server" Height="40" Width="200" Font-Size="Larger"></asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:DropDownList ID="DropDownList_sortuj" runat="server" Height="40" Width="150" Font-Size="Larger"></asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell runat="server">
            <asp:DropDownList ID="DropDownList_kierunek" runat="server" Height="40" Width="150" Font-Size="Larger"></asp:DropDownList>
        </asp:TableCell>

    </asp:TableRow>
    <asp:TableRow Height="20">
        </asp:TableRow>

    </asp:Table>
    <br />


    <%-- TABELA --%>


    <asp:Table ID="Table1" runat="server" Width="1036px" Height="739px" CellPadding="10" CellSpacing="10">

    <%-- PIERWSZY WIERSZ (NAZWY PÓL) --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:Label ID="Label1" runat="server" Text="Sprzedający: " Font-Size="Large" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:Label ID="Label2" runat="server" Text="Data zakończenia: " Font-Size="Large" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:Label ID="Label3" runat="server" Text="Nazwa: " Font-Size="Large" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:Label ID="Label4" runat="server" Text="Cena startowa: " Font-Size="Large" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:Label ID="Label5" runat="server" Text="Cena wysyłki: " Font-Size="Large" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:Label ID="Label6" runat="server" Text="Ocena sprzedawcy: " Font-Size="Large" Font-Bold="True"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:Label ID="Label7" runat="server" Text="Najwyższa oferta: " Font-Size="Large" Font-Bold="True"></asp:Label>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- DRUGI WIERSZ (PIERWSZY RZĄD TEXTBOXÓW)--%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox01" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox02" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox03" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox04" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox05" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox06" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox07" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- TRZECI WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox11" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox12" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox13" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox14" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox15" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox16" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox17" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- CZWARTY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox21" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox22" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox23" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox24" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox25" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox26" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox27" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- PIĄTY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox31" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox32" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox33" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox34" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox35" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox36" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox37" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow> 
        
    <%-- SZÓSTY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox41" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox42" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox43" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox44" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox45" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox46" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox47" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>   

    <%-- SIÓDMY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox51" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox52" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox53" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox54" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox55" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox56" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox57" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- ÓSMY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox61" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox62" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox63" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox64" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox65" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox66" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox67" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- DZIEWIĄTY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox71" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox72" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox73" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox74" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox75" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox76" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox77" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  


    <%-- DZIESIĄTY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox81" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox82" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox83" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox84" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox85" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox86" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox87" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- JEDENASTY WIERSZ --%>

    <asp:TableRow runat="server" BorderStyle="Solid" BorderColor="Black">

        <asp:TableCell runat="server" BackColor="#FFCC66">
            <asp:TextBox ID="TextBox91" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFCC66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF66">
            <asp:TextBox ID="TextBox92" runat="server" BorderStyle="Solid" Width="150px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF66" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFF99">
            <asp:TextBox ID="TextBox93" runat="server" BorderStyle="Solid" Width="300px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFF99" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#FFFFCC">
            <asp:TextBox ID="TextBox94" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#FFFFCC" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="White">
            <asp:TextBox ID="TextBox95" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="White" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#CCFFFF">
            <asp:TextBox ID="TextBox96" runat="server" BorderStyle="Solid" Width="75px" Height="40px"
                Text="" Font-Size="Large" BackColor="#CCFFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell runat="server" BackColor="#66FFFF">
            <asp:TextBox ID="TextBox97" runat="server" BorderStyle="Solid" Width="125px" Height="40px"
                Text="" Font-Size="Large" BackColor="#66FFFF" CssClass="form-control"></asp:TextBox>
        </asp:TableCell>

    </asp:TableRow>  

    <%-- BUTTONY --%>

    <asp:TableRow runat="server">

    </asp:TableRow>


    <%-- KONIEC TABELI--%>
    
    
    </asp:Table>
  

</asp:Content>

