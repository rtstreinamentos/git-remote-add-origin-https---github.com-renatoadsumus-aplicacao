using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class Categoria
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Termo { get; set; }
        public virtual IList<Termo> Termos { get; set; }
        public virtual string Url
        {
            get
            {
                return "orcamento-online-" + Common.UtilString.GerarUrlParaSeo(Nome) + "-" + Id.ToString() + ".aspx";
            }
        }
        public virtual string UrlPreco
        {
            get
            {
                return "orcamento-preco-" + Common.UtilString.GerarUrlParaSeo(Nome) + "-" + Id.ToString() + ".aspx";
            }
        }
        public virtual string UrlSEO
        {
            get
            {
                return Common.UtilString.GerarUrlParaSeo(Nome) + "-" + Id.ToString() + ".aspx";
            }
        }
        public virtual string ToolTip
        {
            get { return "Receba Orçamentos Grátis de Várias Empresas de " + Nome; }
        }
        public virtual string UrlFornecedores
        {
            get
            {
                return "cadastro-empresa-" + Common.UtilString.GerarUrlParaSeo(Nome) + "-" + Id.ToString() + ".aspx";
            }
        }
        public virtual string UrlTitle { get; set; }
        public virtual string UrlMappings { get; set; }
        public virtual Categoria Pai { get; set; }
        public virtual Boolean Ativo { get; set; }
        public virtual IList<Categoria> SubCategorias { get; set; }
        public virtual IList<LinkInterno> LinksInternos { get; set; }
        public virtual double Valor { get; set; }
        public virtual string DetalheExplicativo { get; set; }

    }
}
