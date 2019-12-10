
using AppDAEMovil.Interfaces.Inventarios;
using AppDAEMovil.Services.Inventarios;
//using AppDAEMovil.Services.Navigation;
using AppDAEMovil.ViewModels.Inventarios;
using Autofac;

namespace AppDAEMovil.ViewModels.Base
{
    public class FicViewModelDependencyInjection
    {
        private static IContainer FicIContainer;

        public FicViewModelDependencyInjection()
        {
            var FicContainerBuilder = new ContainerBuilder();
            FicContainerBuilder.RegisterType<FicVmCatalogoSkuLista>();
            FicContainerBuilder.RegisterType<FicSrvInventarioSKUList>().As<FicInterfaceSKULista>().SingleInstance();

            FicContainerBuilder.RegisterType<FicVmReporteAcumuladosLista>();
            FicContainerBuilder.RegisterType<FicSrvReporteAcumuladosLista>().As <FicInterFaceReporteAcumuladosLista>().SingleInstance();

            FicContainerBuilder.RegisterType<FicVmCatUMedidaList>();
            FicContainerBuilder.RegisterType<FicSrvInventarioSKUList>().As<FicInterfaceSKULista>().SingleInstance();


            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }
        public FicVmReporteAcumuladosLista FicVmReporteAcumuladosLista { get { return FicIContainer.Resolve<FicVmReporteAcumuladosLista>(); } }

        public FicVmCatalogoSkuLista FicVmCatalogoSkuLista { get { return FicIContainer.Resolve<FicVmCatalogoSkuLista>(); } }

        public FicVmCatUMedidaList FicVmCatUMedidaList { get { return FicIContainer.Resolve<FicVmCatUMedidaList>(); } }
    }//CLASS
}//NAMESPACE
