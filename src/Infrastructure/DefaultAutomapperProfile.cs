using AutoMapper;
using AlphaCompanyWebApi.Controllers;
using AlphaCompanyWebApi.Models;
using AlphaCompanyWebApi.Entitites;
using System.Collections.Generic;

namespace AlphaCompanyWebApi.Infrastructure
{
    public class DefaultAutomapperProfile : Profile
    {
        public DefaultAutomapperProfile()
        {
            CreateMap<ConversationEntity, ConversationResource>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                    nameof(FinancialJourneyController.GetConversationByIdAsync),
                    new GetConversationByIdParameters { ConversationId = src.Id })))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => Link.ToCollection(
                    nameof(FinancialJourneyController.GetConversationCommentsByIdAsync),
                    new GetConversationByIdParameters { ConversationId = src.Id })));

            CreateMap<CustomerEntity, CustomerResource>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                    nameof(CustomerController.GetCommentByIdAsync),
                    new GetCommentByIdParameters { CommentId = src.Id })))
                .ForMember(dest => dest.Conversation, opt => opt.MapFrom(src => Link.To(
                    nameof(FinancialJourneyController.GetConversationByIdAsync),
                    new GetConversationByIdParameters { ConversationId = src.Conversation.Id })));

            CreateMap<Product, ProductModel>();
            //CreateMap<List<Product>, ProductModel>();



        }
    }
}
