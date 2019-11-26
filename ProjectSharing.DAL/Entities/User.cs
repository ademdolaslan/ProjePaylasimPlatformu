using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectSharing.DAL.Entities
{
    public class User
    {
        [Key]
        [Required]
        public string UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public byte[] Picture { get; set; }        
        public string Tel { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public bool IsBanned { get; set; }
        public string UserType { get; set; }


        public ICollection<Page> Pages { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<File> File { get; set; }
    }
}
