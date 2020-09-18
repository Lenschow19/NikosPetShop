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
    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        // GET: api/<PetTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<PetType>> GetAllPetTypes()
        {
            try
            {
                return Ok(_petTypeService.GetAllPetTypes());
            }
            catch
            {
                return StatusCode(500, "An error occured while loading all pettypes.");
            }
        }

        // GET api/<PetTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PetType>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petTypeService.GetPetTypesWithFilter(filter));
            }
            catch
            {
                return StatusCode(500, "An error occured while loading petTypes.");
            }
        }

        // POST api/<PetTypeController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            if (string.IsNullOrEmpty(petType.NameOfPetType))
            {
                return BadRequest("The Pet needs to be specified to be created.");
            }
            PetType typeToAdd = _petTypeService.CreatePetType(petType.NameOfPetType);
            return Created("",_petTypeService.AddPetType(typeToAdd));
        }

        // PUT api/<PetTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            if (string.IsNullOrEmpty(petType.NameOfPetType))
            {
                return BadRequest("The PetType needs to be specified.");
            }
            var petTypeUpdate = petType;
            petTypeUpdate.Id = id;
            return Accepted(_petTypeService.UpdatePetType(petType, id));
        }

        // DELETE api/<PetTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            try
            {
                return Ok(_petTypeService.DeletePetType(id));
            }
            catch
            {
                return StatusCode(500, "An error occured while attempting to delete PetType.");
            }
        }
    }
}
