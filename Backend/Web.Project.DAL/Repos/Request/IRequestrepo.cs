using FinalProject.Dal;
public interface IRequestrepo:IGenericRepo<ServiceRequest>
    {
        void Add(ServiceRequest request);

        ServiceRequest GetbyId(int UserId);
        List<ServiceRequest> GetbyUserId(string UserId);

        List<ServiceRequest> GetbyProviderId(string ProviderId);

        void Remove(ServiceRequest request);

        int SaveChanges();

        void Update(ServiceRequest request);

        List<ServiceRequest> GetRequestDetails(int RequestId);
        List<ServiceRequest>? GetAllWithDetails();
    }

