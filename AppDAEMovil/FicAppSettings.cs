using System;
using System.Collections.Generic;
using System.Text;

namespace AppDAEMovil
{
    public class FicAppSettings
    {
        public static string FicDataBaseName = "DB_DAE_TEC.db3";
        //public static cat_usuarios FicUserConnect { get; set; }
        //public static rh_cat_personas FicUserPersona { get; set; }
        //public static List<seg_roles_usuarios> FicUserRoles { get; set; }
        //public static string FicUrlBase { get => "http://localhost:60304/"; set { } }
        public static string FicUrlBase { get => "http://:9091/AppDAEREST/"; set { } }
    }
}
