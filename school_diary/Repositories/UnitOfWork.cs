using school_diary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace school_diary.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        [Dependency]
        public IGenericRepository<ExampleModel> ExampleRepository { get; set; }
        //[Dependency]
        //public IGenericRepository<CategoryModel> CategoryRepository { get; set; }
        //[Dependency]
        //public IGenericRepository<OfferModel> OfferRepository { get; set; }
        //[Dependency]
        //public IGenericRepository<BillModel> BillRepository { get; set; }
        //[Dependency]
        //public IGenericRepository<VoucherModel> VoucherRepository { get; set; }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}