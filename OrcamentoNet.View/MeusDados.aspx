<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
    CodeBehind="MeusDados.aspx.cs" Inherits="OrcamentoNet.View.MeusDados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="controles/MenuAdmin.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
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
    <div id="mainWrapper">
        <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
        <asp:MultiView ID="multiview01" runat="server" ActiveViewIndex="0">
            <asp:View ID="viewMeusDados" runat="server">
                <br />
                <br />
                <asp:HyperLink Text="Veja sua p�gina personalizada" Target="_blank" ID="hpyFichaTecnica"
                    runat="server"></asp:HyperLink>
                <br />
                <br />
                <div class="frm-solicitar-orcamento">
                    <fieldset>
                        <ul class="fl">
                        <li>
                                <h2>
                                    Configura��o Avan�ada
                                </h2>
                               <label> Ajuste para receber pedidos de acordo com seu perfil!</label>
                                
                            </li>
                            <li>
                               <label> Quero receber pedidos de pessoa f�sica acima de 
                                <asp:TextBox ID="txtConfiguracaoArea" MaxLength="5" runat="server" Width="50px"></asp:TextBox> metros quadrados</label>
                                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                    TargetControlID="txtConfiguracaoArea" >
                                </cc1:FilteredTextBoxExtender>
                                
                                </li>
                                <br />
                                <li>
                                <h2>
                                    Meus Dados
                                </h2>
                               <label> Ajuste para receber pedidos de acordo com seu perfil!</label>
                                
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
                                <asp:Label ID="uxtxtEmail" runat="server" CssClass="ie6SubmitFix" ToolTip="Informe seu e-mail."></asp:Label>
                            </li>
                            <li>
                                <label>
                                    Data Vencimento:</label>
                                <asp:Label ID="uxtxtDataCobranca" runat="server" CssClass="ie6SubmitFix" ToolTip="Informe seu e-mail."></asp:Label>
                            </li>
                            <li>
                                <label>
                                    Valor Mensalidade:</label>
                                <asp:Label ID="uxtxtValorMensalidade" runat="server" CssClass="ie6SubmitFix" ToolTip="Informe seu e-mail."></asp:Label>
                                <%--<a href="MeusDados.aspx?plano=sim">Alterar Plano</a>--%>
                                <asp:HyperLink ID="hypLinkPagamento" runat="server" Text="Efetuar Pagamento" Font-Size="Large"></asp:HyperLink>
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
                            
                                <br />
                                <br />
                                <li>
                                <h2>
                                    Envio de Fotos
                                </h2>
                               
                                
                            </li>
                            <li>
                                <label>
                                    Fotos(max 1MB por foto):<asp:FileUpload ID="FileUpload1" runat="server" />
                                </label>
                                <br />
                                <asp:Button ID="uxbtnFoto" runat="server" OnClick="uxbtnFoto_Click" Text="Adicionar Foto" />
                            </li>
                            <li>
                                <h3 style="color: Red">
                                    Ap�s enviar suas fotos clicar em Salvar</h3>
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
                            
                            <li>
                                <asp:Button ID="uxbtnSalvar" runat="server" CssClass="ie6SubmitFix" Text="Salvar"
                                    OnClick="uxbtnSalvar_Click" />
                            </li>
                        </ul>
                    </fieldset>
                </div>
            </asp:View>
            <asp:View ID="viewMeuPlano" runat="server">
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
                                            Espa�o para banner em nosso site
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
                                </table>
                                <ul>
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
                            </fieldset>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="viewSucesso" runat="server">
                <div class="productLargeBox">
                    <div class="productTrialForm">
                        <div class="frm-solicitar-orcamento">
                            <fieldset>
                                <div style="float: left; width: 100%;">
                                    <br />
                                    <br />
                                    <h1>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        Dados alterados com sucesso!</h1>
                                    <br />
                                    <br />
                                    <h2>
                                        Na sua pr�xima fatura j� estar� o valor do plano selecionado.
                                    </h2>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <!-- end mainWrapper -->
    </div>
    <center>

        <script type="text/javascript"><!--
            google_ad_client = "ca-pub-9502900066313233";
            /* Banner Rodap� Largo */
            google_ad_slot = "5398927505";
            google_ad_width = 970;
            google_ad_height = 90;
//-->
        </script>

        <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>

    </center>
    <div id="footerInformation">
        <p>
            � Copyright - Este site � parte do sistema tema a href="http://rcmsolucoes.com/"
            target="_blank" title="Or�amento Online">Or�amento Online</a>. Conhe�a nossa <a href="http://rcmsolucoes.com/politica-de-privacidade/"
                target="_blank">pol�tica de privacidade</a>.</p>
        <p>
            D�vidas, cr�ticas ou sugest�es? <a href="http://rcmsolucoes.com/fale-conosco/" target="_blank"
                rel="nofollow">Fale conosco</a>, teremos o maior prazer em atend�-lo(a)!</p>
        <p>
            <small><a href="http://www.freedigitalphotos.net/images/view_photog.php?photogid=2664"
                target="_blank" rel="nofollow">Foto: Stuart Miles / FreeDigitalPhotos.net</a></small></p>
    </div>
</asp:Content>
