using MessagePageView.Models;
using MessagePageView.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MessagePageView.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private readonly SignalRClient signalR;

        private List<SmsContactState> _contactList;
        public List<SmsContactState> ContactList
        {
            get { return _contactList; }
            set
            {
                _contactList = value;
                OnPropertyChanged();
            }
        }

        private List<Sms> _messageList;
        public List<Sms> MessageList
        {
            get { return _messageList; }
            set
            {
                _messageList = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            signalR = new SignalRClient();

            //var contactServices = new SmsContactStateServices();
            //ContactList = contactServices.GetContacts();
        }

        public void Load()
        {
            ContactList = signalR.GetContacts();
            MessageList = signalR.GetMessages();
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
