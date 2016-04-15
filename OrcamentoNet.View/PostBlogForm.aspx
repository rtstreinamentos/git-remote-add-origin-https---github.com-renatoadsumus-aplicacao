<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrcamentoNet2.Master"
    CodeBehind="PostBlogForm.aspx.cs" Inherits="OrcamentoNet.View.PostBlogForm" %>

<asp:Content ID="cpHead" ContentPlaceHolderID="Head" runat="server">
<link type="text/css" rel="stylesheet" href="http://i0.statig.com.br/css/jquery.css" />

<link type="text/css" rel="stylesheet" href="/css/Blog.css"/>

    <script>        window.jQuery || document.write('<script src="http://js.statig.com.br/egomes/jquery-1.9.1.min.js">\x3C/script>')</script>

    <script type="text/javascript">        (function() { try { var c = document.location.hostname, a = document.createElement("script"); a.type = "text/javascript"; a.async = !0; a.src = "//js.statig.com.br/metricas/metricas." + c + ".js"; var b = document.getElementsByTagName("script")[0]; b.parentNode.insertBefore(a, b) } catch (d) { } })();</script>

    <script type="text/javascript" src="js/solrator-0.2.1.js"></script>

    <script type="text/javascript" src="http://js.statig.com.br/egomes/ads-min.js?v=0.3"> </script>

    <script type="text/javascript" src="js/plusone.js"></script>

    <script type="text/javascript" src="js/jquery.mCustomScrollbar.js"></script>

    <script type="text/javascript">        /* ** enables the cache on every ajax/jsonp/getscript request** this line removes the querystring param _=187236123231 */$.ajaxSetup({ cache: true });</script>

    <script type="text/javascript">        /** * Todos os scripts que serao carregados e dependem do modo de edicao devem ser incluidos nesta classe e instanciados por ela */function ScriptsSiteiG() { this.scripts = { jquery_ui_edicao: '<scr' + 'ipt type="text/javascript" src="http://js.statig.com.br/egomes/jquery-ui.js"> </scr' + 'ipt>', jquery_ui_producao: '<scr' + 'ipt type="text/javascript" src="http://js.statig.com.br/jquery-ui_1.10.3.js"> </scr' + 'ipt>', ibtx_realtime_padrao: '<scr' + 'ipt type="text/javascript" src="http://www.apps.realtime.co/IBTX/raGGuI/IBTX.js"></scr' + 'ipt>', ibtx_realtime_minas: '<scr' + 'ipt type="text/javascript" src="http://www.apps.realtime.co/IBTX/WXNLBS/IBTX.js"></scr' + 'ipt>', rti30018_useg: '<scr' + 'ipt type="text/javascript" src="http://js.statig.com.br/ultimosegundo/rt/RTI30018-v4.min.js"></scr' + 'ipt>', rti30018_minas: '<scr' + 'ipt type="text/javascript" src="http://js.statig.com.br/regionalizacao/minasgerais/RTI30018.min.js"></scr' + 'ipt>' }; } /** * Agrupa chamadas aos scripts que devem carregar */ScriptsSiteiG.prototype.baixar = function() { var self = this; /* regra para baixar versoes do script do realtime */if (IG_INFO.HOST.indexOf('minasgerais') > -1) { document.write(self.scripts.ibtx_realtime_minas); } else { document.write(self.scripts.ibtx_realtime_padrao); } /* regra para baixar somente nas homes */if (IG_INFO.SECAO === 'home') { /* ultimo segundo */if (IG_INFO.HOST.indexOf('ultimosegundo') > -1 || IG_INFO.SITE_ID === '4e7b756c7a6504a01e0000af') { document.write(self.scripts.rti30018_useg); } /* minas gerais */if (IG_INFO.HOST.indexOf('minasgerais') > -1 || IG_INFO.SITE_ID === '51683ec081c77ab423000452') { document.write(self.scripts.rti30018_minas); } } }; /** * Agrupa chamadas a scripts que devem carregar no modo EDICAO */ScriptsSiteiG.prototype.baixarModeEdicao = function() { var self = this; document.write(self.scripts.jquery_ui_edicao); }; /** * Agrupar chamadas a scripts que devem carregar no modo PUBLICADO */ScriptsSiteiG.prototype.baixarModePublicado = function() { var self = this; document.write(self.scripts.jquery_ui_producao); self.baixar(); }; /** * Recupera informacoes relacionadas ao site e a secao das meta tags do header do template */var head = $('head'); var IG_INFO = { URL: window.location.href, SITE_ID: head.find('meta[name="iG-site-id"]').attr('content'), SECAO: head.find('meta[name="iG-secao-nome-normalizado"]').attr('content'), HOST: window.location.host }; /** * Identifica em qual modo a pagina se encontra */var PAGE_MODE = { EDICAO: null, PREVIEW: null, PUBLICADO: null }; if (IG_INFO.URL.indexOf('edicao.html') > -1) { PAGE_MODE.EDICAO = true; } else if (IG_INFO.URL.indexOf('preview') > -1) { PAGE_MODE.PREVIEW = true; } else { PAGE_MODE.PUBLICADO = true; } /** * Esconde a publicidade quando false */var showIgAd = PAGE_MODE.PUBLICADO; /** * Instancia o objeto que deve baixar scripts */var scriptsSiteiG = new ScriptsSiteiG(); /* roda scripts e faz alteracoes na pagina de acordo com o MODO de EDICAO (PREVIEW, EDICAO ou PUBLICACAO) */if (PAGE_MODE.EDICAO) { scriptsSiteiG.baixarModeEdicao(); $('body').addClass('mode-edicao'); } else { if (PAGE_MODE.PREVIEW) { $('body').addClass('mode-preview'); } scriptsSiteiG.baixarModePublicado(); } /* se for o saudebucal adiciona uma tag para rastrear o usuário */if (IG_INFO.URL.indexOf('saudebucal') > -1 && !PAGE_MODE.EDICAO) { $('head').append('<scr' + 'ipt type="text/javascript" src="//nexus.ensighten.com/colgatepalmolive/Bootstrap.js"></scr' + 'ipt>'); } /* Verifica se o canal é Esporte e cria a função que irá definir a publicidade da TV */function initTVPub(idPublicidade) { $('#' + idPublicidade).html(''); $('#' + idPublicidade).append('<iframe src="http://adserver.ig.com.br/RealMedia/ads/adstream_sx.ads/esporte.ig.com.br/homepage/' + Math.floor(Math.random() * 100000) + '@x01!x01" width="316" height="237" frameborder="0" marginheight="0" marginwidth="0" scrolling="no"></iframe><small>publicidade</small>'); }</script>

    <script type="text/javascript" src="http://js.statig.com.br/comments/comments-v1.js"></script>

    <script src="http://js.statig.com.br/dropfy/dropfy-1.0.3.js"></script>

    <link type="text/css" rel="stylesheet" href="http://i0.statig.com.br/comments/comments-v3.css" />

    <script src="http://i0.statig.com.br/x/galeria/js/galleria.js?v=11"></script>

   <meta name="keywords" content="casa,dicas,jardim,lâmpadas,limpeza,luminárias,piscina,piso,vidro,álcool,amônia,azulejos,brilho,truques,vinagre,alergia,bomba de água,mangueiras,microclima,repelir mosquitos,terraço,vantagens,varanda,acabamento,aquarela,brilhante,decoração,fosco,janelas,quadros,vidros,cores,móveis,sala,sofá multifunção,drenagem,economizar,plantas,vasos,cuidados,jardim de inverno,jardim interior,natureza,bambu,casas,casas modulares,construção,construção ecológica,estruturas,gradua,lar sustentável,materiais de construção,meio ambiente,painéis,crianças,flores,poupar tempo,regadeira automática,regar,economia,eletrodomésticos,lava louça,máquina de lavar louça,almofadas,cuidado,manutenção,móveis d evime,móveis de jardim,apliques de parede,chave teste,conselhos,eletricidade,fios,iluminação,potenciômetro,quarto dasc rianças,regulador,tomada,aço,barco,caracol,corrimãos,escadas,imperial,madeira,material,metal,modelos,segurança,apartamento de aluguel,idéias,luz natural,sofá,bustos,esculturas,estilo clássico,estilo eclético,figura de mármore,cômodidade,cortinas motorizadas,economia energética,fechamentos automatizados,janelas motorizadas,persianas motorizadas,toldos automáticos,almofadas coloridas,apartamento,candelabro,chill-out,cortinas,estilo retrô,poltrona,puf,sacada,tapete,baú,brinquedos,faixas decorativas,paredes,quarto de bebês,quarto de crianças, Comercial, Escritório, Grafiato,  Residência, Serviço, Textura, Condomínio, Profissional de Porta, Residencial, Preço, reformas, obras e reformas, construtores, orçamentos de reformas, orçamentos, obras, arquitetura, decoração de interiores, design de interiores, banheiros, cozinhas, arquitetos, decoradores de interior" />
    <meta name="robots" content="all" />
    
    
    
    
    
</asp:Content>
<asp:Content ID="cpObjetivoPrincipalPagina" ContentPlaceHolderID="cpObjetivoPrincipalPagina"
    runat="server">
    
    <div class="gallery posts" id="post-list">
   <h2 id="h2TituloTema" runat="server">
            </h2>
  
  <asp:Repeater ID="uxrptPosts" runat="server">
        
        <ItemTemplate>
            <article id="post-<%# Eval("Id")%>" class="post-7136 post type-post status-publish format-standard hentry category-manutencao-2 tag-almofadas tag-cuidado tag-dicas tag-limpeza tag-manutencao tag-moveis-d-evime tag-moveis-de-jardim tag-varanda gallery-item">

      <div class="gallery-item-image">
                  <a href="/PostBlogForm.aspx?idPost=<%# Eval("Id")%>">
                  <img width="301" height="335" src="/FotosPost/<%#Eval("FotoPrincipal")%>" 
                  class="attachment-post-thumbnail wp-post-image" alt="Orçamento Online - Obras,Reformas, Arquiteto,Decoração e Desgin de Interior"></a>
          <div class="controls controls-bottom">
           <a href="/PostBlogForm.aspx?idPost=<%# Eval("Id")%>" 
           class="btn btn-default pull-right top" rel="social-hub" data-wrapper="article" 
           data-url="/PostBlogForm.aspx?idPost=<%# Eval("Id")%>" 
           data-media="http://orcamentosgratis.net.br/<%#Eval("FotoPrincipal")%>"></a>
          </div>
        </div>
      <div class="gallery-item-description">         
          
          <h2>
            <a href="/PostBlogForm.aspx?idPost=<%# Eval("Id")%>" 
            title= '<%#Server.HtmlEncode(Eval("Titulo").ToString())%>' rel="bookmark" 
            style="float: none; position: static;"><%#Server.HtmlEncode(Eval("Titulo").ToString())%> 
            </a>
          </h2>
      </div>

    </article>
        </ItemTemplate>
       
    </asp:Repeater>  

  
   </div>
   
    <div class="productHeadingType1" itemscope itemtype = "http://schema.org/NewsArticle">
    
    
        <h1 runat="server" id="h1Titulo" itemprop="headline">
        </h1>
        <br />
        <br />
        <asp:Label ID="uxlblPost" runat="server"></asp:Label>
    </div>
    <div id="fb-root">
    </div>

    <script>        (function(d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/pt_BR/all.js#xfbml=1";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));</script>

    <asp:Literal ID="uxlblFacebook" runat="server"></asp:Literal>
</asp:Content>
