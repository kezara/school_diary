using NLog;
using school_diary.Models;
using school_diary.Services;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    public class UsersController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Route("")]
        public IEnumerable<User> GetAllUsers()
        {
            logger.Info("Getting all users");
            return usersService.GetAllUsers();
        }

        [Route("")]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            try
            {
                User userCreated = usersService.CreateUser(user);
                return Created("", userCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult PutUser(int id, User updtUser)
        {
            try
            {
                User userUpdated = usersService.UpdateUser(id, updtUser);
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
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                User userDeleted = usersService.DeleteUser(id);
                return Ok(userDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
