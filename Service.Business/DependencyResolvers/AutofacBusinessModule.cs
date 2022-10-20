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

            builder.RegisterType<CustomerManager>().As<ICustomerDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
        }
    }
}
