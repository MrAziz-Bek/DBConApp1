using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace DBConApp1.Entity
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }
        
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Range(18, 100, ErrorMessage = "You should be elder than 18")]
        public DateTime Birthdate { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [Phone]
        public string Phone { get; set; }
        
        [Obsolete("Used only for Entity binding.")]
        public Teacher() { }

        public Teacher(Guid id, string firstname, string lastname, DateTime birthdate, string email, string phone)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Birthdate = birthdate;
            Email = email;
            Phone = phone;
        }
    }
}