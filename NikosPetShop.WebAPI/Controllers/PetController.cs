using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Pet> GetAllPets()
        {
            return _petService.GetPets();
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return _petService.FindPetById(id);
        }

        // POST api/<PetController>
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petService.CreatePet(pet);
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            var petUpdate = pet;
            petUpdate.Id = id;
            _petService.UpdatePet(petUpdate);
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
