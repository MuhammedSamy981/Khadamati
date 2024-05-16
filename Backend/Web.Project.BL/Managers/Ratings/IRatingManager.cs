using FinalProject.Dal;
    public interface IRatingManager
    {
        void AddRating(RatingAddDto rating);
        void DeleteRating(int id);
        RatingDto  GetRatingByUserAndService(int sid,string uid);
    }

