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
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    [RoutePrefix("api/grades")]
    public class GradesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IGradeService gradesService;
        public GradesController(IGradeService gradesService)
        {
            this.gradesService = gradesService;
        }

        //Authorize(Roles = "admins")]
        [Route("")]
        public IHttpActionResult GetAllGrades()
        {
            logger.Info("Getting all Marks");
            IEnumerable<GradeDTOOut> grades = gradesService.GetGrades();
            return Ok(grades);
        }

        //[Authorize(Roles = "admins")]
        //[Authorize(Roles = "teachers")]
        //[Authorize(Roles = "students")]
        //[Authorize(Roles = "parents")]
        //[Route("by-username/{username}")]
        //public IHttpActionResult GetGradesByUserName(string username)
        //{
        //    try
        //    {
        //        IEnumerable<MarkDTO> grade = gradesService.GetMarkByStudentUserName(username);
        //        return Ok(grade);
        //    }
        //    catch (UserNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //[Route("by-name/{name}")]
        //public IHttpActionResult GetGradesByName(string name)
        //{
        //    try
        //    {
        //        IEnumerable<Grade> grade = gradesService.GetGradeByStudentName(name);
        //        return Ok(grade);
        //    }
        //    catch (UserNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //[Route("by-lastname/{lastName}")]
        //public IHttpActionResult GetGradesByLastName(string lastName)
        //{
        //    try
        //    {
        //        IEnumerable<Grade> grade = gradesService.GetGradeByStudentLastName(lastName);
        //        return Ok(grade);
        //    }
        //    catch (UserNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //[Route("")]
        //[ResponseType(typeof(Mark))]
        //public IHttpActionResult PostGrade(Mark grade)
        //{
        //    try
        //    {
        //        Mark gradeCreated = gradesService.CreateMark(grade);
        //        return Created("", gradeCreated);
        //    }
        //    catch (UserNotFoundException)
        //    {

        //        return NotFound();

        //    }
        //}

        //[Route("{id}")]
        //[ResponseType(typeof(Grade))]
        //public IHttpActionResult PutGrade(string username, Grade updtGrade)
        //{
        //    try
        //    {
        //        Grade gradeUpdated = gradesService.UpdateGrade(username, updtGrade);
        //        if (gradeUpdated == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(gradeUpdated);
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }

        //}

        //[Route("{id}")]
        //[ResponseType(typeof(Grade))]
        //public IHttpActionResult DeleteGrade(string username)
        //{
        //    try
        //    {
        //        Grade gradeDeleted = gradesService.DeleteGrade(username);
        //        return Ok(gradeDeleted);
        //    }
        //    catch (UserNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
