using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using LocationNotificationsDemo.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PushLocalNotification))]
namespace LocationNotificationsDemo.iOS
{
    class PushLocalNotification : IPushNotification
    {
        public void CreateNotifications()
        {
            var notification = new UILocalNotification();

            // set the fire date (the date time in which it will fire)
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(10);

            // configure the alert
            notification.AlertAction = "View Alert";
            notification.AlertBody = "Your one minute alert has fired!";

            // modify the badge
            notification.ApplicationIconBadgeNumber = 1;

            // set the sound to be the default sound
            notification.SoundName = UILocalNotification.DefaultSoundName;

            // schedule it
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}