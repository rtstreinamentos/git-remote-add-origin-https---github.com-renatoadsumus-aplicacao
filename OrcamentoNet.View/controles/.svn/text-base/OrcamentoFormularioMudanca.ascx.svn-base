<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrcamentoFormularioMudanca.ascx.cs" Inherits="OrcamentoNet.View.controles.OrcamentoFormularioMudanca" %>
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
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTelefone" runat="server" width="100px"
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
                
            </li>
            <uc1:CaptchaControle ID="CaptchaControle1" runat="server" />
        </ul>
    </div>
    <div style="float: right; width: 49%;">
        <ul class="fl">
         <li>
                <label>
                    Título</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTitulo" runat="server" MaxLength="100"
                    ToolTip="Informe título (ex.: mudança de um apartamento 7º andar para uma casa)"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxtxtTitulo"
                    ErrorMessage="" Text="O título deve ser informado." /><br />
                <asp:RegularExpressionValidator ID="regexpTitulo" runat="server" ControlToValidate="uxtxtTitulo"
                    ErrorMessage="" Text="O título deve ter entre 5 e 100 caracteres." ValidationExpression="^.{5,100}$" />
            </li>
            
            <li>
                <uc3:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
            </li>
            <li>
                <label>
                    Bairro - Origem</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtCidadeBairroOrigem" 
                    runat="server" MaxLength="100"
                    ToolTip="Informe Cidade e Bairro de Origem (ex.: copacabana, morumbi.)" 
                    ></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxtxtCidadeBairroOrigem"
                    ErrorMessage="" Text="Bairro de Origem" /><br />
                
            </li>
            <li>
                <label>
                   Destino</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtCidadeBairroDestino" runat="server"
                    MaxLength="200" ToolTip="Informe Cidade e Bairro de Destino (ex.: UF / Rio de Janeiro / Copacabana.)"
                    ></asp:TextBox>(UF / Cidade / Bairro)<br />
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxtxtCidadeBairroDestino"
                    ErrorMessage="" Text="Cidade e Bairro de Destino">
                </asp:RequiredFieldValidator>
            </li>    
            
            <li>
                <label>
                    Detalhes da Mudança?</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtObservacao" runat="server" TextMode="MultiLine"
                    Width="95%" Height="100px" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor. Ex. quantidade de camas, armários etc"></asp:TextBox><br />
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
<!-- end buttonDarkBG -->
