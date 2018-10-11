using System;
using System.ComponentModel.DataAnnotations;

namespace MarsThreeSite.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
