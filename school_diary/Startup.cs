using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using school_diary.Filters;
using school_diary.Infrastructure;
using school_diary.Models;
using school_diary.Providers;
using school_diary.Repositories;
using school_diary.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

[assembly: OwinStartup(typeof(school_diary.Startup))]
namespace school_diary
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            UnityContainer container = SetupUnity();
            ConfigureOAuth(app, container);

            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityDependencyResolver(container);
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "dd.MM.yyyy";
            //config.Filters.Add(new UserNotFoundExceptionFilterAttribute());
            //config.Filters.Add(new ValidateModelAttribute());
            

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, UnityContainer container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(container)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private UnityContainer SetupUnity()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<DbContext, AuthContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IGenericRepository<Admin>, GenericRepository<Admin>>();
            container.RegisterType<IGenericRepository<Parent>, GenericRepository<Parent>>();
            container.RegisterType<IGenericRepository<Student>, GenericRepository<Student>>();
            container.RegisterType<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
            container.RegisterType<IGenericRepository<Grade>, GenericRepository<Grade>>();
            container.RegisterType<IGenericRepository<StudentDepartment>, GenericRepository<StudentDepartment>>();
            container.RegisterType<IAuthRepository, AuthRepository>();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IGenericRepository<Department>, GenericRepository<Department>>();
            container.RegisterType<IGenericRepository<Mark>, GenericRepository<Mark>>();
            container.RegisterType<IGenericRepository<Subject>, GenericRepository<Subject>>();
            container.RegisterType<IGenericRepository<Teach>, GenericRepository<Teach>>();
            container.RegisterType<IGenericRepository<AppUser>, GenericRepository<AppUser>>();
            container.RegisterType<DbContext, AuthContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentsService, DepartmentsService>();
            container.RegisterType<IMarksService, MarksService>();
            container.RegisterType<IAdminsService, AdminsService>();
            container.RegisterType<IParentsService, ParentsService>();
            container.RegisterType<IStudentsService, StudentsService>();
            container.RegisterType<ISubjectsService, SubjectsService>();
            container.RegisterType<ITeachesService, TeachesService>();
            container.RegisterType<ITeachersService, TeachersService>();
            container.RegisterType<IStudentDepartmentsService, StudentDepartmentsService>();
            container.RegisterType<IAppUsersService, AppUsersService>();
            container.RegisterType<IGradeService, GradeService>();

            return container;
        }
    }
}