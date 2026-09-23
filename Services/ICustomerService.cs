using ServiceHub.Api.Models;

namespace ServiceHub.Api.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer?> GetByIdAsync(Guid id);

        Task<Customer> CreateAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task DeleteAsync(Guid id);
    }
}