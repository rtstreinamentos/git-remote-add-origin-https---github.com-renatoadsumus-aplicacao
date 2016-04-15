<%@ Page Language="C#" MasterPageFile="~/OrcamentoNet.Master" AutoEventWireup="true"
    CodeBehind="orcamento-online.aspx.cs" Inherits="OrcamentoNet.View.OrcamentoOnline " %>

<%@ OutputCache Duration="14400" VaryByParam="categoria;cidade;termo;bairro" Location="Server"%>
<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc2" %>
<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc3" %>
<%@ Register Src="/controles/OrcamentoFormularioGenerico.ascx" TagName="OrcamentoFormularioGenerico"
    TagPrefix="uc6" %>
<%@ Register Src="/controles/OrcamentoFormularioEvento.ascx" TagName="OrcamentoFormularioEvento"
    TagPrefix="uc5" %>
<%@ Register Src="/controles/OrcamentoFormularioConstrucao.ascx" TagName="OrcamentoFormularioConstrucao"
    TagPrefix="uc7" %>
<%@ Register Src="/controles/OrcamentoFormularioEspelhoVidro.ascx" TagName="OrcamentoFormularioEspelhoVidro"
    TagPrefix="uc4" %>
<%@ Register Src="/controles/OrcamentoFormularioCFTV.ascx" TagName="OrcamentoFormularioCFTV"
    TagPrefix="uc9" %>
<%@ Register Src="/controles/OrcamentoFormularioMudanca.ascx" TagName="OrcamentoFormularioMudanca"
    TagPrefix="uc11" %>
<%@ Register Src="/controles/CategoriaListaControle.ascx" TagName="CategoriaListaControle"
    TagPrefix="uc1" %>
<%@ Register Src="controles/OrcamentoFormularioFachadaPredial.ascx" TagName="OrcamentoFormularioFachadaPredial"
    TagPrefix="uc10" %>
<%@ Register Src="controles/OrcamentoFormularioCasaDecoracao.ascx" TagName="OrcamentoFormularioCasaDecoracao"
    TagPrefix="uc12" %>
<%@ Register Src="controles/LinksInternosControle.ascx" TagName="LinksInternosControle"
    TagPrefix="uc8" %>
<%@ Register Src="controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="uc13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta name="keywords" content="casa,dicas,jardim,l�mpadas,limpeza,lumin�rias,piscina,piso,vidro,�lcool,am�nia,azulejos,brilho,truques,vinagre,alergia,bomba de �gua,mangueiras,microclima,repelir mosquitos,terra�o,vantagens,varanda,acabamento,aquarela,brilhante,decora��o,fosco,janelas,quadros,vidros,cores,m�veis,sala,sof� multifun��o,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,constru��o,constru��o ecol�gica,estruturas,gradua,lar sustent�vel,materiais de constru��o,meio ambiente,pain�is,crian�as,flores,poupar tempo,regadeira autom�tica,regar,economia,eletrodom�sticos,lava lou�a,m�quina de lavar lou�a,almofadas,cuidado,manuten��o,m�veis d evime,m�veis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,ilumina��o,potenci�metro,quarto dasc rian�as,regulador,tomada,a�o,barco,caracol,corrim�os,escadas,imperial,madeira,material,metal,modelos,seguran�a,apartamento de aluguel,id�ias,luz natural,sof�,bustos,esculturas,estilo cl�ssico,estilo ecl�tico,figura de m�rmore,c�modidade,cortinas motorizadas,economia energ�tica,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos autom�ticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retr�,poltrona,puf,sacada,tapete,ba�,brinquedos,faixas decorativas,paredes,quarto de beb�s,quarto de crian�as, Comercial, Escrit�rio, Grafiato,  Resid�ncia, Servi�o, Textura, Condom�nio, Profissional de Porta, Residencial, Pre�o, reformas, obras e reformas, construtores, or�amentos de reformas, or�amentos, obras, arquitetura, decora��o de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
     <meta property="og:locale" content="pt_BR">    
    <meta property="og:type" content="website">
    <meta property="og:site_name" content="Or�amento Online Gr�tis">
    <meta property="article:tag" content="Resid�ncia, Servi�o, Textura, Condom�nio, Profissional de Porta, Residencial, Pre�o, reformas, obras e reformas, construtores, or�amentos de reformas, or�amentos, obras, arquitetura, decora��o de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior, festas, eventos, constru��o, pre�o, or�amento, sistema seguran�a, CFTV, manuten��o predial, limpeza fachada" />
    <meta property="article:section" content="Or�amento Gr�tis" />
    <meta property="article:author" content="Or�amento Gr�tis">
    <meta property="og:url" content="http://orcamentosgratis.net.br/" />
    <meta property="og:image" content="http://orcamentosgratis.net.br/img/fechando-negocios-orcamento-online.jpg" />
    <meta property="og:image:type" content="image/jpg">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType3">
        <div style="float: left;">
            <p>
                <img src="img/fechando-negocios-orcamento-online.jpg" alt="Feche neg�cios atrav�s do Or�amento Online"
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
        <div class="productText fl" itemscope itemtype = "http://schema.org/NewsArticle">
            <h1 id="uxTituloH1" runat="server" itemprop="headline">
            </h1>
            <p class="productDescription" >
                <uc2:MensagemSuperiorControle ID="MensagemSuperiorControle1" runat="server" />
                <p class="productDescription" style="padding-left: 80px; text-align=right;"  itemprop="description">
                    <em>O Or�amento Online mostrou-se uma ferramenta muito pr�tica, direcionando um pedido
                        de or�amento para os estabelecimentos e poupando tempo de pesquisa de minha parte.</em><br />
                    Luciane Tomiyasu - Or�amento de Buffet Japon�s - SP</p>
                <p id="uxTrocarFormulario" visible="false" runat="server">
                    <a href="/orcamento-online.aspx#listaOrcamentos" title="Clique para mudar o tipo de or�amento que deseja solicitar">
                        Quero outro tipo de or�amento</a>. Consulte nossa <a href="http://rcmsolucoes.com/politica-de-privacidade/"
                            target="_blank">pol�tica de privacidade</a>.</p>
            </p>
            <div class="tipos-orcamentos" id="uxOrcamentosMaisPopulares" visible="false" runat="server">
                <p class="productDescription">
                    Veja os tipos de or�amentos e cota��es de pre�os mais populares:</p>
                <ul class="checkList">
                    <li><a href='/preco-casamento-1.aspx' title='Solicite or�amento online gr�tis para casamentos. Receba cota��o de pre�os de v�rios fornecedores de casamentos. Pr�tico, simples, eficaz e gr�tis!'>
                        Casamento</a></li>
                    <li><a href="/preco-reforma-banheiro-10.aspx" title="Solicite or�amento online gr�tis de reforma de banheiro. Receba cota��o de pre�os de v�rios fornecedores de reformas. Pr�tico, simples, eficaz e gr�tis!">
                        Reforma Banheiro</a></li>
                    <li><a href='/preco-debutante-4.aspx' title='Solicite or�amento online gr�tis para festas de 15 anos (debutantes). Receba cota��o de pre�os de v�rios fornecedores de festas de 15 anos (debutantes). Pr�tico, simples, eficaz e gr�tis!'>
                        15 anos (debutante)</a></li>
                    <li><a href="/preco-obras-reformas-construcao-imovel-11.aspx" title="Solicite or�amento online gr�tis de obras, reformas, constru��o de im�vel. Receba cota��o de pre�os de v�rias empresas de obras, reformas, constru��o de im�vel. Pr�tico, simples, eficaz e gr�tis!">
                        Reforma Im�vel</a></li>
                    <li><a href='/preco-confraternizacao-2.aspx' title='Solicite or�amento online gr�tis para confraterniza��es. Receba cota��o de pre�os de v�rios fornecedores de confraterniza��es. Pr�tico, simples, eficaz e gr�tis!'>
                        Confraterniza��o</a></li>
                    <li><a href="/orcamento-online-obras-reformas-construcao-pintura-27.aspx" title="Solicite or�amento online gr�tis de obras, reformas, constru��o, pintura e pintor profissional. Receba cota��o de pre�os de v�rios fornecedores de obras, reformas, constru��o, pintura e pintor profissional. Pr�tico, simples, eficaz e gr�tis!">
                        Obras, Reformas e Constru��o</a></li>
                    <li><a href='/preco-aniversario-3.aspx' title='Solicite or�amento online gr�tis para anivers�rios. Receba cota��o de pre�os de v�rios fornecedores de anivers�rios. Pr�tico, simples, eficaz e gr�tis!'>
                        Anivers�rio</a></li>
                    <li><a href="/orcamento-online-reforma-fachada-predio-182.aspx" title="Solicite or�amento online gr�tis de servi�os em fachadas prediais. Receba cota��o de pre�os de v�rios fornecedores de servi�os em fachadas prediais. Pr�tico, simples, eficaz e gr�tis!">
                        Pintura e Limpeza de Fachadas Prediais</a></li>
                    <li><a href='/preco-festa-infantil-5.aspx' title='Solicite or�amento online gr�tis para festas infantis. Receba cota��o de pre�os de v�rios fornecedores de festas infantis. Pr�tico, simples, eficaz e gr�tis!'>
                        Festa Infantil</a></li>
                    <li><a href="/orcamento-online.aspx#listaOrcamentos" title="Solicite or�amento online gr�tis de diversos produtos e servi�os. Receba cota��o de pre�os de v�rios fornecedores de diversos produtos e servi�os. Pr�tico, simples, eficaz e gr�tis!">
                        Outros or�amentos</a></li>
                </ul>
            </div>
            <div style="clear: both; margin-left: 40px;">
                <asp:ValidationSummary ID="valSum" runat="server" HeaderText="<strong>N�o foi poss�vel enviar seu pedido de or�amento. Por favor, corrija os campos e tente novamente.</strong>"
                    DisplayMode="BulletList" />
            </div>
            <div class="productLargeBox">
                <div class="productTrialForm">
                    <div class="frm-solicitar-orcamento">
                        <uc12:OrcamentoFormularioCasaDecoracao ID="OrcamentoFormularioCasaDecoracao1" runat="server"
                            Visible="false" />
                        <uc4:OrcamentoFormularioEspelhoVidro ID="OrcamentoFormularioEspelhoVidro1" Visible="false"
                            runat="server" />
                        <uc6:OrcamentoFormularioGenerico ID="OrcamentoFormularioGenerico" Visible="false"
                            runat="server" />
                        <uc7:OrcamentoFormularioConstrucao ID="OrcamentoFormularioConstrucao" Visible="false"
                            runat="server" />
                        <uc9:OrcamentoFormularioCFTV ID="OrcamentoFormularioCFTV1" runat="server" Visible="false" />
                        <uc5:OrcamentoFormularioEvento ID="OrcamentoFormularioEvento" runat="server" Visible="false" />
                        <uc11:OrcamentoFormularioMudanca ID="OrcamentoFormularioMudanca1" runat="server"
                            Visible="false" />
                        <uc10:OrcamentoFormularioFachadaPredial ID="OrcamentoFormularioFachadaPredial1" runat="server"
                            Visible="false" />
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
        �ltimos Pedidos de Or�amento
    </h2>
    <uc13:PedidosOrcamentoControle ID="PedidosOrcamentoControle1" runat="server" />
    <!-- end productHeadingType3 -->
    <uc8:LinksInternosControle ID="LinksInternosControle1" runat="server" />
    <uc1:CategoriaListaControle ID="CategoriaListaControle1" runat="server" />
    <div class="horizontalSep">
        <!-- -->
    </div>
    <div class="tipos-orcamentos">
        <h3 id="H1" runat="server">
            Voc� tamb�m solicitar or�amentos de</h3>
        <ul class="checkList">
            <li><a href="orcamento-online.aspx?categoria=40&servico=1" title='Solicite or�amento online gr�tis para pintor e pintores. Receba cota��o de pre�os de v�rios pintores. Pr�tico, simples, eficaz e gr�tis!'>
                Pintores</a> </li>
            <li><a href="orcamento-online.aspx?categoria=186&servico=2" title='Solicite or�amento online gr�tis para construtoras e empresas de reforma. Receba cota��o de pre�os de v�rioas construtoras e empresas de reforma. Pr�tico, simples, eficaz e gr�tis!'>
                Constru��o</a></li>
            <li><a href="orcamento-online.aspx?categoria=155&servico=3" title='Solicite or�amento online gr�tis para arquitetos. Receba cota��o de pre�os de v�rios arquitetos. Pr�tico, simples, eficaz e gr�tis!'>
                Arquitetos</a></li>
            <li><a href="orcamento-online.aspx?categoria=186&servico=4" title='Solicite or�amento online gr�tis para construtoras e empresas de reforma. Receba cota��o de pre�os de v�rias construtoras e empresas de reforma. Pr�tico, simples, eficaz e gr�tis!'>
                Reformas</a></li>
            <li><a href="orcamento-online.aspx?categoria=155&servico=5" title='Solicite or�amento online gr�tis para Designer de Interior. Receba cota��o de pre�os Designer de Interior. Pr�tico, simples, eficaz e gr�tis!'>
                Designer de Interior</a></li>
        </ul>
    </div>
    <div class="horizontalSep">
        <!-- -->
    </div>
    <h2>
        Como funciona o Or�amento Online?</h2>
    <p style="margin-bottom: 20px;">
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
        Nada. <strong>O Or�amento Online � gr�tis.</strong>. <a href="/orcamento-online.aspx#listaOrcamentos"
            title="Solicite or�amento online gr�tis de diversos produtos e servi�os.">Solicite
            j� seu or�amento!</a></p>
    <h2>
        Sou um fornecedor. Como fa�o para receber os Pedidos de Or�amento?</h2>
    <p style="margin-bottom: 20px;">
        Voc� deve fazer seu <a href="cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cota��es e envie or�amentos">
            cadastro como fornecedor</a> no Or�amento Online para receber os pedidos de
        or�amento. Trabalhamos apenas com profissionais e empresas diferenciados, competentes,
        capacitados, que prestam servi�os ou fornecem produtos de reconhecida qualidade.</p>
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
