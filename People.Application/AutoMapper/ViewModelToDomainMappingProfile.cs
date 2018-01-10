using AutoMapper;
using People.Application.ViewModels;
using People.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, CreateNewPersonCommand>()
                .ConstructUsing(c => new CreateNewPersonCommand(c.FirstName, c.LastName, c.Gender, c.Age));
            CreateMap<PersonViewModel, UpdatePersonCommand>()
                .ConstructUsing(c => new UpdatePersonCommand(c.ID,c.FirstName, c.LastName, c.Gender, c.Age));
        }
    }
}
