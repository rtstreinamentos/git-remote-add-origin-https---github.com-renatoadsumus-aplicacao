<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet.Master"
    CodeBehind="orcamento-online-pedido-historico.aspx.cs" Inherits="OrcamentoNet.View.orcamento_online_pedido_historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .Fonte24Azul
        {
            font-size: 24px;
            font-family: 'Droid Sans' , 'Arial' , sans-serif;
            color: #2b92fa; /* The skin color - This can be changed if you are going for a diferent color scheme */
            margin-bottom: 15px;
        }
        .lista
        {
            background: url("/img/checkListBullet.jpg") left top no-repeat;
            float: left;
            padding-left: 24px;
            margin-left: 20px;
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType3">
        <%--<img src="/img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
            class="productImg fl" /><br />&nbsp;<br />

				<script type="text/javascript"><!--
					google_ad_client = "ca-pub-9502900066313233";
					/* Box Esquerda */
					google_ad_slot = "8491994707";
					google_ad_width = 250;
					google_ad_height = 250;
			//-->
				</script>

				<script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
				</script>--%>
        <div class="tipos-orcamentos">
            <h3>
                Por Estado</h3>
            <ul class="checkList">
                <asp:Repeater ID="uxrptLinksEstadoCidade" runat="server">
                    <ItemTemplate>
                        <li><a href='/orcamento-online-pedido-historico.aspx?uf=<%#Eval("Nome")%>' title='<%#Eval("ToolTip")%>'>
                            <%#Eval("Nome")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <ul>
            <asp:Repeater ID="uxrptPedidosOrcamentos" runat="server">
                <ItemTemplate>
                    <li>
                        <img src="/img/marcador-orcamento-online.png" alt="Marcador do Orçamento Online"
                            class="fl" />
                        <h4 style="margin-top: 16px; margin-left: 50px;">
                            <%#Server.HtmlEncode(Eval("Titulo").ToString())%>
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
                        <!-- end productText -->
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
