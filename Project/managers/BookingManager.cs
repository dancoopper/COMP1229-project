using Project.classes;

namespace Project.managers;

public class BookingManager
{
    private Booking[] booking = new Booking[5];
    private int numOfBookings = 0;

    public void MakeBooking(int customerID, string flightNumber)
    {
        booking[numOfBookings] = new Booking(customerID, flightNumber);
        numOfBookings++;
    }

    public void PrintBookings()
    {
        Console.WriteLine("------------Booking--------------");
        for (int i = 0; i < numOfBookings; i++)
        {
            Console.WriteLine(booking[i].toString());
            Console.WriteLine("--------------------------");
        }
    }
}