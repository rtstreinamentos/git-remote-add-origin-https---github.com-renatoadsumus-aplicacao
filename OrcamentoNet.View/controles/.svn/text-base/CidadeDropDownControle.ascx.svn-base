<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CidadeDropDownControle.ascx.cs"
    Inherits="OrcamentoNet.View.controles.CidadeDropDownControle" %>
<asp:Label ID="uxlblMensagem" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Medium"></asp:Label>
<label>
    Onde? (Estado e Cidade/Região)</label>
<asp:DropDownList ID="uxddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="uxDdlEstado_SelectedIndexChanged"
    Width="60">
</asp:DropDownList>
&nbsp;-&nbsp;
<asp:DropDownList ID="uxddlCidade" runat="server" Width="190">
    <asp:ListItem Value="0">Selecione</asp:ListItem>
</asp:DropDownList>
<br />
<asp:RequiredFieldValidator ID="RequiredFieldValidator998" runat="server" ControlToValidate="uxddlEstado"
    InitialValue="Selecione" ErrorMessage="" Text="O estado deve ser informado." /><br />
<asp:RequiredFieldValidator ID="RequiredFieldValidator999" runat="server" ControlToValidate="uxddlCidade"
    InitialValue="0" ErrorMessage="" Text="A cidade deve ser informada." />

