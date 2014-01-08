using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJsHandsCamp.Api.Models
{
    public class ContactForm
    {
        public int ContactFormId { get; set; }
        public int HcMemberId { get; set; }
        public string Comment { get; set; }

        public virtual HcMember HcMember { get; set; }
    }
}