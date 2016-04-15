<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FornecedorPorCategoriaControle.ascx.cs"
    Inherits="OrcamentoNet.View.controles.FornecedorPorCategoriaControle" %>
<div class="horizontalSep">
    <!-- -->
</div>


 <div class="tipos-orcamentos">
        <h3 id="uxH3TituloLinksInterno" runat="server">
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
<h2 class="box_head grad_colour" id="htmlCategoriaH2" runat="server">
</h2>
<div>
    <asp:Repeater ID="uxrptFornecedores" runat="server">
        <ItemTemplate>
        
        <br />
            <br />
            <h2>
                <%#Server.HtmlEncode(Eval("Nome").ToString())%></h2>           
           
           
            <br />
            <a href="fornecedor-<%#Server.HtmlEncode(Eval("UrlFichaTecnica").ToString())%>">ver ficha completa</a>
            <%--<%#Eval("Descricao")%>--%>
            <br />
            <br />
            <br />
            <%--<div style="border:2px solid #007FC2;"></div>--%>
            <div style="border:1px solid #CDCDC1;"></div>
        </ItemTemplate>
    </asp:Repeater>
</div>
