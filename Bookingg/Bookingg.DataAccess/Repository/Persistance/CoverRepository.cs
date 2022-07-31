using Booking.Models;
using Bookingg.Data;
using Bookingg.DataAccess.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookingg.DataAccess.Repository.Persistance
{
    public class CoverRepository : Repository<CoverType>, ICoverRepository
    {
        private ApplicationDbContext _db;
        public CoverRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
