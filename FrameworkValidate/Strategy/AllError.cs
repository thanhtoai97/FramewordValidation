using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Strategy
{
    public class AllError : View
    {
        public override string ShowNotification(List<NotificationError> notificationsError)
        {
            string result = "";
            notificationsError.ToList().ForEach((temp) =>
            {
                result += temp.ToString() + "\n";
            });
            return result;
        }
    }
}
