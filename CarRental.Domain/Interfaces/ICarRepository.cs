using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> AddAsync(Car car);
        Task<bool> UpdateAsync(int id, Car car);
        Task<Car> DeleteAsync(int id);

    }
}
