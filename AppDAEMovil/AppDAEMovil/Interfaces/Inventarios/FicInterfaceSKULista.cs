
using AppDAEMovil.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace AppDAEMovil.Interfaces.Inventarios
{
    public interface FicInterfaceSKULista
    {
        Task<IList<zt_cat_productos>> FicMetGetSKUList();
    }
}
