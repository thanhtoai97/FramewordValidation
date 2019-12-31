using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate
{
    public class NotificationError
    {
        public string Name { get; set; }
        public string Notification { get; set; }

        public NotificationError()
        {
            Name = "";
            Notification = "";
        }

        public static NotificationError Create(string name, string notification)
        {
            NotificationError error = new NotificationError()
            {
                Name = name,
                Notification = notification
            };

            return error;
        }

        public override string ToString()
        {
            return Notification;
        }
    }
}
