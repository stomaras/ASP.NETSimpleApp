using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookingg.DataAccess.Repository.Core
{
    public interface IUnitOfWork
    {
        ICategoryReposiotry Category { get; }

        ICoverRepository CoverType { get; }

        IProductRepository Product { get; }

        void Save();
    }
}
