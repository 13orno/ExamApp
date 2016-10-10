
using System.Collections.Generic;

namespace SeliseExamApp.Core.DTO
{
    public class CourseItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsDelete { get; set; }

        public List<StudentItem> StudentItems { get; set; }
    }
}
