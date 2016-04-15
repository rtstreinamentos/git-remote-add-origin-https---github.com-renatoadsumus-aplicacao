<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriaListaControle.ascx.cs"
    Inherits="OrcamentoNet.View.controles.CategoriaListaControle" %>
<div class="horizontalSepNegativo">
	<!-- -->
</div>
<div style="margin-bottom: 24px;">
	<center>
<script type="text/javascript"><!--
google_ad_client = "ca-pub-9502900066313233";
/* Banner Topo */
google_ad_slot = "2585061900";
google_ad_width = 728;
google_ad_height = 90;
//-->
</script>
<script type="text/javascript"
src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
</script>
</center>
</div>
<asp:DataList RepeatLayout="Table" RepeatColumns="3" RepeatDirection="Horizontal"
	runat="server" ID="uxrptCategoriasColuna1" CellPadding="8" CellSpacing="4" ItemStyle-VerticalAlign="Top"
	Width="100%" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="33%">
	<HeaderTemplate>
		<h2 style="margin: 0 0 0 0;" id="listaOrcamentosH2">
			<a name="listaOrcamentos">Que orçamentos posso solicitar?</a></h2>
	</HeaderTemplate>
    <ItemTemplate>
        <h3 style="margin: 30px 0 8px 0;">
            <%#Eval("Nome")%></h3>
        <ul class="checkList">
            <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                <ItemTemplate>
                    <li style="margin: 0 6px 6px 0;"><a href='/<%#Eval("Url")%>' title='Solicite orçamento online <%#Eval("Nome")%>. Receba cotação de preços de vários fornecedores de <%#Eval("Nome")%>. Prático, simples, eficaz e grátis!'><%#Eval("Nome")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </ItemTemplate>
</asp:DataList>
