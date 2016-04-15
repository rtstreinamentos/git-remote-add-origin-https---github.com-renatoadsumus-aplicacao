<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PesquisaSatisfacaoCompradorSucessoSucesso.aspx.cs"
	Inherits="OrcamentoNet.View.PesquisaSatisfacaoCompradorSucesso" %>

<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
	TagPrefix="uc23" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Pesquisa de Satisfação - Comprador</title>
	<meta name="description" content="Comprador, responda à pesquisa de satisfação do Orçamento Online, indicando o que foi bom e o que pode ser melhorado." />
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
	<form id="form1" runat="server">
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
				<h1>
					Pesquisa Gravada com Sucesso!</h1>
				<p class="productDescription">
					Sua opinião será utilizada para melhorarmos nossos serviços e/ou dar um retorno
					aos fornecedores.</p>
				<p class="productDescription">
					<strong>Muito obrigado pela sua participação!</strong></p>
				<h2 style="margin-top: 30px;">
					Ajude a divulgar o Orçamento Online</h2>
				<div>
					<div>
						<p>
							<!-- AddThis Button BEGIN -->
							<div class="addthis_toolbox addthis_default_style addthis_32x32_style" addthis:url="http://orcamentosgratis.net.br/"
								addthis:title="Orçamento Online" addthis:description="A sua ferramenta para multicotação simultânea de pesquisa de preços">
								<a class="addthis_button_orkut"></a><a class="addthis_button_facebook"></a><a class="addthis_button_twitter">
								</a><a class="addthis_button_email"></a><a class="addthis_button_linkedin"></a><a
									class="addthis_button_google"></a><a class="addthis_button_favorites"></a><a class="addthis_button_compact">
									</a><a class="addthis_counter addthis_bubble_style"></a>
							</div>

							<script type="text/javascript">
								var addthis_config = { "data_track_clickback": true };
							</script>

							<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4dfff7f80ea230ee"></script>

							<div style="margin-top: 8px;">
								<!-- Place this tag after the last plusone tag -->
								<g:plusone></g:plusone>

								<script type="text/javascript">
									window.___gcfg = { lang: 'pt-BR' };

									(function() {
										var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
										po.src = 'https://apis.google.com/js/plusone.js';
										var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
									})();
								</script>

							</div>
							<!-- AddThis Button END -->
							<div id="fb-root" style="margin: 10px;">
							</div>

							<script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>

							<fb:like href="http://orcamentosgratis.net.br/" send="true" width="450" show_faces="true"
								font="arial"></fb:like>
							<!-- Place this tag where you want the +1 button to render -->
						</p>
					</div>
				</div>
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
