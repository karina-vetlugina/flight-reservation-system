using FlightReservationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class FileUtilities
    {
        // SAVING CUSTOMERS
        public static void saveCustomers(CustomerManager cm)
        {
            try
            {
                StreamWriter sw = new StreamWriter("customers.txt"); // bin\\Debug\\net8.0\\customers.txt
                int numCustomers = cm.getNumCustomers();
                Customer[] customers = cm.getCustomersList();

                for (int i = 0; i < numCustomers; i++)
                {
                    sw.WriteLine(customers[i].getCustomerID() + " | " + customers[i].getFirstName() + " | " + customers[i].getLastName() + " | " + customers[i].getPhoneNumber());
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Customers file successfully saved...");
            }
        }

        // LOADING CUSTOMERS
        public static CustomerManager loadCustomers()
        {
            CustomerManager cm = new CustomerManager(1000, 1);

            try
            {
                StreamReader sr = new StreamReader("customers.txt"); // bin\\Debug\\net8.0\\customers.txt

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokens = line.Split(" | ");
                    int customerID = Convert.ToInt32(tokens[0]);
                    cm.addCustomer(customerID, tokens[1], tokens[2], tokens[3]);
                }
                sr.Close();
                return cm;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new CustomerManager(1000, 1);
        }


        // SAVING FLIGHTS
        public static void saveFlights(FlightManager fm)
        {
            try
            {
                StreamWriter sw = new StreamWriter("flights.txt"); // bin\\Debug\\net8.0\\flights.txt
                int numFlights = fm.getNumFlights();
                Flight[] flights = fm.getFlightList();

                for (int i = 0; i < numFlights; i++)
                {
                    sw.WriteLine(flights[i].getFlightNum() + " | " + flights[i].getOrigin() + " | " + flights[i].getDestination() + " | " + flights[i].getMaxSeats());
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Flights file successfully saved...");

            }

        }

        // LOADING FLIGHTS
        public static FlightManager loadFlights()
        {
            FlightManager fm = new FlightManager(1000, 100);

            try
            {
                StreamReader sr = new StreamReader("flights.txt"); // bin\\Debug\\net8.0\\flights.txt

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokens = line.Split(" | ");
                    int flightNum = Convert.ToInt32(tokens[0]);
                    int maxSeats = Convert.ToInt32(tokens[3]);
                    fm.addFlight(flightNum, tokens[1], tokens[2], maxSeats);
                }
                sr.Close();
                return fm;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new FlightManager(1000, 100);
        }


        // SAVING BOOKINGS
        public static void saveBookings(BookingManager bm)
        {
            try
            {
                StreamWriter sw = new StreamWriter("bookings.txt"); // bin\\Debug\\net8.0\\bookings.txt
                int numBookings = bm.getNumBookings();
                Booking[] bookings = bm.getBookingsList();

                for (int i = 0; i < numBookings; i++)
                {
                    sw.WriteLine(bookings[i].getBookingID() + " | " + bookings[i].getDate() + " | " + bookings[i].getFlightNum() + " | " + bookings[i].getCustomerID());
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Bookings file successfully saved...");
            }
        }

        // LOADING BOOKINGS
        public static BookingManager loadBookings(FlightManager fm, CustomerManager cm)
        {
            BookingManager bm = new BookingManager(1000, 1);

            try
            {
                StreamReader sr = new StreamReader("bookings.txt"); // bin\\Debug\\net8.0\\bookings.txt

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokens = line.Split(" | ");
                    int bookingID = Convert.ToInt32(tokens[0]);
                    int flightNum = Convert.ToInt32(tokens[2]);
                    int customerID = Convert.ToInt32(tokens[3]);

                    bm.makeBooking(bookingID, tokens[1], flightNum, customerID, fm, cm);
                }
                sr.Close();
                return bm;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new BookingManager(100, 1);
        }
    }
}