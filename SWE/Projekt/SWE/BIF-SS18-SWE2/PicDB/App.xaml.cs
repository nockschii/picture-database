using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BIF.SWE2.Interfaces;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IApplication
    {
        void IApplication.HelloWorld()
        {
            // I'm here, that's fine
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            BusinessLayer BL = new BusinessLayer(DALFactory.CreateDAL());
            BL.Sync();
        }
    }
}
