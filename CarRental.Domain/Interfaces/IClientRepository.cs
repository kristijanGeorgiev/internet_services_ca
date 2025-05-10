using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> AddAsync(Client car);
        Task<bool> UpdateAsync(int id, Client client);
        Task<Client> DeleteAsync(int id);

    }
}
