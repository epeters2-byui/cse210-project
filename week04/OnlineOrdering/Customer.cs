using System;

// Represents a customer with a name and an Address. Encapsulates its fields.
public class Customer
{
    private string _name;
    private Address _address;

    // Name property
    public string Name
    {
        get { return _name; }
        set { _name = value ?? ""; }
    }

    // Address property (Address is its own class)
    public Address Address
    {
        get { return _address; }
        set
        {
            if (value == null) _address = new Address();
            else _address = value;
        }
    }

    // Constructor
    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // Default constructor
    public Customer()
    {
        Name = "";
        Address = new Address();
    }

    // Returns true if the customer's address is in the USA (delegates to Address)
    public bool LivesInUSA()
    {
        if (Address == null) return false;
        return Address.IsInUSA();
    }
}
