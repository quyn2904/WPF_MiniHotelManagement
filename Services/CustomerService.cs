using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService
    {
        private static CustomerService instance;
        private CustomerService() { }
        public static CustomerService GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerService();
            }
            return instance;
        }

        private readonly ICustomerRepository _customerRepository = CustomerRepository.GetInstance();
    }
}
