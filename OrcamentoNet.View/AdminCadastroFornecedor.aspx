<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCadastroFornecedor.aspx.cs"
    Inherits="OrcamentoNet.View.AdminCadastroFornecedor" %>

<%@ Register Src="/controles/CidadeDropDownControle.ascx" TagName="CidadeDropDownControle"
    TagPrefix="uc1" %>
<%@ Register Src="controles/CidadeListBoxControle.ascx" TagName="CidadeListBoxControle"
    TagPrefix="uc2" %>
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
            <asp:Button ID="uxbtnEnviar" runat="server" Text="Enviar" CssClass="ie6SubmitFix"
                OnClick="uxbtnEnviar_Click" />
        </asp:View>
        <asp:View ID="viewCadastro" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            ID
                        </td>
                        <td>
                            <asp:HyperLink ID="hpyFichaTecnica" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nome
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtNome" runat="server" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtEmail" runat="server" Width="350px"></asp:TextBox>
							<asp:Button ID="uxbtnBuscar" runat="server" Text="Buscar" CausesValidation="false"
								OnClick="uxbtnBuscar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email Secundário
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtEmailSecundario" runat="server" Width="350px"></asp:TextBox>
							
                        </td>
                    </tr>
                    <tr>
                    <td>
                            Senha
                        </td>
                    <td>
                    <asp:Label ID="uxlblSenha" runat="server"></asp:Label>
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
                            WebSite
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtSite" runat="server" Width="446px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Indicação
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtIndicacao" runat="server" Width="446px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Valor
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtValorMensalidade" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo Pessoa Atendimento
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtTipoPessoa" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrição
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtDescricao" runat="server" TextMode="MultiLine" Height="101px"
                                Width="451px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data Cadastro
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtDataCadastro" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data Vencimento
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtDataCobranca" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="uxddlStatus">
                                <asp:ListItem>Degustacao</asp:ListItem>
                                <asp:ListItem>Cliente</asp:ListItem>
                                <asp:ListItem>Inativo</asp:ListItem>
                                <asp:ListItem>Cortesia</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Dias Ultimos Pedidos
                        </td>
                        <td>
                            <asp:TextBox ID="uxtxtDiasUltimosPedidos" runat="server" Text="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="uxlblMensagem" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <asp:Button ID="uxbtnSalvar" runat="server" Text="Salvar" OnClick="uxbtnSalvar_Click" />
            <asp:Button ID="uxbtnEmailPagamento" runat="server" Text="Email Pagamento Recebido"
                CausesValidation="false" OnClick="uxbtnEmailPagamento_Click" />
            <asp:Button ID="uxbtnEnviarUltimosPedidos" runat="server" Text="Enviar Pedidos" OnClick="uxbtnEnviarUltimosPedidos_Click" />
            <asp:Button ID="uxbtnEnviarUltimosPedidosTruncados" runat="server" 
                Text="Enviar Pedidos Truncados" 
                onclick="uxbtnEnviarUltimosPedidosTruncados_Click"  />
            <asp:Button ID="uxbtnFornecedoresNovos" runat="server" CausesValidation="false" Text="Fornecedores Novos"
                OnClick="uxbtnFornecedoresNovos_Click" />
            <br />
            <uc2:CidadeListBoxControle ID="CidadeListBoxControle1" runat="server" />
            <div style="margin-top: 4px; width: 100%; height: 558px; overflow: auto;">
                <asp:Repeater ID="uxrptCategorias" runat="server">
                    <ItemTemplate>
                        <strong>
                            <%#Eval("Nome")%></strong>
                        <asp:Repeater ID="uxrptSubCategorias" runat="server" DataSource='<%#Eval("SubCategorias")%>'>
                            <ItemTemplate>
                                <br />
                                <asp:CheckBox ID="uxchkSubCategoria" runat="server" />
                                
                                <asp:Label ID="uxlblNomeCategoria" runat="server" Text='<%#Eval("Nome") %>'></asp:Label>
                                <asp:Label ID="uxlblIdCategoria" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="uxtxtPrioridade" runat="server" Width="14"></asp:TextBox>
                            </ItemTemplate>
                        </asp:Repeater>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </asp:View>
        <asp:View ID="viewNovosFornecedores" runat="server">
            <asp:GridView runat="server" ID="uxgrdFornecedores" AutoGenerateColumns="False" DataKeyNames="Id"
                AlternatingRowStyle-BackColor="#DCDCDC" HeaderStyle-BackColor="#BEBEBE" OnSelectedIndexChanging="uxgrdFornecedores_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label Width="170" ID="TextBox3" runat="server" Text='<%# Bind("Nome") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descrição">
                        <ItemTemplate>
                            <asp:Label Width="700" ID="TextBox3" runat="server" Text='<%# Bind("Descricao") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Selecionar" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
    </form>
</body>
</html>
