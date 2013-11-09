using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UbpSample_Browser.Resources;

namespace UbpSample_Browser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Browser.IsScriptEnabled = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //[UBP]
            Uri uri = App.RootFrame.UriMapper.MapUri(e.Uri);
            ParseNavigationUri(uri);

            base.OnNavigatedTo(e);
        }

        //[UBP]
        public void ParseNavigationUri(Uri uri)
        {
            string uriString = uri.ToString();

            //Get key/value pairs from query
            string[] args = uriString.Substring(uriString.IndexOf("?") + 1).Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

            //Cycle through key/value pair and navigate to url
            foreach (string arg in args)
            {
                if (arg.Contains("="))
                {
                    //var[0]=key, var[1]=value
                    string[] var = arg.Split(new string[] { "=" }, StringSplitOptions.None);
                    switch (var[0])
                    {
                        case "url":
                            {
                                Browser.Navigate(new Uri(var[1], UriKind.Absolute));
                                break;
                            }
                    }
                }
            }
        }
    }
}