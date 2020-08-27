using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace minhareceita.data.Contexto
{
    public class IdentityAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            IdentityRole adminRole = new IdentityRole("Admin");
            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "tomjbg",
                Email = "tgds.net@outlook.com.br",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            byte[] salt = new byte[128 / 2];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var keyBytes = KeyDerivation.Pbkdf2(
                password: "A1d2m3n4@#2020",
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                );

            string hashed = Convert.ToBase64String(keyBytes);
            admin.PasswordHash = hashed;

            modelBuilder.Entity<IdentityRole>().HasData(adminRole);
            modelBuilder.Entity<ApplicationUser>().HasData(admin);


            base.OnModelCreating(modelBuilder);
        }
    }
}
