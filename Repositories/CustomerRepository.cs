using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static CustomerRepository instance;
        private CustomerRepository() { }
        public static CustomerRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerRepository();
            }
            return instance;
        }

        private readonly CustomerDAO _customerDAO = CustomerDAO.GetInstance();
    }
}
