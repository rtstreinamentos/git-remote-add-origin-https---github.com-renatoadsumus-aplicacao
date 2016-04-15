<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
    CodeBehind="UltimosPedidosOrcamento.aspx.cs" Inherits="OrcamentoNet.View.UltimosPedidosOrcamento" %>

<%@ Register Src="controles/MenuAdmin.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
    <br />
    <h3 id="h3NomeFornecedor" runat="server">
    </h3>
    <br />
    <asp:MultiView ID="multiview01" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewUltimosPedidos" runat="server">
            <h3>
                Veja os Pedidos Agrupados por Região:</h3>
            <asp:DropDownList ID="uxddlCidades" runat="server" OnSelectedIndexChanged="uxddlCidades_SelectedIndexChanged"
                AppendDataBoundItems="true" AutoPostBack="true">
                <asp:ListItem Value="0">Selecione</asp:ListItem>
            </asp:DropDownList>
            <p>
            </p>
            <h1>
                Últimos Pedidos de Orçamento de Todas as Regiões</h1>
            <div id="PedidosOrcamentoRecentes">
                <ul class="iconBulletList">
                    <asp:Repeater ID="uxrptPedidosOrcamentosDegustacao" runat="server">
                        <ItemTemplate>
                            <li>
                                <img src="/img/marcador-orcamento-online.png" alt="Marcador do Orçamento Online"
                                    class="fl" />
                                <h4 style="margin-top: 16px; margin-left: 50px;">
                                    <%#Server.HtmlEncode(Eval("Titulo").ToString())%>
                                    - Número Pedido:
                                    <%# Eval("Id")%>
                                </h4>
                                <p>
                                    <b>Classificação Pedido:</b>
                                    <%# Eval("ClassificacaoPedido")%>
                                    <br />
                                    <br />
                                    <b>Solicitante:</b>
                                    <%#Server.HtmlEncode(Eval("NomeComprador").ToString())%>...
                                    <br />
                                    <b>Email:</b>
                                    <%#Server.HtmlEncode(Eval("Email").ToString().ToString().Substring(0, 6))%>...@XXX.com
                                    <br />
                                    <b>Telefone:</b>
                                    <%#Server.HtmlEncode(Eval("Telefone").ToString().ToString().Substring(0, 7))%>-XXXX
                                    <br />
                                    <b>Detalhamento do pedido de orçamento:</b><br />
                                    <br />
                                    <%#Server.HtmlEncode(Eval("Observacao").ToString()).Replace(Environment.NewLine, "<br />")%><br />
                                    <b>Solicitado em</b>
                                    <%#String.Format("{0:dd/MM/yyyy}", Eval("Data"))%><br />
                                    <b>Local:</b>
                                    <%#Server.HtmlEncode(Eval("Cidade.Nome").ToString()) + "/" + Server.HtmlEncode(Eval("Cidade.UF").ToString())%></strong>
                                </p>
                                <p>
                                    <a href="UltimosPedidosOrcamento.aspx?idPedido=<%# Eval("Id")%>"><font size="3">Quero
                                        Participar da Cotação Avulsa</font></a>
                                    <br />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <p>
                        Escala Classificação dos Pedidos:
                        <br />
                        - Bronze<br />
                        - Prata<br />
                        - Ouro<br />
                        - Diamente
                    </p>
                    <ul class="iconBulletList">
                        <asp:Repeater ID="uxrptPedidosOrcamentosClienteCortesia" runat="server" OnItemCommand="Repeater1_OnItemCommand">
                            <ItemTemplate>
                                <li>
                                    <img src="/img/marcador-orcamento-online.png" alt="Marcador do Orçamento Online"
                                        class="fl" />
                                    <h4 style="margin-top: 16px; margin-left: 50px;">
                                        <%#Server.HtmlEncode(Eval("Titulo").ToString())%>
                                        - Número Pedido:
                                        <%# Eval("Id")%>
                                    </h4>
                                    <asp:Label ID="key1Label" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                    <p>
                                        <b>Solicitante:</b>
                                        <%#Server.HtmlEncode(Eval("NomeComprador").ToString())%>
                                        <br />
                                        <b>Email:</b>
                                        <%#Server.HtmlEncode(Eval("Email").ToString())%>
                                        <br />
                                        <b>Telefone:</b>
                                        <%#Server.HtmlEncode(Eval("Telefone").ToString())%>
                                        <br />
                                        <b>Operadora:</b>
                                        <%#Server.HtmlEncode(Eval("TelefoneOperadora").ToString())%>
                                        <br />
                                        <b>Detalhamento do pedido de orçamento:</b><br />
                                        <br />
                                        <%#Server.HtmlEncode(Eval("Observacao").ToString()).Replace(Environment.NewLine, "<br />")%><br />
                                        <b>Solicitado em</b>
                                        <%#String.Format("{0:dd/MM/yyyy}", Eval("Data"))%><br />
                                        <b>Local:</b>
                                        <%#Server.HtmlEncode(Eval("Cidade.Nome").ToString()) + "/" + Server.HtmlEncode(Eval("Cidade.UF").ToString())%></strong>
                                        <br />
                                        <b>Fotos enviadas do local:</b>
                                        <asp:Repeater ID="uxptfotos" runat="server" DataSource='<%#Eval("Fotos")%>'>
                                            <ItemTemplate>
                                                <br />
                                                <a href="fotoscomprador/<%# Container.DataItem %>" target="_blank">
                                                    <%# Container.DataItem %></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <br />
                                        <br />
                                        <asp:LinkButton Font-Size="Large" ID="uxbtnGuardarPedido" CommandName="Update" runat="server"
                                            Text="Guardar em Meus Pedidos" CssClass="btn-success" ToolTip="Ao clicar nesse pedido ele será enviado para o item Meus Pedidos." />
                                    </p>
                                    <!-- end productText -->
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
            </div>
            <div class="horizontalSep">
                <!-- -->
            </div>
            <!-- Product Buy Button Section Starts Here -->
            <div class="bigBuyButton">
            </div>
        </asp:View>
        <asp:View ID="viewBoxCompraAvulsa" runat="server">
            <asp:HyperLink CssClass="ie6SubmitFix" Font-Size="Large" ID="uxhplPagSeguro" runat="server"></asp:HyperLink>
        </asp:View>
    </asp:MultiView>
</asp:Content>
