using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopDemoAPI.Application.Countries;
using WorkshopDemoAPI.Application.Countries.CreateCountry;
using WorkshopDemoAPI.Application.Countries.ListCountries;
using WorkshopDemoAPI.DAL;
using WorkshopDemoAPI.DAL.Entities;

namespace WorkshopDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(WorkshopDemoDbContext context, IValidator<CountryDto> countryValidator, IMediator mediator) : ControllerBase
    {
        // private readonly WorkshopDemoDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IValidator<CountryDto> _countryValidator = countryValidator ?? throw new ArgumentNullException(nameof(countryValidator));
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            var countries = await _mediator.Send(new ListCountriesQuery());
            
            return Ok(countries);
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Country>> GetCountryById(Guid id)
        // {
        //     var country = await _context.Countries.FindAsync(id);
        //
        //     if (country is null)
        //     {
        //         return NotFound("Country not found");
        //     }
        //     
        //     return Ok(country);
        // }

        [HttpPost]
        public async Task<ActionResult> AddCountry(CountryDto country)
        {
            var validationResult = await _countryValidator.ValidateAsync(country);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var countryDto = await _mediator.Send(new CreateCountryCommand(country.Name, country.IsoCountryCode));

            return Ok(countryDto);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateCountry(Guid id, CountryDto country)
        // {
        //     var validationResult = await _countryValidator.ValidateAsync(country);
        //
        //     if (!validationResult.IsValid)
        //     {
        //         return BadRequest(validationResult.Errors);
        //     }
        //     
        //     var countryToUpdate = await _context.Countries.FindAsync(id);
        //
        //     if (countryToUpdate is null)
        //     {
        //         return NotFound($"Country with id {id} was not found");
        //     }
        //     
        //     countryToUpdate.Name = country.Name;
        //     countryToUpdate.IsoCountryCode = country.IsoCountryCode;
        //     _context.Countries.Update(countryToUpdate);
        //     await _context.SaveChangesAsync();
        //
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCountry(Guid id)
        // {
        //     var countryToDelete = await _context.Countries.FindAsync(id);
        //
        //     if (countryToDelete is null)
        //     {
        //         return NotFound($"Country with id {id} was not found");
        //     }
        //     
        //     _context.Countries.Remove(countryToDelete);
        //     await _context.SaveChangesAsync();
        //     
        //     return NoContent();
        // }
    }
}
