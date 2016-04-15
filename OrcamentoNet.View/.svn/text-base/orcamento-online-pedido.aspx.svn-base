<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet.Master"
    CodeBehind="Orcamento-Online-Pedido.aspx.cs" Inherits="OrcamentoNet.View.Orcamento_Online_Pedido" %>

<%@ OutputCache Duration="14400" VaryByParam="categoria;termo" %>

<%@ Register Src="/controles/LinksInternosControle.ascx" TagName="LinksInternosControle"
    TagPrefix="uc8" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="/controles/CaptchaControle.ascx" TagName="CaptchaControle" TagPrefix="uc1" %>
<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc2" %>
<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc3" %>
<%@ Register Src="/controles/CategoriaListaControle.ascx" TagName="CategoriaListaControle"
    TagPrefix="uc1" %>
<%@ Register Src="/controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="ucPedidosOrcamentoControle" %>
<%@ Register Src="controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .Fonte24Azul
        {
            font-size: 24px;
            font-family: 'Droid Sans' , 'Arial' , sans-serif;
            color: #2b92fa; /* The skin color - This can be changed if you are going for a diferent color scheme */
            margin-bottom: 15px;
        }
        .lista
        {
            background: url("/img/checkListBullet.jpg") left top no-repeat;
            float: left;
            padding-left: 24px;
            margin-left: 20px;
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType3">
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
        <span id="spanLanding" visible="true" runat="server">
           
            <div class="productTrialForm">
                <div class="frm-solicitar-orcamento">
                    <h3 style="margin-top: 10px;">
                        Onde será executado o serviço?</h3>
                    <asp:DropDownList ID="uxddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="uxDdlEstado_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="uxddlCidade" runat="server" AutoPostBack="true" OnSelectedIndexChanged="uxDdlCidade_SelectedIndexChanged">
                        <asp:ListItem Value="0">Selecione</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator998" runat="server" ControlToValidate="uxddlEstado"
                        ErrorMessage="" InitialValue="Selecione" Text="O estado deve ser informado." />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator999" runat="server" ControlToValidate="uxddlCidade"
                        ErrorMessage="" InitialValue="0" Text="A cidade deve ser informada." />
                    <%--<h3 style="margin-bottom: 0px; margin-top: 10px;">
						Que serviços deseja contratar?</h3>
					<ul>
						<li class="sugestoesOrcamentos">
							<asp:CheckBoxList ID="uxchkCategoriasTema" runat="server" Style="margin: 0 6px 6px 0;"
								AutoPostBack="true" OnSelectedIndexChanged="uxChkCategoriasTema_SelectedIndexChanged">
							</asp:CheckBoxList>
						</li>
					</ul>--%>
                    <h3 style="margin-top: 20px;">
                        Selecione os fornecedores que agradam você:</h3>
                    <p>
                        Clique no fornecedor e veja a sua ficha completa.</p>
                    <asp:Label ID="uxlblMensagemPassoFornecedor" runat="server" ForeColor="Red"></asp:Label>
                    <ul class="checkList">
                        <asp:Repeater ID="uxrptFornecedores" runat="server">
                            <ItemTemplate>
                                <li style="margin: 0 6px 6px 14px; font-size: 12px;">
                                    <asp:CheckBox ID="uxchkFornecedor" runat="server" />
                                    <a title="Acesse a ficha completa de <%#Eval("Nome")%>" href="/Ficha_Tecnica.aspx?n=<%#Server.HtmlEncode(Eval("Id").ToString())%>"
                                        target="_blank">
                                        <%#Eval("Nome")%></a>
                                    <p>
                                        <%#Eval("Descricao")%></p>
                                    <asp:Label ID="lblIdFornecedor" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <h3 style="margin-bottom: 0px; margin-top: 20px;">
                        Dê informações sobre sua necessidade:</h3>
                    <div style="float: left; width: 49%;">
                        <ul class="fl">
                            <li>
                                <label>
                                    Título:</label>
                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTitulo" runat="server" MaxLength="100"
                                    ToolTip="Informe um título resumido (ex.: pintura de parede interna, pintura de terraço externo, etc.)"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxtxtTitulo"
                                    ErrorMessage="" Text="O título deve ser informado." /><br />
                                <asp:RegularExpressionValidator ID="regexpTitulo" runat="server" ControlToValidate="uxtxtTitulo"
                                    ErrorMessage="" Text="O título deve ter entre 5 e 100 caracteres." ValidationExpression="^.{5,100}$" />
                            </li>
                            <li>
                                <label>
                                    Materiais:</label>
                                <asp:DropDownList ID="uxddlMaterias" runat="server">
                                    <asp:ListItem Value="0">Selecionar</asp:ListItem>
                                    <asp:ListItem>Eu fornecerei os materiais</asp:ListItem>
                                    <asp:ListItem>A empresa deve fornecer os materiais</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="uxddlMaterias"
                                    ErrorMessage="" InitialValue="0" Text="O fornecimento dos materiais deve ser informado." />
                            </li>
                            <li>
                                <label>
                                    Tipo de imóvel:</label>
                                <asp:DropDownList ID="uxddlTipoImovel" runat="server">
                                    <asp:ListItem Value="0">Selecionar</asp:ListItem>
                                    <asp:ListItem>Apartamento</asp:ListItem>
                                    <asp:ListItem>Duplex</asp:ListItem>
                                    <asp:ListItem>Casa</asp:ListItem>
                                    <asp:ListItem>Escritório</asp:ListItem>
                                    <asp:ListItem>Local Comercial</asp:ListItem>
                                    <asp:ListItem>Local Industrial</asp:ListItem>
                                    <asp:ListItem>Outro</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="uxddlTipoImovel"
                                    ErrorMessage="" InitialValue="0" Text="O tipo de imóvel deve ser informado." />
                            </li>
                            <li>
                                <label>
                                    Área do Serviço (m<sup>2</sup>):</label>
                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTamanho" runat="server" MaxLength="8"
                                    Width="60px"></asp:TextBox>&nbsp;(apenas uma estimativa)<br />
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="uxtxtTamanho"
                                    FilterType="Custom,Numbers" ValidChars=" .,">
                                </cc1:FilteredTextBoxExtender>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxtxtTamanho"
                                    ErrorMessage="" Text="A área aproximada deve ser informada.">
                                </asp:RequiredFieldValidator>
                            </li>
                            <li>
                                <label>
                                    Bairro, região ou local:</label>
                                <asp:TextBox ID="uxtxtLocalObra" runat="server" MaxLength="200" Width="256px"></asp:TextBox>
                            </li>
                            <li>
                                <label>
                                    Seu objetivo é:
                                </label>
                                <asp:DropDownList ID="uxddlPretensao" runat="server">
                                    <asp:ListItem Value="0">Selecionar</asp:ListItem>
                                    <asp:ListItem Value="1">apenas ter noção de preços</asp:ListItem>
                                    <asp:ListItem Value="2">contratar o serviço</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uxddlPretensao"
                                    ErrorMessage="" InitialValue="0" Text="Seu objetivo deve ser informado." />
                            </li>
                            <li>
                                <label>
                                    Se necessário prefere receber visita técnica:</label></li>
                            <asp:CheckBoxList runat="server" ID="uxchlDiasSemana">
                                <asp:ListItem>Segunda-Feira</asp:ListItem>
                                <asp:ListItem>Terça-Feira</asp:ListItem>
                                <asp:ListItem>Quarta-Feira</asp:ListItem>
                                <asp:ListItem>Quinta-Feira</asp:ListItem>
                                <asp:ListItem>Sexta-Feira</asp:ListItem>
                                <asp:ListItem>Sábado</asp:ListItem>
                                <asp:ListItem>Domingo</asp:ListItem>
                            </asp:CheckBoxList>
                        </ul>
                    </div>
                    <div style="float: right; width: 49%;">
                        <ul class="fl">
                            <li>
                                <label for="uxtxtNome">
                                    Nome:</label>
                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtNome" runat="server" MaxLength="100"
                                    ToolTip="Informe seu nome."></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxtxtNome"
                                    ErrorMessage="" Text="O nome deve ser informado." />
                            </li>
                            <li>
                                <label>
                                    E-mail:</label>
                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtEmail" runat="server" MaxLength="100"
                                    ToolTip="Informe seu e-mail."></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="regexpEmail" ControlToValidate="uxtxtEmail" ErrorMessage=""
                                    Text="O e-mail deve ser informado no formato correto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    runat="server" /><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxtxtEmail"
                                    ErrorMessage="" Text="O e-mail deve ser informado." />
                            </li>
                            <li>
                                <label>
                                    Telefone:</label>
                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtDDD" runat="server" Width="20px" MaxLength="2"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="uxtxtDDD"
                                    FilterType="Custom,Numbers">
                                </cc1:FilteredTextBoxExtender>
                                -
                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTelefone" runat="server" Width="80px"
                                    MaxLength="12"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="uxtxtTelefone"
                                    FilterType="Custom,Numbers" ValidChars=" -()_./r">
                                </cc1:FilteredTextBoxExtender>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxtxtDDD"
                                    ErrorMessage="" Text="O DDD deve ser informado."> </asp:RequiredFieldValidator><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxtxtTelefone"
                                    ErrorMessage="" Text="O telefone deve ser informado."> </asp:RequiredFieldValidator>
                            </li>
                            <li>
                                <label>
                                    Prefere receber ligações no período:</label>
                                <asp:DropDownList ID="uxddlLigacao" runat="server" Width="112px">
                                    <asp:ListItem Value="0">Selecione</asp:ListItem>
                                    <asp:ListItem>Manhã</asp:ListItem>
                                    <asp:ListItem>Tarde</asp:ListItem>
                                    <asp:ListItem>Noite</asp:ListItem>
                                    <asp:ListItem>Não ligar</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxddlLigacao"
                                    ErrorMessage="" Text="<br />Informar o melhor horário para ligações" InitialValue="0" />
                            </li>
                            <uc1:CaptchaControle ID="CaptchaControle1" runat="server" />
                        </ul>
                    </div>
                    <div style="clear: both; width: 98%;">
                        <ul>
                            <li>
                                <label>
                                    O que deseja orçar? (Fale sobre sua necessidade)</label>
                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtObservacao" runat="server" TextMode="MultiLine"
                                    Width="95%" Height="200px" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor."></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxtxtObservacao"
                                    Text="A descrição deve ser informada." ErrorMessage="" />
                            </li>
                        </ul>
                    </div>
                    <div class="secaoEnviar">
                        <asp:Button CssClass="ie6SubmitFix" ID="uxbtnSalvar" runat="server" Text="Solicitar Orçamento"
                            OnClick="uxbtnSalvar_Click" />
                    </div>
                </div>
            </div>
            <div class="horizontalSep">
            </div>
            <div class="productText fl">
                <h2 style="margin-left: 20px; margin-top: 20px;">
                    Veja a opinião de quem já usou o Orçamento Online:</h2>
                <p class='productDescription'>
                    <em>Economizei tempo para orçar a festa. O orçamento online é ideal.</em><br />
                    Mariana Dantas (São Paulo)</p>
                <p class='productDescription'>
                    <em>A resposta das empresas foi rápida. Gostei do atendimento e da facilidade de solicitar
                        vários orçamentos em um único site. Parabéns!</em><br />
                    Ingrid (Rio de Janeiro)</p>
                <p class='productDescription'>
                    <em>Gostei da rapidez e qualidade dos serviços oferecidos.</em><br />
                    Ciane (São Paulo)</p>
                <h2 style="margin-left: 20px; margin-top: 20px;">
                    Que garantias eu tenho?</h2>
                <p class='productDescription'>
                    Nós garantimos uma seriedade e dedicação que você não encontra em outros sites.
                    No Orçamento Online, você fala diretamente com os donos do site. Portanto, você
                    pode ter certeza de que faremos o melhor para você receber os orçamentos que precisa
                    para contratar os serviços que deseja.</p>
                <h2 style="margin-left: 20px; margin-top: 20px;">
                    Quanto custa?</h2>
                <p class='productDescription'>
                    O melhor de tudo é que você não paga para fazer pedidos de orçamento e contratar
                    os fornecedores do Orçamento Online. <strong>Para você, o serviço é totalmente grátis.
                        Faça seu pedido de orçamento para festas ou eventos agora mesmo!</strong></p>
        </span>
    </div>
   
</asp:Content>
