using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class Flight
    {
        protected int flightNum;
        protected string origin;
        protected string destination;
        protected int maxSeats;
        protected int numOfPassengers;

        public Flight(int flightNum, string origin, string destination, int maxSeats)
        {
            this.flightNum = flightNum;
            this.origin = origin;
            this.destination = destination;
            numOfPassengers = 0;
            this.maxSeats = maxSeats;
        }

        public int getFlightNum()
        {
            return flightNum;
        }

        public string getOrigin()
        {
            return origin;
        }

        public string getDestination()
        {
            return destination;
        }

        public int getNumOfPassengers()
        {
            return numOfPassengers;
        }

        public int getMaxSeats()
        {
            return maxSeats;
        }

        public bool bookSeat()
        {
            if (numOfPassengers < maxSeats)
            {
                numOfPassengers++;
                return true;
            }
            return false;
        }

        public string viewFlight() // view flights
        {
            string s = "\nFlight Number: " + flightNum;
            s += "\nFlight Origin: " + origin;
            s += "\nFlight Destination: " + destination + "\n";
            return s;
        }

        public override string ToString() // view a particular flight
        {
            string s = "\nFlight Number: " + flightNum;
            s += "\nFlight Origin: " + origin;
            s += "\nFlight Destination: " + destination;
            s += "\nFlight Capacity: " + maxSeats;
            s += "\nNumber of Passengers: " + numOfPassengers;
            s += "\nAvailable Seats: " + (maxSeats - numOfPassengers);
            return s;
        }
    }
}