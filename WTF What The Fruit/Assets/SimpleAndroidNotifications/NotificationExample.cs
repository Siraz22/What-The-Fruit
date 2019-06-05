using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class NotificationExample : MonoBehaviour
    {
        public void Rate()
        {
            Application.OpenURL("http://u3d.as/y6r");
        }

        public void OpenWiki()
        {
            Application.OpenURL("https://github.com/hippogamesunity/SimpleAndroidNotificationsPublic/wiki");
        }

        public void ScheduleSimple()  //"Simple notification" matlab Heading ... "Customize icon and color" matlab sub detail.
        {
            NotificationManager.Send(TimeSpan.FromSeconds(5), "Simple notification", "Customize icon and color", new Color(1, 0.3f, 0.15f));
        }

        public void ScheduleNormal() //"Notification" matlab heading  "Notification with app icon" mtlb sub heading and ismein right  side mein ek icon aajayega;//\U0001F600 matlab griinning face
        {

            //ACHIEVEMENTS
            int x =PlayerPrefs.GetInt("Gifts");
            x++;
            PlayerPrefs.SetInt("Gifts", x);
            
            NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(1800), "Kids! your Gift is ready; 2000 Diamonds!!", "Lets eat fruits together! \U0001F609 \U0001F351 ", new Color(0, 1f, 1), NotificationIcon.Message);
        }

        public void ScheduleCustom()
        {
            var notificationParams = new NotificationParams
            {
                Id = UnityEngine.Random.Range(0, int.MaxValue),
                Delay = TimeSpan.FromSeconds(5),
                Title = "Custom notification",
                Message = "Message",
                Ticker = "Ticker",
                Sound = true,
                Vibrate = true,
                Light = true,
                SmallIcon = NotificationIcon.Heart,
                SmallIconColor = new Color(0, 0.5f, 0),
                LargeIcon = "app_icon"
            };

            NotificationManager.SendCustom(notificationParams);
        }

        public void CancelAll()
        {
            NotificationManager.CancelAll();
        }
    }
}