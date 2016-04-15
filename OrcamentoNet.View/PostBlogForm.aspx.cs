using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

namespace OrcamentoNet.View
{
    public partial class PostBlogForm : System.Web.UI.Page, IPostBlogForm
    {
        PostBlogFormPresenter presenter;
        int idPost = 0;
        int idTemaPost = 27;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new PostBlogFormPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            NameValueCollection queryString = Request.QueryString;
            String[] array = queryString.AllKeys;

            if (!IsPostBack)
            {
                idTemaPost = (Request.QueryString["idTema"] != null) ? Convert.ToInt32(Request.QueryString["idTema"].ToString()) : 0;

                if (idTemaPost == 52)
                    h2TituloTema.InnerText = "Festas e Eventos";
                if (idTemaPost == 27)
                    h2TituloTema.InnerText = "Obras e Reformas";

                idPost = (Request.QueryString["idPost"] != null) ? Convert.ToInt32(Request.QueryString["idPost"].ToString()) : 0;

                if (idPost > 0)
                {
                    presenter.CarregarPostBlog();

                }
                else
                {
                    presenter.CarregarTodosPostsDoTema();
                }
            }
        }
        #region Propriedades
        public int IdPost
        {
            get { return idPost; }
        }

        public int IdTemaPost
        {
            get { return idTemaPost; }
        }
        #endregion

        #region Metodos
        public void GerarFacebook(PostBlog post)
        {
            string url = Common.UtilString.GerarUrlParaSeo(post.Titulo).Replace("!", "") + "-" + post.Id + ".aspx";

            uxlblFacebook.Text = "<div class='fb-like' data-href='http://orcamentosgratis.net.br/post-" + url + "' data-layout='standard'" +
                        " data-action='like' data-show-faces='true' data-share='true'>    </div>";
            HtmlMeta tag = new HtmlMeta();
            tag.Attributes.Add("property", "og:title");
            tag.Content = post.Titulo + " - Orçamentos Grátis!";
            Page.Header.Controls.Add(tag);
        }

        public void CarregarPostBlog(PostBlog postBlog)
        {
            h1Titulo.InnerText = postBlog.Titulo;
            uxlblPost.Text = postBlog.Conteudo;
        }

        public void GerarHeaderPaginaHTML(PostBlog post)
        {
            Page.Title = post.Titulo + " | Orçamento Online Grátis - " + post.Categoria.Nome;

            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = "Solicite orçamento online grátis de " + post.Categoria.Nome + ". Receba cotação de preços de " + post.Categoria.Nome + " de vários fornecedores. Prático, simples, eficaz e grátis! As melhores empresas e profissionais Rio de Janeiro, São Paulo, Curitiba, Salvador, Belo Horizonte e Distrito Federal.";
            Page.Header.Controls.Add(metaHtml);
        }

        public void GerarHeaderPaginaHTML()
        {
            Page.Title = "Festas Eventos, Obras e Reformas | Peça o seu Orçamento Online Grátis ";

            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = "Solicite orçamento online grátis de vários segmentos como: obras, reformas, pintor, pedreiro, festas e eventos, buffet, japonês, fotográfo. Receba cotação de preços de vários fornecedores. Prático, simples, eficaz e grátis! As melhores empresas e profissionais Rio de Janeiro, São Paulo, Curitiba, Salvador, Belo Horizonte e Distrito Federal.";
            Page.Header.Controls.Add(metaHtml);
        }

        public void CarregarTodosPostsDoTema(IList<PostBlog> posts)
        {
            uxrptPosts.DataSource = posts;
            uxrptPosts.DataBind();
        }

        #endregion
    }
}
