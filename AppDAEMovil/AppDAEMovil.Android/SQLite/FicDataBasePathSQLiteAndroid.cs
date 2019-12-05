using System.IO;
using AppDAEMovil.Droid.SQLite;
using AppDAEMovil.Interfaces.SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(FicDataBasePathSQLiteAndroid))]
namespace AppDAEMovil.Droid.SQLite
{
    public class FicDataBasePathSQLiteAndroid : IFicDataBasePathSQLite
    {
        public string FicGetDataBasePath()
        {
            var FicExternalPath = Android.OS.Environment.ExternalStorageDirectory +
                Java.IO.File.Separator + "DAETEC" + Java.IO.File.Separator + "DataBase";
            if (!Directory.Exists(FicExternalPath))
            {
                Directory.CreateDirectory(FicExternalPath);
            }
            FicExternalPath = FicExternalPath + Java.IO.File.Separator +
                FicAppSettings.FicDataBaseName;
            return FicExternalPath;
        }
    }
}