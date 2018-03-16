using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagePageView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessageView : ContentPage
	{
		public MessageView ()
		{
			InitializeComponent ();
            //listMessages.ItemsSource = new Sms().GetMessages();
		}

        protected override void OnAppearing()
        {
            this.MainViewModelMessageList.Load();
            listMessages.ItemsSource = this.MainViewModelMessageList.MessageList;
        }
    }
}