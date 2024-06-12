using AutoMapper;
using MyFinances.API.Models.Domain;
using MyFinances.API.Models.DTOs;

namespace MyFinances.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Expense, ExpenseDTO>().ReverseMap();
        }
    }
}
