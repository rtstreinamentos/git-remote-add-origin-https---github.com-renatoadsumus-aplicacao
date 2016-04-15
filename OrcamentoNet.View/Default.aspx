<%@ Page Language="C#" MasterPageFile="~/OrcamentoNet.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="OrcamentoNet.View.Default" %>

<%@ OutputCache Duration="14400" VaryByParam="none" Location="Server"%>
<%@ Register Src="/controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="ucPedidosOrcamentoControle" %>
<%@ Register Src="/controles/CategoriaListaControle.ascx" TagName="CategoriaListaControle"
    TagPrefix="uc1" %>
<%@ Register Src="/controles/FornecedoresControle.ascx" TagName="Fornecedores" TagPrefix="uc1" %>
<asp:Content ID="cpHead" ContentPlaceHolderID="Head" runat="server">
    <title>Or�amento Online - Cota��o de Pre�os Gr�tis</title>
    <meta name="description" content="Solicite or�amento online gr�tis de diversos produtos e servi�os. Receba cota��o de pre�os de v�rios fornecedores. Pr�tico, simples, eficaz e gr�tis!" />
    <meta name="keywords" content="casa,dicas,jardim,l�mpadas,limpeza,lumin�rias,piscina,piso,vidro,�lcool,am�nia,azulejos,brilho,truques,vinagre,alergia,bomba de �gua,mangueiras,microclima,repelir mosquitos,terra�o,vantagens,varanda,acabamento,aquarela,brilhante,decora��o,fosco,janelas,quadros,vidros,cores,m�veis,sala,sof� multifun��o,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,constru��o,constru��o ecol�gica,estruturas,gradua,lar sustent�vel,materiais de constru��o,meio ambiente,pain�is,crian�as,flores,poupar tempo,regadeira autom�tica,regar,economia,eletrodom�sticos,lava lou�a,m�quina de lavar lou�a,almofadas,cuidado,manuten��o,m�veis d evime,m�veis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,ilumina��o,potenci�metro,quarto dasc rian�as,regulador,tomada,a�o,barco,caracol,corrim�os,escadas,imperial,madeira,material,metal,modelos,seguran�a,apartamento de aluguel,id�ias,luz natural,sof�,bustos,esculturas,estilo cl�ssico,estilo ecl�tico,figura de m�rmore,c�modidade,cortinas motorizadas,economia energ�tica,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos autom�ticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retr�,poltrona,puf,sacada,tapete,ba�,brinquedos,faixas decorativas,paredes,quarto de beb�s,quarto de crian�as, Comercial, Escrit�rio, Grafiato,  Resid�ncia, Servi�o, Textura, Condom�nio, Profissional de Porta, Residencial, Pre�o, reformas, obras e reformas, construtores, or�amentos de reformas, or�amentos, obras, arquitetura, decora��o de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
    <meta property="og:locale" content="pt_BR">
    <meta property="og:title" content="Or�amento Online - Cota��o de Pre�os Gr�tis" />
    <meta property="og:description" content="Solicite or�amento online gr�tis de diversos produtos e servi�os. Receba cota��o de pre�os de v�rios fornecedores. Pr�tico, simples, eficaz e gr�tis!" />
    <meta property="og:type" content="website">
    <meta property="og:site_name" content="Or�amento Online Gr�tis">
    <meta property="article:tag" content="pintor, pintura, obras, reformas, festas, eventos, cohnstru��o, pre�o, or�amento, sistema seguran�a, CFTV, manuten��o predial, limpeza fachada, or�amento, parede, apartamento, restaura��o fachada, gesso, gesseiro, bombeiro hidr�ulico, el�trica, eletrecista, pisos, azulejos, terceiriza��o de servi�os, buffet, buffet japon�s, fot�grafo" />
    <meta property="article:section" content="Or�amento Gr�tis" />
    <meta property="article:author" content="Or�amento Gr�tis">
    <meta property="og:url" content="http://orcamentosgratis.net.br/" />
    <meta property="og:image" content="http://orcamentosgratis.net.br/img/fechando-negocios-orcamento-online.jpg" />
    <meta property="og:image:type" content="image/jpg">
</asp:Content>
<%--<asp:Content ID="cpPaginaDefault" ContentPlaceHolderID="cpPaginaDefault"
    runat="server">
    <div class="destaque section imagemPersona">
            <h1 class="welcome welcome-new">
            Or�amento Online - Cota��o de Pre�os</h1>
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
            <img src="/img/fechando-negocios-orcamento-online.jpg" alt="Feche neg�cios atrav�s do Or�amento Online"
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
                Or�amento Online - Cota��o de Pre�os</h1>
            <p class="productDescription" itemprop="description">
                O <strong>or�amento online</strong> coloca em contato compradores e uma rede de
                <strong>indica��o de fornecedores</strong> (lojas, empresas, prestadores de servi�os
                profissionais, aut�nomos) de diversos ramos de atividade.</p>
            <p class="productDescription">
                Veja alguns tipos de or�amentos e cota��es de pre�os que voc� pode pedir:</p>
            <ul class="checkList">
                <li><a href='/preco-casamento-1.aspx' title='Solicite or�amento online gr�tis para casamentos. Receba cota��o de pre�os de v�rios fornecedores de casamentos. Pr�tico, simples, eficaz e gr�tis!'>
                    Casamento</a></li>
                <li><a href="/preco-reforma-banheiro-10.aspx" title="Solicite or�amento online gr�tis para reforma de banheiro. Receba cota��o de pre�os de v�rios fornecedores de reformas. Pr�tico, simples, eficaz e gr�tis!">
                    Reforma Banheiro</a></li>
                <li><a href='/preco-debutante-4.aspx' title='Solicite or�amento online gr�tis para festas de 15 anos (debutantes). Receba cota��o de pre�os de v�rios fornecedores de festas de 15 anos (debutantes). Pr�tico, simples, eficaz e gr�tis!'>
                    15 anos (debutante)</a></li>
                <li><a href="/preco-reforma-cozinha-12.aspx" title="Solicite or�amento online gr�tis de obras, reformas, constru��o de cozinha. Receba cota��o de pre�os de v�rias empresas de obras, reformas, constru��o de cozinha. Pr�tico, simples, eficaz e gr�tis!">
                    Reforma Cozinha</a></li>
                <li><a href='/preco-confraternizacao-2.aspx' title='Solicite or�amento online gr�tis para confraterniza��o. Receba cota��o de pre�os de v�rios fornecedores confraterniza��o. Pr�tico, simples, eficaz e gr�tis!'>
                    Confraterniza��o</a></li>
                <li><a href="/preco-obras-reforma-de-casa-11.aspx" title="Solicite or�amento online gr�tis de obras, reformas, constru��o e reforma de casa. Receba cota��o de pre�os de v�rias empresas de obras, reformas, constru��o e reforma de casa. Pr�tico, simples, eficaz e gr�tis!">
                    Reforma de Casa</a></li>
                <li><a href='/preco-aniversario-3.aspx' title='Solicite or�amento online gr�tis para anivers�rios. Receba cota��o de pre�os de v�rios fornecedores de anivers�rios. Pr�tico, simples, eficaz e gr�tis!'>
                    Anivers�rio</a></li>
                <li><a href="/orcamento-online-termo.aspx" title="Solicite or�amento online gr�tis de obras, reformas, constru��o, pintura e pintor profissional. Receba cota��o de pre�os de v�rios fornecedores de obras, reformas, constru��o, pintura e pintor profissional. Pr�tico, simples, eficaz e gr�tis!">
                    Obras, Reformas e Constru��o</a></li>
                <li><a href='/preco-festa-infantil-5.aspx' title='Solicite or�amento online gr�tis para festas infantis. Receba cota��o de pre�os de v�rios fornecedores de festas infantis. Pr�tico, simples, eficaz e gr�tis!'>
                    Festa Infantil</a></li>
                <li><a href="/orcamento-online-reforma-fachada-predio-182.aspx" title="Solicite or�amento online gr�tis de servi�os em fachadas prediais. Receba cota��o de pre�os de v�rios fornecedores de servi�os em fachadas prediais. Pr�tico, simples, eficaz e gr�tis!">
                    Pintura e Limpeza de Fachadas Prediais</a></li>
                <li><a href="/orcamento-online.aspx#listaOrcamentos" title="Solicite or�amento online gr�tis de diversos produtos e servi�os. Receba cota��o de pre�os de v�rios fornecedores de diversos produtos e servi�os. Pr�tico, simples, eficaz e gr�tis!">
                    Outros or�amentos</a></li>
                <li><a href='/preco-camera-seguranca-eletronica-19.aspx' title='Solicite or�amento online gr�tis para C�mera e Seguran�a Eletr�nica. Receba cota��o de pre�os de v�rios fornecedores C�mera e Seguran�a Eletr�nica. Pr�tico, simples, eficaz e gr�tis!'>
                    C�mera e Seguran�a Eletr�nica</a></li>
            </ul>
        </div>
        <!-- end productText -->
        <div class="productPrice fr">
            <div class="productPriceContainer">
                <span>Gr�tis!</span>
                <p>
                    solicite seu or�amento gr�tis</p>
                <div id="buttonDarkBG">
                    <a class="buttonLink" href="/orcamento-online.aspx#listaOrcamentos" title="Solicite seu or�amento online de gra�a">
                        Quero um Or�amento</a>
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
            Projetos e id�ias!</h2>
        <br />
    </div>
    <ul class="iconBulletList">
        <li><a href="/casa/decoracao/post-traga-a-beleza-da-camurca-para-as-paredes-de-casa-12.aspx">
            <img src='/FotosPost/8fb68xh9se03z7jo9loeo86g3o741.jpg' alt="Marcador do Or�amento Online"
                width="330px" height="200px" title="Or�amento Online Pintor e Pintura no Rio de Janeiro, S�o Paulo, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/decoracao/post-traga-a-beleza-da-camurca-para-as-paredes-de-casa-12.aspx">
                <b>Traga a beleza da camur�a para as paredes de casa </b></a>
            <br />
            <br />
            O efeito camur�a tem apar�ncia manchada e d� um novo visual aos ambientes. </li>
        <li><a href="/casa/arquitetura/post-como-escolher-e-adaptar-o-corrimao-8.aspx">
            <img src='/FotosPost/eu3hbve8ret1sn6j6a5x339in.jpg' alt="Marcador do Or�amento Online"
                width="330px" height="200px" title="Or�amento Online Pintor e Pintura no Rio de Janeiro, S�o Paulo, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/arquitetura/post-como-escolher-e-adaptar-o-corrimao-8.aspx"><b>Como escolher
                e adaptar o corrim�o</b></a>
            <br />
            <br />
            De a�o, o corrim�o da AAZ aumenta a seguran�a da escada e confere ares modernos
            ao ambiente. Foto: Divulgacao / AAZ Corrim�es </li>
        <li><a href="/casa/arquitetura/post-escolha-a-planta-certa-para-a-sacada-22.aspx">
            <img src='/FotosPost/er2c6bs31jez5jut4dswul5sl.jpg' alt="Marcador do Or�amento Online"
                width="330px" height="200px" title="Or�amento Online Jardinagem e Paisagismo no Rio de Janeiro, S�o Paulo, Bras�lia, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/arquitetura/post-escolha-a-planta-certa-para-a-sacada-22.aspx"><b>Escolha
                a planta certa para a sacada</b></a>
            <br />
            <br />
            Conhe�a as esp�cies mais indicadas para compor o jardim na varanda... </li>
        <li><a href="/casa/arquitetura/post-30-incriveis-projetos-de-varandas-21.aspx">
            <img src='/FotosPost/d91lplnxyl9up8a9ds6w0nd1e.jpg' alt="Marcador do Or�amento Online"
                width="330px" height="200px" title="Or�amento Online Arquitetos, Design de Interiores no Rio de Janeiro, S�o Paulo, Bras�lia, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/casa/arquitetura/post-30-incriveis-projetos-de-varandas-21.aspx"><b>30 incr�veis
                projetos de varandas</b></a>
            <br />
            <br />
            Antes usadas apenas para se ter melhor vista, as sacadas est�o hoje totalmente integradas
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
            <img src='/FotosPost/2yz3z5ns7r2hdvqp5havavrcx.jpg' alt="Marcador do Or�amento Online"
                width="330px" height="200px" title="Or�amento Online Festas e Buffet de Casamento no Rio de Janeiro, S�o Paulo, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/noivas/cerimoniaefesta/post-cinquenta-comidinhas-de-verao-para-o-buffet-do-casamento-23.aspx">
                <b>Cinquenta comidinhas de ver�o para o buffet do casamento </b></a>
            <br />
            <br />
            Sugest�es de salada, entrada, massas, carnes e sobremesas que combinam com o calor...
        </li>
        <li><a href="/noivas/vestidoseacessorios/post-aliancas-de-casamento-25.aspx">
            <img src='/FotosPost/cd4tgsehqzjhxymcoenywxtyb.jpg' alt="Marcador do Or�amento Online"
                width="330px" height="200px" title="Or�amento Online Festas e Buffet de Casamento no Rio de Janeiro, S�o Paulo, Bras�lia, Curitiba e Salvador" /></a>
            <br />
            <br />
            <a href="/noivas/vestidoseacessorios/post-aliancas-de-casamento-25.aspx"><b>Cinquenta
                alian�as de casamento</b></a>
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
        Como funciona o Or�amento Online?</h2>
    <p style="margin-bottom: 20px;" itemprop="description">
        Seu pedido de or�amento para compra de produtos ou contrata��o de servi�os ser�
        encaminhado a diversos fornecedores (lojas, empresas, consultorias, prestadores
        de servi�os profissionais, aut�nomos), que entrar�o em contato diretamente com voc�.
        Toda a negocia��o quanto a pre�os, formas de pagamento e prazos ocorre diretamente
        entre o comprador e o fornecedor. O site Or�amento Online n�o tem nenhuma participa��o
        no or�amento, nem no fornecimento do produto ou servi�o, a n�o ser atuar como ponte
        de contato entre o comprador e o fornecedor.</p>
    <h2>
        Sou um comprador. Quanto pago e como fa�o para pedir um or�amento online?</h2>
    <p style="margin-bottom: 20px;">
        Nada. <strong>O Or�amento Online � gr�tis.</strong> <a href="/orcamento-online.aspx#listaOrcamentos"
            title="Solicite or�amento online gr�tis de diversos produtos e servi�os.">Solicite
            j� seu or�amento!</a></p>
    <h2>
        Sou uma empresa ou profissional. Como fa�o para receber os Pedidos de Or�amento?</h2>
    <p style="margin-bottom: 20px;">
        Voc� deve fazer seu <a href="novo-fornecedore-passo1.aspx" title="Cadastro de Fornecedor: participe de cota��es e envie or�amentos">
            cadastro como fornecedor</a> no Or�amento Online para receber os pedidos de
        or�amento. Trabalhamos apenas com profissionais e empresas diferenciados, competentes,
        capacitados, que prestam servi�os ou fornecem produtos de reconhecida qualidade.</p>
    <h2>
        Ainda est� com d�vida?</h2>
    <p style="margin-bottom: 20px;">
        Veja nossa<a href="Faq.aspx" title="Cadastro de Fornecedor: participe de cota��es e envie or�amentos">
            faq, nela voc� encontrar� um roteiro de perguntas e respostas! </a>
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
        �ltimos Pedidos de Or�amento
    </h2>
    <ucPedidosOrcamentoControle:PedidosOrcamentoControle ID="ultimosPedidosOrcamento"
        runat="server" />
    <div class="testimonialContainer" itemscope itemtype="http://schema.org/NewsArticle">
        <div id="boxHeading">
            <h3 itemprop="headline">
                Depoimentos de pessoas como voc�!</h3>
        </div>
        <!-- end boxHeading -->
        <ul class="testimonials" >
            <li itemprop="description">Agrade�o a aten��o mas j� fechamos o or�amento, contaremos com voc�s de uma proxima
                vez se possivel. <span>LAERCIO ALVES - RJ</span></li>
            <li>Agilidade e compromisso no atendimento. <span>Edson Fernandes - RJ</span> </li>
            <li>A possibilidade de receber de forma �gil e f�cil os or�amentos de todas as categorias
                solicitadas.<span>FLAVIA - RJ</span> </li>
            <li>A resposta r�pida e eficiente ao meu pedido pelos prestadores de servi�o ligados
                ao Or�amento Online.<span>Suzamara Fabiano - SP</span> </li>
            <li><a href="ResultadoPesquisaSatisfcao.aspx" target="_blank">veja mais depoimentos!</a></li>
        </ul>
    </div>
</asp:Content>
