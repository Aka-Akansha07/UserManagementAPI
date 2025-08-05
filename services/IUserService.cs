using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User? GetById(int id);
        User Create(User user);
        User? Update(int id, User user);
        bool Delete(int id);
    }
}
