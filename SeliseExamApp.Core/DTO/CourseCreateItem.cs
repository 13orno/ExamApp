
using System.Collections.Generic;

namespace SeliseExamApp.Core.DTO
{
    public class CourseCreateItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<int> StudentList { get; set; }
    }
}
