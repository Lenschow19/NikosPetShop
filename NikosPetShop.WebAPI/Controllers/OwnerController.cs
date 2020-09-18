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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> GetAllOwners([FromQuery] Filter filter)
        {
            try { 
            return _ownerService.GetOwnersWithFilter(filter);
            }
            catch
            {
                return StatusCode(500, "An error occured while loading all owners.");
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            Owner owner = _ownerService.GetOwnerById(id);
            if (owner != null)
            {
                return Ok(owner);
            }
            return NotFound("Entered ID doesn't match a Owner.");
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("Please provide a Firstname for the owner");
            }
            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("Please provide a Lastname for the owner");
            }
            if (string.IsNullOrEmpty(owner.Address))
            {
                return BadRequest("Please provide the owner with an address.");
            }
            if (string.IsNullOrEmpty(owner.Email))
            {
                return BadRequest("Please add an email, so we can get in contact with you.");
            }
            if (string.IsNullOrEmpty(owner.PhoneNumber))
            {
                return BadRequest("Please provide us with a Phonenumber, so we can get in contact with you.");
            }
            return _ownerService.CreateOwner(owner);
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("Owner missing a FirstName.");
            }
            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("Owner missing a LastName.");
            }
            if (string.IsNullOrEmpty(owner.PhoneNumber))
            {
                return BadRequest("Please enter a PhoneNumber.");
            }
            var ownerUpdate = owner;
            ownerUpdate.Id = id;
            return Accepted(_ownerService.UpdateOwner(owner, id));
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            Owner owner = _ownerService.GetOwnerById(id);
            if (owner != null)
            {
                return Ok(_ownerService.DeleteOwner(id));
            }
            return StatusCode(500, "An error occured while attempting to delete owner.");
        }
    }
}
