<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.ascx.cs" Inherits="OrcamentoNet.View.controles.MenuAdmin" %>
<table>
    <tr>
        <td>
            <a href="MeusDados.aspx"><font size="3">Meus Dados </font></a>
        </td>
        <td width="29">
        </td>
        <td>
            <a href="UltimosPedidosOrcamento.aspx"><font size="3">Últimos Pedidos</font> </a>
        </td>
        <td width="29">
        </td>
        <td>
            <asp:HyperLink ID="uxhpkMeusPedidos" runat="server" ToolTip="Controle de Pedidos"
                NavigateUrl="~/MeusPedidos.aspx" Text="Meus Pedidos" Font-Size="Medium"></asp:HyperLink>
        </td>
        <td width="29">
        </td>
        <td>
            <a href="PedidosNaoRespondidos.aspx" title="Veja qual o status dos pedidos"><font
                size="3">Status dos Pedidos</font> </a>
                <td width="29">
        </td>
        </td>
         <td>
            <a href="Faq.aspx" title="Peguntas e Respostas"><font
                size="3">FAQ - Peguntas e Respostas</font> </a>
        </td>
    </tr>
</table>
