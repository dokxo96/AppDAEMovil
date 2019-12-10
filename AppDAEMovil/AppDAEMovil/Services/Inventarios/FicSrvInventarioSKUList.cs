using AppDAEMovil.Data;
using AppDAEMovil.Interfaces.Inventarios;
using AppDAEMovil.Interfaces.SQLite;
using AppDAEMovil.Models;
using AppDAEMovil.Helpers;
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
        private readonly FicDBContext FicLoBDContext;
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        public FicSrvInventarioSKUList() {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicDataBasePathSQLite>().FicGetDataBasePath());
        }//contructor
        public async Task<IList<zt_cat_productos>> FicMetGetSKUList()
        {
            var items = new List<zt_cat_productos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var resultado = await (from FicCED in FicLoBDContext.zt_cat_productos
                                       select FicCED).AsNoTracking().ToListAsync();
                resultado.ToList().ForEach(x => items.Add(x));
            }
            return items;
        }

        public async Task<IList<zt_cat_UMedida>> FicMetGetUMedidaList()
        {
            var items = new List<zt_cat_UMedida>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var resultado = await(from FicCED in FicLoBDContext.zt_cat_UMedida
                                      select FicCED).AsNoTracking().ToListAsync();
                resultado.ToList().ForEach(x => items.Add(x));
            }
            return items;
        }
    }
    }

