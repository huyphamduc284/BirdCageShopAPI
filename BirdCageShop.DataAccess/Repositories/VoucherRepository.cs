

using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BirdCageShop.DataAccess.Models;

namespace BirdCageShop.DataAccess.Repositories 
{

    public partial interface IVoucherRepository : IBaseRepository<Voucher>
    {
        void Delete(object existingVoucher);
        IEnumerable<object> GetAll();
        object GetById(int idTmp);
    }
    public partial class VoucherRepository :BaseRepository<Voucher>, IVoucherRepository
    {
         public VoucherRepository(DbContext dbContext) : base(dbContext)
         {
         }

        public void Delete(object existingVoucher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetById(int idTmp)
        {
         
            throw new NotImplementedException();
        }
    }
}


