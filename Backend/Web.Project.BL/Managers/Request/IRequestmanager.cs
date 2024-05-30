using FinalProject.Dal;

public interface IRequestmanager
{
    int Add(RequestAddDTO request);

    bool Update(RequestUpdateDTO request);
    
    bool Delete(int id);

    List<RequestDetailsDTO> GetbyUserId(string UserId);

    List<RequestDetailsDTO> GetbyIdDetails(int DetailsId);

    List<RequestDetailsDTO> GetbyProviderId(string ProviderId);
    List<RequestDetailsDTO> GetAll();
}
