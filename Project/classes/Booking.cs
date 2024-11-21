namespace Project.classes;

public class Booking
{
    private int customerID;
    private string date;
    private int flightNumber;
    private static int bookingID = 0;
    
    public Booking(int customerID, int flightNumber)
    {
        this.customerID = customerID;
        this.date = DateTime.Now.ToString(@"MM/dd/yyyy h:mm tt");;
        this.flightNumber = flightNumber;
        bookingID = bookingID++;
    }

    public int GetCustomerID()
    {
        return this.customerID;
    }

    public int GetFlightNumber()
    {
        return this.flightNumber;
    }

    public int GetBookingID()
    {
        return bookingID;
    }
    
    public string toString()
    {
        return $"Date: {this.date}\nFlight: {this.flightNumber}\nCustomer ID: {this.customerID}\nBooking ID: {bookingID}\n";
    }
}