using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal abstract class Person
    {
        protected string firstName;
        protected string lastName;
        protected string phoneNumber;

        public Person(string firstName, string lastName, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }

        public abstract string getFullName();

        public override string ToString()
        {
            string s = "First Name: " + firstName;
            s += "\nLast Name: " + lastName;
            s += "\nPhone Number: " + phoneNumber + "\n";
            return s;
        }
    }
}