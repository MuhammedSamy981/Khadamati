
namespace FinalProject.Dal;

    public class GetAllServicesDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public float Rating { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public string ProviderId { get; set; }=string.Empty;
        public string ProviderName { get; set; }=string.Empty;
        public string ProviderPhone { get; set; }=string.Empty;
        public string CategoryName { get; set; }=string.Empty;
        public List<GetAllPicturesDTO>? pictures  { get; set; }
        public List<GetAllRatingsDTO>? ratings  { get; set; }
        public bool approved { get; set; }


    }
