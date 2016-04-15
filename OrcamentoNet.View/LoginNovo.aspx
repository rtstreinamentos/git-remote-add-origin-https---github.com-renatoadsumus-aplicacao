<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginNovo.aspx.cs" Inherits="OrcamentoNet.View.LoginNovo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="controles/CaptchaControle.ascx" TagName="CaptchaControle" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
        <!-- Product Buy Button Section Starts Here -->
        <asp:MultiView ID="multiview01" runat="server" ActiveViewIndex="0">
            <asp:View ID="viewLogin" runat="server">
                <div class="bigBuyButton">
                    <div class="productLargeBox">
                        <div class="productTrialForm">
                            <div class="frm-solicitar-orcamento">
                                <fieldset>
                                    <ul>
                                        <li>
                                            <label>
                                                Email:</label><asp:TextBox ID="uxtxtEmail" runat="server" Width="295px" MaxLength="80"></asp:TextBox>
                                                <a href="LoginNovo.aspx?recuperarSenha=sim">Esqueci Minha Senha</a>
                                        </li>
                                        <li>
                                            <label>
                                                Senha</label><asp:TextBox ID="uxtxtSenha" runat="server" Width="295px" MaxLength="12"
                                                    TextMode="Password"></asp:TextBox>
                                        </li>
                                      
                                        <li>
                                            <asp:Button CssClass="ie6SubmitFix" ID="uxbtnEnviar" runat="server" Text="Enviar"
                                                OnClick="uxbtnEnviar_Click" />
                                        </li>
                                        
                                        
                                        <li>
                                            <p>
                                                <strong>
                                                    <asp:Label ID="uxlblMensagemInferior" runat="server"></asp:Label></strong></p>
                                        </li>
                                    </ul>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="viewMenu" runat="server">
            <br />
           <div class="bigBuyButton">
                    <div class="productLargeBox">
                        <div class="productTrialForm">
                            <div class="frm-solicitar-orcamento">
                                <fieldset>
                                <h3>
                                    Solicitação de Recuperar Senha
                                </h3>
                                    <ul>
                                        <li>
                                            <label>
                                                Email:</label><asp:TextBox ID="uxtxtRecuperarEmail" runat="server" Width="295px" MaxLength="80"></asp:TextBox>
                                                
                                        </li>
                                       <li>
                                           Esta solicitação será enviada para seu e-mail. Caso não receba o e-mail, entre 
                                           em contato conosco.
                                       </li>
                                      
                                        <li>
                                            <asp:Button CssClass="ie6SubmitFix" ID="uxbtnRecuperarSenha" runat="server" 
                                                Text="Recuperar Senha" onclick="uxbtnRecuperarSenha_Click"
                                                 />
                                        </li>
                                        
                                        
                                        <li>
                                            <p>
                                                <strong>
                                                    <asp:Label ID="uxlblMensagemInferiorRecuperarSenha" runat="server" Font-Size="Large"></asp:Label></strong></p>
                                        </li>
                                    </ul>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
        <br />
        <br />
            </asp:View>
        </asp:MultiView>
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
            © Copyright - Este site é parte do sistema tema <a href="http://rcmsolucoes.com/"
                target="_blank" title="Orçamento Online">Orçamento Online</a>. Conheça nossa
            <a href="http://rcmsolucoes.com/politica-de-privacidade/" target="_blank">
            política de privacidade</a>.</p>
        <p>
            Dúvidas, críticas ou sugestões? <a href="http://rcmsolucoes.com/fale-conosco/"
                target="_blank" rel="nofollow">Fale conosco</a>, teremos o maior prazer em 
            atendê-lo(a)!</p>
        <p>
            <small><a href="http://www.freedigitalphotos.net/images/view_photog.php?photogid=2664"
                target="_blank" rel="nofollow">Foto: Stuart Miles / FreeDigitalPhotos.net</a></small></p>
    </div>
    <!-- end footerInformation -->
    </form>
</body>
</html> 