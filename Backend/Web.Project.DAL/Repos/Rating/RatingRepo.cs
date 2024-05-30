using System.Linq;
using FinalProject.Dal;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;

    public class RatingRepo : IRatingRepo
    {
        private readonly KhadamatiContext _db;

        public RatingRepo(KhadamatiContext db)
        {
            _db = db;
        }
        public void Add(Rating rating)
        {
            _db.Ratings.Add(rating);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var rating = _db.Ratings.Find(id);
            _db.Ratings.Remove(rating);
            _db.SaveChanges();
        }

        public Rating GetRatingByUserAndService(int sid,string uid)
        {
            var rating = _db.Ratings.Where(r => r.ServiceId == sid && r.UserId==uid)
            .Include(r=>r.User).FirstOrDefault();
            return rating;
        }

    public void RemoveEntity(Rating r)
    {
        throw new NotImplementedException();
    }
}
