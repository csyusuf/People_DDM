using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace People.Application.ViewModels
{
   public class PersonViewModel
    {
        public int ID { get; set; }

        [DisplayName("Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Age")]
        public int Age { get; set; }
    }
}
