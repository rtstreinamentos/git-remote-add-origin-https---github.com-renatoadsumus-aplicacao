<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet.Master"
    CodeBehind="orcamento-online-tipo-servico.aspx.cs" Inherits="OrcamentoNet.View.orcamento_online_tipo_servico" %>

<%@ OutputCache Duration="14400" VaryByParam="idTipoOrcamento;cidade;categoria;bairro" %>
<%@ Register Src="/controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="ucPedidosOrcamentoControle" %>
<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc2" %>
<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc3" %>
<%@ Register Src="/controles/OrcamentoFormularioEvento.ascx" TagName="OrcamentoFormularioEvento"
    TagPrefix="uc5" %>
    <%@ Register Src="/controles/OrcamentoFormularioConstrucao.ascx" TagName="OrcamentoFormularioConstrucao"
    TagPrefix="uc7" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="/controles/CaptchaControle.ascx" TagName="CaptchaControle" TagPrefix="uc1" %>
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
                    <li><a href="/orcamento-online-box-vidros-espelhos-19.aspx" title="Solicite orçamento online grátis de box, vidros e espelhos. Receba cotação de preços de vários fornecedores de box, vidros e espelhos. Prático, simples, eficaz e grátis!">
                        Box, Vidros e Espelhos</a></li>
                    <li><a href="/orcamento-online-buffet-123.aspx" title="Solicite orçamento online grátis de buffet para casamento, festas, aniversários e eventos. Receba cotação de preços de vários fornecedores de buffet para casamento, festas, aniversários e eventos. Prático, simples, eficaz e grátis!">
                        Buffet</a></li>
                    <li><a href="/orcamento-online-Buffet-Infantil-171.aspx" title="Solicite orçamento online grátis de buffet infantil para aniversários, batizados e festas. Receba cotação de preços de vários fornecedores de buffet infantil para aniversários, batizados e festas. Prático, simples, eficaz e grátis!">
                        Buffet Infantil</a></li>
                    <li><a href="/orcamento-online-buffet-japones-54.aspx" title="Solicite orçamento online grátis de buffet japonês e comida japonesa. Receba cotação de preços de vários fornecedores de buffet japonês e comida japonesa. Prático, simples, eficaz e grátis!">
                        Buffet Japonês</a></li>
                    <li><a href="/orcamento-online-circuito-fechado-televisao-CFTV-169.aspx" title="Solicite orçamento online grátis de circuito fechado de TV (CFTV). Receba cotação de preços de vários fornecedores de circuito fechado de televisão (CFTV). Prático, simples, eficaz e grátis!">
                        Circuito Fechado de TV (CFTV)</a></li>
                    <li><a href="/orcamento-online-pintura-pintor-40.aspx" title="Solicite orçamento online grátis de pintura e pintor profissional. Receba cotação de preços de vários fornecedores de pintura e pintor profissional. Prático, simples, eficaz e grátis!">
                        Obras, Reformas e Pintura</a></li>
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
                        <uc5:OrcamentoFormularioEvento ID="OrcamentoFormularioEvento" runat="server" />
                         <uc7:OrcamentoFormularioConstrucao ID="OrcamentoFormularioConstrucao" Visible="false"
                            runat="server" />
                    </div>
                </div>
                <!-- end productPriceContainer -->
            </div>
            <!-- end productText -->
        </div>
        <!-- end productPrice -->
    </div>
    <!-- end productHeadingType3 -->
    <div class="tipos-orcamentos">
        <h3 id="H1" runat="server">
            Por Serviço</h3>
        <ul class="checkList">
            <asp:Repeater ID="uxrptLinksPorServico" runat="server">
                <ItemTemplate>
                    <li><a href='/<%#Eval("UrlAmigavel")%>' title='<%#Eval("ToolTip")%>'>
                        <%#Eval("Nome")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div style="clear: both;">
        <p>
            &nbsp;</p>
    </div>
    <div class="tipos-orcamentos">
        <h3 id="uxH3TituloLinksInterno" runat="server">
            Por Estado</h3>
        <ul class="checkList">
            <asp:Repeater ID="uxrptLinksEstadoCidade" runat="server">
                <ItemTemplate>
                    <li><a href='/<%#Eval("UrlAmigavel")%>' title='<%#Eval("ToolTip")%>'>
                        <%#Eval("Nome")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div style="clear: both;">
        <p>
            &nbsp;</p>
    </div>
    <div class="tipos-orcamentos">
        <h3>
            Por Termo</h3>
        <ul class="checkList">
            <asp:Repeater ID="uxrptLinksTermo" runat="server">
                <ItemTemplate>
                    <li><a href='/<%#Eval("UrlAmigavel")%>' title='<%#Eval("ToolTip")%>'>
                        <%#Eval("Nome")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div style="clear: both;">
        <p>
            &nbsp;</p>
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
