<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrcamentoFormularioGenerico.ascx.cs"
    Inherits="OrcamentoNet.View.controles.OrcamentoFormularioGenerico" %>
<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
	TagPrefix="uc3" %>
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
               
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxtxtDDD"
                    ErrorMessage="" Text="O DDD deve ser informado.">
                </asp:RequiredFieldValidator><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxtxtTelefone"
                    ErrorMessage="" Text="O telefone deve ser informado.">
                </asp:RequiredFieldValidator>
            </li>
             <li>
                <label>
                    Operadora Telefone:
                    </label>
                    <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTelefoneOperadora" runat="server" Width="80px"
                        MaxLength="12" ToolTip="Exemplo: vivo, claro, oi, fixo..."></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxtxtTelefoneOperadora"
                    ErrorMessage="" Text="Operadora deve ser informado." />
                
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
                    Fotos ou Arquivos(max 2MB por arquivo):
                </label>
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Fotos ajudam muito os fornecedores na elaboração do orçamento" />
                <br />
                <br />
                <asp:Button CausesValidation="false" ID="uxbtnFoto" runat="server" OnClick="uxbtnFoto_Click"
                    Text="Adicionar Arquivo" ToolTip="Fotos ajudam muito os fornecedores na elaboração do orçamento" />
            </li>
            <li>
                <h3 style="color: Red">
                  Aguarde até seus arquivos aparecem na lista abaixo:
                </h3>
               
                <asp:Label ID="uxlblFotos" runat="server"></asp:Label>
                <br />
                <asp:Label ID="uxlblMensagemFoto" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="uxlblFotosGuids" runat="server" Visible="false"></asp:Label>
            </li>
            <uc1:CaptchaControle ID="CaptchaControle1" runat="server" />
        </ul>      
    </div>
    <div style="float: right; width: 49%;">
        <ul>
            <li>
                <uc3:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
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
                    O que deseja?</label>
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
</fieldset>
