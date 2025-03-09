using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class BookingManager
    {
        protected int maxBookings;
        protected int numberOfBookings;
        protected Booking[] bookings;
        public static int generateBookingID;

        public BookingManager(int max, int startBookingID)
        {
            maxBookings = max;
            numberOfBookings = 0;
            bookings = new Booking[max];
            generateBookingID = startBookingID;
        }

        public bool makeBooking(Customer c, Flight f, string date = null, int bookingID = -1)
        {
            // check if the customer has already booked this flight
            for (int i = 0; i < numberOfBookings; i++)
            {
                if (bookings[i].getCustomerID() == c.getCustomerID() && bookings[i].getFlightNum() == f.getFlightNum())
                {
                    Console.WriteLine("\nCustomer has already booked this flight!");
                    return false;
                }
            }

            // check if there are available seats on the flight
            if (numberOfBookings < maxBookings && f.getNumOfPassengers() < f.getMaxSeats()) // check booking limit and flight seat availability
            {
                // create the booking
                if (date == null)
                {
                    bookings[numberOfBookings++] = new Booking(generateBookingID, f, c);
                    generateBookingID++;
                }
                else
                {
                    bookings[numberOfBookings++] = new Booking(bookingID, f, c, date);
                }

                // book a seat
                f.bookSeat(); // decrease maxSeats and increase numOfPassengers
                c.increaseNumOfBookings(); // increase the number of bookings for the customer
                return true;
            }
            return false;
        }

        // overloaded method for the FileUtilities class
        public bool makeBooking(int bookingID, string date, int flightNum, int customerID, FlightManager fm, CustomerManager cm)
        {
            Flight flight = fm.findFlight(flightNum);
            Customer customer = cm.findCustomer(customerID);

            if (flight == null || customer == null)
            {
                return false;
            }

            return makeBooking(customer, flight, date, bookingID);
        }


        public string customerListPerFlight(int flightNum)
        {
            string s = "--- List of Customers for Flight " + flightNum + " ---\n";
            bool foundCustomer = false;
            for (int i = 0; i < numberOfBookings; i++)
            {
                if (bookings[i].getFlightNum() == flightNum)
                {
                    foundCustomer = true;
                    int customerID = bookings[i].getCustomerID();
                    string customerName = bookings[i].getCustomerName();
                    s += "Customer ID: " + customerID + "\n";
                    s += "Name: " + customerName + "\n\n";
                }
            }
            if (!foundCustomer)
            {
                s += "\nNo customers found on this flight!";
            }
            return s;
        }

        public string viewAllBookings()
        {
            string s = "--- List of Bookings ---";
            for (int i = 0; i < numberOfBookings; i++)
            {
                s += bookings[i].ToString();
            }
            return s;
        }
        
        // file helper functionality
        public Booking[] getBookingsList()
        {
            return bookings;
        }

        public int getNumBookings()
        {
            return numberOfBookings;
        }
    }
}