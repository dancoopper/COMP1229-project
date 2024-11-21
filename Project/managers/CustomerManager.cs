﻿using Project.classes;

namespace Project.managers;

public class CustomerManager
{
    private Customer[] customers;
    private int numOfCustomer;
    private int maxCustomers;
    private static int seed;
    public CustomerManager(int maxCustomers, int seed)
    {
        numOfCustomer = 0;
        this.maxCustomers = maxCustomers;
        CustomerManager.seed = seed;
        customers = new Customer[maxCustomers];
    }

    // do not add a customer if one already exists with the same first name, last name and phone number
    // implement this logic in the menu
    // if a customer is added return true and display a success message on the menu
    // otherwise return false and dipsplay error message on menu
    public void AddCustomers(string firstName, string lastName, string phone)
    {
        if (numOfCustomer < maxCustomers)
        {
            customers[numOfCustomer++] = new Customer(seed, firstName, lastName, phone);
            seed++;
        }
    }

    public void DeleteCustomer(int customerID)
    {
        for (int i = 0; i < numOfCustomer; i++)
        {
            if (customerID == customers[i].GetID())
            {
                customers[i] = customers[numOfCustomer - 1];
                numOfCustomer--;
            }
        }
    }

    public string GetCustomerInfo(int customerID)
    {
        for (int i = 0; i < numOfCustomer; i++)
        {
            if (customerID == customers[i].GetID())
            {
                return customers[i].toString();
            }
        }

        return "could not get customer info"; // customer with ID ____ cannot be found 
    }
    
    public string TextInput()
    {
        string sCustomers = "";
        for (int i = 0; i < numOfCustomer; i++)
        {
            sCustomers += customers[i].TextInput();
        }

        return sCustomers;
    }

    public string ShowCustomers()
    {
        string sCustomers = "";
        sCustomers += "------------Customer--------------\n";

        if (numOfCustomer <= 0)
        {
            sCustomers += "No Customers Found";
        }

        for (int i = 0; i < numOfCustomer; i++)
        {
            sCustomers += customers[i].toString();
            sCustomers += "--------------------------\n";
        }

        return sCustomers;
    }
}