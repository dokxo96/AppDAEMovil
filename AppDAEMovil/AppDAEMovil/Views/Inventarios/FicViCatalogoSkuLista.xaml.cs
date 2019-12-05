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
        public FicViCatalogoSkuLista()
        {
            InitializeComponent();

           
        }

        private void FicSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }
    }
}