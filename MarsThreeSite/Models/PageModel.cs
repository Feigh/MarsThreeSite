using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarsThreeSite.Models
{
    public class Tags
    {
        [Key]
        [Column("Id", TypeName = "integer")]
        public int TagId { get; set; }
        [Required]
        [Column("Name")]
        public string TagName { get; set; }
    }
    public class PageTags
    {
        [ForeignKey("TagId")]
        public Tags Tags_Id { get; set; }
        [ForeignKey("PageId")]
        public PageModel Pages_Id { get; set; }
    }
    [Table("Chapiters")]
    public class ChapiterData
    {
        [Key]
        [Column("Id", TypeName="integer")]
        public int ChapiterId { get; set; }
        [Required]
        [Column("Number", TypeName = "integer")]
        public int ChapiterNumber { get; set; }
        [Column("Name")]
        public string ChapiterName { get; set; }
        [Required]
        public bool isDeleted { get; set; }
    }
    [Table("Pages")]
    public class PageModel
    {
        [Key]
        [Column("Id", TypeName = "integer")]
        public int PageId { get; set; }
        [Column("Number", TypeName = "integer")]
        public int PageNumber { get; set; }
        [Column("Name")]
        public string PageName { get; set; }
        [Required]
        [Column("Address")]
        public string PageAddress { get; set; }
        [Required]
        public DateTime Published { get; set; }
        [ForeignKey("ChapiterId")]
        public ChapiterData Chapiter_Id { get; set; }
        [Required]
        public bool isDeleted { get; set; }
    }
}
