using System.Configuration.Provider;
using System.Web.Security;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace DOC.Intranet.Demo
{
    [InitializableModule]
    public class CreateAdminUserAndRoles : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
#if DEBUG
            var mu = Membership.GetUser("EpiAdmin");

            if (mu != null) return;

            try
            {
                Membership.CreateUser("EpiAdmin", "Password1", "EpiAdmin@site.com");

                try
                {
                    this.EnsureRoleExists("WebEditors");
                    this.EnsureRoleExists("WebAdmins");

                    Roles.AddUserToRoles("EpiAdmin", new[] { "WebAdmins", "WebEditors" });
                }
                catch (ProviderException pe)
                {

                }
            }
            catch (MembershipCreateUserException mcue)
            {

            }
#endif
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        private void EnsureRoleExists(string roleName)
        {
            if (Roles.RoleExists(roleName)) return;

            try
            {
                Roles.CreateRole(roleName);
            }
            catch (ProviderException pe)
            {

            }
        }
    }
}