namespace FinalProject.Dal;
    public class UserDetailsDTO
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public List<UserChildBookmarkDTO> Bookmarks { get; set; }
        public List<UserChildNotificationDTO> Notifications { get; set; }
        public List<UserChildRatingDTO> Ratings { get; set; }
        public List<UserChildRequestDTO> UserRequests { get; set; }
        public List<ProviderChildRequestDTO> ProviderRequests { get; set; }
        public List<UserChildServicesDTO> Services { get; set; }
    }

