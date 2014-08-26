

using System.Reflection;
using System;
using ReactiveUI;
namespace NewExample.ViewModel
{
    public class AppVersionCheckViewModel : ReactiveObject
    {
        public static string _appVersion;
        public string appVersion
        {
            get { return _appVersion; }
            set { this.RaiseAndSetIfChanged(x => x.appVersion, value); }
        }

        public static string _appName;
        public string appName
        {
            get { return _appName; }
            set { this.RaiseAndSetIfChanged(x => x.appName, value); }
        }


        public AppVersionCheckViewModel()
        {
            var nameHelper = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
            var sysVersion = nameHelper.Version;
            var full = nameHelper.FullName;
            var name = nameHelper.Name;

            appVersion = sysVersion.ToString();
            appName = name;

            Console.WriteLine("version==> " + sysVersion);
            Console.WriteLine("full==> " + full);
            Console.WriteLine("name==> " + name);
        }
    }
}
