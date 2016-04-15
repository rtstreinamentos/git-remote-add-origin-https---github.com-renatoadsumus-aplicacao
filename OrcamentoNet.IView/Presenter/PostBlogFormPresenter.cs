using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
    public class PostBlogFormPresenter
    {
        public IPostBlogForm View { get; set; }

        [Inject]
        public IPostBlogService postBlogService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }


        public void CarregarPostBlog()
        {
            PostBlog post = postBlogService.Obter(View.IdPost);

            if (post != null)
            {                
                View.GerarFacebook(post);

                View.CarregarPostBlog(post);
                View.GerarHeaderPaginaHTML(post);               
                
            }
        }

        public void CarregarTodosPostsDoTema()
        {
            IList<PostBlog> posts = postBlogService.ObterPostsDeUmTema(View.IdTemaPost);
            View.CarregarTodosPostsDoTema(posts);
            View.GerarHeaderPaginaHTML();
        }
    }
}
