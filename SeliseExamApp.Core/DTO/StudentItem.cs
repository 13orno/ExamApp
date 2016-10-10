using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeliseExamApp.Core.DTO
{
    public class StudentItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Roll { get; set; }

        public string Address { get; set; }

        public bool IsDelete { get; set; }

        public List<CourseItem> CourseItems { get; set; }
    }
}
