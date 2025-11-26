using System;

// Representin product in order.
// It encapsulates fields.
// provides method to compute total amount of cost for the product.
public class Product
{
    private string _name;
    private string _productId;
    private decimal _pricePerUnit;
    private int _quantity;

    // Represent validation of properties
    public string Name
    {
        get { return _name; }
        set { _name = value ?? ""; }
    }

    public string ProductId
    {
        get { return _productId; }
        set { _productId = value ?? ""; }
    }

    public decimal PricePerUnit
    {
        get { return _pricePerUnit; }
        set
        {
            if (value < 0) _pricePerUnit = 0;
            else _pricePerUnit = value;
        }
    }

    public int Quantity
    {
        get { return _quantity; }
        set
        {
            if (value < 0) _quantity = 0;
            else _quantity = value;
        }
    }

    // Constructor for name, productId, pricePerUnit and quantity (int)
    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    // Represents default constructor
    public Product()
    {
        Name = "";
        ProductId = "";
        PricePerUnit = 0m;
        Quantity = 0;
    }

    // Compute total cost for this product (price * quantity)
    public decimal GetTotalCost()
    {
        return PricePerUnit * Quantity;
    }
}
