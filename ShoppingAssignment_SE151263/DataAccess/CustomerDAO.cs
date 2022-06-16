using ShoppingAssignment_SE151263.Repository;
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
                    if (tmp.CustomerId.Trim().Equals(id.Trim())) // ID trong database cô gửi có quá nhiều dấu cách ạ!
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

        public Customer GetCustomerByID(string id)
        {
            Customer cus = null;
            try
            {
                var context = new NorthwindCopyDBContext();
                cus = context.Customers.SingleOrDefault(c => c.CustomerId.Trim().Equals(id.Trim()));

            }
            catch (Exception ex)
            {
                throw new Exception("Error at CheckIDExist: " + ex.Message);
            }
            return cus;
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
                {// ID trong database cô gửi có quá nhiều dấu cách ạ!
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

        public bool DeleteCustomer(string id)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                Customer cus = context.Customers.SingleOrDefault(c => c.CustomerId.Trim().Equals(id.Trim()));
                if (cus != null)
                {
                    IOrderRepository orRepo = new OrderRepository();
                    List<Order> orders = orRepo.GetOrdersByCustomerID(id);
                    if (orders.Count == 0) // không có order thì delete
                    {
                        context.Customers.Remove(cus);
                        context.SaveChanges();
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
