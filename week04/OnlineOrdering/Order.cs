using System;
using System.Collections.Generic;
using System.Globalization;

// Represents an order containing products and a customer.
// Encapsulates internal product list
//Provides methods for packing label, shipping label, and total price.
public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    // Constructor for customer
    public Order(Customer customer)
    {
        Customer = customer;
        _products = new List<Product>();
    }

    // Set s default constructor
    public Order()
    {
        Customer = new Customer();
        _products = new List<Product>();
    }

    // Represents customer property
    public Customer Customer
    {
        get { return _customer; }
        set
        {
            if (value == null) _customer = new Customer();
            else _customer = value;
        }
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        if (product == null) return;
        _products.Add(product);
    }

    // A copy of all products are returned. 
    // Protects internal list
    public List<Product> GetAllProducts()
    {
        return new List<Product>(_products);
    }

    // Compute total price, which is sum of product totals + one-time shipping cost
    public decimal GetTotalPrice()
    {
        decimal sum = 0m;
        foreach (Product p in _products)
        {
            sum += p.GetTotalCost();
        }

        decimal shipping = (Customer != null && Customer.LivesInUSA()) ? 5m : 35m;
        return sum + shipping;
    }

    // Packing label with list product names and IDs
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += p.Name + " (Product ID: " + p.ProductId + ")" + "\n";
        }
        return label;
    }

    // Build shipping label with customer name
    // Full address on separate lines
    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += Customer.Name + "\n";
        if (Customer.Address != null)
        {
            label += Customer.Address.ToFormattedString();
        }
        return label;
    }

    // Format price in current culture currency
    public string GetTotalPriceFormatted()
    {
        decimal total = GetTotalPrice();
        return total.ToString("C", CultureInfo.CurrentCulture);
    }
}
