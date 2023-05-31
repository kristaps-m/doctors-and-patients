namespace doctors_and_patients.Core.Interfaces
{
    public interface IEntityService<T> where T : Entity
    {
        void Create(Entity entity);
        void Delete(Entity entity);
        void Update(Entity entity);
        List<T> GetAll();
        Entity GetById(int id);
        IQueryable<Entity> Query();
    }
}
