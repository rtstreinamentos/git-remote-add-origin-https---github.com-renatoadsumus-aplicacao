using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace OrcamentoNet.Common
{
    /// <summary>
    /// Classe de manipulação de erros da aplicação
    /// </summary>
    public static class Erro
    {
        public static log4net.ILog Log4Net { get; set; }

        public static void Logar(Exception e) {
            log4net.Config.XmlConfigurator.Configure();
            Log4Net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string erroInterno = string.Empty;
            if (e.InnerException != null)
            {
                erroInterno = e.InnerException.ToString();
            }

            Log4Net.Error(e.Message +
                           " - Detalhamento: " + erroInterno +
                           " - Origem: " + e.Source +
                           " - Pilha: " + e.StackTrace);
        }
    }
}
