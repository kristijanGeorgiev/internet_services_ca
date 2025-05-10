using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Client> CreateAsync(Client client)
        {
            return await _repository.AddAsync(client);
        }

        public async Task<bool> UpdateAsync(int id, Client client)
        {
            return await _repository.UpdateAsync(id, client);
        }

        public async Task<Client?> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}