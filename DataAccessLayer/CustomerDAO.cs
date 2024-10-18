using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO : IDAO<Customer>
    {
        private static CustomerDAO instance;
        private CustomerDAO() { }
        public static CustomerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerDAO();
            }
            return instance;
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
