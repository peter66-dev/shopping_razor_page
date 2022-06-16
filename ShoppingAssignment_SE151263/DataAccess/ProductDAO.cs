using ShoppingAssignment_SE151263.Repository;
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
                    if (tmp.ProductName.ToLower().Trim().Equals(name.ToLower().Trim()))
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
                    if (tmp.ProductName.ToLower().Trim().Equals(name.ToLower().Trim()) && tmp.ProductId != id)
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
                    if (tmp.ProductImage.ToLower().Trim().Equals(img.ToLower().Trim()))
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
                    if (tmp.ProductImage.ToLower().Trim().Equals(img.Trim()) && tmp.ProductId != id)
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

        public bool CheckQuantity(int id, int quantity)
        {
            bool check = false;

            try
            {
                var context = new NorthwindCopyDBContext();
                Product pro = context.Products.SingleOrDefault(p => p.ProductId == id);
                if (quantity <= pro.QuantityPerUnit)
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at CheckQuantity:" + ex.Message);
            }

            return check;
        }
        public bool SubQuantity(int id, int quantity)
        {
            bool check = false;

            try
            {
                var context = new NorthwindCopyDBContext();
                Product pro = context.Products.SingleOrDefault(p => p.ProductId == id);
                pro.QuantityPerUnit -= quantity;
                if (pro.QuantityPerUnit >= 0)
                {
                    check = true;
                    byte available = 1;
                    byte notAvailable = 0;
                    pro.ProductStatus = pro.QuantityPerUnit > 0 ? available : notAvailable;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at SubQuantity:" + ex.Message);
            }

            return check;
        }

        public Product GetProductByID(int id)
        {
            Product pro = null;
            try
            {
                var context = new NorthwindCopyDBContext();
                pro = context.Products.SingleOrDefault(p => p.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error at SubQuantity:" + ex.Message);
            }
            return pro;
        }

        public bool DeleteProduct(int id)
        {
            bool check = false;
            try
            {
                var context = new NorthwindCopyDBContext();
                Product pro = new Product();
                pro = GetProductByID(id);
                if (pro != null)
                {
                    IOrderDetailRepository odRepo = new OrderDetailRepository();
                    List<OrderDetail> odList = odRepo.GetListByProductID(id);
                    if (odList.Count == 0)
                    {
                        context.Products.Remove(pro);
                        context.SaveChanges();
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error at DeleteProduct: " + ex.Message);
            }
            return check;
        }

    }
}
