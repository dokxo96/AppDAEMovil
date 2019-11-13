using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppDAEMovil.Views.Inventarios;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppDAEMovil
{
    public partial class App : Application
    {



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
