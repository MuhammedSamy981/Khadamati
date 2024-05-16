using FinalProject.Dal;
    public class RatingManager : IRatingManager
    {
        private readonly IRatingRepo _ratingrepo;
        public RatingManager(IRatingRepo rr)
        {
            _ratingrepo = rr;
        }
  
        public RatingDto  GetRatingByUserAndService(int sid,string uid)
        {
            {
                var rating = _ratingrepo. GetRatingByUserAndService(sid,uid);
                return new RatingDto
                {
                    Id = rating.Id,
                    UserName=rating.User.UserName,
                    date=rating.date
                };

            }
        }
        public void DeleteRating(int id)
        {
            
                _ratingrepo.Delete(id);
            
        }
        public void AddRating(RatingAddDto rating)
        {

            _ratingrepo.Add(new Rating
            {
                ServiceId = rating.ServiceId,
                UserId = rating.UserId,
                Comment = rating.Comment,
                rating = rating.rating,
                date = DateTime.Now,
            });

        }

    }


