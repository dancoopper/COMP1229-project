using Project.managers;
using Project.classes;
namespace Project;

public class FileUtil
{
    private static string customerPath = "../../../TextFiles/CM.txt";
    private static string flightPath = "../../../TextFiles/FM.txt";
    private static string bookingPath = "../../../TextFiles/BM.txt";


    public void SaveCustomerFile(CustomerManager cm)
    {
        if (!File.Exists(customerPath))
        {
            FileStream customerFile = File.Create(customerPath);
            customerFile.Close();
        }

        StreamWriter writer = new StreamWriter(customerPath);
        int numCustomers = cm.GetNumOfCustomers();
        int seed = CustomerManager.GetSeed();
        writer.WriteLine(numCustomers);
        writer.WriteLine(seed);
        Customer[] customers = cm.GetCustomers();
        for(int customerIndex = 0; customerIndex < numCustomers; customerIndex++)
        {
            writer.WriteLine(customers[customerIndex].GetNumOfBookings() + "|" + customers[customerIndex].GetID() + "|" + customers[customerIndex].GetFirstName() + "|" + customers[customerIndex].GetLastName() + "|" + customers[customerIndex].GetPhone());
        }
        writer.Close();
    }

    public CustomerManager LoadCustomerFile()
    {
        if (File.Exists(customerPath))
        {
            StreamReader reader = new StreamReader(customerPath);
            int numOfCustomers = Convert.ToInt32(reader.ReadLine());
            int seed = Convert.ToInt32(reader.ReadLine());
            CustomerManager cm = new CustomerManager(numOfCustomers + 1000, seed);

            for (int customerIndex = 0; customerIndex < numOfCustomers; customerIndex++)
            {
                string[] customer = reader.ReadLine().Split('|');
                int numOfBookings = Convert.ToInt32(customer[0]);
                int id = Convert.ToInt32(customer[1]);
                cm.AddCustomers(numOfBookings, id, customer[2], customer[3], customer[4]);
            }
            reader.Close();
            return cm;
        }
        return new CustomerManager(1000, 100);
    }

    public void SaveFlightFile(FlightManager fm)
    {

        if (!File.Exists(flightPath))
        {
            FileStream flightFile = File.Create(flightPath);
            flightFile.Close();
        }

        StreamWriter writer = new StreamWriter(flightPath);
        int numFlights = fm.GetNumberOfFlights();
        Flight[] flights = fm.GetFlights();
        writer.WriteLine(numFlights);
        for (int flightIndex = 0; flightIndex < numFlights; flightIndex++)
        {
            writer.WriteLine(flights[flightIndex].GetFlightNum() + "|" + flights[flightIndex].GetOrigin() + "|" + flights[flightIndex].GetDestination() + "|" + flights[flightIndex].GetMaxSeats());
        }
        writer.Close();
    }

    public FlightManager LoadFlightFile()
    {
        if (File.Exists(flightPath))
        {
            StreamReader reader = new StreamReader(flightPath);
            int numFlights = Convert.ToInt32(reader.ReadLine());
            FlightManager fm = new FlightManager(numFlights + 1000);

            for (int flightIndex = 0; flightIndex < numFlights; flightIndex++)
            {
                string[] flight = reader.ReadLine().Split("|");
                int flightNum = Convert.ToInt32(flight[0]);
                int seatNum = Convert.ToInt32(flight[3]);
                fm.AddFlight(flightNum, flight[1], flight[2], seatNum);
            }
            reader.Close();
            return fm;
        }
        return new FlightManager(1000);
    }

    public void SaveBookingFile(BookingManager bm)
    {

        if (!File.Exists(bookingPath))
        {
            FileStream bookingFile = File.Create(bookingPath);
            bookingFile.Close();
        }

        StreamWriter writer = new StreamWriter(bookingPath);
        int numBookings = bm.GetNumberOfBookings();
        int seed = BookingManager.GetSeed();
        writer.WriteLine(numBookings);
        writer.WriteLine(seed);
        Booking[] bookings = bm.GetBookings();

        for(int bookingIndex = 0; bookingIndex < numBookings; bookingIndex++)
        {
            writer.WriteLine(bookings[bookingIndex].GetBookingID() + "|" + bookings[bookingIndex].GetCustomerID() + "|" + bookings[bookingIndex].GetFlightNumber() + "|" + bookings[bookingIndex].GetDate());
        }
        writer.Close();
    }

    public BookingManager LoadBookingFile()
    {
        if(File.Exists(bookingPath))
        {
            StreamReader reader = new StreamReader(bookingPath);
            int numBookings = Convert.ToInt32(reader.ReadLine());
            int seed = Convert.ToInt32(reader.ReadLine());
            BookingManager bm = new BookingManager(numBookings + 1000, seed);

            for (int bookingIndex = 0; bookingIndex < numBookings; bookingIndex++)
            {
                string[] booking = reader.ReadLine().Split("|");
                int bookingID = Convert.ToInt32(booking[0]);
                int customerID = Convert.ToInt32(booking[1]);
                int flightNumber = Convert.ToInt32(booking[2]);
                bm.MakeBooking(bookingID, customerID, flightNumber, booking[3]);
            }
            reader.Close();
            return bm;
        }
        return new BookingManager(1000, 1);
    }

    public void SaveState(CustomerManager cm, FlightManager fm, BookingManager bm)
    {
        SaveCustomerFile(cm);
        SaveFlightFile(fm);
        SaveBookingFile(bm);
    }
}