using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePageView
{
    public class Sms
    {
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Status { get; set; }

       
    }

    
}
