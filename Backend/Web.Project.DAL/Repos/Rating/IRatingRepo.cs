using FinalProject.Dal;
    public interface IRatingRepo
    {
         void Add(Rating rating);
         void Delete(int id);
         Rating GetRatingByUserAndService(int sid,string uid);
    void RemoveEntity(Rating r);
}

