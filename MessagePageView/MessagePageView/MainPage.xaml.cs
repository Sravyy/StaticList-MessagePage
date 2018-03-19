using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
           
            Console.WriteLine();
            //listView.ItemsSource = filteredList;
        }
    }
}
