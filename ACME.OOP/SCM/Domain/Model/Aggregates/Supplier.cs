using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.SCM.Domain.Model.Aggregates;

/// <summary>
/// Represents a supplier aggregate in the supply chain management bounded context.
/// </summary>
/// <param name="identifier">The unique identifier for the supplier.</param>
/// <param name="name">The name of the supplier.</param>
/// <param name="address">The <see cref="Address"/> of the supplier.</param>
public class Supplier(string identifier, string name, Address address)
{
    public string Identifier { get; } = identifier ?? throw new ArgumentNullException(nameof(identifier));
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public Address Address { get; } = address ?? throw new ArgumentNullException(nameof(address));
}