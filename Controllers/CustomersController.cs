using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceHub.Api.Models;
using ServiceHub.Api.Services;

namespace ServiceHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
        {
            var customers = await _customerService.GetAllAsync();

            return Ok(customers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Customer>> GetById(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            var createdCustomer = await _customerService.CreateAsync(customer);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdCustomer.Id },
                createdCustomer);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var existingCustomer = await _customerService.GetByIdAsync(id);

            if (existingCustomer is null)
            {
                return NotFound();
            }

            await _customerService.UpdateAsync(customer);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingCustomer = await _customerService.GetByIdAsync(id);

            if (existingCustomer is null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(id);

            return NoContent();
        }
    }
}
