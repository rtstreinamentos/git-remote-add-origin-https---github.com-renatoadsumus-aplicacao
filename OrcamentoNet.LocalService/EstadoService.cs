using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.LocalService
{
    public class EstadoService : IEstadoService
    {
        public Estado ObterEstado(int idEstado)
        {
            Estado estado = new Estado();
            estado.Id = idEstado;

            if (idEstado == 5)
            {
                estado.Nome = "Bahia - BA";
                estado.Url = "-bahia-ba";
                estado.Uf = UF.BA;                
            }

            if (idEstado == 7)
            {
                estado.Nome = "Brasília - DF";
                estado.Url = "-brasilia-df";
                estado.Uf = UF.DF;
            }

            if (idEstado == 13)
            {
                estado.Nome = "Minas Gerais - MG";
                estado.Url = "-minas-gerais-mg";
                estado.Uf = UF.MG;
            }

            if (idEstado == 16)
            {
                estado.Nome = "Paraná - PR";
                estado.Url = "-parana-pr";
                estado.Uf = UF.PR;
            }

            if (idEstado == 17)
            {
                estado.Nome = "Pernambuco - PE";
                estado.Url = "-pernambuco-pe";
                estado.Uf = UF.PE;
            }

            if (idEstado == 19)
            {
                estado.Nome = "Rio de Janeiro - RJ";
                estado.Url = "-rio-de-janeiro-rj";
                estado.Uf = UF.RJ;
            }

            if (idEstado == 25)
            {
                estado.Nome = "São Paulo - SP";
                estado.Url = "-sao-paulo-sp";
                estado.Uf = UF.SP;
            }
            return estado;
        }

        public IList<string> ObterEstados()
        {
            IList<string> estados = new List<string>();
            estados.Add("Selecione");

            foreach (string estado in Enum.GetNames(typeof(UF)))
            {
                UF uf = (UF)Enum.Parse(typeof(UF), estado);
                estados.Add(estado);
            }
            return estados;
        }
    }
}
