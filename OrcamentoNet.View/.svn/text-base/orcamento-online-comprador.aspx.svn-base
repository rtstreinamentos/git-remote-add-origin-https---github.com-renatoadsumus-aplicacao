<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orcamento-online-comprador.aspx.cs"
    Inherits="OrcamentoNet.View.orcamento_online_comprador" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="uxrptAreasDeRegiao" runat="server">
            <ItemTemplate>
                <%#Eval("Uf")%>
                <br />
                <ul>
                    <asp:Repeater ID="rpt" runat="server" DataSource='<%#Eval("Cidades")%>'>
                        <ItemTemplate>
                            <li><a href="#">
                                <%#Eval("Nome")%></a> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
