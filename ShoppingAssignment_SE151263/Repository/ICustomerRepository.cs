namespace ShoppingAssignment_SE151263.Repository
{
    public interface ICustomerRepository
    {
        public bool CheckIDExist(string id);
        public bool CheckEmailExist(string email);

        public bool CheckEmailExist(string id, string email);
    }
}
