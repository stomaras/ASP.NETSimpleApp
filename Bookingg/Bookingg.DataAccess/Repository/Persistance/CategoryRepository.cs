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

    // Unit of Work Will be a parent wrapper for all the repositories which we have created
    public class CategoryRepository : Repository<Category> , ICategoryReposiotry
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
