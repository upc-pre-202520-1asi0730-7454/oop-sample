using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
/// Represents a Purchase Order Aggregate Root in the Procurement Bounded Context.
/// It encapsulates the details of a purchase order, including its items and total amount.
/// </summary>
/// <param name="orderNumber">The unique identifier for the purchase order.</param>
/// <param name="supplierId">The <see cref="SupplierId"/> identifying the supplier.</param>
/// <param name="orderDate">The date the order was placed.</param>
/// <param name="currency">The currency code (ISO 4217) for the order.</param>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, 
    DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = new();
    
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } = 
        string.IsNullOrWhiteSpace(currency) || currency.Length!= 3 
        ? throw new ArgumentNullException(nameof(currency))
        : currency;
    
    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Adds an item to the purchase order.
    /// </summary>
    /// <param name="productId">The <see cref="ProductId"/> of the product being ordered.</param>
    /// <param name="quantity">The quantity of the product being ordered. Must be greater than zero.</param>
    /// <param name="unitPriceAmount">The unit price amount of the product. Must be non-negative.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="productId"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="quantity"/> is less than or equal to zero or if <paramref name="unitPriceAmount"/> is negative.</exception>
    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount < 0) throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit price amount cannot be negative.");
        
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
    }

    /// <summary>
    /// Calculates the total amount of the purchase order by summing the total of each item.
    /// </summary>
    /// <returns>A <see cref="Money"/> object representing the total amount of the purchase order in the specified currency.</returns>
    public Money CalculateOrderTotal()
    {
        var totalAmount = _items.Sum(item => item.CalculateItemTotal().Amount);
        return new Money(totalAmount, Currency);
    }
}