using System.Linq;
using FinalProject.Dal;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;
public class Requestrepo : GenericRepo<ServiceRequest>,IRequestrepo
    {
        private KhadamatiContext _context;

        public Requestrepo(KhadamatiContext context) : base(context)
        {
            _context = context;
        }

        public void Add(ServiceRequest request)
        {
            _context.Set<ServiceRequest>().Add(request);
        }
        public List<ServiceRequest>? GetAllWithDetails()
        {
            return _context.Set<ServiceRequest>().
               Include(d => d.Service)
               .Include(d => d.Service)
               .Include(p => p.User)
               .Include(p => p.Provider)
               .ToList();
        }
        public ServiceRequest GetbyId(int Id)
        {
            return _context.Set<ServiceRequest>().Where(d => d.Id == Id).FirstOrDefault();
        }

        public List<ServiceRequest>? GetbyProviderId(string ProviderId)
        {
            return _context.Set<ServiceRequest>().
                Include(d => d.Service)
                .Include(d => d.Service)
                .Include(p => p.User)
                .Include(p => p.Provider)
                .Where(d => d.ProviderId == ProviderId)
                .ToList();

        }

        public List<ServiceRequest>? GetbyUserId(string UserId)
        {
            return _context.Set<ServiceRequest>().
                Include(d => d.Service)
                .Include(d => d.Service)
                .Include(p => p.User)
                .Include(p => p.Provider)
                .Where(d => d.UserId == UserId)
                .ToList();
        }

        public List<ServiceRequest>? GetRequestDetails(int RequestId)
        {
            return _context.Set<ServiceRequest>().
                Include(d => d.Service)
                .Include(d => d.Service)
                .Include(p => p.User)
                .Include(p => p.Provider)
                .Where(d => d.Id == RequestId)
                .ToList();
        }

        public void Remove(ServiceRequest request)
        {
            
            if (request != null)
            {
                _context.Set<ServiceRequest>().Remove(request);
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(ServiceRequest request)
        {
            
        }

        
    }

