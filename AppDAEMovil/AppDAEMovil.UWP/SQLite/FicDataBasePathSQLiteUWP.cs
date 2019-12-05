using AppDAEMovil.Interfaces.SQLite;
using AppDAEMovil.UWP.SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicDataBasePathSQLiteUWP))]
namespace AppDAEMovil.UWP.SQLite
{
    public class FicDataBasePathSQLiteUWP : IFicDataBasePathSQLite
    {

        public string FicGetDataBasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, FicAppSettings.FicDataBaseName);
        }//This method obtains the physical rout of the database on the device

    }
}
