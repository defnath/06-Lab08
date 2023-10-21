﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;
namespace Business
{
    public class BCustomer
    {
        public List<Customer> GetCustomersByName(string customerName)
        {

            List<Customer> customers = new List<Customer>();

            CustomerDB customerDataAccess = new CustomerDB();
            customers = customerDataAccess.GetCustomer();

            var results = customers.Where(x => x.Name.Contains(customerName)).ToList();

            return results;
        }
    }
}