<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mapa-temas.aspx.cs" MasterPageFile="~/OrcamentoNet2.Master"
	Inherits="OrcamentoNet.View.orcamento_online_temas" %>

<%@ OutputCache Duration="86400" VaryByParam="categoria;cidade;termo;ano;mes;bairro" %>

<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
	TagPrefix="uc22" %>
<%@ Register Src="/controles/CategoriaListaControle.ascx" TagName="CategoriaListaControle"
	TagPrefix="uc1" %>
<%@ Register Src="/controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
	TagPrefix="uc2" %>
<%@ Register Src="controles/FornecedoresControle2.ascx" TagName="FornecedoresControle"
	TagPrefix="uc3" %>
<%@ Register Src="controles/DepoimentoOrcamentoOnline.ascx" TagName="DepoimentoOrcamentoOnline"
	TagPrefix="uc4" %>
<%@ Register Src="controles/LinksInternosTemaCategoria.ascx" TagName="LinksInternosTemaCategoria"
	TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
	runat="server">
	<div class="productHeadingType3">
		<div style="float: left;">
			<img src="/img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
				class="productImg fl" /></div>
		<div class="productText fl">
			<h1 id="uxTituloH1" runat="server">
			</h1>
			<uc22:mensagemsuperiorcontrole ID="MensagemSuperiorControle1" runat="server" />
			<!-- Product Buy Button Section Starts Here -->
			<div class="bigBuyButton">
				<a href="/orcamento-online.aspx" id="uxLinkSolicitarOrcamento" runat="server" title="Solicite seu Orçamento Online"
					class="buttonLinkWithImage">Quero pedir um Orçamento Online grátis<img src="/img/buttonArrow.png"
						alt="Arrow Button" id="arrowButtonFixPNG" /></a>
			</div>
			<!-- end bigBuyButton -->
			<!-- Product Buy Button Section Starts Here -->
			<div class="bigBuyButton">
				<a href="/cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos"
					class="buttonLinkWithImage">Quero me cadastrar no Orçamento Online<img src="/img/buttonArrow.png"
						alt="Arrow Button" id="arrowButtonFixPNG" /></a>
			</div>
			<!-- Controle de Categorias. Só descomentar quando tiver focando em categorias -->
			<%--<uc1:CategoriaListaControle ID="CategoriaListaControle1" runat="server" />--%>
		</div>
	</div>
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
		<h2 id="uxTituloH2UltimasEmpresasProfissionais" runat="server">
		</h2>
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
	</div>
	<div id="PedidosOrcamentoRecentes">
		<h2 id="uxTituloH2UltimasOportunidades" runat="server">
		</h2>
		<uc2:PedidosOrcamentoControle ID="PedidosOrcamentoControle1" runat="server" />
	</div>
	<div class="horizontalSep">
		<!-- -->
	</div>
	<div class="FornecedoresRecentes">
		<h2 id="uxTituloH2UltimosDepoimentos" runat="server">
		</h2>
		<uc4:DepoimentoOrcamentoOnline ID="DepoimentoOrcamentoOnline1" runat="server" />
	</div>
	<!-- Product Buy Button Section Starts Here -->
	<div class="bigBuyButton">
		<a href="/orcamento-online.aspx" title="Solicite seu Orçamento Online" class="buttonLinkWithImage">
			Quero pedir um Orçamento Online grátis<img src="/img/buttonArrow.png" alt="Arrow Button"
				id="arrowButtonFixPNG" /></a>
	</div>
	<!-- end bigBuyButton -->
	<div class="horizontalSep">
		<!-- -->
	</div>
	<uc5:LinksInternosTemaCategoria ID="LinksInternosTemaCategoria1" runat="server" />
</asp:Content>
