using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Notification
{
    public class VietNamNotification : Notifications
    {
        public VietNamNotification()
        {
            /*
            IsNotification = "'không thỏa điều kiện.";
            IsNotNotification = "không thỏa điều kiện.";
            IsEmailNotification = "không phải email.";
            IsMatchNotification = "không thỏa điều kiện.";
            IsNotNullNotification = "không được phép null.";
            IsNotNullOrEmptyNotification = "không được phép rỗng hay null .";
            IsPasswordNotification = "ít bảo mật. Mật khảu phải từ 8 đến 30 kí tự, ít nhất một chữ hoa, một chữ thường và một số.";
            IsMinLengthNotification = "phải ít nhất có {1} kí tự.";
            */

            IsNotNullNotification = "'{0}' cannot be null.";
            IsNotNullOrEmptyNotification = "'{0}' cannot be null or empty.";
            IsNotNullOrWhiteSpaceNotification = "'{0}' cannot be null or whitespace only.";
            IsNotZeroNotification = "'{0}' cannot be zero.";
            IsPasswordNotification = "'{0}' is not a valid password. Passwords must be 8 to 30 characters, at least on 1 uppercase letter, at least 1 lowercase letter and at least one number.";
            IsMinLengthNotification = "'{0}' must be a at least {1} characters.";
            IsMaxLengthNotification = "'{0}' must be {1} characters or less.";
            IsExactLengthNotification = "'{0}' must be exactly {1} characters.";
            IsBetweenLengthNotification = "'{0}' must be at least {1} and at most {2} characters.";
            IsNotification = "'{0}' does not match the specified criteria.";
            IsNotNotification = "'{0}' does not match the specified criteria.";
            IsEmailNotification = "'{0}' is not a valid email address.";
            IsRegexNotification = "'{0}' does not match the provided regular expression.";
            IsMatchNotification = "'{0}' did not match the specified criteria.";
            IsDateNotification = "'{0}' is not a valid date.";
            IsRuleNotification = "'{0}' failed the provided business rule provided.";
            IsGreaterThanNotification = "'{0}' must be greater than '{1}'.";
            IsGreaterThanOrEqualToNotification = "'{0}' must be greater than or equal to '{1}'.";
            IsLessThanNotification = "'{0}' must be less than '{1}'.";
            IsLessThanOrEqualToNotification = "'{0}' must be less than or equal to '{1}'.";
            IsEqualToNotification = "'{0}' must be equal to '{1}'.";
            IsBetweenInclusiveNotification = "'{0}' must be between '{1}' and '{2}' (inclusive).";
            IsBetweenExclusiveNotification = "'{0}' must be between '{1}' and '{2}' (exclusive).";
        }
    }
}
