using MediatR;
using People.Domain.Commands;
using People.Domain.Core.Bus;
using People.Domain.Core.Notifications;
using People.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using People.Domain.Models;

namespace People.Domain.CommandHandlers
{
    public class PersonCommandHandler : CommandHandler,
       INotificationHandler<CreateNewPersonCommand>,
       INotificationHandler<UpdatePersonCommand>,
       INotificationHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository personRepository;
        private readonly IMediatorHandler Bus;

        public PersonCommandHandler(IPersonRepository personRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.personRepository = personRepository;
            Bus = bus;
        }

        public void Handle(CreateNewPersonCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var person = new PersonModel(message.FirstName, message.LastName, message.Gender, message.Age);
            
            personRepository.Add(person);

            if (Commit())
            {
                //Bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        public void Handle(UpdatePersonCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var person = new PersonModel(message.FirstName, message.LastName, message.Gender, message.Age);
                     
            personRepository.Update(person);

            if (Commit())
            {
               // Bus.RaiseEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));
            }
        }

        public void Handle(DeletePersonCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            personRepository.Remove(message.Id);

            if (Commit())
            {
                //Bus.RaiseEvent(new CustomerRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            personRepository.Dispose();
        }
    }
}
