using Project.classes;
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

    public void DeleteCustomers(int customerId)
    {
        customerManager.DeleteCustomer(customerId);
    }
    
    public void ShowCustomers()
    {
        customerManager.ShowCustomers();
    }

    public string ShowCustomersAsString()
    {
        return customerManager.ShowCustomersAsString();
    }

    public void AddFlights(int flightNumber, string origin, string destination, int maximumSeats, int numberOfSeats)
    {
        flightManager.RegisterFlight(flightNumber, origin, destination, maximumSeats, numberOfSeats);
    }
    
    public void PrintFlights()
    {
        flightManager.PrintFlights();
    }
}

