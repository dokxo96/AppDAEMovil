using AppDAEMovil.Data;
using AppDAEMovil.Interfaces.Inventarios;
using AppDAEMovil.Interfaces.SQLite;
using AppDAEMovil.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDAEMovil.Services.Inventarios
{
    
    public class FicSrvInventarioSKUList : FicInterfaceSKULista
    {
        private readonly FicDBContext FicLocalDBContext;

        public FicSrvInventarioSKUList() {
            FicLocalDBContext = new FicDBContext(DependencyService.Get<IFicDataBasePathSQLite>().FicGetDataBasePath());
        }//contructor
        public async Task<IList<zt_cat_productos>> FicMetGetSKUList()
        {
            return await (from conteo in FicLocalDBContext.zt_cat_productos
                             select conteo).AsNoTracking().ToListAsync();
        }

       

       
    }
    }

