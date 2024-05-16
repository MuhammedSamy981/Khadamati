using FinalProject.Dal;

    public interface IBookMarkRepo : IGenericRepo<BookMark>
    {
        BookMark returnBookmark(string uid, int sid);
    }

