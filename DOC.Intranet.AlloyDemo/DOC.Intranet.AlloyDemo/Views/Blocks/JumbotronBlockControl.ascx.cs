using System;
using EPiServer.Framework.DataAnnotations;
using DOC.Intranet.Demo.Models.Blocks;
using EPiServer.Web;

namespace DOC.Intranet.Demo.Views.Blocks
{
    [TemplateDescriptor(
        AvailableWithoutTag = false,
        Tags = new [] { Global.ContentAreaTags.FullWidth })] // Only allowed in full-width content areas
    public partial class JumbotronBlockControl : SiteBlockControlBase<JumbotronBlock>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            jumboLink.DataBind();

            // In on-page edit mode, clicking the link button should allow editor to edit the link button text
            jumboLink.ApplyEditAttributes<JumbotronBlock>(b => b.ButtonText);
        }
    }
}
