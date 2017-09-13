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
using System.Data.OleDb;
using PartnersMatcher.Controller;
using PartnersMatcher.Model;

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user = null;
        static MyController controller;

        public MainWindow(MyController c)
        {
            InitializeComponent();
            controller = c;
            controller.addNewAdvertisement(new SportAdvertisement(0, "football", "hard", "gil", "haifa", new DateTime(), "lalalalalalal"));
            Show();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            insertmail.Visibility = Visibility.Hidden;
            entermail.Visibility = Visibility.Hidden;
            insertpass.Visibility = Visibility.Hidden;
            enterpass.Visibility = Visibility.Hidden;
            signingin.Visibility = Visibility.Hidden;
            SignUpWindow suw = new PartnersMatcher.SignUpWindow();
            suw.Show();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            //Window1 win = new Window1();
            //win.Show();
            entermail.Text = "";
            enterpass.Password = "";
            insertmail.Visibility = Visibility.Visible;
            entermail.Visibility = Visibility.Visible;
            insertpass.Visibility = Visibility.Visible;
            enterpass.Visibility = Visibility.Visible;
            signingin.Visibility = Visibility.Visible;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (Fields.Text == "")
                MessageBox.Show("You must choose a category");
            else if (Cities.Text == "")
                MessageBox.Show("You must choose a city");
            else
            {
                List<Advertisement> advList = controller.getAdvsResults(Cities.Text, Fields.Text);

                if (advList.Count == 0)
                    MessageBox.Show("No ads match your search");
                else
                {
                    System.Windows.Controls.ListView showDic = new System.Windows.Controls.ListView();
                    //showDic.Foreground = Color
                    foreach (Advertisement s in advList)
                        showDic.Items.Add("Published by: "+s.Owner + "\nAt: " + s.Datepublished + "\nDescription: " + s.Description+"\n");

                    AdDisplay ad = new AdDisplay();
                    ad.Content = showDic;
                    ad.Show();
                }
            }
        }

        private void signingin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = enterpass.Password;
                string email = entermail.Text;
                DataBaseService myDataBase = new DataBaseService();
                if (entermail.Text == "" || enterpass.Password == "")
                    MessageBox.Show("Wrong email input ");
                else if (password == "")
                    MessageBox.Show("please enter password ");
                else
                {
                    user = controller.connectUser(email, password);
                    if (user == null)
                    {
                        MessageBox.Show("wrong user or password");
                    }
                    else
                    {
                        MessageBox.Show("Connected succesfully!");
                        //    ((MainWindow)Application.Current.MainWindow).notifyMe(user); do something with this
                        insertmail.Visibility = Visibility.Hidden;
                        entermail.Visibility = Visibility.Hidden;
                        insertpass.Visibility = Visibility.Hidden;
                        enterpass.Visibility = Visibility.Hidden;
                        signingin.Visibility = Visibility.Hidden;
                        SignUp.Visibility = Visibility.Hidden;
                        SignIn.Visibility = Visibility.Hidden;
                        Field.Visibility = Visibility.Visible;
                        Fields.Visibility = Visibility.Visible;
                        City.Visibility = Visibility.Visible;
                        Cities.Visibility = Visibility.Visible;
                        search.Visibility = Visibility.Visible;
                        logout.Visibility = Visibility.Visible;
                        hello.Text = "Hello " + user.FirstName + "!";
                        hello.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception excepction)
            {
                MessageBox.Show("Connection to DB failed " + excepction.Message);
            }


        }
        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                signingin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            
            insertmail.Visibility = Visibility.Hidden;
            entermail.Visibility = Visibility.Hidden;
            insertpass.Visibility = Visibility.Hidden;
            enterpass.Visibility = Visibility.Hidden;
            signingin.Visibility = Visibility.Hidden;
            SignUp.Visibility = Visibility.Visible;
            SignIn.Visibility = Visibility.Visible;
            Field.Visibility = Visibility.Hidden;
            Fields.Visibility = Visibility.Hidden;
            City.Visibility = Visibility.Hidden;
            Cities.Visibility = Visibility.Hidden;
            search.Visibility = Visibility.Hidden;
            logout.Visibility = Visibility.Hidden;
            hello.Text = "Hello " + user.FirstName + "!";
            hello.Visibility = Visibility.Hidden;
            user = null;
            Fields.SelectedIndex = -1;
            Cities.SelectedIndex = -1;

        }
        public static void addUser(User u)
        {
            controller.addUser(u);
        }
    }
}
