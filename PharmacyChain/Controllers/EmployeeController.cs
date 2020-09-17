using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PharmacyChain.Contract;
using PharmacyChain.DTOs;
using PharmacyChain.Models;

namespace PharmacyChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;
      
        public EmployeeController(IEmployeeRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/Employee
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfEmployees = await _repository.GetAll();
            if (listOfEmployees == null)
                return NotFound();
            return Ok(listOfEmployees);
        }

        //GET /api/Employee/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeFromRepo = await _repository.GetById(id);
            if (employeeFromRepo == null)
                return NotFound();

            return Ok(employeeFromRepo);
        }

        //GET /api/Employee/lastName
        [HttpGet("lastName={lastName}")]
        public async Task<IActionResult> GetByLastName(string lastName)
        {
            var employeeWithLastName = await _repository.GetEmployeesByLastName(lastName);
            if (employeeWithLastName == null)
                return NotFound();
            return Ok(employeeWithLastName);
        }

        //POST /api/Employee
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDto employeeCreateDto)
        {
            var employee = _mapper.Map<Employee>(employeeCreateDto);
            await _repository.Create(employee);
            await _repository.Save();
            return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeId }, employee);
        }
    
        //PUT /api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(EmployeeUpdateDto employee, int id)
        {
            var employeeFromRepo = await _repository.GetById(id);
            if (employeeFromRepo == null)
                return NotFound();

            _mapper.Map(employee, employeeFromRepo);
            await _repository.Update(employeeFromRepo);
            await _repository.Save();
            return NoContent();
        }

        //DELETE /api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var entityToDelete = await _repository.GetById(id);
            if (entityToDelete == null)
                return NotFound();
            await _repository.Remove(entityToDelete);
            await _repository.Save();
            return NoContent();
        }

        //PATCH /api/Employee/5s
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<EmployeePatchDto> jsonPatchDocument)
        {
            var entityFromDb = await _repository.GetById(id);
            if (entityFromDb == null)
                return NotFound();

            var entityToPatch = _mapper.Map<EmployeePatchDto>(entityFromDb);
            jsonPatchDocument.ApplyTo(entityToPatch,ModelState);

            if (!TryValidateModel(entityToPatch))
                return ValidationProblem();

            _mapper.Map(entityToPatch, entityFromDb);
            await _repository.Update(entityFromDb);
            await _repository.Save();
            return NoContent();
        }
    }
}