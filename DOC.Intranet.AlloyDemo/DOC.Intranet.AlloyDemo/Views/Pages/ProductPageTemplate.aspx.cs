using DOC.Intranet.Demo.Business;
using DOC.Intranet.Demo.Models.Pages;
using EPiServer.Web;

namespace DOC.Intranet.Demo.Views.Pages
{
    public partial class ProductPageTemplate : SiteTemplatePage<ProductPage>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            // List of unique selling points should have styling based on the current product's theme

            var productThemeCssClasses = string.Concat(string.Join(" ", CurrentPage.GetThemeCssClassNames()), " ", UniqueSellingPointsContainer.Attributes["class"]); // Append theme class to any existing CSS classes
            UniqueSellingPointsContainer.Attributes["class"] = productThemeCssClasses;
        }
    }
}
