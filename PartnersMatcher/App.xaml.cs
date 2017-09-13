using PartnersMatcher.Controller;
using PartnersMatcher.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MyController controller = new MyController();
            MyModel model = new MyModel(controller);
            controller.setModel(model);
            MainWindow mw= new MainWindow(controller);
            controller.setView(mw);
        }

    }
}
