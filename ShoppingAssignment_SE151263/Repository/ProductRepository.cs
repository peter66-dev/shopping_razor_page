using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Repository
{
    public class ProductRepository : IProductRepository
    {
        public bool CheckNameExist(string name) => ProductDAO.Instance.CheckNameExist(name);

        public bool CheckImageExist(string img) => ProductDAO.Instance.CheckImageExist(img);

        public bool CheckNameExist(int id, string name) => ProductDAO.Instance.CheckNameExist(id, name);

        public bool CheckImageExist(int id, string img) => ProductDAO.Instance.CheckImageExist(id, img);
    }
}
