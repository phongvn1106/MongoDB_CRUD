using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB_CRUD.Models;
using MongoDB_CRUD.Repository;
using MongoDB_CRUD.Services;

namespace MongoDB_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUserRepository _userRepository;
        public CustomerController(ICustomerService customerService, IUserRepository userRepository)
        {
            _customerService = customerService;
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync().ConfigureAwait(false));
        }

        [HttpGet("xxx")]
        public async Task<IActionResult> xxx()
        {
            var table = nameof(MongoDB_CRUD.Models.User);
            return Ok(await _userRepository.GetAll(table));
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _customerService.CreateAsync(customer).ConfigureAwait(false);
            await _userRepository.AddAsync(new User
            {
                FirstName = customer.FirstName,
                Password = "1234567"
            });
            return Ok(customer.Id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Customer customerIn)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.UpdateAsync(id, customerIn).ConfigureAwait(false);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetByIdAsync(id).ConfigureAwait(false);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteAsync(customer.Id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
