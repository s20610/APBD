using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie7.DTO.Response;

namespace Cwiczenie7.Service
{
    public interface IDBService
    {
        public Task<List<TripResponseDTO>> GetTripsFromDB();
        public Task<string> DeleteClientFromDB(int id);

        public Task<string> AddClientToTrip(int id);
    }
}
