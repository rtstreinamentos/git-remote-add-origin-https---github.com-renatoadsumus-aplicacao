<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PedidosOrcamentoControle.ascx.cs"
    Inherits="OrcamentoNet.View.controles.PedidosOrcamentoControle" %>
<p id="mensagemVazio" runat="server">
</p>
<ul class="iconBulletList" >
    
    <asp:Repeater ID="uxrptPedidosOrcamentosComImagem" runat="server">
        <ItemTemplate>
            <li itemscope itemtype="http://schema.org/NewsArticle">
                <img src="../FotosComprador/<%#Eval("FotoPrincipal")%>"alt="Orçamento Online Grátis Obras e Reformas, Arquitetos, Pintor e Pintura no Rio de Janeiro, São Paulo, Curitiba e Salvador"
                      width="330px" height="200px" title="Orçamento Online Grátis Obras e Reformas, Arquitetos, Pintor e Pintura no Rio de Janeiro, São Paulo, Curitiba e Salvador"/>
                     <br />
                     <br />
                <b itemprop="headline">
                    <%#Server.HtmlEncode(Eval("Titulo").ToString())%>
                </b>
                <p itemprop="description">
                    <br />
                    <br />
                    <%#Server.HtmlEncode(Eval("Observacao").ToString()).Replace(Environment.NewLine, "<br />")%><br />
                   
                    
                </p>
                <!-- end productText -->
            </li>
        </ItemTemplate>
    </asp:Repeater>
    
    <asp:Repeater ID="uxrptPedidosOrcamentos" runat="server">
        <ItemTemplate>
            <li>
                <img src="/img/marcador-orcamento-online.png" alt="Orçamento Online Grátis Obras e Reformas, Arquitetos, Pintor e Pintura no Rio de Janeiro, São Paulo, Curitiba e Salvador"
                    class="fl" />
                    
                <h4 style="margin-top: 16px; margin-left: 50px;">
                    Preço
                    <%#Server.HtmlEncode(Eval("Titulo").ToString())%>
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
    <asp:Repeater ID="uxrptPedidosOrcamentosPreco" runat="server" Visible="false">
        <ItemTemplate>
            <li>
                <img src="/img/marcador-orcamento-online.png" alt="Orçamento Online Grátis Obras e Reformas, Arquitetos, Pintor e Pintura no Rio de Janeiro, São Paulo, Curitiba e Salvador"
                    class="fl" />
                <h4 style="margin-top: 16px; margin-left: 50px;">
                    <%#Server.HtmlEncode(Eval("TituloPreco").ToString())%>
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
