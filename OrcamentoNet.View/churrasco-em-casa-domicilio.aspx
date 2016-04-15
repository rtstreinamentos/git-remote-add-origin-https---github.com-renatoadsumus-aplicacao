<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet.Master"
	CodeBehind="churrasco-em-casa-domicilio.aspx.cs" Inherits="OrcamentoNet.View.Churrasco_Em_Casa_Domicilio" %>

<%@ OutputCache Duration="14400" VaryByParam="cidade;termo" %>

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
	</style>
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
	runat="server">
	<div class="productHeadingType3">
		<div style="float: left;">
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
		</div>
		<div class="productText fl">
			<span id="spanLanding" runat="server" visible="true">
				<h1>
					Churrasco em Casa ou Domicílio</h1>
				<p class='productDescription'>
					Encontrar churrasqueiros para a organização de um churrasco exige trabalho,
					esforço e dedicação. Você tem que pesquisar, selecionar os mais adequados, entrar
					em contato com cada um deles, explicar o que você deseja e, a fase mais difícil,
					aguardar o retorno. Tudo isso gera muita ansiedade, pois você depende dessas respostas
					para dar o próximo passo e tomar as decisões para organizar seu churrasco em casa, no seu domicílio, ou para um evento.
					Para piorar, normalmente, você precisa de rapidez e tem pouco tempo para realizar
					todas essas tarefas.</p>
				<h2 style="margin-left: 20px;">
					O que fazemos?</h2>
				<p class='productDescription'>
					Nós do Orçamento Online já pesquisamos as empresas de churrasco ou churrasqueiros para você e oferecemos um
					conjunto de serviços para atender todas as suas necessidades de organização de um
					churrasco para evento ou festa. Cada churrasqueiro tem uma ficha técnica que mostra exatamente o que
					ele faz, junto com fotos de seus trabalhos. Assim, você só precisa escolher os que
					mais agradarem. Aí você explica apenas uma vez o que precisa e o Orçamento Online
					envia seu pedido para todos os profissionais ou empresas de uma só vez. As respostas chegam rapidamente
					para você, pois nossos fornecedores utilizam a internet como uma verdadeira ferramenta
					de trabalho e estão à espera do seu pedido de orçamento. Você então tem todas as
					informações para fazer as melhores contratações de empresas e profissionais para
					seu churrasco.</p>
				<div class="bigBuyButton">
					<asp:LinkButton title="Solicitar Orçamento Online" class="buttonLinkWithImage" runat="server"
						OnClick="uxbtnPasso1_1_Click">Avançar<img src="/img/buttonArrow.png" alt="Avançar" id="arrowButtonFixPNG"></asp:LinkButton>
				</div>
				<h2 style="margin-left: 20px;">
					Veja a opinião de quem já usou o Orçamento Online</h2>
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
				<h2 style="margin-left: 20px;">
					Que garantias eu tenho?</h2>
				<p class='productDescription'>
					Nós garantimos uma seriedade e dedicação que você não encontra em outros sites.
					No Orçamento Online, você fala diretamente com os donos do site. Portanto, você
					pode ter certeza de que faremos o melhor para você receber os orçamentos que precisa
					para contratar o churrasco que deseja.</p>
				<h2 style="margin-left: 20px;">
					Quanto custa?</h2>
				<p class='productDescription'>
					O melhor de tudo é que você não paga para fazer pedidos de orçamento e contratar
					os fornecedores do Orçamento Online. <strong>Para você, o serviço é totalmente grátis.
						Faça seu pedido de orçamento para festas ou eventos agora mesmo!</strong></p>
				<div class="bigBuyButton">
					<asp:LinkButton title="Solicitar Orçamento Online" class="buttonLinkWithImage" runat="server"
						OnClick="uxbtnPasso1_Click">Avançar<img src="/img/buttonArrow.png" alt="Avançar" id="arrowButtonFixPNG"></asp:LinkButton>
				</div>
			</span>
			<div class="productLargeBox">
				<div class="productTrialForm">
					<div class="frm-solicitar-orcamento">
						<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" Visible="false">
							<asp:View ID="ViewCidade" runat="server">
								<h3 style="margin-top: 10px;">
									Onde será a festa ou evento?</h3>
								<asp:DropDownList ID="uxddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="uxDdlEstado_SelectedIndexChanged">
								</asp:DropDownList>
								<asp:DropDownList ID="uxddlCidade" runat="server">
									<asp:ListItem Value="0">Selecione</asp:ListItem>
								</asp:DropDownList>
								<br />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator998" runat="server" ControlToValidate="uxddlEstado"
									ErrorMessage="" InitialValue="Selecione" Text="O estado deve ser informado." />
								<br />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator999" runat="server" ControlToValidate="uxddlCidade"
									ErrorMessage="" InitialValue="0" Text="A cidade deve ser informada." />
								<div class="bigBuyButton">
									<asp:LinkButton title="Solicitar Orçamento Online" class="buttonLinkWithImage" runat="server"
										OnClick="uxbtnPasso2_Click">Avançar<img src="/img/buttonArrow.png" alt="Avançar" id="arrowButtonFixPNG"></asp:LinkButton>
								</div>
								<b>Passo 1 de 4</b>
							</asp:View>
							<asp:View ID="ViewCategoria" runat="server">
								<h3 style="margin-top: 10px;">
									Que serviços deseja contratar?</h3>
								<ul class="fl">
									<li class="sugestoesOrcamentos">
										<asp:CheckBoxList ID="uxchkCategoriasTema" runat="server" Style="margin: 0 6px 6px 0;">
										</asp:CheckBoxList>
									</li>
									<li>
										<div class="bigBuyButton" align="center">
											<asp:LinkButton title="Solicitar Orçamento Online" class="buttonLinkWithImage" runat="server"
												OnClick="uxbtnPasso3_Click">Avançar<img src="/img/buttonArrow.png" alt="Avançar" id="arrowButtonFixPNG"></asp:LinkButton>
										</div>
										<b>Passo 2 de 4</b></li>
								</ul>
							</asp:View>
							<asp:View ID="ViewFornecedor" runat="server">
								<h3 style="margin-top: 10px;">
									Selecione os fornecedores que agradam você.</h3>
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
								<div class="bigBuyButton" align="center">
									<asp:LinkButton title="Solicitar Orçamento Online" class="buttonLinkWithImage" runat="server"
										OnClick="uxbtnPasso4_Click">Avançar<img src="/img/buttonArrow.png" alt="Avançar" id="arrowButtonFixPNG"></asp:LinkButton>
								</div>
								<b>Passo 3 de 4</b>
							</asp:View>
							<asp:View ID="ViewDadosComprador" runat="server">
								<h3 style="margin-top: 10px;">
									Dê informações sobre o seu evento</h3>
								<div style="float: left; width: 49%;">
									<ul class="fl">
										<li>
											<label>
												Evento:</label>
											<asp:DropDownList ID="uxddlTipoEvento" runat="server">
												<asp:ListItem Value="0">Selecione</asp:ListItem>
												<asp:ListItem>Aniversário</asp:ListItem>
												<asp:ListItem>Casamento</asp:ListItem>
												<asp:ListItem>Confraternização</asp:ListItem>
												<asp:ListItem>Festa de 15 anos (debutante)</asp:ListItem>
											</asp:DropDownList>
											<br />
											<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="uxddlTipoEvento"
												ErrorMessage="" Text="O tipo de evento deve ser informado." InitialValue="0" /><br />
										</li>
										<li>
											<label>
												Quando?</label>
											<asp:TextBox ID="uxtxtDataEvento" runat="server" MaxLength="10" Style="width: 140px;"></asp:TextBox><br />
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
											<asp:TextBox ID="uxtxtNumeroConvidados" runat="server" MaxLength="10" Style="width: 140px;"></asp:TextBox><br />
											<cc1:FilteredTextBoxExtender ID="ftNumeroConvidados" runat="server" TargetControlID="uxtxtNumeroConvidados"
												FilterType="Numbers" />
											<asp:RequiredFieldValidator ID="rfNumeroConvidados" runat="server" ControlToValidate="uxtxtNumeroConvidados"
												ErrorMessage="" Text="O número de convidados deve ser informado." />
										</li>
										<li>
											<label>
												Número de crianças até 10 anos:</label>
											<asp:TextBox ID="uxtxtNumeroCriancas" runat="server" MaxLength="10" Style="width: 140px;"></asp:TextBox><br />
											<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="uxtxtNumeroConvidados"
												FilterType="Numbers" />
											<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxtxtNumeroConvidados"
												ErrorMessage="" Text="O número de convidados deve ser informado." />
										</li>
										<li>
											<label>
												Bairro, região ou local:</label>
											<asp:TextBox ID="uxtxtLocalEvento" runat="server" MaxLength="200" Width="256px"></asp:TextBox>
										</li>
										<li>
											<label>
												Hora de início/fim:</label>
											<asp:TextBox ID="uxtxtHoraInicio" runat="server" MaxLength="5" Width="50px"></asp:TextBox>&nbsp;/&nbsp;<asp:TextBox ID="uxtxtHoraFim" runat="server" MaxLength="5" Width="50px"></asp:TextBox>
											<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="uxtxtHoraInicio"
												ValidChars=":" FilterType="Numbers,Custom" />
											<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="uxtxtHoraFim"
												ValidChars=":" FilterType="Numbers,Custom" />
										</li>
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
												O que deseja orçar? (Fale sobre o estilo de festa, tipo de comida, etc.)</label>
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
								<b>Passo 4 de 4</b>
							</asp:View>
						</asp:MultiView>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
