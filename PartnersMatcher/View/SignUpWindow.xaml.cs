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
using System.Windows.Shapes;
using System.Net.Mail;
using PartnersMatcher.Controller;

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow() 
        {
            InitializeComponent();
        }
        /// <summary>
        /// checking sign up form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            bool ready = false;
           
            int agenum = -1;
            if (firstname.Text == "" ||
                lastname.Text == "" ||
                e_mail.Text == "" ||
                telephone.Text == "" ||
                PASSWORD.Text == "" ||
                cities.Text == ""
               )
                MessageBox.Show("All orange fields are required for sign up!");
            else if (male.IsChecked != true && female.IsChecked != true)
                MessageBox.Show("you must select a gender in order to sign up");
            else if (yes.IsChecked != true && no.IsChecked != true)
                MessageBox.Show("Please choose if you want to get recomindation\nwe promise not to bug you!");
            else if (!(firstname.Text.All(c => (Char.IsLetter(c) || c == ' ')) || !(lastname.Text.All(c => Char.IsLetter(c) || c == ' '))))
                MessageBox.Show("first and last names must consist of letters only");
            else if (!(telephone.Text.All(c => Char.IsNumber(c))))
                MessageBox.Show("phone must consist of numbers only, no spaces");
            else if (age.Text != "")
            {
                if (!(age.Text.All(c => Char.IsNumber(c))))
                    MessageBox.Show("age must consist of numbers only, no spaces");
                else
                {
                    agenum = Int32.Parse(age.Text);
                    if (agenum < 18 || agenum >120)
                        MessageBox.Show("Sorry, you must be between the ages of 18 and 120 in order to sign up");
                    else
                        ready = true;
                }
            }
            else
                ready = true;
            if (ready)
            {
                string mal = "false";
                string rec = "false";
                string smk = "false";
                string kos = "false";
                string shab = "false";
                string anm = "false";
                string noise = "false";
                if (male.IsChecked == true)
                    mal = "true";
                if (yes.IsChecked == true)
                    rec = "true";
                if (smoking.IsChecked == true)
                    smk = "true";
                if (kosher.IsChecked == true)
                    kos = "true";
                if (shabat.IsChecked == true)
                    shab = "true";
                if (animal.IsChecked == true)
                    anm = "true";
                if (noiseSensitive.IsChecked == true)
                    noise = "true";
                try
                {
                    User u = new User(firstname.Text, lastname.Text, e_mail.Text, telephone.Text, PASSWORD.Text, cities.Text,
                                    mal, rec, smk, kos, age.Text, shab, anm, noise, Hobbies.Text, aboutme.Text, Clean.Text);
                    MainWindow.addUser(u);
                    MessageBox.Show("Welcome to the family!\nA confirmation email has been sent");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        /// <summary>
        /// can't choose both genders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void male_Checked(object sender, RoutedEventArgs e)
        {
            if (female.IsChecked == true)
                female.IsChecked = false;
        }

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            if (male.IsChecked == true)
                male.IsChecked = false;
        }
        /// <summary>
        /// can't choose both "yes" and "no"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yes_Checked(object sender, RoutedEventArgs e)
        {
            if (no.IsChecked == true)
                no.IsChecked = false;
        }

        private void no_Checked(object sender, RoutedEventArgs e)
        {
            if (yes.IsChecked == true)
                yes.IsChecked = false;
        }
    }
}
