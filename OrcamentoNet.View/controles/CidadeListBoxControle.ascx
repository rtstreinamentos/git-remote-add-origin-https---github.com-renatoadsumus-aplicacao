<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CidadeListBoxControle.ascx.cs"
    Inherits="OrcamentoNet.View.controles.CidadeListBoxControle" %>
<label>
    Em qual estado você atua?</label>
<asp:DropDownList ID="uxddlEstado" AppendDataBoundItems="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="uxDdlEstado_SelectedIndexChanged"
    Width="60">
    <asp:ListItem Value="0">Selecione</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator998" runat="server" ControlToValidate="uxddlEstado"
    InitialValue="Selecione" ErrorMessage="" Text="O estado deve ser informado." /><br />

<br />
<div style="float: left; width: 100%;">
    <label id="uxlblCidade" runat="server" visible="false">
        Em quais cidades você atua?</label>
    <ul class="fl">
        <li class="sugestoesOrcamentos">
            <asp:CheckBoxList ID="uxchkCidades" runat="server">
            </asp:CheckBoxList>
        </li>
    </ul>
</div>
