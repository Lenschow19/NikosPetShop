using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikosPetShop.Core.ApplicationServices;
using NikosPetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikosPetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/<PetController>
        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult<IEnumerable<Pet>> GetAllPets([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.GetPetsWithFilter(filter));
            }
            catch
            {
                return StatusCode(500, "An error occured while loading all pets.");
            }
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            Pet pet = _petService.FindPetById(id);
            if (pet != null)
            {
                return Ok(pet);
            }
            return NotFound("Entered ID doesn't match a Pet.");
        }

        // POST api/<PetController>
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("The Pet needs a name.");
            }
            if (string.IsNullOrEmpty(pet.Color))
            {
                return BadRequest("Please specify the look of the Pet.");
            }

            return Created("",_petService.CreatePet(pet));
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if(string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("The Pet needs a name.");
            }
            if (string.IsNullOrEmpty(pet.Color))
            {
                return BadRequest("Please specify the look of the Pet.");
            }
            var petUpdate = pet;
            petUpdate.Id = id;
            return Accepted(_petService.UpdatePet(petUpdate));
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            try
            {
                return Ok(_petService.DeletePet(id));
            }
            catch
            {
                return StatusCode(500, "An error occured while deleting a pet.");
            }
        }
    }
}
