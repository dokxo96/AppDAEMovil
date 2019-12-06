using AppDAEMovil.ViewModels.Inventarios;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDAEMovil.Views.Inventarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicViCatalogoSkuLista : ContentPage
    {
        private object FicNavigationContext { get; set; }
        public FicViCatalogoSkuLista()
        {
           
            
            
            BindingContext = App.FicViewModelDependencyInjection.FicVmCatalogoSkuLista;
            

        }
        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatalogoSkuLista;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();

            }
        }


            private void DataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 && e.CellValue == null)
                {
                    e.Style.BackgroundColor = Color.IndianRed;
                    e.Style.ForegroundColor = Color.White;
                }
                else if (e.ColumnIndex == 4 && int.Parse(e.CellValue.ToString()) >= 0)
                {
                    e.Style.BackgroundColor = Color.YellowGreen;
                    e.Style.ForegroundColor = Color.White;
                }

                e.Handled = true;
            }
            catch
            {
                if (e.ColumnIndex == 4)
                {
                    e.Style.BackgroundColor = Color.IndianRed;
                    e.Style.ForegroundColor = Color.White;
                    e.Handled = true;
                }
            }
        }
    }
}