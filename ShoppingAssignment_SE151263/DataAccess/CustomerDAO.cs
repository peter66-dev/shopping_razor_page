using Microsoft.EntityFrameworkCore;
using ShoppingAssignment_SE151263.BusinessObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
        public string CheckLogin(string email, string password)
        {
            string role = "undefined";
            Account a = new Account();
            try
            {
                string json = File.ReadAllText("appsettings.json");
                a = JsonSerializer.Deserialize<Account>(json, null);
                if (email.Equals(a.Email) && password.Equals(a.Password))
                {
                    role = "admin";
                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
            return role;
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
