using System.Linq;
using FinalProject.Dal;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;

public class ServiceRepo : IServiceRepo
{
    private readonly KhadamatiContext _context;

    public ServiceRepo(KhadamatiContext context)
    {
      _context=context;
    }

    public List<Service> GetAll()
    {
        return _context.Set<Service>().Include(s=>s.Category).ToList();   
    }

    public List<Service> GetAllDetails()
    {
       return _context.Set<Service>().Include(s=>s.Provider).Include(s=>s.Category)
       .Include(s=>s.Pictures).Include(s=>s.Ratings).ToList();
        
    }

    public Service? GetById(int id)
    {
        return _context.Set<Service>().Find(id);
    }

    public Service? GetDetailsById(int id)
    {
       return _context.Set<Service>().Include(s=>s.Provider).Include(s=>s.Category)
       .Include(s=>s.Pictures).Include(s=>s.Ratings).ThenInclude(r=>r.User)
       .FirstOrDefault(s=>s.Id==id);
    }

    public List<Service> GetSpecificDetails(string loction , string category)
    {
        if(loction=="empty" || category=="empty")
        {
             return _context.Set<Service>()
             .Include(s=>s.Provider).Include(s=>s.Category)
             .Include(s=>s.Pictures).Include(s=>s.Ratings)
             .Where(s=> (s.Category.Name == category)||(s.Location == loction)
             ).ToList();
        }
       
        return _context.Set<Service>()
       .Include(s=>s.Provider).Include(s=>s.Category)
       .Include(s=>s.Pictures).Include(s=>s.Ratings)
       .Where(s=> s.Location == loction && s.Category.Name == category).ToList();

    }

    public void Add(Service service)
    {
        _context.Set<Service>().Add(service);
    }

    public void DeleteById(int id)
    {
        var service = _context.Set<Service>().Find(id);
        _context.Set<Service>().Remove(service);
    }

    public void Update(Service service)
    {
        _context.Set<Service>().Update(service);
    }
    public int SaveDbChange()
    {
       return _context.SaveChanges();
    }

}