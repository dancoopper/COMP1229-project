using Project.classes;

namespace Project.managers;

public class FlightManager
{
    private Flight[] flights;
    private int numOfFlights;
    private int maxFlights;

    public FlightManager(int maxFlights)
    {
        this.numOfFlights = 0;
        this.maxFlights = maxFlights;
        this.flights = new Flight[maxFlights];
    }


    // do not add a flight with a flight number that already exists
    // user needs to enter in a flight number
    // flight number is not automatically assigned
    public bool AddFlight(int flightNum, string origin, string destination, int numberOfSeats)
    {
        for (int i = 0; i < numOfFlights; i++)
        {
            if (flights[i] != null && GetFlightNumber(i) == flightNum)
            {
                return false;
            }
        }
        flights[numOfFlights] = new Flight(flightNum, origin, destination, numberOfSeats);
        numOfFlights++;
        return true;
    }

    public int GetFlightNumber(int index)
    {
        return flights[index].GetFlightNum();
    }


    // can only be done if there are no customers booked
    public void DeleteFlight(int flightNumber)
    {
        for (int i = 0; i < flights.Length; i++)
        {
            if (flights[i].GetFlightNum().Equals(flightNumber))
            {
                flights[i] = flights[numOfFlights - 1];
                numOfFlights--;
            }

        }
    }

    public string PrintOneFlight(int flightNumber, string customers)
    {
        string output = "Customers on flight: " + flightNumber + "\n";
        for (int i = 0; i < flights.Length; i++)
        {
            if (flights[i].GetFlightNum().Equals(flightNumber))
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
            output += flights[i].toString();
            output += "--------------------------\n";
        }

        return output;
    }

    public int GetNumberOfFlights()
    {
        return numOfFlights;
    }

    public Flight[] GetFlights()
    {
        return flights;
    }
    
    
}
