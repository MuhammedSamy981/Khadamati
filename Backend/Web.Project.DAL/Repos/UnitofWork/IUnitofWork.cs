using FinalProject.Dal;
    public interface IUnitofWork
    {
        IBookMarkRepo BookmarkRepo { get; }
        IUserRepo UserRepo { get; }
        IServiceRepo ServiceRepo { get; }
        IRequestrepo RequestRepo { get; }
        INotificationRepo NotificationRepo { get; }
        IRatingRepo RatingRepo { get; }
        IPictureRepo PictureRepo { get; }
        ICategoryrepo CategoryRepo { get; }

        int SaveChanges();
    }
