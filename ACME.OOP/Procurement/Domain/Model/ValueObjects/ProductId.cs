namespace ACME.OOP.Procurement.Domain.Model.ValueObjects;

public record ProductId
{
    public Guid Id { get; init; }
    
    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("ProductId cannot be empty.", nameof(id));

        Id = id;
    }
    
    public static ProductId New() => new (Guid.NewGuid());
}