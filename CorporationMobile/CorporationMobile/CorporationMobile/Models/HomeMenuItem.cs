using System;
using System.Collections.Generic;
using System.Text;

namespace CorporationMobile.Models
{
    public enum MenuItemType
    {
        Home,
        Corporation,
        Provider,
        Browse
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
