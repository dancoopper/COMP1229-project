using Project.classes;

namespace Project.managers;

public class BookingManager
{
    private Booking[] booking = new Booking[5];
    private int numOfBookings = 0;

    public void MakeBooking(int customerID, DateTime date, string flightNumber)
    {
        booking[numOfBookings] = new Booking(customerID, date, flightNumber);
        numOfBookings++;
    }

    public void PrintBookings()
    {
        Console.WriteLine("------------Booking--------------");
        for (int i = 0; i < numOfBookings; i++)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(booking[i].toString());
        }
    }
}