﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingBird.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzE3ODg1QDMxMzgyZTMyMmUzMEpFTVBDWjZSSllDSGt0Q2JhRTJncytDOGpHalNGS0dIaFJsdzU1NzJoeVU9");
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
