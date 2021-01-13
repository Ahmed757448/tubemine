using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TubeMine2021.Models;

[assembly: OwinStartupAttribute(typeof(TubeMine2021.Startup))]
namespace TubeMine2021
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();

        }

        public void CreateDefaultRolesAndUsers()
        {
            var rolemange = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!rolemange.RoleExists("Admins"))
            {
                role.Name = "Admins";
                rolemange.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "shnider";
                user.Email = "ahmed.shnider38@gmail.com";
                var check = usermanger.Create(user, "123ASDasd@");
                if (check.Succeeded)
                {
                    usermanger.AddToRole(user.Id, "Admins");
                }
            }
        }
    }
}
