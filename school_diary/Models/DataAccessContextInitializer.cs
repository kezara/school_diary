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
        public override void InitializeDatabase(AuthContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

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
                new Admin { UserName = "borisavadmin", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Borisav", LastName = "Ignjatov" },
                new Admin { UserName = "ivanadmin", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Ivan", LastName = "Miljkovic" }
            };
            admins.ForEach(a => manager.Create(a));
            admins.ForEach(a => manager.AddToRole(a.Id, ReturnUserRole(a)));

            //make some parents
            var parents = new List<Parent>
            {
                new Parent { UserName = "baneparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Branislav", LastName = "Djordjevic", Email = "borisav.ignjatov@gmail.com" },
                new Parent { UserName = "ivanaparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Ivana", LastName = "Djordjevic", Email = "borisav.ignjatov@icloud.com" },
                new Parent { UserName = "goranparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Goran", LastName = "Antanasijevic", Email = "goran@example.com" },
                new Parent { UserName = "jelenaparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Jelena", LastName = "Antanasijevic", Email = "jelena@yahoo.com" },
                new Parent { UserName = "djordjeparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Djordje", LastName = "Nikolic", Email = "djordje@icloud.com" },
                new Parent { UserName = "gabrijelaparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Gabrijela", LastName = "Nikolic", Email = "gabrijela@example.com" },
                new Parent { UserName = "brankicaparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Brankica", LastName = "Ignjatov", Email = "brankica@yahoo.com" },
                new Parent { UserName = "zeljkoparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Zeljko", LastName = "Backulic", Email = "zeljko@gmail.com" },
                new Parent { UserName = "marijaparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Marija", LastName = "Backulic", Email = "marija@example.com" },
                new Parent { UserName = "jelenapparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Jelena", LastName = "Pavlica", Email = "jelenap@example.com" },
                new Parent { UserName = "milanparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Milan", LastName = "Miskovic", Email = "milan@yahoo.com" },
                new Parent { UserName = "milenaparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Milena", LastName = "Miskovic", Email = "milena@gmail.com" },
                new Parent { UserName = "stanislavparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Stanislav", LastName = "Zirovic", Email = "stanislav@email.com" },
                new Parent { UserName = "sandraparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Sandra", LastName = "Zirovic", Email = "sandra@email.com" },
                new Parent { UserName = "cicaparent", PasswordHash = Utilities.HashPass.HashedPassword("test123"), FirstName = "Cica", LastName = "Zirovic", Email = "cica@example.com" }
            };

            parents.ForEach(a => manager.Create(a));
            parents.ForEach(a => manager.AddToRole(a.Id, ReturnUserRole(a)));

            //make some teachers
            var teacher1 = new Teacher()
            {
                UserName = "nikolateacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Nikola",
                LastName = "Vajdic"
            };
            manager.Create(teacher1);
            manager.AddToRole(teacher1.Id, "teachers");
            var teacher2 = new Teacher()
            {
                UserName = "cabateacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Caba",
                LastName = "Varga"
            };
            manager.Create(teacher2);
            manager.AddToRole(teacher2.Id, "teachers");
            var teacher3 = new Teacher()
            {
                UserName = "brankicateacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Brankica",
                LastName = "Kuzmanovic"
            };
            manager.Create(teacher3);
            manager.AddToRole(teacher3.Id, "teachers");

            var teacher4 = new Teacher()
            {
                UserName = "branislavteacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Branislav",
                LastName = "Kukic"
            };
            manager.Create(teacher4);
            manager.AddToRole(teacher4.Id, "teachers");

            var teacher5 = new Teacher()
            {
                UserName = "radmilateacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Radmila",
                LastName = "Dajic"
            };
            manager.Create(teacher5);
            manager.AddToRole(teacher5.Id, "teachers");

            var teacher6 = new Teacher()
            {
                UserName = "milicateacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Milica",
                LastName = "Barbaric"
            };
            manager.Create(teacher6);
            manager.AddToRole(teacher6.Id, "teachers");

            var teacher7 = new Teacher()
            {
                UserName = "marinateacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Marina",
                LastName = "Petrovic"
            };
            manager.Create(teacher7);
            manager.AddToRole(teacher7.Id, "teachers");

            var teacher8 = new Teacher()
            {
                UserName = "radoteacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Rado",
                LastName = "Maksimovic"
            };
            manager.Create(teacher8);
            manager.AddToRole(teacher8.Id, "teachers");

            var teacher9 = new Teacher()
            {
                UserName = "ikonovteacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Radmila",
                LastName = "Ikonov"
            };
            manager.Create(teacher9);
            manager.AddToRole(teacher9.Id, "teachers");

            var teacher10 = new Teacher()
            {
                UserName = "ivicateacher",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Ivica",
                LastName = "Tuskan"
            };
            manager.Create(teacher10);
            manager.AddToRole(teacher10.Id, "teachers");

            //make some subjects
            var subject1 = new Subject()
            {
                Id = 1,
                SubjectName = "Matematika",
                SubjectFond = 4,
                Teachers = new HashSet<Teacher>() { teacher1, teacher2}
            };
            context.Subjects.Add(subject1);
            var subject2 = new Subject()
            {
                Id = 2,
                SubjectName = "Srpski jezik i knjizevnost",
                SubjectFond = 5,
                Teachers = new HashSet<Teacher>() { teacher3, teacher4, teacher9 }
            };
            context.Subjects.Add(subject2);
            var subject3 = new Subject()
            {
                Id = 3,
                SubjectName = "Likovno",
                SubjectFond = 2,
                Teachers = new HashSet<Teacher>() { teacher5 }
            };
            context.Subjects.Add(subject3);
            var subject4 = new Subject()
            {
                Id = 4,
                SubjectName = "Muzicko",
                SubjectFond = 2,
                Teachers = new HashSet<Teacher>() { teacher6 }
            };
            context.Subjects.Add(subject4);
            var subject5 = new Subject()
            {
                Id = 5,
                SubjectName = "Srpski jezik i knjizevnost",
                SubjectFond = 4,
                Teachers = new HashSet<Teacher>() { teacher3, teacher4, teacher9 }
            };
            context.Subjects.Add(subject5);
            var subject6 = new Subject()
            {
                Id = 6,
                SubjectName = "Likovno",
                SubjectFond = 1,
                Teachers = new HashSet<Teacher>() { teacher5 }
            };
            context.Subjects.Add(subject6);
            var subject7 = new Subject()
            {
                Id = 7,
                SubjectName = "Muzicko",
                SubjectFond = 1,
                Teachers = new HashSet<Teacher>() { teacher6 }
            };
            context.Subjects.Add(subject7);
            var subject8 = new Subject()
            {
                Id = 8,
                SubjectName = "Hemija",
                SubjectFond = 2,
                Teachers = new HashSet<Teacher>() { teacher7, teacher10 }
            };
            context.Subjects.Add(subject8);
            var subject9 = new Subject()
            {
                Id = 9,
                SubjectName = "Biologija",
                SubjectFond = 2,
                Teachers = new HashSet<Teacher>() { teacher8 }
            };
            context.Subjects.Add(subject9);
            var subject10 = new Subject()
            {
                Id = 10,
                SubjectName = "Fizika",
                SubjectFond = 2,
                Teachers = new HashSet<Teacher>() { teacher1 }
            };
            context.Subjects.Add(subject10);

            //make some grades
            var grade1 = new Grade()
            {
                GradeYear = 5,
                Subjects = new HashSet<Subject>() { subject1, subject2, subject3, subject4 }

            };
            context.Grades.Add(grade1);
            var grade2 = new Grade()
            {
                GradeYear = 6,
                Subjects = new HashSet<Subject>() { subject1, subject5, subject6, subject7, subject9 }
            };
            context.Grades.Add(grade2);
            var grade3 = new Grade()
            {
                GradeYear = 7,
                Subjects = new HashSet<Subject>() { subject1, subject5, subject6, subject7, subject8, subject9,subject10 }
            };
            context.Grades.Add(grade3);
            var grade4 = new Grade()
            {
                GradeYear = 8,
                Subjects = new HashSet<Subject>() { subject1, subject5, subject6, subject7, subject8, subject9, subject10 }
            };
            context.Grades.Add(grade4);

            //make some departments
            var classRoom1 = new Department()
            {
                DepartmentName = "V-1",
                Grades = grade1
            };
            context.Departments.Add(classRoom1);
            var classRoom2 = new Department()
            {
                DepartmentName = "V-2",
                Grades = grade1
            };
            context.Departments.Add(classRoom2);
            var classRoom3 = new Department()
            {
                DepartmentName = "VI-1",
                Grades = grade2
            };
            context.Departments.Add(classRoom3);
            var classRoom4 = new Department()
            {
                DepartmentName = "VI-2",
                Grades = grade2
            };
            context.Departments.Add(classRoom4);
            var classRoom5 = new Department()
            {
                DepartmentName = "VII-1",
                Grades = grade3
            };
            context.Departments.Add(classRoom5);
            var classRoom6 = new Department()
            {
                DepartmentName = "VII-2",
                Grades = grade3
            };
            context.Departments.Add(classRoom6);
            var classRoom7 = new Department()
            {
                DepartmentName = "VIII-1",
                Grades = grade4
            };
            context.Departments.Add(classRoom7);
            var classRoom8 = new Department()
            {
                DepartmentName = "VIII-2",
                Grades = grade4
            };
            context.Departments.Add(classRoom8);
            //make some subjectgrade
            //var subjectgrade1 = new SubjectGrade()
            //{
            //    Subject = subject1,
            //    Grade = grade1
            //};
            //context.SubjectGrades.Add(subjectgrade1);
            //var subjectgrade2 = new SubjectGrade()
            //{
            //    Subject = subject2,
            //    Grade = grade1
            //};
            //context.SubjectGrades.Add(subjectgrade2);
            //var subjectgrade3 = new SubjectGrade()
            //{
            //    Subject = subject3,
            //    Grade = grade1
            //};
            //context.SubjectGrades.Add(subjectgrade3);
            //var subjectgrade4 = new SubjectGrade()
            //{
            //    Subject = subject4,
            //    Grade = grade1
            //};
            //context.SubjectGrades.Add(subjectgrade4);
            //var subjectgrade5 = new SubjectGrade()
            //{
            //    Subject = subject1,
            //    Grade = grade2
            //};
            //context.SubjectGrades.Add(subjectgrade5);
            //var subjectgrade6 = new SubjectGrade()
            //{
            //    Subject = subject5,
            //    Grade = grade2
            //};
            //context.SubjectGrades.Add(subjectgrade6);
            //var subjectgrade7 = new SubjectGrade()
            //{
            //    Subject = subject6,
            //    Grade = grade2
            //};
            //context.SubjectGrades.Add(subjectgrade7);
            //var subjectgrade8 = new SubjectGrade()
            //{
            //    Subject = subject7,
            //    Grade = grade2
            //};
            //context.SubjectGrades.Add(subjectgrade8);
            //var subjectgrade9 = new SubjectGrade()
            //{
            //    Subject = subject9,
            //    Grade = grade2
            //};
            //context.SubjectGrades.Add(subjectgrade9);
            //var subjectgrade10 = new SubjectGrade()
            //{
            //    Subject = subject1,
            //    Grade = grade3
            //};
            //context.SubjectGrades.Add(subjectgrade10);
            //var subjectgrade11 = new SubjectGrade()
            //{
            //    Subject = subject5,
            //    Grade = grade3
            //};
            //context.SubjectGrades.Add(subjectgrade11);
            //var subjectgrade12 = new SubjectGrade()
            //{
            //    Subject = subject6,
            //    Grade = grade3
            //};
            //context.SubjectGrades.Add(subjectgrade12);
            //var subjectgrade13 = new SubjectGrade()
            //{
            //    Subject = subject7,
            //    Grade = grade3
            //};
            //context.SubjectGrades.Add(subjectgrade13);
            //var subjectgrade14 = new SubjectGrade()
            //{
            //    Subject = subject8,
            //    Grade = grade3
            //};
            //context.SubjectGrades.Add(subjectgrade14);
            //var subjectgrade15 = new SubjectGrade()
            //{
            //    Subject= subject9,
            //    Grade = grade3
            //};
            //context.SubjectGrades.Add(subjectgrade15);
            //var subjectgrade16 = new SubjectGrade()
            //{
            //    Subject = subject1,
            //    Grade = grade4
            //};
            //context.SubjectGrades.Add(subjectgrade16);
            //var subjectgrade17 = new SubjectGrade()
            //{
            //    Subject = subject5,
            //    Grade = grade4
            //};
            //context.SubjectGrades.Add(subjectgrade17);
            //var subjectgrade18 = new SubjectGrade()
            //{
            //    Subject = subject6,
            //    Grade = grade4
            //};
            //context.SubjectGrades.Add(subjectgrade18);
            //var subjectgrade19 = new SubjectGrade()
            //{
            //    Subject = subject7,
            //    Grade = grade4
            //};
            //context.SubjectGrades.Add(subjectgrade19);
            //var subjectgrade20 = new SubjectGrade()
            //{
            //    Subject = subject8,
            //    Grade = grade4
            //};
            //context.SubjectGrades.Add(subjectgrade20);
            //var subjectgrade21 = new SubjectGrade()
            //{
            //    Subject = subject9,
            //    Grade = grade4
            //};
            //context.SubjectGrades.Add(subjectgrade21);

            //make some students with parents and 
            var student1 = new Student()
            {
                UserName = "aleksastudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Aleksa",
                LastName = "Ignjatov",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "brankicaparent")
                }
            };
            manager.Create(student1);
            manager.AddToRole(student1.Id, "students");

            var student2 = new Student()
            {
                UserName = "petarstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Petar",
                LastName = "Ignjatov",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "brankicaparent")
                }
            };
            manager.Create(student2);
            manager.AddToRole(student2.Id, "students");

            var student3 = new Student()
            {
                UserName = "strahinjastudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Strahinja",
                LastName = "Nikolic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "djordjeparent"),
                    parents.Find(p => p.UserName == "gabrijelaparent")
                }
            };
            manager.Create(student3);
            manager.AddToRole(student3.Id, "students");

            var student4 = new Student()
            {
                UserName = "filipstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Filip",
                LastName = "Antanasijevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "goranparent"),
                    parents.Find(p => p.UserName == "jelenaparent")
                }
            };
            manager.Create(student4);
            manager.AddToRole(student4.Id, "students");

            var student5 = new Student()
            {
                UserName = "ivastudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Iva",
                LastName = "Antanasijevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "goranparent"),
                    parents.Find(p => p.UserName == "jelenaparent")
                }
            };
            manager.Create(student5);
            manager.AddToRole(student5.Id, "students");

            var student6 = new Student()
            {
                UserName = "miastudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Mia",
                LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "sandraparent")
                }
            };
            manager.Create(student6);
            manager.AddToRole(student6.Id, "students");

            var student7 = new Student()
            {
                UserName = "dariostudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Dario",
                LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "sandraparent")
                }
            };
            manager.Create(student7);
            manager.AddToRole(student7.Id, "students");

            var student8 = new Student()
            {
                UserName = "teastudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Tea",
                LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "stanislavparent"),
                    parents.Find(p => p.UserName == "cicaparent")
                }
            };
            manager.Create(student8);
            manager.AddToRole(student8.Id, "students");

            var student9 = new Student()
            {
                UserName = "vukasinzstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Vukasin",
                LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "stanislavparent"),
                    parents.Find(p => p.UserName == "cicaparent")
                }
            };
            manager.Create(student9);
            manager.AddToRole(student9.Id, "students");

            var student10 = new Student()
            {
                UserName = "dunjastudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Dunja",
                LastName = "Miskovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "milanparent"),
                    parents.Find(p => p.UserName == "milenaparent")
                }
            };
            manager.Create(student10);
            manager.AddToRole(student10.Id, "students");

            var student11 = new Student()
            {
                UserName = "milosstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Milos",
                LastName = "Miskovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "milanparent"),
                    parents.Find(p => p.UserName == "milenaparent")
                }
            };
            manager.Create(student11);
            manager.AddToRole(student11.Id, "students");

            var student12 = new Student()
            {
                UserName = "vukasinpstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Vukasin",
                LastName = "Pavlica",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "jelenapparent")
                }
            };
            manager.Create(student12);
            manager.AddToRole(student12.Id, "students");

            var student13 = new Student()
            {
                UserName = "urosstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Uros",
                LastName = "Backulic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "zeljkoparent"),
                    parents.Find(p => p.UserName == "marijaparent")
                }
            };
            manager.Create(student13);
            manager.AddToRole(student13.Id, "students");

            var student14 = new Student()
            {
                UserName = "vukasinstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Vukasin",
                LastName = "Djordjevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "baneparent"),
                    parents.Find(p => p.UserName == "ivanaparent")
                }
            };
            manager.Create(student14);
            manager.AddToRole(student14.Id, "students");

            var student15 = new Student()
            {
                UserName = "aleksandarstudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Aleksandar",
                LastName = "Djordjevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "baneparent"),
                    parents.Find(p => p.UserName == "ivanaparent")
                }
            };
            manager.Create(student15);
            manager.AddToRole(student15.Id, "students");

            var student16 = new Student()
            {
                UserName = "veljkostudent",
                PasswordHash = Utilities.HashPass.HashedPassword("test123"),
                FirstName = "Veljko",
                LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "sandraparent")
                }
            };
            manager.Create(student16);
            manager.AddToRole(student16.Id, "students");

            //make some studentdepartment
            var studentdepartment1 = new StudentDepartment()
            {
                Departments = classRoom1,
                Students = student1,
                EnrolmentTime = new DateTime(2018,9,1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach3, teach7, teach9
                //}
            };
            context.StudentDepartments.Add(studentdepartment1);
            var studentdepartment2 = new StudentDepartment()
            {
                Departments = classRoom1,
                Students = student2,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach3, teach7, teach9
                //}
            };
            context.StudentDepartments.Add(studentdepartment2);
            var studentdepartment3 = new StudentDepartment()
            {
                Departments = classRoom2,
                Students = student3,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach4, teach7, teach9
                //}
            };
            context.StudentDepartments.Add(studentdepartment3);
            var studentdepartment4 = new StudentDepartment()
            {
                Departments = classRoom2,
                Students = student4,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach4, teach7, teach9
                //}
            };
            context.StudentDepartments.Add(studentdepartment4);
            var studentdepartment5 = new StudentDepartment()
            {
                Departments = classRoom3,
                Students = student5,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach5,teach8,teach12,teach10
                //}
            };
            context.StudentDepartments.Add(studentdepartment5);
            var studentdepartment6 = new StudentDepartment()
            {
                Departments = classRoom3,
                Students = student6,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach5,teach8,teach12,teach10
                //}
            };
            context.StudentDepartments.Add(studentdepartment6);
            var studentdepartment7 = new StudentDepartment()
            {
                Departments = classRoom4,
                Students = student7,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach6,teach8,teach12,teach10
                //}
            };
            context.StudentDepartments.Add(studentdepartment7);
            var studentdepartment8 = new StudentDepartment()
            {
                Departments = classRoom4,
                Students = student8,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach6,teach8,teach12,teach10
                //}
            };
            context.StudentDepartments.Add(studentdepartment8);
            var studentdepartment9 = new StudentDepartment()
            {
                Departments = classRoom5,
                Students = student9,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach5,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment9);
            var studentdepartment10 = new StudentDepartment()
            {
                Departments = classRoom5,
                Students = student10,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach5,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment10);
            var studentdepartment11 = new StudentDepartment()
            {
                Departments = classRoom6,
                Students = student11,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach6,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment11);
            var studentdepartment12 = new StudentDepartment()
            {
                Departments = classRoom6,
                Students = student12,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach6,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment12);
            var studentdepartment13 = new StudentDepartment()
            {
                Departments = classRoom7,
                Students = student13,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach5,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment13);
            var studentdepartment14 = new StudentDepartment()
            {
                Departments = classRoom7,
                Students = student14,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach1, teach5,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment14);
            var studentdepartment15 = new StudentDepartment()
            {
                Departments = classRoom8,
                Students = student15,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach6,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment15);
            var studentdepartment16 = new StudentDepartment()
            {
                Departments = classRoom8,
                Students = student16,
                EnrolmentTime = new DateTime(2018, 9, 1),
                //Teaches = new List<Teach>()
                //{
                //    teach2, teach6,teach8,teach12,teach10,teach11,teach13
                //}
            };
            context.StudentDepartments.Add(studentdepartment16);

            //make some Teach
            var teach1 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment1
            };
            context.Teaches.Add(teach1);

            var teach2 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment2
            };
            context.Teaches.Add(teach2);

            var teach3 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment3
            };
            context.Teaches.Add(teach3);
            var teach4 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment4
            };
            context.Teaches.Add(teach4);
            var teach5 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject2,
                StudentDepartments = studentdepartment1
            };
            context.Teaches.Add(teach5);
            var teach6 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject2,
                StudentDepartments = studentdepartment2
            };
            context.Teaches.Add(teach6);
            var teach7 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject2,
                StudentDepartments = studentdepartment3
            };
            context.Teaches.Add(teach7);
            var teach8 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject2,
                StudentDepartments = studentdepartment4
            };
            context.Teaches.Add(teach8);
            var teach9 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject3,
                StudentDepartments = studentdepartment1
            };
            context.Teaches.Add(teach9);
            var teach10 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject3,
                StudentDepartments = studentdepartment2
            };
            context.Teaches.Add(teach10);
            var teach11 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject3,
                StudentDepartments = studentdepartment3
            };
            context.Teaches.Add(teach11);
            var teach12 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject3,
                StudentDepartments = studentdepartment4
            };
            context.Teaches.Add(teach12);
            var teach13 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject4,
                StudentDepartments = studentdepartment1
            };
            context.Teaches.Add(teach13);
            var teach14 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject4,
                StudentDepartments = studentdepartment2
            };
            context.Teaches.Add(teach14);
            var teach15 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject4,
                StudentDepartments = studentdepartment3
            };
            context.Teaches.Add(teach15);
            var teach16 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject4,
                StudentDepartments = studentdepartment4
            };
            context.Teaches.Add(teach16);
            var teach17 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment5
            };
            context.Teaches.Add(teach17);
            var teach18 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment6
            };
            context.Teaches.Add(teach18);
            var teach19 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment7
            };
            context.Teaches.Add(teach19);
            var teach20 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment8
            };
            context.Teaches.Add(teach20);
            var teach21 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject5,
                StudentDepartments = studentdepartment5
            };
            context.Teaches.Add(teach21);
            var teach22 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject5,
                StudentDepartments = studentdepartment6
            };
            context.Teaches.Add(teach22);
            var teach23 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject5,
                StudentDepartments = studentdepartment7
            };
            context.Teaches.Add(teach23);
            var teach24 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject5,
                StudentDepartments = studentdepartment8
            };
            context.Teaches.Add(teach24);
            var teach25 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment5
            };
            context.Teaches.Add(teach25);
            var teach26 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment6
            };
            context.Teaches.Add(teach26);
            var teach27 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment7
            };
            context.Teaches.Add(teach27);
            var teach28 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment8
            };
            context.Teaches.Add(teach28);
            var teach29 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment5
            };
            context.Teaches.Add(teach29);
            var teach30 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment6
            };
            context.Teaches.Add(teach30);
            var teach31 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment7
            };
            context.Teaches.Add(teach31);
            var teach32 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment8
            };
            context.Teaches.Add(teach32);
            var teach33 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment5
            };
            context.Teaches.Add(teach33);
            var teach34 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment6
            };
            context.Teaches.Add(teach34);
            var teach35 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment7
            };
            context.Teaches.Add(teach35);
            var teach36 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment8
            };
            context.Teaches.Add(teach36);
            var teach37 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment9
            };
            context.Teaches.Add(teach37);
            var teach38 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment10
            };
            context.Teaches.Add(teach38);
            var teach39 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment11
            };
            context.Teaches.Add(teach39);
            var teach40 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment12
            };
            context.Teaches.Add(teach40);
            var teach41 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject5,
                StudentDepartments = studentdepartment9
            };
            context.Teaches.Add(teach41);
            var teach42 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject5,
                StudentDepartments = studentdepartment10
            };
            context.Teaches.Add(teach42);
            var teach43 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject5,
                StudentDepartments = studentdepartment11
            };
            context.Teaches.Add(teach43);
            var teach44 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject5,
                StudentDepartments = studentdepartment12
            };
            context.Teaches.Add(teach44);
            var teach45 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment9
            };
            context.Teaches.Add(teach45);
            var teach46 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment10
            };
            context.Teaches.Add(teach46);
            var teach47 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment11
            };
            context.Teaches.Add(teach47);
            var teach48 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment12
            };
            context.Teaches.Add(teach48);
            var teach49 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment9
            };
            context.Teaches.Add(teach49);
            var teach50 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment10
            };
            context.Teaches.Add(teach50);
            var teach51 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment11
            };
            context.Teaches.Add(teach51);
            var teach52 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment12
            };
            context.Teaches.Add(teach52);
            var teach53 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment9
            };
            context.Teaches.Add(teach53);
            var teach54 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment10
            };
            context.Teaches.Add(teach54);
            var teach55 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment11
            };
            context.Teaches.Add(teach55);
            var teach56 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment12
            };
            context.Teaches.Add(teach56);
            var teach57 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment9
            };
            context.Teaches.Add(teach57);
            var teach58 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment10
            };
            context.Teaches.Add(teach58);
            var teach59 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment11
            };
            context.Teaches.Add(teach59);
            var teach60 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment12
            };
            context.Teaches.Add(teach60);
            var teach61 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment13
            };
            context.Teaches.Add(teach61);
            var teach62 = new Teach()
            {
                Teachers = teacher1,
                Subject = subject1,
                StudentDepartments = studentdepartment14
            };
            context.Teaches.Add(teach62);
            var teach63 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment15
            };
            context.Teaches.Add(teach63);
            var teach64 = new Teach()
            {
                Teachers = teacher2,
                Subject = subject1,
                StudentDepartments = studentdepartment16
            };
            context.Teaches.Add(teach64);
            var teach65 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject5,
                StudentDepartments = studentdepartment13
            };
            context.Teaches.Add(teach65);
            var teach66 = new Teach()
            {
                Teachers = teacher3,
                Subject = subject5,
                StudentDepartments = studentdepartment14
            };
            context.Teaches.Add(teach66);
            var teach67 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject5,
                StudentDepartments = studentdepartment15
            };
            context.Teaches.Add(teach67);
            var teach68 = new Teach()
            {
                Teachers = teacher4,
                Subject = subject5,
                StudentDepartments = studentdepartment16
            };
            context.Teaches.Add(teach68);
            var teach69 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment13
            };
            context.Teaches.Add(teach69);
            var teach70 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment14
            };
            context.Teaches.Add(teach70);
            var teach71 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment15
            };
            context.Teaches.Add(teach71);
            var teach72 = new Teach()
            {
                Teachers = teacher5,
                Subject = subject6,
                StudentDepartments = studentdepartment16
            };
            context.Teaches.Add(teach72);
            var teach73 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment13
            };
            context.Teaches.Add(teach73);
            var teach74 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment14
            };
            context.Teaches.Add(teach74);
            var teach75 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment15
            };
            context.Teaches.Add(teach75);
            var teach76 = new Teach()
            {
                Teachers = teacher6,
                Subject = subject7,
                StudentDepartments = studentdepartment16
            };
            context.Teaches.Add(teach76);
            var teach77 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment13
            };
            context.Teaches.Add(teach77);
            var teach78 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment14
            };
            context.Teaches.Add(teach78);
            var teach79 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment15
            };
            context.Teaches.Add(teach79);
            var teach80 = new Teach()
            {
                Teachers = teacher7,
                Subject = subject9,
                StudentDepartments = studentdepartment16
            };
            context.Teaches.Add(teach80);
            var teach81 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment13
            };
            context.Teaches.Add(teach81);
            var teach82 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment14
            };
            context.Teaches.Add(teach82);
            var teach83 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment15
            };
            context.Teaches.Add(teach83);
            var teach84 = new Teach()
            {
                Teachers = teacher8,
                Subject = subject8,
                StudentDepartments = studentdepartment16
            };
            context.Teaches.Add(teach84);

            //var teach1 = new Teach()
            //{
            //    Teachers = teacher1,
            //    Subjects = subjectgrade1,
            //    StudentDepartments = studentdepartment1
            //};
            //context.Teaches.Add(teach1);

            //var teach2 = new Teach()
            //{
            //    Teachers = teacher1,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment2
            //};
            //context.Teaches.Add(teach2);

            //var teach3 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment3
            //};
            //context.Teaches.Add(teach3);
            //var teach4 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment4
            //};
            //context.Teaches.Add(teach4);
            //var teach5 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade2,
            //    StudentDepartments = studentdepartment1
            //};
            //context.Teaches.Add(teach5);
            //var teach6 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade2,
            //    StudentDepartments = studentdepartment2
            //};
            //context.Teaches.Add(teach6);
            //var teach7 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade2,
            //    StudentDepartments = studentdepartment3
            //};
            //context.Teaches.Add(teach7);
            //var teach8 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade2,
            //    StudentDepartments = studentdepartment4
            //};
            //context.Teaches.Add(teach8);
            //var teach9 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade3,
            //    StudentDepartments = studentdepartment1
            //};
            //context.Teaches.Add(teach9);
            //var teach10 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade3,
            //    StudentDepartments = studentdepartment2
            //};
            //context.Teaches.Add(teach10);
            //var teach11 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade3,
            //    StudentDepartments = studentdepartment3
            //};
            //context.Teaches.Add(teach11);
            //var teach12 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade3,
            //    StudentDepartments = studentdepartment4
            //};
            //context.Teaches.Add(teach12);
            //var teach13 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade4,
            //    StudentDepartments = studentdepartment1
            //};
            //context.Teaches.Add(teach13);
            //var teach14 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade4,
            //    StudentDepartments = studentdepartment2
            //};
            //context.Teaches.Add(teach14);
            //var teach15 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade4,
            //    StudentDepartments = studentdepartment3
            //};
            //context.Teaches.Add(teach15);
            //var teach16 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade4,
            //    StudentDepartments = studentdepartment4
            //};
            //context.Teaches.Add(teach16);
            //var teach17 = new Teach()
            //{
            //    Teachers = teacher1,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment5
            //};
            //context.Teaches.Add(teach17);
            //var teach18 = new Teach()
            //{
            //    Teachers = teacher1,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment6
            //};
            //context.Teaches.Add(teach18);
            //var teach19 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment7
            //};
            //context.Teaches.Add(teach19);
            //var teach20 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment8
            //};
            //context.Teaches.Add(teach20);
            //var teach21 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment5
            //};
            //context.Teaches.Add(teach21);
            //var teach22 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment6
            //};
            //context.Teaches.Add(teach22);
            //var teach23 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment7
            //};
            //context.Teaches.Add(teach23);
            //var teach24 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment8
            //};
            //context.Teaches.Add(teach24);
            //var teach25 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment5
            //};
            //context.Teaches.Add(teach25);
            //var teach26 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment6
            //};
            //context.Teaches.Add(teach26);
            //var teach27 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment7
            //};
            //context.Teaches.Add(teach27);
            //var teach28 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment8
            //};
            //context.Teaches.Add(teach28);
            //var teach29 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment5
            //};
            //context.Teaches.Add(teach29);
            //var teach30 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment6
            //};
            //context.Teaches.Add(teach30);
            //var teach31 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment7
            //};
            //context.Teaches.Add(teach31);
            //var teach32 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment8
            //};
            //context.Teaches.Add(teach32);
            //var teach33 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment5
            //};
            //context.Teaches.Add(teach33);
            //var teach34 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment6
            //};
            //context.Teaches.Add(teach34);
            //var teach35 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment7
            //};
            //context.Teaches.Add(teach35);
            //var teach36 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment8
            //};
            //context.Teaches.Add(teach36);
            //var teach37 = new Teach()
            //{
            //    Teachers = teacher1,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment9
            //};
            //context.Teaches.Add(teach37);
            //var teach38 = new Teach()
            //{
            //    Teachers = teacher1,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment10
            //};
            //context.Teaches.Add(teach38);
            //var teach39 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment11
            //};
            //context.Teaches.Add(teach39);
            //var teach40 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment12
            //};
            //context.Teaches.Add(teach40);
            //var teach41 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment9
            //};
            //context.Teaches.Add(teach41);
            //var teach42 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment10
            //};
            //context.Teaches.Add(teach42);
            //var teach43 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment11
            //};
            //context.Teaches.Add(teach43);
            //var teach44 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment12
            //};
            //context.Teaches.Add(teach44);
            //var teach45 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment9
            //};
            //context.Teaches.Add(teach45);
            //var teach46 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment10
            //};
            //context.Teaches.Add(teach46);
            //var teach47 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment11
            //};
            //context.Teaches.Add(teach47);
            //var teach48 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment12
            //};
            //context.Teaches.Add(teach48);
            //var teach49 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment9
            //};
            //context.Teaches.Add(teach49);
            //var teach50 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment10
            //};
            //context.Teaches.Add(teach50);
            //var teach51 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment11
            //};
            //context.Teaches.Add(teach51);
            //var teach52 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment12
            //};
            //context.Teaches.Add(teach52);
            //var teach53 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment9
            //};
            //context.Teaches.Add(teach53);
            //var teach54 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment10
            //};
            //context.Teaches.Add(teach54);
            //var teach55 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment11
            //};
            //context.Teaches.Add(teach55);
            //var teach56 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment12
            //};
            //context.Teaches.Add(teach56);
            //var teach57 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment9
            //};
            //context.Teaches.Add(teach57);
            //var teach58 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment10
            //};
            //context.Teaches.Add(teach58);
            //var teach59 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment11
            //};
            //context.Teaches.Add(teach59);
            //var teach60 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment12
            //};
            //context.Teaches.Add(teach60);
            //var teach61 = new Teach()
            //{
            //    Teachers = teacher1,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment13
            //};
            //context.Teaches.Add(teach61);
            //var teach62 = new Teach()
            //{
            //    Teachers = teacher1,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment14
            //};
            //context.Teaches.Add(teach62);
            //var teach63 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment15
            //};
            //context.Teaches.Add(teach63);
            //var teach64 = new Teach()
            //{
            //    Teachers = teacher2,
            //    SubjectGrades = subjectgrade1,
            //    StudentDepartments = studentdepartment16
            //};
            //context.Teaches.Add(teach64);
            //var teach65 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment13
            //};
            //context.Teaches.Add(teach65);
            //var teach66 = new Teach()
            //{
            //    Teachers = teacher3,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment14
            //};
            //context.Teaches.Add(teach66);
            //var teach67 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment15
            //};
            //context.Teaches.Add(teach67);
            //var teach68 = new Teach()
            //{
            //    Teachers = teacher4,
            //    SubjectGrades = subjectgrade5,
            //    StudentDepartments = studentdepartment16
            //};
            //context.Teaches.Add(teach68);
            //var teach69 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment13
            //};
            //context.Teaches.Add(teach69);
            //var teach70 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment14
            //};
            //context.Teaches.Add(teach70);
            //var teach71 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment15
            //};
            //context.Teaches.Add(teach71);
            //var teach72 = new Teach()
            //{
            //    Teachers = teacher5,
            //    SubjectGrades = subjectgrade6,
            //    StudentDepartments = studentdepartment16
            //};
            //context.Teaches.Add(teach72);
            //var teach73 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment13
            //};
            //context.Teaches.Add(teach73);
            //var teach74 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment14
            //};
            //context.Teaches.Add(teach74);
            //var teach75 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment15
            //};
            //context.Teaches.Add(teach75);
            //var teach76 = new Teach()
            //{
            //    Teachers = teacher6,
            //    SubjectGrades = subjectgrade7,
            //    StudentDepartments = studentdepartment16
            //};
            //context.Teaches.Add(teach76);
            //var teach77 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment13
            //};
            //context.Teaches.Add(teach77);
            //var teach78 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment14
            //};
            //context.Teaches.Add(teach78);
            //var teach79 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment15
            //};
            //context.Teaches.Add(teach79);
            //var teach80 = new Teach()
            //{
            //    Teachers = teacher7,
            //    SubjectGrades = subjectgrade9,
            //    StudentDepartments = studentdepartment16
            //};
            //context.Teaches.Add(teach80);
            //var teach81 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment13
            //};
            //context.Teaches.Add(teach81);
            //var teach82 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment14
            //};
            //context.Teaches.Add(teach82);
            //var teach83 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment15
            //};
            //context.Teaches.Add(teach83);
            //var teach84 = new Teach()
            //{
            //    Teachers = teacher8,
            //    SubjectGrades = subjectgrade8,
            //    StudentDepartments = studentdepartment16
            //};
            //context.Teaches.Add(teach84);

            //make some marks
            var mark1 = new Mark()
            {
                MarkValue = 5,
                Teaches = teach1
            };
            context.Marks.Add(mark1);

            var mark2 = new Mark()
            {
                MarkValue = 4,
                Teaches = teach1
            };
            context.Marks.Add(mark2);

            var mark3 = new Mark()
            {
                MarkValue = 2,
                Teaches = teach2
            };
            context.Marks.Add(mark3);

            var mark4 = new Mark()
            {
                MarkValue = 3,
                Teaches = teach2
            };
            context.Marks.Add(mark4);

            var mark5 = new Mark()
            {
                MarkValue = 3,
                Teaches = teach1
            };
            context.Marks.Add(mark5);

            var mark6 = new Mark()
            {
                MarkValue = 5,
                Teaches = teach34
            };
            context.Marks.Add(mark6);

            var mark7 = new Mark()
            {
                MarkValue = 5,
                Teaches = teach39
            };
            context.Marks.Add(mark7);

            var mark8 = new Mark()
            {
                MarkValue = 1,
                Teaches = teach40
            };
            context.Marks.Add(mark8);

            var mark9 = new Mark()
            {
                MarkValue = 1,
                Teaches = teach50
            };
            context.Marks.Add(mark9);

            var mark10 = new Mark()
            {
                MarkValue = 5,
                Teaches = teach33
            };
            context.Marks.Add(mark10);

            var mark11 = new Mark()
            {
                MarkValue = 5,
                Teaches = teach33
            };
            context.Marks.Add(mark11);

            var mark12 = new Mark()
            {
                MarkValue = 5,
                Teaches = teach80
            };
            context.Marks.Add(mark12);

            var mark13 = new Mark()
            {
                MarkValue = 4,
                Teaches = teach84
            };
            context.Marks.Add(mark13);

            var mark14 = new Mark()
            {
                MarkValue = 3,
                Teaches = teach76
            };
            context.Marks.Add(mark14);

            var mark15 = new Mark()
            {
                MarkValue = 1,
                Teaches = teach65
            };
            context.Marks.Add(mark15);

            var mark16 = new Mark()
            {
                MarkValue = 3,
                Teaches = teach40
            };
            context.Marks.Add(mark16);

            base.Seed(context);
        }
    
        private string ReturnUserRole(AppUser user)
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