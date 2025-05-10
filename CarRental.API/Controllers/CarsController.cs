using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CarDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest();
            }

            var createdCar = await _carService.CreateAsync(carDto);
            return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);  // Return CarDto
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarDto carDto)  // Take CarDto as input
        {
            if (carDto == null)
            {
                return BadRequest();
            }

          
            carDto.Id = id;

            
            var success = await _carService.UpdateAsync(id, carDto);
            if (!success)
            {
                return NotFound(new { message = "Car not found for update." });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carService.DeleteAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
