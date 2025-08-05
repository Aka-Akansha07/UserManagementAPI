using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public List<User> GetAll() => _users;

        public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public User Create(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
            return user;
        }

        public User? Update(int id, User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == id);
            if (existing == null) return null;

            existing.Name = user.Name;
            existing.Email = user.Email;
            return existing;
        }

        public bool Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }
    }
}
