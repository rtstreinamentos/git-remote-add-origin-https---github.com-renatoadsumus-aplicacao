<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro-fornecedores-orcamento-online_old.aspx.cs"
    Inherits="OrcamentoNet.View.orcamento_online_parceiro_old" MasterPageFile="~/OrcamentoNet.Master" %>

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
                <img src="img/fechando-negocios-orcamento-online.jpg" alt="Feche neg�cios atrav�s do Or�amento Online"
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

            <div class="fb-like" data-href="http://orcamentosgratis.net.br/novo-fornecedore-passo1.aspx"
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
                    pol�tica de privacidade</a>.
            </p>
            <asp:MultiView ID="multiview" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewPasso0" runat="server">
                    <p class='productDescription'>
                        Veja no v�deo abaixo como funciona o sistema:</p>
                    <p>
                        <iframe width="560" height="315" src="http://www.youtube.com/embed/zDU-2c2WhTM?rel=0"
                            frameborder="0" allowfullscreen></iframe>
                    </p>
                    <div class="frm-solicitar-orcamento">
                        <asp:Button ID="uxbtnPasso0" runat="server" CssClass="ie6SubmitFix" Text="Quero me Cadastrar!"
                            OnClick="uxbtnPasso0_Click" />&nbsp;&nbsp;
                        <asp:Button ID="uxbtnCalcularValor" runat="server" CssClass="ie6SubmitFix" OnClick="uxbtnCalcularValor_Click"
                            Text="Simular Mensalidade" Visible="false" />
                    </div>
                </asp:View>
                <asp:View ID="viewPasso1" runat="server">
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
                            <asp:Button ID="uxbtnPasso1" runat="server" CssClass="ie6SubmitFix" Text="Avan�ar"
                                OnClick="uxbtnPasso1_Click" />
                        </fieldset>
                    </div>
                </asp:View>
                <asp:View ID="viewPasso2" runat="server">
                    <div class="frm-solicitar-orcamento">
                        <fieldset>
                            <ul class="fl">
                                <li>
                                    <label>
                                        Passo 2 de 5 - Indique a atividade mais importante para voc�:</label>
                                    <asp:DropDownList ID="uxddlCategoriasSelecionadas" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Selecione</asp:ListItem>
                                    </asp:DropDownList>
                                </li>
                                <li>
                                    <asp:Button ID="uxbtnPasso2" runat="server" CssClass="ie6SubmitFix" Text="Avan�ar"
                                        OnClick="uxbtnPasso2_Click" />
                                </li>
                            </ul>
                        </fieldset>
                    </div>
                </asp:View>
                <asp:View ID="viewPasso2_1" runat="server">
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
                                    <asp:Button ID="uxbtnPasso2_1" runat="server" CssClass="ie6SubmitFix" Text="Avan�ar"
                                        OnClick="uxbtnPasso2_1_Click" />
                                </li>
                            </ul>
                        </fieldset>
                    </div>
                </asp:View>
                <asp:View ID="viewPasso3" runat="server">
                    <div class="frm-solicitar-orcamento">
                        <fieldset>
                            <ul class="fl">
                                <li>
                                    <label>
                                        Passo 4 de 5 - Estes dados ser�o vistos pelas pessoas que visitarem sua ficha no
                                        Or�amento Online.</label>
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
                                        Descri��o da empresa/atividades:</label>
                                    <asp:TextBox ID="uxtxtDescricao" runat="server" CssClass="ie6SubmitFix" Height="100px"
                                        TextMode="MultiLine" ToolTip="Exemplo: Empresa especializada em constru��o com 5 anos de experi�ncia no mercado... "
                                        Width="95%"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxtxtDescricao"
                                        ErrorMessage="" Text="A descri��o deve ser informada." />
                                </li>
                                <li>
                                    <label>
                                        Como conheceu o Or�amento Online?</label>
                                    <asp:DropDownList ID="uxddlComoConheceu" runat="server">
                                        <asp:ListItem>Selecione</asp:ListItem>
                                        <asp:ListItem>Google</asp:ListItem>
                                        <asp:ListItem>Indica��o</asp:ListItem>
                                        <asp:ListItem>Outros</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxddlComoConheceu"
                                        ErrorMessage="" InitialValue="0" Text="Informar Como Conheceu Or�amento Online!" />
                                    <br />
                                    <label id="lblComoConheceu">
                                    </label>
                                    <asp:TextBox ID="uxtxtIndicacao" runat="server" CssClass="ie6SubmitFix" MaxLength="100"
                                        ToolTip="Informe o nome da empresa ou pessoa que indicou o Or�amento Online para voc�."></asp:TextBox>
                                </li>
                                <li>
                                    <uc11:CaptchaControle ID="CaptchaControle1" runat="server" />
                                    <asp:Button ID="uxbtnPasso3" runat="server" CssClass="ie6SubmitFix" OnClick="uxbtnPasso3_Click"
                                        Text="Avan�ar" />
                                </li>
                            </ul>
                            <p>
                                <strong>
                                    <asp:Label ID="uxlblMensagemInferior" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></strong></p>
                        </fieldset>
                    </div>
                </asp:View>
                <asp:View ID="viewEscolhaPlanos" runat="server">
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
                                                Ideal para pessoas f�sicas e aut�nomos.
                                            </td>
                                            <td class="style1">
                                                Ideal para empresas.
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Pedidos de pessoa f�sica ilimitado
                                            </td>
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Pedidos de pessoa f�sica ilimitado
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                            </td>
                                            <td class="style1">
                                                <img src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif" height="20"
                                                    width="20" />
                                                Pedidos de pessoa jur�dica ilimitado
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
                                                Servi�o de resposta autom�tica
                                            </td>
                                        </tr>
                                        <tr align="left">
                                            <td class="style1">
                                                &nbsp;
                                            </td>
                                            <td class="style1">
                                                <img height="20" src="http://upload.wikimedia.org/wikipedia/commons/7/73/Yes_check.gif"
                                                    width="20" />
                                                Ter seus projetos e fotos na p�gina principal do site
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
                                                Voc� poder� controlar n�o somente os pedidos de nosso sistema, mas tamb�m poder�
                                                cadastrar novos pedidos. Atrav�s dessa ferramenta voc� poder� controlar e acompanhar:</label>
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
                                                        respons�vel pelo atendimento</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        comiss�o</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        valor do or�amento</label>
                                                </li>
                                            </ul>
                                        </li>
                                        <li>
                                            <h2>
                                                O que � a Resposta Autom�tica?</h2>
                                        </li>
                                        <li>
                                            <label>
                                                � um servi�o que o Or�amento Online oferece para acelerar seu contato com o cliente.
                                                A Resposta Autom�tica � um texto escrito por voc� que ser� enviado automaticamente
                                                ao cliente. Esse texto pode conter:</label>
                                            <ul>
                                                <li>
                                                    <label>
                                                        Formas de pagamento</label>
                                                </li>
                                                <li>
                                                    <label>
                                                        Descri��o da empresa e dos seus servi�os</label></li>
                                                <li>
                                                    <label>
                                                        Card�pio</label></li>
                                                <li>
                                                    <label>
                                                        Pre�o do seu servi�o ou produto</label>
                                                </li>
                                            </ul>
                                        </li>
                                        <li>
                                            <h2>
                                                Como funciona a Resposta Autom�tica?</h2>
                                        </li>
                                        <li>
                                            <label>
                                                Cada vez que nosso sistema receber um pedido de or�amento com seu perfil n�s enviaremos
                                                um email para voc� e para o cliente com a sua Resposta Autom�tica personalizada.
                                                Com isso, voc� saber� que pedidos voc� recebeu e j� respondeu automaticamente.</label></li>
                                        <li>
                                            <h2>
                                                Benef�cios da Resposta Autom�tica:</h2>
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
                                                        Voc� n�o ter� d�vidas se respondeu ou n�o o cliente</label></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="viewPerguntaDesejaEnvioFotos" runat="server">
                    <div class="productLargeBox">
                        <div class="productTrialForm">
                            <div class="frm-solicitar-orcamento">
                                <fieldset>
                                    <div style="float: left; width: 100%;">
                                        <h3>
                                            Passo 5 de 5 - Voc� deseja enviar agora fotos do seu trabalho?</h3>
                                        <ul>
                                            <li>
                                                <asp:Button ID="uxbtnEnviarFoto" runat="server" OnClick="uxbtnEnviarFoto_Click" Text="Sim" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="uxbtnNaoEnviarFotos" runat="server" Text="N�o" OnClick="uxbtnNaoEnviarFotos_Click" />
                                            </li>
                                        </ul>
                                        <h3>
                                            Fotos e depoimentos s�o uma �tima forma de passar credibilidade do seu servi�o!</h3>
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
                                            Passo 5 de 5 - Enviar no m�ximo 10 fotos</h3>
                                        <ul>
                                            <li>
                                                <label>
                                                    Fotos(max 1MB por foto):<asp:FileUpload ID="FileUpload1" runat="server" />
                                                </label>
                                                <br />
                                                <asp:Button ID="uxbtnFoto" runat="server" OnClick="uxbtnFoto_Click" Text="Adicionar Foto" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="uxbtnFinalizarCadastro" runat="server" OnClick="uxbtnFinalizarCadastro_Click"
                                                    Text="Avan�ar" />
                                            </li>
                                            <li>
                                                <h3 style="color: Red">
                                                    Ap�s enviar suas fotos clicar em Avan�ar</h3>
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
        Como funciona o Or�amento Online?</h2>
    <p style="margin-bottom: 20px;">
        Seu pedido de or�amento para compra de produtos ou contrata��o de servi�os ser�
        encaminhado a diversos fornecedores (lojas, empresas, consultorias, prestadores
        de servi�os profissionais, aut�nomos), que entrar�o em contato diretamente com voc�.
        Toda a negocia��o quanto a pre�os, formas de pagamento e prazos ocorre diretamente
        entre o comprador e o fornecedor. O site Or�amento Online n�o tem nenhuma participa��o
        no or�amento, nem no fornecimento do produto ou servi�o, a n�o ser atuar como ponte
        de contato entre o comprador e o fornecedor.</p>
    <h2>
        Sou um comprador. Quanto pago e como fa�o para pedir um or�amento online?</h2>
    <p style="margin-bottom: 20px;">
        Nada. <strong>O Or�amento Online � gr�tis.</strong>. <a href="/orcamento-online.aspx#listaOrcamentos"
            title="Solicite or�amento online gr�tis de diversos produtos e servi�os.">Solicite
            j� seu or�amento!</a></p>
    <h2>
        Sou um fornecedor. Como fa�o para receber os Pedidos de Or�amento?</h2>
    <p style="margin-bottom: 20px;">
        Voc� deve fazer seu <a href="cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cota��es e envie or�amentos">
            cadastro como fornecedor</a> no Or�amento Online para receber os pedidos de
        or�amento. Trabalhamos apenas com profissionais e empresas diferenciados, competentes,
        capacitados, que prestam servi�os ou fornecem produtos de reconhecida qualidade.</p>

    <script type="text/javascript">
        function displayVals() {
            var opcaoSelecionada = $("#ctl00_cpObjetivoPrincipalPagina_uxddlComoConheceu").val();
            if (opcaoSelecionada == 'Google') {
                $("#lblComoConheceu").text('Quais palavras voc� digitou no Google?');
            }

            if (opcaoSelecionada == 'Indica��o') {
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
