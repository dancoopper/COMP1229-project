﻿using Project.classes;
using Project.managers;

namespace Project;

public class Coordinator
{
    CustomerManager customerManager = new CustomerManager();
    FlightManager flightManager = new FlightManager();

    public void AddCustomers(string firstName, string lastName, string phone)
    {
        customerManager.AddCustomers(firstName, lastName, phone);
    }
    public void ShowCustomers()
    {
        customerManager.ShowCustomers();
    }

    public string ShowCustomersAsString()
    {
        return customerManager.ShowCustomersAsString();
    }
}

