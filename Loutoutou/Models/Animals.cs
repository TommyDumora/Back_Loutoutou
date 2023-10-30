namespace Loutoutou.Models;

public partial class Animals
{
    public int Id { get; set; }

    public string Race { get; set; }

    public int Age { get; set; }

    public bool Sexe { get; set; }

    public string Color { get; set; }

    public string Name { get; set; }

    public int PricePerDay { get; set; }

    public virtual ICollection<UserGetAnimal> UserGetAnimal { get; set; } = new List<UserGetAnimal>();
}