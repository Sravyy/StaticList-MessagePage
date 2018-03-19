using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MessagePageView.Models;
using MessagePageView.ViewModels;
using MessagePageView.Services;

namespace MessagePageView
{
	public partial class MainPage : ContentPage
	{   

		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            this.MainViewModelContactList.Load(); 
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            var itemlist = this.MainViewModelContactList.ContactList;

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                listView.ItemsSource = itemlist;
            else
                listView.ItemsSource = itemlist.Where(l => l.ContactName.ToUpper().Contains(e.NewTextValue.ToUpper()));
                //listView.ItemsSource = itemlist.Where(l => l.ContactMobileNumber.IndexOf(e.NewTextValue));

            Console.WriteLine();
            //listView.ItemsSource = filteredList;
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            var itemlist = this.MainViewModelContactList.ContactList;
            listView.ItemsSource = itemlist;
            listView.EndRefresh();
            //or listView.IsRefreshing = "false"
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as SmsContactState;
            Sms sms = new Sms();
            var itemlist = this.MainViewModelContactList.MessageList;

            await Navigation.PushModalAsync(new MessageView(contact));
            listView.SelectedItem = null;
        }
    }
}
