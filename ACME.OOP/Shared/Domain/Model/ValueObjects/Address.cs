namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a physical address Value Object.
/// </summary>
public record Address
{
    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    public string? StateOrRegion { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }
    
    /// <summary>
    ///  Initializes a new instance of the <see cref="Address"/> Value Object.
    /// </summary>
    /// <param name="street">the street name</param>
    /// <param name="number">the street number</param>
    /// <param name="city">the city name</param>
    /// <param name="stateOrRegion">the state or region name (optional)</param>
    /// <param name="postalCode">the postal code</param>
    /// <param name="country">the country name</param>
    /// <exception cref="ArgumentException">Thrown when any required parameter is null or empty.</exception>
    public Address(string street, string number, string city, string? stateOrRegion, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or empty.", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Number cannot be null or empty.", nameof(number));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be null or empty.", nameof(city));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code cannot be null or empty.", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or empty.", nameof(country));
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }
    
    /// <summary>
    ///  Returns a string representation of the address.
    /// </summary>
    /// <returns>A formatted string representing the address containing street, number, city, state/region (if provided), postal code, and country.</returns>
    public override string ToString() => $"{Street} {Number}, {City}, {(string.IsNullOrWhiteSpace(StateOrRegion) ? "" : StateOrRegion + ", ")}{PostalCode}, {Country}";
}