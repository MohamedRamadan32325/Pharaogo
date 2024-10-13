using DEPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class DepiContext : IdentityDbContext<ApplicationUser>
    {

        public DepiContext() : base()
        {

        }
        public DepiContext(DbContextOptions options) : base(options)
        { }

			public DbSet<User> User { get; set; }
		    public DbSet<Admin> Admin { get; set; }
            public DbSet<Booking> Booking { get; set; }
            public DbSet<Membership> Memberships { get; set; }
            public DbSet<Place> Places { get; set; }
            public DbSet<Payment> Payment { get; set; }
            public DbSet<Promotion> Promotions { get; set; }
            public DbSet<Review> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.;Database=Depi;Trusted_Connection=True;Encrypt=False;");
            //base.OnConfiguring(optionsBuilder);
        }

    }
}

