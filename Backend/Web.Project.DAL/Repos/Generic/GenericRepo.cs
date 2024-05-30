using System.Linq;
using FinalProject.Dal;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    private readonly KhadamatiContext _context;

    public GenericRepo(KhadamatiContext context)
    {
      _context=context;
    }

    public List<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();   
    }

    public TEntity? GetById(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }
    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void DeleteById(int id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        _context.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
    public int SaveDbChange()
    {
       return _context.SaveChanges();
    }

    public void RemoveEntity(TEntity tentity)
    {
         _context.Set<TEntity>().Remove(tentity);
    }
}