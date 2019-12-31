using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Strategy
{
    public class UniqueError : View
    {
        public override string ShowNotification(List<NotificationError> notificationsError)
        {
            string result = "";
            notificationsError.GroupBy(e => e.Name).Select(e => e.First()).ToList().ForEach((temp) =>
            {
                result += temp.ToString() + "\n";
            });

            return result;
        }
    }
}
