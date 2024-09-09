namespace BookStore.DAL.Entitites;

public abstract class BaseEntity
{
    protected BaseEntity() 
    {
        Id = Guid.Empty;
    }

    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
