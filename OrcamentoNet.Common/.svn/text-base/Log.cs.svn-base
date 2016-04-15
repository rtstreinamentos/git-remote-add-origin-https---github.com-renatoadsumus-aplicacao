using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Common
{
    public static class Log
    {
        public static void GravarLog(string mensagem)
        {
            log4net.Config.XmlConfigurator.Configure();

            log4net.ILog logger;

            logger = log4net.LogManager.GetLogger("LogInFile");

            //logger.Debug("Log no nivel de debug");

            //logger.Info("Log no nivel de info");

            logger.Error(mensagem);

            //logger.Warn("Log no nivel de warning");
        }
    }
}
