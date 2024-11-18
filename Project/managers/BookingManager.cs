using Project.classes;

namespace Project.managers;

public class BookingManager
{
    private Booking[] bookings = new Booking[5];
    private int numOfBookings = 0;
    CustomerManager customerManager = new CustomerManager();

    public void MakeBooking(int customerID, string flightNumber)
    {
        bookings[numOfBookings] = new Booking(customerID, flightNumber);
        numOfBookings++;
    }

    public void UpdateBooking(int customerID, string flightNumber)
    {
        for (int i = 0; i < numOfBookings; i++)
        {
            if (bookings[i].GetCustomerID() == customerID && bookings[i].GetFlightNumber() == flightNumber)
            {
                bookings[i] = new Booking(customerID, flightNumber);
            }
        }
    }

    public void DeleteBooking(int customerID, string flightNumber)
    {
        for (int i = 0; i < numOfBookings; i++)
        {
            if (bookings[i].GetCustomerID() == customerID && bookings[i].GetFlightNumber() == flightNumber)
            {
                bookings[i] = bookings[numOfBookings-1];
                numOfBookings--;
            }
        }
    }

    public string FindBookings(string flightNumber)
    {
        string output = "";
        for (int i = 0; i < numOfBookings; i++)
        {
            if (bookings[i].GetFlightNumber().Equals(flightNumber))
            {
               output+= customerManager.GetCustomerInfo(bookings[i].GetCustomerID());
            }
        }
        return output;
    }
    
    
    
    public string PrintBookings()
    {
        string output = "";
        output+="------------Booking--------------\n";
        for (int i = 0; i < numOfBookings; i++)
        {
            output+=bookings[i].toString();
            output+="--------------------------\n";
        }

        return output;
    }
}