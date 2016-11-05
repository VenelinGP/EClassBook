// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EClassBook.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Common.Models;
    using ViewModels;
    using Model;
    using AutoMapper;

    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        IUserRepository userRepository;
        ICourseRepository courseRepository;
        ILoggingRepository loggingRepository;

        public TeacherController(IUserRepository userRepository, ICourseRepository courseRepository, ILoggingRepository loggingRepository)
        {
            this.userRepository = userRepository;
            this.courseRepository = courseRepository;
            this.loggingRepository = loggingRepository;
        }

        [HttpGet]
        public IEnumerable<User> Index()
        {
            List<User> teachers = null;
            try
            {

                teachers = userRepository
                    .FindBy(t => t.RoleId == 2)
                    .ToList();
                IEnumerable<TeacherViewModel> teachersVM = Mapper.Map<IEnumerable<User>, IEnumerable<TeacherViewModel>>(teachers);

            }
            catch (Exception ex)
            {
                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }
            return teachers;
        }

        [HttpGet("{id:int}")]
        public IEnumerable<CourseViewModel> Get(int id)
        {
            IEnumerable<Course> courses = null;
            User user = userRepository.GetSingle(a => a.Id == id);
            try
            {
                courses = courseRepository
                    .FindBy(c => c.UserId == user.Id)
                    .OrderBy(c => c.Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }
            var coursesVM = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return coursesVM;
        }
    }
}
