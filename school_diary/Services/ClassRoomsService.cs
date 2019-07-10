using school_diary.DTOs.ClassRoomDTO;
using school_diary.Models;
using school_diary.Repositories;
using school_diary.Utilities.Exceptions;
using school_diary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Services
{
    public class ClassRoomsService : IClassRoomsService
    {
        IUnitOfWork db;

        public ClassRoomsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public ClassRoom CreateClassRoom(ClassRoom newClass)
        {
            //ClassRoom newClass = ConverterDTO.SimpleDTOConverter<ClassRoom>(newClassDTO);
            db.ClassRoomsRepository.Insert(newClass);
            db.Save();
            return newClass;
        }

        public ClassRoom DeleteClassRoom(int id)
        {
            ClassRoom classRoom = GetClassRoomByID(id);
            if (classRoom == null)
            {
                throw new UserNotFoundException();
            }
            db.ClassRoomsRepository.Delete(id);
            db.Save();
            return classRoom;
        }

        public IEnumerable<ClassRoom> GetAllClassRooms()
        {
            return db.ClassRoomsRepository.Get();
        }

        public ClassRoom GetClassRoomByID(int id)
        {
            return db.ClassRoomsRepository.GetByID(id);
        }

        public ClassRoom UpdateClassRoom(int id, ClassRoom classToUpdt)
        {
            ClassRoom classRoom = GetClassRoomByID(id);

            classRoom.Id = classToUpdt.Id;
            classRoom.Year = classToUpdt.Year;
            classRoom.ClassName = classToUpdt.ClassName;
            //classRoom.Subjects = classRoom.Subjects;
            //classRoom.Teachers = classRoom.Teachers;
            db.ClassRoomsRepository.Update(classRoom);
            db.Save();
            return classToUpdt;
        }
    }
}