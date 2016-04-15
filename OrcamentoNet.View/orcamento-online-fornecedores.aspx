<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orcamento-online-fornecedores.aspx.cs"
    Inherits="OrcamentoNet.View.orcamento_online_fornecedores" MasterPageFile="~/OrcamentoNet.Master" %>
    
<%@ OutputCache Duration="14400" VaryByParam="none" %>

<%@ Register Src="/controles/CategoriaListaFornecedoresControle.ascx" TagName="CategoriaListaFornecedoresControle"
    TagPrefix="uc2" %>
    <%@ Register Src="/controles/FornecedoresControle.ascx" TagName="FornecedoresControle"
    TagPrefix="ucFornecedores" %>
    <%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc23" %>
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
			<h1>
				Orçamento Online - Cotação de Preços</h1>
			<p class="productDescription">
				O <strong>orçamento online</strong> coloca em contato compradores e uma rede de
				<strong>indicação de fornecedores</strong> (lojas, empresas, prestadores de serviços
				profissionais, autônomos) de diversos ramos de atividade.</p>
			<p class="productDescription">
				Veja alguns tipos de orçamentos e cotações de preços que você pode pedir:</p>
			<ul class="checkList">
				<li><a href="/orcamento-online-box-vidros-espelhos-19.aspx" title="Solicite orçamento online grátis de box, vidros e espelhos. Receba cotação de preços de vários fornecedores de box, vidros e espelhos. Prático, simples, eficaz e grátis!">
					Box, Vidros e Espelhos</a></li>
				<li><a href="/orcamento-online-buffet-japones-54.aspx" title="Solicite orçamento online grátis de buffet japonês e comida japonesa. Receba cotação de preços de vários fornecedores de buffet japonês e comida japonesa. Prático, simples, eficaz e grátis!">
					Buffet Japonês</a></li>
				<li><a href="/orcamento-online-festa-casamento-52.aspx" title="Solicite orçamento online grátis para todos os preparativos da sua festa de casamento. Receba cotação de preços de vários fornecedores de casamento. Prático, simples, eficaz e grátis!">
					Festas e Eventos</a></li>
				<li><a href="/orcamento-online-circuito-fechado-televisao-CFTV-169.aspx" title="Solicite orçamento online grátis de circuito fechado de TV (CFTV). Receba cotação de preços de vários fornecedores de circuito fechado de televisão (CFTV). Prático, simples, eficaz e grátis!">
					Circuito Fechado de Televisão (CFTV)</a></li>
				<li><a href="/orcamento-online-obras-reformas-construcao-pintura-27.aspx" title="Solicite orçamento online grátis de obras, reformas, construção, pintura e pintor profissional. Receba cotação de preços de vários fornecedores de obras, reformas, construção, pintura e pintor profissional. Prático, simples, eficaz e grátis!">
					Obras, Reformas e Construção</a></li>
				<li><a href="/orcamento-online-reforma-fachada-predio-182.aspx" title="Solicite orçamento online grátis de serviços em fachadas prediais. Receba cotação de preços de vários fornecedores de serviços em fachadas prediais. Prático, simples, eficaz e grátis!">
					Pintura e Limpeza de Fachadas Prediais</a></li>
				<li><a href="/orcamento-online-pintura-pintor-profissional-40.aspx" title="Solicite orçamento online grátis de pintor e pintura profissional. Receba cotação de preços de vários pintores e seviços de pintura profissional. Prático, simples, eficaz e grátis!">
					Pintura e Pintor Profissional</a></li>
				<li><a href="/orcamento-online.aspx#listaOrcamentos" title="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!">
					Outros orçamentos</a></li>
			</ul>
		</div>
		<!-- end productText -->
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
 <uc2:categorialistafornecedorescontrole ID="CategoriaListaFornecedoresControle1"
        runat="server" />
   
    <div class="horizontalSep">
        <!-- -->
    </div>
    <h2>
        Como funciona o Orçamento Online?</h2>
    <p style="margin-bottom: 20px;">
        Seu pedido de orçamento para compra de produtos ou contratação de serviços será
        encaminhado a diversos fornecedores (lojas, empresas, consultorias, prestadores
        de serviços profissionais, autônomos), que entrarão em contato diretamente com você.
        Toda a negociação quanto a preços, formas de pagamento e prazos ocorre diretamente
        entre o comprador e o fornecedor. O site Orçamento Online não tem nenhuma participação
        no orçamento, nem no fornecimento do produto ou serviço, a não ser atuar como ponte
        de contato entre o comprador e o fornecedor.</p>
    <h2>
        Sou um comprador. Quanto pago e como faço para pedir um orçamento online?</h2>
    <p style="margin-bottom: 20px;">
        Nada. <strong>O Orçamento Online é grátis.</strong>. <a href="/orcamento-online.aspx#listaOrcamentos"
            title="Solicite orçamento online grátis de diversos produtos e serviços.">Solicite
            já seu orçamento!</a></p>
    <h2>
        Sou um fornecedor. Como faço para receber os Pedidos de Orçamento?</h2>
    <p style="margin-bottom: 20px;">
        Você deve fazer seu <a href="cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos">
            cadastro como fornecedor</a> no Orçamento Online para receber os pedidos de
        orçamento. Trabalhamos apenas com profissionais e empresas diferenciados, competentes,
        capacitados, que prestam serviços ou fornecem produtos de reconhecida qualidade.</p>
</asp:Content>
<asp:Content ID="cpObjetivoSecundarioPagina" ContentPlaceHolderID="cpObjetivoSecundarioPagina"
    runat="server">
    <ucfornecedores:fornecedorescontrole ID="ultimosFornecedores" runat="server" />
    <div style="clear: both;">
    </div>
</asp:Content>