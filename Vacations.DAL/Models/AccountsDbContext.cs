using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vacations.DAL.Models
{
    public class AccountsDbContext : IdentityDbContext<User>
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Team>();
        }
    }
}
