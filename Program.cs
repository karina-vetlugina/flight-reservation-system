namespace FlightReservationSystem
{
    internal class Program
    {
        static AirlineCoordinator coord;

        // MAIN MENU
        public static string mainMenu()
        {
            string s = "---- WELCOME ----";
            s += "\n\nPlease select an option:";
            s += "\n1. Customers";
            s += "\n2. Flights";
            s += "\n3. Bookings";
            s += "\n4. Exit";
            s += "\n\nEnter your choice: ";
            return s;
        }

        public static void showMainMenu()
        {
            Console.Clear();
            Console.WriteLine(mainMenu());
        }

        public static int getValidChoice(int range)
        {
            int choice;
            showMainMenu();
            if (!int.TryParse(Console.ReadLine(), out choice) || choice > range)
            {
                showMainMenu();
            }
            return choice;
        }

        public static void run()
        {
            int choice;
            choice = getValidChoice(4);

            while (choice != 4)
            {
                if (choice == 1)
                {
                    customersMenu();
                }
                if (choice == 2)
                {
                    flightsMenu();
                }
                if (choice == 3)
                {
                    bookingMenu();
                }
                choice = getValidChoice(4);
            }
        }

        
        // CUSTOMERS MENU
        public static void customersMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("---- CUSTOMERS MENU ----\n");
                Console.WriteLine("1. Add a Customer");
                Console.WriteLine("2. View All Customers");
                Console.WriteLine("3. Delete a Customer");
                Console.WriteLine("4. Back to the Main Menu");
                Console.Write("\nEnter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addCustomer();
                        break;
                    case 2:
                        viewAllCustomers();
                        break;
                    case 3:
                        deleteCustomer();
                        break;
                    default:
                        break;
                }
            } while (choice != 4);
        }

        public static void addCustomer()
        {
            Console.Clear();
            string firstName, lastName, phoneNumber;

            Console.WriteLine("---- ADD A CUSTOMER ----\n");

            Console.Write("\nEnter First Name: ");
            firstName = Console.ReadLine();

            Console.Write("\nEnter Last Name: ");
            lastName = Console.ReadLine();

            Console.Write("\nEnter Phone Number: ");
            phoneNumber = Console.ReadLine();

            if (coord.addCustomer(firstName, lastName, phoneNumber))
            {
                Console.WriteLine("\nCustomer added successfully!");
            }
            else
            {
                Console.WriteLine("\nCustomer not added!");
            }
            Console.ReadKey();
        }

        public static void viewAllCustomers()
        {
            Console.Clear();
            Console.WriteLine(coord.viewAllCustomers());
            Console.ReadKey();
        }

        public static void deleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("---- DELETE A CUSTOMER ----\n");
            Console.Write("\n1. Delete by Customer ID");
            Console.Write("\n2. Delete by Name and Phone Number");
            Console.Write("\n3. Back to Customers Menu");
            Console.Write("\n\nEnter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(coord.viewAllCustomers() + "\n");
                    Console.Write("Enter Customer ID: ");
                    int customerID = Convert.ToInt32(Console.ReadLine());
                    coord.deleteCustomer(customerID);
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\n" + coord.viewAllCustomers() + "\n");

                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    string phoneNumber = Console.ReadLine();

                    coord.deleteCustomer(firstName, lastName, phoneNumber);
                    Console.ReadKey();
                    break;
                case 3:
                    customersMenu();
                    break;
                default:
                    break;
            }
        }


        // FLIGHTS MENU
        public static void flightsMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("---- FLIGHTS MENU ----\n");
                Console.WriteLine("1. Add a Flight");
                Console.WriteLine("2. View Flights");
                Console.WriteLine("3. View a Particular Flight");
                Console.WriteLine("4. Delete a Flight");
                Console.WriteLine("5. Back to the Main Menu");
                Console.Write("\nEnter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addFlight();
                        break;
                    case 2:
                        viewFlights();
                        break;
                    case 3:
                        viewAllFlights();
                        break;
                    case 4:
                        deleteFlight();
                        break;
                    default:
                        break;
                }
            } while (choice != 5);
        }

        public static void addFlight()
        {
            Console.Clear();
            string origin, destination;
            int maxSeats;

            Console.WriteLine("---- ADD A FLIGHT ----\n");

            Console.Write("\nEnter Origin: ");
            origin = Console.ReadLine();

            Console.Write("\nEnter Destination: ");
            destination = Console.ReadLine();

            Console.Write("\nEnter Maximum Seats: ");
            maxSeats = Convert.ToInt32(Console.ReadLine());

            if (coord.addFlight(origin, destination, maxSeats))
            {
                Console.WriteLine("\nFlight added successfully!");
            }
            else
            {
                Console.WriteLine("\nFlight not added!");
            }
            Console.ReadKey();
        }

        public static void viewFlights()
        {
            Console.Clear();
            Console.WriteLine("---- VIEW ALL FLIGHTS ----\n");
            Console.WriteLine(coord.viewFlights());
            Console.ReadKey();
        }

        // searching for a particular flight
        public static void viewAllFlights()
        {
            Console.Clear();
            Console.WriteLine(coord.viewFlights());

            Console.WriteLine("\n---- VIEW A PARTICULAR FLIGHT ----\n");

            Console.Write("Enter Flight Number: ");
            int flightNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(coord.findFlight(flightNum));
            Console.WriteLine("\n" + coord.customerListPerFlight(flightNum));
            Console.ReadKey();
        }

        public static void deleteFlight()
        {
            Console.Clear();
            Console.WriteLine("---- DELETE A FLIGHT ----\n");
            Console.WriteLine("1. Delete by FLight Number");
            Console.WriteLine("2. Back to Flights Menu");
            Console.Write("\nEnter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(coord.viewFlights() + "\n"); // displaying all the flights before deleting

                    Console.Write("\nEnter Flight Number: ");
                    int flightNum = Convert.ToInt32(Console.ReadLine());
                    coord.deleteFlight(flightNum);
                    Console.ReadKey();
                    break;
                case 2:
                    flightsMenu();
                    break;
                default:
                    break;
            }
        }


        // BOOKINGS MENU
        public static void bookingMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("---- BOOKING MENU ----\n");
                Console.WriteLine("1. Make a Booking");
                Console.WriteLine("2. View All Bookings");
                Console.WriteLine("3. Back to the Main Menu");
                Console.Write("\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        makeBooking();
                        break;
                    case 2:
                        viewAllBookings();
                        break;
                    default:
                        break;
                }
            } while (choice != 3);
        }

        public static void makeBooking()
        {
            Console.Clear();
            Console.WriteLine(coord.viewAllCustomers());
            Console.WriteLine(coord.viewFlights());

            int customerID, flightID;

            Console.WriteLine("\n---- MAKE A BOOKING ----\n");

            Console.Write("Enter Customer ID: ");
            customerID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Flight ID: ");
            flightID = Convert.ToInt32(Console.ReadLine());

            if (coord.makeBooking(customerID, flightID))
            {
                Console.WriteLine("\nBooking Successful!");
            }
            else
            {
                Console.WriteLine("\nBooking Failed!");
            }
            Console.ReadKey();
        }

        public static void viewAllBookings()
        {
            Console.Clear();
            Console.WriteLine(coord.viewAllBookings());
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            CustomerManager cm = FileUtilities.loadCustomers();
            FlightManager fm = FileUtilities.loadFlights();
            BookingManager bm = FileUtilities.loadBookings(fm, cm);

            // CustomerManager cm = new CustomerManager(100, 1);
            // FlightManager fm = new FlightManager(1000, 100);
            // BookingManager bm = new BookingManager(100, 1);

            coord = new AirlineCoordinator(cm, fm, bm);
            run();

            FileUtilities.saveCustomers(cm);
            FileUtilities.saveFlights(fm);
            FileUtilities.saveBookings(bm);
        }
    }
}