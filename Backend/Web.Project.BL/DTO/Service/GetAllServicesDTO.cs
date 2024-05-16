
namespace FinalProject.Dal;

    public class GetAllServicesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; }=string.Empty;
        public int Price { get; set; }
        public bool Approved { get; set; }
        public DateTime date { get; set; }
        public string ProviderId { get; set; }

    }
