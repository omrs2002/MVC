using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCourse2017.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<MVCCourse2017.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<MVCCourse2017.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<MVCCourse2017.DTOs.NewRentalDto> NewRentalDtoes { get; set; }

        //public System.Data.Entity.DbSet<MVCCourse2017.Models.MovieDto> MovieDtoes { get; set; }

        //public System.Data.Entity.DbSet<MVCCourse2017.Models.GenreDto> GenreDtoes { get; set; }

        //public System.Data.Entity.DbSet<MVCCourse2017.Models.MovieDto> MovieDtoes { get; set; }

        //public System.Data.Entity.DbSet<MVCCourse2017.Models.GenreDto> GenreDtoes { get; set; }
    }

}