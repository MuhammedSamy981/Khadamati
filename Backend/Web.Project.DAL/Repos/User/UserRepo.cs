using Microsoft.AspNetCore.Identity;
using System.Linq;
using FinalProject.Dal;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserManager<User> UserManager { get; set; }
        public KhadamatiContext Context { get; set; }
        public UserRepo(KhadamatiContext context) : base(context)
        {
            Context = context;
        }
        public List<User> GetAllUsers()
        {
            List<string>ids = Context.UserClaims.Where(i => i.ClaimValue == "User").Select(i =>i.UserId).ToList();
            List<User> users = new List<User>();
            foreach(string id in ids )
            {
                users.Add(GetUserById(id));
            }
            return users;
        }
        public List<User> GetAllAdmins()
        {
            List<string> ids = Context.UserClaims.Where(i => i.ClaimValue == "Admin").Select(i => i.UserId).ToList();
            List<User> users = new List<User>();
            foreach (string id in ids)
            {
                if (!Context.UserClaims.Where(i => i.UserId == id).Select(i => i.ClaimValue).ToList().Contains("Manger"))
                { 
                    users.Add(GetUserById(id)); 
                }
            }
            return users;
        }

        public User GetUserById(string id)
        {
            return Context.Set<User>().Find(id);
        }
        public User GeUserDetailsbyId(string id)
        {
            return Context.Set<User>()
                .Include(i=>i.Services).ThenInclude(s=>s.Ratings)
                .Include(i => i.Services).ThenInclude(s => s.Requests)
                .Include(i=>i.Bookmarks).ThenInclude(b=>b.Service)
                .Include(i=>i.UserRequests).ThenInclude(b => b.Service)
                .Include(i=>i.Notifications)
                .Include(i=>i.Ratings).ThenInclude(r=>r.Service)
                .FirstOrDefault(i=>i.Id==id)!;
        }
        public User UserBookMarks(string id)
        {
            return Context.Set<User>()
                .Include(i => i.Bookmarks).ThenInclude(b => b.Service)
                .FirstOrDefault(i => i.Id == id)!;
        }

    }

