using System;

public class Driver
{
    string firstName;
    string lastName;
    int driverId;
    TaxiScript taxi;

    public Driver(string first, string last, int id)
    {
        firstName = first;
        lastName = last;
        driverId = id; 

    }

    internal void assignTaxi(TaxiScript taxiScript)
    {
        taxi = taxiScript;
    }
}