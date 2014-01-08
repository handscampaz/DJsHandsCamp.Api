using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DJsHandsCamp.Api.Models
{
    public class HcMember
    {
        public int HcMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HcMemberCategory { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        

        public virtual ICollection<ContactForm> ContactForm { get; set; }
    }
}
