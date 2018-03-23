using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ContactsSms.Server.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ContactsSms.Server
{
    [HubName("MyHub")]
    public class MyHub : Hub
    {
        List<Sms> Messages = new List<Sms>()
        {
            new Sms{ ContactId=1, FromUser ="Mosh", ToUser= "Dan", Message="Hi", TimeStamp= DateTime.Now, Status="Received", ImageUrl = "http://lorempixel.com/100/100/people/1"},
            new Sms{ ContactId=2, FromUser ="John", ToUser= "Mosh", Message="Hi", TimeStamp= DateTime.Now, Status="Sent", ImageUrl = "http://lorempixel.com/100/100/people/5"},
            new Sms{ ContactId=1, FromUser ="Mosh", ToUser= "Dan", Message="Hi", TimeStamp= DateTime.Now, Status="Received", ImageUrl = "http://lorempixel.com/100/100/people/1"},
            new Sms{ ContactId=2, FromUser ="John", ToUser= "Mosh", Message="Hi", TimeStamp= DateTime.Now, Status="Sent", ImageUrl = "http://lorempixel.com/100/100/people/5"},
            new Sms{ ContactId=1, FromUser ="Mosh", ToUser= "Dan", Message="Hi", TimeStamp= DateTime.Now, Status="Received", ImageUrl = "http://lorempixel.com/100/100/people/1"}
        };



        public Sms AddNewMessage(String OutGoingText)
        {
            return new Sms
            {
                Message = OutGoingText,
               // TimeStamp = DateTime.Now

            };
                
        }

        public IEnumerable<SmsContactState> GetContacts(string param)
        {
            var Contacts = new List<SmsContactState>
            {
                new SmsContactState {ContactId=1, ContactName ="Mosh",ContactMobileNumber= 1277644890, ImageUrl = "http://lorempixel.com/100/100/people/6", LastMessageOn="Hi There" },
                new SmsContactState {ContactId=2, ContactName ="Dan", ContactMobileNumber= 1294890690, ImageUrl = "http://lorempixel.com/100/100/people/7", LastMessageOn="Hi" },
                new SmsContactState {ContactId=3, ContactName ="John", ContactMobileNumber= 1246777890, ImageUrl = "http://lorempixel.com/100/100/people/8", LastMessageOn="wats up!"  },
                new SmsContactState {ContactId=4, ContactName ="Shon", ContactMobileNumber= 1203456590, ImageUrl = "http://lorempixel.com/100/100/people/9", LastMessageOn="u thr?"  }

            };
            
             return Contacts;
        }

        public IEnumerable<Sms> GetMessages(string param)
        {
            
            return Messages;
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }

}