<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BiedaClient.Auction.AuctionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

<br/>
<br/>
<br/>
<br/>
    
    <asp:Panel ID="panelBackground" runat="server" BackColor="#FFBC79" BorderColor="#FFBC79" BorderWidth="20px" Width="1100px" Height="2000px">
    
    <style type="text/css">

        table tr td {
            cursor : pointer;
        }

        div.auction_list table {
            width: 100%;
        }
        
        div.auction_list table.content {
            border : solid;
            border-color : black;
            border-width : 1px;
        }

        div.auction_list table tr.header {
            border-bottom : solid;
            border-bottom-width : 1px;
            border-bottom-color : black;
            background-color : white;
            text-align : center;
        }

        div.auction_list table tr td.lp {
            text-align : left;
            padding-left : 0;
            font-size : smaller;
        }

        div.auction_list table.content tr.header {
            border-bottom : solid;
            border-width : 2px;
        }

        div.auction_list table.content tr.item td{
            background-color : white;
            padding-left: 1em;
        }

        div.auction_list table.content tr.odd-item td{
            background-color: lightgray;
            padding-left: 1em;
        }

        div.auction_list table.content tr.item:hover td,
        div.auction_list table.content tr.odd-item:hover td{
            background-color : yellow;
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
            <th class="lp">Lp.</th>
            <th class="name">Nazwa produktu</th>
		    <th class="id">Identyfikator aukcji</th>
		    <th class="cat">Nazwa kategorii</th>
		    <th class="price">Cena startowa</th>
		    <th class="price">Najwyższa oferta (zł)</th>
		    <th class="time">Czas trwania</th>
	    </tr>

	    <%
        var biedaWebService = new BiedaServiceClient();
        var auctionIdList = biedaWebService.getAuctionListbyUserId(Context.User.Identity.Name);
        var categoryList = biedaWebService.getAuctionCategoryList();

        int rowCount = 20;
        int rowIndex = 0;
    
        
        if (Request.QueryString["row_index"] != null)
            int.TryParse(Request.QueryString["row_index"], out rowIndex);
            

        if (Request.QueryString["row_count"] != null)
            int.TryParse(Request.QueryString["row_count"], out rowCount);
            
        Session["row_index"] = rowIndex;
        Session["row_count"] = rowCount;

        for (int i = 0, j = rowIndex; i < rowCount && j < auctionIdList.Length; j++, i++)
        {
            var auctionId = auctionIdList[j];
            var auction = biedaWebService.getAuctionById(auctionId);
            var catNameList = categoryList.Where(x => x.Id == auction.id_kategoria);
            var catName = categoryList.Where(x => x.Id == auction.id_kategoria).Select(x => x.Name).FirstOrDefault();
            var offerText = biedaWebService.getAuctionHighestOffer(auctionId);
            decimal offerNum = 0.0m;
            decimal.TryParse(offerText, out offerNum);
            %>

	    <tr class="<%=i%2==1?"odd-":""%>item" onclick="document.location = '<%=ResolveClientUrl("~/About?numer=")+auctionId%>';">
            <td class="lp"><%=i.ToString() %></td>
            <td class="name"><%=auction.nazwa_produktu%></td>
		    <td class="id"><%=auctionId%></td>
		    <td class="cat"><%=categoryList.Where(x=>x.Id==auction.id_kategoria).Select(x=>x.Name).FirstOrDefault()%></td>
		    <td class="price"><%=auction.cena_startowa.ToString("#.##")%></td>
		    <td class="price"><%=offerNum.ToString("#.##")%></td>
		    <td class="time"><%=auction.data_zakonczenia%></td>
	    </tr>
	    <%}%>
    </table>

    <table class="navbar">
        <tr>
            <td class="left item nav_button"><asp:Button ID="btnPrevPage" Text="Poprzednia strona" runat="server"  OnClick="AuctionListPrevPage" /></td>
            <td class="right item nav_button"><asp:Button ID="btnNextPage" Text="Następna strona" runat="server" OnClick="AuctionListNextPage" /></td>
        </tr>
    </table>

    <table class="footer">
    </table>
</div>
        
	
    
    </asp:Panel>
    

</asp:Content>
