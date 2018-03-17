using System;
using System.Collections.Generic;
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

        public IEnumerable<SmsContactState> GetContacts(string param)
        {
            var Contacts = new List<SmsContactState>
            {
                new SmsContactState {ContactName ="Mosh kjggg",ContactMobileNumber= 1234567890, LastMessageOn="Hi There" },
                new SmsContactState {ContactName ="Milly", ContactMobileNumber= 1234567890, LastMessageOn="Hi" },
                new SmsContactState {ContactName ="John", ContactMobileNumber= 1234567890, LastMessageOn="wats up!"  },
                new SmsContactState {ContactName ="Shon", ContactMobileNumber= 1234567890, LastMessageOn="u thr?"  }

            };

            return Contacts;

        }

        public IEnumerable<Sms> GetMessages(string param)
        {
            List<Sms> Messages = new List<Sms>()
            {
                new Sms{ FromUser ="Mosh", ToUser= "Dan", Message="Hi", TimeStamp= DateTime.Now, Status="Received", ImageUrl = "http://lorempixel.com/100/100/people/1"},
                new Sms{ FromUser ="Dan", ToUser= "Mosh", Message="Hi", TimeStamp= DateTime.Now, Status="Sent", ImageUrl = "http://lorempixel.com/100/100/people/5"},
                new Sms{ FromUser ="Mosh", ToUser= "Dan", Message="Hi", TimeStamp= DateTime.Now, Status="Received", ImageUrl = "http://lorempixel.com/100/100/people/5"},
                new Sms{ FromUser ="Dan", ToUser= "Mosh", Message="Hi", TimeStamp= DateTime.Now, Status="Sent", ImageUrl = "http://lorempixel.com/100/100/people/1"},
                new Sms{ FromUser ="Mosh", ToUser= "Dan", Message="Hi", TimeStamp= DateTime.Now, Status="Received", ImageUrl = "http://lorempixel.com/100/100/people/5"}
            };
            return Messages;
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }

}