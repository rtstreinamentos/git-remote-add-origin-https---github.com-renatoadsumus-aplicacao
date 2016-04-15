<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeusPedidos.aspx.cs" MasterPageFile="~/OrcamentoNet2.Master"
    Inherits="OrcamentoNet.View.MeusPedidos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="controles/MenuAdmin.ascx" TagName="MenuAdmin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 33px;
            font-size: medium;            
        }
    </style>
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div id="mainWrapper">
        <!-- Top Section Starts Here -->
        <uc1:MenuAdmin ID="MenuAdmin1" runat="server" />
        <asp:MultiView ID="multiview01" runat="server" ActiveViewIndex="0">
            <asp:View ID="viewMeusPedidos" runat="server">
                <br />
                <br />
                Selecione Status:<asp:DropDownList ID="uxddlStatusPedido" runat="server" OnSelectedIndexChanged="uxddlStatusPedido_SelectedIndexChanged"
                    AutoPostBack="true">
                   
                    <asp:ListItem Value="NaoEnviado">Não Enviado</asp:ListItem>
                    <asp:ListItem Value="Enviado">Enviado</asp:ListItem>
                    <asp:ListItem Value="EmNegociacao">Em Negociação</asp:ListItem>
                    <asp:ListItem Value="Aprovado">Aprovado</asp:ListItem>
                    <asp:ListItem Value="Cancelado">Cancelado</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="uxbtnCriarPedido" runat="server" Text="  Criar Pedido Externo "
                    CssClass="btn-success" OnClick="uxbtnCriarPedido_Click" ToolTip="Cria um pedido externo do Orçamento Online, ou seja um pedido que não tenha sido enviado pelo nosso sistema." />
                <br />
                <br />
                <h2 runat="server" id="uxH2">
                    Nenhum Pedido Encontrado!Selecione outro status!
                </h2>
                <br />
                <asp:GridView runat="server" ID="uxgrdPedidos" AutoGenerateColumns="False" DataKeyNames="Id"
                    AlternatingRowStyle-BackColor="#DCDCDC" HeaderStyle-BackColor="#BEBEBE" OnSelectedIndexChanging="uxgrdPedidos_SelectedIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Pedido" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                                <asp:Label ID="TextBoxId" Width="60" runat="server" Text='<%# Bind("PedidoOrcamento.Id") %>'
                                    Font-Size="Medium" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Solicitante" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                                <asp:Label Width="170" ID="TextBox1" runat="server" Text='<%# Bind("PedidoOrcamento.NomeComprador") %>'
                                    Font-Size="Medium" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Titulo" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                                <asp:Label Width="270" ID="TextBox2" runat="server" Text='<%# Bind("PedidoOrcamento.Titulo") %>'
                                    Font-Size="Medium" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data do Pedido" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                                <asp:Label Width="150" ID="TextBox3" runat="server" Text='<%# Bind("PedidoOrcamento.Data") %>'
                                    Font-Size="Medium" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Data Última Alteração" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                                <asp:Label Width="150" ID="TextBox4" runat="server" Text='<%# Bind("DataAltercao") %>'
                                    Font-Size="Medium" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" SelectText="Selecionar" />
                    </Columns>
                    <HeaderStyle BackColor="#BEBEBE" />
                    <AlternatingRowStyle BackColor="Gainsboro" />
                </asp:GridView>
                <br />
                <h3>
                    Quando eu uso cada status?</h3>
                <p>
                    <span style="font-size: large"><b>Não Enviado </b></span>
                    <br />
<span style="font-size: medium">significa que separou o pedido, mas ainda não enviou o orçamento ao
                    solicitante.</span>
                    <br />
                    <span style="font-size: large"><b>Enviado</b></span>
                    <br />
                   <span style="font-size: medium"> significa que já enviou o orçamento ao solicitante e está aguardando um retorno.</span>
                    <br />
                    <span style="font-size: large"><b>Em Negociação</b></span>
                    <br />
                   <span style="font-size: medium"> significa que o solicitante já realizou algum tipo de retorno e você se encontra
                    em negociação com o cliente, nesse momento aconselhamos você incluir informações
                    adicionais ao pedido, por exemplo:
                    <br />
                     <img src="img/checkListBullet.jpg" /> data/hora da visita
                    <br />
                    <img src="img/checkListBullet.jpg" /> responsável pelo atendimento
                    <br />
                     <img src="img/checkListBullet.jpg" /> comissão
                    <br />
                     <img src="img/checkListBullet.jpg" /> valor do orçamento
                    <br />
                     <img src="img/checkListBullet.jpg" /> condições de pagamento
                    <br />
                     <img src="img/checkListBullet.jpg" />contatos adicionais do cliente como:nome, email e telefone </li>
                    <br />
                    </span>
                    <span style="font-size: large"><b>Cancelado</b></span>
                    <br />
                    <span style="font-size: medium">significa que o orçamento não foi aprovado pelo cliente ou você desistiu do serviço,
                    nesse caso você também incluir essas informações no pedido adicionais do motivo</span>
                    desse cancelamento.
                    <br />
                    <span style="font-size: large"><b>Aprovado</b></span>
                    <br />
                    <span style="font-size: medium">significa que o cliente aprovou o orçamento e você irá iniciar os serviços.</span>
                </p>
                
               <h3>
                    É muito importante você manter atualizado o status de cada pedido assim como suas
                    informações adicionais, isso ajudará você manter um histórico e gerar um aprendizado
                    para você e sua empresa.
                </h3>
            </asp:View>
            <asp:View ID="viewDetalhePedido" runat="server">
                <br />
                <div>
                    <table>
                        <tr class="style1">
                            <td>
                                Id
                            </td>
                            <td>
                                <asp:Label ID="uxlblId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr  class="style1">
                            <td>
                                Nome
                            </td>
                            <td>
                                <asp:Label ID="uxlblNome" runat="server" Width="458px"></asp:Label>
                            </td>
                        </tr>
                        <tr class="style1">
                            <td>
                                Email
                            </td>
                            <td>
                                <asp:Label ID="uxlblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr  class="style1">
                            <td >
                                Telefone
                            </td>
                            <td class="style1">
                                <asp:Label ID="uxtxtTelefone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr  class="style1">
                            <td>
                                Titulo
                            </td>
                            <td>
                                <asp:Label ID="uxtxtTitulo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="style1">
                            <td>
                                Status do Orçamento
                            </td>
                            <td>
                                <asp:DropDownList ID="uxddlStatusPedido2" runat="server">
                                    <asp:ListItem Value="NaoEnviado">Não Enviado</asp:ListItem>
                                    <asp:ListItem Value="Enviado">Enviado</asp:ListItem>
                                    <asp:ListItem Value="EmNegociacao">Em Negociação</asp:ListItem>
                                    <asp:ListItem Value="Aprovado">Aprovado</asp:ListItem>
                                    <asp:ListItem Value="Cancelado">Cancelado</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="style1">
                            <td colspan="2">
                                <label>
                                    Descrição</label>
                                <br />
                                <asp:TextBox ID="uxtxtObservacao" runat="server" CssClass="ie6SubmitFix" Height="237px"
                                    TextMode="MultiLine" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor."
                                    Width="597px" ReadOnly="true"></asp:TextBox>
                                <br />
                            </td>
                        </tr>
                    </table>
                     <br />
                      <br />
                    <span class="style1">Suas Anotações Adicionais do Pedido</span>
                    <br />
                    <span style="font-size: small">Somente você terá acesso a essas anotações, você poderá
                        usar guardar informações como: data de início, data de visita, comissão de um vendedor,
                        nome de quem está atuando no pedido e etc </span>
                    <br />
                    <asp:TextBox ID="uxtxtMaisInformacoesPedido" runat="server" TextMode="MultiLine"
                        Height="237px" Width="597px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="uxbtnSalvar" runat="server" Text="Salvar" Font-Bold="true" Font-Size="Large"
                        OnClick="uxbtnSalvar_Click" />
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
