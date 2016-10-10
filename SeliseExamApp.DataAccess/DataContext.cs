using SeliseExamApp.DataAccess.DomainObjects;
using System.Data.Entity;

namespace SeliseExamApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext() : base("SchoolContext")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }
    }
}
