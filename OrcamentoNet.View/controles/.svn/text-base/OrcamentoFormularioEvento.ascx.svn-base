<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrcamentoFormularioEvento.ascx.cs"
    Inherits="OrcamentoNet.View.controles.OrcamentoFormularioEvento" %>
<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="/controles/CaptchaControle.ascx" TagName="CaptchaControle" TagPrefix="uc1" %>
<fieldset>
    <div style="float: left; width: 49%;">
        <ul class="fl">
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
					O serviço será executado para:
				</label>
				<asp:DropDownList ID="uxddlTipoPessoa" runat="server">
					<asp:ListItem Value="0">Selecionar</asp:ListItem>
					<asp:ListItem Value="1">pessoa física</asp:ListItem>
					<asp:ListItem Value="2">pessoa jurídica</asp:ListItem>
				</asp:DropDownList>
				<br />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxddlTipoPessoa"
					ErrorMessage="" InitialValue="0" Text="O tipo de pessoa deve ser informado." />
			</li>
            <li>
                <uc3:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
            </li>
            <li class="sugestoesOrcamentos">
                <asp:Repeater ID="uxrptCategorias" runat="server">
                    <HeaderTemplate>
                        <label>
                            Que serviços deseja?</label>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li style="margin: 6px 0 0 0;"><b>
                            <%#Eval("Nome")%></b>
                            <asp:Label ID="uxlblIdCategoria" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                        </li>
                        <asp:Repeater ID="uxrptTermos" runat="server" DataSource='<%#Eval("Termos")%>'>
                            <HeaderTemplate>
                                <ul style="margin: 0 0 0 20px;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li style="margin: 0 0 0 0;">
                                    <asp:CheckBox ID="uxchkTermo" runat="server" />
                                    <asp:Label ID="uxlblTermo" runat="server" Text='<%#Eval("Nome") %>'></asp:Label>
                                    <%--<asp:Label ID="uxlblIdCategoriaTermo" runat="server" Text='<%#Eval("IdCategoria") %>'
                                        Visible="false"></asp:Label>--%>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                <li style="margin: 0 0 0 0;">Outros:
                                    <asp:TextBox ID="uxtxtOutroTermo" runat="server" MaxLength="100" Height="18"></asp:TextBox>
                                </li>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Label ID="uxlblMensagem" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Medium"></asp:Label>
            </li>
        </ul>
    </div>
    <div style="float: right; width: 49%;">
        <ul class="fl">
            <li>
                <label>
                    Evento:</label>
                <asp:DropDownList ID="uxddlTipoEvento" runat="server">
                    <asp:ListItem Value="0">Selecione</asp:ListItem>
                    <asp:ListItem>Aniversário</asp:ListItem>
                    <asp:ListItem>Casamento</asp:ListItem>
                    <asp:ListItem>Chá de Bebe</asp:ListItem>
                    <asp:ListItem>Chá de Fralda</asp:ListItem>
                    <asp:ListItem>Confraternização</asp:ListItem>
                    <asp:ListItem>Festa de 15 anos (debutante)</asp:ListItem>
                    <asp:ListItem>Outro</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="uxddlTipoEvento"
                    ErrorMessage="" Text="O tipo de evento deve ser informado." InitialValue="0" /><br />
               
            </li>
            <li>
                <label>
                    Bairro, região ou local:</label>
                <asp:TextBox ID="uxtxtAreaAtuacao" ToolTip="Copacabana, Ipanema, Morumbi, Interlagos, etc. "
                    runat="server" MaxLength="1000"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                        runat="server" ControlToValidate="uxtxtAreaAtuacao" ErrorMessage="" Text="O local deve ser informado."
                        InitialValue="0" /><br />
            </li>
            <li>
                <label>
                    Quando?</label>
                <asp:TextBox ID="uxtxtDataEvento" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                (dd/mm/aaaa)<br />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender58" runat="server" TargetControlID="uxtxtDataEvento"
                    FilterType="Custom,Numbers" ValidChars="/" />
                <asp:RegularExpressionValidator ID="regexpDataValidade" runat="server" ControlToValidate="uxtxtDataEvento"
                    ErrorMessage="" Text="Informe a data no formato dd/mm/aaaa." ValidationExpression="^\d\d/\d\d/\d\d\d\d$" /><br />
                <asp:RequiredFieldValidator ID="rfDataEvento" runat="server" ControlToValidate="uxtxtDataEvento"
                    ErrorMessage="" Text="A data deve ser informada." />
            </li>
            <li>
                <label>
                    Número de convidados:</label>
                <asp:TextBox ID="uxtxtNumeroConvidados" runat="server" MaxLength="10" Width="60px"></asp:TextBox><br />
                <cc1:FilteredTextBoxExtender ID="ftNumeroConvidados" runat="server" TargetControlID="uxtxtNumeroConvidados"
                    FilterType="Numbers" />
                <asp:RequiredFieldValidator ID="rfNumeroConvidados" runat="server" ControlToValidate="uxtxtNumeroConvidados"
                    ErrorMessage="" Text="O número de convidados deve ser informado." />
            </li>
            <li>
                <label>
                    Hora de início:</label>
                <asp:TextBox ID="uxtxtHoraInicio" runat="server" MaxLength="5" Width="60px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="uxtxtHoraInicio"
                    ValidChars=":" FilterType="Numbers,Custom" />
            </li>
            <li>
                <label>
                    Duração da festa:</label>
                <asp:DropDownList ID="uxddlDuracaoFesta" runat="server">
                    <asp:ListItem Value="0">Selecionar</asp:ListItem>
                    <asp:ListItem Value="4">4 horas</asp:ListItem>
                    <asp:ListItem Value="5">5 horas</asp:ListItem>
                    <asp:ListItem Value="6">6 horas</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxddlDuracaoFesta"
                    ErrorMessage="" Text="Informar duração da festa!" InitialValue="0" />
            </li>
            <li>
                <label>
                    Acrescente mais detalhes sobre os serviços:</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtObservacao" runat="server" TextMode="MultiLine"
                    Width="95%" Height="100px" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor."></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxtxtObservacao"
                    Text="A descrição deve ser informada." ErrorMessage="" />
            </li>
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
    <div class="secaoEnviar">
        <asp:Button CssClass="ie6SubmitFix" ID="uxbtnSalvar" runat="server" Text="Solicitar Orçamento"
            OnClick="uxbtnSalvar_Click" />
    </div>
</fieldset>
