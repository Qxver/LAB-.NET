using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Zadanie_03
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;

            // Nazwa musi być dokładnie taka sama jak w pliku Service1.cs!
            serviceInstaller.ServiceName = "Service1";

            // To nazwa i opis, które zobaczysz na liście w menedżerze usług Windows
            serviceInstaller.DisplayName = "Zadanie 3 - Service1 Działająca w Tle";
            serviceInstaller.Description = "Przykładowa niewizualna usługa systemu Windows (Service1).";

            serviceInstaller.StartType = ServiceStartMode.Manual;

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}