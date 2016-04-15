rem RODE ESTE PROGRAMA A PARTIR DA PASTA RAIZ ONDE ESTAO OS ARQUIVOS DO DEPLOY
pause

rd AdminicaTemplate /s /q 
rd images /s /q
rd css /s /q
rd js /s /q

cd bin
del AjaxControlToolkit.dll /q
del Castle.Core.dll /q
del Castle.DynamicProxy2.dll /q
del CookComputing.XmlRpcV2.dll /q
del Iesi.Collections.dll /q
del InfoGlobo.InjectionFramework.Core.dll /q
del log4net.dll /q
del MySql.Data.dll /q
del NHibernate.Burrow.dll /q
del NHibernate.Burrow.WebUtil.dll /q
del NHibernate.ByteCode.Castle.dll /q
del NHibernate.dll /q
del NHibernate.Linq.dll /q
del Owasp.Esapi.dll /q
del PerceptiveMCAPI.dll /q
del PortalEscolar.Data.dll /q
del System.Web.DataVisualization.dll /q
del *.pdb /q
cd..

del web.config
ren webprd.config web.config

del AdminCadastroFornecedor.aspx