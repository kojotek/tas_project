<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="BiedaClient.Account.Manage"%>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <br/>
    <br/>
    <br/>
    <asp:Label ID="ErrorMsg" runat="server" Text="Error" Font-Size="Large" ForeColor="#FF3300" Visible="false"></asp:Label>

    <asp:Table ID="Table1" runat="server" Width="1036px" Height="1036px" CellPadding="30" CellSpacing="0">


        <asp:TableRow runat="server" >

            <asp:TableCell runat="server" BackColor="#FFBC79">
                <asp:Panel ID="Panel2" runat="server" Height="500px" Width="500px">

                    <asp:Label ID="Label1" runat="server" Text="Dane Twojego Konta" Width="500px" Font-Size="XX-Large"></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Login: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="login" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                    

                    
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Data przystąpienia: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="data_od" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>

                    <br />
                    <asp:Label ID="nr_konta_label" runat="server" Text="Numer konta bankowego: " Font-Size="Large" Visible = "false"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="nr_konta" runat="server" BorderStyle="None" Width="500px" Height="40px" Visible = "false"
                    Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>

                    <asp:Panel ID="przepychacz" runat="server" Height="105px"></asp:Panel>

                    <asp:Button ID="edit0" runat="server" BorderStyle="Solid" Height="60px" Text="EDYTUJ" CssClass="btn btn-default"
                    Visible = "false" Font-Size="X-Large" Width="300px" BackColor="#FFBC79" OnClick="edit0_Click" />

                    <asp:Button ID="edit0_ok" runat="server" BorderStyle="Solid" Height="60px" Text="ZAPISZ" CssClass="btn btn-default"
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FFBC79" OnClick="edit0_ok_Click" />

                    <asp:Button ID="edit0_cancel" runat="server" BorderStyle="Solid" Height="60px" Text="ANULUJ" CssClass="btn btn-default"
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FFBC79" OnClick="edit0_cancel_Click" />
                    

                </asp:Panel>
            

</asp:TableCell>

            <asp:TableCell runat="server" BackColor="#FF9D3C">
                <asp:Panel ID="Panel3" runat="server" Height="500px" Width="500px">
                    <asp:Label ID="Label2" runat="server" Text="Twoje Dane Kontaktowe" Width="500px" Font-Size="XX-Large"></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Imię: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="imie" runat="server" BorderStyle="None" Width="500px" Height="40px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                    

                    
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Nazwisko: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="nazwisko" runat="server" BorderStyle="None" Width="500px" Height="40px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                    

                    
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="E-mail:  " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="email" runat="server" BorderStyle="None" Width="500px" Height="40px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                    

                    
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Telefon " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="telefon" runat="server" BorderStyle="None" Width="500px" Height="40px" 
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                    

                    
                    <br />
                    <asp:Button ID="edit1" runat="server" BorderStyle="Solid" Height="60px" Text="EDYTUJ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="300px" BackColor="#FF9D3C" OnClick="edit1_Click" />

                    <asp:Button ID="edit1_ok" runat="server" BorderStyle="Solid" Height="60px" Text="ZAPISZ" CssClass="btn btn-default"
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="edit1_ok_Click" />

                    <asp:Button ID="edit1_cancel" runat="server" BorderStyle="Solid" Height="60px" Text="ANULUJ" CssClass="btn btn-default"
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="edit1_cancel_Click" />
                    
         </asp:Panel>
        

</asp:TableCell>

        </asp:TableRow>

        <asp:TableRow runat="server">

            <asp:TableCell runat="server" BackColor="#FF9D3C">
                <asp:Panel ID="Panel4" runat="server" Width="500px" Height="700px">
                    <asp:Label ID="Label3" runat="server" Text="Ustawienia Konta" Width="500px" Font-Size="XX-Large" ></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Label ID="ustawieniaKontaMsg" runat="server" Text="" Font-Size="Large" Visible="false"></asp:Label>
                    <br />
                    
                <asp:Panel ID="changePassword" runat="server" Width="500px" Visible="false">

                    <asp:Label ID="oldPassLabel" runat="server" Text="Obecne Haslo: " Font-Size="Large"></asp:Label>
                    <br />
                    
                    <asp:TextBox ID="oldPassT_Box" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                     Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <br />

                    <asp:Label ID="newPassLabel" runat="server" Text="Nowe Haslo: " Font-Size="Large"></asp:Label>
                    <br />
                    
                    <asp:TextBox ID="newPassT_Box" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                     Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <br />
                    
                    <asp:Label ID="confirmPassLabel" runat="server" Text="Powtorz Haslo: " Font-Size="Large"></asp:Label>
                    <br />
                    
                    <asp:TextBox ID="confirmPassT_Box" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                     Text="" Font-Size="X-Large" BackColor="#FF9D3C" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <br />

                    <asp:Button ID="change_pass_ok" runat="server" BorderStyle="Solid" Height="60px" Text="ZAPISZ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="changePass_ok_Click" />

                    <asp:Button ID="change_pass_cancel" runat="server" BorderStyle="Solid" Height="60px" Text="ANULUJ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="changePass_cancel_Click" />
                    <br />

                </asp:Panel> 
                    
                    <asp:Button ID="change_pass" runat="server" BorderStyle="Solid" Height="60px" Text="ZMIEŃ HASŁO" BackColor="#FF9D3C"
                    Font-Size="X-Large" Width="300px" CssClass="btn btn-default" OnClick="changePass_Click" />           


                <asp:Panel ID="upgradePanel" runat="server">
                    
                    <br />
                    <asp:Button ID="upgrade" runat="server" BorderStyle="Solid" Height="60px" Text="ZOSTAŃ SPRZEDAWCĄ" BackColor="#FF9D3C"
                    Font-Size="X-Large" Width="300px" CssClass="btn btn-default" OnClick="upgradeAcc_Click" />
                </asp:Panel> 
    
                <asp:Panel ID="upgradeAccPanel" runat="server" Width="500px" Visible="false">

                    <asp:Label ID="numerKontaLabel" runat="server" Text="Podaj numer konta bankowego: " Font-Size="Large"></asp:Label>
                    <br />
                    
                    <asp:TextBox ID="numerKontaT_Box" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                     Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control"></asp:TextBox>
                    <br />

                    zgadzam sie aby obciazyc podany wyzej rachunek na 100 zł <asp:CheckBox ID="geszeft" runat="server" />
                    <br />
                    
                    <asp:Button ID="upgradeAcc_ok" runat="server" BorderStyle="Solid" Height="60px" Text="ZAPISZ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="upgradeAcc_ok_Click" />

                    <asp:Button ID="upgradeAcc_cancel" runat="server" BorderStyle="Solid" Height="60px" Text="ANULUJ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="upgradeAcc_cancel_Click" />
                    <br />    

                </asp:Panel> 

                    
                    <br />
                    <asp:Button ID="delete_acc" runat="server" BorderStyle="Solid" Height="60px" Text="USUŃ KONTO" BackColor="#FF9D3C"
                         Font-Size="X-Large" Width="300px" CssClass="btn btn-default" OnClick="deleteAcc_Click" />

                <asp:Panel ID="deleteAccPanel" runat="server" Width="500px" Visible="false">

                    <asp:Label ID="deleteAccLabel" runat="server" Text="Potwierdz operacje wpisujac haslo: " Font-Size="Large"></asp:Label>
                    <br />
                    
                    <asp:TextBox ID="deleteAccT_Box" runat="server" BorderStyle="Solid" Width="500px" Height="40px"
                     Text="" Font-Size="X-Large" BackColor="#FF9D3C" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <br />

                    <asp:Button ID="deleteAccOk" runat="server" BorderStyle="Solid" Height="60px" Text="USUN KONTO" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="deleteAcc_ok_Click" />

                    <asp:Button ID="deleteAccCancel" runat="server" BorderStyle="Solid" Height="60px" Text="ANULUJ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="200px" BackColor="#FF9D3C" OnClick="deleteAcc_cancel_Click" />
                    <br />  
                    
                </asp:Panel>

                    
                    <br />  
                    <br />  
                    
                    <asp:Table ID="Table2" runat="server" BackColor="#FF9933" Font-Bold="true" Font-Size="11" ForeColor="Black" GridLines="None" HorizontalAlign="Left" BorderStyle="Solid" BorderColor="#FFBC79" BorderWidth="8" CellPadding="4" CellSpacing="1"></asp:Table>

                </asp:Panel>

            

</asp:TableCell>

            <asp:TableCell runat="server" BackColor="#FFBC79">
                <asp:Panel ID="Panel5" runat="server" Width="500px" Height="700px">
                    <asp:Label ID="Label4" runat="server" Text="Twoje Dane Adresowe" Width="500px" Font-Size="XX-Large"></asp:Label>
                    

                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Kraj: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="kraj" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                    

              
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Miasto: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="miasto" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                    

                   
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Kod Pocztowy:  " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="kod" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>

                    
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Ulica:  " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="ulica" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                    

                    
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Numer Budynku: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="budynek" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                    

                   
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="Numer Mieszkania: " Font-Size="Large"></asp:Label>
                    

                    <br />
                    <asp:TextBox ID="mieszkanie" runat="server" BorderStyle="None" Width="500px" Height="40px"
                     Text="sdkjfdskfjsdfd" Font-Size="X-Large" ReadOnly="True" BackColor="#FFBC79" CssClass="form-control"></asp:TextBox>
                    

                   
                    <br />
                    <asp:Button ID="edit2" runat="server" BorderStyle="Solid" Height="60px" Text="EDYTUJ" CssClass="btn btn-default"
                    Font-Size="X-Large" Width="300px" BackColor="#FFBC79" OnClick="edit2_Click" />

                    <asp:Button ID="edit2_ok" runat="server" BorderStyle="Solid" Height="60px" Text="ZAPISZ" CssClass="btn btn-default"
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FFBC79" OnClick="edit2_ok_Click" />

                    <asp:Button ID="edit2_cancel" runat="server" BorderStyle="Solid" Height="60px" Text="ANULUJ" CssClass="btn btn-default"
                    Visible = "false" Font-Size="X-Large" Width="200px" BackColor="#FFBC79" OnClick="edit2_cancel_Click" />
                

                

                

                </asp:Panel>
            

</asp:TableCell>

        </asp:TableRow>
      
    </asp:Table>

</asp:Content>
