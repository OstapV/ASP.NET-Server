using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPZ_LAB_3.Repository;
using KPZ_LAB_3.Repository.Models;
using KPZ_LAB_3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KPZ_LAB_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly IJewelryStoreRepository _jewelryStoreRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jewelryStoreRepository"></param>
        public CustomerController(IJewelryStoreRepository jewelryStoreRepository)
        {
            _jewelryStoreRepository = jewelryStoreRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _jewelryStoreRepository.GetCustomers();
        }

        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Customer> Get(int customerId)
        {
            return await _jewelryStoreRepository.GetCustomer(customerId);
        }

        /// <remarks>
        ///     Sample request:
        ///     
        ///      POST
        ///      {
        ///        "username": "Example",
        ///        "email": "example@gmail.com",
        ///        "password": "example"
        ///      }
        /// </remarks>
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post([FromBody]CreateCustomerViewModel customerViewModel)
        {
            await _jewelryStoreRepository.AddCustomer(customerViewModel);
        }

        /// <remarks>
        ///     Sample request:
        ///     
        ///      PUT
        ///      {
        ///        "username": "Example",
        ///        "email": "example@gmail.com",
        ///        "password": "example"
        ///      }
        /// </remarks>
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateCustomer"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Put(int id, [FromBody]UpdateCustomerViewModel updateCustomer)
        {
            //if (updateCustomer == null || updateCustomer.Id != id)
            //    throw new ArgumentException();

            await _jewelryStoreRepository.UpdateCustomer(updateCustomer);
        }

    
        /// <summary>
        /// Delete specific customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _jewelryStoreRepository.DeleteCustomer(id);
        }

    }
}
