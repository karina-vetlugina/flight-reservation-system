using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class AirlineCoordinator
    {
        private CustomerManager cm;
        private FlightManager fm;
        private BookingManager bm;

        public AirlineCoordinator(CustomerManager cm, FlightManager fm, BookingManager bm)
        {
            this.cm = cm;
            this.fm = fm;
            this.bm = bm;
        }

        public bool makeBooking(int customerID, int flightNum, string date = null, int bookingID = -1)
        {
            Customer c = cm.findCustomer(customerID);
            Flight f = fm.findFlight(flightNum);

            if (c == null || f == null)
            {
                return false;
            }
            return bm.makeBooking(c, f, date, bookingID);
        }

        public bool addCustomer(string firstName, string lastName, string phoneNumber)
        {
            return cm.addCustomer(firstName, lastName, phoneNumber);
        }

        public bool addFlight(string origin, string destination, int maxSeats)
        {
            return fm.addFlight(origin, destination, maxSeats);
        }

        public string viewFlights()
        {
            return fm.viewFlights(); // flight manager
        }

        public string viewAllCustomers()
        {
            return cm.viewAllCustomers(); // customer manager
        }

        public string viewAllBookings()
        {
            return bm.viewAllBookings(); // booking manager
        }

        public void deleteCustomer(string firstName, string lastName, string phoneNumber)
        {
            cm.deleteCustomer(firstName, lastName, phoneNumber);
        }

        public void deleteCustomer(int customerID)
        {
            cm.deleteCustomer(customerID);
        }

        public void deleteFlight(int flightNum)
        {
            fm.deleteFlight(flightNum);
        }

        public string findFlight(int flightNum) // view a particular flight
        {
            Flight flight = fm.findFlight(flightNum);
            if (flight != null)
            {
                return flight.ToString();
            }
            return "\nFlight not found";
        }

        public string customerListPerFlight(int flightNum)
        {
            return bm.customerListPerFlight(flightNum);
        }
    }
}