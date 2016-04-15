<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet.Master"
    CodeBehind="orcamento-online-preco.aspx.cs" Inherits="OrcamentoNet.View.orcamento_online_preco" %>

<%@ Register Src="controles/PedidosOrcamentoControle.ascx" TagName="PedidosOrcamentoControle"
    TagPrefix="uc1" %>
<asp:Content ID="cpHead" ContentPlaceHolderID="Head" runat="server">
    <meta name="description" content="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores. Prático, simples, eficaz e grátis!" />
    <meta name="keywords" content="casa,dicas,jardim,lâmpadas,limpeza,luminárias,piscina,piso,vidro,álcool,amônia,azulejos,brilho,truques,vinagre,alergia,bomba de água,mangueiras,microclima,repelir mosquitos,terraço,vantagens,varanda,acabamento,aquarela,brilhante,decoração,fosco,janelas,quadros,vidros,cores,móveis,sala,sofá multifunção,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,construção,construção ecológica,estruturas,gradua,lar sustentável,materiais de construção,meio ambiente,painéis,crianças,flores,poupar tempo,regadeira automática,regar,economia,eletrodomésticos,lava louça,máquina de lavar louça,almofadas,cuidado,manutenção,móveis d evime,móveis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,iluminação,potenciômetro,quarto dasc rianças,regulador,tomada,aço,barco,caracol,corrimãos,escadas,imperial,madeira,material,metal,modelos,segurança,apartamento de aluguel,idéias,luz natural,sofá,bustos,esculturas,estilo clássico,estilo eclético,figura de mármore,cômodidade,cortinas motorizadas,economia energética,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos automáticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retrô,poltrona,puf,sacada,tapete,baú,brinquedos,faixas decorativas,paredes,quarto de bebês,quarto de crianças, Comercial, Escritório, Grafiato,  Residência, Serviço, Textura, Condomínio, Profissional de Porta, Residencial, Preço, reformas, obras e reformas, construtores, orçamentos de reformas, orçamentos, obras, arquitetura, decoração de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
</asp:Content>
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
            <h1 id="H1" runat="server">
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
                <a href="/cadastro-fornecedores-orcamento-online.aspx" title="Cadastro de Fornecedor e Empresas: receba cotações e orçamentos por email!"
                    class="buttonLinkWithImage">Sou fornecedor quero me cadastrar no Orçamento Online<img src="/img/buttonArrow.png"
                        alt="Arrow Button" id="arrowButtonFixPNG" /></a>
            </div>
            <!-- end bigBuyButton -->
            <!-- end productText -->
        </div>
        
        </div>
    
    <div style="clear: both;">
            <p>
                &nbsp;</p>
        </div>
        <h2 id="uxTituloH2" runat="server">
            Categorias
        </h2>
        <div class="tipos-orcamentos">
            <ul class="checkList">
                <asp:Repeater ID="uxrptLinksCategoria" runat="server">
                    <ItemTemplate>
                        <li><a href='/<%#Eval("UrlPreco")%>' title='<%#Eval("ToolTip")%>'>
                            <%#Eval("Nome")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both;">
            <p>
                &nbsp;</p>
        </div>
        <div style="clear: both;">
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
        <div style="clear: both;">
        </div>
        <div class="tipos-orcamentos">
            <h3>
                Ano</h3>
            <ul class="checkList">
                <asp:Repeater ID="uxrptAnoMes" runat="server">
                    <ItemTemplate>
                        <li><a href='/<%#Eval("UrlAmigavel")%>' title='<%#Eval("ToolTip")%>'>
                            <%#Eval("Nome")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div style="clear: both;">
            <p>
                &nbsp;</p>
        </div>
        <h1 id="uxTituloH1" runat="server">
        </h1>
        <p>
            <asp:Label ID="uxllblObservacao" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="uxllblCidade" runat="server"></asp:Label>
            <br />
            <asp:Repeater ID="uxrptFotos" runat="server">
                <ItemTemplate>
                    <img src='FotosPost/"<%# Container.DataItem %>' height="100" width="100" alt="Preço e Orçamento Online Grátis" />
                </ItemTemplate>
            </asp:Repeater>
        </p>
        <div class="horizontalSep">
            <!-- -->
        </div>
        <ul class="iconBulletList">
            <asp:Repeater ID="uxrptPedidosOrcamentos" runat="server">
                <ItemTemplate>
                    <li>
                        <img src="/img/marcador-orcamento-online.png" alt="Orçamento Online Grátis Obras e Reformas, Arquitetos, Pintor e Pintura no Rio de Janeiro, São Paulo, Curitiba e Salvador"
                            class="fl" />
                        <h4 style="margin-top: 16px; margin-left: 50px;">
                            <a href="/orcamento-online-preco.aspx?idPedidoOrcamento=<%#Eval("Id")%>">Preço
                                <%#Server.HtmlEncode(Eval("Titulo").ToString())%></a>
                        </h4>
                        <p>
                            Detalhamento do pedido de orçamento:<br />
                            <br />
                            <%#Server.HtmlEncode(Eval("Observacao").ToString()).Replace(Environment.NewLine, "<br />")%><br />
                            Solicitado em
                            <%#String.Format("{0:dd/MM/yyyy}", Eval("Data"))%><br />
                            Local:
                            <%#Server.HtmlEncode(Eval("Cidade.Nome").ToString()) + "/" + Server.HtmlEncode(Eval("Cidade.UF").ToString())%></strong>
                        </p>
                        <!-- end productText -->
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    
</asp:Content>
