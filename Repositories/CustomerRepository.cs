using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(FuminiHotelManagementContext context) : base(context)
        {
        }
        public bool AdminLogin(string email, string password)
        {
            return this.context.IsAdmin(email, password);
        }
    }
}
