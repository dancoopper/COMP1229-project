namespace Project.classes;

public class Booking
{
    private int customerID;
    private string date;
    private string flightNumber;
    private int bookingID = 0;
    
    public Booking(int customerID, string flightNumber)
    {
        this.customerID = customerID;
        this.date = DateTime.Now.ToString(@"MM/dd/yyyy h:mm tt");;
        this.flightNumber = flightNumber;
        bookingID = bookingID++;
    }

    public string toString()
    {
        return $"Date: {this.date}\nFlight: {this.flightNumber}\nCustomer ID: {this.customerID}\nBooking ID: {bookingID}";
    }
}