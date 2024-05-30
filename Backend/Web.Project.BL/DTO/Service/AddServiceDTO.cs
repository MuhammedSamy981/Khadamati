
namespace FinalProject.Dal;

    public class AddServiceDTO
    {       

        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public string ProviderId { get; set; }=string.Empty;
    }
