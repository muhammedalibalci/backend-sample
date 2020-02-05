
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    [Table("Posts")]
    public class Post :  IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int Rank { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
