using CarRental.Application.DTOs;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllAsync();
    Task<CarDto?> GetByIdAsync(int id);
    Task<CarDto> CreateAsync(CarDto carDto);
    Task<bool> UpdateAsync(int id, CarDto carDto);
    Task<CarDto?> DeleteAsync(int id);
}
