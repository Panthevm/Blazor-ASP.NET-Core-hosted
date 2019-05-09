using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Dekanat.Server.Models;

namespace Dekanat.Server.Data {
    public class ApplicationContext : IdentityDbContext<User> {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
