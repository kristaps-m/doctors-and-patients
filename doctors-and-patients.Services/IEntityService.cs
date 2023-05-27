using doctors_and_patients.Core;

namespace doctors_and_patients.Services
{
    public interface IEntityService<T> where T : Entity
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
        IQueryable<T> Query();
    }
}
