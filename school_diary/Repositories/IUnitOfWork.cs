﻿using school_diary.Models;

namespace school_diary.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<ExampleModel> ExampleRepository { get; }
        //IGenericRepository<CategoryModel> CategoryRepository { get; }
        //IGenericRepository<OfferModel> OfferRepository { get; }
        //IGenericRepository<BillModel> BillRepository { get; }
        //IGenericRepository<VoucherModel> VoucherRepository { get; }
        void Save();
    }
}