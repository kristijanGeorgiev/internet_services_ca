using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car> AddAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;

        }

        public async Task<Car?> DeleteAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return null;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }


        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Car updatedCar)
        {
          
            var existingCar = await _context.Cars.FindAsync(id);
            if (existingCar == null)
            {
                return false; 
            }

          
            _context.Entry(existingCar).CurrentValues.SetValues(updatedCar); 

         
            var result = await _context.SaveChangesAsync();
            return result > 0; 
        }



    }
}
