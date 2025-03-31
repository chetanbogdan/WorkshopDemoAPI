using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WorkshopDemoAPI.Data;
using WorkshopDemoAPI.Entities;

namespace WorkshopDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(WorkshopDemoDbContext context, IValidator<Country> countryValidator) : ControllerBase
    {
        private readonly WorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IValidator<Country> _countryValidator = countryValidator ?? throw new ArgumentNullException(nameof(countryValidator));

        [HttpGet]
        public ActionResult<List<Country>> GetCountries()
        {
            var countries = _context.Countries.ToList();
            
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public ActionResult<Country> GetCountryById(Guid id)
        {
            var country = _context.Countries.Find(id);

            if (country is null)
            {
                return NotFound("Country not found");
            }
            
            return Ok(country);
        }

        [HttpPost]
        public ActionResult AddCountry(Country country)
        {
            var validationResult = _countryValidator.Validate(country);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            country.Id = Guid.NewGuid();
            _context.Countries.Add(country);
            _context.SaveChanges();

            return Ok(country);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(Guid id, Country country)
        {
            var validationResult = _countryValidator.Validate(country);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            
            var countryToUpdate = _context.Countries.Find(id);

            if (countryToUpdate is null)
            {
                return NotFound($"Country with id {id} was not found");
            }
            
            countryToUpdate.Name = country.Name;
            countryToUpdate.IsoCountryCode = country.IsoCountryCode;
            _context.Countries.Update(countryToUpdate);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(Guid id)
        {
            var countryToDelete = _context.Countries.Find(id);

            if (countryToDelete is null)
            {
                return NotFound($"Country with id {id} was not found");
            }
            
            _context.Countries.Remove(countryToDelete);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
