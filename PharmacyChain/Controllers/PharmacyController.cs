using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PharmacyChain.Dtos;
using PharmacyChain.Models;
using PharmacyChain.Repository.IRepository;

namespace PharmacyChain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyRepo _repository;
        private readonly IMapper _mapper;
       

        public PharmacyController(IPharmacyRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/Pharmacy
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var pharmacyList = await _repository.GetAll();
            if (pharmacyList == null)
                return NotFound();
            return Ok(pharmacyList);
        }
        // GET /api/Pharmacy/5
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            var pharmacyFromRepo = await _repository.GetById(id);
            if (pharmacyFromRepo == null)
                return NotFound();

            return Ok(pharmacyFromRepo);
        }

        //POST /api/Pharmacy
        [HttpPost]
        public async Task<IActionResult> Create(PharmacyCreateDto pharmacyCreateDto)
        {
            
            var pharmacy = _mapper.Map<Pharmacy>(pharmacyCreateDto);
            await _repository.Create(pharmacy);
            await _repository.Save();
            return CreatedAtAction(nameof(GetById), new { id = pharmacy.PharmacyId }, pharmacy);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateRange(IEnumerable<Pharmacy> pharmacyList)
        //{

        //    await _repository.AddRangeAsync(pharmacyList);
        //    await _repository.SaveChangesAsync();
        //    return Ok();
        //}

        //PUT /api/Pharmac/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(PharmacyUpdateDto pharmacyUpdateDto,int id)
        {
            var pharmacyFromRepo = await _repository.GetById(id);
            if (pharmacyFromRepo == null)
                return NotFound();

            _mapper.Map(pharmacyUpdateDto, pharmacyFromRepo);
            await _repository.Update(pharmacyFromRepo);
            await _repository.Save();
            return NoContent();
        }

        //DELETE /api/Pharmacy/5
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

        //PATCH /api/Pharmacy/5s
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id,JsonPatchDocument<PharmacyCreateDto> jsonPatchDocument)
        {
            var entityFromDb = await _repository.GetById(id);
            if (entityFromDb == null)
                return NotFound();

            var entityToPatch = _mapper.Map<PharmacyCreateDto>(entityFromDb);
            jsonPatchDocument.ApplyTo(entityToPatch);

            if (!TryValidateModel(entityToPatch))
                return ValidationProblem();

            _mapper.Map(entityToPatch, entityFromDb);
            await _repository.Update(entityFromDb);
            await _repository.Save();

            return NoContent();
        }
    }
}
