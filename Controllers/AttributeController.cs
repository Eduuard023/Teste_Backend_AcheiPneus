using Microsoft.AspNetCore.Mvc;
using ApiAchei.Models;
using ApiAchei.Repositories;

namespace ApiAchei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeController(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Attribute>>> GetAttributes()
        {
            var attributes = await _attributeRepository.GetAllAsync();
            return Ok(attributes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Attribute>> GetAttribute(int id)
        {
            var attribute = await _attributeRepository.GetByIdAsync(id);
            if (attribute == null) return NotFound();
            return Ok(attribute);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Attribute>> CreateAttribute(Models.Attribute attribute)
        {
            await _attributeRepository.AddAsync(attribute);
            return CreatedAtAction(nameof(GetAttribute), new { id = attribute.Id }, attribute);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttribute(int id, Models.Attribute attribute)
        {
            if (id != attribute.Id) return BadRequest();
            await _attributeRepository.UpdateAsync(attribute);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            await _attributeRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
