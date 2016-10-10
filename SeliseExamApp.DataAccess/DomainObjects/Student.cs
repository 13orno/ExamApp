using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeliseExamApp.DataAccess.DomainObjects
{
    [Table("Student")]
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        public int StudentId { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(20)]
        [Required]
        public string Roll { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
