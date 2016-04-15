<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriaListaFornecedoresControle.ascx.cs" Inherits="OrcamentoNet.View.controles.CategoriaListaFornecedoresControle" %>
<div class="horizontalSep">
    <!-- -->
</div>
<asp:DataList RepeatLayout="Table" RepeatColumns="3" RepeatDirection="Horizontal"
    runat="server" ID="uxrptCategoriasColuna1" CellPadding="8" CellSpacing="4" ItemStyle-VerticalAlign="Top"
    Width="100%" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="33%">
    <HeaderTemplate>
        <h2 style="margin: 0 0 0 0;" id="listaOrcamentosH2">
			<a name="listaFornecedores">Quem são os fornecedores do Orçamento Online?</a></h2>
    </HeaderTemplate>
    <ItemTemplate>
        <h3 style="margin: 30px 0 8px 0;"><%#Eval("Nome")%></h3>
        <ul class="checkList">
            <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                <ItemTemplate>
                    <li style="margin: 0 6px 6px 0;"><a href='/<%#Eval("UrlFornecedores")%>' title='Conheça as lojas, profissionais e empresas do Orçamento Online para <%#Eval("Nome")%>'><%#Eval("Nome")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </ItemTemplate>
</asp:DataList>
