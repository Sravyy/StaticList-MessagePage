﻿using MessagePageView.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MessagePageView.Services
{
    public class SignalRClient : INotifyPropertyChanged
    {
        public HubConnection _hub;
        public IHubProxy _smsHubProxy;

        public HubConnection Hub { get { return _hub; } }

        private SignalRClient()
        {
            Debug.WriteLine("SignalR Initialized...");
            InitializeSignalR().ContinueWith(task =>
            {
                Debug.WriteLine("SignalR Started...");
            });
        }
    //create SignalR singleton instance
        private static SignalRClient instance;

        public static SignalRClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SignalRClient();
                }
                return instance;
            }
        }

        public async Task InitializeSignalR()
        {
            _hub = new HubConnection("http://a473a9ab.ngrok.io");
            _smsHubProxy = _hub.CreateHubProxy("MyHub");

            _hub.StateChanged += state =>
            {
                Console.WriteLine("Connection State Changed From {0} To {1}", state.OldState, state.NewState);
                if (state.NewState == ConnectionState.Disconnected)
                {
                    Console.WriteLine("Reconnecting in 500 ms");
                    Thread.Sleep(500);
                    _hub.Start();
                }
            };

            _hub.Error += E => Console.WriteLine(E.Message);

            _hub.TraceLevel = TraceLevels.All;
            _hub.TraceWriter = Console.Out;


            //_smsHubProxy.On<Sms>("Add", sms => GetMessages());

            await _hub.Start();
        }


        public Sms AddNewMessage(string message)
        {
            while (_hub.State != ConnectionState.Connected) Thread.Sleep(500);
            var Task=  _smsHubProxy.Invoke<Sms>("AddNewMessage", message);
            Task.Wait();
            return Task.Result;
            
        }


        public List<SmsContactState> GetContacts()
        {
            while (_hub.State != ConnectionState.Connected) Thread.Sleep(500);
            var Task = _smsHubProxy.Invoke<List<SmsContactState>>("GetContacts", "List of Contacts");
            Task.Wait();
            return Task.Result;
        }

        public List<Sms> GetMessages()
        {
            while (_hub.State != ConnectionState.Connected) Thread.Sleep(500);
            var Task = _smsHubProxy.Invoke<List<Sms>>("GetMessages", "List of Messages");
            Task.Wait();
            return Task.Result;
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
