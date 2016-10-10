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
    public class StudentRepository : IRepository<Student>
    {
        DataContext context;

        public StudentRepository()
            : this(new DataContext())
        {

        }
        public StudentRepository(DataContext context)
        {

            this.context = context;
        }

        public IQueryable<Student> All
        {
            get { return context.Students; }
        }

        public IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties)
        {
            IQueryable<Student> query = context.Students;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public List<Student> GetAll()
        {
            return context.Students.Where(s => s.IsDelete != true).ToList();
        }
        public Student Find(long id)
        {
            //return context.Students.Find(id);
            return context.Students.Where(s=>s.StudentId == id).Include(s=>s.Courses).FirstOrDefault();
        }

        public Student FindByRoll(string roll)
        {
            var stu= context.Students.Where(s => s.Name == roll).FirstOrDefault();
            return stu;
        }

        public void InsertOrUpdate(Student student)
        {
            if (student.StudentId == default(long))
            {
                // New entity
                context.Students.Add(student);
            }
            else
            {
                // Existing entity
                context.Entry(student).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var student = context.Students.Find(id);
            student.IsDelete = true;
            InsertOrUpdate(student);
            Save();
            //context.Students.Remove(student);
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
