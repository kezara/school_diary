using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("DataAccessConnection")
        {
            Database.SetInitializer<DataAccessContext>(new DropCreateDatabaseIfModelChanges<DataAccessContext>());
            //Database.SetInitializer<DataAccessContext>(new DataAccessContextInitializer());
        }

        public DbSet<ClassRoom> ClassRooms { get; set; }
        //public DbSet<CategoryModel> CategoryModels { get; set; }
        //public DbSet<OfferModel> OfferModels { get; set; }
        //public DbSet<BillModel> BillModels { get; set; }
        //public DbSet<VoucherModel> VoucherModels { get; set; }
    }
}