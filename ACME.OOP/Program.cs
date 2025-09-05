using ACME.OOP.Procurement.Domain.Model.Aggregates;
using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.Aggregates;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

var supplierAddress = new Address(street: "Main St", number: "1213", city: "Anytown", stateOrRegion: "CA",
    postalCode: "12345", country: "USA");
    
var supplier = new Supplier("SUP001", "Acme Supplies", supplierAddress);

var purchaseOrder = new PurchaseOrder("PO12345", new SupplierId(supplier.Identifier),
    DateTime.Now, "USD");
purchaseOrder.AddItem(ProductId.New(), 10, 15.00m);
purchaseOrder.AddItem(ProductId.New(), 5, 25.00m);
Console.WriteLine($"order total: {purchaseOrder.CalculateOrderTotal()}");