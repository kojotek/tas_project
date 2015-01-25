<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BiedaClient.Auction.AuctionList" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

<br/>
<br/>
<br/>
<br/>
    
    <asp:Panel ID="panelBackground" runat="server" BackColor="#FFBC79" BorderColor="#FFBC79" BorderWidth="20px" Width="1100px" Height="2000px">
    
    <style type="text/css">

        div.auction_list table.content {
            width: 100%;
            border : solid;
        }
        
        div.auction_list table.content tr.header {
            border-bottom : solid;
            background-color : white;
        }

        div.auction_list table.content tr.item {
        }

        div.auction_list table.navbar {
            width: 100%;
        }

        .right {
          text-align: right;
          margin-right: 1em;
        }

        .left {
          text-align: left;
          margin-left: 1em;
        }


    </style>       
<div class="auction_list">
    <table class="header">
    </table>
        
    <table class="content">
	    <tr class="header">
            <th class="name">Nazwa produktu</th>
		    <th class="id">Identyfikator aukcji</th>
		    <th class="cat">Nazwa kategorii</th>
		    <th class="price">Cena startowa</th>
		    <th class="time">Czas trwania</th>
	    </tr>

	    <% var auctionIdList = biedaWebService.getAuctionListbyUserId(Context.User.Identity.Name);
        var categoryList = biedaWebService.getAuctionCategoryList();

        rowCount = 20;
        rowIndex = 0;
    
        if (Request["row_index"] != null)
            int.TryParse(Request["row_index"], out rowIndex);

        if (Request["row_count"] != null)
            int.TryParse(Request["row_count"], out rowCount);

        for (int i = 0, j = rowIndex; i < rowCount && j < auctionIdList.Length; j++, i++)
        {
            var auctionId = auctionIdList[j];
            var auction = biedaWebService.getAuctionById(auctionId);%>
	    <tr class="<%=i%2==1?"odd-":""%>item">
            <td class="name"><%=auction.nazwa_produktu%></td>
		    <td class="id"><a href="<%=ResolveClientUrl("~/About?numer=")+auctionId%>"><%=auctionId%></a></td>
		    <td class="cat"><%=categoryList.Where(x=>x.Id==auction.id_kategoria).Select(x=>x.Name).FirstOrDefault()%></td>
		    <td class="price"><%=auction.cena_startowa.ToString("#.##")%></td>
		    <td class="time"><%=auction.data_zakonczenia%></td>
	    </tr>
	    <%}%>
    </table>

    <table class="navbar">
        <tr>
            <td class="left item"><asp:Button ID="btnPrevPage" Text="Poprzednia strona" runat="server" OnClick="AuctionListPrevPage" /></td>
            <td class="right item"><asp:Button ID="btnNextPage" Text="Następna strona" runat="server" OnClick="AuctionListNextPage" /></td>
        </tr>
    </table>

    <table class="footer">
    </table>
</div>
        
	
    
    </asp:Panel>
    

</asp:Content>
