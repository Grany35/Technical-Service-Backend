using Autofac;
using Service.Business.Abstract;
using Service.Business.Concrete;
using Service.DataAccess.Abstract;
using Service.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PartManager>().As<IPartService>();
            builder.RegisterType<EfPartDal>().As<IPartDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<ServiceInformationManager>().As<IServiceInformationService>();
            builder.RegisterType<EfServiceInformationDal>().As<IServiceInformationDal>();
        }
    }
}
