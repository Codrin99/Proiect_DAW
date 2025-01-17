﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Proiect.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new Initp());
        }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Recenzie> Recenzie { get; set; }
        public DbSet<Magazin> Magazin { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<AdresaFactura> AdresaFactura { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
    public class Initp : DropCreateDatabaseAlways<ApplicationDbContext>
    { // custom initializer
        protected override void Seed(ApplicationDbContext ctx)
        {
            ctx.Produs.Add(new Produs { Denumire = "Figider Arctic A++", Pret = "950"  });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}