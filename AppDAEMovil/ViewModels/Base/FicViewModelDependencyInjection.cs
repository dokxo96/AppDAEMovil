
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
            FicContainerBuilder.RegisterType<FicVmReporteAcumuladosLista>();
            FicContainerBuilder.RegisterType<FicSrvReporteAcumuladosLista>().As <FicInterFaceReporteAcumuladosLista>().SingleInstance();
            
            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }
        public FicVmReporteAcumuladosLista FicVmReporteAcumuladosLista { get { return FicIContainer.Resolve<FicVmReporteAcumuladosLista>(); } }

        
    }//CLASS
}//NAMESPACE
