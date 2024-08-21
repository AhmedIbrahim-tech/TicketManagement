using Application.MediatR.Tickets.Commands.Requests;
using AutoMapper;
using Domain.DTOS;
using Domain.Enums;

namespace Application.Mapping.Ticket;

public class TicketMappingProfile : Profile
{
    public TicketMappingProfile()
    {
        CreateMap<CreateTicketCommand, Domain.Entities.Ticket>()
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => TicketStatus.New));





        CreateMap<Domain.Entities.Ticket, TicketDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ToString()));

    }
}
