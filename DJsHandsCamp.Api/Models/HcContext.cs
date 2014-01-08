using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DJsHandsCamp.Api.Models
{
    public class HcContext : DbContext
    {
        public DbSet<HcMember> HcMembers { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
    }
}