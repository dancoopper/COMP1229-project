using Project.managers;

namespace Project;

public class FileUtil
{
    private static string customerPath = "../../../TextFiles/CM.txt";
    private static string flightPath = "../../../TextFiles/FM.txt";
    private static string bookingPath = "../../../TextFiles/BM.txt";

  
    public bool WriteCustomerToFile(CustomerManager cm)
    {
        if (!File.Exists(customerPath))
        {
            FileStream fs = File.Create(customerPath);
            fs.Close();
        }

        StreamWriter obj = new StreamWriter(customerPath);
        obj.WriteLine(cm.GetSeed());
        obj.WriteLine(cm.GetMaxCustomers());
        obj.WriteLine(cm.GetNumOfCustomers());
        obj.WriteLine(cm.TextInput());
        obj.Close();
        
        return true;
    }

    public CustomerManager ReadCustomerFile()
    {
        if (File.Exists(customerPath))
        {
            
            StreamReader reader = new StreamReader(customerPath);
            int maxCustomers = Convert.ToInt32(reader.ReadLine());
            int seed = Convert.ToInt32(reader.ReadLine());
            int numOfCustomers = Convert.ToInt32(reader.ReadLine());
            CustomerManager cm = new CustomerManager(maxCustomers, seed);
            for(int i=0;i<numOfCustomers;i++)
            {
                string[] customer = reader.ReadLine().Split('|');
                int numOfBookings = Convert.ToInt32(customer[0]);
                int id = Convert.ToInt32(customer[1]);
                cm.AddCustomers(numOfBookings,id,customer[2], customer[3], customer[4]);
            }
            reader.Close();
            return cm;
        }
        return new CustomerManager(1000,100);
    }

    public bool WriteFlightToFile(FlightManager fm)
    {
        
        if (!File.Exists(flightPath))
        {
            FileStream fs = File.Create(flightPath);
            fs.Close();
        }

        StreamWriter obj = new StreamWriter(flightPath);
        obj.WriteLine(fm.PrintFlights());
        obj.Close();
        
        return true;
    }
    
    public bool WriteBookToFile(BookingManager bm)
    {
        
        if (!File.Exists(bookingPath))
        {
            FileStream fs = File.Create(bookingPath);
            fs.Close();
        }

        StreamWriter obj = new StreamWriter(bookingPath);
        obj.WriteLine(bm.PrintBookings());
        obj.Close();
        
        return true;
    }
    
    

    public bool SaveState(CustomerManager cm, FlightManager fm, BookingManager bm)
    {
        WriteCustomerToFile(cm);
        WriteFlightToFile(fm);
        WriteBookToFile(bm);

        return true;
    }
}