<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAlterarDados.aspx.cs" Inherits="OrcamentoNet.View.AdminAlterarDados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<%@ Register Src="/controles/FornecedorPorCategoriaControle.ascx" TagName="FornecedorPorCategoriaControle"
    TagPrefix="uc1" %>
<%@ Register Src="controles/CidadeListBoxControle.ascx" TagName="CidadeListBoxControle"
    TagPrefix="uc4" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
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
    <asp:ToolKitScriptManager id="ScriptManager1" runat="server"></asp:ToolKitScriptManager>
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
        <div class="bigBuyButton">
           
<div class="productLargeBox">
                        <div class="productTrialForm">
                            <div class="frm-solicitar-orcamento">
                                <fieldset>
                                    <div style="float: left; width: 49%;">
                                        <ul class="fl">
                                            <li>
                                                <label for="uxtxtNome">
                                                    Nome/Empresa:</label>
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
                                                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="uxtxtDDD"
                                                    FilterType="Custom,Numbers">
                                                </cc1:filteredtextboxextender>
                                                -
                                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtTelefone" runat="server" Width="80px"
                                                    MaxLength="12"></asp:TextBox>
                                                <cc1:filteredtextboxextender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="uxtxtTelefone"
                                                    FilterType="Custom,Numbers" ValidChars=" -()_./r">
                                                </cc1:filteredtextboxextender>
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxtxtDDD"
                                                    ErrorMessage="" Text="O DDD deve ser informado.">
                                                </asp:RequiredFieldValidator><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxtxtTelefone"
                                                    ErrorMessage="" Text="O telefone deve ser informado.">
                                                </asp:RequiredFieldValidator>
                                            </li>
                                            <li>
                                                <label>
                                                    Web site:</label>
                                                <asp:TextBox CssClass="ie6SubmitFix" ID="uxtxtSite" runat="server" MaxLength="100"
                                                    ToolTip="http://..."></asp:TextBox><br />
                                                <asp:RegularExpressionValidator ID="regexpURL" ControlToValidate="uxtxtSite" ErrorMessage=""
                                                    Text="O web site deve ser informado no formato correto." ValidationExpression="^(http(s?):\/\/)(www.)?(\w|-)+(\.(\w|-)+)*((\.[a-zA-Z]{2,3})|\.(aero|coop|info|museum|name))+(\/)?$"
                                                    runat="server" /><br />
                                            </li>
                                            <li>
                                                <label>
                                                    Descrição da empresa:</label>
                                                <asp:TextBox ID="uxtxtDescricao" ToolTip="Exemplo: Empresa especializada em construção com 5 anos de experiência no mercado... "
                                                    CssClass="ie6SubmitFix" runat="server" TextMode="MultiLine" Width="95%" Height="100px"></asp:TextBox><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxtxtDescricao"
                                                    Text="A descrição deve ser informada." ErrorMessage="" />
                                            </li>
                                            
                                            <li>
                                                <asp:Button ID="uxbtnCalcularValor" runat="server" Text="Calcular Valor Mensalidade"
                                                    OnClick="uxbtnCalcularValor_Click" />
                                            </li>
                                            <li>
                                                <asp:Label runat="server" ID="uxlblValorMensalidade" ForeColor="Red" Font-Size="Medium"></asp:Label>
                                            </li>
                                        </ul>
                                    </div>
                                    <div style="float: right; width: 49%;">
                                        <ul>
                                            <li>
                                                <div style="margin-top: 4px; width: 100%; height: 558px; overflow: auto;">
                                                    <uc4:CidadeListBoxControle ID="CidadeListBoxControle1" runat="server" />
                                                </div>
                                            </li>
                                            <li>
                                                <label>
                                                    Bairro / Área de Atuação:</label>
                                                <asp:TextBox ID="uxtxtAreaAtuacao" ToolTip="Zona Sul, Copacabana, Zona Norte etc "
                                                    runat="server" MaxLength="1000"></asp:TextBox><br />
                                            </li>
                                            <li>
                                                <label>
                                                    Seus ramos de atividade:</label>
                                                <div style="margin-top: 4px; width: 100%; height: 558px; overflow: auto;">
                                                    <br />
                                                    <asp:Repeater ID="uxrptCategorias" runat="server">
                                                        <ItemTemplate>
                                                            <strong>
                                                                <%#Eval("Nome")%></strong>
                                                            <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                                                                <ItemTemplate>
                                                                    <br />
                                                                    <asp:CheckBox runat="server" ID="uxchkSubCategoria" />
                                                                    <%--<%#Eval("Nome")%>--%>
                                                                    <asp:Label ID="uxlblNomeCategoria" runat="server" Text='<%#Eval("Nome") %>'></asp:Label>
                                                                    <asp:Label ID="uxlblIdCategoria" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <br />
                                                            <br />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="secaoEnviar">
                                        <asp:Button CssClass="ie6SubmitFix" ID="uxbtnSalvar" runat="server" Text="Enviar"
                                            OnClick="uxbtnSalvar_Click" />
                                    </div>
                                    <p>
                                        <strong>
                                            <asp:Label ID="uxlblMensagemInferior" runat="server"></asp:Label></strong></p>
                                </fieldset>
                            </div>
                        </div>
                    </div>           
        </div>
        <!-- end bigBuyButton -->
  
      

        <!-- Footer Section Starts Here -->
       
          
        
        <!-- end footerMenu -->

    </div>
        <!-- end mainWrapper -->
        
    <div id="footerInformation">
        <p>
            &copy; Copyright - Este site é parte do sistema <a href="http://rcmsolucoes.com/"
                target="_blank" title="Orçamento Online">Orçamento Online</a>. Conheça nossa 
			<a href="http://rcmsolucoes.com/politica-de-privacidade/" target="_blank">política de privacidade</a>.</p>
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
