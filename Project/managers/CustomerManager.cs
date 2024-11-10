using Project.classes;

namespace Project.managers;

public class CustomerManager
{
    Customer[] customers = new Customer[5];
    public int numOfCustomer = 0;

    public void AddCustomer(Customer customer)
    {
        if (numOfCustomer >= 5)
        {
            Console.WriteLine("could not add more customers");
            return;
        }

        customers[numOfCustomer] = customer;
        numOfCustomer++;
    }

    public void AddCustomers(string firstName, string lastName, string phone)
    {
        if (numOfCustomer >= 5)
        {
            Console.WriteLine("could not add more customers");
            return;
        }

        customers[numOfCustomer] = new Customer(firstName, lastName, phone);
        numOfCustomer++;
    }

    public void BookFlight(int ID)
    {
        for (int i = 0; i < numOfCustomer; i++)
        {
            if (customers[i].GetID() == ID)
            {
                customers[i].BookFlight(ID);
            }
        }
    }

    public void ShowCustomers()
    {
        Console.WriteLine("------------Customer--------------");
        for (var i = 0; i < numOfCustomer; i++)
        {
            Console.WriteLine(customers[i].toString());
            Console.WriteLine("--------------------------");
        }
    }

    public string ShowCustomersAsString()
    {
        string sCustomers = "";
        sCustomers+="------------Customer--------------\n";

        for (int i = 0; i < numOfCustomer; i++)
        {
            sCustomers += customers[i].toString();
            sCustomers+= "--------------------------\n";

        }
        
        return sCustomers;
    }
}