namespace UserManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }         // Unique user ID
        public string Name { get; set; }     // User's full name
        public string Email { get; set; }    // Email address
        public string Role { get; set; }     // Role (Admin, User, etc.)
    }
}

