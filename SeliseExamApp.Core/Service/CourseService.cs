using SeliseExamApp.Core.DTO;
using SeliseExamApp.Core.Interfaces;
using SeliseExamApp.Core.Repository;
using SeliseExamApp.DataAccess.DomainObjects;
using System.Collections.Generic;

namespace SeliseExamApp.Core.Service
{
    public class CourseService : IService<CourseItem, CourseCreateItem>
    {
        private readonly UnitOfWork unit = new UnitOfWork();

        public CourseItem Create(CourseItem courseItem)
        {
            var course = new Course()
            {
                CourseId = courseItem.Id,
                Name = courseItem.Name,
                Code = courseItem.Code,
                IsDelete = courseItem.IsDelete
            };

            unit.CourseRepository.InsertOrUpdate(course);
            unit.CourseRepository.Save();
            return courseItem;
        }

        public CourseItem Find(int id)
        {
            var course = new Course();
            course = unit.CourseRepository.Find(id);

            var courseItem = new CourseItem()
            {
                Id= course.CourseId,
                Name = course.Name,
                Code =course.Code,
                IsDelete = course.IsDelete
            };

            return courseItem;
        }

        public List<CourseItem> GetAll()
        {
            var lstCourse = new List<Course>();
            lstCourse = unit.CourseRepository.GetAll();

            var lstCourseItem = new List<CourseItem>();
            foreach (var item in lstCourse)
            {
                var courseItem = new CourseItem()
                {
                    Id = item.CourseId,
                    Name = item.Name,
                    Code = item.Code,
                    IsDelete = item.IsDelete,
                    StudentItems = new List<StudentItem>()
                };
                foreach (var student in item.Students)
                {
                    var studentItem = new StudentItem()
                    {
                        Id = student.StudentId,
                        Name = student.Name,
                        Roll = student.Roll,
                        Email = student.Email,
                        Address = student.Address,
                        IsDelete = student.IsDelete
                    };
                    courseItem.StudentItems.Add(studentItem);
                }
                lstCourseItem.Add(courseItem);
            }
            return lstCourseItem;
        }

        public void Save(CourseCreateItem courseCreateItem)
        {
            var course = new Course()
            {
                CourseId = courseCreateItem.Id,
                Name = courseCreateItem.Name,
                Code = courseCreateItem.Code
            };
            unit.CourseRepository.InsertOrUpdate(course);
            unit.CourseRepository.Save();
        }

        public void Delete(int id)
        {
        }
    }
}
