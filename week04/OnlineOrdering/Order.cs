using System;
using System.Collections.Generic;
using System.Globalization;

// Represents an order containing products and a customer.
// Encapsulates internal product list and provides methods for packing label, shipping label, and total price.
public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    // Constructor with customer
    public Order(Customer customer)
    {
        Customer = customer;
        _products = new List<Product>();
    }

    // Default constructor
    public Order()
    {
        Customer = new Customer();
        _products = new List<Product>();
    }

    // Customer property
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

    // Return a copy of all products (protects internal list)
    public List<Product> GetAllProducts()
    {
        return new List<Product>(_products);
    }

    // Compute total price: sum of product totals + one-time shipping cost
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

    // Build packing label: list product names and IDs
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += p.Name + " (Product ID: " + p.ProductId + ")" + "\n";
        }
        return label;
    }

    // Build shipping label: customer name and full address on separate lines
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

    // Pretty format price in current culture currency
    public string GetTotalPriceFormatted()
    {
        decimal total = GetTotalPrice();
        return total.ToString("C", CultureInfo.CurrentCulture);
    }
}
