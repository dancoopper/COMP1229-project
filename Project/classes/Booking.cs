namespace Project.classes;

public class Booking
{
    private int customerID;
    private string date;
    private int flightNumber;
    private int bookingID;

    public Booking(int bookingID, int customerID, int flightNumber)
    {
        this.bookingID = bookingID;
        this.customerID = customerID;
        this.date = DateTime.Now.ToString(@"MM/dd/yyyy h:mm tt"); ;
        this.flightNumber = flightNumber;
    }

    public Booking(int bookingID, int customerID, int flightNumber, string date)
    {
        this.bookingID = bookingID;
        this.customerID = customerID;
        this.flightNumber = flightNumber;
        this.date = date;
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

    public string GetDate()
    {
        return date;
    }

    public string toString()
    {
        return $"Date: {this.date}\nFlight: {this.flightNumber}\nCustomer ID: {this.customerID}\nBooking ID: {bookingID}\n";
    }
}