using NLog;
using school_diary.Models;
using school_diary.Services;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    [RoutePrefix("api/users")]
    public class AppUsersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IAppUsersService appUsersService;

        public AppUsersController(IAppUsersService appUsersService)
        {
            this.appUsersService = appUsersService;
        }

        [Authorize(Roles = "admins")]
        [Route("admin")]
        [ResponseType(typeof(AppUser))]
        public IEnumerable<AppUser> GetAllUsers()
        {
            logger.Info("Admin gets all users");

            return appUsersService.GetAllUsers();
        }

        [Authorize(Roles = "admins")]
        [Route("admin/students")]
        [ResponseType(typeof(Student))]
        public IEnumerable<Student> GetAllStudents()
        {
            logger.Info("Admin gets all students");

            return appUsersService.GetAllStudents();
        }

        [Authorize(Roles = "admins")]
        [Route("admin/teachers")]
        [ResponseType(typeof(Teacher))]
        public IEnumerable<Teacher> GetAllTeachers()
        {
            logger.Info("Admin gets all teachers");

            return appUsersService.GetAllTeachers();
        }

        [Authorize(Roles = "admins")]
        [Route("admin/parents")]
        [ResponseType(typeof(Parent))]
        public IEnumerable<Parent> GetAllParents()
        {
            logger.Info("Admin gets all parents");

            return appUsersService.GetAllParents();
        }

        [Authorize(Roles = "admins")]
        [Route("admin/admins")]
        [ResponseType(typeof(Admin))]
        public IEnumerable<Admin> GetAllAdmins()
        {
            logger.Info("Admin gets all admins");

            return appUsersService.GetAllAdmins();
        }

        [Authorize(Roles = "admins")]
        [Route("admin/{username}")]
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult GetUserByUsername(string username)
        {
            logger.Info("Admin gets user by username");
            try
            {
                AppUser user = appUsersService.GetUserByUsername(username);
                return Ok(user);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "admins")]
        //[Route("")]
        //[ResponseType(typeof(AppUser))]
        //public IHttpActionResult PostUser(AppUser user)
        //{
        //    try
        //    {
        //        AppUser userCreated = appUsersService.CreateUser(user);
        //        return Created("", userCreated);
        //    }
        //    catch (UserNotFoundException)
        //    {

        //        return NotFound();

        //    }
        //}

        [Authorize(Roles = "admins")]
        [Route("{username}")]
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult PutUser(string username, AppUser updtUser)
        {
            if (!username.Equals(updtUser.UserName))
            {
                throw new BadRequestException();
            }

            try
            {
                AppUser userUpdated = appUsersService.UpdateUser(username, updtUser);
                if (userUpdated == null)
                {
                    return NotFound();
                }

                return Ok(userUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(AppUser))]
        public IHttpActionResult DeleteUser(string username)
        {
            try
            {
                AppUser userDeleted = appUsersService.DeleteUser(username);
                return Ok(userDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
