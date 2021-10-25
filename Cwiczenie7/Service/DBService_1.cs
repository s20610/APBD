using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie7.DTO.Response;
using Cwiczenie7.Models;

namespace Cwiczenie7.Service
{
    public class DBService : IDBService
    {
        private readonly S20610Context _s20610Context;
        public DBService(S20610Context s20610Context)
        {
            _s20610Context = s20610Context;
        }

        public async Task<string> AddClientToTrip(int id)
        {
            var isClient = await _s20610Context.Clients.AnyAsync(r => r.IdClient == id);
            if(isClient == false)
            {
                _s20610Context.AddAsync(new Client
                {

                }) ;
            }
            return null;
        }

        public async Task<string> DeleteClientFromDB(int id)
        {
            bool result = await _s20610Context.ClientTrips
                                                .AnyAsync(r => r.IdClient == id);
            if (result)
            {
                return "Error";
            }
            else
            {
                var Client = await _s20610Context.Clients.Where(r => r.IdClient == id).FirstAsync();
                _s20610Context.Remove(Client);
                _s20610Context.SaveChangesAsync();
    
            }
            return null;
        }

        public async Task<List<TripResponseDTO>> GetTripsFromDB()
        {
            var result = await _s20610Context.Trips
                                            .Include(r => r.ClientTrips).ThenInclude(r => r.IdClientNavigation)
                                            .Include(r => r.CountryTrips).ThenInclude(r => r.IdCountryNavigation)
                                            .ToListAsync();

            List<TripResponseDTO> list = new List<TripResponseDTO>() ;

            foreach(var trip in result)
            {
                list.Add(new TripResponseDTO
                {
                    Name = trip.Name,
                    Description = trip.Description,
                    DateFrom = trip.DateFrom,
                    DateTo = trip.DateTo,
                    MaxPeople = trip.MaxPeople,
                    Countries = trip.CountryTrips.Select(r => new CountryResponseDTO
                    {
                        Name = r.IdCountryNavigation.Name
                    }).ToList(),
                    Clients = trip.ClientTrips.Select(r => new ClientResponseDTO
                    {
                        FristName = r.IdClientNavigation.FirstName,
                        LastName = r.IdClientNavigation.LastName
                    }).ToList()
                }) ;
            }
            return list.OrderByDescending(r => r.DateFrom).ToList();
        }
    }
}
