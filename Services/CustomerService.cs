using BusinessObjects;
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

        private UnitOfWork unitOfWork = new UnitOfWork();

        public Customer? CustomerLogin(String email, String password)
        {
            var user = this.unitOfWork.CustomerRepository.Get(item => item.EmailAddress == email).FirstOrDefault();
            return user != null && user.Password.Equals(password) ? user : null;
        }

        public bool AdminLogin(String email, String password) => this.unitOfWork.CustomerRepository.AdminLogin(email, password);

        public void UpdateCustomer(Customer customer)
        {
            this.unitOfWork.CustomerRepository.Update(customer);
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return this.unitOfWork.CustomerRepository.Get();
        }

        public void AddCustomer(Customer cus)
        {
            this.unitOfWork.CustomerRepository.Insert(cus);
            this.unitOfWork.SaveChanges();
        }

        public void DeleteCustomer(Customer cus)
        {
            this.unitOfWork.CustomerRepository.Delete(cus);
            this.unitOfWork.SaveChanges();
        }
    }
}
