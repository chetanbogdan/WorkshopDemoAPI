using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopDemoAPI.Data;
using WorkshopDemoAPI.Entities;
using WorkshopDemoAPI.Filters;

namespace WorkshopDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SynchronousAttributeCustomFilter("CountriesController")]
    public class CountriesController(WorkshopDemoDbContext context, IValidator<Country> countryValidator) : ControllerBase
    {
        private readonly WorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IValidator<Country> _countryValidator = countryValidator ?? throw new ArgumentNullException(nameof(countryValidator));

        [HttpGet]
        [AsynchronousAttributeCustomFilter("GetCountries")]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(Guid id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country is null)
            {
                return NotFound("Country not found");
            }
            
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult> AddCountry(Country country)
        {
            var validationResult = await _countryValidator.ValidateAsync(country);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            country.Id = Guid.NewGuid();
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(Guid id, Country country)
        {
            var validationResult = await _countryValidator.ValidateAsync(country);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            var countryToUpdate = await _context.Countries.FindAsync(id);

            if (countryToUpdate is null)
            {
                return NotFound($"Country with id {id} was not found");
            }
            
            countryToUpdate.Name = country.Name;
            countryToUpdate.IsoCountryCode = country.IsoCountryCode;
            _context.Countries.Update(countryToUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            var countryToDelete = await _context.Countries.FindAsync(id);

            if (countryToDelete is null)
            {
                return NotFound($"Country with id {id} was not found");
            }
            
            _context.Countries.Remove(countryToDelete);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
