<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
	CodeBehind="mapa.aspx.cs" Inherits="OrcamentoNet.View.orcamento_online_mapa_site" %>

<%@ OutputCache Duration="86400" VaryByParam="none" %>

<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
	TagPrefix="uc2" %>
<%@ Register Src="/controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
	TagPrefix="uc2" %>
<%@ Register Src="/controles/FornecedoresControle2.ascx" TagName="FornecedoresControle"
	TagPrefix="uc3" %>
<%@ Register Src="/controles/DepoimentoOrcamentoOnline.ascx" TagName="DepoimentoOrcamentoOnline"
	TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
	runat="server">
	<div class="productHeadingType3">
		<div style="float: left;">
			<img src="/img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
				class="productImg fl" />
		</div>
		<div class="productText fl">
			<h1 id="uxTituloH1" runat="server">
			</h1>
			<uc2:mensagemsuperiorcontrole ID="MensagemSuperiorControle1" runat="server" />
			<!-- Product Buy Button Section Starts Here -->
			<div class="bigBuyButton">
				<a href="/orcamento-online.aspx" title="Solicite seu Orçamento Online" class="buttonLinkWithImage">
					Quero pedir um Orçamento Online grátis<img src="/img/buttonArrow.png" alt="Arrow Button"
						id="arrowButtonFixPNG" /></a>
			</div>
			<!-- end bigBuyButton -->
			<!-- Product Buy Button Section Starts Here -->
			<div class="bigBuyButton">
				<a href="/cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos"
					class="buttonLinkWithImage">Quero me cadastrar no Orçamento Online<img src="/img/buttonArrow.png"
						alt="Arrow Button" id="arrowButtonFixPNG" /></a>
			</div>
			<!-- end bigBuyButton -->
			<!-- end productText -->
		</div>
		<!-- end productPrice -->
	</div>
	<!-- end productHeadingType3 -->
	<div class="horizontalSep">
		<!-- -->
	</div>

	<div style="margin-bottom: 24px;">
		<center>
		<script type="text/javascript"><!--
			google_ad_client = "ca-pub-9502900066313233";
			/* Banner Topo */
			google_ad_slot = "2585061900";
			google_ad_width = 728;
			google_ad_height = 90;
		//-->
		</script>
		<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
		</script>
		</center>
	</div>	
	
	<asp:DataList RepeatLayout="Table" RepeatColumns="3" RepeatDirection="Horizontal"
		runat="server" ID="uxrptCategoriasColuna1" CellPadding="8" CellSpacing="4" ItemStyle-VerticalAlign="Top"
		Width="100%" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="33%">
		<HeaderTemplate>
			<h2>
				Categorias de Empresas, Profissionais e Oportunidades de Negócio</h2>
		</HeaderTemplate>
		<ItemTemplate>
			<h3 style="margin: 30px 0 8px 0;">
				<a href='/mapa-<%#Eval("UrlSEO")%>' title='Empresas, Profissionais e Oportunidades de Negócio em <%#Server.HtmlEncode(Eval("Nome").ToString())%>'>
					<%#Server.HtmlEncode(Eval("Nome").ToString())%></a></h3>
			<ul class="checkList">
				<asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
					<ItemTemplate>
						<li style="margin: 0 6px 6px 0;">
							<%#Server.HtmlEncode(Eval("Nome").ToString())%></li>
					</ItemTemplate>
				</asp:Repeater>
			</ul>
		</ItemTemplate>
	</asp:DataList>
	<div class="horizontalSep">
		<!-- -->
	</div>
	<div style="margin-bottom: 24px;">
		<center>
		<script type="text/javascript"><!--
			google_ad_client = "ca-pub-9502900066313233";
			/* Banner Rodapé Largo */
			google_ad_slot = "5398927505";
			google_ad_width = 970;
			google_ad_height = 90;
		//-->
		</script>
		<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>
		</center>
	</div>
	<div class="FornecedoresRecentes">
		<h2>
			Últimas Empresas e Profissionais</h2>
		<uc3:FornecedoresControle ID="FornecedoresControle1" runat="server" />
		<center>
		<script type="text/javascript"><!--
			google_ad_client = "ca-pub-9502900066313233";
			/* Banner Rodapé Largo */
			google_ad_slot = "5398927505";
			google_ad_width = 970;
			google_ad_height = 90;
		//-->
		</script>
		<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>
		</center>
		<!-- Product Buy Button Section Starts Here -->
		<div class="bigBuyButton">
			<a href="/cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos"
				class="buttonLinkWithImage">Sou fornecedor e Quero me cadastrar no Orçamento Online<img
					src="/img/buttonArrow.png" alt="Arrow Button" id="arrowButtonFixPNG" /></a>
		</div>
		<!-- end bigBuyButton -->
	</div>
	<div class="horizontalSep">
		<!-- -->
	</div>
	<div id="PedidosOrcamentoRecentes">
		<h2>
			Últimas Oportunidades de Negócio</h2>
		<uc2:PedidosOrcamentoControle ID="PedidosOrcamentoControle1" runat="server" />
	</div>
	<div class="horizontalSep">
		<!-- -->
	</div>
	<div class="FornecedoresRecentes">
		<h2>
			Últimos Depoimentos de Clientes</h2>
		<uc4:DepoimentoOrcamentoOnline ID="DepoimentoOrcamentoOnline1" runat="server" />
	</div>
	<!-- Product Buy Button Section Starts Here -->
	<div class="bigBuyButton">
		<a href="/orcamento-online.aspx" title="Solicite seu Orçamento Online" class="buttonLinkWithImage">
			Quero pedir um Orçamento Online grátis<img src="/img/buttonArrow.png" alt="Arrow Button"
				id="arrowButtonFixPNG" /></a>
	</div>
	<!-- end bigBuyButton -->
</asp:Content>
