using Booking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookingg.Utility
{
    public static class SeedExtension
    {

            public static void Seed(this ModelBuilder modelBuilder)
            {
                    modelBuilder.Entity<CoverType>().HasData(
                        new CoverType
                        {
                            Id = 1,
                            Name = "Fabric",
                            Price = 20
                        },
                        new CoverType
                        {
                            Id = 2,
                            Name = "Leather",
                            Price = 15
                        },
                        new CoverType
                        {
                            Id = 3,
                            Name = "Vegan",
                            Price = 9
                        },
                        new CoverType
                        {
                            Id = 4,
                            Name = "Sofa",
                            Price = 30
                        },
                         new CoverType
                         {
                             Id = 5,
                             Name = "Armani",
                             Price = 35
                         }
                    );

            }
    }
}
