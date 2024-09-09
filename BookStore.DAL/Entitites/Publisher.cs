namespace BookStore.DAL.Entitites;

public class Publisher : BaseEntity
{
    public string CompanyName { get; set; }

    public ICollection<Book> Books { get; set; }
}
