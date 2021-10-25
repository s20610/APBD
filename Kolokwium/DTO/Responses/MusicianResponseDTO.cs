namespace Kolokwium.DTO.Responses
{
    public class MusicianResponseDTO
    {
        public int IdMusician { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Nickname { get; set; }
        public TrackResponseDTO[] tracks { get; set; }
    }
}