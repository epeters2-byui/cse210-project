using System;

// Represents a postal address. Encapsulates its fields with private members and public properties.
public class Address
{
    // Private fields (encapsulation)
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // Public properties (getters/setters) with simple validation
    public string Street
    {
        get { return _street; }
        set { _street = value ?? ""; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value ?? ""; }
    }

    public string StateOrProvince
    {
        get { return _stateOrProvince; }
        set { _stateOrProvince = value ?? ""; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value ?? ""; }
    }

    // Constructor to set all fields
    public Address(string street, string city, string stateOrProvince, string country)
    {
        Street = street;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }

    // Default parameterless constructor
    public Address()
    {
        Street = "";
        City = "";
        StateOrProvince = "";
        Country = "";
    }

    // Returns true if the country is USA (case-insensitive)
    public bool IsInUSA()
    {
        if (string.IsNullOrWhiteSpace(Country)) return false;
        return Country.Trim().ToUpper() == "USA" || Country.Trim().ToUpper() == "UNITED STATES" || Country.Trim().ToUpper() == "UNITED STATES OF AMERICA";
    }

    // Return the address as a multi-line formatted string (for shipping label)
    public string ToFormattedString()
    {
        return Street + "\n" + City + ", " + StateOrProvince + "\n" + Country;
    }
}
