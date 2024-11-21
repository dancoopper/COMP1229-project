using Project.managers;

namespace Project;

public class FileUtil
{
    private string customerPath = "../../../TextFiles/CM.txt";
    private string flightPath = "../../../TextFiles/FM.txt";
    private string bookingPath = "../../../TextFiles/BM.txt";

  
    public bool WriteCustomerToFile(CustomerManager cm)
    {
        if (!File.Exists(customerPath))
        {
            FileStream fs = File.Create(customerPath);
            fs.Close();
        }

        StreamWriter obj = new StreamWriter(customerPath);
        obj.WriteLine(cm.TextInput());
        obj.Close();
        
        return true;
    }

    public string[] ReadCustomerFile()
    {
        
        string[] s;
        StreamReader obj = new StreamReader(customerPath);
        s = obj.ReadToEnd().Split("|");
        obj.Close();
        return s;
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