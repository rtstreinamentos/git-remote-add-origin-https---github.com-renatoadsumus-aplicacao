<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="novo-fornecedore-passo2.aspx.cs"
    Inherits="OrcamentoNet.View.orcamento_online_parceiro_passo2" MasterPageFile="~/OrcamentoNet.Master" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                                        Passo 2 de 5 - Indique a atividade mais importante para você:</label>
                                    <asp:DropDownList ID="uxddlCategoriasSelecionadas" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Selecione</asp:ListItem>
                                    </asp:DropDownList>
                                </li>
                                <li>
                                </li>
                            </ul>
                        </fieldset>
                    </div>
                    <div class="frm-solicitar-orcamento">
                        <fieldset>
                            <ul class="fl">
                                <li>
                                    <label>
                                        Passo 3 de 5</label>
                                    <%--<div style="margin-top: 4px; width: 100%; height: 410px; overflow: auto;">--%>
                                    <uc4:CidadeListBoxControle ID="CidadeListBoxControle1" runat="server" />
                                    <%--</div>--%>
                                </li>
                                <li>
                                </li>
                            </ul>
                        </fieldset>
                    </div>
                    <div class="frm-solicitar-orcamento">
                        <fieldset>
                            <ul class="fl">
                                <li>
                                    <label>
                                        Passo 4 de 5 - Estes dados serão vistos pelas pessoas que visitarem sua ficha no
                                        Orçamento Online.</label>
                                </li>
                                <li>
                                    <label for="uxtxtNome">
                                        <a name="formulario">Nome/Empresa:</a></label>
                                    <asp:TextBox ID="uxtxtNome" runat="server" CssClass="ie6SubmitFix" MaxLength="100"
                                        ToolTip="Informe seu nome."></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxtxtNome"
                                        ErrorMessage="" Text="O nome deve ser informado." />
                                </li>
                                <li>
                                    <label>
                                        E-mail:</label>
                                    <asp:TextBox ID="uxtxtEmail" runat="server" CssClass="ie6SubmitFix" MaxLength="100"
                                        ToolTip="Informe seu e-mail."></asp:TextBox>
                                    <br />
                                    <asp:RegularExpressionValidator ID="regexpEmail" runat="server" ControlToValidate="uxtxtEmail"
                                        ErrorMessage="" Text="O e-mail deve ser informado no formato correto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxtxtEmail"
                                        ErrorMessage="" Text="O e-mail deve ser informado." />
                                </li>
                                <li>
                                    <label>
                                        Telefone:</label>
                                    <asp:TextBox ID="uxtxtDDD" runat="server" CssClass="ie6SubmitFix" MaxLength="2" Width="20px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                        TargetControlID="uxtxtDDD">
                                    </cc1:FilteredTextBoxExtender>
                                    -
                                    <asp:TextBox ID="uxtxtTelefone" runat="server" CssClass="ie6SubmitFix" MaxLength="12"
                                        Width="80px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                        TargetControlID="uxtxtTelefone" ValidChars=" -()_./r">
                                    </cc1:FilteredTextBoxExtender>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxtxtDDD"
                                        ErrorMessage="" Text="O DDD deve ser informado.">
                                    </asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxtxtTelefone"
                                        ErrorMessage="" Text="O telefone deve ser informado.">
                                    </asp:RequiredFieldValidator>
                                </li>
                                <li>
                                    <label>
                                        Web site:</label>
                                    <asp:TextBox ID="uxtxtSite" runat="server" CssClass="ie6SubmitFix" MaxLength="100"
                                        ToolTip="http://..."></asp:TextBox>
                                    <br />
                                    <asp:RegularExpressionValidator ID="regexpURL" runat="server" ControlToValidate="uxtxtSite"
                                        ErrorMessage="" Text="O web site deve ser informado no formato correto." ValidationExpression="^(http(s?):\/\/)(www.)?(\w|-)+(\.(\w|-)+)*((\.[a-zA-Z]{2,3})|\.(aero|coop|info|museum|name))+(\/)?$" />
                                    <br />
                                </li>
                                <li>
                                    <label>
                                        Descrição da empresa/atividades:</label>
                                    <asp:TextBox ID="uxtxtDescricao" runat="server" CssClass="ie6SubmitFix" Height="100px"
                                        TextMode="MultiLine" ToolTip="Exemplo: Empresa especializada em construção com 5 anos de experiência no mercado... "
                                        Width="95%"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxtxtDescricao"
                                        ErrorMessage="" Text="A descrição deve ser informada." />
                                </li>
                                <li>
                                    <label>
                                        Como conheceu o Orçamento Online?</label>
                                    <asp:DropDownList ID="uxddlComoConheceu" runat="server">
                                        <asp:ListItem>Selecione</asp:ListItem>
                                        <asp:ListItem>Google</asp:ListItem>
                                        <asp:ListItem>Indicação</asp:ListItem>
                                        <asp:ListItem>Outros</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxddlComoConheceu"
                                        ErrorMessage="" InitialValue="0" Text="Informar Como Conheceu Orçamento Online!" />
                                    <br />
                                    <label id="lblComoConheceu">
                                    </label>
                                    <asp:TextBox ID="uxtxtIndicacao" runat="server" CssClass="ie6SubmitFix" MaxLength="100"
                                        ToolTip="Informe o nome da empresa ou pessoa que indicou o Orçamento Online para você."></asp:TextBox>
                                </li>
                                <li>
                                    
                                    <xxxxelmt>
                                        <asp:Button ID="uxbtnPasso3" runat="server" CssClass="ie6SubmitFix" 
                                        OnClick="uxbtnPasso3_Click" Text="Avançar" />
                                    </xxxxelmt>
                                </li>
                            </ul>
                            <p>
                                <strong>
                                    <asp:Label ID="uxlblMensagemInferior" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></strong></p>
                        </fieldset>
                    </div>
           
                    
            
        </div>
        <div style="clear: both; margin-left: 40px;">
        </div>
        <!-- -->
    </div>
    <div class="tipos-orcamentos">
        <h3>
            Por Termo  
        </ul>
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
    
</asp:Content>
