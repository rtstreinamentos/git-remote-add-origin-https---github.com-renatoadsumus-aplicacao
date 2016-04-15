<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
    CodeBehind="CriarPedido.aspx.cs" Inherits="OrcamentoNet.View.CriarPedido" %>

<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
	TagPrefix="uc3" %>
	
	<%@ Register src="controles/MenuAdmin.ascx" tagname="MenuAdmin" tagprefix="uc1" %>
	
	
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div id="mainWrapper">
    <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
        <div class="frm-solicitar-orcamento">
        
            <fieldset>
                <ul>
                    <li>
                        <label for="uxtxtNome">
                            Cliente:</label>
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
                            ErrorMessage="" Text="O DDD deve ser informado."> </asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxtxtTelefone"
                            ErrorMessage="" Text="O telefone deve ser informado."> </asp:RequiredFieldValidator>
                    </li>
                     <li>
                <label>
                    Operadora Telefone:
                </label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTelefoneOperadora" runat="server" Width="80px"
                    MaxLength="12" ToolTip="Exemplo: vivo, claro, oi, fixo..."></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="uxtxtTelefoneOperadora"
                    ErrorMessage="" Text="Operadora deve ser informado." />
            </li>
                    <li>
                        <label>
                            Título:</label>
                        <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTitulo" runat="server" MaxLength="100"
                            ToolTip="Informe um título resumido de sua necessidade"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxtxtTitulo"
                            ErrorMessage="" Text="O título deve ser informado." /><br />
                        <asp:RegularExpressionValidator ID="regexpTitulo" runat="server" ControlToValidate="uxtxtTitulo"
                            ErrorMessage="" Text="O título deve ter entre 5 e 100 caracteres." ValidationExpression="^.{5,100}$" />
                    </li>
                    <li>
                        <label>
                            O serviço será executado para:
                        </label>
                        <asp:DropDownList ID="uxddlTipoPessoa" runat="server">
                            <asp:ListItem Value="0">Selecionar</asp:ListItem>
                            <asp:ListItem Value="1">pessoa física</asp:ListItem>
                            <asp:ListItem Value="2">pessoa jurídica</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="uxddlTipoPessoa"
                            ErrorMessage="" InitialValue="0" Text="O tipo de pessoa deve ser informado." />
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxddlLigacao"
                            ErrorMessage="" Text="Informar Melhor Horário para ligar!" InitialValue="0" />
                    </li>
                     <li>
                <uc3:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
            </li>
                    <li>
                        <label>
                            Descrição do pedido</label>
                        <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtObservacao" runat="server" TextMode="MultiLine"
                            Width="95%" Height="100px" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor."></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxtxtObservacao"
                            Text="A descrição deve ser informada." ErrorMessage="" />
                    </li>
                    <li>
                        <asp:Button ID="uxbtnSalvar" runat="server" CssClass="ie6SubmitFix" Text="Salvar"
                            OnClick="uxbtnSalvar_Click" />
                    </li>
                </ul>
            </fieldset>
        </div>
    </div>
</asp:Content>
