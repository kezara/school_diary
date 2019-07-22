using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using school_diary.Infrastructure;
using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Security;

namespace school_diary.Models
{
    public class DataAccessContextInitializer : DropCreateDatabaseAlways<AuthContext>//DropCreateDatabaseIfModelChanges<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            var store = new UserStore<AppUser>(context);
            var manager = new UserManager<AppUser>(store);
            //kreiranje rola
            context.Roles.Add(new IdentityRole()
            {
                Id = "1",
                Name = "admins"
            });

            context.Roles.Add(new IdentityRole()
            {
                Id = "2",
                Name = "teachers"
            });

            context.Roles.Add(new IdentityRole()
            {
                Id = "3",
                Name = "parents"
            });

            context.Roles.Add(new IdentityRole()
            {
                Id = "4",
                Name = "students"
            });

            //make some admins
            var admins = new List<AppUser>
                        {
                            new Admin { UserName = "borisavadmin", PasswordHash = HashedPassword("test123"), FirstName = "Borisav", LastName = "Ignjatov" },
                            new Admin { UserName = "ivanadmin", PasswordHash = HashedPassword("test123"), FirstName = "Ivan", LastName = "Miljkovic" }
                        };
            admins.ForEach(a => manager.Create(a));
            admins.ForEach(a => manager.AddToRole(a.Id, returnUserRole(a)));

            //make some parents
            var parents = new List<Parent>
                        {
                            new Parent { UserName = "baneparent", PasswordHash = HashedPassword("test123"), FirstName = "Branislav", LastName = "Djordjevic", Email = "bane@example.com" },
                            new Parent { UserName = "ivanaparent", PasswordHash = HashedPassword("test123"), FirstName = "Ivana", LastName = "Djordjevic", Email = "ivana@gmail.com" },
                            new Parent { UserName = "goranparent", PasswordHash = HashedPassword("test123"), FirstName = "Goran", LastName = "Antanasijevic", Email = "goran@example.com" },
                            new Parent { UserName = "jelenaparent", PasswordHash = HashedPassword("test123"), FirstName = "Jelena", LastName = "Antanasijevic", Email = "jelena@yahoo.com" },
                            new Parent { UserName = "djordjeparent", PasswordHash = HashedPassword("test123"), FirstName = "Djordje", LastName = "Nikolic", Email = "djordje@icloud.com" },
                            new Parent { UserName = "gabrijelaparent", PasswordHash = HashedPassword("test123"), FirstName = "Gabrijela", LastName = "Nikolic", Email = "gabrijela@example.com" },
                            new Parent { UserName = "brankicaparent", PasswordHash = HashedPassword("test123"), FirstName = "Brankica", LastName = "Ignjatov", Email = "brankica@yahoo.com" },
                            new Parent { UserName = "zeljkoparent", PasswordHash = HashedPassword("test123"), FirstName = "Zeljko", LastName = "Backulic", Email = "zeljko@gmail.com" },
                            new Parent { UserName = "marijaparent", PasswordHash = HashedPassword("test123"), FirstName = "Marija", LastName = "Backulic", Email = "marija@example.com" },
                            new Parent { UserName = "jelenapparent", PasswordHash = HashedPassword("test123"), FirstName = "Jelena", LastName = "Pavlica", Email = "jelenap@example.com" },
                            new Parent { UserName = "milanparent", PasswordHash = HashedPassword("test123"), FirstName = "Milan", LastName = "Miskovic", Email = "milan@yahoo.com" },
                            new Parent { UserName = "milenaparent", PasswordHash = HashedPassword("test123"), FirstName = "Milena", LastName = "Miskovic", Email = "milena@gmail.com" },
                            new Parent { UserName = "stanislavparent", PasswordHash = HashedPassword("test123"), FirstName = "Stanislav", LastName = "Zirovic", Email = "stanislav@email.com" },
                            new Parent { UserName = "sandraparent", PasswordHash = HashedPassword("test123"), FirstName = "Sandra", LastName = "Zirovic", Email = "sandra@email.com" },
                            new Parent { UserName = "cicaparent", PasswordHash = HashedPassword("test123"), FirstName = "Cica", LastName = "Zirovic", Email = "cica@example.com" }
                        };

            parents.ForEach(a => manager.Create(a));
            parents.ForEach(a => manager.AddToRole(a.Id, returnUserRole(a)));

            //make some teachers
            var teachers = new List<Teacher>
                        {
                            new Teacher { UserName = "nikolateacher", PasswordHash = HashedPassword("test123"), FirstName = "Nikola", LastName = "Vajdic" },
                            new Teacher { UserName = "cabateacher", PasswordHash = HashedPassword("test123"), FirstName = "Caba", LastName = "Varga" },
                            new Teacher { UserName = "brankicateacher", PasswordHash = HashedPassword("test123"), FirstName = "Brankica", LastName = "Kuzmanovic" },
                            new Teacher { UserName = "branislavteacher", PasswordHash = HashedPassword("test123"), FirstName = "Branislav", LastName = "Kukic" },
                            new Teacher { UserName = "radmilateacher", PasswordHash = HashedPassword("test123"), FirstName = "Radmila", LastName = "Dajic" },
                            new Teacher { UserName = "milicateacher", PasswordHash = HashedPassword("test123"), FirstName = "Milica", LastName = "Barbaric" },
                            new Teacher { UserName = "marinateacher", PasswordHash = HashedPassword("test123"), FirstName = "Marina", LastName = "Petrovic" },
                            new Teacher { UserName = "radoteacher", PasswordHash = HashedPassword("test123"), FirstName = "Rado", LastName = "Maksimovic" },
                            new Teacher { UserName = "ikonovteacher", PasswordHash = HashedPassword("test123"), FirstName = "Radmila", LastName = "Ikonov" },
                            new Teacher { UserName = "ivicateacher", PasswordHash = HashedPassword("test123"), FirstName = "Ivica", LastName = "Tuskan" }
                        };

            teachers.ForEach(a => manager.Create(a));
            teachers.ForEach(a => manager.AddToRole(a.Id, returnUserRole(a)));

            //make some classRooms
            var classRooms = new List<ClassRoom>
            {
                new ClassRoom { Id = 1, Year = 5, ClassName = "V-1" },
                new ClassRoom { Id = 2, Year = 5, ClassName = "V-2" },
                new ClassRoom { Id = 3, Year = 6, ClassName = "VI-1" },
                new ClassRoom { Id = 4,Year = 6, ClassName = "VI-2" },
                new ClassRoom { Id = 5,Year = 7, ClassName = "VII-1" },
                new ClassRoom { Id = 6,Year = 7, ClassName = "VII-2" },
                new ClassRoom { Id = 7,Year = 8, ClassName = "VIII-1" },
                new ClassRoom { Id = 8,Year = 8, ClassName = "VIII-2" }
            };

            context.ClassRooms.AddRange(classRooms);

            //make some students with parents and classrooms
            var students = new List<Student>
            {
                new Student { UserName = "aleksastudent", PasswordHash = HashedPassword("test123"), FirstName = "Aleksa", LastName = "Ignjatov",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "brankicaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "V-1") },
                new Student { UserName = "petarstudent", PasswordHash = HashedPassword("test123"), FirstName = "Petar", LastName = "Ignjatov",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "brankicaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "V-1")},
                new Student { UserName = "strahinjastudent", PasswordHash = HashedPassword("test123"), FirstName = "Strahinja", LastName = "Nikolic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "djordjeparent"),
                    parents.Find(p => p.UserName == "gabrijelaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "V-2")
                //, Teachs = new List<Teach>()
                //{
                //    teachs.Find(x => x.Subjects.SubjectName == "Matematika 5" && x.TeacherUserName == "nikolateacher"),
                //    teachs.Find(x => x.Subjects.SubjectName == "Muzicko 5" && x.TeacherUserName == "radmilateacher"),
                //    teachs.Find(x => x.Subjects.SubjectName == "Likovno 5" && x.TeacherUserName == "milicateacher"),
                //    teachs.Find(x => x.Subjects.SubjectName == "Srpski jezik i knjizevnost 5" && x.TeacherUserName == "brankicateacher"),
                //}
                },
                new Student { UserName = "filipstudent", PasswordHash = HashedPassword("test123"), FirstName = "Filip", LastName = "Antanasijevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "goranparent"),
                    parents.Find(p => p.UserName == "jelenaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "V-2")
                //, Teachs = new List<Teach>()
                //{
                //    teachs.Find(x => x.Subjects.SubjectName == "Matematika 5" && x.TeacherUserName == "cabateacher"),
                //    teachs.Find(x => x.Subjects.SubjectName == "Muzicko 5" && x.TeacherUserName == "radmilateacher"),
                //    teachs.Find(x => x.Subjects.SubjectName == "Likovno 5" && x.TeacherUserName == "milicateacher"),
                //    teachs.Find(x => x.Subjects.SubjectName == "Srpski jezik i knjizevnost 5" && x.TeacherUserName == "branislavteacher"),
                //}
                },
                new Student { UserName = "ivastudent", PasswordHash = HashedPassword("test123"), FirstName = "Iva", LastName = "Antanasijevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "goranparent"),
                    parents.Find(p => p.UserName == "jelenaparent")
                } , ClassRooms = classRooms.Find(x => x.ClassName == "VI-2")},
                new Student { UserName = "aleksandarstudent", PasswordHash = HashedPassword("test123"), FirstName = "Aleksandar", LastName = "Djordjevic" ,
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "branislavparent"),
                    parents.Find(p => p.UserName == "ivanaparent")
                } , ClassRooms = classRooms.Find(x => x.ClassName == "VI-2")},
                new Student { UserName = "vukasinstudent", PasswordHash = HashedPassword("test123"), FirstName = "Vukasin", LastName = "Djordjevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "branislavparent"),
                    parents.Find(p => p.UserName == "ivanaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "VII-2")},
                new Student { UserName = "urosstudent", PasswordHash = HashedPassword("test123"), FirstName = "Uros", LastName = "Backulic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "zeljkoparent"),
                    parents.Find(p => p.UserName == "marijaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "VII-2")},
                new Student { UserName = "vukasinpstudent", PasswordHash = HashedPassword("test123"), FirstName = "Vukasin", LastName = "Pavlica",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "jelenapparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "VIII-2")},
                new Student { UserName = "milosstudent", PasswordHash = HashedPassword("test123"), FirstName = "Milos", LastName = "Miskovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "milanparent"),
                    parents.Find(p => p.UserName == "milenaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "VIII-2")},
                new Student { UserName = "dunjastudent", PasswordHash = HashedPassword("test123"), FirstName = "Dunja", LastName = "Miskovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "milanparent"),
                    parents.Find(p => p.UserName == "milenaparent")
                } , ClassRooms = classRooms.Find(x => x.ClassName == "VI-1")},
                new Student { UserName = "vukasinzstudent", PasswordHash = HashedPassword("test123"), FirstName = "Vukasin", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "stanislavparent"),
                    parents.Find(p => p.UserName == "cicaparent")
                }, ClassRooms = classRooms.Find(x => x.ClassName == "VI-1")},
                new Student { UserName = "teastudent", PasswordHash = HashedPassword("test123"), FirstName = "Tea", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "stanislavparent"),
                    parents.Find(p => p.UserName == "cicaparent")
                } , ClassRooms = classRooms.Find(x => x.ClassName == "VII-1")},
                new Student { UserName = "miastudent", PasswordHash = HashedPassword("test123"), FirstName = "Mia", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "sandraparent")
                } , ClassRooms = classRooms.Find(x => x.ClassName == "VII-1")},
                new Student { UserName = "dariostudent", PasswordHash = HashedPassword("test123"), FirstName = "Mia", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "sandraparent")
                } , ClassRooms = classRooms.Find(x => x.ClassName == "VIII-1")},
                new Student { UserName = "veljkostudent", PasswordHash = HashedPassword("test123"), FirstName = "Mia", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "sandraparent")
                } , ClassRooms = classRooms.Find(x => x.ClassName == "VIII-1")}
            };
            students.ForEach(a => manager.Create(a));
            students.ForEach(a => manager.AddToRole(a.Id, returnUserRole(a)));

            //make some subjects
            var subjects = new List<Subject>
            {
                new Subject { SubjectName = "Matematika 5"},
                new Subject { SubjectName = "Matematika 6"},
                new Subject { SubjectName = "Matematika 7"},
                new Subject { SubjectName = "Matematika 8"},
                new Subject { SubjectName = "Srpski jezik i knjizevnost 5"},
                new Subject { SubjectName = "Srpski jezik i knjizevnost 6"},
                new Subject { SubjectName = "Srpski jezik i knjizevnost 7"},
                new Subject { SubjectName = "Srpski jezik i knjizevnost 8"},
                new Subject { SubjectName = "Muzicko 5"},
                new Subject { SubjectName = "Muzicko 6"},
                new Subject { SubjectName = "Likovno 5"},
                new Subject { SubjectName = "Likovno 6"},
                new Subject { SubjectName = "Likovno 7"},
                new Subject { SubjectName = "Likovno 8"},
                new Subject { SubjectName = "Hemija 7"},
                new Subject { SubjectName = "Hemija 8"},
                new Subject { SubjectName = "Biologija 7"},
                new Subject { SubjectName = "Biologija 8"}
            };
            context.Subjects.AddRange(subjects);

            //make some teachs
            var teachs = new List<Teach>
            {
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Matematika 5"), Teachers = teachers.Find(t => t.UserName == "cabateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "aleksastudent" && s.UserName == "petarstudent")
                } },
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Matematika 5"), Teachers = teachers.Find(t => t.UserName == "nikolateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "strahinjastudent" && s.UserName == "filipstudent")
                } },
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Matematika 6"), Teachers = teachers.Find(t => t.UserName == "nikolateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dunjastudent" && s.UserName == "vukasinzstudent")
                } },
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Matematika 6"), Teachers = teachers.Find(t => t.UserName == "cabateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "ivastudent" && s.UserName == "aleksandarstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Matematika 7"), Teachers = teachers.Find(t => t.UserName == "nikolateacher") ,
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "teastudent" && s.UserName == "miastudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Matematika 7"), Teachers = teachers.Find(t => t.UserName == "cabateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "vukasinstudent" && s.UserName == "urosstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Matematika 8"), Teachers = teachers.Find(t => t.UserName == "nikolateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dariostudent" && s.UserName == "veljkostudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Matematika 8"), Teachers = teachers.Find(t => t.UserName == "cabateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "vukasinpstudent" && s.UserName == "milosstudent")
                } },
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 5"), Teachers = teachers.Find(t => t.UserName == "brankicateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "aleksastudent" && s.UserName == "petarstudent")
                } },
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 5"), Teachers = teachers.Find(t => t.UserName == "branislavteacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "strahinjastudent" && s.UserName == "filipstudent")
                } },
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 6"), Teachers = teachers.Find(t => t.UserName == "brankicateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dunjastudent" && s.UserName == "vukasinzstudent")
                } },
                new Teach { WeeklyFond = 6, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 6"), Teachers = teachers.Find(t => t.UserName == "branislavteacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "ivastudent" && s.UserName == "aleksandarstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 7"), Teachers = teachers.Find(t => t.UserName == "brankicateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "teastudent" && s.UserName == "miastudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 7"), Teachers = teachers.Find(t => t.UserName == "branislavteacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "vukasinstudent" && s.UserName == "urosstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 8"), Teachers = teachers.Find(t => t.UserName == "brankicateacher") ,
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dariostudent" && s.UserName == "veljkostudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Srpski jezik i knjizevnost 8"), Teachers = teachers.Find(t => t.UserName == "branislavteacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "vukasinpstudent" && s.UserName == "milosstudent")
                } },
                new Teach { WeeklyFond = 2, Subjects = subjects.Find(s => s.SubjectName == "Muzicko 5"), Teachers = teachers.Find(t => t.UserName == "radmilateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "aleksastudent" && s.UserName == "petarstudent" && s.UserName == "strahinjastudent" && s.UserName == "filipstudent")
                } },
                new Teach { WeeklyFond = 1, Subjects = subjects.Find(s => s.SubjectName == "Muzicko 6"), Teachers = teachers.Find(t => t.UserName == "radmilateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dunjastudent" && s.UserName == "vukasinzstudent" && s.UserName == "ivastudent" && s.UserName == "aleksandarstudent")
                } },
                new Teach { WeeklyFond = 2, Subjects = subjects.Find(s => s.SubjectName == "Likovno 5"), Teachers = teachers.Find(t => t.UserName == "milicateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "aleksastudent" && s.UserName == "petarstudent" && s.UserName == "vukasinzstudent" && s.UserName == "strahinjastudent" && s.UserName == "filipstudent" && s.UserName == "teastudent")
                } },
                new Teach { WeeklyFond = 2, Subjects = subjects.Find(s => s.SubjectName == "Likovno 6"), Teachers = teachers.Find(t => t.UserName == "milicateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dunjastudent" && s.UserName == "vukasinzstudent" && s.UserName == "ivastudent" && s.UserName == "aleksandarstudent")
                } },
                new Teach { WeeklyFond = 1, Subjects = subjects.Find(s => s.SubjectName == "Likovno 7"), Teachers = teachers.Find(t => t.UserName == "milicateacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "teastudent" && s.UserName == "miastudent" && s.UserName == "vukasinstudent" && s.UserName == "urosstudent")
                } },
                new Teach { WeeklyFond = 1, Subjects = subjects.Find(s => s.SubjectName == "Likovno 8"), Teachers = teachers.Find(t => t.UserName == "milicateacher") ,
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dariostudent" && s.UserName == "veljkostudent" &&s.UserName == "vukasinpstudent" && s.UserName == "milosstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Hemija 7"), Teachers = teachers.Find(t => t.UserName == "radoteacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "teastudent" && s.UserName == "miastudent"&& s.UserName == "vukasinstudent" && s.UserName == "urosstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Hemija 8"), Teachers = teachers.Find(t => t.UserName == "radoteacher") ,
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dariostudent" && s.UserName == "veljkostudent" && s.UserName == "vukasinpstudent" && s.UserName == "milosstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Biologija 7"), Teachers = teachers.Find(t => t.UserName == "ikonovteacher"),
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "teastudent" && s.UserName == "miastudent"&& s.UserName == "vukasinstudent" && s.UserName == "urosstudent")
                } },
                new Teach { WeeklyFond = 4, Subjects = subjects.Find(s => s.SubjectName == "Biologija 8"), Teachers = teachers.Find(t => t.UserName == "ikonovteacher") ,
                Students = new List<Student>()
                {
                    students.Find(s => s.UserName == "dariostudent" && s.UserName == "veljkostudent" && s.UserName == "vukasinpstudent" && s.UserName == "milosstudent")
                } }
            };
            context.Teachs.AddRange(teachs);

            //make some grades
            var grades = new List<Grade>
            {
                new Grade { GradeValue = 1, Students = students.Find(s => s.UserName == "dariostudent"), Subjects = subjects.Find(u => u.SubjectName == "Matematika 8")},
                new Grade { GradeValue = 1, Students = students.Find(s => s.UserName == "dariostudent"), Subjects = subjects.Find(u => u.SubjectName == "Matematika 8")},
                new Grade { GradeValue = 1, Students = students.Find(s => s.UserName == "vukasinstudent"), Subjects = subjects.Find(u => u.SubjectName == "Hemija 7")}
                //new Grade { GradeValue = 2, GradeDesc = "Dovoljan"},
                //new Grade { GradeValue = 3, GradeDesc = "Dobar"},
                //new Grade { GradeValue = 4, GradeDesc = "Vrlo dobar"},
                //new Grade { GradeValue = 5, GradeDesc = "Odlican"}
            };
            context.Grades.AddRange(grades);



            base.Seed(context);
        }
    


        private static string HashedPassword(string password)
        {
            var pass = new PasswordHasher();
            var hashed = pass.HashPassword(password);
            return hashed;
        }

        private string returnUserRole(AppUser user)
        {
            string role = null;
            switch (user.GetType().Name)
            {
                case "Admin":
                    role = "admins";
                    break;
                case "Student":
                    role = "students";
                    break;
                case "Parent":
                    role = "parents";
                    break;
                case "Teacher":
                    role = "teachers";
                    break;
                default:
                    break;
            }
            return role;
        }
    }
}

//        private void UsersToDB(List<AppUser> users, AuthContext context)
//        {
//            var store = new UserStore<AppUser>(context);
//            var manager = new UserManager<AppUser>(store);
//            foreach (var user in users)
//            {
//                manager.Create(user);
//                manager.AddToRole(user.Id, returnUserRole(user));
//            }
//        }