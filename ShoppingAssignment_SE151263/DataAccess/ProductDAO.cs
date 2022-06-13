using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingAssignment_SE151263.DataAccess
{
    public class ProductDAO
    {

        private static ProductDAO instance;
        private static readonly object instanceLock = new object();


        private ProductDAO() { }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public bool CheckNameExist(string name)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                List<Product> list = context.Products.ToList();
                foreach (Product tmp in list)
                {
                    if (tmp.ProductName.Trim().Trim().Equals(name.Trim()))
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at CheckNameExist: " + ex.Message);
            }
            return check;
        }

        public bool CheckNameExist(int id, string name)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                List<Product> list = context.Products.ToList();
                foreach (Product tmp in list)
                {
                    if (tmp.ProductName.Trim().Equals(name.Trim()) && tmp.ProductId != id)
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at CheckNameExist: " + ex.Message);
            }
            return check;
        }

        public bool CheckImageExist(string img)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                List<Product> list = context.Products.ToList();
                foreach (Product tmp in list)
                {
                    if (tmp.ProductImage.Trim().Trim().Equals(img.Trim()))
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at CheckImageExist: " + ex.Message);
            }
            return check;
        }

        public bool CheckImageExist(int id, string img)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                List<Product> list = context.Products.ToList();
                foreach (Product tmp in list)
                {
                    if (tmp.ProductImage.Trim().Equals(img.Trim()) && tmp.ProductId != id)
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at CheckImageExist: " + ex.Message);
            }
            return check;
        }

    }
}
