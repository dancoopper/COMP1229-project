namespace Project.classes;

public class Booking
{
    private int customerID;
    private DateTime date;
    private string flightNumber;
    private int bookingID = 0;
    
    public Booking(int customerID, DateTime date, string flightNumber)
    {
        this.customerID = customerID;
        this.date = date;
        this.flightNumber = flightNumber;
        bookingID = bookingID++;
    }

    public string toString()
    {
        return $"Date: {this.date}\nFlight: {this.flightNumber}\nCustomer ID: {this.customerID}\nBooking ID: {bookingID}";
    }
}