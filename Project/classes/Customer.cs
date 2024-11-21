namespace Project.classes;

public class Customer
{
    private int ID;
    private string firstName;
    private string lastName;
    private string phone;
    private int numOfBookings = 0;

    public Customer(int id, string firstName, string lastName, string phone)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.ID = id;
    }

    public Customer(int NumofBook, int id, string firstName, string lastName, string phone)
    {
        this.numOfBookings = numOfBookings;
        this.ID = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
    }

    public void BookFlight()
    {
        
        this.numOfBookings = numOfBookings + 1;
    }

    public int GetID()
    {
        return this.ID;
    }
    public string TextInput()
    {
        return
            $"{numOfBookings}|{this.ID}|{this.firstName}|{this.lastName}|{this.phone}\n";
    }
   
    
    public string toString()
    {
        return
            $"ID: {this.ID}\nFirst name: {firstName}\nLast name: {lastName}\nPhone number: {phone}\nNumber of bookings: {numOfBookings}\n";
    }
}