namespace CarRental.Domain.Entities.Accounts;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public ICollection<UserRole?> UserRoles { get; set; } = new HashSet<UserRole?>();
    public UserDetail? UserDetail { get; set; }
}
