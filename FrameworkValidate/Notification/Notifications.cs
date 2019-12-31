using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Notification
{
    public class Notifications
    {
        /*
        public string IsNotNullNotification { get; set; }
        public string IsNotNullOrEmptyNotification { get; set; }
        public string IsPasswordNotification { get; set; }
        public string IsMinLengthNotification { get; set; }
        public string  IsNotification { get; set; }
        public string  IsNotNotification { get; set; }
        public string  IsEmailNotification { get; set; }
        public string IsMatchNotification { get; set; }
        */

        public string IsNotNullNotification { get; set; }
        public string IsNotNullOrEmptyNotification { get; set; }
        public string IsNotNullOrWhiteSpaceNotification { get; set; }
        public string IsNotZeroNotification { get; set; }
        public string IsPasswordNotification { get; set; }
        public string IsMinLengthNotification { get; set; }
        public string IsMaxLengthNotification { get; set; }
        public string IsExactLengthNotification { get; set; }
        public string IsBetweenLengthNotification { get; set; }
        public string IsNotification { get; set; }
        public string IsNotNotification { get; set; }
        public string IsEmailNotification { get; set; }
        public string IsRegexNotification { get; set; }
        public string IsMatchNotification { get; set; }
        public string IsDateNotification { get; set; }
        public string IsRuleNotification { get; set; }


        public string IsGreaterThanNotification { get; set; }
        public string IsGreaterThanOrEqualToNotification { get; set; }
        public string IsLessThanNotification { get; set; }
        public string IsLessThanOrEqualToNotification { get; set; }
        public string IsEqualToNotification { get; set; }
        public string IsBetweenInclusiveNotification { get; set; }
        public string IsBetweenExclusiveNotification { get; set; }
    }
}
