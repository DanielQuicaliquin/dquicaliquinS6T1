﻿namespace dquicaliquinS6T1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Sitios());
        }
    }
}
