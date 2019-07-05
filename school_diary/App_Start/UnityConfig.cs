using school_diary.Models;
using school_diary.Repositories;
using school_diary.Services;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace school_diary
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IGenericRepository<ExampleModel>, GenericRepository<ExampleModel>>();
            container.RegisterType<IGenericRepository<ClassRoom>, GenericRepository<ClassRoom>>();
            //container.RegisterType<IGenericRepository<OfferModel>, GenericRepository<OfferModel>>();
            //container.RegisterType<IGenericRepository<BillModel>, GenericRepository<BillModel>>();
            //container.RegisterType<IGenericRepository<VoucherModel>, GenericRepository<VoucherModel>>();
            container.RegisterType<DbContext, DataAccessContext>(new HierarchicalLifetimeManager());
            //container.RegisterType<IExampleService, ExampleService>();
            container.RegisterType<IClassRoomsService, ClassRoomsService>();
            //container.RegisterType<IOffersService, OffersService>();
            //container.RegisterType<IBillsService, BillsService>();
            //container.RegisterType<IVouchersService, VouchersService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}