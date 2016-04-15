using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.ILocalService
{
    public interface IPostBlogService
    {
        PostBlog Obter(int idPostBlog);
        IList<PostBlog> ObterPostsDeUmTema(int idTema);
    }
}
