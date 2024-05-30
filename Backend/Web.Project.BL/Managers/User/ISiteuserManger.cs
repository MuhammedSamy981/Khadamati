using FinalProject.Dal;
    public interface IUserManger
    {
        IUnitofWork Unitofwork { get; }

        List<UserReadDto> GetAll();
        UserReadDto GetUser(string id);
        User RegisterUser(UserAddDTO userAdd);
        void UpateUserData(string id, UserUpdateDto siteUser);
        public void RemoveUser(string id);
        List<UserReadDto> GetAllUsers();
        List<UserReadDto> GetAllAdmins();
        public UserDetailsDTO GetUserDetails(string id);
        void AddBookmark(string UserID, int serviceID);
        void RemoveBookmark(string id, int serviceID);
    }
