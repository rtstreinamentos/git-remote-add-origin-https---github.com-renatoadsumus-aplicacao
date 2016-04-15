<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
	CodeBehind="guia-empresas-profissionais.aspx.cs" Inherits="OrcamentoNet.View.Guia" %>

<%@ OutputCache Duration="14400" VaryByParam="categoria;cidade" %>

<%@ Register Src="controles/DepoimentoOrcamentoOnline.ascx" TagName="DepoimentoOrcamentoOnline"
	TagPrefix="uc1" %>
<%@ Register Src="controles/FornecedoresControle.ascx" TagName="FornecedoresControle"
	TagPrefix="uc3" %>
<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
	TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
	runat="server">
	<div class="productHeadingType1">
		<div style="float: left;">
			<img src="/img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
				class="productImg fl" /><br />&nbsp;<br />

			<script type="text/javascript"><!--
				google_ad_client = "ca-pub-9502900066313233";
				/* Box Esquerda */
				google_ad_slot = "8491994707";
				google_ad_width = 250;
				google_ad_height = 250;
			//-->
			</script>

			<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
			</script>

		</div>
		<div class="productText fl">
			<h1 id="uxTituloH1" runat="server">
			</h1>
			<uc5:mensagemsuperiorcontrole ID="MensagemSuperiorControle1" runat="server" />
			<ul class="checkList">
				<li>Ganhe tempo. Orçamentos rápidos!</li>
				<li>Vários fornecedores num só lugar</li>
				<li>Formulário ajuda você a pedir o orçamento</li>
				<li>Você fala diretamente com os fornecedores</li>
				<li>Muitos ramos de atividade</li>
				<li>Grátis!</li>
			</ul>
		</div>
		<div class="productPrice fr">
			<div class="productPriceContainer">
				<span>Grátis!</span>
				<p>
					solicite seu orçamento grátis</p>
				<div id="buttonDarkBG">
					<a class="buttonLink" href="/orcamento-online.aspx#listaOrcamentos" title="Solicite seu orçamento online de graça">
						Quero um Orçamento</a>
				</div>
				<!-- end buttonDarkBG -->
			</div>
			<!-- end productPriceContainer -->
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
		runat="server" ID="uxrptCategorias" CellPadding="8" CellSpacing="4" ItemStyle-VerticalAlign="Top"
		Width="100%" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="33%">
		<HeaderTemplate>
			<h2>
				Categorias do Guia de Empresas e Profissionais</h2>
		</HeaderTemplate>
		<ItemTemplate>
			<h3 style="margin: 30px 0 8px 0;">
				<a href='/guia-<%#Eval("UrlSEO")%>' title='Guia de Empresas e Profissionais em <%#Server.HtmlEncode(Eval("Nome").ToString())%>'>
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
	<div class="FornecedoresRecentes">
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
	<div class="FornecedoresRecentes">
		<h2>
			Últimos Depoimentos de Clientes</h2>
		<uc1:DepoimentoOrcamentoOnline ID="DepoimentoOrcamentoOnline1" runat="server" />
	</div>
	<!-- Product Buy Button Section Starts Here -->
	<div class="bigBuyButton">
		<a href="/orcamento-online.aspx" title="Solicite seu Orçamento Online" class="buttonLinkWithImage">
			Quero pedir um Orçamento Online grátis<img src="/img/buttonArrow.png" alt="Arrow Button"
				id="arrowButtonFixPNG" /></a>
	</div>
	<!-- end bigBuyButton -->
</asp:Content>
