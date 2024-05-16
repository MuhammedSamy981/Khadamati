using System.Linq;
using FinalProject.Dal;
using Microsoft.EntityFrameworkCore;
using WebApplications4.DAL;
    public class UnitofWork : IUnitofWork
    {
        public IUserRepo UserRepo { get; }
        public IBookMarkRepo BookmarkRepo { get; }
        public IServiceRepo ServiceRepo { get; }
        public IRequestrepo RequestRepo { get; }
        public INotificationRepo NotificationRepo { get; }
        public IRatingRepo RatingRepo { get; }
        public ICategoryrepo CategoryRepo { get; }
        public IPictureRepo PictureRepo { get; }

        private readonly KhadamatiContext khadamatiContext;

        public UnitofWork(KhadamatiContext _khadamatiContext,
            IUserRepo u, IBookMarkRepo b, IServiceRepo serviceRepo,
            IRequestrepo requestRepo, INotificationRepo notificationRepo, 
            IRatingRepo ratingRepo, IPictureRepo pictureRepo,
            ICategoryrepo categoryrepo)
        {
            khadamatiContext = _khadamatiContext;
            UserRepo = u;
            BookmarkRepo = b;
            ServiceRepo = serviceRepo;
            RequestRepo = requestRepo;
            NotificationRepo = notificationRepo;
            RatingRepo = ratingRepo;
            PictureRepo = pictureRepo;
            CategoryRepo = categoryrepo;
        }

        public int SaveChanges()
        {
            return khadamatiContext.SaveChanges();
        }
    }
