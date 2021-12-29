using LexiconMVCData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconMVCData.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Sverige"});
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Norge" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Danmark" });

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Göteborg", CountryId = 1});
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Malmö", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Stockholm", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 4, Name = "Oslo", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 5, Name = "Bergen", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 6, Name = "Trondheim", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 7, Name = "Köpenhamn", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { Id = 8, Name = "Ålborg", CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { Id = 9, Name = "Helsingör", CountryId = 3 });

            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Adam Adamsson", PhoneNumber = "031-123456", CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 2, Name = "Bertil Bertilsson", PhoneNumber = "031-123456", CityId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 3, Name = "Carl Carlsson", PhoneNumber = "031-123456", CityId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 4, Name = "Dan Danielsson", PhoneNumber = "031-123456", CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 5, Name = "Erik Eriksson", PhoneNumber = "031-123456", CityId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 6, Name = "Frans Fransson", PhoneNumber = "031-123456", CityId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 7, Name = "Gustav Gustavsson", PhoneNumber = "031-123456", CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 8, Name = "Henrik Henriksson", PhoneNumber = "031-123456", CityId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 9, Name = "Ivar Ivarsson", PhoneNumber = "031-123456", CityId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 10, Name = "Jan Jansson", PhoneNumber = "031-123456", CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 11, Name = "Karl Karlsson", PhoneNumber = "031-123456", CityId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 12, Name = "Lars Larsson", PhoneNumber = "031-123456", CityId = 3 });

            modelBuilder.Entity<Person>().HasData(new Person { Id = 13, Name = "Ole Bramserud", PhoneNumber = "031-123456", CityId = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 14, Name = "Petter Northug", PhoneNumber = "031-123456", CityId = 5 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 15, Name = "Theres Johaug", PhoneNumber = "031-123456", CityId = 6 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 16, Name = "Gunn-Rita Dahle Flesjå", PhoneNumber = "031-123456", CityId = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 17, Name = "Fleksnes", PhoneNumber = "031-123456", CityId = 5 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 18, Name = "Max manus", PhoneNumber = "031-123456", CityId = 6 });

            modelBuilder.Entity<Person>().HasData(new Person { Id = 19, Name = "Nikolaj Coster-Waldau", PhoneNumber = "031-123456", CityId = 7 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 20, Name = "Iben Hjejle", PhoneNumber = "031-123456", CityId = 8 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 21, Name = "Mads Mikkelsen", PhoneNumber = "031-123456", CityId = 9 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 22, Name = "Kristian Tyrann", PhoneNumber = "031-123456", CityId = 7 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 23, Name = "Kim Larsen", PhoneNumber = "031-123456", CityId = 8 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 24, Name = "Tycho Brahe", PhoneNumber = "031-123456", CityId = 9 });

            modelBuilder.Entity<Language>().HasData(new Language { Id = 1, Name = "Svenska"});
            modelBuilder.Entity<Language>().HasData(new Language { Id = 2, Name = "Norska" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 3, Name = "Danska" });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 1, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 2, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 3, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 3, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 4, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 5, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 6, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 7, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 7, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 8, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 9, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 11, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 12, LanguageId = 1 });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 13, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 14, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 14, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 15, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 16, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 17, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 17, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 18, LanguageId = 2 });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 19, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 20, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 21, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 21, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 22, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 23, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 23, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 24, LanguageId = 3 });

            string roleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Super Admin",
                NormalizedName = "SUPER ADMIN"

            });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "superadmin@mail.com",
                NormalizedEmail = "SUPERADMIN@MAIL.COM",
                UserName = "superadmin@mail.com",
                NormalizedUserName = "SUPERADMIN@MAIL.COM",
                PasswordHash = hasher.HashPassword(null, "password"),
                FirstName = "Super",
                LastName = "Admin"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

        }

    }
}
