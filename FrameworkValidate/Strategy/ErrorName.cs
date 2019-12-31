using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Strategy
{
    public class ErrorName : View
    {
        public string name;
        public ErrorName(string name)
        {
            this.name = name;
        }

        public override string ShowNotification(List<NotificationError> notificationsError)
        {
            string result = "";
            notificationsError.Where(e => e.Name == name).ToList().ForEach((temp) =>
            {
                result += temp.ToString() + "\n";
            });

            return result;
        }
    }
}
