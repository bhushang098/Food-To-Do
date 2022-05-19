using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToDo.Core
{
    public class FoodToDoDbContext : DbContext
    {
        public FoodToDoDbContext(DbContextOptions<FoodToDoDbContext> options)
        : base(options) 
        {

        }

        public DbSet<Restorant> Restorants { get; set; }

    }
}
