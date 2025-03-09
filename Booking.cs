using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class Booking
    {
        protected Flight flight;
        protected Customer customer;
        protected int bookingID;
        protected string date;

        public Booking(int bookingID, Flight flight, Customer customer, string date = null)
        {
            this.flight = flight;
            this.customer = customer;
            this.bookingID = bookingID;
            this.date = date;

            if (date == null)
            {
                this.date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            }
        }

        public string getDate()
        {
            return date;
        }

        public int getBookingID()
        {
            return bookingID;
        }

        public int getFlightNum()
        {
            return flight.getFlightNum();
        }

        public int getCustomerID()
        {
            return customer.getCustomerID();
        }

        public string getCustomerName()
        {
            return customer.getFullName();
        }

        public override string ToString()
        {
            string s = "\nBooking ID: " + bookingID;
            s += "\nBooking Date: " + date;
            s += "\nFlight Number: " + flight.getFlightNum();
            s += "\nCustomer Name: " + customer.getFirstName() + " " + customer.getLastName() + "\n";
            return s;
        }
    }
}