using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBConApp1.Models
{
    public class CreateRequest 
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required]
        [Range(18, 100, ErrorMessage = "You should be elder than 18")]
        public DateTime Birthdate { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public string Phone { get; set; }
        
        [Required]
        [ForeignKey("Id")]
        public Guid MentorId { get; set; }
        
        [Obsolete("Used only for Entity binding.")]
        public CreateRequest() { }

        public CreateRequest(Guid id, string firstname, string lastname, DateTime birthdate, string email, string phone, Guid mentorId)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Birthdate = birthdate;
            Email = email;
            Phone = phone;
            MentorId = mentorId;
        }
    }
}