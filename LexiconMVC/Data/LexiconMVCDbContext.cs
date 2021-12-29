using LexiconMVCData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Data
{
    public class LexiconMVCDbContext : IdentityDbContext<ApplicationUser>
    {
        public LexiconMVCDbContext(DbContextOptions<LexiconMVCDbContext> options) : base (options)
        {

        }
        
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>().HasKey(p => new { p.PersonId, p.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);


            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(pl => pl.Language)
                .WithMany(l => l.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageId);

            modelBuilder.Seed();
        }
    }
}
