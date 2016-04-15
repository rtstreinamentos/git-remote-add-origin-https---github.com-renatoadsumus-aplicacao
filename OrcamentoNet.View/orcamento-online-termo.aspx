<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet.Master"
    CodeBehind="orcamento-online-termo.aspx.cs" Inherits="OrcamentoNet.View.orcamento_online_termo" %>

<asp:Content ID="cpHead" ContentPlaceHolderID="Head" runat="server">
    <title>Orçamento Online - Cotação de Preços Grátis</title>
    <meta name="description" content="Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores. Prático, simples, eficaz e grátis!" />
    <meta name="keywords" content="casa,dicas,jardim,lâmpadas,limpeza,luminárias,piscina,piso,vidro,álcool,amônia,azulejos,brilho,truques,vinagre,alergia,bomba de água,mangueiras,microclima,repelir mosquitos,terraço,vantagens,varanda,acabamento,aquarela,brilhante,decoração,fosco,janelas,quadros,vidros,cores,móveis,sala,sofá multifunção,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,construção,construção ecológica,estruturas,gradua,lar sustentável,materiais de construção,meio ambiente,painéis,crianças,flores,poupar tempo,regadeira automática,regar,economia,eletrodomésticos,lava louça,máquina de lavar louça,almofadas,cuidado,manutenção,móveis d evime,móveis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,iluminação,potenciômetro,quarto dasc rianças,regulador,tomada,aço,barco,caracol,corrimãos,escadas,imperial,madeira,material,metal,modelos,segurança,apartamento de aluguel,idéias,luz natural,sofá,bustos,esculturas,estilo clássico,estilo eclético,figura de mármore,cômodidade,cortinas motorizadas,economia energética,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos automáticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retrô,poltrona,puf,sacada,tapete,baú,brinquedos,faixas decorativas,paredes,quarto de bebês,quarto de crianças, Comercial, Escritório, Grafiato,  Residência, Serviço, Textura, Condomínio, Profissional de Porta, Residencial, Preço, reformas, obras e reformas, construtores, orçamentos de reformas, orçamentos, obras, arquitetura, decoração de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
</asp:Content>

<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    <div class="productHeadingType3">
        <img src="/img/fechando-negocios-orcamento-online.jpg" alt="Feche negócios através do Orçamento Online"
            class="productImg fl" /><br />&nbsp;<br />
      <div class="productTrialForm3">
    <h1 style="margin-left:80px;">
        Qual o tipo de serviço você precisa?</h1>
    <h1 style="margin-left:20px;">
        Reforma:</h1>
    <ul>
        <asp:Repeater ID="uxrptTermos" runat="server">
            <ItemTemplate>
                <li><a href="/orcamento-online.aspx?categoria=27&termo=Reforma <%#Eval("Nome")%>" title="Preço para <%#Eval("Nome")%>">
                <%#Eval("Nome")%>
                </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    </div>
    </div>
</asp:Content>
