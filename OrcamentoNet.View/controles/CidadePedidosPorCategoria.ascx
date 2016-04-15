<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CidadePedidosPorCategoria.ascx.cs" Inherits="OrcamentoNet.View.controles.CidadePedidosPorCategoria" %>
<div class="horizontalSep">
    <!-- -->
</div>
<h2 id="uxTituloH2" runat="server">
</h2>
<div class="tipos-orcamentos">
    <ul class="checkList">
        <asp:Repeater ID="uxrptLinks" runat="server">
            <ItemTemplate>
                <li><a href='/<%#Eval("url")%>' title='<%#Eval("tooltip")%>'><%#Eval("nomeExibicao")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
        <li><a href='/orcamento-online.aspx#listaOrcamentos' title='Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!'>Outros orçamentos</a></li>
    </ul>
</div>
<div style="clear: both;">
</div>
