using SeliseExamApp.Core.DTO;
using SeliseExamApp.Core.Interfaces;
using SeliseExamApp.Core.Repository;
using SeliseExamApp.DataAccess.DomainObjects;
using System.Collections.Generic;

namespace SeliseExamApp.Core.Service
{
    public class StudentService : IService<StudentItem, StudentCreateItem>
    {
        private readonly UnitOfWork unit = new UnitOfWork();
        public List<StudentItem> GetAll()
        {
            var lstStudent = new List<Student>();
            var lstStudentItem = new List<StudentItem>();
            
            lstStudent = unit.StudentRepository.GetAll();
            
            foreach (var item in lstStudent)
            {
                var studentItem = new StudentItem()
                {
                    Id = item.StudentId,
                    Name = item.Name,
                    Roll = item.Roll,
                    Email = item.Email,
                    Address = item.Address,
                    IsDelete = item.IsDelete
                };
                lstStudentItem.Add(studentItem);
            }
            return lstStudentItem;
        }

        public void Save(StudentCreateItem studentCreateItem)
        {
            var student = new Student()
            {
                StudentId = studentCreateItem.Id,
                Name = studentCreateItem.Name,
                Roll = studentCreateItem.Roll,
                Email = studentCreateItem.Email
            };
            
            foreach (var item in studentCreateItem.CoursesList)
            {
                var course = new Course();

                {
                    course = unit.CourseRepository.Find(item);
                }
                student.Courses.Add(course);
            }

            unit.StudentRepository.InsertOrUpdate(student);
            unit.StudentRepository.Save();
        }

        public void Delete(int id)
        {
            unit.StudentRepository.Delete(id);
        }

        public StudentItem Find(int id)
        {
            var student = new Student();
            student = unit.StudentRepository.Find(id);

            var studentItem = new StudentItem()
            {
                Id = student.StudentId,
                Name = student.Name,
                Roll = student.Roll,
                Email = student.Email,
                Address = student.Address,
                CourseItems = new List<CourseItem>()
            };
            foreach (var item in student.Courses)
            {
                var courseItem = new CourseItem()
                {
                    Id= item.CourseId,
                    Code = item.Code,
                    Name = item.Name
                };
                studentItem.CourseItems.Add(courseItem);
            }
            return studentItem;
        }
    }
}
