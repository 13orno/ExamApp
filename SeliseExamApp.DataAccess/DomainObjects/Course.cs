using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeliseExamApp.DataAccess.DomainObjects
{
    [Table("Course")]
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }
        [Key]
        public int CourseId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
