using System.ComponentModel.DataAnnotations;

namespace Kolokwium.DTO.Requests
{
    public class MusicianRequestDTO
    {
        [Required(ErrorMessage = "First name is required!")]
        [MaxLength(30, ErrorMessage = "Text is over 30 characters long!")]
        public string FirstName{ get; set; }
        
        [Required(ErrorMessage = "Last name is required!")]
        [MaxLength(50, ErrorMessage = "Text is over 50 characters long!")]
        public string LastName{ get; set; }
        
        [MaxLength(20, ErrorMessage = "Text is over 20 characters long!")]
        public string Nickname { get; set; }
        
        [MaxLength(20, ErrorMessage = "Text is over 20 characters long!")] 
        public string TrackName { get; set; }
        
        public float Duration  { get; set; }
    }
}