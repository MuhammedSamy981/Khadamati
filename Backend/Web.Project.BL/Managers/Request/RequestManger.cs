using FinalProject.Dal;
public class RequestManger : IRequestmanager
{
    private IUnitofWork _repo;

    public RequestManger(IUnitofWork repo)
    {
            _repo = repo;
    }
    public int Add(RequestAddDTO RequestFromRequest)
    {
        ServiceRequest request = new ServiceRequest()
        {

            RequestText = RequestFromRequest.RequestText,
            UserId = RequestFromRequest.UserId,
            ProviderId = _repo.ServiceRepo.GetById(RequestFromRequest.ServiceId.Value).ProviderId,
            Status = "Waiting",
            ServiceId = RequestFromRequest.ServiceId,
            date=DateTime.Now
        };
        _repo.RequestRepo.Add(request);
        _repo.SaveChanges();
        return request.Id;
    }

    public bool Delete(int id)
    {
        ServiceRequest? request = _repo.RequestRepo.GetbyId(id);
        if (request == null) return false;
        _repo.RequestRepo.Remove(request);
        _repo.SaveChanges();
        return true;
    }

    public List<RequestDetailsDTO> GetbyIdDetails(int DetailsId)
    {
        List<RequestDetailsDTO> request = _repo.RequestRepo.GetRequestDetails(DetailsId).Select(i =>
        new RequestDetailsDTO
        {
            Id = i.Id,
            RequestText = i.RequestText,
            date = i.date,
            ProviderDetails = new RequestChildProviderDetailsDTO 
            { 
                ProviderName = i.Provider.UserName,
                ProviderID=i.ProviderId
            },
            ServiceDetails = new RequestChildServiceDetailsDTO
            {
                Name = i.Service.Name,
                Id = i.Service.Id
            },
            Status= i.Status,
            UserDetails = new RequestChildUserDetailsDTO 
            {
                UserName = i.User.UserName,
                UserID = i.UserId,
                UserPhone = i.User.PhoneNumber
            }
        }
        ).ToList();
        if (request == null) return null;

        return request;
    }

    public List<RequestDetailsDTO> GetAll()
    {
        List<RequestDetailsDTO> request = _repo.RequestRepo.GetAllWithDetails().Select(i =>
        new RequestDetailsDTO
        {
            Id = i.Id,
            RequestText = i.RequestText,
            date = i.date,
            ProviderDetails = new RequestChildProviderDetailsDTO
            {
                ProviderName = i.Provider.UserName,
                ProviderID = i.ProviderId
            },
            ServiceDetails = new RequestChildServiceDetailsDTO
            {
                Name = i.Service.Name,
                Id = i.Service.Id
            },
            Status = i.Status,
            UserDetails = new RequestChildUserDetailsDTO
            {
                UserName = i.User.UserName,
                UserID = i.UserId,
                UserPhone = i.User.PhoneNumber
            }
        }
        ).ToList();
        return request;
    }
    public List<RequestDetailsDTO> GetbyProviderId(string ProviderId)
    {
        List <RequestDetailsDTO> request = _repo.RequestRepo.GetbyProviderId(ProviderId).Select(i => 
        new RequestDetailsDTO
        {
            Id = i.Id,
            RequestText = i.RequestText,
            date = i.date,
            ProviderDetails = new RequestChildProviderDetailsDTO
            {
                ProviderName = i.Provider.UserName,
                ProviderID = i.ProviderId
            },
            ServiceDetails = new RequestChildServiceDetailsDTO
            {
                Name = i.Service.Name,
                Id = i.Service.Id
            },
            Status = i.Status,
            UserDetails = new RequestChildUserDetailsDTO
            {
                UserName = i.User.UserName,
                UserID = i.UserId,
                UserPhone = i.User.PhoneNumber
            }
        }
        ).ToList();
        if (request == null) return null;
       
        return request;

    }

    public List<RequestDetailsDTO> GetbyUserId(string UserId)
    {
        List<RequestDetailsDTO> request = _repo.RequestRepo.GetbyUserId(UserId).Select(i =>
        new RequestDetailsDTO
        {
            Id = i.Id,
            RequestText = i.RequestText,
            date = i.date,
            ProviderDetails = new RequestChildProviderDetailsDTO
            {
                ProviderName = i.Provider.UserName,
                ProviderID = i.ProviderId
            },
            ServiceDetails = new RequestChildServiceDetailsDTO
            {
                Name = i.Service.Name,
                Id = i.Service.Id
            },
            Status = i.Status,
            UserDetails = new RequestChildUserDetailsDTO
            {
                UserName = i.User.UserName,
                UserID = i.UserId,
                UserPhone = i.User.PhoneNumber
            }
        }
        ).ToList();
        if (request == null) return null;

        return request;
    }

    public bool Update(RequestUpdateDTO RequestFromRequest)
    {
        ServiceRequest? request = _repo.RequestRepo.GetbyId(RequestFromRequest.Id);
        if (request == null) return false;
        request.RequestText = RequestFromRequest.RequestText;
        request.Id= RequestFromRequest.Id;
        request.Status= RequestFromRequest.Status;
        _repo.RequestRepo.Update(request);
        _repo.SaveChanges();
        return true;
    }

    

  
    
}
