using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Strategy
{
    public abstract class View
    {
        public abstract string ShowNotification(List<NotificationError> notificationsError);
    }
}
