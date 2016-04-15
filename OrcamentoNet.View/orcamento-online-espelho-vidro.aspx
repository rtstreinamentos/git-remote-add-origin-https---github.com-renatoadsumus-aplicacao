<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet.Master"
    CodeBehind="orcamento-online-espelho-vidro.aspx.cs" Inherits="OrcamentoNet.View.orcamento_online_espelho" %>

<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc2" %>
<%@ Register Src="controles/LinksInternosControle.ascx" TagName="LinksInternosControle"
    TagPrefix="uc8" %>
<%@ Register Src="controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="uc13" %>
<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc3" %>
    
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
    <%@ Register Src="/controles/CategoriaListaControle.ascx" TagName="CategoriaListaControle"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta name="keywords" content="casa,dicas,jardim,lâmpadas,limpeza,luminárias,piscina,piso,vidro,álcool,amônia,azulejos,brilho,truques,vinagre,alergia,bomba de água,mangueiras,microclima,repelir mosquitos,terraço,vantagens,varanda,acabamento,aquarela,brilhante,decoração,fosco,janelas,quadros,vidros,cores,móveis,sala,sofá multifunção,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,construção,construção ecológica,estruturas,gradua,lar sustentável,materiais de construção,meio ambiente,painéis,crianças,flores,poupar tempo,regadeira automática,regar,economia,eletrodomésticos,lava louça,máquina de lavar louça,almofadas,cuidado,manutenção,móveis d evime,móveis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,iluminação,potenciômetro,quarto dasc rianças,regulador,tomada,aço,barco,caracol,corrimãos,escadas,imperial,madeira,material,metal,modelos,segurança,apartamento de aluguel,idéias,luz natural,sofá,bustos,esculturas,estilo clássico,estilo eclético,figura de mármore,cômodidade,cortinas motorizadas,economia energética,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos automáticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retrô,poltrona,puf,sacada,tapete,baú,brinquedos,faixas decorativas,paredes,quarto de bebês,quarto de crianças, Comercial, Escritório, Grafiato,  Residência, Serviço, Textura, Condomínio, Profissional de Porta, Residencial, Preço, reformas, obras e reformas, construtores, orçamentos de reformas, orçamentos, obras, arquitetura, decoração de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
    <meta property="og:locale" content="pt_BR">
    <meta property="og:type" content="website">
    <meta property="og:site_name" content="Orçamento Online Grátis">
    <meta property="article:tag" content="Residência, Serviço, Textura, Condomínio, Profissional de Porta, Residencial, Preço, reformas, obras e reformas, construtores, orçamentos de reformas, orçamentos, obras, arquitetura, decoração de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior, festas, eventos, construção, preço, orçamento, sistema segurança, CFTV, manutenção predial, limpeza fachada" />
    <meta property="article:section" content="Orçamento Grátis" />
    <meta property="article:author" content="Orçamento Grátis">
    <meta property="og:url" content="http://orcamentosgratis.net.br/" />
    <meta property="og:image" content="http://orcamentosgratis.net.br/img/fechando-negocios-orcamento-online.jpg" />
    <meta property="og:image:type" content="image/jpg">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType3">
        <div style="float: left;">
            <p>
                <img src="img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
                    class="productImg fl" /><br />
                &nbsp;<br />

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

            </p>
        </div>
        <div class="productText fl" itemscope itemtype="http://schema.org/NewsArticle">
            <h1 id="uxTituloH1" runat="server" itemprop="headline">
            </h1>
            <p class="productDescription">
                <uc2:MensagemSuperiorControle ID="MensagemSuperiorControle1" runat="server" />
                <p class="productDescription" style="padding-left: 80px; text-align=right;" itemprop="description">
                    <em>O Orçamento Online mostrou-se uma ferramenta muito prática, direcionando um pedido
                        de orçamento para os estabelecimentos e poupando tempo de pesquisa de minha parte.</em><br />
                    Luciane Tomiyasu - Orçamento de Buffet Japonês - SP</p>
                <p id="uxTrocarFormulario" visible="false" runat="server">
                    <a href="/orcamento-online.aspx#listaOrcamentos" title="Clique para mudar o tipo de orçamento que deseja solicitar">
                        Quero outro tipo de orçamento</a>. Consulte nossa <a href="http://rcmsolucoes.com/politica-de-privacidade/"
                            target="_blank">política de privacidade</a>.</p>
            </p>
            <div class="tipos-orcamentos" id="uxOrcamentosMaisPopulares" visible="false" runat="server">
                <p class="productDescription">
                    Veja os tipos de orçamentos e cotações de preços mais populares:</p>
                <ul class="checkList">
                    <li><a href='/preco-casamento-1.aspx' title='Solicite orçamento online grátis para casamentos. Receba cotação de preços de vários fornecedores de casamentos. Prático, simples, eficaz e grátis!'>
                        Casamento</a></li>
                    <li><a href="/preco-reforma-banheiro-10.aspx" title="Solicite orçamento online grátis de reforma de banheiro. Receba cotação de preços de vários fornecedores de reformas. Prático, simples, eficaz e grátis!">
                        Reforma Banheiro</a></li>
                    <li><a href='/preco-debutante-4.aspx' title='Solicite orçamento online grátis para festas de 15 anos (debutantes). Receba cotação de preços de vários fornecedores de festas de 15 anos (debutantes). Prático, simples, eficaz e grátis!'>
                        15 anos (debutante)</a></li>
                    <li><a href="/preco-obras-reformas-construcao-imovel-11.aspx" title="Solicite orçamento online grátis de obras, reformas, construção de imóvel. Receba cotação de preços de várias empresas de obras, reformas, construção de imóvel. Prático, simples, eficaz e grátis!">
                        Reforma Imóvel</a></li>
                    <li><a href='/preco-confraternizacao-2.aspx' title='Solicite orçamento online grátis para confraternizações. Receba cotação de preços de vários fornecedores de confraternizações. Prático, simples, eficaz e grátis!'>
                        Confraternização</a></li>
                    <li><a href="/orcamento-online-obras-reformas-construcao-pintura-27.aspx" title="Solicite orçamento online grátis de obras, reformas, construção, pintura e pintor profissional. Receba cotação de preços de vários fornecedores de obras, reformas, construção, pintura e pintor profissional. Prático, simples, eficaz e grátis!">
                        Obras, Reformas e Construção</a></li>
                    <li><a href='/preco-aniversario-3.aspx' title='Solicite orçamento online grátis para aniversários. Receba cotação de preços de vários fornecedores de aniversários. Prático, simples, eficaz e grátis!'>
                        Aniversário</a></li>
                    <li><a href="/orcamento-online-reforma-fachada-predio-182.aspx" title="Solicite orçamento online grátis de serviços em fachadas prediais. Receba cotação de preços de vários fornecedores de serviços em fachadas prediais. Prático, simples, eficaz e grátis!">
                        Pintura e Limpeza de Fachadas Prediais</a></li>
                    <li><a href='/preco-festa-infantil-5.aspx' title='Solicite orçamento online grátis para festas infantis. Receba cotação de preços de vários fornecedores de festas infantis. Prático, simples, eficaz e grátis!'>
                        Festa Infantil</a></li>
                    <li><a href="/orcamento-online.aspx#listaOrcamentos" title="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!">
                        Outros orçamentos</a></li>
                </ul>
            </div>
            <div style="clear: both; margin-left: 40px;">
                <asp:ValidationSummary ID="valSum" runat="server" HeaderText="<strong>Não foi possível enviar seu pedido de orçamento. Por favor, corrija os campos e tente novamente.</strong>"
                    DisplayMode="BulletList" />
            </div>
            <div class="productLargeBox">
                <div class="productTrialForm">
                    <div class="frm-solicitar-orcamento">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uxddlLigacao"
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
                    Tipo:</label>
                <asp:DropDownList ID="uxddlTipo" runat="server">
                    <asp:ListItem>Selecionar</asp:ListItem>
                    <asp:ListItem>Box</asp:ListItem>
                    <asp:ListItem>Espelho</asp:ListItem>
                    <asp:ListItem>Vidro</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label>
                    Largura aproximada (cm):</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtLargura" runat="server" MaxLength="8"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="uxtxtLargura"
                    FilterType="Custom,Numbers" ValidChars=" .,">
                </cc1:FilteredTextBoxExtender>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxtxtLargura"
                    ErrorMessage="" Text="A largura deve ser informada.">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <label>
                    Altura aproximada (cm):</label>
                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtAltura" runat="server" MaxLength="8"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="uxtxtAltura"
                    FilterType="Custom,Numbers" ValidChars=" .,">
                </cc1:FilteredTextBoxExtender>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxtxtAltura"
                    ErrorMessage="" Text="A altura deve ser informada.">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <uc3:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
            </li>
             <li>
				<label>
					Bairro, região ou local:</label>
				<asp:TextBox ID="uxtxtLocalObra" runat="server" MaxLength="200" Width="256px"></asp:TextBox>
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
                    Fotos do local(max 2MB por foto):
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
                    </div>
                </div>
                <!-- end productPriceContainer -->
            </div>
            <!-- end productText -->
        </div>
        <!-- end productPrice -->
    </div>
    <div class="horizontalSep">
        <!-- -->
    </div>
    <asp:Label ID="uxlblExplicacao" runat="server"></asp:Label>
    <div class="horizontalSep">
        <!-- -->
    </div>
    <h2>
        Últimos Pedidos de Orçamento
    </h2>
    <uc13:PedidosOrcamentoControle ID="PedidosOrcamentoControle1" runat="server" />
    <!-- end productHeadingType3 -->
    <uc8:LinksInternosControle ID="LinksInternosControle1" runat="server" />
    <uc1:categorialistacontrole id="CategoriaListaControle1" runat="server" />
    <div class="horizontalSep">
        <!-- -->
    </div>
    <div class="tipos-orcamentos">
        <h3 id="H1" runat="server">
            Você também solicitar orçamentos de</h3>
        <ul class="checkList">
            <li><a href="orcamento-online.aspx?categoria=40&servico=1" title='Solicite orçamento online grátis para pintor e pintores. Receba cotação de preços de vários pintores. Prático, simples, eficaz e grátis!'>
                Pintores</a> </li>
            <li><a href="orcamento-online.aspx?categoria=186&servico=2" title='Solicite orçamento online grátis para construtoras e empresas de reforma. Receba cotação de preços de várioas construtoras e empresas de reforma. Prático, simples, eficaz e grátis!'>
                Construção</a></li>
            <li><a href="orcamento-online.aspx?categoria=155&servico=3" title='Solicite orçamento online grátis para arquitetos. Receba cotação de preços de vários arquitetos. Prático, simples, eficaz e grátis!'>
                Arquitetos</a></li>
            <li><a href="orcamento-online.aspx?categoria=186&servico=4" title='Solicite orçamento online grátis para construtoras e empresas de reforma. Receba cotação de preços de várias construtoras e empresas de reforma. Prático, simples, eficaz e grátis!'>
                Reformas</a></li>
            <li><a href="orcamento-online.aspx?categoria=155&servico=5" title='Solicite orçamento online grátis para Designer de Interior. Receba cotação de preços Designer de Interior. Prático, simples, eficaz e grátis!'>
                Designer de Interior</a></li>
        </ul>
    </div>
    <div class="horizontalSep">
        <!-- -->
    </div>
    <h2>
        Como funciona o Orçamento Online?</h2>
    <p style="margin-bottom: 20px;">
        Seu pedido de orçamento para compra de produtos ou contratação de serviços será
        encaminhado a diversos fornecedores (lojas, empresas, consultorias, prestadores
        de serviços profissionais, autônomos), que entrarão em contato diretamente com você.
        Toda a negociação quanto a preços, formas de pagamento e prazos ocorre diretamente
        entre o comprador e o fornecedor. O site Orçamento Online não tem nenhuma participação
        no orçamento, nem no fornecimento do produto ou serviço, a não ser atuar como ponte
        de contato entre o comprador e o fornecedor.</p>
    <h2>
        Sou um comprador. Quanto pago e como faço para pedir um orçamento online?</h2>
    <p style="margin-bottom: 20px;">
        Nada. <strong>O Orçamento Online é grátis.</strong>. <a href="/orcamento-online.aspx#listaOrcamentos"
            title="Solicite orçamento online grátis de diversos produtos e serviços.">Solicite
            já seu orçamento!</a></p>
    <h2>
        Sou um fornecedor. Como faço para receber os Pedidos de Orçamento?</h2>
    <p style="margin-bottom: 20px;">
        Você deve fazer seu <a href="cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos">
            cadastro como fornecedor</a> no Orçamento Online para receber os pedidos de
        orçamento. Trabalhamos apenas com profissionais e empresas diferenciados, competentes,
        capacitados, que prestam serviços ou fornecem produtos de reconhecida qualidade.</p>
</asp:Content>
<asp:Content ID="cpObjetivoSecundarioPagina" ContentPlaceHolderID="cpObjetivoSecundarioPagina"
    runat="server">
    <div id="fb-root">
    </div>

    <script>        (function(d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/pt_BR/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));</script>

    <asp:Literal ID="uxlblFacebook" runat="server"></asp:Literal>
</asp:Content>
