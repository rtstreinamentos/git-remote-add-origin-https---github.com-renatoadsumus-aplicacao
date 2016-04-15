using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using NUnit.Framework;
using NHibernate.Burrow;

namespace OrcamentoNet.LocalServiceTest
{
    public class FotoServiceTest
    {
        private StandardKernel injectionService;

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IFotoService fotoService { get; set; }

        Fornecedor fornecedorRJ;
        Categoria categoria;

        public void Inicializar()
        {
            injectionService = new StandardKernel(new CustomModule());
            injectionService.Inject(this);
        }

        [SetUp]
        public void Setup()
        {
            //Preparando Base de Dados
            BaseDados.BaseDados baseDados = new BaseDados.BaseDados();
            baseDados.ExcluirDados();
            Inicializar();
            PrepararTest();
        }

        [TearDown]
        public void TearDown()
        {
            new BurrowFramework().CloseWorkSpace();
        }

        [Test]
        public void IncluirFoto()
        {
            Foto foto = new Foto();
            foto.Caminho="001.jpg";
            foto.Nome="Foto 01";
            foto.Titulo="Foto 01";
            foto.Fornecedor = this.fornecedorRJ;

            fotoService.Inserir(foto);
        }

        private void PrepararTest()
        {
            List<int> cidades = new List<int>();
            cidades.Add(6005);

            List<int> categorias = new List<int>();
            categorias.Add(54);

            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            this.fornecedorRJ = baseFornecedor.IncluirFornecedorValido(cidades, "renato@rcmsolucoes.com", categorias);          

        }
    }
}
