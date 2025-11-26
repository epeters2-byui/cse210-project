using System;

// Shows customer with name and Address by encapsulating fields.
public class Customer
{
    private string _name;
    private Address _address;

    // Names the property
    public string Name
    {
        get { return _name; }
        set { _name = value ?? ""; }
    }

    // For address property, with address is its own class.
    public Address Address
    {
        get { return _address; }
        set
        {
            if (value == null) _address = new Address();
            else _address = value;
        }
    }

    // Constructor for name and address
    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // Set as default constructor
    public Customer()
    {
        Name = "";
        Address = new Address();
    }

    // This will returns true if the customer's address is in the USA 
    // Delegates to Address
    public bool LivesInUSA()
    {
        if (Address == null) return false;
        return Address.IsInUSA();
    }
}
