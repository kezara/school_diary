using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using school_diary.Infrastructure;
using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Security;

namespace Project_Repository.Models
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

            //make some students with parents
            var students = new List<AppUser>
            {
                new Student { UserName = "aleksastudent", PasswordHash = HashedPassword("test123"), FirstName = "Aleksa", LastName = "Ignjatov",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "brankicaparent")
                } },
                new Student { UserName = "petarstudent", PasswordHash = HashedPassword("test123"), FirstName = "Petar", LastName = "Ignjatov",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "brankicaparent")
                } },
                new Student { UserName = "strahinjastudent", PasswordHash = HashedPassword("test123"), FirstName = "Strahinja", LastName = "Nikolic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "djordjeparent"),
                    parents.Find(p => p.UserName == "gabrijelaparent")
                } },
                new Student { UserName = "filipstudent", PasswordHash = HashedPassword("test123"), FirstName = "Filip", LastName = "Antanasijevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "goranparent"),
                    parents.Find(p => p.UserName == "jelenaparent")
                } },
                new Student { UserName = "ivastudent", PasswordHash = HashedPassword("test123"), FirstName = "Iva", LastName = "Antanasijevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "goranparent"),
                    parents.Find(p => p.UserName == "jelenaparent")
                } },
                new Student { UserName = "aleksandarstudent", PasswordHash = HashedPassword("test123"), FirstName = "Aleksandar", LastName = "Djordjevic" ,
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "branislavparent"),
                    parents.Find(p => p.UserName == "ivanaparent")
                } },
                new Student { UserName = "vukasinstudent", PasswordHash = HashedPassword("test123"), FirstName = "Vukasin", LastName = "Djordjevic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "branislavparent"),
                    parents.Find(p => p.UserName == "ivanaparent")
                } },
                new Student { UserName = "urosstudent", PasswordHash = HashedPassword("test123"), FirstName = "Uros", LastName = "Backulic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "zeljkoparent"),
                    parents.Find(p => p.UserName == "marijaparent")
                } },
                new Student { UserName = "vukasinpstudent", PasswordHash = HashedPassword("test123"), FirstName = "Vukasin", LastName = "Pavlica",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "jelenapparent")
                }  },
                new Student { UserName = "milosstudent", PasswordHash = HashedPassword("test123"), FirstName = "Milos", LastName = "Miskovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "milanparent"),
                    parents.Find(p => p.UserName == "milenaparent")
                } },
                new Student { UserName = "dunjastudent", PasswordHash = HashedPassword("test123"), FirstName = "Dunja", LastName = "Miskovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "milanparent"),
                    parents.Find(p => p.UserName == "milenaparent")
                } },
                new Student { UserName = "vukasinzstudent", PasswordHash = HashedPassword("test123"), FirstName = "Vukasin", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "stanislavparent"),
                    parents.Find(p => p.UserName == "cicaparent")
                }},
                new Student { UserName = "teastudent", PasswordHash = HashedPassword("test123"), FirstName = "Tea", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "stanislavparent"),
                    parents.Find(p => p.UserName == "cicaparent")
                } },
                new Student { UserName = "miastudent", PasswordHash = HashedPassword("test123"), FirstName = "Mia", LastName = "Zirovic",
                Parents = new List<Parent>()
                {
                    parents.Find(p => p.UserName == "sandraparent")
                } }
            };

            students.ForEach(a => manager.Create(a));
            students.ForEach(a => manager.AddToRole(a.Id, returnUserRole(a)));

            //make some classRooms
            var classRooms = new List<ClassRoom>
            {
                new ClassRoom { Year = 5, ClassName = "V-1" },
                new ClassRoom { Year = 5, ClassName = "V-2" },
                new ClassRoom { Year = 6, ClassName = "VI-1" },
                new ClassRoom { Year = 6, ClassName = "VI-2" },
                new ClassRoom { Year = 7, ClassName = "VII-1" },
                new ClassRoom { Year = 7, ClassName = "VII-2" },
                new ClassRoom { Year = 8, ClassName = "VIII-1" },
                new ClassRoom { Year = 8, ClassName = "VIII-2" },
            };

            context.ClassRooms.AddRange(classRooms);

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
                new Subject { SubjectName = "Biologija 8"},
            };
            context.Subjects.AddRange(subjects);

            //make some grades
            var grades = new List<Grade>
            {
                new Grade { GradeValue = 1, GradeDesc = "Nedovoljan"},
                new Grade { GradeValue = 2, GradeDesc = "Dovoljan"},
                new Grade { GradeValue = 3, GradeDesc = "Dobar"},
                new Grade { GradeValue = 4, GradeDesc = "Vrlo dobar"},
                new Grade { GradeValue = 5, GradeDesc = "Odlican"},
            };
            context.Grades.AddRange(grades);

            base.Seed(context);
        }

        
        
   

    

        

        private static string  HashedPassword(string password)
        {
            var pass = new PasswordHasher();
            var hashed = pass.HashPassword(password);
            return hashed;
        }

        private void UsersToDB(List<AppUser> users, AuthContext context)
        {
            var store = new UserStore<AppUser>(context);
            var manager = new UserManager<AppUser>(store);
            foreach (var user in users)
            {
                manager.Create(user);
                manager.AddToRole(user.Id, returnUserRole(user));
            }
        }

        private string returnUserRole(AppUser user)
        {
            string role = null;
            switch (user.GetType().Name)
            {
                case "Admin" : role = "admins";
                    break;
                case "Student": role = "students";
                    break;
                case "Parent": role = "parents";
                    break;
                case "Teacher": role = "teachers";
                    break;
                default:
                    break;
            }
            return role;
        }
        
    }
}
//            // kreiranje korisnika
//            IList<UserModel> users = new List<UserModel>();
//            UserModel user1 = new UserModel() { FirstName = "Boris", LastName = "Nedic", Username = "nedic", Password = "password", Email = "boris.nedic@gmail.com", UserRole = UserRoles.ROLE_SELLER };
//            users.Add(user1);
//            UserModel user2 = new UserModel() { FirstName = "Aleksandra", LastName = "Vukovic", Username = "vukovic", Password = "password", Email = "aleksandra.vukovic@gmail.com", UserRole = UserRoles.ROLE_SELLER };
//            users.Add(user2);
//            UserModel user3 = new UserModel() { FirstName = "Svetlana", LastName = "Radovanovic", Username = "radovanovic", Password = "password", Email = "svetlana.radovanovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER };
//            users.Add(user3);
//            users.Add(new UserModel() { FirstName = "Nikola", LastName = "Brankovic", Username = "brankovic", Password = "password", Email = "nikola.brankovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Cedomir", LastName = "Ribic", Username = "ribic", Password = "password", Email = "cedomir.ribic@gmail.com", UserRole = UserRoles.ROLE_SELLER });
//            users.Add(new UserModel() { FirstName = "Dusko", LastName = "Kovac", Username = "kovac", Password = "password", Email = "dusko.kovac@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Milan", LastName = "Golubovic", Username = "golubovic", Password = "password", Email = "milan.golubovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Milan", LastName = "Ludoski", Username = "ludoski", Password = "password", Email = "milan.ludoski@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Milan", LastName = "Kablar", Username = "kablar", Password = "password", Email = "milan.kablar@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Nemanja", LastName = "Vujic", Username = "vujic", Password = "password", Email = "nemanja.vujic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Borislav", LastName = "Petrovic", Username = "petrovic", Password = "password", Email = "borislav.petrovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Vladimir", LastName = "Gvozdenovic", Username = "gvozdenovic", Password = "password", Email = "vladimir.gvozdenovic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Vladimir", LastName = "Cavic", Username = "cavic", Password = "password", Email = "vladimir.cavic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Zlatko", LastName = "Spasojevic", Username = "spasojevic", Password = "password", Email = "zlatko.spasojevic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            users.Add(new UserModel() { FirstName = "Zoran", LastName = "Tomic", Username = "tomic", Password = "password", Email = "zoran.tomic@gmail.com", UserRole = UserRoles.ROLE_CUSTOMER });
//            context.UserModels.AddRange(users);

//            // kreiranje kategorija
//            IList<CategoryModel> categories = new List<CategoryModel>();
//            CategoryModel category1 = new CategoryModel() { CategoryName = "Frizider", CategoryDescription = "Bela tehnika" };
//            categories.Add(category1);
//            CategoryModel category2 = new CategoryModel() { CategoryName = "Sporet", CategoryDescription = "Bela tehnika" };
//            categories.Add(category2);
//            context.CategoryModels.AddRange(categories);

//            //// kreiranje ponuda
//            IList<OfferModel> offers = new List<OfferModel>();
//            OfferModel offer1 = new OfferModel()
//            {
//                OfferName = "Ponuda 1",
//                OfferDescription = "Ponuda 1",
//                OfferCreated = new DateTime(2018, 5, 5),
//                OfferExpires = new DateTime(2018, 5, 10),
//                RegularPrice = 4.34m,
//                ActionPrice = 4.12m,
//                ImagePath = "",
//                AvailableOffers = 2,
//                BoughtOffers = 10,
//                OfferStatus = OfferStatus.WAIT_FOR_APPROVING,
//                CategoryModel = category1,
//                UserModel = user1
//            };
//            offers.Add(offer1);

//            OfferModel offer2 = new OfferModel()
//            {
//                OfferName = "Ponuda 2",
//                OfferDescription = "Ponuda 2",
//                OfferCreated = new DateTime(2018, 5, 5),
//                OfferExpires = new DateTime(2018, 5, 20),
//                RegularPrice = 5.34m,
//                ActionPrice = 3.12m,
//                ImagePath = "",
//                AvailableOffers = 1,
//                BoughtOffers = 4,
//                OfferStatus = OfferStatus.WAIT_FOR_APPROVING,
//                CategoryModel = category1,
//                UserModel = user2
//            };
//            offers.Add(offer2);

//            OfferModel offer3 = new OfferModel()
//            {
//                OfferName = "Ponuda 3",
//                OfferDescription = "Ponuda 3",
//                OfferCreated = new DateTime(2018, 5, 5),
//                OfferExpires = new DateTime(2018, 5, 30),
//                RegularPrice = 10.34m,
//                ActionPrice = 5.12m,
//                ImagePath = "",
//                AvailableOffers = 10,
//                BoughtOffers = 6,
//                OfferStatus = OfferStatus.WAIT_FOR_APPROVING,
//                CategoryModel = category2,
//                UserModel = user2
//            };
//            offers.Add(offer3);
//            context.OfferModels.AddRange(offers);

//            //// kreiranje racuna
//            IList<BillModel> bills = new List<BillModel>();
//            BillModel bill1 = new BillModel()
//            {
//                PaymentMade = false,
//                PaymentCanceled = false,
//                BillCreated = new DateTime(2018, 4, 1),
//                Offers = offer1,
//                UserModel = user3
//            };
//            bills.Add(bill1);

//            BillModel bill2 = new BillModel()
//            {
//                PaymentMade = false,
//                PaymentCanceled = false,
//                BillCreated = new DateTime(2019, 3, 5),
//                Offers = offer2,
//                UserModel = user3
//            };
//            bills.Add(bill2);

//            BillModel bill3 = new BillModel()
//            {
//                PaymentMade = false,
//                PaymentCanceled = false,
//                BillCreated = DateTime.Now,
//                Offers = offer3,
//                UserModel = user3
//            };
//            bills.Add(bill3);
//            context.BillModels.AddRange(bills);

//            //// kreiranje vaucera
//            IList<VoucherModel> vouchers = new List<VoucherModel>();
//            VoucherModel voucher1 = new VoucherModel()
//            {
//                ExpirationDate = new DateTime(2018, 1, 1),
//                IsUsed = false,
//                OfferModels = offer1,
//                UserModel = user3
//            };
//            vouchers.Add(voucher1);

//            VoucherModel voucher2 = new VoucherModel()
//            {
//                ExpirationDate = new DateTime(2018, 6, 6),
//                IsUsed = false,
//                OfferModels = offer2,
//                UserModel = user3
//            };
//            vouchers.Add(voucher2);

//            VoucherModel voucher3 = new VoucherModel()
//            {
//                ExpirationDate = new DateTime(2018, 10, 10),
//                IsUsed = false,
//                OfferModels = offer3,
//                UserModel = user3
//            };
//            vouchers.Add(voucher3);
//            context.VoucherModels.AddRange(vouchers);

//            base.Seed(context);
//        }
//    }
//}