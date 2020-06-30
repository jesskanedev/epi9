using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using DOC.Intranet.Demo.Models.Blocks;
using EPiServer.Web;

namespace DOC.Intranet.Demo.Views.Blocks
{
    [TemplateDescriptor(Inherited = true, TemplateTypeCategory = TemplateTypeCategories.UserControl)]
    public partial class ButtonBlockControl : SiteBlockControlBase<ButtonBlock>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            // Make button text editable in on-page edit mode
            ButtonLink.ApplyEditAttributes<ButtonBlock>(b => b.ButtonText);

            DataBind();
        }
    }
}
