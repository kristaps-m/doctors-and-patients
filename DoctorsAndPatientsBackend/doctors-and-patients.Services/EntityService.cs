using doctors_and_patients.Data;
using doctors_and_patients.Core;
using doctors_and_patients.Core.Interfaces;

namespace doctors_and_patients.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        protected IDoctorsAndPatientsDbContext _context;
        public EntityService(IDoctorsAndPatientsDbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Entity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public Entity GetById(int id)
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IQueryable<Entity> Query()
        {
            return _context.Set<Entity>().AsQueryable();
        }

    }
}
