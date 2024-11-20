using Project.classes;
using Project.managers;

namespace Project;

public class Coordinator
{
    CustomerManager customerManager = new CustomerManager();
    FlightManager flightManager = new FlightManager();
    BookingManager bookingManager = new BookingManager();
    FileUtil fileUtil = new FileUtil();
    
    public void EndProcess()
    {
        fileUtil.SaveState(customerManager, flightManager, bookingManager);
    }
    public void AddCustomers(string firstName, string lastName, string phone)
    {
        customerManager.AddCustomers(firstName, lastName, phone);
        fileUtil.WriteCustomerToFile(customerManager);
    }

    public void DeleteCustomers(int customerId)
    {
        customerManager.DeleteCustomer(customerId);
        fileUtil.WriteCustomerToFile(customerManager);

    }

    public string ShowCustomers()
    {
        return customerManager.ShowCustomers();
    }


    public void MakeBooking(int customerId, string flightId)
    {
        bookingManager.MakeBooking(customerId, flightId);
        fileUtil.WriteBookToFile(bookingManager);
    }

    public string ShowBookings()
    {
        return bookingManager.PrintBookings();
    }
    
    public void AddFlights(string origin, string destination, int numberOfSeats)
    {
        flightManager.RegisterFlight(origin, destination, numberOfSeats);
        fileUtil.WriteFlightToFile(flightManager);
    }

    public void DeleteFlights(string flightId)
    {
        flightManager.DeleteFlight(flightId);
        fileUtil.WriteFlightToFile(flightManager);

    }
    
    public string PrintFlights()
    {
        return flightManager.PrintFlights();
    }

    public string PrintOneFlight(string flightId)
    {
        return flightManager.PrintOneFlight(flightId, bookingManager.FindBookings(flightId));
    }
}

