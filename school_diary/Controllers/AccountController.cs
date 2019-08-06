using NLog;
using school_diary.Models.DTOs;
using school_diary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace school_diary.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IUserService service;

        public AccountController(IUserService userService)
        {
            this.service = userService;
        }

        [Route("change-role/{id}")]
        [ResponseType(typeof(AppUserDTOOut))]
        public async Task<IHttpActionResult> PutRole(string id, AppUserDTOIn userModel)
        {
            if (!id.Equals(userModel.Id))
            {
                logger.Info("Id does not match, put parent, account controller");
                return BadRequest("Id not match");
            }

            logger.Info($"User {userModel.UserName} sent to user service, put role");
            var updatedRole = await service.UpdateRole(id, userModel);

            if (updatedRole == null)
            {
                logger.Info($"User role {userModel.UserName} has not been updated. Update failed, put role.");
                return NotFound();
            }

            return Ok(updatedRole);
        }


        [Route("update-parent/{id}")]
        [ResponseType(typeof(ParentDTOOut))]
        public async Task<IHttpActionResult> PutParent(string id, ParentDTOInUp userModel)
        {
            if (!id.Equals(userModel.Id))
            {
                logger.Info("Id does not match, put parent, account controller");
                return BadRequest("Id not match");
            }

            logger.Info($"User {userModel.UserName} sent to user service, put parent");
            var updatedParent = await service.UpdateParent(id, userModel);

            if (updatedParent == null)
            {
                logger.Info($"User {userModel.UserName} has not been updated. Update failed, put parent.");
                return NotFound();
            }

            return Ok(updatedParent);
        }

        [Route("update-teacher/{id}")]
        [ResponseType(typeof(TeacherDTOOutUp))]
        public async Task<IHttpActionResult> PutTeacher(string id, TeacherDTOInUp userModel)
        {
            if (!id.Equals(userModel.Id))
            {
                logger.Info("Id does not match, put teacher, account controller");
                return BadRequest("Id not match");
            }

            logger.Info($"User {userModel.UserName} sent to user service, put teacher");
            var updatedTeacher = await service.UpdateTeacher(id, userModel);

            if (updatedTeacher == null)
            {
                logger.Info($"User {userModel.UserName} has not been updated. Update failed, put teacher.");
                return NotFound();
            }

            return Ok(updatedTeacher);
        }

        [Route("update-student/{id}")]
        [ResponseType(typeof(StudentDTOOutUp))]
        public async Task<IHttpActionResult> PutStudent(string id, StudentDTOInUp userModel)
        {
            if (!id.Equals(userModel.Id))
            {
                logger.Info("Id does not match, put student, account controller");
                return BadRequest("Id not match");
            }

            logger.Info($"User {userModel.UserName} sent to user service, put student");
            var updatedStudent = await service.UpdateStudent(id, userModel);

            if (updatedStudent == null)
            {
                logger.Info($"User {userModel.UserName} has not been updated. Update failed, put student.");
                return NotFound();
            }

            return Ok(updatedStudent);
        }

        [Route("update-admin/{id}")]
        [ResponseType(typeof(StudentDTOOutUp))]
        public async Task<IHttpActionResult> PutAdmin(string id, AdminDTOInUp userModel)
        {
            if (!id.Equals(userModel.Id))
            {
                logger.Info("Id does not match, put admin, account controller");
                return BadRequest("Id not match");
            }

            logger.Info($"User {userModel.UserName} sent to user service, put admin");
            var updatedAdmin = await service.UpdateAdmin(id, userModel);

            if (updatedAdmin == null)
            {
                logger.Info($"User {userModel.UserName} has not been updated. Update failed, put admin.");
                return NotFound();
            }

            return Ok(updatedAdmin);
        }

        [Route("password-update/{id}")]
        [ResponseType(typeof(AppUserDTOOutPass))]
        public async Task<IHttpActionResult> PutPassword(string id, AppUserDTOPassword user)
        {
            if (!id.Equals(user.Id))
            {
                logger.Info("Id does not match, put Password, account controller");
                return BadRequest("Id not match");
            }

            logger.Info("Accessing user service for password update, account controller, put password");
            AppUserDTOOutPass appUserPassChanged = await service.UpdatePassword(id, user);
            return Ok(appUserPassChanged);
        }

        [AllowAnonymous]
        [Route("register-parent")]
        [ResponseType(typeof(ParentDTOOut))]
        public async Task<IHttpActionResult> RegisterParent(ParentDTORegister userModel)
        {
            if (!ModelState.IsValid)
            {
                logger.Info($"Model state is not valid, register parent {userModel.UserName}, controller");
                return BadRequest(ModelState);
            }

            logger.Info($"Accessing user service, register parent {userModel.UserName}, controller");
            var result = await service.RegisterParent(userModel);
            
            if (result == null)
            {
                logger.Info($"Model state is not valid, result not succeeded, register parent {userModel.UserName}, controller");
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [Route("register-student")]
        [ResponseType(typeof(StudentDTOOutReg))]
        public async Task<IHttpActionResult> RegisterStudent(StudentDTOInRegister userModel)
        {
            if (!ModelState.IsValid)
            {
                logger.Info($"Model state is not valid, register student {userModel.UserName}, controller");
                return BadRequest(ModelState);
            }

            logger.Info($"Accessing user service, register student {userModel.UserName}, controller");
            var result = await service.RegisterStudent(userModel);

            if (result == null)
            {
                logger.Info($"Model state is not valid, result not succeeded, register student {userModel.UserName}, controller");
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [Route("register-admin")]
        [ResponseType(typeof(AdminDTOOutUp))]
        public async Task<IHttpActionResult> RegisterAdminUser(AdminDTOInRegister userModel)
        {
            if (!ModelState.IsValid)
            {
                logger.Info($"Model state is not valid, register admin {userModel.UserName}, controller");
                return BadRequest(ModelState);
            }

            logger.Info($"Accessing user service, register admin {userModel.UserName}, controller");
            var result = await service.RegisterAdminUser(userModel);

            if (result == null)
            {
                logger.Info($"Model state is not valid, result not succeeded, register admin {userModel.UserName}, controller");

                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [Route("register-teacher")]
        [ResponseType(typeof(TeacherDTOOutReg))]
        public async Task<IHttpActionResult> RegisterTeacher(TeacherDTORegister userModel)
        {
            if (!ModelState.IsValid)
            {
                logger.Info($"Model state is not valid, register teacher {userModel.UserName}, controller");
                return BadRequest(ModelState);
            }

            logger.Info($"Accessing user service, register Teacher {userModel.UserName}, controller");
            var result = await service.RegisterTeacher(userModel);

            if (result == null)
            {
                logger.Info($"Model state is not valid, result not succeeded, register teacher {userModel.UserName}, controller");
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            logger.Info("Disposing, Account controller");
            base.Dispose(disposing);
        }
    }
}
