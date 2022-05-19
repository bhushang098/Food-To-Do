using FoodToDo.Core;

namespace FoodToDo.Data
{
    public interface IRestorantData
    {
        public IEnumerable<Restorant> getAll();
        public IEnumerable<Restorant> getRestorantsByName(string searchterm);
        public Restorant getRestorantById(int id);
        public Restorant Update(Restorant updatedRestorant);
        public int commit();

        public Restorant add(Restorant newRestorant);

        public Restorant delete(int id);

        public int getCountOfRestorats();
    }

}
