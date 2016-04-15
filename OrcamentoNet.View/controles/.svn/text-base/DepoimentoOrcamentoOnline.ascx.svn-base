<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepoimentoOrcamentoOnline.ascx.cs"
	Inherits="OrcamentoNet.View.DepoimentoOrcamentoOnline" %>
<p id="mensagemVazio" runat="server">
</p>
<ul>
	<asp:Repeater ID="uxrptDepoimentos" runat="server">
		<ItemTemplate>
			<li style="margin-bottom: 10px;"><strong>
				<%#Server.HtmlEncode(Eval("NomeComprador").ToString())%></strong><br />
				Do que você mais gostou?<br />
				<%#Server.HtmlEncode(Eval("OpiniaoComprador").ToString())%><br />
				<em>
					<%#Server.HtmlEncode(Eval("Cidade.Nome").ToString())%>/<%#Server.HtmlEncode(Eval("Cidade.Uf").ToString())%></em>,
				em
				<%#String.Format("{0:dd/MM/yyyy}", Eval("Data"))%>
			</li>
		</ItemTemplate>
	</asp:Repeater>
</ul>
