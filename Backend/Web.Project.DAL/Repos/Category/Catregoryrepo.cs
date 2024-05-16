using System.Linq;
using FinalProject.Dal;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;

public class Catregoryrepo:ICategoryrepo
{
    KhadamatiContext _context;

    public Catregoryrepo(KhadamatiContext context)
    {
         _context = context;
    }

    public void Add(Category category)
    {
        _context.Set<Category>().Add(category);
    }

    public List<Category> GetAll()
    {
        return _context.Set<Category>().ToList();
    }

    public Category? GetbyID(int id)
    {
        return _context.Set<Category>().Find(id);
    }

    public void Remove(Category category)
    {
       if (category != null&&_context.Categories.Count()!=0)
        {
            List<Service>s=_context.Services.Where(s => s.CategoryId== category.Id).ToList();
            foreach(Service service in s)
            {
                service.CategoryId = _context.Categories.FirstOrDefault(s=>s.Id!=category.Id).Id;
            }
            _context.Set<Category>().Remove(category);
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(Category category)
    {
       
    }
}
