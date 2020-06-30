using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer.Core;
using EPiServer.Web.Hosting;

namespace DOC.Intranet.AlloyDemo
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            var startPath = "D:/Dev/DOC";
            var physicalPath = Environment.ExpandEnvironmentVariables(startPath);
            var info = new DirectoryInfo(physicalPath);
            var info2 = new DirectoryInfo(GenericHostingEnvironment.ApplicationPhysicalPath);
            if (info.FullName.StartsWith(info2.FullName, StringComparison.OrdinalIgnoreCase))
            {
                throw new EPiServerException(
                    "VirtualPathNativeProvider attribute 'physicalPath' must not refer to a path under the application path");
            }
            if (!info.Exists)
            {
                info.Create();
            }
            bool hasFileSystemRights;
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            sb.Append("Running account = ");
            sb.Append(principal.Identity.Name);
            sb.AppendLine("<br />");
            sb.AppendLine("<br />");
            FileSystemRights rights = 0;
            foreach (FileSystemAccessRule rule in info.GetAccessControl().GetAccessRules(true, true, typeof(NTAccount)))
            {
                try
                {
                    if (principal.IsInRole(rule.IdentityReference.Value))
                    {
                        if ((rule.AccessControlType == AccessControlType.Deny) &&
                            ((rule.FileSystemRights & FileSystemRights.Modify) != 0))
                        {
                            hasFileSystemRights = false;
                        }
                        if (rule.AccessControlType == AccessControlType.Allow)
                        {
                            rights |= rule.FileSystemRights;
                        }
                    }
                    sb.Append(rule.IdentityReference.Value);
                    sb.AppendLine("<br />");
                    sb.Append("OK");
                    sb.AppendLine("<br />");
                    sb.AppendLine("<br />");
                }
                catch (Exception ex)
                {
                    sb.Append(rule.IdentityReference.Value);
                    sb.AppendLine("<br />");
                    sb.Append(ex.Message);
                    sb.AppendLine("<br />");
                    sb.AppendLine("<br />");
                }
            }
            hasFileSystemRights = ((rights & FileSystemRights.Modify) == FileSystemRights.Modify);
            if (!hasFileSystemRights)
            {
                throw new EPiServerException(string.Format(
                    "VirtualPathNativeProvider must have modify rights to '{0}'", info.FullName));
            }
        }
    }
}