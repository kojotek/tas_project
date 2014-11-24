<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ProjektBieda.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
    <br/>
    <br/>

    <asp:Panel ID="Panel1" runat="server" Width="1036px">
        <asp:TextBox ID="ErrorMsg" runat="server" BorderStyle="None" Height="28px" ReadOnly="True" Visible="False" Width="212px" TextMode="MultiLine">donna mamma es chujoczita</asp:TextBox>
                    
    </asp:Panel>

    <br/>
    
    <asp:Table ID="Table1" runat="server" Width="1036px" Height="1036px" CellPadding="30" CellSpacing="0">


        <asp:TableRow runat="server" >

            <asp:TableCell runat="server" BackColor="#FFBC79">
                <asp:Panel ID="Panel2" runat="server" Height="450px" Width="500px">
                    <asp:Label ID="Label1" runat="server" Text="Dane Twojego Konta" Width="500px" Font-Size="XX-Large"></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Login: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="login" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Data przystąpienia: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="data_od" runat="server" BorderStyle="None" Width="500px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>
                    
                   

                

                    
                   

                </asp:Panel>
            

</asp:TableCell>

            <asp:TableCell runat="server" BackColor="#FF9D3C">
                <asp:Panel ID="Panel3" runat="server" Height="450px" Width="500px">
                    <asp:Label ID="Label2" runat="server" Text="Twoje Dane Kontaktowe" Width="500px" Font-Size="XX-Large"></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Imię: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="imie" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Nazwisko: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="nazwisko" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="E-mail:  " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="email" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Telefon " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="telefon" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Button ID="edit1" runat="server" BorderStyle="Solid" Height="50px" Text="EDYTUJ" 
                    Font-Size="X-Large" Width="300px" BackColor="#FF9D3C" OnClick="edit1_Click" />

                    <asp:Button ID="edit1_ok" runat="server" BorderStyle="Solid" Height="50px" Text="ZAPISZ" 
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="edit1_ok_Click" />

                    <asp:Button ID="edit1_cancel" runat="server" BorderStyle="Solid" Height="50px" Text="ANULUJ" 
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="edit1_cancel_Click" />
                    
         </asp:Panel>
            

</asp:TableCell>

        </asp:TableRow>

        <asp:TableRow runat="server">

            <asp:TableCell runat="server" BackColor="#FF9D3C">
                <asp:Panel ID="Panel4" runat="server" Height="600px" Width="500px">
                    <asp:Label ID="Label3" runat="server" Text="Ustawienia Konta" Width="500px" Font-Size="XX-Large" ></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Button ID="change_pass" runat="server" BorderStyle="Solid" Height="50px" Text="ZMIEŃ HASŁO" BackColor="#FF9D3C"
                         Font-Size="X-Large" Width="300px" />
                    

                    <br />
                    <br />
                    <asp:Button ID="upgrade" runat="server" BorderStyle="Solid" Height="50px" Text="ZOSTAŃ SPRZEDAWCĄ" BackColor="#FF9D3C"
                         Font-Size="X-Large" Width="300px" />
                    

                    <br />
                    <br />
                    <asp:Button ID="delete_acc" runat="server" BorderStyle="Solid" Height="50px" Text="USUŃ KONTO" BackColor="#FF9D3C"
                         Font-Size="X-Large" Width="300px" />
                

                

                

                </asp:Panel>
            

</asp:TableCell>

            <asp:TableCell runat="server" BackColor="#FFBC79">
                <asp:Panel ID="Panel5" runat="server" Height="600px" Width="500px">
                    <asp:Label ID="Label4" runat="server" Text="Twoje Dane Adresowe" Width="500px" Font-Size="XX-Large"></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Kraj: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="kraj" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Miasto: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="miasto" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Kod Pocztowy:  " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="kod" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>

                    <br />
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Ulica:  " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="ulica" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Numer Budynku: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="budynek" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="Numer Mieszkania: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="mieszkanie" runat="server" BorderStyle="None" Width="500px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79"></asp:TextBox>
                    

                    <br />
                    <br />
                    <asp:Button ID="edit2" runat="server" BorderStyle="Solid" Height="50px" Text="EDYTUJ" 
                    Font-Size="X-Large" Width="300px" BackColor="#FFBC79" OnClick="edit2_Click" />

                    <asp:Button ID="edit2_ok" runat="server" BorderStyle="Solid" Height="50px" Text="ZAPISZ" 
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FFBC79" OnClick="edit2_ok_Click" />

                    <asp:Button ID="edit2_cancel" runat="server" BorderStyle="Solid" Height="50px" Text="ANULUJ" 
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FFBC79" OnClick="edit2_cancel_Click" />
                

                

                

                </asp:Panel>
            

</asp:TableCell>

        </asp:TableRow>
      
    </asp:Table>

</asp:Content>
