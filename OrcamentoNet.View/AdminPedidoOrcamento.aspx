﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPedidoOrcamento.aspx.cs"
    Inherits="OrcamentoNet.View.AdminPedidoOrcamento" %>

<%@ Register Src="controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:MultiView ID="multiview01" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewLogin" runat="server">
            <table>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="uxtxtEmailLogin" runat="server" Width="458px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="req001" ErrorMessage="*" runat="server" ControlToValidate="uxtxtEmailLogin"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Senha
                    </td>
                    <td>
                        <asp:TextBox ID="uxtxtSenhaLogin" TextMode="Password" runat="server" Width="457px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" runat="server"
                            ControlToValidate="uxtxtSenhaLogin"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="uxbtnEnviar" runat="server" Text="Enviar" OnClick="uxbtnEnviar_Click" />
        </asp:View>
        <asp:View ID="viewUltimosPedidos" runat="server">
            Pedidos de:
            <asp:DropDownList ID="uxddlDias" runat="server" AutoPostBack="true" OnSelectedIndexChanged="uxddlDias_SelectedIndexChanged">
                <asp:ListItem Value="0">Hoje</asp:ListItem>
                <asp:ListItem Value="-1">-1</asp:ListItem>
                <asp:ListItem Value="-2">-2</asp:ListItem>
                <asp:ListItem Value="-2">-3</asp:ListItem>
            </asp:DropDownList>
            <asp:GridView runat="server" ID="uxgrdPedidos" AutoGenerateColumns="False" DataKeyNames="Id"
                AlternatingRowStyle-BackColor="#DCDCDC" HeaderStyle-BackColor="#BEBEBE" OnSelectedIndexChanging="uxgrdPedidos_SelectedIndexChanging"
                OnRowCommand="uxgrdPedidos_RowCommand1">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label Width="80" ID="TextBox3" runat="server" Text='<%# Bind("Data") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label Width="170" ID="TextBox3" runat="server" Text='<%# Bind("NomeComprador") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label Width="240" ID="TextBox3" runat="server" Text='<%# Bind("Email") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email Validado">
                        <ItemTemplate>
                            <asp:Label Width="30" ID="TextBox3" runat="server" Text='<%# Bind("Status") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacao">
                        <ItemTemplate>
                            <asp:Label Width="700" ID="TextBox3" runat="server" Text='<%# Bind("Observacao") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Selecionar" />
                    <asp:ButtonField CommandName="Aprovar" Text="Aprovar" />
                </Columns>
                <HeaderStyle BackColor="#BEBEBE" />
                <AlternatingRowStyle BackColor="Gainsboro" />
            </asp:GridView>
        </asp:View>
        <asp:View ID="viewCadastro" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            Id
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtId" runat="server" Width="60px"></asp:TextBox>
                            <asp:Button ID="uxbtnBuscar" runat="server" Text="Buscar" OnClick="uxbtnBuscar_Click"
                                CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nome
                        </td>
                        <td>
                            <asp:Label ID="uxlblNome" runat="server" Width="458px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtEmail" runat="server" Width="457px"></asp:TextBox>
                            Validado:
                            <asp:DropDownList ID="uxddlEmailValidado" runat="server">
                                <asp:ListItem Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:DropDownList>
                        
                        </td>
                      
                            
                    </tr>
                    <tr>
                        <td>
                            Nome Fornecedor Avulso
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtNomeFornecedor" runat="server" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email Fornecedor Avulso
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtEmailFornecedorAvulso" runat="server" Width="350px"></asp:TextBox>
                            <asp:Button ID="uxbtnCompraAvulsa" runat="server" Text="Compra Avulsa" OnClick="uxbtnCompraAvulsa_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Classificação Pedido
                        </td>
                        <td>
                            <asp:DropDownList ID="uxddlClassificaoPedido" runat="server">
                                <asp:ListItem Value="1">Bronze</asp:ListItem>
                                <asp:ListItem Value="2">Prata</asp:ListItem>
                                <asp:ListItem Value="3">Ouro</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                   
                    <tr>
                        <td>
                            Telefone
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtTelefone" runat="server" Width="450px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Titulo
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtTitulo" runat="server" Width="450px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            URL Foto Principal
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtFotoPrincipal" runat="server" Width="450px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Aparece no Site
                        </td>
                        <td>
                            <asp:DropDownList ID="uxApareceNoSite" runat="server">
                                <asp:ListItem Value="False">Não</asp:ListItem>
                                <asp:ListItem Value="True">Sim</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                       
                           
                                <caption>
                                    Fotos
                                    <ul>
                                        <asp:Repeater ID="uxrptFotos" runat="server">
                                            <ItemTemplate>
                                                <li><a href="http://orcamentosgratis.net.br/FotosComprador/<%# Container.DataItem %>" 
                                                        target="_blank"><%# Container.DataItem %> </a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </caption>
                           
                       
                    </tr>
                    <tr>
                        <td colspan="2">
                            <label>
                                O que deseja?</label>
                            <asp:TextBox ID="uxtxtObservacao" runat="server" CssClass="ie6SubmitFix" Height="100px"
                                TextMode="MultiLine" ToolTip="Informe detalhes que auxiliem na elaboração do orçamento. Quanto mais detalhes, melhor."
                                Width="95%"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                </table>
                Categorias
                <div style="margin-top: 4px; width: 100%; height: 558px; overflow: auto;">
                    <asp:Repeater ID="uxrptCategorias" runat="server">
                        <ItemTemplate>
                            <strong>
                                <%#Eval("Nome")%></strong>
                            <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                                <ItemTemplate>
                                    <br />
                                    <asp:CheckBox runat="server" ID="uxchkSubCategoria" />
                                    <%--<%#Eval("Nome")%>--%>
                                    <asp:Label ID="uxlblNomeCategoria" runat="server" Text='<%#Eval("Nome") %>'></asp:Label>
                                    <asp:Label ID="uxlblIdCategoria" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:Repeater>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                    <uc1:CidadeDropDownControle ID="CidadeDropDownControle1" runat="server" />
                </div>
                <br />
                <asp:TextBox ID="uxtxtMaisInformacoesPedido" runat="server" TextMode="MultiLine"
                    Height="237px" Width="597px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="uxbtnSalvar" runat="server" Text="Salvar" OnClick="uxbtnSalvar_Click"
                    CausesValidation="false" />
                <asp:Button ID="uxbtnSolicitarMaisInformação" runat="server" Text="Solicitar Mais Informação"
                    OnClick="uxbtnSolicitarMaisInformacao_Click" />
            </div>
        </asp:View>
    </asp:MultiView>
    </form>
</body>
</html>
