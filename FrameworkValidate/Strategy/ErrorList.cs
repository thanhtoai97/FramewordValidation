using FrameworkValidate.Notification;
using FrameworkValidate.Validate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Strategy
{
    public partial class ErrorList
    {
        public List<NotificationError> notificationsError { get; set; }
        public Notifications notifications;

        // Constructor
        public ErrorList()
        {
            notificationsError = new List<NotificationError>();
            notifications = NotificationFactory.getInstance().getNotificationType();
        }

        public ErrorList(NotificationType type)
        {
            notificationsError = new List<NotificationError>();
            notifications = NotificationFactory.getInstance().getNotificationType(type);
        }

        // check count
        public bool IsValid()
        {
            return notificationsError.Count == 0;
        }


        public string ErrorToString(View error)
        {
            return error.ShowNotification(notificationsError);
        }

        public ErrorList AddError(string notification)
        {
            return AddError("", notification);
        }

        public ErrorList AddError(string name, string notification)
        {
            NotificationError error = NotificationError.Create(name.EmptyStringIfNull(), notification);
            notificationsError.Add(error);
            return this;
        }

        protected ErrorList NoError()
        {
            return this;
        }

        public ErrorList Must(Func<bool> func)
        {
            return Must("", func);
        }

        public ErrorList Must(string name, Func<bool> func)
        {
            return Must(name, func, string.Format(notifications.IsNotNotification, name));
        }

        public ErrorList Must(string name, Func<bool> func, string message)
        {
            if (!func())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        // list Error
        #region " IsNotNullOrEmpty "

        public ErrorList IsNotNullOrEmpty(string value)
        {
            return IsNotNullOrEmpty("", value);
        }

        public ErrorList IsNotNullOrEmpty(string name, string value)
        {
            return IsNotNullOrEmpty(name, value, string.Format(notifications.IsNotNullOrEmptyNotification, name));
        }

        public ErrorList IsNotNullOrEmpty(string name, string value, string message)
        {
            // do the check
            if (value.IsNotNullOrEmpty())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsNotNullOrWhiteSpace "

        public ErrorList IsNotNullOrWhiteSpace(string value)
        {
            return IsNotNullOrWhiteSpace("", value);
        }

        public ErrorList IsNotNullOrWhiteSpace(string name, string value)
        {
            return IsNotNullOrWhiteSpace(name, value, string.Format(notifications.IsNotNullOrWhiteSpaceNotification, name));
        }

        public ErrorList IsNotNullOrWhiteSpace(string name, string value, string message)
        {
            // do the check
            if (value.IsNotNullOrWhiteSpace())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsEmail "

        public ErrorList IsEmail(string value)
        {
            return IsEmail("", value);
        }

        public ErrorList IsEmail(string name, string value)
        {
            return IsEmail(name, value, string.Format(notifications.IsEmailNotification, name));
        }

        public ErrorList IsEmail(string name, string value, string message)
        {
            // do the check
            if (value.IsEmail())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsRegex "

        public ErrorList IsRegex(string value, string exp)
        {
            return IsRegex("", value, exp);
        }

        public ErrorList IsRegex(string name, string value, string exp)
        {
            return IsRegex(name, value, exp, string.Format(notifications.IsRegexNotification, name));
        }

        public ErrorList IsRegex(string name, string value, string exp, string message)
        {
            // do the check
            if (value.IsRegex(exp))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsPassword "

        public ErrorList IsPassword(string value)
        {
            return IsPassword("", value);
        }

        public ErrorList IsPassword(string name, string value)
        {
            return IsPassword(name, value, string.Format(notifications.IsPasswordNotification, name));
        }

        public ErrorList IsPassword(string name, string value, string message)
        {
            // do the check
            if (!value.IsPassword())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsEqualTo "

        public ErrorList IsMatch(string value, string compare)
        {
            return IsMatch("", value, compare);
        }

        public ErrorList IsMatch(string name, string value, string compare)
        {
            return IsMatch(name, value, compare, string.Format(notifications.IsMatchNotification, name));
        }

        public ErrorList IsMatch(string name, string value, string compare, string message)
        {
            // do the check
            if (!value.IsEqualTo(compare))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion // p

        #region " IsMinLength "

        public ErrorList IsMinLength(string value, int min)
        {
            return IsMinLength("", value, min);
        }

        public ErrorList IsMinLength(string name, string value, int min)
        {
            return IsMinLength(name, value, min, string.Format(notifications.IsMinLengthNotification, name, min));
        }

        public ErrorList IsMinLength(string name, string value, int min, string message)
        {
            // do the check
            if (value.IsMinLength(min))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsMaxLength "

        public ErrorList IsMaxLength(string value, int max)
        {
            return IsMaxLength("", value, max);
        }

        public ErrorList IsMaxLength(string name, string value, int max)
        {
            ErrorList t = IsMaxLength(name, value, max, string.Format(notifications.IsMaxLengthNotification, name, max));
            if (t == null)
            {
                Console.WriteLine("oo");
            }
            return t;

        }

        public ErrorList IsMaxLength(string name, string value, int max, string message)
        {
            // do the check
            if (value.IsMaxLength(max))
            {
                return NoError();

            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsBetweenLength "

        public ErrorList IsBetweenLength(string value, int min, int max)
        {
            return IsBetweenLength("", value, min, max);
        }

        public ErrorList IsBetweenLength(string name, string value, int min, int max)
        {
            return IsBetweenLength(name, value, min, max, string.Format(notifications.IsBetweenLengthNotification, name, min, max));
        }

        public ErrorList IsBetweenLength(string name, string value, int min, int max, string message)
        {
            // do the check
            if (value.IsBetweenLength(min, max))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsExactLength "

        public ErrorList IsExactLength(string value, int exact)
        {
            return IsExactLength("", value, exact);
        }

        public ErrorList IsExactLength(string name, string value, int exact)
        {
            return IsExactLength(name, value, exact, string.Format(notifications.IsExactLengthNotification, name, exact));
        }

        public ErrorList IsExactLength(string name, string value, int exact, string message)
        {
            // do the check
            if (!value.IsExactLength(exact))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsNotNull "

        public ErrorList IsNotNull(object value)
        {
            return IsNotNull("", value);
        }

        public ErrorList IsNotNull(string name, object value)
        {
            return IsNotNull(name, value, string.Format(notifications.IsNotNullNotification, name));
        }

        public ErrorList IsNotNull(string name, object value, string message)
        {
            // do the check
            if (value.IsNotNull())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " Is "

        public ErrorList Is(Func<bool> func)
        {
            return Is("", func);
        }

        public ErrorList Is(string name, Func<bool> func)
        {
            return Is(name, func, notifications.IsNotification);
        }

        public ErrorList Is(string name, Func<bool> func, string message)
        {
            if (func())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsNot "

        public ErrorList IsNot(Func<bool> func)
        {
            return IsNot("", func);
        }

        public ErrorList IsNot(string name, Func<bool> func)
        {
            return IsNot(name, func, notifications.IsNotNotification);
        }

        public ErrorList IsNot(string name, Func<bool> func, string message)
        {
            if (func())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsNotZero "

        public ErrorList IsNotZero(int value)
        {
            return IsNotZero("", value);
        }

        public ErrorList IsNotZero(string name, int value)
        {
            return IsNotZero(name, value, string.Format(notifications.IsNotZeroNotification, name));
        }

        public ErrorList IsNotZero(string name, int value, string message)
        {
            // do the check
            if (value.IsNotZero())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsDate "

        public ErrorList IsDate(object value)
        {
            return IsDate("", value);
        }

        public ErrorList IsDate(string name, object value)
        {
            return IsDate(name, value, string.Format(notifications.IsDateNotification, name));
        }

        public ErrorList IsDate(string name, object value, string message)
        {
            // do the check
            if (value.IsDate())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        public ErrorList IsDate(object value, CultureInfo info)
        {
            return IsDate("", value, info);
        }

        public ErrorList IsDate(string name, object value, CultureInfo info)
        {
            return IsDate(name, value, string.Format(notifications.IsDateNotification, name), info);
        }

        public ErrorList IsDate(string name, object value, string message, CultureInfo info)
        {
            // do the check
            if (value.IsDate(info))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        public ErrorList IsDate(object value, CultureInfo info, DateTimeStyles styles)
        {
            return IsDate(string.Empty, value, info, styles);
        }

        public ErrorList IsDate(string name, object value, CultureInfo info, DateTimeStyles styles)
        {
            return IsDate(name, value, string.Format(notifications.IsDateNotification, name), info, styles);
        }

        public ErrorList IsDate(string name, object value, string message, CultureInfo info, DateTimeStyles styles)
        {
            // do the check
            if (value.IsDate(info, styles))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsGreaterThan "

        public ErrorList IsGreaterThan(DateTime value, DateTime compare)
        {
            return IsGreaterThan("", value, compare);
        }

        public ErrorList IsGreaterThan(string name, DateTime value, DateTime compare)
        {
            return IsGreaterThan(name, value, compare, string.Format(notifications.IsGreaterThanNotification, name, compare));
        }

        public ErrorList IsGreaterThan(string name, DateTime value, DateTime compare, string message)
        {
            // do the check
            if (value.IsGreaterThan(compare))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsGreaterThanOrEqualTo "

        public ErrorList IsGreaterThanOrEqualTo(DateTime value, DateTime compare)
        {
            return IsGreaterThanOrEqualTo("", value, compare);
        }

        public ErrorList IsGreaterThanOrEqualTo(string name, DateTime value, DateTime compare)
        {
            return IsGreaterThanOrEqualTo(name, value, compare, string.Format(notifications.IsGreaterThanOrEqualToNotification, name, compare));
        }

        public ErrorList IsGreaterThanOrEqualTo(string name, DateTime value, DateTime compare, string message)
        {
            // do the check
            if (value.IsGreaterThanOrEqualTo(compare))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsLessThan "

        public ErrorList IsLessThan(DateTime value, DateTime compare)
        {
            return IsLessThan("", value, compare);
        }

        public ErrorList IsLessThan(string name, DateTime value, DateTime compare)
        {
            return IsLessThan(name, value, compare, string.Format(notifications.IsLessThanNotification, name, compare));
        }

        public ErrorList IsLessThan(string name, DateTime value, DateTime compare, string message)
        {
            // do the check
            if (value.IsLessThan(compare))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsLessThanOrEqualTo "

        public ErrorList IsLessThanOrEqualTo(DateTime value, DateTime compare)
        {
            return IsLessThanOrEqualTo("", value, compare);
        }

        public ErrorList IsLessThanOrEqualTo(string name, DateTime value, DateTime compare)
        {
            return IsLessThanOrEqualTo(name, value, compare, string.Format(notifications.IsLessThanOrEqualToNotification, name, compare));
        }

        public ErrorList IsLessThanOrEqualTo(string name, DateTime value, DateTime compare, string message)
        {
            // do the check
            if (value.IsLessThanOrEqualTo(compare))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsEqualTo "

        public ErrorList IsEqualTo(DateTime value, DateTime compare)
        {
            return IsEqualTo("", value, compare);
        }

        public ErrorList IsEqualTo(string name, DateTime value, DateTime compare)
        {
            return IsEqualTo(name, value, compare, string.Format(notifications.IsEqualToNotification, name, compare));
        }

        public ErrorList IsEqualTo(string name, DateTime value, DateTime compare, string message)
        {
            // do the check
            if (value.IsEqualTo(compare))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsBetweenInclusive "

        public ErrorList IsBetweenInclusive(DateTime value, DateTime from, DateTime to)
        {
            return IsBetweenInclusive("", value, from, to);
        }

        public ErrorList IsBetweenInclusive(string name, DateTime value, DateTime from, DateTime to)
        {
            return IsBetweenInclusive(name, value, from, to, string.Format(notifications.IsBetweenInclusiveNotification, name, from, to));
        }

        public ErrorList IsBetweenInclusive(string name, DateTime value, DateTime from, DateTime to, string message)
        {
            // do the check
            if (value.IsBetweenInclusive(from, to))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsBetweenInclusive "

        public ErrorList IsBetweenExclusive(DateTime value, DateTime from, DateTime to)
        {
            return IsBetweenExclusive("", value, from, to);
        }

        public ErrorList IsBetweenExclusive(string name, DateTime value, DateTime from, DateTime to)
        {
            return IsBetweenExclusive(name, value, from, to, string.Format(notifications.IsBetweenExclusiveNotification, name, from, to));
        }

        public ErrorList IsBetweenExclusive(string name, DateTime value, DateTime from, DateTime to, string message)
        {
            // do the check
            if (value.IsBetweenExclusive(from, to))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion
    }
}
