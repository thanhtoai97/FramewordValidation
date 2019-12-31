using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Notification
{
    public class NotificationFactory
    {
        // Singleton

        private static NotificationFactory instance;

        private NotificationFactory()
        {
        }

        public static NotificationFactory getInstance()
        {
            if(instance == null)
            {
                return new NotificationFactory();
            }
            return instance;
        }

        // FactoryMethod

        public Notifications getNotificationType()
        {
            return getNotificationType(NotificationType.English);
        }
        public Notifications getNotificationType(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.VietNam:
                        return new VietNamNotification();
                case NotificationType.English:
                    return new EnglishNotification();
                default:
                    return null;

            }
        }
    }
}
