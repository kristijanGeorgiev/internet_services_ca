using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;

        }

        public async Task<Client?> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return null;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return client;
        }


        public async Task<IEnumerable<Client>> GetAllAsync()
        {
           
            return await _context.Clients.Include(c => c.Cars).ToListAsync();
        }


        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Client updatedClient)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            client.Id = updatedClient.Id;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
