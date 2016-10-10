using SeliseExamApp.Core.Interfaces;
using SeliseExamApp.DataAccess;
using SeliseExamApp.DataAccess.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SeliseExamApp.Core.Repository
{
    public class CourseRepository : IRepository<Course>
    {
        DataContext context;

        public CourseRepository()
            : this(new DataContext())
        {

        }
        public CourseRepository(DataContext context)
        {

            this.context = context;
        }

        public IQueryable<Course> All
        {
            get { return context.Courses; }
        }

        public IQueryable<Course> AllIncluding(params Expression<Func<Course, object>>[] includeProperties)
        {
            IQueryable<Course> query = context.Courses;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public List<Course> GetAll()
        {
            return context.Courses.Where(c => c.IsDelete != true).Include(c=>c.Students).ToList();
        }

        public Course Find(long id)
        {
            //return context.Students.Find(id);
            return context.Courses.Where(c=>c.CourseId==id && c.IsDelete !=true).FirstOrDefault();
        }

        public void InsertOrUpdate(Course course)
        {
            if (course.CourseId == default(long))
            {
                // New entity
                context.Courses.Add(course);
            }
            else
            {
                // Existing entity
                context.Entry(course).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var course = context.Courses.Find(id);
            course.IsDelete = true;
            InsertOrUpdate(course);
            Save();
            //context.Courses.Remove(course);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
