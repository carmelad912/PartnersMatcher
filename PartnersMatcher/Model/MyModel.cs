using PartnersMatcher.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    public class MyModel
    {

        DataBaseService myDataBase;
        MyController controler;
        public MyModel(MyController c)
        {
            myDataBase = new DataBaseService();
            controler = c;
        }

       public void addUser(User u)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("PartnersMatchers@gmail.com");
            mail.To.Add(u.Email);
            mail.Subject = "Welcome to PartnersMatcher, " + u.FirstName;
            mail.Body = "the place where poeple come toghter";
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("PartnersMatchers", "Partners");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            if (!myDataBase.validateMail(u.Email))
                myDataBase.addNewUser(u);
        }

        public List<Advertisement> getAdvsResults(string city, string fields)
        {
            return myDataBase.getAdvsResults(city, fields);
        }

        public User connectUser(string email, string password)
        {
           return ( myDataBase.connectUser(email, password));
        }

        public void addNewAdvertisement(Advertisement adv)
        {
            myDataBase.addNewAdvertisement(adv);
        }
    }
}
