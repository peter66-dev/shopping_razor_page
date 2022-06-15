using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Repository
{
    public interface ICustomerRepository
    {
        public bool CheckIDExist(string id);
        public bool CheckEmailExist(string email);

        public bool CheckEmailExist(string id, string email);

        public bool DeleteCustomer(string id);

        public Customer GetCustomerByID(string id);
    }
}
