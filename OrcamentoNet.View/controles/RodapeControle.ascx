<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RodapeControle.ascx.cs" Inherits="OrcamentoNet.View.controles.RodapeControle" %>
<!-- Footer Section Starts Here -->
<div class="horizontalSep">
    <!-- -->
</div>
<div class="footerMenu">
    <div class="fl" id="socialMedia">
        <h3>
            Divulgue o Orçamento Online</h3>
        <p>
            Fale sobre o orçamento online para seus amigos. Nós agradecemos!</p>
        <!-- AddThis Button BEGIN -->
        <div class="addthis_toolbox addthis_default_style" addthis:url="http://orcamentosgratis.net.br/"
            addthis:title="Orçamento Online" addthis:description="A sua ferramenta para multicotação simultânea de pesquisa de preços">
            <a class="addthis_button_orkut"></a><a class="addthis_button_facebook"></a><a class="addthis_button_twitter">
            </a><a class="addthis_button_email"></a><a class="addthis_button_linkedin"></a><a
                class="addthis_button_google"></a><a class="addthis_button_favorites"></a><a class="addthis_button_compact">
                </a>
        </div>

        <script type="text/javascript">var addthis_config = { "data_track_clickback": true };</script>

        <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4dfff7f80ea230ee"></script>

        <!-- AddThis Button END -->
        <!-- Place this tag where you want the +1 button to render -->
       <!-- <div style="margin-top: 4px;">
            <g:plusone size="small"></g:plusone>
            

            <script type="text/javascript">
                window.___gcfg = { lang: 'pt-BR' };
                (function() {
                    var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
                    po.src = 'https://apis.google.com/js/plusone.js';
                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
                })();
				</script>
 -->
        </div>
    </div>
    <!-- end socialMedia -->
    <div class="footerSeparator fl">
        <!-- -->
    </div>
    <div id="subscribe" class="fl">
        <h3 id="uxTituloH3RodapeVoceConhece" runat="server">
        </h3>
        <p>
            Conheça nossa rede de indicação de fornecedores e parceiros. Trabalhamos apenas
            com empresas e profissionais de reconhecida qualidade e competência. Você pode ficar
            tranquilo com as nossas indicações de
            <asp:HyperLink ID="hplLink" runat="server" Target="_blank" NavigateUrl="#" Text="fornecedores premium de Orçamento Online" ToolTip="Rede de profissionais e empresas indicados e recomendados. Um grupo selecionado dos melhores fornecedores para prestação de serviços, oportunidades de negócio ou busca de parcerias."></asp:HyperLink>.</p>
    </div>
    <!-- end subscribe -->
    <div class="footerSeparator fl">
        <!-- -->
    </div>
    <div id="contactInformation" class="fl">
        <h3 id="uxTituloH3RodapeHistorico" runat="server">Histórico de Preços e Cotações</h3>
        <p>
            Veja as consultas de
            <asp:HyperLink ID="hplLinkHistorico" runat="server" Target="_blank" NavigateUrl="~/orcamento-online-preco.aspx"
                Text="preços e cotações feitas através do Orçamento Online" ToolTip="Preço e cotação de produtos e serviços através de solicitação de orçamento online. Melhor preço e cotação para suas compras."></asp:HyperLink>
            Foram inúmeras oportunidades de negócio em que colaboramos para satisfazer compradores
            e fornecedores!</p>
    </div>
    <!-- end contactInformation -->
</div>
<!-- end footerMenu -->
