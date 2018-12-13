using Rescheduler.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rescheduler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            //TODO: Remove My Reservation if the user is not logged in 
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.MyReservations, Title="My Reservations" },
                new HomeMenuItem {Id = MenuItemType.Login, Title="Login"},
                new HomeMenuItem {Id = MenuItemType.About, Title="About"}
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += DoThisOne;
        }
            //    async (sender, e) =>
            //{
            //    if (e.SelectedItem == null)
            //        return;

            //    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            //    await RootPage.NavigateFromMenu(id);
            //};
            //unsubscribe
             private async void DoThisOne(object sender, SelectedItemChangedEventArgs e)
            {
                if (e.SelectedItem == null)
                    return;

                var id =(int)((HomeMenuItem)e.SelectedItem).Id;
            await RootPage.NavigateFromMenu(id);
            }
        //public  void TakeMeHere(int PageNumber)
        //{
        //    ListViewMenu.SelectedItem = menuItems[PageNumber];
        //}
  
        public void TakeMeHere(MenuItemType page)
        {
            var id = (int)page;
            ListViewMenu.SelectedItem = menuItems[id];
        }
    }
}