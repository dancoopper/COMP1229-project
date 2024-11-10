namespace Project.classes;

public class Flight
{
    protected int flightNumber;//idk if the use sets this
    private string origin;
    private string destination;
    private int maximumSeats;
    private int numberOfSeats;

    public Flight(int flightNumber, string origin, string destination, int maximumSeats, int numberOfSeats)
    {
        this.flightNumber = flightNumber;
        this.origin = origin;
        this.destination = destination;
        this.maximumSeats = maximumSeats;
        this.numberOfSeats = numberOfSeats;
    }

    public string toString()
    {
        return $"Flight number: {flightNumber}\nOrigin: {origin}\nDestination: {destination}\nMaximum Seats: {maximumSeats}\nNumber of Seats: {numberOfSeats}";
    }
}