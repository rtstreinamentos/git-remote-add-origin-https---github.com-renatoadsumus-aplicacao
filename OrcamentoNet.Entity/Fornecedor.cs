using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class Fornecedor
    {
        public virtual string MensagemAutoResposta { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int Desconto { get; set; }
        public virtual string Email { get; set; }
        public virtual string EmailSecundario { get; set; }
        public virtual int Id { get; set; }
        public virtual PessoaTipo TipoPessoaAtendimento { get; set; }
        public virtual PessoaTipo TipoPessoaAtendimentoAlteracao { get; set; }
        public virtual string Indicacao { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string WebSite { get; set; }
        public virtual string Senha { get; set; }
        public virtual int Parcelas { get; set; }
        public virtual Status Status { get; set; }
        public virtual double ValorMensalidade { get; set; }
        public virtual double ValorMensalidadeAlteracao { get; set; }
        public virtual string ValorAvulso
        {
            get
            {
                string valorAvulso = "";

                if (ValorMensalidade < 29)
                {
                    valorAvulso = "4,90";
                }
                else
                {
                    valorAvulso = String.Format("{0:#0.00}", (ValorMensalidade / 10) + 1).Replace(".", ",");
                }

                return valorAvulso;
            }

        }
        public virtual IList<Opiniao> Opinioes { get; set; }
        public virtual IList<Foto> Fotos { get; set; }
        public virtual IList<Cidade> Cidades { get; set; }
        public virtual IList<Categoria> SubCategorias { get; set; }
        public virtual IList<Termo> Termos { get; set; }
        public virtual IList<Atributo> Atributos { get; set; }
        public virtual IList<CategoriaPrioridade> CategoriasPrioridade { get; set; }
        public virtual string UrlFichaTecnica
        {
            get
            {
                return Config.UrlSite + "fornecedor-" + Common.UtilString.GerarUrlParaSeo(Nome) + "-" + Id.ToString() + ".aspx";
            }
        }
        public virtual Boolean EnviadoPorUltimo { get; set; }
    }
}
