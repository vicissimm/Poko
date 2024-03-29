﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokReview.DTO;
using PokReview.Interfaces;
using PokReview.Models;
using PokReview.Repository;

namespace PokReview.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {

        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;
        public CountryController(ICountryRepository countryRepository,IMapper mapper)
        {
            this.mapper = mapper;
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = mapper.Map<List<CountryDTO>>(countryRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!countryRepository.CountryExists(countryId))
                return NotFound();

            var country = mapper.Map<CountryDTO>(countryRepository.GetCountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = mapper.Map<CountryDTO>(
                countryRepository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }
    }
}
