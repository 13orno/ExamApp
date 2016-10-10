
using System.Collections.Generic;

namespace SeliseExamApp.Core.DTO
{
    public class StudentCreateItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Roll { get; set; }

        public List<int> CoursesList { get; set; }
    }
}
