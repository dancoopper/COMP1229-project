using Project.classes;

namespace Project.managers;

public class CustomerManager
{
    Customer[] customers = new Customer[5];
    public int numOfCustomer = 0;

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

    public void DeleteCustomer(int customerID)
    {
        for (int i = 0; i < numOfCustomer; i++)
        {
            if (customerID == customers[i].GetID())
            {
                customers[i] = customers[numOfCustomer - 1];
                numOfCustomer--;
            }
        }
    }

    public string GetCustomerInfo(int customerID)
    {
        for (int i = 0; i < numOfCustomer; i++)
        {
            if (customerID == customers[i].GetID())
            {
                return customers[i].toString();
            }
        }

        return "could not get customer info";
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


    public string TextInput()
    {
        string sCustomers = "";
        for (int i = 0; i < numOfCustomer; i++)
        {
            sCustomers += customers[i].TextInput();
        }

        return sCustomers;
    }

    public string ShowCustomers()
    {
        string sCustomers = "";
        sCustomers += "------------Customer--------------\n";

        if (numOfCustomer <= 0)
        {
            sCustomers += "No Customers Found";
        }

        for (int i = 0; i < numOfCustomer; i++)
        {
            sCustomers += customers[i].toString();
            sCustomers += "--------------------------\n";
        }

        return sCustomers;
    }
}