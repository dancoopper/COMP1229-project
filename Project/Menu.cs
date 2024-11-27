namespace Project
{
    public class Menu
    {
        public Option[] MainMenuOptions;
        public Option[] CustomerManuOptions;
        public Option[] FlightMenuOptions;
        public Option[] BookingManuOptions;

        public static int menuIndex = 0;
        public static Option[][] MenuOptions;
        public static int index;

        public static Coordinator coordinator = new Coordinator();
        public FileUtil fileUtil = new FileUtil();
        public void Start()
        {
            // Create options that you want your menu to have
            MainMenuOptions = new Option[4];
            MainMenuOptions[0] = new Option("Customer", () => SelectMenuOption("main", "customer"));
            MainMenuOptions[1] = new Option("Flights", () => SelectMenuOption("main", "flights"));
            MainMenuOptions[2] = new Option("Bookings", () => SelectMenuOption("main", "bookings"));
            MainMenuOptions[3] = new Option("Exit", () => coordinator.EndProcess());

            CustomerManuOptions = new Option[4];
            CustomerManuOptions[0] = new Option("Add Customer", () => SelectMenuOption("customer", "add"));
            CustomerManuOptions[1] = new Option("View Customer", () => SelectMenuOption("customer", "view"));
            CustomerManuOptions[2] = new Option("Delete Customer", () => SelectMenuOption("customer", "delete"));
            CustomerManuOptions[3] = new Option("Back", () => SelectMenuOption("customer", "back"));

            FlightMenuOptions = new Option[5];
            FlightMenuOptions[0] = new Option("Add Flight", () => SelectMenuOption("flight", "add"));
            FlightMenuOptions[1] = new Option("View Flights", () => SelectMenuOption("flight", "view"));
            FlightMenuOptions[2] = new Option("View One Flight", () => SelectMenuOption("flight", "view1"));
            FlightMenuOptions[3] = new Option("Delete Flight", () => SelectMenuOption("flight", "delete"));
            FlightMenuOptions[4] = new Option("Back", () => SelectMenuOption("flight", "back"));


            BookingManuOptions = new Option[3];
            BookingManuOptions[0] = new Option("Make Booking", () => SelectMenuOption("booking", "make"));
            BookingManuOptions[1] = new Option("View Bookings", () => SelectMenuOption("booking", "view"));
            BookingManuOptions[2] = new Option("Back", () => SelectMenuOption("booking", "back"));

            MenuOptions = new[] { MainMenuOptions, CustomerManuOptions, FlightMenuOptions, BookingManuOptions };

            // Set the default index of the selected item to be the first

            // Write the menu out

            WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
            

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < MenuOptions[menuIndex].Length)
                    {
                        index++;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                    }
                    else if (index + 1 == MenuOptions[menuIndex].Length) // when index is more them 4
                    {
                        index = 0;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                    }
                    else if (index - 1 < 0)
                    {
                        index = MenuOptions[menuIndex].Length - 1;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                    }
                }

                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    MenuOptions[menuIndex][index].GetSelected().Invoke();

                    //WriteMenu();
                    //index = 0;
                }
            } while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }

        // Default action of all the options. You can create more methods
        static void SelectMenuOption(string menu, string option)
        {
            Console.Clear();
            //Console.WriteLine(message);

            if (menu.Equals("main")) //main menu
            {
                switch (option)
                {
                    case "customer":
                        menuIndex = 1;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                    case "flights":
                        menuIndex = 2;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                    case "bookings":
                        menuIndex = 3;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                }
            }

            if (menu.Equals("customer")) // customer menu
            {
                switch (option)
                {
                    case "add":
                        string firstName = GetValidInputString("What is the first name: ");
                        string lastName = GetValidInputString("What is the last name: ");
                        string phone = GetValidInputString("What is the phone number: ");
                        coordinator.AddCustomers(firstName, lastName, phone);
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                    case "view":
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index], true,
                            coordinator.ShowCustomers());
                        option = null;
                        break;
                    case "delete":
                        int customerID;

                        if (int.TryParse(
                                GetValidInputString(
                                    $"{coordinator.ShowCustomers()}\nwhat is the customer id (Enter 0 to go back): "),
                                out customerID))
                        {
                            if (customerID <= 0)
                            {
                                WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                                break;
                            }

                            coordinator.DeleteCustomers(customerID);
                            WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index], true, "Customer Deleted");
                        }
                        else
                        {
                            WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index], true,
                                "Could not delete the customer");
                        }

                        break;
                    case "back":
                        menuIndex = 0;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                }
            }

            if (menu.Equals("flight")) //flight menu
            {
                int flightID = 0;
                switch (option)
                {
                    case "add":
                        string origin = GetValidInputString("What is the origin: ");
                        string destination = GetValidInputString("What is the destination: ");
                        int numberOfSeats = GetValidInputInt("What is the number of seats: ");
                        int flightNum = GetValidInputInt("What is the flight number: ");
                        if (coordinator.AddFlights(flightNum, origin, destination, numberOfSeats))
                        {
                            WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index], true, "Flight Added");
                        }
                        else
                        {
                            WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index], true, "Flight not added (can't have duplicate flight numbers)");
                        }
                        break;
                    case "view":
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index], true, coordinator.PrintFlights());
                        option = null;
                        break;
                    case "view1"://fix this
                        flightID = GetValidInputInt($"{coordinator.PrintFlights()}\nWhat is the flight ID: ");
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index], true, coordinator.PrintOneFlight(flightID));
                        option = null;
                        break;
                    case "delete"://fix this
                         flightID = GetValidInputInt($"{coordinator.PrintFlights()}\nWhat is the flight ID: ");
                         coordinator.DeleteFlights(flightID);
                        break;
                    case "back":
                        menuIndex = 0;
                        index--;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                }
            }

            if (menu.Equals("booking")) //booking menu
            {
                switch (option)
                {
                    case "make":
                        int customerID =int.TryParse(GetValidInputString($"{coordinator.ShowCustomers()}\nEnter the customer ID: "), out customerID)?customerID:0;
                        int flightID = GetValidInputInt($"{coordinator.PrintFlights()}\nEnter the flight ID: ");
                        coordinator.MakeBooking(customerID, flightID);
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index],true, "Booking made successfully");
                        option = null; 
                        break;
                    case "view":
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index],true, coordinator.ShowBookings());
                        option = null;
                        break;
                    case "back":
                        menuIndex = 0;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                }
            }
        }

        static int GetValidInputInt(string prompt)
        {
            int input;
            string userInput;
            Console.Clear();
            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                // Check for null or empty strings
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.Clear();
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                // Check for overly long strings
                if (userInput.Length > 100) // Adjust the length limit as needed
                {
                    Console.Clear();
                    Console.WriteLine("Input is too long. Please enter a shorter number.");
                    continue;
                }

                // Try parsing the input to an integer
                if (int.TryParse(userInput, out input))
                {
                    break;  // Valid integer input
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

            return input;
        }

        
        static string GetValidInputString(string prompt)
        {
            string input;
            Console.Clear();
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                // Check for null or empty strings
                if (string.IsNullOrEmpty(input))
                {
                    Console.Clear();
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                // Check for overly long strings
                if (input.Length > 100) // Adjust the length limit as needed
                {
                    Console.Clear();
                    Console.WriteLine("Input is too long. Please enter a shorter string.");
                    continue;
                }

                break;
            }

            return input;
        }


        static void DrawScreen(string titleText = null)
        {
            Console.Clear();
            Console.WriteLine(titleText);
            
        }
        
        static void WriteMenu(Option[] options, Option selectedOption, bool hasTitle = false, string titleText = null)
        {
            
            Console.Clear();


            Console.WriteLine("ABC Airlines.");
            if (hasTitle && titleText != null)
            {
                Console.WriteLine(titleText);
                
            }


            switch (menuIndex)
            {
                case 0:
                    Console.WriteLine("----Main menu----");
                    break;
                case 1:
                    Console.WriteLine("----Customer menu----");
                    break;
                case 2:
                    Console.WriteLine("----Flight menu----");
                    break;
                case 3:
                    Console.WriteLine("----Booking menu----");
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }


            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.GetName());
            }

            Console.WriteLine("Up Arrow: Up\nDown Arrow: Down\nEnter: enter\n\n");
            
            
        }

        
    }
    
    
    public class Option
    {
        private string Name;
        private Action selected;

        // Constructor to initialize fields
        public Option(string name, Action selected)
        {
            this.Name = name;
            this.selected = selected;
        }

        public string GetName()
        {
            return this.Name;
        }

        public Action GetSelected()
        {
            return this.selected;
        }
    }
}