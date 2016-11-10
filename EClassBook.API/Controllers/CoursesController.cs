namespace EClassBook.API.Controllers
{
    using AutoMapper;
    using Common.Infrastructure.Core;
    using Common.Models;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using System;
    using System.Collections.Generic;
    using ViewModels;

    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        //IUserRepository userRepository;
        ICourseRepository courseRepository;
        ILoggingRepository loggingRepository;

        public CoursesController(ICourseRepository courseRepository, ILoggingRepository loggingRepository)
        {
            this.courseRepository = courseRepository;
            this.loggingRepository = loggingRepository;
        }


        [HttpGet]
        public IEnumerable<CourseViewModel> Get()
        {
            IEnumerable<Course> courses = null;
            try
            {
                courses = courseRepository
                    .AllIncluding(c => c.User);
            }
            catch (Exception ex)
            {
                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }
            var coursesVM = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);
            return coursesVM;
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            IActionResult result = new ObjectResult(false);
            GenericResult removeResult = null;

            try
            {
                Course courseToRemove = this.courseRepository.GetSingle(id);
                this.courseRepository.Delete(courseToRemove);
                this.courseRepository.Commit();

                removeResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Photo removed."
                };
            }
            catch (Exception ex)
            {
                removeResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }

            result = new ObjectResult(removeResult);
            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Course course)
        {
            IActionResult result = new ObjectResult(false);
            GenericResult addingResult = null;
            try
            {
                this.courseRepository.Add(course);
                this.courseRepository.Commit();

                addingResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Course added."
                };
            }
            catch (Exception ex)
            {

                addingResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }

            result = new ObjectResult(addingResult);
            return result;

        }
    }
}
