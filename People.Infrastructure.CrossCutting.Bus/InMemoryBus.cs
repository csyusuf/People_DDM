using MediatR;
using People.Domain.Core.Bus;
using People.Domain.Core.Commands;
using People.Domain.Core.Events;
using System;
using System.Threading.Tasks;

namespace People.Infrastructure.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;

        public InMemoryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return Publish(command);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return mediator.Publish(message);
        }
    }
}
