using PartnersMatcher.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class DataBaseService
    {
        OleDbConnection dbHandler;

        public DataBaseService()
        {
            
            // DB pathes
            string currentPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string reletivePath = @"\DB\pmDB.accdb";
            string pathDB = currentPath + reletivePath;
            // DB source
            //2013
            //dbHandler =new OleDbConnection( @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
            //2010
            dbHandler = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathDB + "; Persist Security Info=False");
        }
        /// <summary>
        /// add a new user to the DB
        /// </summary>
        /// <param name="newUser"> user's details</param>
        public void addNewUser(User newUser)
        {
            string firstName = newUser.FirstName;
            string lastName = newUser.LastName;
            string email = newUser.Email;
            if (validateMail(email))
                throw new Exception("Sorry. that mail adress is already in use");
            string phone = newUser.Phone;
            string pass = newUser.Password;
            string smoke = newUser.Smoke;
            string kosher = newUser.Kosher;
            string isMale = newUser.IsMale;
            string subscribed = newUser.Subscribed;
            string city = newUser.City;
            string age = newUser.Age;
            string shabat = newUser.Shabat;
            string animal = newUser.Animal;
            string noiseSens = newUser.NoiseSensitive;
            string clean = newUser.Clean;
            string hobbies = newUser.Hobbies;
            string more = newUser.FreeText;

            //query that inserts all user's fields into the DB 
            //string query = "insert into PartnersUsers (email,lastName,firstName,phone,password,smoke,kosher,isMale,subscribed,city,age,shabat,animal,noiseSens,clean,hobbies,more) values('" + email + "','" + lastName + "','" + firstName + "','" + phone + "','" + pass + "','" + smoke + "','" + kosher + "','" + isMale + "','" + subscribed + "','" + city + "','" + age + "','" + shabat + "','" + animal + "','" + noiseSens + "','" + clean + "','" + hobbies + "','" + more + "')";
            string sqlQuery = "insert into PartnersUsers values('" + email + "','" + lastName + "','" + firstName + "','" + phone + "','" + pass + "','" + smoke + "','" + kosher + "','" + isMale + "','" + subscribed + "','" + city + "','" + age + "','" + shabat + "','" + animal + "','" + noiseSens + "','" + clean + "','" + hobbies + "','" + more + "')";
            sendQuery(sqlQuery);
        }
        /// <summary>
        /// add a new advertisement to the DB
        /// </summary>
        /// <param name="ad">advertisement details</param>
        public void addNewAdvertisement(Advertisement adv)
        {
            // abstract fields
            string ownerMail = adv.Owner;
            int watched = adv.Watched;
            string location = adv.Location;
            DateTime datepublishedD=adv.Datepublished;
            string datePublished = datepublishedD.ToShortDateString();
            string descreption = adv.Description;

            string query= "";
            if (adv is SportAdvertisement)
            {
                SportAdvertisement sportAdv = (SportAdvertisement)adv;
                string level = sportAdv.Level;
                string type = sportAdv.Type;

                query = "insert into SportAdv values('" + ownerMail + "','" + watched + "','" + location + "','" + descreption + "','" + type + "','" + level + "','"  + datePublished + "')";
               

            }
            sendQuery(query);
        }

        /// <summary>
        /// get advertisements results from search
        /// </summary>
        /// <param name="location"> search location</param>
        /// <param name="category"> search catagory</param>
        /// <returns></returns>
        public List<Advertisement> getAdvsResults(string location, string category)
        {
            List<Advertisement> advList = null;

            try
            {
                dbHandler.Open();
                string query = "select manager,catagory,location,datepublished,descripition from advertisements where catagory = '" + category + "' and location= '" + location + "'";
                OleDbCommand command = new OleDbCommand(query, dbHandler);
                OleDbDataReader reader = command.ExecuteReader();
                advList = new List<Advertisement>();
                while (reader.Read()) // read data from every adv
                {
                    string adv_manager = reader.GetString(0);
                    string adv_catagory = reader.GetString(1);
                    string adv_location = reader.GetString(2);
                    string adv_date= reader.GetString(3);
                    string adv_description = reader.GetString(4);
            //        Advertisement newAdv = new Advertisement(adv_manager, adv_catagory, adv_location, adv_date, adv_description);
            //        advList.Add(newAdv);
                }
            }
            catch (Exception)
            {
                throw new Exception(" there is a connection problem ");
            }
            finally
            {
                dbHandler.Close();
            }

            return advList;
        }



        /// <summary>
        /// this function connects a user to the system
        /// </summary>
        /// <param name="userEmail"> user's email</param>
        /// <param name="userPassword">user's password</param>
        /// <returns> the user that connected</returns>
        public User connectUser(string userEmail, string password)
        {
            User user = null;
            string u_firstName = "";
            string u_lastName = "";
            string u_email = "";
            string u_phone = "";
            string u_password = "";
            string u_city = "";
            string u_isMale = "true";
            string u_subscribed = "true";
            string u_smoke = "true";
            string u_kosher = "true";
            string u_age = "";
            string u_animal = "true";
            string u_shabat = "true";
            string u_noiseSensitive = "true";
            string u_hobbies = "";
            string u_freeText = "";
            string u_clean = "";
            string errorMessege = "there is a connection problem";
            try
            {
                dbHandler.Open();
                string query = "select * from PartnersUsers where email = '" + userEmail + "'";
                OleDbCommand command = new OleDbCommand(query, dbHandler);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read()) // start reading user's fields from db
                {
                    u_email = reader.GetString(0);
                    u_lastName = reader.GetString(1);
                    u_firstName = reader.GetString(2);
                    u_phone = reader.GetString(3);
                    u_password = reader.GetString(4);
                    u_smoke = reader.GetString(5);
                    u_kosher = reader.GetString(6);
                    u_isMale = reader.GetString(7);
                    u_subscribed = reader.GetString(8);
                    u_city = reader.GetString(9);
                    u_age = reader.GetString(10);
                    u_shabat = reader.GetString(11);
                    u_animal = reader.GetString(12);
                    u_noiseSensitive = reader.GetString(13);
                    u_clean = reader.GetString(14);
                    u_hobbies = reader.GetString(15);
                    u_freeText = reader.GetString(16);
                }
                if (u_password != password)
                    errorMessege = "Wrong password!";
                else
                {
                    user = new User(u_firstName, u_lastName, u_email, u_phone, u_password,u_city, u_isMale, u_subscribed, u_smoke, u_kosher, u_age, u_shabat, u_animal, u_noiseSensitive, u_hobbies, u_freeText, u_clean);
                }
            }
            catch (Exception)
            {
                throw new Exception(errorMessege);
            }
            finally
            {
                dbHandler.Close();
            }
            return user;
        }

        /// <summary>
        /// generic query send to the access DB
        /// </summary>
        /// <param name="query"> sql query to send</param>
        private void sendQuery(string query)
        {
            try
            {
                dbHandler.Open();
                OleDbCommand command = new OleDbCommand(query, dbHandler);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                dbHandler.Close(); // close connection with db anyway
            }
        }

        public bool validateMail(string email)
        {
            bool toReturn = false;
            string query = "select email from PartnersUsers where email = '" + email + "'";

            try
            {
                dbHandler.Open();
                OleDbCommand command = new OleDbCommand(query, dbHandler);
                OleDbDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                    toReturn = true;
            }
            catch (Exception)
            {
                throw new Exception("there is a connection problem");
            }
            finally
            {
                dbHandler.Close();
            }
            return toReturn;
        }
    }


}
