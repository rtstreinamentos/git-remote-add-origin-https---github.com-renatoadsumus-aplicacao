<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrcamentoFormularioBox.ascx.cs"
    Inherits="OrcamentoNet.View.controles.OrcamentoFormularioBoxVidroEspelho" %>
<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="/controles/CaptchaControle.ascx" TagName="CaptchaControle" TagPrefix="uc1" %>
<fieldset>
    <div style="float: left; width: 49%;">
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
                 Operadora
                 <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTelefoneOperadora" runat="server" Width="80px"
                    MaxLength="12"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxtxtDDD"
                    ErrorMessage="" Text="O DDD deve ser informado.">
                </asp:RequiredFieldValidator><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxtxtTelefone"
                    ErrorMessage="" Text="O telefone deve ser informado.">
                </asp:RequiredFieldValidator>
            </li>
            <uc1:CaptchaControle ID="CaptchaControle1" runat="server" />
        </ul>
    </div>
    <div style="float: right; width: 49%;">
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
                    Cor vidro:</label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Selecionar</asp:ListItem>
                    <asp:ListItem>Azul</asp:ListItem>
                    <asp:ListItem>Bronze</asp:ListItem>
                    <asp:ListItem>Fumê</asp:ListItem>
                    <asp:ListItem>Incolor</asp:ListItem>
                    <asp:ListItem>Pontilhado</asp:ListItem>
                    <asp:ListItem>Verde</asp:ListItem>
                    <asp:ListItem>Satiné</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label>
                    Produto(h)=altura:</label>
                <asp:DropDownList ID="uxddlTipoBox" runat="server">
                    <asp:ListItem>Selecionar</asp:ListItem>
                    <asp:ListItem>Box Frontal - 1,90m(h)</asp:ListItem>
                    <asp:ListItem>Box Ângulo - 1,90m(h)</asp:ListItem>
                    <asp:ListItem>Box Porta Abrir - 1,85m(h)</asp:ListItem>
                    <asp:ListItem>Box Banheira - 1,50m(h)</asp:ListItem>
                    <asp:ListItem>Outro(descreva na descrição)</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <uc3:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
            </li>
            <li>
                <label>
                    Descrição</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtObservacao" runat="server" TextMode="MultiLine"
                    Width="95%" Height="100px" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor."></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxtxtObservacao"
                    Text="A descrição deve ser informada." ErrorMessage="" />
            </li>
        </ul>
    </div>
    <div class="secaoEnviar">
        <asp:Button CssClass="ie6SubmitFix" ID="uxbtnSalvar" runat="server" Text="Solicitar Orçamento"
            OnClick="uxbtnSalvar_Click" />
    </div>
    <br />
    <br />
    <div>
        <label>
            Verifique o Modelo do Box</label>
        <br />
        <img src="http://www.artembox.com.br/mediac/450_0/media/AmboxOrcamentoModelos.jpg" />
        <br />
        Frontal 2folhas;Porta Abrir; Ângulo L; Ânguloc/PortaAbrir ;Banheira ; Frontal 4folhas
    </div>
    <br />
    <div>
        <label>
            Cor Vidro</label>
        <br />
        <img src="http://www.artembox.com.br/mediac/450_0/media/AmboxOrcamentoVidros.jpg" />
    </div>
</fieldset>
<!-- end buttonDarkBG -->
