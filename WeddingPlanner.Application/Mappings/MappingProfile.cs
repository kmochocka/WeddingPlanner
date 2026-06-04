using AutoMapper;
using WeddingPlanner.SharedKernel.DTOs;
using WeddingPlanner.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeddingPlanner.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            
            CreateMap<Guest, GuestDto>().ReverseMap();
          
            CreateMap<CreateGuestDto, Guest>();

           
            CreateMap<Expense, ExpenseDto>().ReverseMap();
            CreateMap<CreateExpenseDto, Expense>();

           
            CreateMap<TaskItem, TaskDto>().ReverseMap();
            CreateMap<CreateTaskDto, TaskItem>();

            
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<CreateTableDto, Table>();
            
            CreateMap<WeddingBudget, BudgetDto>().ReverseMap();
        }
    }
}