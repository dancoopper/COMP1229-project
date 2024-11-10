using Project.classes;

namespace Project.managers;

public class FlightManager
{
    private Flight[] flights = new Flight[5];
    private int numOfFlights = 0;

    public void RegisterFlight(Flight flight)
    {
        flights[numOfFlights] = flight;
        numOfFlights++;
    }

    public void RegisterFlight(int flightNumber, string origin, string destination, int maximumSeats, int numberOfSeats)
    {
        flights[numOfFlights] = new Flight(flightNumber, origin, destination, maximumSeats, numberOfSeats);
        numOfFlights++;
    }

    public void PrintFlights()
    {
        Console.WriteLine("--------------Flight------------");
        for (int i = 0; i < numOfFlights; i++)
        {
            Console.WriteLine(flights[i].toString());
            Console.WriteLine("--------------------------");
        }
    }
}