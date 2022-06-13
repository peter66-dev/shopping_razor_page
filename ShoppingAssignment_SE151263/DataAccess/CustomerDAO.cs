using System;
using System.Collections.Generic;
using System.Linq;

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


        public bool CheckIDExist(string id)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                List<Customer> list = context.Customers.ToList();
                foreach (Customer tmp in list)
                {
                    if (tmp.CustomerId.Trim().Equals(id.Trim()))
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error at CheckIDExist: " + ex.Message);
            }
            return check;
        }

        public bool CheckEmailExist(string email)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                List<Customer> list = context.Customers.ToList();
                foreach (Customer tmp in list)
                {
                    if (tmp.Email.Trim().Equals(email.Trim()))
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error at CheckIDExist: " + ex.Message);
            }
            return check;
        }

        public bool CheckEmailExist(string id, string email)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                List<Customer> list = context.Customers.ToList();
                foreach (Customer tmp in list)
                {
                    if (tmp.Email.Trim().Equals(email.Trim()) && !tmp.CustomerId.Trim().Equals(id.Trim()))
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error at CheckIDExist: " + ex.Message);
            }
            return check;
        }

    }
}
