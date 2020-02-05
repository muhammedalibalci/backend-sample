using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    [Table("PostComment")]
    public class PostComment :  IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
    }
}
