using People.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using People.Application.ViewModels;
using AutoMapper;
using People.Domain.Interfaces;
using People.Domain.Core.Bus;
using People.Domain.Commands;
using AutoMapper.QueryableExtensions;

namespace People.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper mapper;
        private readonly IPersonRepository personRepository;
        private readonly IMediatorHandler bus;

        public PersonAppService(IMapper mapper, IPersonRepository personRepository, IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.personRepository = personRepository;
            this.bus = bus;
        }

        public void Create(PersonViewModel personViewModel)
        {
            var createCommand = mapper.Map<CreateNewPersonCommand>(personViewModel);
            bus.SendCommand(createCommand);
        }

        public void Delete(int id)
        {
            var deleteCommand = new DeletePersonCommand(id);
            bus.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            return personRepository.GetAll().ProjectTo<PersonViewModel>();
        }

        public PersonViewModel GetById(int id)
        {
            return mapper.Map<PersonViewModel>(personRepository.GetById(id));
        }

        public void Update(PersonViewModel personViewModel)
        {
            var updateCommand = mapper.Map<UpdatePersonCommand>(personViewModel);
            bus.SendCommand(updateCommand);
        }
    }
}
