using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePageView.Models
{
    public class Sms : ObservableObject
    {
        string fromUser;
        public string FromUser
        { get { return fromUser; }
          set { SetProperty(ref fromUser, value); }
        }
        string toUser;
        public string ToUser
        {
            get { return toUser; }
            set { SetProperty(ref toUser, value); }
        }

        string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        
        public bool HasAttachement => !string.IsNullOrEmpty(imageUrl);
        string imageUrl;
        public string ImageUrl
        {
            get { return imageUrl; }
            set { SetProperty(ref imageUrl, value); }
        }

        DateTime timeStamp;
        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { SetProperty(ref timeStamp, value); }
        }

        string status;
        public string Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        public int ContactId { get; set; }
        public virtual SmsContactState SmsContactState { get; set; }

    }
  
}
