using Project.classes;

namespace Project.managers;

public class BookingManager
{
    private Booking[] bookings;
    private int maxBookings;
    private int numOfBookings;
    private static int seed;

    public BookingManager(int maxBookings, int seed)
    {
        numOfBookings = 0;
        BookingManager.seed = seed;
        this.maxBookings = maxBookings;
        this.bookings = new Booking[maxBookings];
    }

    public void MakeBooking(int bookingID, int customerID, int flightNumber, string date)
    {
        bookings[numOfBookings++] = new Booking(bookingID, customerID, flightNumber, date);
    }

    public void MakeBooking(int customerID, int flightNumber)
    {
        if(numOfBookings < maxBookings)
        {
            bookings[numOfBookings++] = new Booking(seed, customerID, flightNumber);
            seed++;
        }
    }

    public void UpdateBooking(int customerID, int flightNumber)
    {
        for (int i = 0; i < numOfBookings; i++)
        {
            if (bookings[i].GetCustomerID() == customerID && bookings[i].GetFlightNumber() == flightNumber)
            {
                bookings[i] = new Booking(bookings[i].GetBookingID(), customerID, flightNumber);
            }
        }
    }

    public void DeleteBooking(int customerID, int flightNumber)
    {
        for (int i = 0; i < numOfBookings; i++)
        {
            if (bookings[i].GetCustomerID() == customerID && bookings[i].GetFlightNumber() == flightNumber)
            {
                bookings[i] = bookings[numOfBookings - 1];
                numOfBookings--;
            }
        }
    }

    public int GetNumberOfBookings()
    {
        return numOfBookings;
    }

    public static int GetSeed()
    {
        return seed;
    }

    public Booking[] GetBookings()
    {
        return bookings;
    }

    public string FindBookings(int flightNumber, CustomerManager customerManager)
    {
        string output = "";
        for (int i = 0; i < numOfBookings; i++)
        {
            if (bookings[i].GetFlightNumber() == flightNumber)
            {
                output += customerManager.GetCustomerInfo(bookings[i].GetCustomerID());
            }
        }
        return output;
    }


    public string PrintBookings()
    {
        string output = "";
        output += "------------Booking--------------\n";
        for (int i = 0; i < numOfBookings; i++)
        {
            output += bookings[i].toString();
            output += "--------------------------\n";
        }

        return output;
    }
}
