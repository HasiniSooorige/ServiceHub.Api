using ServiceHub.Api.Models;
using ServiceHub.Api.Repositories;

namespace ServiceHub.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            return await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}