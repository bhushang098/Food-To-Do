using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToDo.Core
{
    public class Restorant
    {
        public int Id { get; set; }

        [Required , StringLength(100)]
        public String Name { get; set; }

        [Required, StringLength(100)]
        public String Location { get; set; }

        public CuisiineType cuisiine { get; set; }

    }
}
