﻿<%@ Page Language="C#" MasterPageFile="~/OrcamentoNet.Master" AutoEventWireup="true"
    CodeBehind="historico-pedidos-orcamento-online.aspx.cs" Inherits="OrcamentoNet.View.OrcamentoOnline " %>

<%@ OutputCache Duration="14400" VaryByParam="categoria;cidade;termo;bairro" %>
<%@ Register Src="/controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="ucPedidosOrcamentoControle" %>
<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType3">
		<div style="float: left;">
		<p>
			<img src="img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
				class="productImg fl" /><br />
			&nbsp;<br />

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

		</p>
		</div>
		
		<div class="productText fl">
            <h1 id="uxTituloH1" runat="server">
            </h1>
            <p class="productDescription">
                <uc2:MensagemSuperiorControle ID="MensagemSuperiorControle1" runat="server" />
                <p class="productDescription" style="padding-left: 80px; text-align=right;">
                    <em>O Orçamento Online mostrou-se uma ferramenta muito prática, direcionando um pedido
                        de orçamento para os estabelecimentos e poupando tempo de pesquisa de minha parte.</em><br />
                    Luciane Tomiyasu - Orçamento de Buffet Japonês - SP</p>
                <p id="uxTrocarFormulario" visible="false" runat="server">
                    <a href="/orcamento-online.aspx#listaOrcamentos" title="Clique para mudar o tipo de orçamento que deseja solicitar">
                        Quero outro tipo de orçamento</a>. Consulte nossa <a href="http://rcmsolucoes.com/politica-de-privacidade/"
                            target="_blank">política de privacidade</a>.</p>
            </p>
            <div class="tipos-orcamentos" id="uxOrcamentosMaisPopulares" visible="false" runat="server">
                <p class="productDescription">
                    Veja os tipos de orçamentos e cotações de preços mais populares:</p>
                <ul class="checkList">
                    <li><a href='/preco-casamento-1.aspx' title='Solicite orçamento online grátis para casamentos. Receba cotação de preços de vários fornecedores de casamentos. Prático, simples, eficaz e grátis!'>
                        Casamento</a></li>
                    <li><a href="/preco-reforma-banheiro-10.aspx" title="Solicite orçamento online grátis de reforma de banheiro. Receba cotação de preços de vários fornecedores de reformas. Prático, simples, eficaz e grátis!">
                        Reforma Banheiro</a></li>
                    <li><a href='/preco-debutante-4.aspx' title='Solicite orçamento online grátis para festas de 15 anos (debutantes). Receba cotação de preços de vários fornecedores de festas de 15 anos (debutantes). Prático, simples, eficaz e grátis!'>
                        15 anos (debutante)</a></li>
                    <li><a href="/preco-obras-reformas-construcao-imovel-11.aspx" title="Solicite orçamento online grátis de obras, reformas, construção de imóvel. Receba cotação de preços de várias empresas de obras, reformas, construção de imóvel. Prático, simples, eficaz e grátis!">
                        Reforma Imóvel</a></li>
                    <li><a href='/preco-confraternizacao-2.aspx' title='Solicite orçamento online grátis para confraternizações. Receba cotação de preços de vários fornecedores de confraternizações. Prático, simples, eficaz e grátis!'>
                        Confraternização</a></li>
                    <li><a href="/orcamento-online-obras-reformas-construcao-pintura-27.aspx" title="Solicite orçamento online grátis de obras, reformas, construção, pintura e pintor profissional. Receba cotação de preços de vários fornecedores de obras, reformas, construção, pintura e pintor profissional. Prático, simples, eficaz e grátis!">
                        Obras, Reformas e Construção</a></li>
                    <li><a href='/preco-aniversario-3.aspx' title='Solicite orçamento online grátis para aniversários. Receba cotação de preços de vários fornecedores de aniversários. Prático, simples, eficaz e grátis!'>
                        Aniversário</a></li>
                    <li><a href="/orcamento-online-reforma-fachada-predio-182.aspx" title="Solicite orçamento online grátis de serviços em fachadas prediais. Receba cotação de preços de vários fornecedores de serviços em fachadas prediais. Prático, simples, eficaz e grátis!">
                        Pintura e Limpeza de Fachadas Prediais</a></li>
                    <li><a href='/preco-festa-infantil-5.aspx' title='Solicite orçamento online grátis para festas infantis. Receba cotação de preços de vários fornecedores de festas infantis. Prático, simples, eficaz e grátis!'>
                        Festa Infantil</a></li>
                    <li><a href="/orcamento-online.aspx#listaOrcamentos" title="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!">
                        Outros orçamentos</a></li>
                </ul>
            </div>
            <div style="clear: both; margin-left: 40px;">
                <asp:ValidationSummary ID="valSum" runat="server" HeaderText="<strong>Não foi possível enviar seu pedido de orçamento. Por favor, corrija os campos e tente novamente.</strong>"
                    DisplayMode="BulletList" />
            </div>
            <div class="productLargeBox">
                <div class="productTrialForm">
                    <div class="frm-solicitar-orcamento">
                        <uc12:OrcamentoFormularioCasaDecoracao ID="OrcamentoFormularioCasaDecoracao1" runat="server"
                            Visible="false" />
                        <uc4:OrcamentoFormularioEspelhoVidro ID="OrcamentoFormularioEspelhoVidro1" Visible="false"
                            runat="server" />
                        <uc6:OrcamentoFormularioGenerico ID="OrcamentoFormularioGenerico" Visible="false"
                            runat="server" />
                        <uc7:OrcamentoFormularioConstrucao ID="OrcamentoFormularioConstrucao" Visible="false"
                            runat="server" />
                        <uc9:OrcamentoFormularioCFTV ID="OrcamentoFormularioCFTV1" runat="server" Visible="false" />
                        <uc5:OrcamentoFormularioEvento ID="OrcamentoFormularioEvento" runat="server" Visible="false" />
                        <uc11:OrcamentoFormularioMudanca ID="OrcamentoFormularioMudanca1" runat="server"
                            Visible="false" />
                        <uc10:OrcamentoFormularioFachadaPredial ID="OrcamentoFormularioFachadaPredial1" runat="server"
                            Visible="false" />
                    </div>
                </div>
                <!-- end productPriceContainer -->
            </div>
            <!-- end productText -->
        </div>
        <!-- end productPrice -->
    </div>
    <!-- end productHeadingType3 -->
    <uc1:CategoriaListaControle ID="CategoriaListaControle1" runat="server" />
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
</asp:Content>
