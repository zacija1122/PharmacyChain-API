using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyChain.Contract;

namespace PharmacyChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;
      
        public EmployeeController(IEmployeeRepo repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfEmployees = await _repository.GetAll();
            if (listOfEmployees == null)
                return NotFound();
            return Ok(listOfEmployees);
        }

    }
}