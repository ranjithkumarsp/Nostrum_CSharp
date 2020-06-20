using log4net;
using log4net.Appender;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nostrum
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));
        protected override void OnStartup(StartupEventArgs e)
        {


            //log4net.Config.XmlConfigurator.Configure();            
            FileInfo log4NetConfigFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Nostrum.exe.config");
            log4net.Config.XmlConfigurator.Configure(log4NetConfigFile);
            log.Info("Config File Loaded..");
            // log.Info("        =============  Started Logging  =============        ");
            base.OnStartup(e);
            //log.Info("        =============  Ended Logging  =============        ");
        }
    }
}
