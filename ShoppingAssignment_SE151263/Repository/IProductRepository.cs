using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Repository
{
    public interface IProductRepository
    {
        public bool CheckNameExist(string name);

        public bool CheckImageExist(string img);

        public bool CheckNameExist(int id, string name);

        public bool CheckImageExist(int id, string img);

        public bool CheckQuantity(int id, int quantity);

        public bool SubQuantity(int id, int quantity);

        public Product GetProductByID(int id);

        public bool DeleteProduct(int id);
    }
}
