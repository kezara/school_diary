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
    [Authorize(Roles = "admins")]
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IDepartmentsService departmentsService;
        public DepartmentsController(IDepartmentsService classRoomsService)
        {
            this.departmentsService = classRoomsService;
        }

        [Route("")]
        [ResponseType(typeof(IEnumerable<DepartmentDTOOut>))]
        public IHttpActionResult GetAllClasses()
        {
            logger.Info("Getting all departments");
            IEnumerable<DepartmentDTOOut> departments = departmentsService.GetAllDepartments();
            return Ok(departments);
        }

        [Route("{id}")]
        [ResponseType(typeof(DepartmentDTOOutSingle))]
        public IHttpActionResult GetDepartmentByID(int id)
        {
            logger.Info("Getting all departments");
            DepartmentDTOOutSingle departments = departmentsService.GetDepartmentByID(id);
            return Ok(departments);
        }

        [Route("")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostClassRoom(DepartmentDTOIn classRoom)
        {
             DepartmentDTOCreated classCreated = departmentsService.CreateDepartment(classRoom);
             return Created("", classCreated);
           
        }

        [Route("{id}")]
        [ResponseType(typeof(DepartmentDTOUpdateOut))]
        public IHttpActionResult PutClassRoom(int id, DepartmentDTOStudent updtClass)
        {
            if (id != updtClass.Id)
            {
                return BadRequest("Id does not match");
            }
            logger.Info($"accessing department service for updating of department id {id}");
            DepartmentDTOUpdateOut classUpdated = departmentsService.UpdateDepartment(id, updtClass);
                
            return Ok(classUpdated);
        }

        [Route("{id}")]
        [ResponseType(typeof(DepartmentDTOOutSingle))]
        public IHttpActionResult DeleteClass(int id)
        {
            logger.Info($"accessing department service for deleting of department id {id}");
            DepartmentDTOOutSingle classDeleted = departmentsService.DeleteDepartment(id);
            return Ok(classDeleted);
            
        }
    }
}
