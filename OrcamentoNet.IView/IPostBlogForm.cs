using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IPostBlogForm
    {
        int IdPost { get; }
        int IdTemaPost { get; }
        void CarregarPostBlog(PostBlog postBlog);
        
        void GerarHeaderPaginaHTML(PostBlog post);

        void GerarFacebook(PostBlog post);

        void CarregarTodosPostsDoTema(IList<PostBlog> posts);

        void GerarHeaderPaginaHTML();
    }
}
