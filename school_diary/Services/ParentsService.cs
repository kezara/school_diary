using NLog;
using school_diary.Models;
using school_diary.Models.DTOs;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class ParentsService : IParentsService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        IUnitOfWork db;
        public ParentsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<ParentDTOOutAll> GetAllParents()
        {
            logger.Info("Accssesing db over Parent rep, get all parents");
            IEnumerable<Parent> parents = db.ParentsRepository.Get();
            if (parents.Count() < 1)
            {
                throw new ParentNotFoundException("No parents here!");
            }
            
            IEnumerable<ParentDTOOutAll> parentDTO = parents.Select(x => new ParentDTOOutAll()
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                StudentDTOOutParents = x.Students.Select(y => Utilities.ConverterDTO.StudentsDTOParentConverter(y))
            });
            return parentDTO;
        }

        public IEnumerable<ParentDTOOutAll> GetParentsByName(string name)
        {
            logger.Info("Accssesing db over Parent rep, get parents by name");
            IEnumerable<Parent> parents = db.ParentsRepository.Get(filter: x => x.FirstName.Contains(name));
            if (parents.Count() < 1)
            {
                throw new ParentNotFoundException($"No parents with name {name} here!");
            }

            IEnumerable<ParentDTOOutAll> parentDTO = parents.Select(x => new ParentDTOOutAll()
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                StudentDTOOutParents = x.Students.Select(y => Utilities.ConverterDTO.StudentsDTOParentConverter(y))
            });
            return parentDTO;
        }

        public IEnumerable<ParentDTOOutAll> GetParentsByLastName(string lastName)
        {
            logger.Info("Accssesing db over Parent rep, get parents by last name");
            IEnumerable<Parent> parents = db.ParentsRepository.Get(filter: x => x.LastName.Contains(lastName));
            if (parents.Count() < 1)
            {
                throw new ParentNotFoundException($"No parents with last name {lastName} here!");
            }

            IEnumerable<ParentDTOOutAll> parentDTO = parents.Select(x => new ParentDTOOutAll()
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                StudentDTOOutParents = x.Students.Select(y => Utilities.ConverterDTO.StudentsDTOParentConverter(y))
            });
            return parentDTO;
        }

        public IEnumerable<ParentDTOOutAll> GetParentsByNameLastName(string name, string lastName)
        {
            logger.Info("Accssesing db over Parent rep, get parents by name and last name");
            IEnumerable<Parent> parents = db.ParentsRepository.Get(filter: x => x.FirstName.Contains(name) && x.LastName.Contains(lastName));
            if (parents.Count() < 1)
            {
                throw new ParentNotFoundException($"No parents with name {name} and last name {lastName} here!");
            }

            IEnumerable<ParentDTOOutAll> parentDTO = parents.Select(x => new ParentDTOOutAll()
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                StudentDTOOutParents = x.Students.Select(y => Utilities.ConverterDTO.StudentsDTOParentConverter(y))
            });
            return parentDTO;
        }

        public ParentDTOHelper GetParentById(string id)
        {
            logger.Info("Accssesing db over Parent rep, get parent by id");
            Parent parent = new Parent();
            parent = db.ParentsRepository.Get(filter: x => x.Id == id).FirstOrDefault();
            if (parent == null)
            {
                throw new ParentNotFoundException($"Parent with ID {id} doesn't exists");
            }
            logger.Info("converting parent with SimpleDTOConverter, get parent by id");
            ParentDTOOut parentDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<ParentDTOOut>(parent);
            IEnumerable<StudentDTOOutParent> studentDTOOutParent = parent.Students.Select(student => Utilities.ConverterDTO.StudentsDTOParentConverter(student));
            ParentDTOHelper parentDTOOutHelper = new ParentDTOHelper();
            parentDTOOutHelper.Parent = parentDTOOut;
            parentDTOOutHelper.Student = studentDTOOutParent;
            return parentDTOOutHelper;
        }

        public ParentDTOHelper GetParentByUserName(string username)
        {
            logger.Info("Accssesing db over Parent rep, get parent by udername");
            Parent parent = db.ParentsRepository.Get(filter: x => x.UserName.Contains(username)).FirstOrDefault();
            if (parent == null)
            {
                throw new ParentNotFoundException($"Parent with username {username} doesn't exist here!");
            }
            logger.Info("converting parent with SimpleDTOConverter, get parent by username");
            ParentDTOOut parentDTOOut = Utilities.ConverterDTO.SimpleDTOConverter<ParentDTOOut>(parent);
            IEnumerable<StudentDTOOutParent> studentDTOOutParent = parent.Students.Select(student => Utilities.ConverterDTO.StudentsDTOParentConverter(student));
            ParentDTOHelper parentDTOOutHelper = new ParentDTOHelper();
            parentDTOOutHelper.Parent = parentDTOOut;
            parentDTOOutHelper.Student = studentDTOOutParent;
            return parentDTOOutHelper;
        }
    }
}