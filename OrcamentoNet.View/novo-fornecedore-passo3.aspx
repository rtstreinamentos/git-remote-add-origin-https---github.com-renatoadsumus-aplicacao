<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="novo-fornecedore-passo3.aspx.cs"
    Inherits="OrcamentoNet.View.orcamento_online_parceiro_passo3" MasterPageFile="~/OrcamentoNet.Master" %>

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
                        
                   
           <div class="productLargeBox">
                        <div class="productTrialForm">
                            <div class="frm-solicitar-orcamento">
                                <fieldset>
                                    <div style="float: left; width: 100%;">
                                        <h1>
                                            Escolha um dos planos mensais abaixo:</h1>
                                    </div>
                                    <table>
                                        <tr class="style2">
                                            <td>
                                                <asp:Button ID="uxbtnPlano1" runat="server" CssClass="ie6SubmitFix" OnClick="uxbtnPlano1_Click" />
                                            </td>
                                            <td class="style1">
                                                <asp:Button ID="uxbtnPlano2" runat="server" CssClass="ie6SubmitFix" OnClick="uxbtnPlano2_Click" />
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td class="style1">
                                                <b>Plano Pessoal</b>
                                            </td>
                                            <td class="style1">
                                                <b>Plano Empresarial</b>
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                                Ideal para pessoas físicas e autônomos.
                                            </td>
                                            <td class="style1">
                                                Ideal para empresas.
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Pedidos de pessoa física ilimitado
                                            </td>
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Pedidos de pessoa física ilimitado
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                            </td>
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Pedidos de pessoa jurídica ilimitado
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                            </td>
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Ferramenta controle de pedido
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                            </td>
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Serviço de resposta automática
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                                &nbsp;
                                            </td>
                                            <td class="style1">
                                                <img height="20" src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif"
                                                    width="20" />
                                                Ter seus projetos e fotos na página principal do site
                                            </td>
                                        </tr>
                                    </table>
                                    <ul>
                                        <li>
                                            <h2>
                                                Ferramenta Controle de Pedidos</h2>
                                        </li>
                                        <li>
                                            <label>
                                                Você poderá controlar não somente os pedidos de nosso sistema, mas também poderá
                                                cadastrar novos pedidos. Através dessa ferramenta você poderá controlar e acompanhar:</label>
                                            <ul>
                                                <li>
                                                    <label>
                                                        status de cada pedido</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        data e hora da visita</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        responsável pelo atendimento</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        comissão</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        valor do orçamento</label>
                                                </li>
                                            </ul>
                                        </li>
                                        <li>
                                            <h2>
                                                O que é a Resposta Automática?</h2>
                                        </li>
                                        <li>
                                            <label>
                                                É um serviço que o Orçamento Online oferece para acelerar seu contato com o cliente.
                                                A Resposta Automática é um texto escrito por você que será enviado automaticamente
                                                ao cliente. Esse texto pode conter:</label>
                                            <ul>
                                                <li>
                                                    <label>
                                                        Formas de pagamento</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        Descrição da empresa e dos seus serviços</label></li>
                                                <li>
                                                    <label>
                                                        Cardápio</label></li>
                                                <li>
                                                    <label>
                                                        Preço do seu serviço ou produto</label>
                                                </li>
                                            </ul>
                                        </li>
                                        <li>
                                            <h2>
                                                Como funciona a Resposta Automática?</h2>
                                        </li>
                                        <li>
                                            <label>
                                                Cada vez que nosso sistema receber um pedido de orçamento com seu perfil nós enviaremos
                                                um email para você e para o cliente com a sua Resposta Automática personalizada.
                                                Com isso, você saberá que pedidos você recebeu e já respondeu automaticamente.</label></li>
                                        <li>
                                            <h2>
                                                Benefícios da Resposta Automática:</h2>
                                            <ul>
                                                <li>
                                                    <label>
                                                        Economia do seu tempo em realizar um trabalho meramente manual</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        Agilidade no primeiro contato com o cliente</label></li>
                                                <li>
                                                    <label>
                                                        Você não terá dúvidas se respondeu ou não o cliente</label></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    
            <asp:MultiView ID="multiview" runat="server" ActiveViewIndex="0">
                
                <asp:View ID="viewPerguntaDesejaEnvioFotos" runat="server">
                    <div class="productLargeBox">
                        <div class="productTrialForm">
                            <div class="frm-solicitar-orcamento">
                                <fieldset>
                                    <div style="float: left; width: 100%;">
                                        <h3>
                                            Passo 5 de 5 - Você deseja enviar agora fotos do seu trabalho?</h3>
                                        <ul>
                                            <li>
                                                <asp:Button ID="uxbtnEnviarFoto" runat="server" OnClick="uxbtnEnviarFoto_Click" Text="Sim" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="uxbtnNaoEnviarFotos" runat="server" Text="Não" OnClick="uxbtnNaoEnviarFotos_Click" />
                                            </li>
                                        </ul>
                                        <h3>
                                            Fotos e depoimentos são uma ótima forma de passar credibilidade do seu serviço!</h3>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="viewEnvioFotos" runat="server">
                    <div class="productLargeBox">
                        <div class="productTrialForm">
                            <div class="frm-solicitar-orcamento">
                                <fieldset>
                                    <div style="float: left; width: 100%;">
                                        <h3>
                                            Passo 5 de 5 - Enviar no máximo 10 fotos</h3>
                                        <ul>
                                            <li>
                                                <label>
                                                    Fotos(max 1MB por foto):<asp:FileUpload ID="FileUpload1" runat="server" />
                                                </label>
                                                <br />
                                                <asp:Button ID="uxbtnFoto" runat="server" OnClick="uxbtnFoto_Click" Text="Adicionar Foto" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="uxbtnFinalizarCadastro" runat="server" OnClick="uxbtnFinalizarCadastro_Click"
                                                    Text="Avançar" />
                                            </li>
                                            <li>
                                                <h3 style="color: Red">
                                                    Após enviar suas fotos clicar em Avançar</h3>
                                            </li>
                                            <li>
                                                <label>
                                                    Fotos Enviadas:
                                                </label>
                                            </li>
                                            <li>
                                                <ul>
                                                    <asp:Repeater ID="uxrptFotos" runat="server">
                                                        <ItemTemplate>
                                                            <li>
                                                                <%# Container.DataItem %>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </li>
                                            <li>
                                                <asp:Label ID="uxlblMensagemFoto" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                            </li>
                                        </ul>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
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
            Por Termo   <asp:Repeater ID="uxrptLinksTermo" runat="server">
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
