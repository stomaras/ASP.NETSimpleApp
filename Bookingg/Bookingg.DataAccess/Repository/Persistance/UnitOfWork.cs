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
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverRepository(_db);
            Product = new ProductRepository(_db);
        }
        public ICategoryReposiotry Category { get; private set; }
        public ICoverRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }

        public void Save()  
        {
            _db.SaveChanges();
        }
    }
}
