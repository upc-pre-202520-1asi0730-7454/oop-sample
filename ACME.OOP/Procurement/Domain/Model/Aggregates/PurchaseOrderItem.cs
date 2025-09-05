using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
/// Represents an item within a purchase order, including product id, quantity, and unit price.
/// </summary>
/// <param name="productId">The <see cref="ProductId"/> of the product being ordered. Cannot be null.</param>
/// <param name="quantity">The quantity of the product being ordered. Must be greater than zero.</param>
/// <param name="unitPrice">The <see cref="Money"/> representing the unit price of the product. Cannot be null.</param>
///
/// <exception cref="ArgumentNullException">Thrown when <paramref name="productId"/> or <paramref name="unitPrice"/> is null.</exception>
/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="quantity"/> is less than or equal to zero.</exception>
///
public class PurchaseOrderItem(ProductId productId, int quantity, Money unitPrice)
{
    public ProductId ProductId { get; } = productId ?? throw new ArgumentNullException(nameof(productId), "Product ID cannot be null.");
    public int Quantity { get; } = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
    public Money UnitPrice { get; } = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice), "Unit price cannot be null.");
    
    /// <summary>
    /// Calculates the total price for this purchase order item by multiplying the unit price by the quantity.
    /// </summary>
    /// <returns>A <see cref="Money"/> object representing the total price for this item.</returns>
    public Money CalculateItemTotal() => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);
}