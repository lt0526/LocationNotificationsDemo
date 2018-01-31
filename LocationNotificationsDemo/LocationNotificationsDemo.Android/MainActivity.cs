using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;

namespace LocationNotificationsDemo.Droid
{
    [Activity(Label = "LocationNotificationsDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var myApp = new App();
            var mBundle = Intent.Extras;
            if (mBundle != null)
            {
                var pageParameter = mBundle.GetString("pageParameter");
                if (!string.IsNullOrEmpty(pageParameter))
                {
                    MessagingCenter.Send<object, string>(this, "Push", pageParameter);
                }
            }

            LoadApplication(myApp);
        }
    }
}

