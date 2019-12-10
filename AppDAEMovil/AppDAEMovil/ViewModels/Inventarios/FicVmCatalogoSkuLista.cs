using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using AppDAEMovil.Interfaces.Inventarios;
using AppDAEMovil.Models;
using AppJDiegoMovil.ViewModels.Base;
using Xamarin.Forms;

namespace AppDAEMovil.ViewModels.Inventarios
{
    public class FicVmCatalogoSkuLista : FicViewModelBase
    {


        public object FicNavigationContext { get; set; }

        private FicInterfaceSKULista FicInterFaceSKULista;
        public FicVmCatalogoSkuLista(FicInterfaceSKULista FicPaIFSrvSKULista)
        {
            FicInterFaceSKULista = FicPaIFSrvSKULista;
        }



        private ObservableCollection<zt_cat_productos> _FicSfDataGrid_ItemSource_Acumulado;
        public ObservableCollection<zt_cat_productos> FicSfDataGrid_ItemSource_Acumulado 
        { 
            get { return _FicSfDataGrid_ItemSource_Acumulado; }
            set {
                _FicSfDataGrid_ItemSource_Acumulado = value;
                RaisePropertyChanged();
            }
        }




        private zt_cat_productos _FicSfDataGrid_SelectItem_Acumulado;
        public zt_cat_productos SfDataGrid_SelectItem_Edificio
        {
            get { return _FicSfDataGrid_SelectItem_Acumulado; }
            set
            {
                _FicSfDataGrid_SelectItem_Acumulado = value;
                RaisePropertyChanged();
            }
        }



        private string _FicPickerFiltroSelected;

        public string FicPickerFiltroSelected
        {
            get { return _FicPickerFiltroSelected; }
            set
            {

                if (value != null)
                {
                    _FicPickerFiltroSelected = value;
                    RaisePropertyChanged("FicPickerFiltroSelected");
                }
            }
        }


        public async override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            var resultado = await FicInterFaceSKULista.FicMetGetSKUList();

            FicSfDataGrid_ItemSource_Acumulado = new ObservableCollection<zt_cat_productos>();

            foreach (var rest in resultado)
            {
                FicSfDataGrid_ItemSource_Acumulado.Add(rest);
            }
        }
       

        

    }
}
