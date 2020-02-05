using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    [Table("Comments")]
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
