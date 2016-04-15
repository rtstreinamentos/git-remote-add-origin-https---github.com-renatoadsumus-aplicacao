<%@ Page Language="C#" MasterPageFile="~/OrcamentoNet.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="OrcamentoNet.View.Default" %>

<%@ OutputCache Duration="14400" VaryByParam="none" Location="Server"%>
<%@ Register Src="/controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="ucPedidosOrcamentoControle" %>
<%@ Register Src="/controles/CategoriaListaControle.ascx" TagName="CategoriaListaControle"
    TagPrefix="uc1" %>
<%@ Register Src="/controles/FornecedoresControle.ascx" TagName="Fornecedores" TagPrefix="uc1" %>
<asp:Content ID="cpHead" ContentPlaceHolderID="Head" runat="server">
    <title>Orçamento Online - Cotação de Preços Grátis</title>
    <meta name="description" content="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores. Prático, simples, eficaz e grátis!" />
    <meta name="keywords" content="casa,dicas,jardim,lâmpadas,limpeza,luminárias,piscina,piso,vidro,álcool,amônia,azulejos,brilho,truques,vinagre,alergia,bomba de água,mangueiras,microclima,repelir mosquitos,terraço,vantagens,varanda,acabamento,aquarela,brilhante,decoração,fosco,janelas,quadros,vidros,cores,móveis,sala,sofá multifunção,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,construção,construção ecológica,estruturas,gradua,lar sustentável,materiais de construção,meio ambiente,painéis,crianças,flores,poupar tempo,regadeira automática,regar,economia,eletrodomésticos,lava louça,máquina de lavar louça,almofadas,cuidado,manutenção,móveis d evime,móveis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,iluminação,potenciômetro,quarto dasc rianças,regulador,tomada,aço,barco,caracol,corrimãos,escadas,imperial,madeira,material,metal,modelos,segurança,apartamento de aluguel,idéias,luz natural,sofá,bustos,esculturas,estilo clássico,estilo eclético,figura de mármore,cômodidade,cortinas motorizadas,economia energética,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos automáticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retrô,poltrona,puf,sacada,tapete,baú,brinquedos,faixas decorativas,paredes,quarto de bebês,quarto de crianças, Comercial, Escritório, Grafiato,  Residência, Serviço, Textura, Condomínio, Profissional de Porta, Residencial, Preço, reformas, obras e reformas, construtores, orçamentos de reformas, orçamentos, obras, arquitetura, decoração de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
    <meta property="og:locale" content="pt_BR">
    <meta property="og:title" content="Orçamento Online - Cotação de Preços Grátis" />
    <meta property="og:description" content="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores. Prático, simples, eficaz e grátis!" />
    <meta property="og:type" content="website">
    <meta property="og:site_name" content="Orçamento Online Grátis">
    <meta property="article:tag" content="pintor, pintura, obras, reformas, festas, eventos, cohnstrução, preço, orçamento, sistema segurança, CFTV, manutenção predial, limpeza fachada, orçamento, parede, apartamento, restauração fachada, gesso, gesseiro, bombeiro hidráulico, elétrica, eletrecista, pisos, azulejos, terceirização de serviços, buffet, buffet japonês, fotógrafo" />
    <meta property="article:section" content="Orçamento Grátis" />
    <meta property="article:author" content="Orçamento Grátis">
    <meta property="og:url" content="http://orcamentosgratis.net.br/" />
    <meta property="og:image" content="http://orcamentosgratis.net.br/img/fechando-negocios-orcamento-online.jpg" />
    <meta property="og:image:type" content="image/jpg">
</asp:Content>
<%--<asp:Content ID="cpPaginaDefault" ContentPlaceHolderID="cpPaginaDefault"
    runat="server">
    <div class="destaque section imagemPersona">
            <h1 class="welcome welcome-new">
            Orçamento Online - Cotação de Preços</h1>
            <p class="text-description-banner">Melhores empresas e profissionais da sua cidade!</p>

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
 </asp:Content>--%>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType1">
        <div style="float: left;">
            <img src="/img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
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

        </div>
        <div class="productText fl" itemscope itemtype="http://schema.org/NewsArticle">
            <h1 itemprop="headline">
                Orçamento Online - Cotação de Preços</h1>
            <p class="productDescription" itemprop="description">
                O <strong>orçamento online</strong> coloca em contato compradores e uma rede de
                <strong>indicação de fornecedores</strong> (lojas, empresas, prestadores de serviços
                profissionais, autônomos) de diversos ramos de atividade.</p>
            <p class="productDescription">
                Veja alguns tipos de orçamentos e cotações de preços que você pode pedir:</p>
            <ul class="checkList">
                <li><a href='/preco-casamento-1.aspx' title='Solicite orçamento online grátis para casamentos. Receba cotação de preços de vários fornecedores de casamentos. Prático, simples, eficaz e grátis!'>
                    Casamento</a></li>
                <li><a href="/preco-reforma-banheiro-10.aspx" title="Solicite orçamento online grátis para reforma de banheiro. Receba cotação de preços de vários fornecedores de reformas. Prático, simples, eficaz e grátis!">
                    Reforma Banheiro</a></li>
                <li><a href='/preco-debutante-4.aspx' title='Solicite orçamento online grátis para festas de 15 anos (debutantes). Receba cotação de preços de vários fornecedores de festas de 15 anos (debutantes). Prático, simples, eficaz e grátis!'>
                    15 anos (debutante)</a></li>
                <li><a href="/preco-reforma-cozinha-12.aspx" title="Solicite orçamento online grátis de obras, reformas, construção de cozinha. Receba cotação de preços de várias empresas de obras, reformas, construção de cozinha. Prático, simples, eficaz e grátis!">
                    Reforma Cozinha</a></li>
                <li><a href='/preco-confraternizacao-2.aspx' title='Solicite orçamento online grátis para confraternização. Receba cotação de preços de vários fornecedores confraternização. Prático, simples, eficaz e grátis!'>
                    Confraternização</a></li>
                <li><a href="/preco-obras-reforma-de-casa-11.aspx" title="Solicite orçamento online grátis de obras, reformas, construção e reforma de casa. Receba cotação de preços de várias empresas de obras, reformas, construção e reforma de casa. Prático, simples, eficaz e grátis!">
                    Reforma de Casa</a></li>
                <li><a href='/preco-aniversario-3.aspx' title='Solicite orçamento online grátis para aniversários. Receba cotação de preços de vários fornecedores de aniversários. Prático, simples, eficaz e grátis!'>
                    Aniversário</a></li>
                <li><a href="/orcamento-online-termo.aspx" title="Solicite orçamento online grátis de obras, reformas, construção, pintura e pintor profissional. Receba cotação de preços de vários fornecedores de obras, reformas, construção, pintura e pintor profissional. Prático, simples, eficaz e grátis!">
                    Obras, Reformas e Construção</a></li>
                <li><a href='/preco-festa-infantil-5.aspx' title='Solicite orçamento online grátis para festas infantis. Receba cotação de preços de vários fornecedores de festas infantis. Prático, simples, eficaz e grátis!'>
                    Festa Infantil</a></li>
                <li><a href="/orcamento-online-reforma-fachada-predio-182.aspx" title="Solicite orçamento online grátis de serviços em fachadas prediais. Receba cotação de preços de vários fornecedores de serviços em fachadas prediais. Prático, simples, eficaz e grátis!">
                    Pintura e Limpeza de Fachadas Prediais</a></li>
                <li><a href="/orcamento-online.aspx#listaOrcamentos" title="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!">
                    Outros orçamentos</a></li>
                <li><a href='/preco-camera-seguranca-eletronica-19.aspx' title='Solicite orçamento online grátis para Câmera e Segurança Eletrônica. Receba cotação de preços de vários fornecedores Câmera e Segurança Eletrônica. Prático, simples, eficaz e grátis!'>
                    Câmera e Segurança Eletrônica</a></li>
            </ul>
        </div>
        <!-- end productText -->
        <div class="productPrice fr">
            <div class="productPriceContainer">
                <span>Grátis!</span>
                <p>
                    solicite seu orçamento grátis</p>
                <div id="buttonDarkBG">
                    <a class="buttonLink" href="/orcamento-online.aspx#listaOrcamentos" title="Solicite seu orçamento online de graça">
                        Quero um Orçamento</a>
                </div>
                <!-- end buttonDarkBG -->
            </div>
            <!-- end productPriceContainer -->
        </div>
        <!-- end productPrice -->
    </div>
    <uc1:categorialistacontrole ID="CategoriaListaControle1" runat="server" />
   
        
   
  <div class="horizontalSep">
        <br />
        <h2>
            Projetos e idéias!</h2>
        <br />
    </div>
    <ul class="iconBulletList">
        <li><a href="/casa/decoracao/post-traga-a-beleza-da-camurca-para-as-paredes-de-casa-12.aspx">
            <img src='/FotosPost/8fb68xh9se03z7jo9loeo86g3o741.jpg' alt="Marcador do Orçamento Online"
                width="330px" height="200px" title="Orçamento Online Pintor e Pintura no Rio de Janeiro, São Paulo, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/decoracao/post-traga-a-beleza-da-camurca-para-as-paredes-de-casa-12.aspx">
                <b>Traga a beleza da camurça para as paredes de casa </b></a>
            <br />
            <br />
            O efeito camurça tem aparência manchada e dá um novo visual aos ambientes. </li>
        <li><a href="/casa/arquitetura/post-como-escolher-e-adaptar-o-corrimao-8.aspx">
            <img src='/FotosPost/eu3hbve8ret1sn6j6a5x339in.jpg' alt="Marcador do Orçamento Online"
                width="330px" height="200px" title="Orçamento Online Pintor e Pintura no Rio de Janeiro, São Paulo, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/arquitetura/post-como-escolher-e-adaptar-o-corrimao-8.aspx"><b>Como escolher
                e adaptar o corrimão</b></a>
            <br />
            <br />
            De aço, o corrimão da AAZ aumenta a segurança da escada e confere ares modernos
            ao ambiente. Foto: Divulgacao / AAZ Corrimões </li>
        <li><a href="/casa/arquitetura/post-escolha-a-planta-certa-para-a-sacada-22.aspx">
            <img src='/FotosPost/er2c6bs31jez5jut4dswul5sl.jpg' alt="Marcador do Orçamento Online"
                width="330px" height="200px" title="Orçamento Online Jardinagem e Paisagismo no Rio de Janeiro, São Paulo, Brasília, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/arquitetura/post-escolha-a-planta-certa-para-a-sacada-22.aspx"><b>Escolha
                a planta certa para a sacada</b></a>
            <br />
            <br />
            Conheça as espécies mais indicadas para compor o jardim na varanda... </li>
        <li><a href="/casa/arquitetura/post-30-incriveis-projetos-de-varandas-21.aspx">
            <img src='/FotosPost/d91lplnxyl9up8a9ds6w0nd1e.jpg' alt="Marcador do Orçamento Online"
                width="330px" height="200px" title="Orçamento Online Arquitetos, Design de Interiores no Rio de Janeiro, São Paulo, Brasília, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/arquitetura/post-30-incriveis-projetos-de-varandas-21.aspx"><b>30 incríveis
                projetos de varandas</b></a>
            <br />
            <br />
            Antes usadas apenas para se ter melhor vista, as sacadas estão hoje totalmente integradas
            aos apartamentos... </li>
    </ul>
    <a href="PostBlogForm.aspx?idTema=27">mais posts de obras e reformas</a>
    <div class="horizontalSep">
        <br />
        <h2>
            Festas e Eventos</h2>
        <br />
    </div>
    <ul class="iconBulletList">
        <li><a href="/noivas/cerimoniaefesta/post-cinquenta-comidinhas-de-verao-para-o-buffet-do-casamento-23.aspx">
            <img src='/FotosPost/2yz3z5ns7r2hdvqp5havavrcx.jpg' alt="Marcador do Orçamento Online"
                width="330px" height="200px" title="Orçamento Online Festas e Buffet de Casamento no Rio de Janeiro, São Paulo, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/noivas/cerimoniaefesta/post-cinquenta-comidinhas-de-verao-para-o-buffet-do-casamento-23.aspx">
                <b>Cinquenta comidinhas de verão para o buffet do casamento </b></a>
            <br />
            <br />
            Sugestões de salada, entrada, massas, carnes e sobremesas que combinam com o calor...
        </li>
        <li><a href="/noivas/vestidoseacessorios/post-aliancas-de-casamento-25.aspx">
            <img src='/FotosPost/cd4tgsehqzjhxymcoenywxtyb.jpg' alt="Marcador do Orçamento Online"
                width="330px" height="200px" title="Orçamento Online Festas e Buffet de Casamento no Rio de Janeiro, São Paulo, Brasília, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/noivas/vestidoseacessorios/post-aliancas-de-casamento-25.aspx"><b>Cinquenta
                alianças de casamento</b></a>
            <br />
            <br />
            Saiba como eleger o material e o modelo que mais combinam com o casal, calcule...
        </li>
    </ul>
    <a href="PostBlogForm.aspx?idTema=52">mais posts de festas e eventos</a>
    <div class="horizontalSep">
    </div>
    <div itemscope itemtype="http://schema.org/NewsArticle">
    <h2 itemprop="headline">
        Como funciona o Orçamento Online?</h2>
    <p style="margin-bottom: 20px;" itemprop="description">
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
        Nada. <strong>O Orçamento Online é grátis.</strong> <a href="/orcamento-online.aspx#listaOrcamentos"
            title="Solicite orçamento online grátis de diversos produtos e serviços.">Solicite
            já seu orçamento!</a></p>
    <h2>
        Sou uma empresa ou profissional. Como faço para receber os Pedidos de Orçamento?</h2>
    <p style="margin-bottom: 20px;">
        Você deve fazer seu <a href="novo-fornecedore-passo1.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos">
            cadastro como fornecedor</a> no Orçamento Online para receber os pedidos de
        orçamento. Trabalhamos apenas com profissionais e empresas diferenciados, competentes,
        capacitados, que prestam serviços ou fornecem produtos de reconhecida qualidade.</p>
    <h2>
        Ainda está com dúvida?</h2>
    <p style="margin-bottom: 20px;">
        Veja nossa<a href="Faq.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos">
            faq, nela você encontrará um roteiro de perguntas e respostas! </a>
    </p>
    </div>
    <!--Product Testimonial Section Starts Here -->
    <uc1:Fornecedores ID="Fornecedores1" runat="server" />
    <div class="horizontalSep">
    </div>
</asp:Content>
<asp:Content ID="cpObjetivoSecundarioPagina" ContentPlaceHolderID="cpObjetivoSecundarioPagina"
    runat="server">
    <h2>
        Últimos Pedidos de Orçamento
    </h2>
    <ucPedidosOrcamentoControle:PedidosOrcamentoControle ID="ultimosPedidosOrcamento"
        runat="server" />
    <div class="testimonialContainer" itemscope itemtype="http://schema.org/NewsArticle">
        <div id="boxHeading">
            <h3 itemprop="headline">
                Depoimentos de pessoas como você!</h3>
        </div>
        <!-- end boxHeading -->
        <ul class="testimonials" >
            <li itemprop="description">Agradeço a atenção mas já fechamos o orçamento, contaremos com vocês de uma proxima
                vez se possivel. <span>LAERCIO ALVES - RJ</span></li>
            <li>Agilidade e compromisso no atendimento. <span>Edson Fernandes - RJ</span> </li>
            <li>A possibilidade de receber de forma ágil e fácil os orçamentos de todas as categorias
                solicitadas.<span>FLAVIA - RJ</span> </li>
            <li>A resposta rápida e eficiente ao meu pedido pelos prestadores de serviço ligados
                ao Orçamento Online.<span>Suzamara Fabiano - SP</span> </li>
            <li><a href="ResultadoPesquisaSatisfcao.aspx" target="_blank">veja mais depoimentos!</a></li>
        </ul>
    </div>
</asp:Content>
