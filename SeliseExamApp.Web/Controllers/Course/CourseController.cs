using SeliseExamApp.Core.DTO;
using SeliseExamApp.Core.Interfaces;
using SeliseExamApp.Core.Service;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeliseExamApp.Web.Controllers.Student.Course
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        private readonly IService<CourseItem, CourseCreateItem> courseService;

        public CourseController()
        {
            this.courseService = new CourseService();
        }
        [Route("")]
        public HttpResponseMessage Get()
        {
            var courses = courseService.GetAll();
            return this.Request.CreateResponse(
                HttpStatusCode.OK, courses);
        }

        [Route("")]
        public HttpResponseMessage Post(CourseCreateItem course)
        {
            this.courseService.Save(course);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
