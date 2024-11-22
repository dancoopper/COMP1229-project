namespace Project.classes;

public class Flight
{
    protected int flightNum; // this is an integer
    private string origin;
    private string destination;
    private int maxSeats;
    private int passengerNum;

    public Flight(int flightNum, string origin, string destination, int maxSeats)
    {
        this.flightNum = flightNum;
        this.origin = origin;
        this.destination = destination;
        this.maxSeats = maxSeats;
    }

    public int GetFlightNum()
    {
        return this.flightNum;
    }

    public string toString()
    {
        return $"Flight number: {flightNum}\nOrigin: {origin}\nDestination: {destination}\nNumber of Seats: {maxSeats}\n";
    }
}