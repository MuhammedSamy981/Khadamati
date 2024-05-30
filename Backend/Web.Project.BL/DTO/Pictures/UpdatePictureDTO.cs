namespace FinalProject.Dal;
    public class UpdatePictureDTO
    {       
        public int Id { get; set; }
        public string Url { get; set; } =string.Empty;
        public int ServiceId { get; set; }
    }
