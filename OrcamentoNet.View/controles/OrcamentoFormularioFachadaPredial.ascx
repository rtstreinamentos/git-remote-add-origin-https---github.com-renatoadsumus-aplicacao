<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrcamentoFormularioFachadaPredial.ascx.cs" Inherits="OrcamentoNet.View.controles.OrcamentoFormularioFachadaPredial" %>

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
				<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="uxddlTipoPessoa"
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
						<li style="margin: 6px 0 0 0;">
							<%--<asp:CheckBox ID="uxchkCategoria" runat="server" />--%>
							<b>
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
					Tipo de construção:</label>
				<asp:DropDownList ID="uxddlTipoImovel" runat="server">
					<asp:ListItem Value="0">Selecionar</asp:ListItem>
					<asp:ListItem>Escola ou Clube</asp:ListItem>
					<asp:ListItem>Galpão</asp:ListItem>
					<asp:ListItem>Hospital</asp:ListItem>
					<asp:ListItem>Prédio Comercial</asp:ListItem>
					<asp:ListItem>Prédio Industrial</asp:ListItem>
					<asp:ListItem>Prédio Residencial</asp:ListItem>
					<asp:ListItem>Condomínio</asp:ListItem>					
					<asp:ListItem>Outros</asp:ListItem>
				</asp:DropDownList>
				<br />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="uxddlTipoImovel"
					ErrorMessage="" InitialValue="0" Text="O tipo de imóvel deve ser informado." />
			</li>
			<li>
				<label>
					Bairro, região ou local:</label>
				<asp:TextBox ID="uxtxtLocalObra" runat="server" MaxLength="200" Width="256px"></asp:TextBox>
			</li>
			
			<li>
				<label>
					Área do Serviço (m<sup>2</sup>) </label>
&nbsp;<asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTamanho" runat="server" MaxLength="8"
					Width="60px"></asp:TextBox>&nbsp;(apenas uma estimativa)<br />
				<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="uxtxtTamanho"
					FilterType="Custom,Numbers" ValidChars=" .,">
				</cc1:FilteredTextBoxExtender>
				<br />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxtxtTamanho"
					ErrorMessage="" Text="A área aproximada deve ser informada.">
				</asp:RequiredFieldValidator>
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
				<label>
					Título ou resumo de seu pedido:</label>
				<asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTitulo" runat="server" MaxLength="100"
					Width="256px" ToolTip="Informe um título resumido (ex.: pintura de parede interna, pintura de terraço externo, etc.)"></asp:TextBox><br />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="uxtxtTitulo"
					ErrorMessage="" Text="O título deve ser informado." /><br />
				<asp:RegularExpressionValidator ID="regexpTitulo" runat="server" ControlToValidate="uxtxtTitulo"
					ErrorMessage="" Text="O título deve ter entre 5 e 100 caracteres." ValidationExpression="^.{5,100}$" />
			</li>
			<li>
				<label for="uxtxtNome">
					Nome:</label>
				<asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtNome" runat="server" MaxLength="100" Width="256"
					ToolTip="Informe seu nome."></asp:TextBox><br />
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxtxtNome"
					ErrorMessage="" Text="O nome deve ser informado." />
			</li>
			<li>
				<label>
					E-mail:</label>
				<asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtEmail" runat="server" MaxLength="100"
					Width="256" ToolTip="Informe seu e-mail."></asp:TextBox><br />
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
					Prefere receber ligações:</label>
				<asp:DropDownList ID="uxddlLigacao" runat="server" Width="112px">
					<asp:ListItem Value="0">Selecione</asp:ListItem>
					<asp:ListItem>Manhã</asp:ListItem>
					<asp:ListItem>Tarde</asp:ListItem>
					<asp:ListItem>Noite</asp:ListItem>
					<asp:ListItem>Não ligar</asp:ListItem>
				</asp:DropDownList>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxddlLigacao"
					ErrorMessage="" Text="Sua opção de contato deve ser informada" InitialValue="0" />
			</li>
			<li>
				<label>
					Prefere receber visita técnica:</label>
			</li>
			<div style="margin-left: 30px;">
			<asp:CheckBoxList runat="server" ID="uxchlDiasSemana">
				<asp:ListItem> Segunda-Feira</asp:ListItem>
				<asp:ListItem> Terça-Feira</asp:ListItem>
				<asp:ListItem> Quarta-Feira</asp:ListItem>
				<asp:ListItem> Quinta-Feira</asp:ListItem>
				<asp:ListItem> Sexta-Feira</asp:ListItem>
				<asp:ListItem> Sábado</asp:ListItem>
				<asp:ListItem> Domingo</asp:ListItem>
			</asp:CheckBoxList>
			</div>
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
			<br />
			<uc1:CaptchaControle ID="CaptchaControle1" runat="server" />
		</ul>
	</div>
	<div class="secaoEnviar">
        <asp:Button CssClass="ie6SubmitFix" ID="uxbtnSalvar" runat="server" Text="Solicitar Orçamento"
            OnClick="uxbtnSalvar_Click" />
    </div>
</fieldset>