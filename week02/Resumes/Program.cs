using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1. _jobTitle = "Computer Engineer";
        job1._company = "LTA";
        job1._startYear = 2020;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Telecom";
        job2._startYear = 2021;
        job2._endYear = 2023;

        Job job3 = new Job();
        job3._jobTitle = "IT Lecturer";
        job3. _company = " United Methodist University";
        job3._startYear = 2023;
        job3._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Emmanuel M. Peters";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();

    }
}

public class Address
{
    private string _country;

    public string Country
    {
        get { return _country; }
        set { _country = value ?? ""; }
    }

    public bool IsInUSA()
    {
        if (string.IsNullOrWhiteSpace(Country)) return false;
        return Country.Trim().ToUpper() == "USA" || 
               Country.Trim().ToUpper() == "UNITED STATES" || 
               Country.Trim().ToUpper() == "UNITED STATES OF AMERICA";
    }
}