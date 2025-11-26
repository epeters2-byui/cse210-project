using System;
using System.Collections.Generic;

// Creates orders adds products
// Displays packing/shipping labels and totals.
// There is no user interaction required per assignment instructions.
class Program
{
    static void Main(string[] args)
    {
        // Order 1: customer in USA
        Address addr1 = new Address("Main Street", "Salt Lake City", "Utah", "USA");
        Customer cust1 = new Customer("Mark Henry", addr1);

        Order order1 = new Order(cust1);
        Product p1 = new Product("Wireless Mouse", "WM-100", 20.99m, 2);
        Product p2 = new Product("USB-C Cable", "UC-50", 13.50m, 3);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        // Order 2: customer outside USA
        Address addr2 = new Address("24 Kofa Street", "Accra", "Greater Accra", "Ghana");
        Customer cust2 = new Customer("Ya Praku", addr2);

        Order order2 = new Order(cust2);
        Product p3 = new Product("Travel Adapter", "TA-77", 20.00m, 1);
        Product p4 = new Product("Noise-Canceling Headphones", "NH-900", 75.90m, 1);
        order2.AddProduct(p3);
        order2.AddProduct(p4);

        // order 3: Customer outside USA
        Address addr3 = new Address(" 81 UN Drive", " Monrovia", " Upper Monrovia" ,"Liberia");
        Customer cust3 = new Customer("Emmanuel Peters",addr3);

        Order order3 = new Order(cust3);
        Product p5 = new Product("Basket Bag", "B-201", 15.00m, 2);
        Product p6 = new Product("Woody Chair", "WC-2021", 20.15m,3);
        order3.AddProduct(p5);
        order3.AddProduct(p6);

        // Put orders in a list and display for each
        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);

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
