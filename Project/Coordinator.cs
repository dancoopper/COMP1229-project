using System.Globalization;
using Project.classes;
using Project.managers;

namespace Project;

public class Coordinator
{
    private static FileUtil fileUtil = new FileUtil();
    CustomerManager customerManager = fileUtil.LoadCustomerFile();
    FlightManager flightManager = fileUtil.LoadFlightFile();
    BookingManager bookingManager = fileUtil.LoadBookingFile();

    public void EndProcess()
    {
        fileUtil.SaveState(customerManager, flightManager, bookingManager);
    }
    public void AddCustomers(string firstName, string lastName, string phone)
    {
        customerManager.AddCustomers(firstName, lastName, phone);
        fileUtil.SaveCustomerFile(customerManager);
    }

    public void DeleteCustomers(int customerId)
    {
        customerManager.DeleteCustomer(customerId);
        fileUtil.SaveCustomerFile(customerManager);

    }

    public string ShowCustomers()
    {
        return customerManager.ShowCustomers();
    }


    public void MakeBooking(int customerId, int flightId)
    {
        bookingManager.MakeBooking(customerId, flightId);
        fileUtil.SaveBookingFile(bookingManager);
    }

    public string ShowBookings()
    {
        return bookingManager.PrintBookings();
    }

    public void AddFlights(int flightNum, string origin, string destination, int numberOfSeats)
    {
        flightManager.AddFlight(flightNum, origin, destination, numberOfSeats);
        fileUtil.SaveFlightFile(flightManager);
    }

    public void DeleteFlights(int flightId)
    {
        flightManager.DeleteFlight(flightId);
        fileUtil.SaveFlightFile(flightManager);

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