using NLog;
using school_diary.Models.DTOs;
using school_diary.Services;
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
    [Authorize]
    [RoutePrefix("api/marks")]
    public class MarksController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IMarksService marksService;
        public MarksController(IMarksService marksService)
        {
            this.marksService = marksService;
        }

        [Authorize(Roles = "admins, teachers")]
        [Route("")]
        [ResponseType(typeof(MarkDTOOut))]
        public IHttpActionResult PostMark(MarkDTOIn newMark)
        {
            //bool isAdmin = RequestContext.Principal.IsInRole("admins");
            //bool isTeacher = RequestContext.Principal.IsInRole("teachers");
            //bool isAuthenticated = RequestContext.Principal.Identity.IsAuthenticated;
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            if (role == "admins")
            {
                MarkDTOOut markAdmin = marksService.CreateMarkAdmin(userId, newMark);
                return Created("", markAdmin);
            }

            MarkDTOOut mark = marksService.CreateMarkTeacher(userId, newMark);
            return Created("", mark);
        }

        [Authorize(Roles = "admins, teachers, parents, students")]
        [Route("")]
        [ResponseType(typeof(MarkDTOOut))]
        public IHttpActionResult GetAllMarks()
        {
            string role = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == ClaimTypes.Role).Value;
            string userId = ((ClaimsPrincipal)RequestContext.Principal).FindFirst(x => x.Type == "UserId").Value;
            IEnumerable<MarkDTOOut> marks = marksService.GetAllMarks(role, userId);
            return Ok(marks);
        }
    }
}
