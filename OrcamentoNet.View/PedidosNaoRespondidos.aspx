<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
    CodeBehind="PedidosNaoRespondidos.aspx.cs" Inherits="OrcamentoNet.View.PedidosNaoRespondidos" %>


	<%@ Register src="controles/MenuAdmin.ascx" tagname="MenuAdmin" tagprefix="uc1" %>
	
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
            Status do pedido:<asp:DropDownList ID="uxddlStatus" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="uxddlStatus_SelectedIndexChanged">
                <asp:ListItem Value="1">Ainda não recebi orçamentos</asp:ListItem>
                <asp:ListItem Value="2">Já fechei o serviço</asp:ListItem>
                <asp:ListItem Value="3">Estou analisando as propostas</asp:ListItem>
                <asp:ListItem Value="4">Desistir não vou contratar </asp:ListItem>
            </asp:DropDownList>
           <div class="horizontalSep">
            </div>
            <h3 id="h4" runat="server">
            </h3>
            <div class="horizontalSep">
            </div>
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
                                    Detalhamento do pedido de orçamento:<br />
                                    <br />
                                    <%#Server.HtmlEncode(Eval("Observacao").ToString()).Replace(Environment.NewLine, "<br />")%><br />
                                    Solicitado em
                                    <%#String.Format("{0:dd/MM/yyyy}", Eval("Data"))%><br />
                                    Local:
                                    <%#Server.HtmlEncode(Eval("Cidade.Nome").ToString()) + "/" + Server.HtmlEncode(Eval("Cidade.UF").ToString())%></strong>
                                </p>
                                <p>
                                    <font size="3">Qual o status do pedido?</font>
                                    <br />
                                     <font size="3" color="red">
                                        <%# Eval("StatusPedidoCompradorTitulo")%></font>
                                </p>
                                <p>
                                    <b>O que foi bom?</b>
                                    <br />
                                    <%# Eval("OpiniaoComprador")%>
                                </p>
                                <p>
                                    <b>O que pode ser melhorado?</b>
                                    <br />
                                    <%# Eval("PontosMelhoria")%>
                                </p>
                                <p>
                                    <b>Gostou do Orçamento Online?</b>
                                    <br />
                                    Sim
                                </p>
                                <p>
                                    <a href="UltimosPedidosOrcamento.aspx?idPedido=<%# Eval("Id")%>"><font size="3">Quero
                                        Participar da Cotação Avulsa</font></a>
                                    <br />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <ul class="iconBulletList">
                    <asp:Repeater ID="uxrptPedidosOrcamentosClienteCortesia" runat="server">
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
                                    <b>Solicitante:</b>
                                    <%#Server.HtmlEncode(Eval("NomeComprador").ToString())%>
                                    <br />
                                    <b>Email:</b>
                                    <%#Server.HtmlEncode(Eval("Email").ToString())%>
                                    <br />
                                    <b>Telefone:</b>
                                    <%#Server.HtmlEncode(Eval("Telefone").ToString())%>
                                    <br />
                                    Detalhamento do pedido de orçamento:<br />
                                    <br />
                                    <%#Server.HtmlEncode(Eval("Observacao").ToString()).Replace(Environment.NewLine, "<br />")%><br />
                                    Solicitado em
                                    <%#String.Format("{0:dd/MM/yyyy}", Eval("Data"))%><br />
                                    Local:
                                    <%#Server.HtmlEncode(Eval("Cidade.Nome").ToString()) + "/" + Server.HtmlEncode(Eval("Cidade.UF").ToString())%></strong>
                                </p>
                                <p>
                                    <font size="3">Qual o status do pedido?</font>
                                    <br />
                                     <font size="3" color="red">
                                        <%# Eval("StatusPedidoCompradorTitulo")%></font>
                                </p>
                                <p>
                                    <b>O que foi bom?</b>
                                    <br />
                                    <%# Eval("OpiniaoComprador")%>
                                </p>
                                <p>
                                    <b>O que pode ser melhorado?</b>
                                    <br />
                                    <%# Eval("PontosMelhoria")%>
                                </p>
                                <p>
                                    <b>Gostou do Orçamento Online?</b>
                                    <br />
                                    Sim
                                </p>
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
