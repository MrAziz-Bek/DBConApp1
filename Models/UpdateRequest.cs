using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBConApp1.Models
{
    public class UpdateRequest
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

        // treat empty string as null for password fields to 
        // make them optional in front end apps
        private string _id;
        [MinLength(6)]
        public string Password
        {
            get => _id;
            set => _id = replaceEmptyWithNull(value);
        }

        private string _mentorid;
        [Compare("MentorId")]
        public string ConfirmPassword 
        {
            get => _mentorid;
            set => _mentorid = replaceEmptyWithNull(value);
        }

        // helpers

        private string replaceEmptyWithNull(string value)
        {
            // replace empty string with null to make field optional
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}