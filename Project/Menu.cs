namespace Project
{
    public class Menu
    {
        public Option[] options1;
        public Option[] options2;
        public Option[] options3;
        public Option[] options4;

        public static int menuIndex = 0;
        public static Option[][] MenuOptions;
        public static int index;

        public static Coordinator coordinator = new Coordinator();

        public void Start()
        {
            // Create options that you want your menu to have
            options1 = new Option[4];
            options1[0] = new Option("Customer", () => SelectMenuOption("main", "customer"));
            options1[1] = new Option("Flights", () => SelectMenuOption("main", "flights"));
            options1[2] = new Option("Bookings", () => SelectMenuOption("main", "bookings"));
            options1[3] = new Option("Exit", () => Environment.Exit(0));

            options2 = new Option[4];
            options2[0] = new Option("Add Customer", () => SelectMenuOption("customer", "add"));
            options2[1] = new Option("View Customer", () => SelectMenuOption("customer", "view"));
            options2[2] = new Option("Delete Customer", () => SelectMenuOption("customer", "delete"));
            options2[3] = new Option("Back", () => SelectMenuOption("customer", "back"));

            options3 = new Option[5];
            options3[0] = new Option("Add Flight", () => SelectMenuOption("flight", "add"));
            options3[1] = new Option("View Flights", () => SelectMenuOption("flight", "view"));
            options3[2] = new Option("View One Flight", () => SelectMenuOption("flight", "view1"));
            options3[3] = new Option("Delete Flight", () => SelectMenuOption("flight", "delete"));
            options3[4] = new Option("Back", () => SelectMenuOption("flight", "back"));


            options4 = new Option[3];
            options4[0] = new Option("Make Booking", () => SelectMenuOption("booking", "make"));
            options4[1] = new Option("View Bookings", () => SelectMenuOption("booking", "view"));
            options4[2] = new Option("Back", () => SelectMenuOption("booking", "back"));

            MenuOptions = new[] { options1, options2, options3, options4 };

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
                        string firstName = GetValidInput("What is the first name: ");
                        string lastName = GetValidInput("What is the last name: ");
                        string phone = GetValidInput("What is the phone number: ");
                        coordinator.AddCustomers(firstName, lastName, phone);
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                    case "view":
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index],true, coordinator.ShowCustomersAsString());
                        break;
                    case "delete":
                        break;
                    case "back":
                        menuIndex = 0;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                }
            }

            if (menu.Equals("flight")) //flight menu
            {
                switch (option)
                {
                    case "add":
                        break;
                    case "view":
                        break;
                    case "view1":
                        break;
                    case "delete":
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
                        break;
                    case "view":
                        break;
                    case "back":
                        menuIndex = 0;
                        WriteMenu(MenuOptions[menuIndex], MenuOptions[menuIndex][index]);
                        break;
                }
            }
        }

        static string GetValidInput(string prompt)
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

        static void WriteMenu(Option[] options, Option selectedOption, bool hasTitle = false, string titleText = null)
        {
            Console.Clear();


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
            
            if (hasTitle)
            {
                Console.WriteLine(titleText);
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
            Console.WriteLine("Up Arrow: Up\nDown Arrow: Down\nEnter: enter");
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