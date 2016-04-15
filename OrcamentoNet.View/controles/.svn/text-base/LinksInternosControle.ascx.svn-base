<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinksInternosControle.ascx.cs"
    Inherits="OrcamentoNet.View.controles.LinksInternosControle" %>
<div class="horizontalSep">
    <!-- -->
</div>
<h2 id="uxTituloH2" runat="server">
</h2>
<div class="tipos-orcamentos">
    <h3 id="H1" runat="server">
        Empresas e Parceiros Por Estado</h3>
    <ul class="checkList">
        <asp:Repeater ID="uxrptLinksEstadoCidadeParceiros" runat="server">
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
<div class="tipos-orcamentos">
    <h3 id="uxH3TituloLinksInterno" runat="server">
        Outros Pedidos Por Estado</h3>
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
    <p>
        &nbsp;</p>
</div>
<div class="tipos-orcamentos">
    <h3>
        Outros Pedidos Por Termo</h3>
    <ul class="checkList">
        <asp:Repeater ID="uxrptLinks" runat="server">
            <ItemTemplate>
                <li><a href='<%#Eval("UrlAmigavel")%>' title='<%#Eval("ToolTip")%>'>
                    <%#Eval("Nome")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
        <li>
            <asp:HyperLink ID="uxlnkTodos" runat="server">Todos</asp:HyperLink></li>
        <li><a href='/orcamento-online.aspx#listaOrcamentos' title='Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!'>
            Outros orçamentos</a></li>
    </ul>
</div>
<div style="clear: both;">
</div>
