using NLog;
using school_diary.Models;
using school_diary.Models.DTOs;
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
    [Authorize(Roles = "admins")]
    [RoutePrefix("api/users")]
    public class AppUsersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IAppUsersService appUsersService;

        public AppUsersController(IAppUsersService appUsersService)
        {
            this.appUsersService = appUsersService;
        }
             
        //GET all users
        [Route("")]
        [ResponseType(typeof(IEnumerable<AppUserDTOOut>))]
        public IHttpActionResult GetAllUsers()
        {

            logger.Info("Admin gets all users, appuserscontroller");
            IEnumerable<AppUserDTOOut> appUsersDTOOut = appUsersService.GetAllUsers();
            return Ok(appUsersDTOOut);
        }

        //GET user by ID
        [Route("{id}")]
        [ResponseType(typeof(AppUserDTOOut))]
        public IHttpActionResult GetUserByID(string id)
        {
            logger.Info("Admin gets user by id, appuserscontroller");
            AppUserDTOOut user = appUsersService.GetUserById(id);
            return Ok(user);
        }

        //GET user by username
        [Route("by-username/{username}")]
        [ResponseType(typeof(AppUserDTOOut))]
        public IHttpActionResult GetUserByUsername(string username)
        {
            logger.Info("Admin gets user by username, appuserscontroller");
            AppUserDTOOut user = appUsersService.GetUserByUsername(username);
            return Ok(user);
        }

        //GET user by name
        [Route("by-name/{name}")]
        [ResponseType(typeof(IEnumerable<AppUserDTOOut>))]
        public IHttpActionResult GetUserByName(string name)
        {
            logger.Info($"Admin gets user by name {name}, appuserscontroller");
            IEnumerable<AppUserDTOOut> user = appUsersService.GetUserByName(name);
            return Ok(user);
        }

        //GET user by last name
        [Route("by-lastname/{lastName}")]
        [ResponseType(typeof(IEnumerable<AppUserDTOOut>))]
        public IHttpActionResult GetUserByLastName(string lastName)
        {
            logger.Info($"Admin gets user by lastname {lastName}, appuserscontroller");
            IEnumerable<AppUserDTOOut> user = appUsersService.GetUserBySurname(lastName);
            return Ok(user);
        }

        //GET user by name and last name
        [Route("by-name-lastname")]
        [ResponseType(typeof(IEnumerable<AppUserDTOOut>))]
        public IHttpActionResult GetUserByNameLastName([FromUri] string name, [FromUri] string lastName)
        {
            logger.Info($"Admin gets user by name {name} and lastname {lastName}, appuserscontroller");
            IEnumerable<AppUserDTOOut> user = appUsersService.GetUserByNameLastName(name, lastName);
            return Ok(user);
        }

        //[Authorize(Roles = "admins")]
        //[Route("{username}")]
        //[ResponseType(typeof(AppUserDTOOut))]
        //public IHttpActionResult PutUser(string username, AppUser updtUser)
        //{
        //    if (!username.Equals(updtUser.UserName))
        //    {
        //        throw new BadRequestException();
        //    }

        //    try
        //    {
        //        AppUserDTOOut userUpdated = appUsersService.UpdateUser(username, updtUser);
        //        if (userUpdated == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(userUpdated);
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }

        //}
    }
}
