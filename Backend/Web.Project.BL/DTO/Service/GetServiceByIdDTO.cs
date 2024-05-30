
namespace FinalProject.Dal;

    public class GetServiceByIdDTO
    {       
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public float Rating { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Approved { get; set; }
        public DateTime date { get; set; }
        public string ProviderId { get; set; }=string.Empty;
    }
