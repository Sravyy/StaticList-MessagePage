using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePageView.Models
{
    public class SmsContactState
    {
        public string ContactName { get; set; }
        public int ContactMobileNumber { get; set; }
        public string LastMessageOn { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Sms> Messages { get; set; }

        //public string Name { get; set; }
        //public string ImageUrl { get; set; }
        //public string Status { get; set; }
    }
}
