using Autofac;


using AppDAEMovil.ViewModels.Inventarios;
using AppDAEMovil.Interfaces.Inventarios;
using AppDAEMovil.Services.Inventarios;

namespace AppJDiegoMovil.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicContainer;

        public FicViewModelLocator()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            // Registrar cada uno de los ViewModels creados en el siguiente formato
            // builder.RegisterType<ViewModels>();
            builder.RegisterType<FicVmCatalogoSkuLista>();
            builder.RegisterType<FicVmCatUMedidaList>();
           
            // Servicios
            builder.RegisterType<FicSrvInventarioSKUList>().As<FicInterfaceSKULista>();
          

            if (FicContainer != null)
            {
                FicContainer.Dispose();
            }

            FicContainer = builder.Build();
        }

        // Crear los metodos que se mandan llamar desde el archivo xaml.cs de cada vista para
        // ligar el ViewModel con la vista
        public FicVmCatalogoSkuLista FicVmCatalogoSkuLista
        {
            get { return FicContainer.Resolve<FicVmCatalogoSkuLista>(); }
        }
        public FicVmCatUMedidaList FicVmCatUMedidaList
        {
            get { return FicContainer.Resolve<FicVmCatUMedidaList>(); }
        }
      
    }
}
