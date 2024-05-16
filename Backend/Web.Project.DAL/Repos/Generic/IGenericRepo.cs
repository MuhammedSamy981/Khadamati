using FinalProject.Dal;

public interface IGenericRepo<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    TEntity? GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void DeleteById(int id);
    void RemoveEntity(TEntity tentity);
    int SaveDbChange();
}