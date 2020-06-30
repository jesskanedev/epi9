using System;
using System.Collections.Generic;
using EPiServer.Web;

namespace DOC.Intranet.Demo.Views.Properties
{
    public partial class StringsCollection : PropertyControlBase<IEnumerable<string>>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentData != null)
            {
                list.DataSource = CurrentData;
                list.DataBind();
            }
        }
    }
}
