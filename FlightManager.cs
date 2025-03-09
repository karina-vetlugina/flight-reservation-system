using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class FlightManager
    {
        public Flight[] flights;
        protected int numFlights;
        protected int maxFlights;
        public static int generateFlightNum;

        public FlightManager(int max, int startFlightNum)
        {
            maxFlights = max;
            numFlights = 0;
            flights = new Flight[max];
            generateFlightNum = startFlightNum;
        }

        public int search(int flightNum)
        {
            for (int i = 0; i < numFlights; i++)
            {
                if (flights[i].getFlightNum() == flightNum)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool addFlight(string origin, string destination, int maxSeats)
        {
            if (numFlights < maxFlights)
            {
                flights[numFlights++] = new Flight(generateFlightNum, origin, destination, maxSeats);
                generateFlightNum++;
                return true;
            }
            return false;
        }

        // overloaded method for the fileUtilities
        public bool addFlight(int flightNum, string origin, string destination, int maxSeats)
        {
            if (numFlights < maxFlights)
            {
                flights[numFlights++] = new Flight(flightNum, origin, destination, maxSeats);
                return true;
            }
            return false;
        }

        public void deleteFlight(int flightNum)
        {
            int index = search(flightNum);
            if (index != -1)
            {
                if (flights[index].getNumOfPassengers() == 0)
                {
                    flights[index] = flights[numFlights - 1];
                    numFlights--;
                    Console.WriteLine("\nDeleted Flight Successfully!");
                }
                else
                {
                    Console.WriteLine("\nCannot delete flight with passengers!");
                }
            }
            else
            {
                Console.WriteLine("\nFlight does not exist!");
            }
        }

        public Flight findFlight(int flightNum)
        {
            int index = search(flightNum);
            if (index != -1)
            {
                return flights[index];
            }
            return null;
        }

        // When you select “View Flights”, a list containing the Flight number, origin and destination for each flight must be shown.
        public string viewFlights()
        {
            string s = "------- Flights -------";
            for (int i = 0; i < numFlights; i++)
            {
                s += flights[i].viewFlight();
            }
            return s;
        }

        // file helper functionality
        public Flight[] getFlightList()
        {
            return flights;
        }

        public int getNumFlights()
        {
            return numFlights;
        }
    }    
}