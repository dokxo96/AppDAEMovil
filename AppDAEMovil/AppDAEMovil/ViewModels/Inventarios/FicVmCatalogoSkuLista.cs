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
using Xamarin.Forms;

namespace AppDAEMovil.ViewModels.Inventarios
{
    public class FicVmCatalogoSkuLista : INotifyPropertyChanged
    {
        public object FicNavigationContext { get; set; }

        private FicInterfaceSKULista FicInterFaceSKULista;

        private ObservableCollection<zt_cat_productos> _FicSfDataGrid_ItemSource_Acumulado;
        private zt_cat_productos _FicSfDataGrid_SelectItem_Acumulado;
        public event PropertyChangedEventHandler PropertyChanged;
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
        public zt_cat_productos FicSfDataGrid_SelectItem_Acumulado
        {
            get { return _FicSfDataGrid_SelectItem_Acumulado; }
            set
            {
                if (value != null)
                {
                    _FicSfDataGrid_SelectItem_Acumulado = value;
                    RaisePropertyChanged("FicSfDataGrid_SelectItem_Acumulado");
                }
            }
        }

        public ObservableCollection<zt_cat_productos> FicSfDataGrid_ItemSource_Acumulado { get { return _FicSfDataGrid_ItemSource_Acumulado; } }
        private ICommand _FicMetListaConteoICommand, _DoubleTappedCommandAction;



        private FicInterfaceSKULista FicInterfaceSKULista;





        public FicVmCatalogoSkuLista(FicInterfaceSKULista FicPaIFSrvSKULista)
        {
            this.FicInterfaceSKULista = FicPaIFSrvSKULista;
        }

       
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void OnAppearing()
        {
            try
            {
                var FicSourceZt_Inventarios = FicNavigationContext as zt_cat_productos;

                _FicSfDataGrid_ItemSource_Acumulado = new ObservableCollection<zt_cat_productos>();

                foreach (zt_cat_productos au in await FicInterfaceSKULista.FicMetGetSKUList(FicSourceZt_Inventarios.idSKU))
                {
                    _FicSfDataGrid_ItemSource_Acumulado.Add(au);
                }

                RaisePropertyChanged("FicSfDataGrid_ItemSource_Acumulado");

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//OnAppearing()

        public async void FicMetFiltroSKU()
        {
            try
            {
                var FicSourceZt_Inventarios = FicNavigationContext as zt_cat_productos;
                _FicSfDataGrid_ItemSource_Acumulado = new ObservableCollection<zt_cat_productos>();
                ObservableCollection<zt_cat_productos> FicSinConteo = new ObservableCollection<zt_cat_productos>();
                ObservableCollection<zt_cat_productos> FicConConteo = new ObservableCollection<zt_cat_productos>();

                foreach (zt_cat_productos au in await FicInterfaceSKULista.FicMetGetSKUList(FicSourceZt_Inventarios.idSKU))
                {
                    _FicSfDataGrid_ItemSource_Acumulado.Add(au);
                   
                }

               
                RaisePropertyChanged("FicSfDataGrid_ItemSource_Acumulado");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
    }
}
