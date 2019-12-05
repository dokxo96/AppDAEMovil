using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDAEMovil.Views.Inventarios;
using AppDAEMovil.ViewModels.Base;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppDAEMovil
{
    public partial class App : Application
    {
        //FIC: esto se agrega hasta el paso 23
        private static FicViewModelDependencyInjection _FicViewModelDependencyInjection;
        public static FicViewModelDependencyInjection FicViewModelDependencyInjection
        {
            get { return _FicViewModelDependencyInjection = _FicViewModelDependencyInjection ?? new FicViewModelDependencyInjection(); }
        }

        //FIC: Metodo Principal
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new MiPaginaContenido();
            MainPage = new FicViReporteAcumuladosLista();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
