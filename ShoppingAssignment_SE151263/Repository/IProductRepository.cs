namespace ShoppingAssignment_SE151263.Repository
{
    public interface IProductRepository
    {
        public bool CheckNameExist(string name);

        public bool CheckImageExist(string img);

        public bool CheckNameExist(int id, string name);

        public bool CheckImageExist(int id, string img);
    }
}
