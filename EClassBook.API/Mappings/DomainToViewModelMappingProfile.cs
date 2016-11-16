namespace EClassBook.API.Mappings
{
    using AutoMapper;
    using Model;
    using ViewModels;

    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Course, CourseViewModel>()
                .ForMember(vm => vm.TeacherName, map => map.MapFrom(c => c.User.FirstName + " " + c.User.LastName));

            Mapper.CreateMap<User, TeacherViewModel>()
               .ForMember(vm => vm.Email, map => map.MapFrom(c => c.Address.Email));

        }
    }
}
