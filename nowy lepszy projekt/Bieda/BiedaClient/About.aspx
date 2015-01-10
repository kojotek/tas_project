<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BiedaClient.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    <asp:Panel ID="Panel1" runat="server" BackColor="#FFBC79" BorderColor="#FFBC79" BorderWidth="20px" Width="1100px">
    <br />
    <br />
    <br />
    
        <div align="right"><asp:Label ID="LabelTime" runat="server" Text="Label" align="right" Font-Size="10"></asp:Label></div>

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow runat="server" >
            <asp:TableCell runat="server" Width="700">
                <asp:Label ID="LabelLogin" runat="server" Text="Label" Font-Bold="false" Font-Size="10"></asp:Label>
                <br />
                <asp:Label ID="LabelName" runat="server" Text="Label" Font-Bold="True" Font-Underline="True" Font-Size="25pt" Width="500px"></asp:Label><br />
                <br />
                <br />
                <asp:Label ID="Labeltemp1" runat="server" Text="Obecna cena:" Font-Bold="True" Font-Size="12pt"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelPrice" runat="server" Text="Label" Font-Bold="True" Font-Size="12pt"></asp:Label>
                <br />
                <asp:Label ID="LabelTemp2" runat="server" Text="Cena wysyłki:" Font-Bold="True" Font-Size="12pt"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelSendPrice" runat="server" Text="Label" Font-Bold="True" Font-Size="12pt"></asp:Label><br />
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Left">
                <asp:TextBox ID="oferta" runat="server" BorderStyle="Solid" Width="300px" Height="60px"
                Text="kwota" Font-Size="X-Large" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Button ID="zlozOferte" runat="server" BorderStyle="Solid" Height="60px" Text="ZŁÓŻ OFERTĘ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="300px" BackColor="#FFBC79" OnClick="zlozOferte_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:Label ID="LabelTemp4" runat="server" Text="Opis produktu:" Font-Bold="True" Font-Size="12pt"></asp:Label><br />

    <asp:Label ID="TextBoxDescription" runat="server" ReadOnly="True" MaxLength="80" Height="100px" Width="500px"></asp:Label><br />

    </asp:Panel>
</asp:Content>
