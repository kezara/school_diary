using school_diary.Models;

namespace school_diary.Repositories
{
    public interface IUnitOfWork
    {
        //IGenericRepository<ExampleModel> ExampleRepository { get; }
        IGenericRepository<ClassRoom> ClassRoomsRepository { get; }
        //IGenericRepository<OfferModel> OfferRepository { get; }
        //IGenericRepository<BillModel> BillRepository { get; }
        //IGenericRepository<VoucherModel> VoucherRepository { get; }
        void Save();
    }
}
