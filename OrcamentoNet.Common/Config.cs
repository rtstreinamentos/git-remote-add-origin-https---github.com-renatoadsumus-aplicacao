﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Common
{
    public class Config
    {
#if DEBUG
        public static string CaminhoFisico { get { return @"C:\Projeto\OrcamentoNet\trunk\OrcamentoNet.View\"; } }
        public static string ConexaoBanco { get { return @"Datasource=localhost;Database=orcamentos;uid=root;pwd=flamengo;Pooling=false;default command timeout=30;Connection Timeout=15;"; } }
        //public static string ConexaoBanco { get { return @"Datasource=mysql.rcmsolucoes.com;Database=rcmsolucoes07;uid=rcmsolucoes07;pwd=orcamento10"; } }

        //public static string UrlSite { get { return "http://localhost:53618/"; } }
        //public static string UrlSite { get { return "http://multicotacao.rcmsolucoes.com/"; } }
         public static string UrlSite { get { return "http://orcamentosgratis.net.br/"; } }

        public static int PausaTestesMilissegundos { get { return 4000; } }
#else

        public static string CaminhoFisico { get { return @"C:\inetpub\wwwroot\"; } }
        //public static string CaminhoFisico { get { return @"D:\\web\\localuser\\orcamentosgratis\\www\\"; } }
        //public static string CaminhoFisico { get { return @"C:\Projeto\OrcamentoNet\trunk\OrcamentoNet.View\"; } }
       // public static string CaminhoFisico { get { return "D:\\web\\localuser\\rcmsolucoes\\www\\multicotacao\\"; } }
        //public static string ConexaoBanco { get { return @"Datasource=mysql.rcmsolucoes.com;Database=rcmsolucoes07;uid=rcmsolucoes07;pwd=orcamento10"; } }
        //public static string ConexaoBanco { get { return @"Datasource=mysql.orcamentosgratis.net.br;Database=orcamentos;uid=orcamentos;pwd=orcamento10"; } }
        public static string ConexaoBanco { get { return @"Datasource=localhost;Database=orcamentos;uid=root;pwd=orcamento10"; } }

        public static string UrlSite { get { return "http://orcamentosgratis.net.br/"; } }
       
        public static int PausaTestesMilissegundos { get { return 2500; } }
#endif

        public static string ArquivoXmlCategorias { get { return Config.CaminhoFisico + "Categoria.xml"; } }
        public static string EmailAdministrador { get { return "orcamentos.net@gmail.com"; } }
        public static string EmailPostWordPress { get { return "OrcamentosNetBrWp2011@orcamentos.net.br"; } }
        public static string EmailPostBlog { get { return "BlogOrcamentosNetBr@orcamentos.net.br"; } }
        public static string EmailsNotificacao { get { return "orcamentos.net@gmail.com"; } }
        public static string NomeAplicacao { get { return "Orçamento Online"; } }
        public static string NomeArquivoAnexoTestes { get { return CaminhoFisico + @"templateEmail\RecuperarSenha.htm"; } }
        public static string NomeArquivoSiteMap { get { return CaminhoFisico + @"sitemapGeral.xml"; } }
        public static int QuantidadeDiasPeriodoCortesia { get { return 361; } }
        public static string SenhaPadrao { get { return "+uxqF25YKMQBAEfC0NI5n4e9tzuIl5MbWhcjTo0OD8E="; } }
        //public static string[,] ServidoresSmtp = { { "smtp.oficial.blog.br", "25", "webmaster@oficial.blog.br", "w3bm4st3r@" }
        //                                         , { "smtp.elasticemail.com", "2525", "webmaster@orcamentos.net.br", "d179ceab-f4f3-47ac-b32e-8ca0d53c3259" } 
        //, { "smtp.rcmsolucoes.com", "25", "renato@rcmsolucoes.com", "flamengo" } };
        public static string[,] ServidoresSmtp = { { "smtp.gmail.com", "587", "orcamentos.net@gmail.com", "plmokn21@!" }
        , { "smtp.elasticemail.com", "2525", "renatoadsumus@gmail.com", "6d2f07d2-f677-428b-8894-81d269aede1e" } };
        //public static string[,] ServidoresSmtp = { { "smtp.elasticemail.com", "2525", "renatoadsumus@gmail.com", "4fbec39a-A315-4b29-a2e7-6962e911ed58" }
        //                                          , { "smtp.elasticemail.com", "2525", "renatoadsumus@gmail.com", "4fbec39a-A315-4b29-a2e7-6962e911ed58" } };
        public static string TemplateEmailAutoResposta { get { return CaminhoFisico + @"templateEmail\AutoResposta.htm"; } }
        public static string TemplateInformativoFornecedoresAoComprador { get { return CaminhoFisico + @"templateEmail\InformativoFornecedoresAoComprador.htm"; } }
        public static string TemplateEmailConfirmandoPagamento { get { return CaminhoFisico + @"templateEmail\EmailConfirmacaoPagamento.htm"; } }
        public static string TemplateEmailCadastroAtivacao { get { return CaminhoFisico + @"templateEmail\CadastroAtivacao.htm"; } }
        public static string TemplateEmailCompraAvulsa { get { return CaminhoFisico + @"templateEmail\CompraAvulsa.htm"; } }
        public static string TemplateEmailRecuperarPagamentoNaoRealizado { get { return CaminhoFisico + @"templateEmail\RecuperarPagamentoNaoRealizado.htm"; } }
        public static string TemplateEmailRecuperarSenha { get { return CaminhoFisico + @"templateEmail\RecuperarSenha.htm"; } }
        public static string TemplateEmailSolicitacaoPagamento { get { return CaminhoFisico + @"templateEmail\SolicitacaoPagamento.htm"; } }
        public static string TemplateEmailFornecedorPromocaoCompraAvulsa { get { return CaminhoFisico + @"templateEmail\FornecedorPromocaoCompraAvulsa.htm"; } }
        public static string TemplateEmailEmailNaoValidado { get { return CaminhoFisico + @"templateEmail\CompradorEmailNaoValidado.htm"; } }
        public static string TemplateEmailInformativoFornecedorDeNovoPedidoOrcamento { get { return CaminhoFisico + @"templateEmail\InformativoFornecedorNovoPedido.htm"; } }
        public static string TemplateEmailInformativoFornecedorDegustacaoDeNovoPedidoOrcamento { get { return CaminhoFisico + @"templateEmail\InformativoFornecedorDegustacaoNovoPedido.htm"; } }
        public static string TemplateEmailInformativoFornecedorDegustacaoDeNovoPedidoOrcamentoPromocao { get { return CaminhoFisico + @"templateEmail\InformativoFornecedorDegustacaoNovoPedidoPromocao.htm"; } }
        public static string TemplateEmailInformativoDePedidos { get { return CaminhoFisico + @"templateEmail\InformativoDePedidosParaFornecedor.htm"; } }
        public static string TemplateEmailInformativoCompradorPedidoComprado { get { return CaminhoFisico + @"templateEmail\InformativoCompradorPedidoComprado.htm"; } }
        public static string TemplateEmailInformativoFornecedorStatusPedido { get { return CaminhoFisico + @"templateEmail\InformativoFornecedorStatusPedido.htm"; } }
        public static string TemplateEmailInformativoNovosFornecedores { get { return CaminhoFisico + @"templateEmail\InformativoNovosFornecedores.htm"; } }
        public static string TemplateEmailLembreteVencimentoFornecedor { get { return CaminhoFisico + @"templateEmail\LembreteVencimentoFornecedor.htm"; } }
        public static string TemplateEmailNovoPedidoOrcamentoSimplificado { get { return CaminhoFisico + @"templateEmail\NovoPedidoOrcamentoSimplificado.htm"; } }
        public static string TemplateCobrarExplicacaoFornecedorPedidoNaoRespondido { get { return CaminhoFisico + @"templateEmail\CobrarExplicacaoFornecedorPedidoNaoRespondido.htm"; } }
        public static string TemplateEmailMalaDireta { get { return CaminhoFisico + @"templateEmail\MalaDireta.htm"; } }
        public static string TemplateEmailPedidoOrcamentoIncompleto { get { return CaminhoFisico + @"templateEmail\PedidoOrcamentoIncompleto.htm"; } }
        public static string TemplateEmailPagamentoFornecedorNaoIdentificado { get { return CaminhoFisico + @"templateEmail\PagamentoFornecedorNaoIdentificado.htm"; } }
        public static string TemplateEmailPedidoOrcamentoParaWordPress { get { return CaminhoFisico + @"templateEmail\PedidoOrcamentoWordPress.htm"; } }
        public static string TemplateEmailPesquisaNaoPagamentoFornecedor { get { return CaminhoFisico + @"templateEmail\PesquisaNaoPagamentoFornecedor.htm"; } }
        public static string TemplateEmailPesquisaSatisfacaoComprador { get { return CaminhoFisico + @"templateEmail\PesquisaSatisfacaoComprador.htm"; } }
        public static string TemplateEmailPesquisaSatisfacaoPreenchidaPorComprador { get { return CaminhoFisico + @"templateEmail\PesquisaSatisfacaoPreenchidaPorComprador.htm"; } }
        public static string TemplateEmailPesquisaSatisfacaoFornecedor { get { return CaminhoFisico + @"templateEmail\PesquisaSatisfacaoFornecedor.htm"; } }
        public static string TemplateEmailRecuperarCliente { get { return CaminhoFisico + @"templateEmail\RecuperarCliente.htm"; } }
        public static string TemplateEmailPesquisaOpiniaoFornecedorAtivo { get { return CaminhoFisico + @"templateEmail\PesquisaOpiniaoFornecedorAtivo.htm"; } }
        public static string TemplateUltimosPedidosDegustacao { get { return CaminhoFisico + @"templateEmail\UltimosPedidosDegustacao.htm"; } }
        public static string TemplatePedidoOrcamentoSemFornecedor { get { return CaminhoFisico + @"templateEmail\PedidoOrcamentoSemFornecedor.htm"; } }
        public static string UrlFormularioGenerico { get { return "orcamento-online.aspx#listaOrcamentos"; } }
        public static string UrlFormularioBoloDeFesta { get { return "orcamento-online-Bolo-Festa-130.aspx"; } }
        public static string UrlFormularioBoxVidrosEspelhos { get { return "orcamento-online-box-vidros-espelhos-19.aspx"; } }
        public static string UrlFormularioBuffet { get { return "orcamento-online-buffet-123.aspx"; } }
        public static string UrlFormularioBuffetInfantil { get { return "orcamento-online-Buffet-Infantil-171.aspx"; } }
        public static string UrlFormularioBuffetJapones { get { return "orcamento-online-buffet-japones-54.aspx"; } }
        public static string UrlFormularioCasamento { get { return "orcamento-online-festa-casamento-52.aspx"; } }
        public static string UrlFormularioCFTV { get { return "orcamento-online-circuito-fechado-televisao-CFTV-169.aspx"; } }
        public static string UrlFormularioDocesChocolatesSalgados { get { return "orcamento-online-doces-chocolates-salgados-56.aspx"; } }
        public static string UrlFormularioFesta15anos { get { return "orcamento-online-festa-15-anos-52.aspx"; } }
        public static string UrlFormularioMesasCadeirasToalhas { get { return "orcamento-online-Mesas-Cadeiras-Toalhas-143.aspx"; } }
        public static string UrlFormularioMudancas { get { return "orcamento-online-Mudancas-112.aspx"; } }
        public static string UrlFormularioObrasReformasConstrucao { get { return "orcamento-online-obras-reformas-construcao-pintura-27.aspx"; } }
        public static string UrlFormularioPinturaLimpezaFachadasPrediais { get { return "orcamento-online-reforma-fachada-predio-182.aspx"; } }
        public static string UrlFormularioPinturaPintor { get { return "orcamento-online-pintura-pintor-40.aspx"; } }
        public static string UrlHomeOrcamentos { get { return "orcamento-online.aspx"; } }

    }
}
