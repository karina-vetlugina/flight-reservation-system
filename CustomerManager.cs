using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    internal class CustomerManager
    {
        protected Customer[] customers;
        private int numCustomers;
        private int max;
        public static int generateID;

        public CustomerManager(int max, int startID)
        {
            this.max = max;
            numCustomers = 0;
            customers = new Customer[max];
            generateID = startID;
        }

        public int search(string firstName, string lastName, string phoneNum)
        {
            for (int i = 0; i < numCustomers; i++)
            {
                if (customers[i].getFirstName() == firstName && customers[i].getLastName() == lastName && customers[i].getPhoneNumber() == phoneNum)
                {
                    return i;
                }
            }
            return -1;
        }

        public int search(int customerID)
        {
            for (int i = 0; i < numCustomers; i++)
            {
                if (customers[i].getCustomerID() == customerID)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool addCustomer(string firstName, string lastName, string phoneNumber)
        {
            if (numCustomers < max)
            {
                int index = search(firstName, lastName, phoneNumber);
                if (index == -1)
                {
                    customers[numCustomers++] = new Customer(generateID, firstName, lastName, phoneNumber);
                    generateID++;
                    return true;
                }
            }
            return false;
        }

        // overloaded method for the FileUtilities class
        public bool addCustomer(int customerID, string firstName, string lastName, string phoneNumber)
        {
            if (numCustomers < max)
            {
                int index = search(firstName, lastName, phoneNumber);
                if (index == -1)
                {
                    customers[numCustomers++] = new Customer(customerID, firstName, lastName, phoneNumber);
                    return true;
                }
            }
            return false;
        }

        // a customer can only be deleted if there are no bookings
        // deleting a customer by their first name, last name and phone number
        public void deleteCustomer(string firstName, string lastName, string phoneNumber)
        {
            int index = search(firstName, lastName, phoneNumber);
            if (index != -1)
            {
                if (customers[index].getBookingCount() == 0)
                {
                    customers[index] = customers[numCustomers - 1];
                    numCustomers--;
                    Console.WriteLine("\nDeleted Customer Successfully!");
                }
                else
                {
                    Console.WriteLine("\nCustomer has bookings, can't delete!");
                }

            }
            else
            {
                Console.WriteLine("\nCustomer not found!");
            }
        }

        // deleting a customer by their customer ID
        public void deleteCustomer(int customerID)
        {
            int index = search(customerID);
            if (index != -1)
            {
                if (customers[index].getBookingCount() == 0)
                {
                    customers[index] = customers[numCustomers - 1];
                    numCustomers--;
                    Console.WriteLine("\nDeleted Customer Successfully!");
                }
                else
                {
                    Console.WriteLine("\nCustomer has bookings, can't delete!");
                }
            }
            else
            {
                Console.WriteLine("\nCustomer not found!");
            }
        }

        public Customer findCustomer(int customerID)
        {
            int index = search(customerID);
            if (index != -1)
            {
                return customers[index];
            }
            return null;
        }

        public string viewAllCustomers()
        {
            string s = "------- Customers -------";
            for (int i = 0; i < numCustomers; i++)
            {
                s += customers[i].ToString();
            }
            return s;
        }

        // file helper functionality
        public Customer[] getCustomersList()
        {
            return customers;
        }

        public int getNumCustomers()
        {
            return numCustomers;
        }
    }
}