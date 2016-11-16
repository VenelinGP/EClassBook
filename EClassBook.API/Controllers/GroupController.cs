namespace EClassBook.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using Common.Models;
    using ViewModels;
    using AutoMapper;
    using Common.Infrastructure.Core;

    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        IUserRepository userRepository;
        IGroupRepository groupRepository;
        ILoggingRepository loggingRepository;

        public GroupController(IUserRepository userRepository, IGroupRepository groupRepository, ILoggingRepository loggingRepository)
        {
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.loggingRepository = loggingRepository;
        }


        [HttpGet]
        public IEnumerable<Group> Index()
        {
            List<Group> groups = null;
            try
            {
                groups = groupRepository
                    .GetAll()
                    .ToList();
            }
            catch (Exception ex)
            {
                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }
            //var groupsVM = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groups);
            return groups;
        }

        [HttpGet("{id:int}")]
        public IEnumerable<Group> Get(int id)
        {
            IEnumerable<Group> groups = null;
            User user = userRepository.GetSingle(a => a.Id == id);
            try
            {
                //groups = userRepository
                //    .FindBy(c => c.GroupId == id)
                //    .ToList();
            }
            catch (Exception ex)
            {
                loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedOn = DateTime.Now });
                loggingRepository.Commit();
            }
            //var coursesVM = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return groups;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Group group)
        {
            IActionResult result = new ObjectResult(false);
            GenericResult addingResult = null;
            try
            {
                this.groupRepository.Add(group);
                this.groupRepository.Commit();

                addingResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Group added."
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
