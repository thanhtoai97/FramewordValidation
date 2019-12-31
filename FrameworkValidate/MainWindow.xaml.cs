using FrameworkValidate.Notification;
using FrameworkValidate.Strategy;
using FrameworkValidate.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrameworkValidate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstname = firsttb.Text;
            string lastname = lasttb.Text;
            int discount = ValidateHelperMethod.ToInt(discounttb.Text);
            string password = passwordtb.Text;
            string email = emailtb.Text;

            ErrorList validator = MyCustomValidator(firstname, lastname, discount, password, email);
            MessageBox.Show(validator.ErrorToString(new AllError()));
        }

        public ErrorList MyCustomValidator(string firstname, string lastname, int discount, string password, string email)
        {
            ErrorList errorlist = new ErrorList(NotificationType.VietNam);
            errorlist.IsNotNullOrEmpty("firstname", firstname)
                .IsNotNullOrEmpty("lastname", lastname)
                .IsMaxLength("lastname", lastname, 40)
                .IsNotZero("discount", discount)
                .IsBetweenLength("email", email, 6, 40)
                .IsEmail("email", email)
                .IsPassword("password", password)
                .Must("custom", () =>
                {
                    return false;
                });
            return errorlist;
        }
    }
}
