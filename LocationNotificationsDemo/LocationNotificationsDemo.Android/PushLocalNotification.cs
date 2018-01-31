using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LocationNotificationsDemo.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PushLocalNotification))]
namespace LocationNotificationsDemo.Droid
{
    public class PushLocalNotification : IPushNotification
    {
        public void CreateNotifications()
        {
            Notification.Builder builder = new Notification.Builder(Forms.Context);
            Intent intent = new Intent(Xamarin.Forms.Forms.Context, typeof(MainActivity));
            Bundle bundle = new Bundle();
            // if we want to navigate to Page1:
            bundle.PutString("pageParameter", "parameter1");
            intent.PutExtras(bundle);
            PendingIntent pIntent = PendingIntent.GetActivity(Xamarin.Forms.Forms.Context, 0, intent, 0);
            builder.SetContentTitle("View Alert")
                   .SetContentText("Your one minute alert has fired!")
                   .SetSmallIcon(Resource.Drawable.icon)
                   .SetContentIntent(pIntent);
            var manager = (NotificationManager)Xamarin.Forms.Forms.Context.GetSystemService("notification");
            manager.Notify(1, builder.Build());
        }
    }
}