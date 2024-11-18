namespace Project.classes;

public class Flight
{
    protected string flightID;//idk if the user sets this
    private string origin;
    private string destination;
    private int numberOfSeats;
    private string status;
    
    private static int numOfFlights = 1;
    private int seed = 2;

    public Flight(string origin, string destination, int numberOfSeats)
    {
        this.flightID = "AB"+(numOfFlights+seed);
        numOfFlights++;
        this.origin = origin;
        this.destination = destination;
        this.numberOfSeats = numberOfSeats;
        this.status = "On Time";
    }

    public void UpdateFlight(string origin, string destination, int numberOfSeats)
    {
        this.origin = origin;
        this.destination = destination;
        this.numberOfSeats = numberOfSeats;
    }

    public string GetStatus()
    {
        return this.status;
    }

    public string GetFlightID()
    {
        return this.flightID;
    }

    public string toString()
    {
        return $"Flight number: {flightID}\nOrigin: {origin}\nDestination: {destination}\nNumber of Seats: {numberOfSeats}\nStatus: {status}\n";
    }
}