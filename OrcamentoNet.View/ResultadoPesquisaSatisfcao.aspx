<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
    CodeBehind="ResultadoPesquisaSatisfcao.aspx.cs" Inherits="OrcamentoNet.View.ResultadoPesquisaSatisfcao" %>

<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType3">
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
        <div class="productText fl">
            <h1 id="uxTituloH1" runat="server">
            </h1>
            <!-- Product Buy Button Section Starts Here -->
            <div class="bigBuyButton">
                <a href="/orcamento-online.aspx" title="Solicite seu Orçamento Online" class="buttonLinkWithImage">
                    Quero pedir um Orçamento Online grátis<img src="/img/buttonArrow.png" alt="Arrow Button"
                        id="arrowButtonFixPNG" /></a>
            </div>
            <!-- end bigBuyButton -->
            <!-- Product Buy Button Section Starts Here -->
            <div class="bigBuyButton">
                <a href="/cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor: participe de cotações e envie orçamentos"
                    class="buttonLinkWithImage">Quero me cadastrar no Orçamento Online<img src="/img/buttonArrow.png"
                        alt="Arrow Button" id="arrowButtonFixPNG" /></a>
            </div>
            <!-- end bigBuyButton -->
            <!-- end productText -->
        </div>
        <!-- end productPrice -->
    </div>
    <!-- end productHeadingType3 -->
    <div class="horizontalSep">
        <!-- -->
    </div>
    <div>
        <h2>
            Abaixo opiniões de pessoas como você sobre o Orçamento Online:
        </h2>
        <ul class="checkList">
            <asp:Repeater ID="uxrptOpiniao" runat="server">
                <ItemTemplate>
                    <li style="margin: 0 6px 6px 0;"><strong>
                        <%#Eval("NomeComprador")%> - <%#Eval("Cidade.Uf")%>
                    
                        <br />
                        O quê foi bom?</strong>
                        <br />
                        <%#Eval("OpiniaoComprador")%>
                        <br />
                        <br />
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!-- end bigBuyButton -->
</asp:Content>
