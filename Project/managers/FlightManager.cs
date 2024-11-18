using Project.classes;

namespace Project.managers;

public class FlightManager
{
    private Flight[] flights = new Flight[5];
    private int numOfFlights = 0;
    

    public void RegisterFlight(string origin, string destination, int numberOfSeats)
    {
        flights[numOfFlights] = new Flight(origin, destination, numberOfSeats);
        numOfFlights++;
    }

    public void UpdateFlight(int flightNumber, string origin, string destination, int numberOfSeats)
    {
        for (int i = 0; i < flights.Length; i++)
        {
            if (flights[i].GetFlightID().Equals(flightNumber))
            {
                flights[i].UpdateFlight(origin, destination, numberOfSeats);
            }
        }
    }
    
    
    
    public void DeleteFlight(string flightNumber)
    {
        for (int i = 0; i < flights.Length; i++)
        {
            if (flights[i].GetFlightID().Equals(flightNumber))
            {
                flights[i] = flights[numOfFlights-1];
                numOfFlights--;
            }

        }
    }

    public string PrintOneFlight(string flightNumber, string customers)
    {
        string output = "Customers on flight: " + flightNumber + "\n";
        for (int i = 0; i < flights.Length; i++)
        {
            if (flights[i].GetFlightID().Equals(flightNumber))
            {
                return output += customers;
            }
        }
        return "could not find flight";
    }

    public string PrintFlights()
    {
        string output = "";
        output += "--------------Flight------------\n";
        for (int i = 0; i < numOfFlights; i++)
        {
            output+= flights[i].toString();
            output += "--------------------------\n";
        }

        return output;
    }
}