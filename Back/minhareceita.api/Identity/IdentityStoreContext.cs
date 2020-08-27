using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace minhareceita.data.Contexto
{
    public class IdentityStoreContext : IdentityDbContext<IdentityUser>
    {

        public IdentityStoreContext(DbContextOptions<IdentityStoreContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
        }


    }
}
