<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinksInternosTemaCategoria.ascx.cs"
    Inherits="OrcamentoNet.View.controles.LinksInternosTemaCategoria" %>
<div class="tipos-orcamentos">
    <h3>
        Por Tema</h3>
    <ul class="checkList">
        <asp:Repeater ID="uxrptLinksInternos" runat="server">
            <ItemTemplate>
                <li><a href='/mapa-<%#Eval("UrlSEO")%>' title='Empresas, Profissionais e Oportunidades de Negócio em <%#Server.HtmlEncode(Eval("Nome").ToString())%>'>
                    <%#Server.HtmlEncode(Eval("Nome").ToString())%></a></li>
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
        Por Termo</h3>
    <ul class="checkList">
        <asp:Repeater ID="uxrptLinksTermo" runat="server">
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
    <p>
        &nbsp;</p>
</div>
<div class="tipos-orcamentos">
    <h3>
        Por Mês/Ano</h3>
    <ul class="checkList">
        <asp:Repeater ID="uxrptLinksMesAno" runat="server">
            <ItemTemplate>
                <li><a href='/<%#Eval("UrlAmigavel")%>' title='<%#Eval("ToolTip")%>'>
                    <%#Eval("Nome")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
<p>
    &nbsp;</p>
