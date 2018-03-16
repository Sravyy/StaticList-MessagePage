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
                new SmsContactState {ContactName ="Mosh", ContactMobileNumber= 1134230342, LastMessageOn="Hello"},
                new SmsContactState {ContactName ="Bob", ContactMobileNumber= 1134230542, LastMessageOn="Hi"},
                new SmsContactState {ContactName ="Dan", ContactMobileNumber= 1134232342, LastMessageOn="Whatup"},
                new SmsContactState {ContactName ="Jhon", ContactMobileNumber= 1134209762, LastMessageOn="Hey"}

            };

            return Contacts;

        }

        public List<Sms> GetMessages()
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