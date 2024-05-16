using FinalProject.Dal;

public class ServiceManager : IServiceManager
{
    private readonly IServiceRepo _serviceRepo;
    private readonly IUnitofWork unitofWork;


    public ServiceManager(IServiceRepo serviceRepo,IUnitofWork _unitofWork)
    {
        _serviceRepo=serviceRepo;
         unitofWork=_unitofWork;
    }
    public void Add(AddServiceDTO serviceDTO)
    {
        var service=new Service
        {
          Name=serviceDTO.Name,
          CategoryId=serviceDTO.CategoryId,
          Price=serviceDTO.Price,
          Location=serviceDTO.Location,
          Description=serviceDTO.Description,
          date=DateTime.Now,
          ProviderId=serviceDTO.ProviderId,
        };
        _serviceRepo.Add(service);
        _serviceRepo.SaveDbChange();
    }

    public void DeleteById(int id)
    {
        Service s = unitofWork.ServiceRepo.GetDetailsById(id);
        List<Picture>PICS= s.Pictures.ToList();
        List<Rating> ratings = s.Ratings.ToList();
        List<ServiceRequest> requests = s.Requests.ToList();
        List<BookMark> bookMarks = s.BookMarks.ToList();
        foreach (Picture p in PICS)
        {
            unitofWork.PictureRepo.Delete(p);
        }
        foreach (Rating r in ratings)
        {
            unitofWork.RatingRepo.RemoveEntity(r);
        }
        foreach (BookMark b in bookMarks)
        {
            unitofWork.BookmarkRepo.RemoveEntity(b);
        }
        foreach (ServiceRequest r in requests)
        {
            unitofWork.RequestRepo.RemoveEntity(r);
        }
        _serviceRepo.DeleteById(id);
        _serviceRepo.SaveDbChange();
    }

    public List<GetAllServicesDTO> GetAll()
    {
        List<Service>services=_serviceRepo.GetAll();
        return services.Select(s=>new GetAllServicesDTO
        {
          Id=s.Id,
          Name=s.Name,
          CategoryName=s.Category.Name,
          Price=s.Price,
          Approved=s.Approved,
          date=s.date,
          ProviderId= s.ProviderId
        }).ToList();
    }

    public List<GetAllServicesDetailsDTO> GetAllDetails()
    {
        List<Service> services=_serviceRepo.GetAllDetails();
        return services.Select(s=> new GetAllServicesDetailsDTO
        {
           Id=s.Id,
           Name=s.Name,
           Price=s.Price,
           Location=s.Location,
           Rating=s.Rating,
           Description=s.Description,
           date=s.date,
           ProviderId=s.ProviderId,
           ProviderName=s.Provider.UserName,
           ProviderPhone=s.Provider.PhoneNumber,
           CategoryName=s.Category.Name,
           pictures=s.Pictures.Select(p=>new GetAllPicturesDTO
           {
             Id=p.Id,
             Url=p.Url
           }).ToList(),
           ratings=s.Ratings.Select(r=>new GetAllRatingsDTO
           {
             Id=r.Id,
             UserId=r.UserId,
             Comment=r.Comment,
             rating=r.rating,
             date=r.date
           }).ToList(),
            approved= s.Approved

        }).ToList();
    }

    public GetServiceByIdDTO? GetById(int id)
    {
        var service=_serviceRepo.GetById(id);
        return new GetServiceByIdDTO
        {
            Id=service.Id,
            Name=service.Name,
            Price=service.Price,
            Location=service.Location,
            Rating=service.Rating,
            Description=service.Description,
            date=service.date
        };
    }

    public GetServiceDetailsByIdDTO? GetDetailsById(int id)
    {
        var service=_serviceRepo.GetDetailsById(id);
        return new GetServiceDetailsByIdDTO
        {
            Id=service.Id,
            Name=service.Name,
            Price=service.Price,
            Location=service.Location,
            Rating=service.Rating,
            Description=service.Description,
            date=service.date,
            ProviderId=service.Provider.Id,
            ProviderName=service.Provider.UserName,
            ProviderPhone=service.Provider.PhoneNumber,
            CategoryName=service.Category.Name,
            pictures=service.Pictures.Select(p=> new GetAllPicturesDTO
            {
              Id=p.Id,
              Url=p.Url
            }).ToList(),
            ratings=service.Ratings.Select(r=>new GetAllRatingsDTO
            {
                Id=r.Id,
                UserId=r.UserId,
                UserName=r.User.UserName,
                Comment=r.Comment,
                rating=r.rating,
                date=r.date
            }).ToList()
        };
    }
    

    public List<GetSpecificServicesDetailsDTO> GetSpecificDetails(string loction , string category)
    {
        List<Service> services=_serviceRepo.GetSpecificDetails(loction,category);
        return services.Select(s=> new GetSpecificServicesDetailsDTO
        {
            Id=s.Id,
            Name=s.Name,
            Price=s.Price,
            Location=s.Location,
            Rating=s.Rating,
            Description=s.Description,
            date=s.date,
            ProviderId=s.Provider.Id,
            ProviderName=s.Provider.UserName,
            ProviderPhone=s.Provider.PhoneNumber,
            Category=s.Category.Name,
            pictures=s.Pictures.Select(p=> new GetAllPicturesDTO
            {
              Id=p.Id,
              Url=p.Url
            }).ToList(),
            ratings=s.Ratings.Select(r=>new GetAllRatingsDTO
            {
                Id=r.Id,
                UserId=r.UserId,
                Comment=r.Comment,
                rating=r.rating,
                date=r.date
            }).ToList()
        }).ToList();
    }


    public bool Update(UpdateServiceDTO serviceDTO)
    {
       var service=_serviceRepo.GetById(serviceDTO.Id);
       if(service==null)
       {
        return false;
       }
       service.Name=serviceDTO.Name;
       service.Price=serviceDTO.Price;
       service.Location=serviceDTO.Location;
       service.Description=serviceDTO.Description;

       _serviceRepo.SaveDbChange();
       return true;
    }

    
    public bool approve(int id)
    {
        var service = _serviceRepo.GetById(id);
        service.Approved= true;
        _serviceRepo.SaveDbChange();
        return true;
    }
}