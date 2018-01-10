using AutoMapper;
using People.Application.ViewModels;
using People.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PersonModel, PersonViewModel>();
        }
    }
}
