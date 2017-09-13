using PartnersMatcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Controller
{
    public class MyController
    {

        MyModel model;
        MainWindow view;
        public void setModel(MyModel m) { model = m; }
        public void setView(MainWindow v) { view = v; }

        public void addUser(User u)
        {
            model.addUser(u);
        }

        public User connectUser(string email, string password)
        {
            return model.connectUser(email, password);
        }

        public List<Advertisement> getAdvsResults(string city, string field)
        {
            return model.getAdvsResults(city, field);
        }

        public void addNewAdvertisement(Advertisement a)
        {
                       
            model.addNewAdvertisement(a);
        }

    }
}
