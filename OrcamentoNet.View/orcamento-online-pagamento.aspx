<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orcamento-online-pagamento.aspx.cs"
    Inherits="OrcamentoNet.View.orcamento_online_pagamento" %>

<%@ Register Assembly="UOL.PagSeguro" Namespace="UOL.PagSeguro" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pagamento PagSeguro</title>
    <meta name="description" content="Você poderá pagar através de boleto bancário,cartão de crédito e débito." />
    <meta name="robots" content="noindex" />
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
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

    <script src="/js/jquery-1.4.4.min.js" type="text/javascript"></script>

    <script src="/js/jquery.tipsy.js" type="text/javascript"></script>

    <script src="/js/functions.js" type="text/javascript"></script>

    <script src="/js/css_browser_selector.js" type="text/javascript"></script>

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

</head>
<body>
    <form id="form" runat="server">
    <div id="mainWrapper">
        <!-- Top Section Starts Here -->
        <div id="topWrapper">
            <div class="logo fl">
                <a href="/" title="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores. Prático, simples, eficaz e grátis!">
                    <img src="/img/logo-orcamento-online.png" alt="Logomarca do Orçamento Online - Cotação de Preços"
                        id="logoFixPNG" /></a>
            </div>
            <!-- end logo -->
            <p class="productDescription" style="color: Red; font-size: Medium; font-weight: bold;">
                &nbsp;</p>
            <div class="frm-solicitar-orcamento" runat="server" visible="false" id="divFormPesquisaSatisfacao">
                &nbsp;</div>
        </div>
        <!-- end topWrapper -->
        <div class="productHeadingType1">
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
               
                <cc1:VendaPagSeguro ID="VendaPagSeguro1" runat="server" EmailCobranca="orcamentos.net@gmail.com">
                </cc1:VendaPagSeguro>
                <br />
            </div>
            <!-- end productPrice -->
        </div>
        <!-- end productHeadingType1 -->
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
<script type="text/javascript"
src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
</center>

	<div id="footerInformation">
        <p>
            © Copyright - Este site é parte do sistema <a href="http://rcmsolucoes.com/" target="_blank"
                title="Orçamento Online">Orçamento Online</a>. Conheça nossa <a href="http://rcmsolucoes.com/politica-de-privacidade/"
                    target="_blank">política de privacidade</a>.</p>
        <p>
            Dúvidas, críticas ou sugestões? <a href="http://rcmsolucoes.com/fale-conosco/"
                target="_blank" rel="nofollow">Fale conosco</a>, teremos o maior prazer em atendê-lo(a)!</p>
        <p>
            <small><a href="http://www.freedigitalphotos.net/images/view_photog.php?photogid=2664"
                target="_blank" rel="nofollow">Foto: Stuart Miles / FreeDigitalPhotos.net</a></small></p>
    </div>
    <!-- end footerInformation -->
    </form>
</body>
</html>
