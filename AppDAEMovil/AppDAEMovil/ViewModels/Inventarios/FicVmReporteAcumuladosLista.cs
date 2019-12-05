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

namespace AppDAEMovil.ViewModels.Inventarios
{
    public class FicVmReporteAcumuladosLista : INotifyPropertyChanged
    {
        private FicInterFaceReporteAcumuladosLista FicIFSrvReporteAcumuladosLista;
        private ObservableCollection<zt_inventarios_acumulados> FicOcSfDataGrid_ItemSource_Acumulado;
        public ObservableCollection<zt_inventarios_acumulados> FicSfDataGrid_ItemSource_Acumulado
        {
            get { return FicOcSfDataGrid_ItemSource_Acumulado; }
           
        }

        public FicVmReporteAcumuladosLista(FicInterFaceReporteAcumuladosLista FicPaIFSrvReporteAcumuladosLista)
        {
            FicIFSrvReporteAcumuladosLista = FicPaIFSrvReporteAcumuladosLista;
        }

        public void OnAppearing()
        {

        }

        public async void FicLoMetGetListaAcumulados(int FicPaIdInventario)
        {
            try
            {
                var FicListaAcumulados = await FicIFSrvReporteAcumuladosLista
                    .FicIMetGetListaAcumuladosWebApi(FicPaIdInventario);
                FicOcSfDataGrid_ItemSource_Acumulado = new ObservableCollection<zt_inventarios_acumulados>();
                foreach (zt_inventarios_acumulados acu in FicListaAcumulados)
                {
                    FicOcSfDataGrid_ItemSource_Acumulado.Add(acu);
                }
                RaisePropertyChanged("FicSfDataGrid_ItemSource_Acumulado");

            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", e.Message.ToString(), "Ok");
            }

        }

        #region  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

    
}
