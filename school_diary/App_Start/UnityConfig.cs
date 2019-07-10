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
            container.RegisterType<IGenericRepository<Admin>, GenericRepository<Admin>>();
            container.RegisterType<IGenericRepository<ClassRoom>, GenericRepository<ClassRoom>>();
            container.RegisterType<IGenericRepository<Grade>, GenericRepository<Grade>>();
            container.RegisterType<IGenericRepository<Parent>, GenericRepository<Parent>>();
            container.RegisterType<IGenericRepository<Student>, GenericRepository<Student>>();
            container.RegisterType<IGenericRepository<Subject>, GenericRepository<Subject>>();
            container.RegisterType<IGenericRepository<Teach>, GenericRepository<Teach>>();
            container.RegisterType<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
            container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
            container.RegisterType<DbContext, DataAccessContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAdminsService, AdminsService>();
            container.RegisterType<IClassRoomsService, ClassRoomsService>();
            container.RegisterType<IGradesService, GradesService>();
            container.RegisterType<IParentsService, ParentsService>();
            container.RegisterType<IStudentsService, StudentsService>();
            container.RegisterType<ISubjectsService, SubjectsService>();
            container.RegisterType<ITeachsService, TeachsService>();
            container.RegisterType<ITeachersService, TeachersService>();
            container.RegisterType<IUsersService, UsersService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}