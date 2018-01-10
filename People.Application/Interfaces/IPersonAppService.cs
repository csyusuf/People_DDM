using People.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Application.Interfaces
{
   public interface IPersonAppService : IDisposable
    {
        void Create(PersonViewModel personViewModel);
        IEnumerable<PersonViewModel> GetAll();
        PersonViewModel GetById(int id);
        void Update(PersonViewModel personViewModel);
        void Delete(int id);
    }
}
