using Microsoft.AspNetCore.Identity;

using FinalProject.Dal;
    public interface IUserRepo : IGenericRepo<User>
    {
        UserManager<User> UserManager { get; set; }
        List<User> GetAllAdmins();
        List<User> GetAllUsers();
        User GetUserById(string id);
        User GeUserDetailsbyId(string id);
    }
