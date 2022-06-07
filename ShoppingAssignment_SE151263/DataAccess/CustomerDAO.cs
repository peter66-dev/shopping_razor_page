using System;
using System.Collections.Generic;

namespace ShoppingAssignment_SE151263.DataAccess
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();
        private CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Customer> GetAllCustomer()
        {
            List<Customer> list = null;
            try
            {
                var context = new NorthwindCopyDBContext();
                //list = context.Customers.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Bug in GetAllCustomer function!");
            }
            return list;
        }
    }
}
