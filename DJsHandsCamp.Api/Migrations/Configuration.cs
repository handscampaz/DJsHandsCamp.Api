using System.Collections.Generic;
using System.Collections.ObjectModel;
using DJsHandsCamp.Api.Models;
using Microsoft.Ajax.Utilities;

namespace DJsHandsCamp.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HcContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var hcmembers = new List<HcMember>
            {
                new HcMember
                {
                    FirstName = "Jayden",
                    LastName = "Hackett",
                    Email = "jayden@mail.com",
                    HcMemberCategory = "Student",
                    PhoneNumber = "555-555-5555",
                    ContactForm = new List<ContactForm> {new ContactForm {Comment = "This is a test comment"}}
                }
            };
            hcmembers.ForEach(c => context.HcMembers.AddOrUpdate(m => m.FirstName, c));
            context.SaveChanges();
        }
    }
}
