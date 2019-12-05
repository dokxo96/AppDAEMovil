using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDAEMovil.ViewModels.Inventarios;

namespace AppDAEMovil.Views.Inventarios
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViReporteAcumuladosLista : ContentPage
	{
		public FicViReporteAcumuladosLista ()
		{
            BindingContext = App.FicViewModelDependencyInjection.FicVmReporteAcumuladosLista;
			InitializeComponent ();
          
        }

        protected override void OnAppearing()
        {
            
        }
        
        void FicButton_Clicked_Consultar(object sender, EventArgs args)
        {
           
            int FicIdInventario = Convert.ToInt32(FicEntry_IdInventario.Text);

            (BindingContext as FicVmReporteAcumuladosLista).FicLoMetGetListaAcumulados( FicIdInventario );
            
           
        }

       
        async void FicButton_Clicked_Cancelar(object sender, EventArgs args)
        {
           
        }
    }
}