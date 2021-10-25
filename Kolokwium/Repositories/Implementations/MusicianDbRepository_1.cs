using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DTO.Requests;
using Kolokwium.DTO.Responses;
using Kolokwium.Models;
using Kolokwium.Repositories.Interfaces;
using Kolokwium.Status;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Repositories.Implementations
{
    public class MusicianDbRepository : IMusicianDbRepository
    {
        private readonly DataBaseContext _context;

        public MusicianDbRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<MusicianResponseDTO> GetMusician(int idMusician)
        {
            var findMusician = await _context.Musician.AnyAsync(o => o.IdMusician == idMusician);
            if (!findMusician)
                return null;
            
            var trackList = await _context.MusicianTrack.Where(eo => eo.IdMusician == idMusician)
                .Include(eo => eo.IdTrackNavigation)
                .Select(e => new TrackResponseDTO()
                {
                    IdTrack = e.IdTrackNavigation.IdTrack,
                    TrackName = e.IdTrackNavigation.TrackName,
                    Duration = e.IdTrackNavigation.Duration,
                }).ToArrayAsync();
            
            var musician = await _context.Musician.Where(o => o.IdMusician == idMusician)
                .Select(o => new MusicianResponseDTO
                {
                    IdMusician = o.IdMusician,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Nickname = o.Nickname,
                    tracks = trackList
                }).FirstAsync();
            
            return musician;
        }

        public async Task<Status.Status> PostMusician(MusicianRequestDTO musician)
        {
            var code = 0;
            var message = "";
            
            var findMusician = await _context.Musician.SingleOrDefaultAsync(d => d.FirstName == musician.FirstName && d.LastName == musician.LastName);
            if (findMusician == null)
            {
                code = 400;
                message = "Artist already exists!";
            }
            else
            {
                var findTrack = await _context.Track.SingleOrDefaultAsync(d => d.TrackName == musician.TrackName);
                if (findTrack == null)
                {
                    await _context.Track.AddAsync(new Track
                    {
                        TrackName = musician.TrackName,
                        Duration = musician.Duration
                    });
                    await _context.SaveChangesAsync();
                }

                var track = await _context.Track.Where(x => x.TrackName == musician.TrackName).Select(x => x.IdTrack)
                    .SingleOrDefaultAsync();

                    await _context.Musician.AddAsync(new Musician
                {
                    FirstName = musician.FirstName,
                    LastName = musician.LastName,
                    Nickname = musician.Nickname
                });
                
                await _context.MusicianTrack.AddAsync(new MusicianTrack
                {
                    IdMusician =_context.Musician.Max(x => x.IdMusician),
                    IdTrack = track
                });

                
                await _context.SaveChangesAsync();

            }

            
            var answer = new Status.Status
            {
                Code = code,
                Message = message
            };

            return answer;
        }

    }
}