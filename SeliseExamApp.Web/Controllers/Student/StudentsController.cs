using SeliseExamApp.Core.DTO;
using SeliseExamApp.Core.Interfaces;
using SeliseExamApp.Core.Service;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeliseExamApp.Web.Controllers.Student
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private readonly IService<StudentItem, StudentCreateItem> studentService;

        public StudentsController()
        {
            this.studentService = new StudentService();
        }

        [Route("")]
        public HttpResponseMessage Get()
        {
            var students = this.studentService.GetAll();
            return this.Request.CreateResponse(
                HttpStatusCode.OK, students);
        }

        [Route("")]
        public HttpResponseMessage Post(StudentCreateItem student)
        {
            this.studentService.Save(student);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            this.studentService.Delete(id);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            var student = this.studentService.Find(id);
            return this.Request.CreateResponse(HttpStatusCode.OK, student);
        }
    }
}
