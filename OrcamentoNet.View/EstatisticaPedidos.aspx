<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstatisticaPedidos.aspx.cs"
    Inherits="OrcamentoNet.View.EstatisticaPedidos" MasterPageFile="~/OrcamentoNet2.Master" %>

<%@ Register Src="/controles/MensagemSuperiorControle.ascx" TagName="MensagemSuperiorControle"
    TagPrefix="uc2" %>
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
            <uc2:mensagemsuperiorcontrole ID="MensagemSuperiorControle1" runat="server" />
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
        <h2 id="uxTituloH2" runat="server">
            </h2>
        <asp:MultiView ID="multiview" runat="server" ActiveViewIndex="1">
            <asp:View ID="viewPasso0" runat="server">
                <div class="tipos-orcamentos">
                    <h3>
                        Selecione um Estado</h3>
                    <ul class="checkList">
                        <asp:Repeater ID="uxrptLinksEstado" runat="server">
                            <ItemTemplate>
                                <li><a href='/EstatisticaPedidos.aspx?uf=<%# Container.DataItem %>'>
                                    <%# Container.DataItem %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <asp:Label Visible="false" ID="hdfUf" runat="server" />
                </div>
            </asp:View>
            <asp:View ID="viewPasso1" runat="server">
                <asp:DataList RepeatLayout="Table" RepeatColumns="3" RepeatDirection="Horizontal"
                    runat="server" ID="uxrptCategoriasColuna1" CellPadding="8" CellSpacing="4" ItemStyle-VerticalAlign="Top"
                    Width="100%" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="33%">
                    <ItemTemplate>
                        <h3 style="margin: 30px 0 8px 0;">
                            <%#Eval("Nome")%></h3>
                        <ul class="checkList">
                            <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                                <ItemTemplate>
                                    <li style="margin: 0 6px 6px 0;"><a href='/EstatisticaPedidos.aspx?categoria=<%#Eval("Id")%>'
                                        title='Solicite orçamento online <%#Eval("Nome")%>. Receba cotação de preços de vários fornecedores de <%#Eval("Nome")%>. Prático, simples, eficaz e grátis!'>
                                        <%#Eval("Nome")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </ItemTemplate>
                </asp:DataList>
            </asp:View>
            <asp:View ID="viewPasso2" runat="server">
                <ul class="checkList">
                    <asp:Repeater ID="uxrptEstatistica" runat="server">
                        <ItemTemplate>
                            <li style="margin: 0 6px 6px 0;">
                            <%#Eval("Cidade.Nome")%> -  <strong><%#Eval("QuantidadePedidos")%></strong>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
    <!-- Product Buy Button Section Starts Here -->
    <div class="bigBuyButton">
        <a href="/orcamento-online.aspx" title="Solicite seu Orçamento Online" class="buttonLinkWithImage">
            Quero pedir um Orçamento Online grátis<img src="/img/buttonArrow.png" alt="Arrow Button"
                id="Img1" /></a>
    </div>
    <!-- end bigBuyButton -->
</asp:Content>
