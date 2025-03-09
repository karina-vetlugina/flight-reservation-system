using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class Customer : Person
    {
        protected int customerID;
        protected int numOfBookings;

        public Customer(int customerID, string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
            this.customerID = customerID;
            numOfBookings = 0;
        }

        public int getCustomerID()
        {
            return customerID;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }

        public int getBookingCount()
        {
            return numOfBookings;
        }

        public void increaseNumOfBookings()
        {
            numOfBookings++;
        }

        public override string getFullName()
        {
            return firstName + " " + lastName;
        }

        public override string ToString()
        {
            string s = "\nCustomer ID: " + customerID;
            s += "\nFirst Name: " + firstName;
            s += "\nLast Name: " + lastName;
            s += "\nPhone Number: " + phoneNumber;
            s += "\nNumber of Bookings: " + numOfBookings + "\n";
            return s;
        }
    }
}