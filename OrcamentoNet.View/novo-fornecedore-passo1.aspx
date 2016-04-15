<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="novo-fornecedore-passo1.aspx.cs"
    Inherits="OrcamentoNet.View.orcamento_online_parceiro_passo1" MasterPageFile="~/OrcamentoNet.Master" %>

<%@ OutputCache Duration="14400" VaryByParam="categoria;cidade;termo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="/controles/CaptchaControle.ascx" TagName="CaptchaControle" TagPrefix="uc11" %>
<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc22" %>
<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc23" %>
<%@ Register Src="/controles/CategoriaListaFornecedoresControle.ascx" TagName="CategoriaListaFornecedoresControle"
    TagPrefix="uc2" %>
<%@ Register Src="/controles/LinksInternosControle.ascx" TagName="LinksInternosControle"
    TagPrefix="uc8" %>
<%@ Register Src="/controles/FornecedorPorCategoriaControle.ascx" TagName="FornecedorPorCategoriaControle"
    TagPrefix="uc1" %>
<%@ Register Src="controles/CidadeListBoxControle.ascx" TagName="CidadeListBoxControle"
    TagPrefix="uc4" %>
<%@ Register Src="controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 418px;
            font-size: large;
            height: 30px;
        }
        .style2
        {
            height: 90px;
        }
    </style>
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
            <div id="fb-root">
            </div>

            <script>
                (function(d, s, id) {
+                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
                    fjs.parentNode.insertBefore(js, fjs);
                } (document, 'script', 'facebook-jssdk'));
            </script>

            <div class="fb-like" data-href="http://orcamentosgratis.net.br/cadastro-fornecedores-orcamento-online.aspx"
                data-send="true" data-layout="button_count" data-width="239" data-show-faces="true"
                style="margin-top: 8px;">
            </div>
            <div style="margin-top: 8px;">
                <a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a></div>

            <script>
                !function(d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");
            </script>

            <div style="margin-top: 8px;">
                <!-- Place this tag where you want the +1 button to render -->
                <g:plusone annotation="inline" width="239"></g:plusone>
                <!-- 

                <script type="text/javascript">
                    window.___gcfg = { lang: 'pt-BR' };

                    (function() {
                        var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
                        po.src = 'https://apis.google.com/js/plusone.js';
                        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
                    })();
                </script>
                -->
            </div>
        </div>
        <div class="productText fl">
            <h1 id="uxTituloH1" runat="server">
            </h1>
            <uc23:MensagemSuperiorControle ID="MensagemSuperiorControle1" runat="server" />
            <p style="text-align: right;">
                Consulte nossa <a href="http://rcmsolucoes.com/politica-de-privacidade/" target="_blank">
                    política de privacidade</a>.
            </p>
            <div class="frm-solicitar-orcamento">
                <fieldset>
                    <ul class="fl">
                        <li>
                            <label>
                                Passo 1 de 5 - Seus ramos de atividade:</label>
                            <%--<div style="margin-top: 4px; width: 100%; height: 410px; overflow: auto;">--%>
                            <br />
                            <asp:Repeater ID="uxrptCategorias" runat="server">
                                <ItemTemplate>
                                    <strong>
                                        <%#Eval("Nome")%></strong>
                                    <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                                        <ItemTemplate>
                                            <br />
                                            <asp:CheckBox runat="server" ID="uxchkSubCategoria" />
                                            <%--<%#Eval("Nome")%>--%>
                                            <asp:Label ID="uxlblNomeCategoria" runat="server" Text='<%#Eval("Nome") %>'></asp:Label>
                                            <asp:Label ID="uxlblIdCategoria" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <br />
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--</div>--%>
                        </li>
                    </ul>
                    <asp:Button ID="uxbtnPasso1" runat="server" CssClass="ie6SubmitFix" Text="Avançar"
                        OnClick="uxbtnPasso1_Click" />
                </fieldset>
            </div>
            
        </div>
        <div style="clear: both; margin-left: 40px;">
        </div>
        <!-- end productText -->
    </div>
    <uc1:FornecedorPorCategoriaControle ID="FornecedorPorCategoriaControle1" runat="server" />
    <uc2:CategoriaListaFornecedoresControle ID="CategoriaListaFornecedoresControle1"
        runat="server" />
    <div class="horizontalSep">
        <!-- -->
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
    <div style="clear: both; margin-left: 40px;">
    </div>
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

    <script type="text/javascript">
        function displayVals() {
            var opcaoSelecionada = $("#ctl00_cpObjetivoPrincipalPagina_uxddlComoConheceu").val();
            if (opcaoSelecionada == 'Google') {
                $("#lblComoConheceu").text('Quais palavras você digitou no Google?');
            }

            if (opcaoSelecionada == 'Indicação') {
                $("#lblComoConheceu").text('Qual nome da empresa que te indicou?');
            }

            if (opcaoSelecionada == 'Outros') {
                $("#lblComoConheceu").text('Como conheceu?');
            }

            if (opcaoSelecionada == 'Selecione') {
                $("#lblComoConheceu").text('');

            }
        }

        $("select").change(displayVals);      

    </script>

</asp:Content>
<asp:Content ID="cpObjetivoSecundarioPagina" ContentPlaceHolderID="cpObjetivoSecundarioPagina"
    runat="server">
    <div style="clear: both;">
    </div>
    <uc3:PedidosOrcamentoControle ID="PedidosOrcamentoControle1" runat="server" />
</asp:Content>
