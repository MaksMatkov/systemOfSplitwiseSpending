using AutoMapper;
using SplitWise.API.Models;
using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SplitWise.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>()
                .ForMember("name", el => el.MapFrom(v => v.Name))
                .ForMember("id", el => el.MapFrom(v => v.Id)).ReverseMap();

            CreateMap<UserRequest, User>()
                .ForMember("Name", el => el.MapFrom(v => v.name))
                .ForMember("Id", el => el.MapFrom(v => v.id)).ReverseMap();

            CreateMap<Group, GroupResponse>()
                .ForMember("name", el => el.MapFrom(v => v.Name))
                .ForMember("id", el => el.MapFrom(v => v.Id)).ReverseMap();

            CreateMap<GroupRequest, Group>()
                .ForMember("Name", el => el.MapFrom(v => v.name))
                .ForMember("Id", el => el.MapFrom(v => v.id)).ReverseMap();

            CreateMap<PaymentRequest, Payment>()
                .ForMember("Amount", el => el.MapFrom(v => v.amount))
                .ForMember("ToUserId", el => el.MapFrom(v => v.toUserId))
                .ForMember("Description", el => el.MapFrom(v => v.description))
                .ForMember("GroupId", el => el.MapFrom(v => v.groupId))
                .ForMember("Id", el => el.MapFrom(v => v.id)).ReverseMap();

            CreateMap<Payment, PaymentResponse>()
               .ForMember("amount", el => el.MapFrom(v => v.Amount))
               .ForMember("time", el => el.MapFrom(v => v.Time))
               .ForMember("confirmed", el => el.MapFrom(v => v.Confirmed))
               .ForMember("id", el => el.MapFrom(v => v.Id)).ReverseMap();

            CreateMap<ExpenseHeaderRequest, ExpenseHeader>()
               .ForMember("Id", el => el.MapFrom(v => v.id))
               .ForMember("Description", el => el.MapFrom(v => v.description))
               .ForMember("Date", el => el.MapFrom(v => v.date))
               .ForMember("GroupId", el => el.MapFrom(v => v.groupId)).ReverseMap();

            CreateMap<ExpenseListRequest, ExpenseList>()
               .ForMember("ExpenseHeaderId", el => el.MapFrom(v => v.expenseHeaderId))
               .ForMember("Amount", el => el.MapFrom(v => v.amount)).ReverseMap();


        }
    }
}
