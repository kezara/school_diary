using school_diary.DTOs.ClassRoomDTO;
using school_diary.Models;
using System.Collections.Generic;

namespace school_diary.Services
{
    public interface IClassRoomsService
    {
        IEnumerable<ClassRoom> GetAllClassRooms();
        ClassRoom GetClassRoomByID(int id);
        ClassRoom CreateClassRoom(ClassRoom newClass);
        ClassRoom UpdateClassRoom(int id, ClassRoom classToUpdt);
        ClassRoom DeleteClassRoom(int id);
    }
}