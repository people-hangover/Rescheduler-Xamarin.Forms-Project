﻿using Rescheduler.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rescheduler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
              
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutUs()));
                        break;

                    case (int)MenuItemType.MyReservations:
                        MenuPages.Add(id, new NavigationPage(new MyReservations()));
                        break;

                    case (int)MenuItemType.Login:
                        MenuPages.Add(id, new NavigationPage(new Login()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        internal Task NavigateFromMenu(object id)
        {
            throw new NotImplementedException();
        }
    }
}