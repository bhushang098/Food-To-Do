using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodToDo.Core;

namespace FoodToDo.Data
{
    public class FoodToDoContext : DbContext
    {
        public FoodToDoContext (DbContextOptions<FoodToDoContext> options)
            : base(options)
        {
        }

        public DbSet<FoodToDo.Core.Restorant>? Restorant { get; set; }
    }
}
