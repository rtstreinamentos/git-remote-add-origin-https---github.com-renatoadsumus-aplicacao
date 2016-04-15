<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrcamentoFormularioCFTV.ascx.cs"
    Inherits="OrcamentoNet.View.controles.OrcamentoFormularioCFTV" %>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="uxtxtTelefoneOperadora"
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="uxddlLigacao"
                    ErrorMessage="" Text="Informar Melhor Horário para ligar!" InitialValue="0" />
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxddlPretensao"
                    ErrorMessage="" InitialValue="0" Text="Seu objetivo deve ser informado." />
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
				<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="uxddlTipoPessoa"
					ErrorMessage="" InitialValue="0" Text="O tipo de pessoa deve ser informado." />
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
            <uc1:CaptchaControle ID="CaptchaControle1" runat="server" />
        </ul>
    </div>
    <div style="float: right; width: 49%;">
        <ul class="fl">
            <li>
                <label>
                    O que deseja monitorar?</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTitulo" runat="server" MaxLength="100"
                    ToolTip="Informe o que deseja monitorar (ex.: toda a casa, pátio externo, garagem, entrada principal, etc.)"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxtxtTitulo"
                    ErrorMessage="" Text="O título deve ser informado." /><br />
                <asp:RegularExpressionValidator ID="regexpTitulo" runat="server" ControlToValidate="uxtxtTitulo"
                    ErrorMessage="" Text="O título deve ter entre 5 e 100 caracteres." ValidationExpression="^.{5,100}$" />
            </li>
            <li>
                <label>
                    Quantidade de câmeras EXTERNAS:</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtQuantidadeCamerasExterna" runat="server"
                    MaxLength="3" ToolTip="Informe a quantidade estimada de câmeras EXTERNAS (somente números)"
                    width="100px"></asp:TextBox>&nbsp;(estimativa)<br />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="uxtxtQuantidadeCamerasExterna"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxtxtQuantidadeCamerasExterna"
                    ErrorMessage="" Text="Informe a quantidade de câmeras EXTERNAS">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    Alcance de visualização (EXTERNO):</label>
                <asp:DropDownList ID="uxddlAlcanceMaximoCameraExterna" runat="server">
                    <asp:ListItem>Não sei informar</asp:ListItem>
                    <asp:ListItem>5 metros</asp:ListItem>
                    <asp:ListItem>10 metros</asp:ListItem>
                    <asp:ListItem>15 metros</asp:ListItem>
                    <asp:ListItem>20 metros</asp:ListItem>
                    <asp:ListItem>25 metros</asp:ListItem>
                    <asp:ListItem>Não preciso</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label>
                    Quantidade de câmeras INTERNAS:</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtQuantidadeCamerasInterna" runat="server"
                    width="100px" MaxLength="3" ToolTip="Informe a quantidade estimada de câmeras INTERNAS (somente números)"></asp:TextBox>&nbsp;(estimativa)<br />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="uxtxtQuantidadeCamerasInterna"
                    FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uxtxtQuantidadeCamerasInterna"
                    ErrorMessage="" Text="Informe a quantidade de câmeras INTERNAS">
                </asp:RequiredFieldValidator>
                <br />
            </li>
            <li>
                <label>
                    Alcance de visualização (INTERNO):</label>
                <asp:DropDownList ID="uxddlAlcanceMaximoCameraInterna" runat="server">
                    <asp:ListItem>Não sei informar</asp:ListItem>
                    <asp:ListItem>5 metros</asp:ListItem>
                    <asp:ListItem>10 metros</asp:ListItem>
                    <asp:ListItem>15 metros</asp:ListItem>
                    <asp:ListItem>20 metros</asp:ListItem>
                    <asp:ListItem>25 metros</asp:ListItem>
                    <asp:ListItem>Não preciso</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label>
                    Possui preferência de marca?</label>
                <asp:DropDownList ID="uxddlMarca" runat="server">
                    <asp:ListItem>Não sei informar</asp:ListItem>
                    <asp:ListItem>Axis</asp:ListItem>
                    <asp:ListItem>Pelco</asp:ListItem>
                    <asp:ListItem>Sony</asp:ListItem>
                    <asp:ListItem>TW</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label>
                    Qual a área de cobertura (m<sup>2</sup>)?</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTamanho" runat="server" MaxLength="8"
                    width="100px"></asp:TextBox>&nbsp;(estimativa)<br />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server" TargetControlID="uxtxtTamanho"
                    FilterType="Custom,Numbers" ValidChars=" .,">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxtxtTamanho"
                    ErrorMessage="" Text="A área de cobertura deve ser informada.">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <uc3:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
            </li>
            <li>
                <label>
                    O que deseja?</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtObservacao" runat="server" TextMode="MultiLine"
                    Width="95%" Height="100px" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor."></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxtxtObservacao"
                    Text="A descrição deve ser informada." ErrorMessage="" />
            </li>
            <li>
                <label>
                    Fotos ou Arquivos(max 2MB por arquivo):
                </label>
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Fotos ajudam muito os fornecedores na elaboração do orçamento" />
                <br />
                <br />
                <asp:Button CausesValidation="false" ID="uxbtnFoto" runat="server" OnClick="uxbtnFoto_Click"
                    Text="Adicionar Foto" ToolTip="Fotos ajudam muito os fornecedores na elaboração do orçamento" />
            </li>
            <li>
                <h3 style="color: Red">
                  Aguarde até suas fotos aparecem na lista abaixo:
                </h3>
               
                <asp:Label ID="uxlblFotos" runat="server"></asp:Label>
                <br />
                <asp:Label ID="uxlblMensagemFoto" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="uxlblFotosGuids" runat="server" Visible="false"></asp:Label>
            </li>
            
        </ul>
    </div>
    <div class="secaoEnviar">
        <asp:Button CssClass="ie6SubmitFix" ID="uxbtnSalvar" runat="server" Text="Solicitar Orçamento"
            OnClick="uxbtnSalvar_Click" />
    </div>
</fieldset>
<!-- end buttonDarkBG -->
