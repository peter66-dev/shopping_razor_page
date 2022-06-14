using ShoppingAssignment_SE151263.DataAccess;

namespace ShoppingAssignment_SE151263.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool CheckEmailExist(string email) => CustomerDAO.Instance.CheckEmailExist(email);

        public bool CheckIDExist(string id) => CustomerDAO.Instance.CheckIDExist(id);

        public bool CheckEmailExist(string id, string email) => CustomerDAO.Instance.CheckEmailExist(id, email);
    }
}
