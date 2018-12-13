using System;
using System.Collections.Generic;
using System.Text;

namespace Rescheduler.Models
{
    [Flags]
    public enum MenuItemType
    {
        Browse =0,
        About = 1,
        MyReservations = 2,
        Login = 3
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
