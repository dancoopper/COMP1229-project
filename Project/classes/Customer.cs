namespace Project.classes;

public class Customer
{
    private static int nextID = 1;
    private int ID;
    private string firstName;
    private string lastName;
    private string phone;
    private int numOfBookings = 0;

    public Customer(string firstName, string lastName, string phone)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.ID = nextID;
        nextID++;
    }

    public void BookFlight(int ID)
    {
        this.numOfBookings = numOfBookings + 1;
    }

    public int GetID()
    {
        return this.ID;
    }

   
    
    public string toString()
    {
        return
            $"ID: {this.ID}\nFirst name: {firstName}\nLast name: {lastName}\nPhone number: {phone}\nNumber of bookings: {numOfBookings}\n";
    }
}