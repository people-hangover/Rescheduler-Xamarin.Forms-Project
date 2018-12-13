using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rescheduler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)] //other option is Skip. New. 
    public partial class AboutUs : ContentPage
    {
        private MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public AboutUs()
        {
            InitializeComponent(); //doing the joining of partial class in run time
            //HeaderGrid.BackgroundColor = Color.Pink;
        }

        private void PhoneGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var mySender = (StackLayout)sender;
            mySender.BackgroundColor = Color.Pink;

            try
            {
                PhoneDialer.Open("16303449385");
            }
            catch (FeatureNotSupportedException ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Sorry, the phone dialer is not supported on this device.", "OK");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void TwitterGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://twitter.com/fox_build"));
            //Device.OpenUri(new Uri( "https://twitter.com/intent/tweet?text=Home&url=https%3A%2F%2Ffox.build%2F&via=@fox_build"));
        }

        private void SlackGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Wait!", "You must be a member to join our Slack Channel!", "OK");
        }

        private void FacebookGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //
            Device.OpenUri(new Uri("https://www.facebook.com/foxbuildshop"));
            //Device.OpenUri(new Uri("https://www.facebook.com/sharer/sharer.php?u=https://fox.build/")
        }

   

        private async void BackButton_Tapped(object sender, EventArgs e)
        {
           // var menu = RootPage.Master as MenuPage;
            (RootPage.Master as MenuPage).TakeMeHere(Models.MenuItemType.Browse);
           await RootPage.NavigateFromMenu(0);
        }//
    }
}