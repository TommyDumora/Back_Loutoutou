namespace Loutoutou.Models;

public partial class Users
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public virtual ICollection<UserGetAnimal> UserGetAnimal { get; set; } = new List<UserGetAnimal>();
}