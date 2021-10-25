using System.Threading.Tasks;
using Kolokwium.DTO.Requests;
using Kolokwium.DTO.Responses;
using Kolokwium.Status;

namespace Kolokwium.Repositories.Interfaces
{
    public interface IMusicianDbRepository
    {
        Task<MusicianResponseDTO> GetMusician(int idMusician);
        Task<Status.Status> PostMusician(MusicianRequestDTO musician);
    }
}