using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LocationNotificationsDemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var rootPage = new MainPage();
			MainPage = new NavigationPage(rootPage);

            MessagingCenter.Subscribe<object, string>(this, "Push", async (sender, args) =>
            {
                var second = new SecondPage();
                second.MyStr = args;
                await rootPage.Navigation.PushAsync(second);
            });
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
