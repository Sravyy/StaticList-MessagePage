using MessagePageView.Models;
using MessagePageView.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace MessagePageView.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

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

        private ObservableRangeCollection<Sms> _messageList;
        public ObservableRangeCollection<Sms> MessageList
        {
            get { return _messageList; }
            set
            {
                _messageList = value;
                OnPropertyChanged();
            }
        }

        string outgoingText = string.Empty;
        public string OutGoingText
        {
            get { return outgoingText; }
            set
            {
                outgoingText = value;
               OnPropertyChanged();
            }
        }

        public ICommand SendCommand { get; set; }

        public MainViewModel()
        {
            MessageList = new ObservableRangeCollection<Sms>();

            SendCommand = new Command(() =>
            {

                var Sms = SignalRClient.Instance.AddNewMessage(OutGoingText);
                MessageList.Add(Sms);
                
                OutGoingText = string.Empty;


            });
        }


        public void Load()
        {
            ContactList = SignalRClient.Instance.GetContacts();
            MessageList = new ObservableRangeCollection<Sms>(SignalRClient.Instance.GetMessages());
        }
        //#region INotifyPropertyChanged Members
        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //        handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //#endregion


    }
}
