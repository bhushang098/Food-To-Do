using FoodToDo.Core;

namespace FoodToDo.Data
{
    public class InMemoryRestorantData : IRestorantData
    {

        List<Restorant> restorants;

        public InMemoryRestorantData()
        {
            restorants = new List<Restorant>()
            {
                new Restorant{Id = 1, Name = "Dhaba Bhantida",Location="Pune",cuisiine=CuisiineType.Indian},
                new Restorant{Id = 2, Name = "despac'ito",Location="Lasca di pal",cuisiine=CuisiineType.Mexican},
                new Restorant{Id = 3, Name = "Winterfell",Location="Serio forel",cuisiine=CuisiineType.Italian}

            };
        }

        public Restorant add(Restorant newRestorant)
        {
            newRestorant.Id = restorants.Max(r => r.Id)+1;

            restorants.Add(newRestorant);

            return newRestorant;
        }

        public int commit()
        {
            return 0;
        }

        public Restorant delete(int id)
        {
           var restorant = restorants.FirstOrDefault(r => r.Id == id);

            if(restorant != null)
            {
                restorants.Remove(restorant);
            }
            return restorant;
        }

        public IEnumerable<Restorant> getAll()
        {
            return from r in restorants
                   orderby r.Name
                   select r;
        }

        public int getCountOfRestorats()
        {
            return restorants.Count();

        }

        public Restorant getRestorantById(int id)
        {
            return restorants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restorant> getRestorantsByName(string searchTerm = null)
        {
            return from r in restorants
                   where string.IsNullOrEmpty(searchTerm) || r.Name.StartsWith(searchTerm)
                   orderby r.Name
                   select r;
        }

        public Restorant Update(Restorant updatedRestorant)
        {
            var restorant = restorants.SingleOrDefault(r => r.Id == updatedRestorant.Id);

            if (restorant != null)
            {
                restorant.Name = updatedRestorant.Name;
                restorant.Location = updatedRestorant.Location;
                restorant.cuisiine = updatedRestorant.cuisiine;

            }

            return restorant;
        }
    }


}
