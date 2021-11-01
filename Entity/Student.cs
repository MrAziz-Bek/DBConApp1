using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace DBConApp1.Entity
{
    public class Student
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
        
        [ForeignKey("Id")]
        public Guid MentorId { get; set; }
        
        [Obsolete("Used only for Entity binding.")]
        public Student() { }

        public Student(Guid id, string firstname, string lastname, DateTime birthdate, string email, string phone, Guid mentorId)
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