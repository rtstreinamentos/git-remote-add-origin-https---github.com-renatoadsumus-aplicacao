﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ficha_Tecnica.aspx.cs"
    Inherits="OrcamentoNet.View.Ficha_Tecnica" %>

<%@ OutputCache Duration="86400" VaryByParam="n" %>
<%@ Register Src="controles/CaptchaControle.ascx" TagName="CaptchaControle" TagPrefix="uc1" %>
<%@ Register Src="/controles/RodapeControle.ascx" TagName="RodapeControle" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <!-- This is where we call the stylesheet for the Google Font -->
    <!-- 
	You can replace this with whatever font you want from their library: http://code.google.com/webfonts
	After you make the change, make sure you modify the font-family in the CSS file
	-->
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Droid+Sans" />
    <link rel="stylesheet" href="/css/reset.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/css/master.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/css/skin.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/css/tipsy.css" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/prettyPhoto.css" charset="utf-8"
        media="screen" />

    <script src="/js/jquery-1.4.4.min.js" type="text/javascript"></script>

    <script src="/js/jquery.tipsy.js" type="text/javascript"></script>

    <script src="/js/functions.js" type="text/javascript"></script>

    <script src="/js/css_browser_selector.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.prettyPhoto.js" charset="utf-8"></script>

    <!--[if IE 6]>
	<link rel="stylesheet" href="/css/ie6.css" type="text/css" media="screen" /> 
	<script src="/js/ie6pngFix.js"></script>
	<script>
		DD_belatedPNG.fix('#logoFixPNG, .topSeparator, .productPrice, ul.iconBulletList img, #arrowButtonFixPNG, .footerSeparator, a.buttonLink');
	</script>
	<![endif]-->

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-15232280-5']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>

    <meta name="keywords" content="casa,dicas,jardim,lâmpadas,limpeza,luminárias,piscina,piso,vidro,álcool,amônia,azulejos,brilho,truques,vinagre,alergia,bomba de água,mangueiras,microclima,repelir mosquitos,terraço,vantagens,varanda,acabamento,aquarela,brilhante,decoração,fosco,janelas,quadros,vidros,cores,móveis,sala,sofá multifunção,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,construção,construção ecológica,estruturas,gradua,lar sustentável,materiais de construção,meio ambiente,painéis,crianças,flores,poupar tempo,regadeira automática,regar,economia,eletrodomésticos,lava louça,máquina de lavar louça,almofadas,cuidado,manutenção,móveis d evime,móveis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,iluminação,potenciômetro,quarto dasc rianças,regulador,tomada,aço,barco,caracol,corrimãos,escadas,imperial,madeira,material,metal,modelos,segurança,apartamento de aluguel,idéias,luz natural,sofá,bustos,esculturas,estilo clássico,estilo eclético,figura de mármore,cômodidade,cortinas motorizadas,economia energética,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos automáticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retrô,poltrona,puf,sacada,tapete,baú,brinquedos,faixas decorativas,paredes,quarto de bebês,quarto de crianças, Comercial, Escritório, Grafiato,  Residência, Serviço, Textura, Condomínio, Profissional de Porta, Residencial, Preço, reformas, obras e reformas, construtores, orçamentos de reformas, orçamentos, obras, arquitetura, decoração de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
    <meta property="og:locale" content="pt_BR">
    <meta property="og:type" content="website">
    <meta property="og:site_name" content="Orçamento Online Grátis">
    <meta property="article:tag" content="obras, reformas, festas, eventos, construção, preço, orçamento, sistema segurança, CFTV, manutenção predial, limpeza fachada" />
    <meta property="article:section" content="Orçamento Grátis" />
    <meta property="article:author" content="Orçamento Grátis">
    <meta property="og:url" content="http://orcamentosgratis.net.br/" />
    <meta property="og:image" content="http://orcamentosgratis.net.br/img/fechando-negocios-orcamento-online.jpg" />
    <meta property="og:image:type" content="image/jpg">
    <meta property="article:section" content="Orçamento Grátis" />
    <meta property="article:author" content="Orçamento Grátis">
    <meta property="og:url" content="http://orcamentosgratis.net.br/" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="mainWrapper">
        <!-- Top Section Starts Here -->
        <div id="topWrapper">
            <div class="logo fl">
                <a href="/" title="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores. Prático, simples, eficaz e grátis!">
                    <img src="/img/logo-orcamento-online.png" alt="Logomarca do Orçamento Online - Cotação de Preços"
                        id="logoFixPNG" /></a>
            </div>
            <!-- end logo -->
        </div>
        <!-- end topWrapper -->
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
                <h1 id="uxH1NomeFornecedor" runat="server" itemprop="headline">
                </h1>
                <br />
                <br />
                <label style="font-size: medium">
                    <strong>Telefone: </strong>
                </label>
                <asp:Label ID="uxlblTelefone" Font-Size="Medium" runat="server"></asp:Label>
                <br />
                <br />
                <label style="font-size: medium">
                    <strong>Site: </strong>
                </label>
                <asp:HyperLink ID="uxlblSite" runat="server" Font-Size="Medium"></asp:HyperLink>
                <br />
                <br />
                <label style="font-size: medium">
                    <strong>Email: </strong>
                </label>
                <asp:Label ID="uxlblEmail" Font-Size="Medium" runat="server"></asp:Label>
                <br />
                <br />
                <label style="font-size: medium">
                    <strong>Cidades em que atua: </strong>
                </label>
                <asp:Label ID="uxlblCidadesAtuacao" Font-Size="Medium" runat="server"></asp:Label>
                <br />
                <br />
                <label style="font-size: medium">
                    <strong>Ramos de atividade: </strong>
                </label>
                <asp:Label ID="uxlblRamosAtividade" Font-Size="Medium" runat="server"></asp:Label>
                <div id="fb-root">
                </div>
                <br />
                <br />

                <script>                    (function(d, s, id) {
                        var js, fjs = d.getElementsByTagName(s)[0];
                        if (d.getElementById(id)) return;
                        js = d.createElement(s); js.id = id;
                        js.src = "//connect.facebook.net/pt_BR/all.js#xfbml=1";
                        fjs.parentNode.insertBefore(js, fjs);
                    } (document, 'script', 'facebook-jssdk'));</script>

                <asp:Literal ID="uxlblFacebook" runat="server"></asp:Literal>
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
        <div class="horizontalSep">
            <!-- -->
        </div>
        <h2 itemprop="description">
            Descrição das atividades:</h2>
        <p style="margin-bottom: 5px;">
            <asp:Label ID="uxlblDescricao" runat="server" Font-Size="Large"></asp:Label>
        </p>
        <div id="divFotos" runat="server">
            <!--<div class="horizontalSep">
                 
            </div>-->
            <div>
                <h2>
                    Fotos</h2>
                <asp:DataList ID="uxdltFotos" RepeatColumns="5" runat="server">
                    <ItemTemplate>
                        <a href='http://orcamentosgratis.net.br/FotosFornecedor/<%# Eval("Caminho")%>' rel="prettyPhoto[pp_gal]"
                            title='<%# Eval("Titulo") %>'>
                            <img src='http://orcamentosgratis.net.br/FotosFornecedor/<%# Eval("Caminho")%>' width="120"
                                height="120" alt='<%# Eval("Nome") %>' />
                        </a>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <!-- Product Testimonial Section Starts Here -->
        <div class="testimonialContainer" id="divDepoimentos" runat="server">
            <div id="boxHeading">
                <h3 id="uxH3Opiniao" runat="server">
                </h3>
            </div>
            <!-- end boxHeading -->
            <ul class="testimonials">
                <asp:Repeater ID="uxrptFornecedores" runat="server">
                    <ItemTemplate>
                        <li>
                            <%#Eval("Descricao")%><br />
                            <span>
                                <%#Eval("Nome")%></span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="testimonialContainer">
            <div id="Div1">
                <h1 id="uxH1OpineFornecedor" runat="server">
                </h1>
            </div>
            Lembre-se: seja educado e não utilize palavras que insultem, por pior que tenha
            sido sua experiência com a empresa.
            <br />
            <br />
            Nome:
            <asp:TextBox Width="200" ID="uxtxtNome" runat="server" MaxLength="100" ToolTip="Informe seu nome."></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxtxtNome"
                ErrorMessage="" Text="O nome deve ser informado." />
            <br />
            <br />
            Email:
            <asp:TextBox Width="200" ID="uxtxtEmail" runat="server" MaxLength="100" ToolTip="Informe seu e-mail."></asp:TextBox>
            <asp:RegularExpressionValidator ID="regexpEmail" ControlToValidate="uxtxtEmail" ErrorMessage=""
                Text="O e-mail deve ser informado no formato correto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                runat="server" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxtxtEmail"
                ErrorMessage="" Text="O e-mail deve ser informado." />
            <br />
            Título Opinião:<asp:TextBox ID="uxtxtTitulo" Width="200" MaxLength="200" runat="server"></asp:TextBox>
            <br />
            <br />
            Com a empresa você ficou:
            <asp:DropDownList ID="uxddlSatisfacao" runat="server">
                <asp:ListItem Value="0">Selecione</asp:ListItem>
                <asp:ListItem>Muito Satisfeito</asp:ListItem>
                <asp:ListItem>Satisfeito</asp:ListItem>
                <asp:ListItem>Parcialmente Satisfeito</asp:ListItem>
                <asp:ListItem>Insatisfeito</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="uxddlSatisfacao"
                ErrorMessage="" Text="Sua satisfação deve ser informada." InitialValue="0" />
            <br />
            <br />
            Descrição:
            <asp:TextBox ID="uxtxtDescricao" ToolTip="Informe a sua opinião ou experiência com a empresa"
                CssClass="ie6SubmitFix" runat="server" TextMode="MultiLine" Width="95%" Height="100px"
                MaxLength="1000"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxtxtDescricao"
                Text="A descrição deve ser informada." ErrorMessage="" />
            <br />
            <div class="frm-solicitar-orcamento">
                <asp:Button CssClass="ie6SubmitFix" ID="uxbtnSalvar" runat="server" Text="Publicar"
                    OnClick="uxbtnSalvar_Click" /></li>
                <br />
                <uc1:CaptchaControle ID="CaptchaControle1" runat="server" />
                <p>
                    <strong>
                        <asp:Label ID="uxlblMensagemInferior" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label></strong></p>
            </div>
        </div>
        <div>
            <h2>
                Outras empresas relacionadas</h2>
            <asp:Repeater ID="uxrptEmpresasRelacionadas" runat="server">
                <ItemTemplate>
                    <li style="margin-bottom: 10px;">
                        <h4>
                            <%#Server.HtmlEncode((string)Eval("Nome"))%></h4>
                        <p>
                            <%#Server.HtmlEncode(Eval("Descricao").ToString())%></p>
                        <p>
                            <strong>Áreas de atuação:</strong></p>
                        <ul class="categoria">
                            <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                                <ItemTemplate>
                                    <li>
                                        <%#Server.HtmlEncode(Eval("Nome").ToString())%></li></ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <p style="text-align: right;">
                            <a href="fornecedor-<%#Server.HtmlEncode(Eval("UrlFichaTecnica").ToString())%>">ver
                                ficha completa</a></p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="tipos-orcamentos">
            <h3>
                Por Estado</h3>
            <ul class="checkList">
                <asp:Repeater ID="uxrptLinksEstadoCidade" runat="server">
                    <ItemTemplate>
                        <li><a href='/<%#Eval("UrlAmigavel")%>' title='<%#Eval("ToolTip")%>'>
                            <%#Eval("Nome")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!-- end testimonials -->
        <!-- Product Buy Button Section Starts Here -->
        <div class="bigBuyButton">
            <a href="/cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos"
                class="buttonLinkWithImage">Sou fornecedor e quero me cadastrar no Orçamento Online<img
                    src="/img/buttonArrow.png" alt="Arrow Button" id="arrowButtonFixPNG" /></a>
        </div>
        <!-- Footer Section Starts Here -->
        <uc1:rodapecontrole id="RodapeControle1" runat="server" />
        <!-- end footerMenu -->
    </div>
    <!-- end mainWrapper -->
    <center>

        <script type="text/javascript"><!--
            google_ad_client = "ca-pub-9502900066313233";
            /* Banner Rodapé Largo */
            google_ad_slot = "5398927505";
            google_ad_width = 970;
            google_ad_height = 90;
//-->
        </script>

        <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>

    </center>
    <div id="footerInformation">
        <p>
            © Copyright - Este site é parte do sistema <a href="http://rcmsolucoes.com/" target="_blank"
                title="Orçamento Online">Orçamento Online</a>. Conheça nossa <a href="http://rcmsolucoes.com/politica-de-privacidade/"
                    target="_blank">política de privacidade</a>.</p>
        <p>
            Dúvidas, críticas ou sugestões? <a href="http://rcmsolucoes.com/fale-conosco/" target="_blank"
                rel="nofollow">Fale conosco</a>, teremos o maior prazer em atendê-lo(a)!</p>
        <p>
            <small><a href="http://www.freedigitalphotos.net/images/view_photog.php?photogid=2664"
                target="_blank" rel="nofollow">Foto: Stuart Miles / FreeDigitalPhotos.net</a></small></p>
    </div>
    <!-- end footerInformation -->
    </form>

    <script type="text/javascript" charset="utf-8">
        $(document).ready(function() {
            $("a[rel^='prettyPhoto']").prettyPhoto({ theme: 'facebook', slideshow: 5000, autoplay_slideshow: true });
        });
    </script>

    <table class="style1">
        <tr>
            <td bgcolor="#6699FF">
                &nbsp;
            </td>
        </tr>
    </table>
</body>
</html>
