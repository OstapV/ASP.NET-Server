using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPZ_LAB_3.Repository.Models;
using KPZ_LAB_3.ViewModels;

namespace KPZ_LAB_3.Repository
{
    public interface IJewelryStoreRepository
    {
        public Task AddCustomer(CreateCustomerViewModel customer);
        public Task DeleteCustomer(int customerId);
        public Task UpdateCustomer(UpdateCustomerViewModel customer);
        public Task<Customer> GetCustomer(int customerId);
        public Task<IEnumerable<Customer>> GetCustomers();
    }
}
