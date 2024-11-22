using Project.classes;
using Project.managers;

namespace Project;

public class Coordinator
{
    private static FileUtil fileUtil = new FileUtil();
    CustomerManager customerManager = fileUtil.ReadCustomerFile();
    FlightManager flightManager = new FlightManager(1000);
    BookingManager bookingManager = new BookingManager();
    
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


    public void MakeBooking(int customerId, int flightId)
    {
        bookingManager.MakeBooking(customerId, flightId);
        fileUtil.WriteBookToFile(bookingManager);
    }

    public string ShowBookings()
    {
        return bookingManager.PrintBookings();
    }
    
    public void AddFlights(int flightNum, string origin, string destination, int numberOfSeats)
    {
        flightManager.AddFlight(flightNum, origin, destination, numberOfSeats);
        fileUtil.WriteFlightToFile(flightManager);
    }

    public void DeleteFlights(int flightId)
    {
        flightManager.DeleteFlight(flightId);
        fileUtil.WriteFlightToFile(flightManager);

    }
    
    public string PrintFlights()
    {
        return flightManager.PrintFlights();
    }

    public string PrintOneFlight(int flightId)
    {
        return flightManager.PrintOneFlight(flightId, bookingManager.FindBookings(flightId, customerManager));
    }
}

