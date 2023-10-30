namespace Loutoutou.Models;

public partial class UserGetAnimal
{
    public int Id { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime EndingDate { get; set; }

    public int AnimalId { get; set; }

    public int UserId { get; set; }

    public virtual Animals Animal { get; set; }

    public virtual Users User { get; set; }
}