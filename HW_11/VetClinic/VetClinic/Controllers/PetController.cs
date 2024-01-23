using VetClinic.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetClinic.Models.Requests;
using VetClinic.Models;
using VetClinic.Services;

namespace VetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        private IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreatePetRequest createRequest)
        {
            Pet pet = new Pet();
            pet.ClientId = createRequest.ClientID;
            pet.Name = createRequest.Name;
            pet.Birthday = createRequest.Birthday;
            return Ok(_petRepository.Create(pet));
        }

        [HttpPut("edit")]
        public IActionResult Update([FromBody] UpdatePetRequest updateRequest)
        {
            Pet pet = new Pet();
            pet.ClientId = updateRequest.ClientID;
            pet.Name = updateRequest.Name;
            pet.Birthday = updateRequest.Birthday;
            return Ok(_petRepository.Update(pet));
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int petID)
        {
            int res = _petRepository.Delete(petID);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpGet("get/{petID}")]
        public IActionResult GetById([FromRoute] int petID)
        {
            return Ok(_petRepository.GetById(petID));
        }

    }
}
