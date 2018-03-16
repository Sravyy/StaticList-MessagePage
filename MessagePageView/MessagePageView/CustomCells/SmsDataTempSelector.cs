using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MessagePageView
{
    public class SmsDataTempSelector : DataTemplateSelector
    {
        public DataTemplate FromTemplate { get; set; }
        public DataTemplate ToTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //Verifying if the Status is SENT, if sent, then it returns the FromTemplate orelse will Return ToTemplate

            return ((Sms)item).Status.ToUpper().Equals("SENT") ? FromTemplate : ToTemplate; 
           
        }
    }
}
