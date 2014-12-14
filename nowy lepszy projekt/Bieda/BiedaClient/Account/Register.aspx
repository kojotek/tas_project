<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BiedaClient.Account.Register" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<br />
<br />
<h4>Załóż własne konto w czterech prostych krokach!</h4>

<asp:Table ID="Table1" runat="server" Width="1036px" Height="1039px" CellPadding="30" CellSpacing="0">
    <asp:TableRow runat="server" >
        <asp:TableCell runat="server" BackColor="#FFBC79">
            <asp:Panel ID="Panel1" runat="server" Height="500px" Width="500px">
                <asp:Panel ID="Panel1_1" runat="server">

                <asp:Label ID="Panel1Title" runat="server" Text="Krok I: Dane konta" Width="500px" Font-Size="XX-Large"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Login: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="login" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Haslo: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="haslo" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large"  BackColor="#FFBC79" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Powtorz Haslo: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="powtorz_haslo" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FFBC79" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="next1" runat="server" BorderStyle="Solid" Height="60px" Text="DALEJ" CssClass="btn btn-default"
                Font-Size="X-Large" Width="300px" BackColor="#FFBC79" OnClick="next1_Click" />
                <br />
                <asp:Label ID="Panel1ErrorMsg" runat="server" Text="" Font-Size="Large" Visible="false"></asp:Label>
                    
                </asp:Panel>
            </asp:Panel>
        </asp:TableCell>
        
        <asp:TableCell runat="server" BackColor="#FF9D3C">
            <asp:Panel ID="Panel2" runat="server" Height="500px" Width="500px">
                <asp:Panel ID="Panel2_1" runat="server" Visible="false">
                
                <asp:Label ID="Panel2Title" runat="server" Text="Krok II: Dane osobowe" Width="500px" Font-Size="XX-Large"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Imie: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="imie" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Nazwisko: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="nazwisko" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label6" runat="server" Text="E-mail: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="email" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large"  BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Telefon: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="telefon" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <a href="#GoToPanel3"><asp:Button ID="next2" runat="server" BorderStyle="Solid" Height="60px" Text="DALEJ" CssClass="btn btn-default"
                Font-Size="X-Large" Width="300px" BackColor="#FF9D3C" OnClick="next2_Click" /></a>
                <br />
                <asp:Label ID="Panel2ErrorMsg" runat="server" Text="" Font-Size="Large" Visible="false"></asp:Label>
            
                </asp:Panel>                    
            </asp:Panel>
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow runat="server">
        <asp:TableCell runat="server" BackColor="#FF9D3C">
            <asp:Panel ID="Panel3" runat="server" Height="700px" Width="500px">
                <asp:Panel ID="Panel3_1" runat="server" Visible="false">

                <asp:Label ID="Panel3Title" runat="server" Text="Krok III: Dane adresowe" Width="500px" Font-Size="XX-Large"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" Text="Kraj: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="kraj" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Miasto: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="miasto" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label11" runat="server" Text="Kod pocztowy: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="kod" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large"  BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label12" runat="server" Text="Ulica: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="ulica" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Numer domu: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="dom" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label13" runat="server" Text="Numer mieszkania: " Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="mieszkanie" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Button ID="next3" runat="server" BorderStyle="Solid" Height="60px" Text="DALEJ" CssClass="btn btn-default"
                Font-Size="X-Large" Width="300px" BackColor="#FF9D3C" OnClick="next3_Click" />
                <br />
                <asp:Label ID="Panel3ErrorMsg" runat="server" Text="" Font-Size="Large" Visible="false"></asp:Label>
            
                </asp:Panel>
            </asp:Panel>
        </asp:TableCell>

        <asp:TableCell runat="server" BackColor="#FFBC79">
            <asp:Panel ID="Panel4" runat="server" Height="700px" Width="500px">
                <asp:Panel ID="Panel4_1" runat="server" Visible="false">

                <asp:Label ID="Panel4Title" runat="server" Text="Krok IV: Warunki koncowe" Width="500px" Font-Size="XX-Large"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label14" runat="server" Text="Zgadzam sie z postanowieniami regulaminu " Font-Size="Large"></asp:Label>
                <asp:CheckBox ID="reg_check" runat="server" BackColor="#FFBC79" />
                <br />
                <br />
                <asp:Label ID="Label15" runat="server" Text="Oswiadczam ze nie jestem botem " Font-Size="Large"></asp:Label>
                <asp:CheckBox ID="bot_check" runat="server" BackColor="#FFBC79" />
                <br />
                <br />
                <asp:Button ID="register" runat="server" BorderStyle="Solid" Height="60px" Text="ZAREJESTRUJ" CssClass="btn btn-default"
                Font-Size="X-Large" Width="300px" BackColor="#FFBC79" OnClick="register_Click" />
                <br />
                <asp:Label ID="Panel4ErrorMsg" runat="server" Text="" Font-Size="Large" Visible="false"></asp:Label>
             
                </asp:Panel>           
            </asp:Panel>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

</asp:Content>