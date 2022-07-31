using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookingg.DataAccess.Repository.Core
{
    public interface ICategoryReposiotry : IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}
