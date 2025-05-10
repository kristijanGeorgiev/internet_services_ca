using AutoMapper;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace CarRental.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDto>> GetAllAsync()
        {
            var cars = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public async Task<CarDto?> GetByIdAsync(int id)
        {
            var car = await _repository.GetByIdAsync(id);
            return _mapper.Map<CarDto>(car);
        }

        public async Task<CarDto> CreateAsync(CarDto carDto)
        {
            // Remove dependency on IClientRepository
            if (carDto.ClientId <= 0)  // Assuming ClientId must be a positive integer
            {
                throw new Exception("Invalid ClientId for the car.");
            }

            var car = _mapper.Map<Car>(carDto);
            // Set the clientId directly in the car entity
            car.client = null;  // We don't fetch the client anymore, just set the clientId as part of the car

            var createdCar = await _repository.AddAsync(car);
            return _mapper.Map<CarDto>(createdCar);
        }

        public async Task<bool> UpdateAsync(int id, CarDto carDto)
        {
            var existingCar = await _repository.GetByIdAsync(id);
            if (existingCar == null)
            {
                return false;
            }

            // Map the CarDto to the existing Car entity
            _mapper.Map(carDto, existingCar);
            // Set the clientId in the car entity directly
            existingCar.client = null;  // No need to fetch the client, just set the ClientId
            existingCar.ClientId = carDto.ClientId;

            await _repository.UpdateAsync(id, existingCar);

            return true;
        }

        public async Task<CarDto?> DeleteAsync(int id)
        {
            var car = await _repository.DeleteAsync(id);
            return _mapper.Map<CarDto>(car);
        }
    }
}
