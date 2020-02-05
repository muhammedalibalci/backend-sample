
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Core.Entities.Concrete

{
    [Table("Users")]
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int DegreeId { get; set; }
        public Degree Degree { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
