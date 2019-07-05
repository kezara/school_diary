//using System;
//using System.Collections.Generic;
//using System.Data.Entity;

//namespace Project_Repository.Models
//{
//    public class DataAccessContextInitializer : DropCreateDatabaseIfModelChanges<DataAccessContext>
//    {
//        protected override void Seed(DataAccessContext context)
//        {
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