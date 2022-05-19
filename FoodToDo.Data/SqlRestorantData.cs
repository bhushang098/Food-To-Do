using FoodToDo.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodToDo.Data
{
    public class SqlRestorantData : IRestorantData
    {
        private readonly FoodToDoDbContext db;

        public SqlRestorantData(FoodToDoDbContext db)
        {
            this.db = db;
        }

        public Restorant add(Restorant newRestorant)
        {
            db.Add(newRestorant);
            return newRestorant;
        }

        public int commit()
        {
            return db.SaveChanges();
        }

        public Restorant delete(int id)
        {

            var restorant = db.Restorants.FirstOrDefault(x => x.Id == id);

            if (restorant != null)
            {
                db.Restorants.Remove(restorant);
            }
            return restorant;
        }

        public IEnumerable<Restorant> getAll()
        {
            return db.Restorants;
        }

        public int getCountOfRestorats()
        {
            return db.Restorants.Count();
        }

        public Restorant getRestorantById(int id)
        {
            var restorant = db.Restorants.FirstOrDefault(x => x.Id == id);
            return restorant;
        }

        public IEnumerable<Restorant> getRestorantsByName(string searchterm)
        {
            var query = from r in db.Restorants
                        where r.Name.StartsWith(searchterm) || string.IsNullOrEmpty(searchterm)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restorant Update(Restorant updatedRestorant)
        {
            var entity = db.Restorants.Attach(updatedRestorant);
            entity.State = EntityState.Modified;
            return updatedRestorant;

        }
    }

}
