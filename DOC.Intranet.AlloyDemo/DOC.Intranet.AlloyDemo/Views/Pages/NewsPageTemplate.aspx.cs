using System;
using EPiServer.Core;
using DOC.Intranet.Demo.Models.Pages;

namespace DOC.Intranet.Demo.Views.Pages
{
    public partial class NewsPageTemplate : SiteTemplatePage<NewsPage>
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            NoListRootMessage.DataBind();
        }
    }
}
