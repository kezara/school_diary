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
    [RoutePrefix("api/admin")]
    public class AdminsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IAdminsService adminsService;
        public AdminsController(IAdminsService adminsService)
        {
            this.adminsService = adminsService;
        }

        [Route("")]
        public IEnumerable<Admin> GetAllAdmins()
        {
            logger.Info("Getting all admins");
            return adminsService.GetAllAdmins();
        }

        [Route("")]
        [ResponseType(typeof(Admin))]
        public IHttpActionResult PostAdmin(Admin admin)
        {
            try
            {
                Admin adminCreated = adminsService.CreateAdmin(admin);
                return Created("", adminCreated);
            }
            catch (UserNotFoundException)
            {

                return NotFound();

            }
        }

        [Route("{id}")]
        [ResponseType(typeof(Admin))]
        public IHttpActionResult PutAdmin(int id, Admin updtAdmin)
        {
            try
            {
                Admin adminUpdated = adminsService.UpdateAdmin(id, updtAdmin);
                if (adminUpdated == null)
                {
                    return NotFound();
                }

                return Ok(adminUpdated);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Route("{id}")]
        [ResponseType(typeof(Admin))]
        public IHttpActionResult DeleteAdmin(int id)
        {
            try
            {
                Admin adminDeleted = adminsService.DeleteAdmin(id);
                return Ok(adminDeleted);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
