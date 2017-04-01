using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UltraTT.View;
using UttUserService.Security;

namespace UltraTT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            //Create a custom principal with an anonymous identity at startup
            UttPrincipal customPrincipal = new UttPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);

        }

        public void AppStart(object sender, StartupEventArgs e)
        {
            var window = new HostWindowView();
            MainWindow = window;
            window.Show();

            Navigator.GetInstance().Start(window);
        }
    }
}
