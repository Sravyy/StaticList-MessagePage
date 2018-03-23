using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePageView.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MessagePageView.Services;
using System.Collections.ObjectModel;
using MvvmHelpers;

namespace MessagePageView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessageView : ContentPage
    {
		public MessageView (SmsContactState contact)
		{
			InitializeComponent ();
            listMessages.ItemsSource = SignalRClient.Instance.GetMessages();
		}

        protected override void OnAppearing()
        {
            this.MainViewModelMessageList.Load();
            listMessages.ItemsSource = this.MainViewModelMessageList.MessageList;

            //ObservableRangeCollection<Sms> updateCollection = new ObservableRangeCollection<Sms>(this.MainViewModelMessageList.MessageList);
            //listMessages.ItemsSource = updateCollection;

            //updateCollection.CollectionChanged += (sender, e) =>
            //{
            //    var target = updateCollection[updateCollection.Count - 1];
            //    listMessages.ScrollTo(target, ScrollToPosition.End, true);
            //};
        }

    
    }

    
}

