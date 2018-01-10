using MediatR;
using Microsoft.AspNetCore.Mvc;
using People.Application.Interfaces;
using People.Application.ViewModels;
using People.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.WebApi.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonAppService personAppService;

        public PersonController(IPersonAppService personAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.personAppService = personAppService;
        }

        [HttpGet]
        [Route("people")]
        public IActionResult GetAll()
        {
            return Response(personAppService.GetAll());
        }

        [HttpGet]
        [Route("people/{id}")]
        public IActionResult GetById(int id)
        {
            var personViewModel = personAppService.GetById(id);
            return Response(personViewModel);
        }

        [HttpPost]
        [Route("people")]
        public IActionResult Create([FromBody]PersonViewModel personViewModel)
        {
            if(!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(personViewModel);
            }

            personAppService.Create(personViewModel);
            return Response(personViewModel);
        }

        [HttpPut]
        [Route("people")]
        public IActionResult Update([FromBody]PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(personViewModel);
            }

            personAppService.Update(personViewModel);
            return Response(personViewModel);
        }

        [HttpDelete]
        [Route("people")]
        public IActionResult Delete(int id)
        {
            personAppService.Delete(id);
            return Response();
        }
        
    }
}
