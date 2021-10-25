using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie7.Models;

namespace Cwiczenie7.DTO.Response
{
    public class TripResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public List<CountryResponseDTO> Countries { get; set; }
        public List<ClientResponseDTO> Clients { get; set; }
    }
}
