using System;
using System.IO;
using AppDAEMovil.Interfaces.SQLite;
using AppDAEMovil.iOS.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicDataBasePathSQLiteiOS))]
namespace AppDAEMovil.iOS.SQLite
{
    public class FicDataBasePathSQLiteiOS : IFicDataBasePathSQLite
    {
        public string FicGetDataBasePath()
        {
            string libFolder = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Databases");

            if (!Directory.Exists(libFolder)) Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, FicAppSettings.FicDataBaseName);
        }//This method obtains the physical rout of the database on the device
    }
}