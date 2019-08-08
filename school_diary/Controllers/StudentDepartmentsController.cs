using NLog;
using school_diary.Models.DTOs;
using school_diary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    [Authorize(Roles = "admins")]
    [RoutePrefix("api/studentdepartments")]
    public class StudentDepartmentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IStudentDepartmentsService studentDepartmentsService;
        public StudentDepartmentsController(IStudentDepartmentsService studentDepartmentsService)
        {
            this.studentDepartmentsService = studentDepartmentsService;
        }

        [Route("")]
        [ResponseType(typeof(StudentDepartmentDTOenrolled))]
        public IHttpActionResult PostEnrollStudent(StudentDepartmentDTO student)
        {
            logger.Info("Enrolling student to department, studentdepartment service, Post enroll Student, studentdepartment controller");
            StudentDepartmentDTOenrolled studentEnrolled = studentDepartmentsService.CreateStudentDepartment(student);
            return Created("", studentEnrolled);
        }
    }
}
