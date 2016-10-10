using SeliseExamApp.DataAccess;
using System;

namespace SeliseExamApp.Core.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DataContext context;
        public UnitOfWork()
        {
            context = new DataContext();
        }
        public UnitOfWork(DataContext _context)
        {
            this.context = _context;
        }
        //
        public StudentRepository _studentRepository;
        public StudentRepository StudentRepository
        {
            get
            {
                if (this._studentRepository == null)
                {
                    this._studentRepository = new StudentRepository(context);
                }
                return _studentRepository;
            }
        }

        public CourseRepository _courseRepository;
        public CourseRepository CourseRepository
        {
            get
            {
                if (this._courseRepository == null)
                {
                    this._courseRepository = new CourseRepository(context);
                }
                return _courseRepository;
            }
        }
        //
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
