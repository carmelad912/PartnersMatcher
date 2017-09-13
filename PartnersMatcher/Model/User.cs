using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PartnersMatcher
{
    /// <summary>
    /// the class represents a user signed to the sytem. getters and setters for all fields.
    /// </summary>
    public class User
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string password;
        private string city;
        private string isMale; // in case of false- female
        private string subscribed; // for automatic recomedation system
        // this are optional
        private string smoke;
        private string kosher;
        private string age;
        private string shabat;
        private string animal;
        private string noiseSensitive;
        private string hobbies;
        private string freeText;
        private string clean;

        public User(string firstName, string lastName, string email, string phone, string password, string city, string isMale, string subscribed, string smoke, string kosher, string age, string shabat, string animal, string noiseSensitive, string hobbies, string freeText, string clean)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.password = password;
            this.isMale = isMale;
            this.subscribed = subscribed;
            this.smoke = smoke;
            this.kosher = kosher;
            this.age = age;
            this.shabat = shabat;
            this.animal = animal;
            this.noiseSensitive = noiseSensitive;
            this.hobbies = hobbies;
            this.freeText = freeText;
            this.clean = clean;
            this.city = city;
        }

        public string FirstName
        {
            get { return firstName; }

            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }

            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }

            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }

            set { phone = value; }
        }

        public string Password
        {
            get { return password; }

            set { password = value; }
        }

        public string IsMale
        {
            get { return isMale; }

            set { isMale = value; }
        }

        public string Subscribed
        {
            get { return subscribed; }

            set { subscribed = value; }
        }

        public string Smoke
        {
            get { return smoke; }

            set { smoke = value; }
        }

        public string Kosher
        {
            get { return kosher; }

            set { kosher = value; }
        }

        public string Age
        {
            get { return age; }

            set { age = value; }
        }

        public string Shabat
        {
            get
            {
                return shabat;
            }

            set
            {
                shabat = value;
            }
        }

        public string Animal
        {
            get
            {
                return animal;
            }

            set
            {
                animal = value;
            }
        }

        public string NoiseSensitive
        {
            get
            {
                return noiseSensitive;
            }

            set
            {
                noiseSensitive = value;
            }
        }

        public string Hobbies
        {
            get
            {
                return hobbies;
            }

            set
            {
                hobbies = value;
            }
        }

        public string FreeText
        {
            get
            {
                return freeText;
            }

            set
            {
                freeText = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string Clean
        {
            get
            {
                return clean;
            }

            set
            {
                clean = value;
            }
        }
    }
}
