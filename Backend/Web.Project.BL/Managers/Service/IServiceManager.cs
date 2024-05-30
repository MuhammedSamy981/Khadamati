using FinalProject.Dal;

public interface IServiceManager
{
    List<GetAllServicesDTO> GetAll();
    List<GetAllServicesDetailsDTO> GetAllDetails();
    GetServiceByIdDTO? GetById(int id);
    void Add(AddServiceDTO service);
    bool Update(UpdateServiceDTO service);
    void DeleteById(int id);
    GetServiceDetailsByIdDTO? GetDetailsById(int id);
        bool approve(int id);

    List<GetSpecificServicesDetailsDTO> GetSpecificDetails(string loction , string categoryName);
}