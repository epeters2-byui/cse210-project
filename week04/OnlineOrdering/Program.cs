using System;
using System.Collections.Generic;

// Creates orders, adds products, and displays packing/shipping labels and totals.
// No user interaction required per assignment instructions.
class Program
{
    static void Main(string[] args)
    {
        // Order 1: customer in USA
        Address addr1 = new Address("123 Market St", "Monrovia", "MN", "USA");
        Customer cust1 = new Customer("Emmanuel Johnson", addr1);

        Order order1 = new Order(cust1);
        Product p1 = new Product("Wireless Mouse", "WM-100", 15.99m, 2);
        Product p2 = new Product("USB-C Cable", "UC-50", 7.50m, 3);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        // Order 2: customer outside USA
        Address addr2 = new Address("45 King Street", "London", "Greater London", "United Kingdom");
        Customer cust2 = new Customer("Aisha Conteh", addr2);

        Order order2 = new Order(cust2);
        Product p3 = new Product("Travel Adapter", "TA-77", 12.00m, 1);
        Product p4 = new Product("Noise-Canceling Headphones", "NH-900", 59.99m, 1);
        order2.AddProduct(p3);
        order2.AddProduct(p4);

        // Put orders in a list and display for each
        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        int orderNum = 1;
        foreach (Order o in orders)
        {
            Console.WriteLine("=== Order #" + orderNum + " ===");
            Console.WriteLine(o.GetPackingLabel());
            Console.WriteLine(o.GetShippingLabel());
            Console.WriteLine("Total Price: " + o.GetTotalPriceFormatted());
            Console.WriteLine(); // blank line
            orderNum++;
        }
    }
}
