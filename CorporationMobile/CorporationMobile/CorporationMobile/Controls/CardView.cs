using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CorporationMobile.Controls
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    HasShadow = false;
                    BorderColor = Color.FromHex("cccccc");
                    BackgroundColor = Color.FromHex("#ffffff");
                    break;
            }
        }
    }
}
