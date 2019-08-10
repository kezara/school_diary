using NLog;
using school_diary.Filters;
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
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    [Authorize(Roles = "admins")]
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
        [ResponseType(typeof(IEnumerable<AdminDTOOutUp>))]
        public IHttpActionResult GetAllAdmins()
        {
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            logger.Info($"Admin {userId} Getting all admins, controller");
            IEnumerable<AdminDTOOutUp> adminsDTOOut = adminsService.GetAllAdmins();
            return Ok(adminsDTOOut);

        }

        [Route("{id}")]
        [ResponseType(typeof(AdminDTOOutUp))]
        public IHttpActionResult GetAdminByID(string id)
        {
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;

            logger.Info($"Admin {userId} Getting admin by admin ID, controller");
            return Ok(adminsService.GetAdminById(id));

        }

        [Route("admin-by-username/{username}")]
        [ResponseType(typeof(AdminDTOOutUp))]
        public IHttpActionResult GetAdminByUsername(string username)
        {
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;

            logger.Info($"Admin {userId} Getting admin by admin UserName, controller");
            return Ok(adminsService.GetAdminByUserName(username));

        }

        [Route("admin-name/{name}")]
        [ResponseType(typeof(IEnumerable<AdminDTOOutUp>))]
        public IHttpActionResult GetAdminByName(string name)
        {
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;

            logger.Info($"Admin {userId} Getting admin by admin Name, controller");
            return Ok(adminsService.GetAdminByName(name));

        }

        [Route("admin-lastname/{lastname}")]
        [ResponseType(typeof(IEnumerable<AdminDTOOutUp>))]
        public IHttpActionResult GetAdminByLastName(string lastName)
        {
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;

            logger.Info($"Admin {userId} Getting admin by admin last name, controller");
            return Ok(adminsService.GetAdminByLastName(lastName));

        }

        [Route("admin-name-lastname")]
        [ResponseType(typeof(IEnumerable<AdminDTOOutUp>))]
        public IHttpActionResult GetAdminByNameLastName(string name, string lastName)
        {
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;

            logger.Info($"Admin {userId} Getting admin by admin name and last name, controller");
            return Ok(adminsService.GetAdminByNameLastName(name, lastName));

        }

        [Route("{id}")]
        [ResponseType(typeof(AdminDTOOutUp))]
        public IHttpActionResult DeleteAdmin(string id)
        {
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;

            logger.Info($"Admin {userId} deletes admin");
            AdminDTOOutUp adminDeleted = adminsService.DeleteAdmin(id);
            return Ok(adminDeleted);
        }
    }
}
