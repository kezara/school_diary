using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NLog;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace school_diary.Services
{
    public class UserService : IUserService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork db;

        public UserService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public async Task<AppUserDTOOut> UpdateRole(string id, AppUserDTOIn appUserDTOIn)
        {
            logger.Info($"Accessing db over auth repo, find user by id {id}, user service, update role");
            AppUser user = await db.AuthRepository.FindUserById(id);
            if (user == null)
            {
                logger.Info("Throwing an user not found exception, no user found update role, user service");
                throw new UserNotFoundException($"User with ID {id} does not exists.");
            }
                        
            logger.Info("Sending user to find new role name by ID, user service, update role");
            IdentityRole roleById = await db.AuthRepository.FindRoleById(appUserDTOIn.RoleId);
            user.Roles.Clear();
            var result = await db.AuthRepository.UpdateRole(user.Id, roleById.Name);
            if (!result.Succeeded)
            {
                logger.Info("Role update failed, result not succeeded, user service");
                return null;
            }

            AppUserDTOOut appUserDTO = new AppUserDTOOut()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                RoleId = roleById.Id
            };

            return appUserDTO;
        }

        public async Task<AppUserDTOOutPass> UpdatePassword(string id, AppUserDTOPassword userPass)
        {
            logger.Info($"Accessing db over auth repo, find user by id {id}, user service, update password");
            AppUser user = await db.AuthRepository.FindUserById(id);
            if (user == null)
            {
                logger.Info("Throwing an user not found exception, no user found update password, user service");
                throw new UserNotFoundException($"User with ID {id} does not exists.");
            }

            logger.Info($"User with username {user.UserName} trying to change password, hashing of new password");
            string newPassHashed = Utilities.HashPass.HashedPassword(userPass.NewPassword);

            if (Utilities.HashPass.VerifyHashedPassword(user.PasswordHash, userPass.OldPassword))
            {
                user.PasswordHash = newPassHashed;
            }
            else
            {
                logger.Info("Wrong old password, update password, user service");
                throw new BadRequestException("Wrong password");
            }

            logger.Info($"Updating user {user.UserName} with new password, update password, user service");
            var result = await db.AuthRepository.UpdateUser(user);

            if (!result.Succeeded)
            {
                logger.Info("Update has failed, result not succeeded, user service");
                return null;
            }

            logger.Info("Getting updated user with auth repository");
            var userUpdated = await db.AuthRepository.FindUserById(user.Id);
            logger.Info("Converting user to AppUser dto");
            AppUserDTOOutPass userDTO = Utilities.ConverterDTO.SimpleDTOConverter<AppUserDTOOutPass>(userUpdated);
            return userDTO;

        }

        public async Task<AdminDTOOutUp> UpdateAdmin(string id, AdminDTOInUp adminInUp)
        {
            logger.Info($"Converting admin {adminInUp.UserName} with simple dto converter, user service update admin");
            Admin admin = Utilities.ConverterDTO.SimpleDTOConverter<Admin>(adminInUp);
            logger.Info($"getting user with id {adminInUp.Id}, with db.authreposito, update admin, user service ");
            AppUser user = await db.AuthRepository.FindUserById(id);
            if (user == null)
            {
                logger.Info("Throwing an user not found exception, no user found update admin, user service");
                throw new UserNotFoundException($"User with ID {id} does not exists.");
            }

            logger.Info($"Updating user {adminInUp.UserName}");
            user.FirstName = adminInUp.FirstName;
            user.LastName = adminInUp.LastName;
            user.Email = adminInUp.Email;
            user.UserName = adminInUp.UserName;

            logger.Info("waiting for result from auth repository, update user, user service");
            var result = await db.AuthRepository.UpdateUser(user);

            if (!result.Succeeded)
            {
                logger.Info("Update has failed, result not succeeded, user service");
                return null;
            }

            logger.Info("Getting updated user with auth repository");
            var userUpdated = await db.AuthRepository.FindUserById(adminInUp.Id);
            logger.Info("Converting user to teacher dto");
            AdminDTOOutUp adminDTO = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(userUpdated);
            return adminDTO;
        }

        public async Task<TeacherDTOOutUp> UpdateTeacher(string id, TeacherDTOInUp teacherInUp)
        {
            logger.Info($"Converting teacher {teacherInUp.UserName} with simple dto converter, user service update teacher");
            Teacher teacher = Utilities.ConverterDTO.SimpleDTOConverter<Teacher>(teacherInUp);
            logger.Info($"getting user with id {teacherInUp.Id}, with db.authreposito, update teacher, user service ");
            AppUser user = await db.AuthRepository.FindUserById(id);
            if (user == null)
            {
                logger.Info("Throwing an user not found exception, no user found update teacher, user service");
                throw new UserNotFoundException($"User with ID {id} does not exists.");
            }

            logger.Info($"Updating user {teacherInUp.UserName}");
            user.FirstName = teacherInUp.FirstName;
            user.LastName = teacherInUp.LastName;
            user.Email = teacherInUp.Email;
            user.UserName = teacherInUp.UserName;

            logger.Info("waiting for result from auth repository, update user, user service");
            var result = await db.AuthRepository.UpdateUser(user);

            if (!result.Succeeded)
            {
                logger.Info("Update has failed, result not succeeded, user service");
                return null;
            }

            logger.Info("Getting updated user with auth repository");
            var userUpdated = await db.AuthRepository.FindUserById(teacherInUp.Id);
            logger.Info("Converting user to teacher dto");
            TeacherDTOOutUp teacherDTO = Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTOOutUp>(userUpdated);
            return teacherDTO;
        }

        public async Task<StudentDTOOutUp> UpdateStudent(string id, StudentDTOInUp studentinInUp)
        {
            logger.Info($"Converting student {studentinInUp.UserName} with simple dto converter, user service update student");
            Student student = Utilities.ConverterDTO.SimpleDTOConverter<Student>(studentinInUp);
            logger.Info($"getting user with id {studentinInUp.Id}, with db.authreposito, update student, user service ");
            AppUser user = await db.AuthRepository.FindUserById(id);
            if (user == null)
            {
                logger.Info("Throwing an user not found exception, no user found update student, user service");
                throw new UserNotFoundException($"User with ID {id} does not exists.");
            }

            logger.Info($"Updating user {studentinInUp.UserName}");
            user.FirstName = studentinInUp.FirstName;
            user.LastName = studentinInUp.LastName;
            user.Email = studentinInUp.Email;
            user.UserName = studentinInUp.UserName;

            logger.Info("waiting for result from auth repository, update user, user service");
            var result = await db.AuthRepository.UpdateUser(user);

            if (!result.Succeeded)
            {
                logger.Info("Update has failed, result not succeeded, user service");
                return null;
            }

            logger.Info("Getting updated user with auth repository");
            var userUpdated = await db.AuthRepository.FindUserById(studentinInUp.Id);
            logger.Info("Converting user to student dto");
            StudentDTOOutUp studentDTO = Utilities.ConverterDTO.SimpleDTOConverter<StudentDTOOutUp>(userUpdated);
            return studentDTO;
        }

        public async Task<ParentDTOOut> UpdateParent(string id, ParentDTOInUp parentInUp)
        {
            logger.Info($"Converting parent {parentInUp.UserName} with simple dto converter, user service update parent");
            Parent parent = Utilities.ConverterDTO.SimpleDTOConverter<Parent>(parentInUp);
            logger.Info($"getting user with id {parentInUp.Id}, with db.authreposito, update parent, user service ");
            AppUser user = await db.AuthRepository.FindUserById(id);
            if (user == null)
            {
                logger.Info("Throwing an user not found exception, no user found update parent, user service");
                throw new UserNotFoundException($"User with ID {id} does not exists.");
            }

            logger.Info($"Updating user {parentInUp.UserName}");
            user.FirstName = parentInUp.FirstName;
            user.LastName = parentInUp.LastName;
            user.Email = parentInUp.Email;
            user.UserName = parentInUp.UserName;

            logger.Info("waiting for result from auth repository, update user, user service");
            var result = await db.AuthRepository.UpdateUser(user);

            if (!result.Succeeded)
            {
                logger.Info("Update has failed, result not succeeded, user service");
                return null;
            }

            logger.Info("Getting updated user with auth repository");
            var userUpdated = await db.AuthRepository.FindUserById(parentInUp.Id);
            logger.Info("Convertin user to parent dto");
            ParentDTOOut parentDTO = Utilities.ConverterDTO.SimpleDTOConverter<ParentDTOOut>(userUpdated);
            return parentDTO;
        }

        public async Task<AdminDTOOutUp> RegisterAdminUser(AdminDTOInRegister userModel)
        {
            logger.Info($"Converting admin {userModel.UserName} to model, user service, register admin");
            Admin user = new Admin
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };

            logger.Info($"sending model to auth repository, register admin {userModel.UserName}");
            var result = await db.AuthRepository.RegisterAdminUser(user, userModel.Password);

            if (!result.Succeeded)
            {
                logger.Info($"Result not succeeded, register admin {userModel.UserName}");
                return null;
            }

            logger.Info($"Searching for registered admin {userModel.UserName}");
            var userCreated = await db.AuthRepository.FindUser(userModel.UserName, userModel.Password);

            logger.Info($"Converting admin {userModel.UserName} to DTO with simple dto converter");
            AdminDTOOutUp admin = Utilities.ConverterDTO.SimpleDTOConverter<AdminDTOOutUp>(userCreated);
            return admin;
        }

        public async Task<TeacherDTOOutReg> RegisterTeacher(TeacherDTORegister userModel)
        {
            logger.Info($"Converting teacher {userModel.UserName} to model, user service, register teacher");
            Teacher user = new Teacher
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };

            logger.Info($"sending model to auth repository, register admin {userModel.UserName}");
            var result = await db.AuthRepository.RegisterTeacher(user, userModel.Password);

            if (!result.Succeeded)
            {
                logger.Info($"Result not succeeded, register teacher {userModel.UserName}");

                return null;
            }

            logger.Info($"Searching for registered teacher {userModel.UserName}");
            var userCreated = await db.AuthRepository.FindUser(userModel.UserName, userModel.Password);

            logger.Info($"Converting teacher {userModel.UserName} to DTO with simple dto converter");
            TeacherDTOOutReg teacher = Utilities.ConverterDTO.SimpleDTOConverter<TeacherDTOOutReg>(userCreated);
            return teacher;
        }

        public async Task<ParentDTOOut> RegisterParent(ParentDTORegister userModel)
        {
            logger.Info($"Converting Parent {userModel.UserName} to model, user service, register parent");
            Parent user = new Parent
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };

            logger.Info($"sending model to auth repository, register parent {userModel.UserName}");
            var result = await db.AuthRepository.RegisterParent(user, userModel.Password);

            if (!result.Succeeded)
            {
                logger.Info($"Result not succeeded, register parent {userModel.UserName}");
                return null;
            }

            logger.Info($"Searching for registered parent {userModel.UserName}");
            var userCreated = await db.AuthRepository.FindUser(userModel.UserName, userModel.Password);
            logger.Info($"Converting parent {userModel.UserName} to DTO with simple dto converter");
            ParentDTOOut parent = Utilities.ConverterDTO.SimpleDTOConverter<ParentDTOOut>(userCreated);
            return parent;
        }

        public async Task<StudentDTOOutReg> RegisterStudent(StudentDTOInRegister userModel)
        {
            logger.Info($"Converting student {userModel.UserName} to model, user service, register student");
            Student user = new Student
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };

            logger.Info($"sending model to auth repository, register student {userModel.UserName}");
            var result = await db.AuthRepository.RegisterStudent(user, userModel.Password);

            if (!result.Succeeded)
            {
                logger.Info($"Result not succeeded, register student {userModel.UserName}");
                return null;
            }

            logger.Info($"Searching for registered student {userModel.UserName}");
            var userCreated = await db.AuthRepository.FindUser(userModel.UserName, userModel.Password);
            logger.Info($"Converting student {userModel.UserName} to DTO with simple dto converter");
            StudentDTOOutReg student = Utilities.ConverterDTO.SimpleDTOConverter<StudentDTOOutReg>(userCreated);
            return student;
        }
    }
}