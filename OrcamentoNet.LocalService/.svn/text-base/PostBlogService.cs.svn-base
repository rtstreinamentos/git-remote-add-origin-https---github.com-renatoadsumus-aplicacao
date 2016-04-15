using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;

namespace OrcamentoNet.LocalService
{
    public class PostBlogService : IPostBlogService
    {
        private IDataContext context;

        public PostBlogService(IDataContext contextData)
        {
            context = contextData;
        }

        public PostBlog Obter(int idPostBlog)
        {
            PostBlog postBlog = context.Repository<PostBlog>().Where(x => x.Id == idPostBlog).FirstOrDefault();

            return postBlog;
        }

        public IList<PostBlog> ObterPostsDeUmTema(int idTema)
        {
            IList<PostBlog> postsTema = context.Repository<PostBlog>().Where(x => x.Categoria.Pai.Id == idTema).ToList();

            return postsTema;
        }
        
    }
}
